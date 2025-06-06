using GlobalSolutionNoBreaker.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;

namespace NobreakSystem.Repository
{
    /// <summary>
    /// Repositório responsável pelo gerenciamento de dados de monitoramento dos nobreaks.
    /// </summary>
    /// <remarks>
    /// Esta classe fornece funcionalidades para inserir leituras de monitoramento,
    /// obter dados de status dos nobreaks, gerar dados aleatórios para simulação
    /// e calcular estatísticas de monitoramento.
    /// </remarks>
    public class MonitoramentoRepository
    {
        /// <summary>
        /// String de conexão com o banco de dados SQLite.
        /// </summary>
        private readonly string _connectionString = $"Data Source={NobreakRepository.DbPath};Version=3;";

        /// <summary>
        /// Inicializa uma nova instância da classe MonitoramentoRepository.
        /// </summary>
        /// <param name="connectionString">String de conexão personalizada com o banco de dados.</param>
        /// <remarks>
        /// O construtor permite sobrescrever a string de conexão padrão se necessário.
        /// </remarks>
        public MonitoramentoRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        /// <summary>
        /// Busca todos os IDs dos nobreaks que estão atualmente ativos no sistema.
        /// </summary>
        /// <returns>Lista contendo os IDs dos nobreaks ativos.</returns>
        /// <exception cref="Exception">
        /// Lançada quando ocorre erro ao acessar o banco de dados.
        /// </exception>
        /// <remarks>
        /// Considera apenas nobreaks com StatusOperacional = 'Ativo'.
        /// </remarks>
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
        /// Insere uma nova leitura de monitoramento no banco de dados.
        /// </summary>
        /// <param name="nobreakId">ID do nobreak sendo monitorado.</param>
        /// <param name="cargaAtualVA">Carga atual em VA (Volt-Ampere).</param>
        /// <param name="porcentagemBateria">Percentual de carga da bateria (0-100).</param>
        /// <param name="codigoEstado">Código do estado operacional do nobreak.</param>
        /// <exception cref="Exception">
        /// Lançada quando ocorre erro ao inserir a leitura no banco de dados.
        /// </exception>
        /// <remarks>
        /// O timestamp da leitura é definido automaticamente pelo banco de dados.
        /// </remarks>
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
                        // Utiliza parâmetros para evitar SQL injection
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
        /// Atualiza o nível de bateria de um nobreak específico.
        /// </summary>
        /// <param name="nobreakId">ID do nobreak a ser atualizado.</param>
        /// <param name="batteryLevel">Novo nível de bateria em percentual (0-100).</param>
        /// <exception cref="Exception">
        /// Lançada quando ocorre erro ao atualizar o banco de dados.
        /// </exception>
        /// <remarks>
        /// Além de atualizar o nível da bateria, também registra o timestamp da atualização.
        /// </remarks>
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
        /// Busca dados completos de monitoramento de todos os nobreaks ativos para exibição.
        /// </summary>
        /// <returns>DataTable contendo os dados de monitoramento formatados.</returns>
        /// <exception cref="Exception">
        /// Lançada quando ocorre erro ao carregar os dados do banco.
        /// </exception>
        /// <remarks>
        /// Retorna informações detalhadas incluindo modelo, localização, carga atual,
        /// percentual de bateria, status traduzido e timestamp da última leitura.
        /// Utiliza a leitura mais recente de cada nobreak.
        /// </remarks>
        public DataTable GetMonitoringData()
        {
            try
            {
                using (var connection = new SQLiteConnection(_connectionString))
                {
                    connection.Open();

                    // Consulta complexa que combina dados de nobreaks, modelos e último monitoramento
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
        /// Gera e insere uma leitura aleatória para um nobreak específico.
        /// </summary>
        /// <param name="nobreakId">ID do nobreak para o qual gerar a leitura.</param>
        /// <param name="random">Instância do gerador de números aleatórios.</param>
        /// <remarks>
        /// Gera valores realistas de carga (100-2000 VA)
        /// e percentual de bateria (10-100%). O código de estado é determinado automaticamente
        /// com base nos valores gerados.
        /// </remarks>
        public void GenerateRandomReadingForNobreak(int nobreakId, Random random)
        {
            // Gera valores aleatórios dentro de faixas realistas
            int cargaAtual = random.Next(100, 2000); // VA entre 100 e 2000
            int percentualBateria = random.Next(10, 100); // Entre 10% e 100%

            // Determina o código de estado baseado nas condições simuladas
            int codigoEstado = DetermineStatusCode(percentualBateria, cargaAtual, random);

            // Insere a leitura e atualiza o registro do nobreak
            InsertMonitoringReading(nobreakId, cargaAtual, percentualBateria, codigoEstado);
            UpdateNobreakBatteryLevel(nobreakId, percentualBateria);
        }

        /// <summary>
        /// Determina o código de status baseado nas condições operacionais do nobreak.
        /// </summary>
        /// <param name="batteryPercent">Percentual atual da bateria.</param>
        /// <param name="currentLoad">Carga atual em VA.</param>
        /// <param name="random">Gerador de números aleatórios para simulação.</param>
        /// <returns>
        /// Código de estado: 0=Operacional, 1=Bateria Fraca, 2=Sobrecarga, 3=Desligado.
        /// </returns>
        /// <remarks>
        /// Implementa uma lógica de prioridade: Desligado > Bateria Fraca > Sobrecarga > Operacional.
        /// Inclui 2% de chance aleatória de simular desligamento inesperado.
        /// </remarks>
        private int DetermineStatusCode(int batteryPercent, int currentLoad, Random random)
        {
            // Implementa prioridade: Desligado > Bateria Fraca > Sobrecarga > Operacional
            if (random.Next(1, 100) <= 2) // 2% de chance de estar desligado
                return 3; // Desligado

            if (batteryPercent < 20) // Bateria crítica
                return 1; // Bateria Fraca

            if (currentLoad > 1800) // Carga muito alta
                return 2; // Sobrecarga

            return 0; // Operacional
        }

        /// <summary>
        /// Gera leituras aleatórias para todos os nobreaks ativos no sistema.
        /// </summary>
        /// <remarks>
        /// Utiliza uma única instância de Random para garantir distribuição adequada.
        /// </remarks>
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
        /// Verifica se existem nobreaks ativos disponíveis para monitoramento.
        /// </summary>
        /// <returns>True se houver nobreaks ativos, False caso contrário.</returns>
        /// <remarks>
        /// Método utilitário para validar se o sistema tem dispositivos para monitorar.
        /// </remarks>
        public bool HasActiveNobreaks()
        {
            return GetActiveNobreakIds().Count > 0;
        }

        /// <summary>
        /// Obtém estatísticas consolidadas do monitoramento de todos os nobreaks ativos.
        /// </summary>
        /// <returns>Objeto MonitoringStats com as estatísticas atuais.</returns>
        /// <exception cref="Exception">
        /// Lançada quando ocorre erro ao calcular as estatísticas.
        /// </exception>
        /// <remarks>
        /// Baseia-se na leitura mais recente de cada nobreak para calcular as estatísticas.
        /// Em caso de erro, retorna um objeto MonitoringStats vazio.
        /// </remarks>
        public MonitoringStats GetMonitoringStats()
        {
            try
            {
                using (var connection = new SQLiteConnection(_connectionString))
                {
                    connection.Open();

                    // Consulta que agrega estatísticas por código de estado
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

            // Retorna objeto vazio em caso de falha na consulta
            return new MonitoringStats();
        }
    }

    /// <summary>
    /// Classe que representa as estatísticas consolidadas de monitoramento dos nobreaks.
    /// </summary>
    /// <remarks>
    /// Utilizada para agrupar informações quantitativas sobre o status 
    /// operacional dos nobreaks no sistema.
    /// </remarks>
    public class MonitoringStats
    {
        /// <summary>
        /// Número total de nobreaks ativos no sistema.
        /// </summary>
        public int TotalNobreaks { get; set; }

        /// <summary>
        /// Quantidade de nobreaks em estado operacional normal.
        /// </summary>
        public int Operacionais { get; set; }

        /// <summary>
        /// Quantidade de nobreaks com bateria fraca (abaixo de 20%).
        /// </summary>
        public int BateriaFraca { get; set; }

        /// <summary>
        /// Quantidade de nobreaks em estado de sobrecarga.
        /// </summary>
        public int Sobrecarga { get; set; }

        /// <summary>
        /// Quantidade de nobreaks que estão desligados.
        /// </summary>
        public int Desligados { get; set; }
    }
}