using GlobalSolutionNoBreaker.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;

namespace NobreakSystem.Repository
{
    public class MonitoramentoRepository
    {
        private readonly string _connectionString = $"Data Source={NobreakRepository.DbPath};Version=3;";

        public MonitoramentoRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        /// <summary>
        /// Busca todos os nobreaks ativos para monitoramento
        /// </summary>
        public List<int> GetActiveNobreakIds()
        {
            var nobreakIds = new List<int>();

            try
            {
                using (var connection = new SQLiteConnection(_connectionString))
                {
                    connection.Open();

                    string query = "SELECT Id FROM Nobreaks WHERE StatusOperacional = 'Ativo'";

                    using (var command = new SQLiteCommand(query, connection))
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            nobreakIds.Add(reader.GetInt32("Id"));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao buscar nobreaks ativos: {ex.Message}", ex);
            }

            return nobreakIds;
        }

        /// <summary>
        /// Insere uma nova leitura de monitoramento
        /// </summary>
        public void InsertMonitoringReading(int nobreakId, int cargaAtualVA, int porcentagemBateria, int codigoEstado)
        {
            try
            {
                using (var connection = new SQLiteConnection(_connectionString))
                {
                    connection.Open();

                    string query = @"
                        INSERT INTO Monitoramento (NobreakId, CargaAtualVA, PorcentagemBateria, CodigoEstado)
                        VALUES (@NobreakId, @CargaAtualVA, @PorcentagemBateria, @CodigoEstado)";

                    using (var command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@NobreakId", nobreakId);
                        command.Parameters.AddWithValue("@CargaAtualVA", cargaAtualVA);
                        command.Parameters.AddWithValue("@PorcentagemBateria", porcentagemBateria);
                        command.Parameters.AddWithValue("@CodigoEstado", codigoEstado);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao inserir leitura de monitoramento: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Atualiza o nível da bateria do nobreak
        /// </summary>
        public void UpdateNobreakBatteryLevel(int nobreakId, int batteryLevel)
        {
            try
            {
                using (var connection = new SQLiteConnection(_connectionString))
                {
                    connection.Open();

                    string query = @"
                        UPDATE Nobreaks 
                        SET NivelBateriaPercent = @NivelBateria, 
                            AtualizadoEm = datetime('now')
                        WHERE Id = @Id";

                    using (var command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@NivelBateria", batteryLevel);
                        command.Parameters.AddWithValue("@Id", nobreakId);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao atualizar nível da bateria: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Busca dados completos de monitoramento para exibição
        /// </summary>
        public DataTable GetMonitoringData()
        {
            try
            {
                using (var connection = new SQLiteConnection(_connectionString))
                {
                    connection.Open();

                    string query = @"
                        SELECT 
                            n.Id,
                            m.Nome as Modelo,
                            n.Localizacao,
                            COALESCE(latest.CargaAtualVA, 0) as CargaAtual,
                            n.NivelBateriaPercent as PorcentagemBateria,
                            CASE 
                                WHEN COALESCE(latest.CodigoEstado, 0) = 0 THEN 'Operacional'
                                WHEN COALESCE(latest.CodigoEstado, 0) = 1 THEN 'Bateria Fraca'
                                WHEN COALESCE(latest.CodigoEstado, 0) = 2 THEN 'Sobrecarga'
                                WHEN COALESCE(latest.CodigoEstado, 0) = 3 THEN 'Desligado'
                                ELSE 'Desconhecido'
                            END as Status,
                            COALESCE(latest.CodigoEstado, 0) as CodigoEstado,
                            COALESCE(latest.Timestamp, '') as UltimaLeitura
                        FROM Nobreaks n
                        LEFT JOIN Modelos m ON n.ModeloId = m.Id
                        LEFT JOIN (
                            SELECT 
                                NobreakId,
                                CargaAtualVA,
                                CodigoEstado,
                                Timestamp,
                                ROW_NUMBER() OVER (PARTITION BY NobreakId ORDER BY Timestamp DESC) as rn
                            FROM Monitoramento
                        ) latest ON n.Id = latest.NobreakId AND latest.rn = 1
                        WHERE n.StatusOperacional = 'Ativo'
                        ORDER BY n.Id";

                    using (var adapter = new SQLiteDataAdapter(query, connection))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        return dataTable;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao carregar dados de monitoramento: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Gera e insere uma leitura aleatória para um nobreak específico
        /// </summary>
        public void GenerateRandomReadingForNobreak(int nobreakId, Random random)
        {
            // Gera valores aleatórios realistas
            int cargaAtual = random.Next(100, 2000); // VA entre 100 e 2000
            int percentualBateria = random.Next(10, 100); // Entre 10% e 100%

            // Define código de estado baseado no percentual da bateria e carga
            int codigoEstado = DetermineStatusCode(percentualBateria, cargaAtual, random);

            // Insere a leitura e atualiza o nobreak
            InsertMonitoringReading(nobreakId, cargaAtual, percentualBateria, codigoEstado);
            UpdateNobreakBatteryLevel(nobreakId, percentualBateria);
        }

        /// <summary>
        /// Determina o código de status baseado nas condições do nobreak
        /// </summary>
        private int DetermineStatusCode(int batteryPercent, int currentLoad, Random random)
        {
            // Prioridade: Desligado > Bateria Fraca > Sobrecarga > Operacional
            if (random.Next(1, 100) <= 2) // 2% de chance de estar desligado
                return 3; // Desligado

            if (batteryPercent < 20)
                return 1; // Bateria Fraca

            if (currentLoad > 1800)
                return 2; // Sobrecarga

            return 0; // Operacional
        }

        /// <summary>
        /// Gera leituras aleatórias para todos os nobreaks ativos
        /// </summary>
        public void GenerateRandomReadingsForAllActive()
        {
            var random = new Random();
            var activeNobreaks = GetActiveNobreakIds();

            foreach (int nobreakId in activeNobreaks)
            {
                GenerateRandomReadingForNobreak(nobreakId, random);
            }
        }

        /// <summary>
        /// Verifica se existem nobreaks ativos para monitoramento
        /// </summary>
        public bool HasActiveNobreaks()
        {
            return GetActiveNobreakIds().Count > 0;
        }

        /// <summary>
        /// Obtém estatísticas básicas do monitoramento
        /// </summary>
        public MonitoringStats GetMonitoringStats()
        {
            try
            {
                using (var connection = new SQLiteConnection(_connectionString))
                {
                    connection.Open();

                    string query = @"
                        SELECT 
                            COUNT(*) as TotalNobreaks,
                            SUM(CASE WHEN latest.CodigoEstado = 0 THEN 1 ELSE 0 END) as Operacionais,
                            SUM(CASE WHEN latest.CodigoEstado = 1 THEN 1 ELSE 0 END) as BateriaFraca,
                            SUM(CASE WHEN latest.CodigoEstado = 2 THEN 1 ELSE 0 END) as Sobrecarga,
                            SUM(CASE WHEN latest.CodigoEstado = 3 THEN 1 ELSE 0 END) as Desligados
                        FROM Nobreaks n
                        LEFT JOIN (
                            SELECT 
                                NobreakId,
                                CodigoEstado,
                                ROW_NUMBER() OVER (PARTITION BY NobreakId ORDER BY Timestamp DESC) as rn
                            FROM Monitoramento
                        ) latest ON n.Id = latest.NobreakId AND latest.rn = 1
                        WHERE n.StatusOperacional = 'Ativo'";

                    using (var command = new SQLiteCommand(query, connection))
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new MonitoringStats
                            {
                                TotalNobreaks = reader.GetInt32("TotalNobreaks"),
                                Operacionais = reader.GetInt32("Operacionais"),
                                BateriaFraca = reader.GetInt32("BateriaFraca"),
                                Sobrecarga = reader.GetInt32("Sobrecarga"),
                                Desligados = reader.GetInt32("Desligados")
                            };
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao obter estatísticas: {ex.Message}", ex);
            }

            return new MonitoringStats();
        }
    }

    /// <summary>
    /// Classe para estatísticas de monitoramento
    /// </summary>
    public class MonitoringStats
    {
        public int TotalNobreaks { get; set; }
        public int Operacionais { get; set; }
        public int BateriaFraca { get; set; }
        public int Sobrecarga { get; set; }
        public int Desligados { get; set; }
    }
}