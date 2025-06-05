using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalSolutionNoBreaker.Data
{
    public static class DataPopulator
    {
        private static Random random = new Random();

        // Define o caminho para AppData\Roaming\NobreakerSystemApp
        private static string path = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
            "NobreakerSystemApp"
        );

        // Caminho completo do arquivo .db
        private static string dbPath = Path.Combine(path, "NoBreakerSystem.db");

        private static string[] sectors = { "UTI", "Centro Cirúrgico", "Radiologia", "Emergência", "TI", "Farmácia", "Laboratório de Análise", "Sala do Servidor" };
        private static string[] equipmentNames = { "Monitor cardíaco", "Ventilador pulmonar", "Bomba de infusão", "Ultrassom", "Desfibrilador", "Computador hospitalar", "Servidor Hospitalar" };
        private static string[] equipmentTypes = { "Crítico", "Suporte", "Diagnóstico" };
        private static string[] statuses = { "Ativo", "Crítico", "Inativo" };
        private static string[] incidentTypes = { "Bateria Fraca", "Falha no Inversor", "Sobrecarga", "Desligamento Inesperado" };
        private static string[] incidentStatuses = { "Aberto", "Em Análise", "Resolvido" };

        public static void Populate()
        {
            try
            {
                using (var connection = new SQLiteConnection($"Data Source={dbPath}"))
                {
                    connection.Open();


                    // Verifica se as tabelas principais já têm dados
                    if (TabelasJaPopuladas(connection))
                    {
                        Console.WriteLine("📋 Banco de dados já possui dados. Operação cancelada.");
                        return;
                    }

                    // Primeiro, verifica e insere modelos se necessário
                    InserirModelosPadrao(connection);

                    List<long> nobreakIds = new List<long>();

                    // 1. Insert Nobreaks
                    Console.WriteLine("Inserindo Nobreaks...");
                    for (int i = 0; i < 20; i++)
                    {
                        int modeloId = RandomInt(1, 6);
                        string local = RandomChoice(sectors);
                        string dataAquisicao = RandomDate(1000, 2000);
                        string dataGarantia = FutureDate(30, 365);
                        string ultimaManutencao = RandomDate(365, 30);
                        string proximaTroca = FutureDate(30, 180);
                        string status = RandomChoice(statuses);
                        int nivelBateria = RandomInt(30, 100);
                        string criadoPor = GenerateEmail();

                        string sql = @"
                            INSERT INTO Nobreaks (
                                ModeloId, Localizacao, DataAquisicao, DataGarantia,
                                DataUltimaManutencao, ProximaTrocaBateria,
                                StatusOperacional, NivelBateriaPercent, CriadoPor
                            ) VALUES (@ModeloId, @Localizacao, @DataAquisicao, @DataGarantia,
                                    @UltimaManutencao, @ProximaTroca, @Status, @NivelBateria, @CriadoPor)";

                        using (var command = new SQLiteCommand(sql, connection))
                        {
                            command.Parameters.AddWithValue("@ModeloId", modeloId);
                            command.Parameters.AddWithValue("@Localizacao", local);
                            command.Parameters.AddWithValue("@DataAquisicao", dataAquisicao);
                            command.Parameters.AddWithValue("@DataGarantia", dataGarantia);
                            command.Parameters.AddWithValue("@UltimaManutencao", ultimaManutencao);
                            command.Parameters.AddWithValue("@ProximaTroca", proximaTroca);
                            command.Parameters.AddWithValue("@Status", status);
                            command.Parameters.AddWithValue("@NivelBateria", nivelBateria);
                            command.Parameters.AddWithValue("@CriadoPor", criadoPor);

                            command.ExecuteNonQuery();

                            // Get the last inserted row ID
                            using (var idCommand = new SQLiteCommand("SELECT last_insert_rowid()", connection))
                            {
                                long lastId = (long)idCommand.ExecuteScalar();
                                nobreakIds.Add(lastId);
                            }
                        }
                    }

                    // 2. Insert Equipment
                    Console.WriteLine("Inserindo Equipamentos...");
                    foreach (long nobreakId in nobreakIds)
                    {
                        int equipmentCount = RandomInt(1, 3);
                        for (int i = 0; i < equipmentCount; i++)
                        {
                            string nome = RandomChoice(equipmentNames);
                            string tipo = RandomChoice(equipmentTypes);

                            string sql = "INSERT INTO Equipamentos (Nome, Tipo, NobreakId) VALUES (@Nome, @Tipo, @NobreakId)";

                            using (var command = new SQLiteCommand(sql, connection))
                            {
                                command.Parameters.AddWithValue("@Nome", nome);
                                command.Parameters.AddWithValue("@Tipo", tipo);
                                command.Parameters.AddWithValue("@NobreakId", nobreakId);
                                command.ExecuteNonQuery();
                            }
                        }
                    }

                    // 3. Insert Monitoring
                    Console.WriteLine("Inserindo dados de Monitoramento...");
                    foreach (long nobreakId in nobreakIds)
                    {
                        for (int i = 0; i < 10; i++)
                        {
                            int cargaVa = RandomInt(500, 4500);
                            int porcentagem = RandomInt(10, 100);
                            int codigoEstado = RandomInt(0, 3);
                            string timestamp = RandomDate(30, 0) + " " + RandomTime();

                            string sql = @"
                                INSERT INTO Monitoramento (NobreakId, Timestamp, CargaAtualVA, PorcentagemBateria, CodigoEstado)
                                VALUES (@NobreakId, @Timestamp, @CargaVa, @Porcentagem, @CodigoEstado)";

                            using (var command = new SQLiteCommand(sql, connection))
                            {
                                command.Parameters.AddWithValue("@NobreakId", nobreakId);
                                command.Parameters.AddWithValue("@Timestamp", timestamp);
                                command.Parameters.AddWithValue("@CargaVa", cargaVa);
                                command.Parameters.AddWithValue("@Porcentagem", porcentagem);
                                command.Parameters.AddWithValue("@CodigoEstado", codigoEstado);
                                command.ExecuteNonQuery();
                            }
                        }
                    }

                    // 4. Insert Incidents
                    Console.WriteLine("Inserindo Incidentes...");
                    for (int i = 0; i < 15; i++)
                    {
                        long nobreakId = RandomChoice(nobreakIds);
                        string tipo = RandomChoice(incidentTypes);
                        string status = RandomChoice(incidentStatuses);
                        int prioridade = RandomInt(1, 3);
                        string dataHora = RandomDate(5, 0) + " " + RandomTime();

                        string sql = @"
                            INSERT INTO Incidentes (NobreakId, TipoIncidente, StatusAtual, Prioridade, DataHora)
                            VALUES (@NobreakId, @Tipo, @Status, @Prioridade, @DataHora)";

                        using (var command = new SQLiteCommand(sql, connection))
                        {
                            command.Parameters.AddWithValue("@NobreakId", nobreakId);
                            command.Parameters.AddWithValue("@Tipo", tipo);
                            command.Parameters.AddWithValue("@Status", status);
                            command.Parameters.AddWithValue("@Prioridade", prioridade);
                            command.Parameters.AddWithValue("@DataHora", dataHora);
                            command.ExecuteNonQuery();
                        }
                    }

                    connection.Close();
                }

                Console.WriteLine("✔️ Dados populados com sucesso no banco NoBreakerSystem.db");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro: {ex.Message}");
                throw; // Re-throw para permitir tratamento pelo código chamador
            }
        }

        private static void InserirModelosPadrao(SQLiteConnection connection)
        {
            // Verifica se já existem modelos na tabela
            string checkModelos = "SELECT COUNT(*) FROM Modelos";
            using (var cmd = new SQLiteCommand(checkModelos, connection))
            {
                long count = (long)cmd.ExecuteScalar();
                if (count == 0)
                {
                    Console.WriteLine("Inserindo Modelos padrão...");

                    // Lista de modelos para inserir
                    var modelos = new[]
                    {
                        new { Nome = "Engetron Double Way Monofásico Modular DWMM 6 kVA", CapacidadeVA = 6000, TempoDeGarantia = 5, TempoTrocaBateria = 4, VidaUtilAnos = 8 },
                        new { Nome = "Intelbras DNB ISO 6 kVA", CapacidadeVA = 6000, TempoDeGarantia = 2, TempoTrocaBateria = 3, VidaUtilAnos = 8 },
                        new { Nome = "Delta Série RT 6 kVA", CapacidadeVA = 6000, TempoDeGarantia = 2, TempoTrocaBateria = 3, VidaUtilAnos = 10 },
                        new { Nome = "TS Shara SYAL EM 4 kVA", CapacidadeVA = 4000, TempoDeGarantia = 2, TempoTrocaBateria = 3, VidaUtilAnos = 8 },
                        new { Nome = "Eaton 9PX3000RT", CapacidadeVA = 3000, TempoDeGarantia = 3, TempoTrocaBateria = 3, VidaUtilAnos = 10 },
                        new { Nome = "APC Symmetra PX 10 kVA", CapacidadeVA = 10000, TempoDeGarantia = 1, TempoTrocaBateria = 4, VidaUtilAnos = 10 }
                    };

                    string insertModelo = @"
                        INSERT INTO Modelos (Nome, CapacidadeVA, TempoDeGarantia, TempoTrocaBateria, VidaUtilAnos)
                        VALUES (@Nome, @CapacidadeVA, @TempoDeGarantia, @TempoTrocaBateria, @VidaUtilAnos)";

                    foreach (var modelo in modelos)
                    {
                        using (var insertCmd = new SQLiteCommand(insertModelo, connection))
                        {
                            insertCmd.Parameters.AddWithValue("@Nome", modelo.Nome);
                            insertCmd.Parameters.AddWithValue("@CapacidadeVA", modelo.CapacidadeVA);
                            insertCmd.Parameters.AddWithValue("@TempoDeGarantia", modelo.TempoDeGarantia);
                            insertCmd.Parameters.AddWithValue("@TempoTrocaBateria", modelo.TempoTrocaBateria);
                            insertCmd.Parameters.AddWithValue("@VidaUtilAnos", modelo.VidaUtilAnos);
                            insertCmd.ExecuteNonQuery();
                        }
                    }
                }
            }
        }

        private static bool TabelasJaPopuladas(SQLiteConnection connection)
        {
            try
            {
                // Verifica se as principais tabelas têm dados
                var tabelasParaVerificar = new[]
                {
                    "Nobreaks",
                    "Equipamentos",
                    "Monitoramento",
                    "Incidentes"
                };

                foreach (string tabela in tabelasParaVerificar)
                {
                    string query = $"SELECT COUNT(*) FROM {tabela}";
                    using (var cmd = new SQLiteCommand(query, connection))
                    {
                        long count = (long)cmd.ExecuteScalar();
                        if (count > 0)
                        {
                            Console.WriteLine($"⚠️  Tabela {tabela} já contém {count} registro(s).");
                            return true;
                        }
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Erro ao verificar tabelas: {ex.Message}");
                // Se não conseguir verificar, assume que pode popular (mais seguro)
                return false;
            }
        }

        // Utility methods
        private static int RandomInt(int min, int max)
        {
            return random.Next(min, max + 1);
        }

        private static T RandomChoice<T>(T[] array)
        {
            return array[random.Next(array.Length)];
        }

        private static T RandomChoice<T>(List<T> list)
        {
            return list[random.Next(list.Count)];
        }

        private static string RandomDate(int startDaysAgo, int endDaysAgo)
        {
            if (startDaysAgo > endDaysAgo)
            {
                int temp = startDaysAgo;
                startDaysAgo = endDaysAgo;
                endDaysAgo = temp;
            }

            int daysAgo = RandomInt(startDaysAgo, endDaysAgo);
            DateTime date = DateTime.Now.AddDays(-daysAgo);
            return date.ToString("yyyy-MM-dd");
        }

        private static string FutureDate(int startDays, int endDays)
        {
            int days = RandomInt(startDays, endDays);
            DateTime date = DateTime.Now.AddDays(days);
            return date.ToString("yyyy-MM-dd");
        }

        private static string RandomTime()
        {
            int hours = random.Next(0, 24);
            int minutes = random.Next(0, 60);
            int seconds = random.Next(0, 60);
            return $"{hours:D2}:{minutes:D2}:{seconds:D2}";
        }

        private static string GenerateEmail()
        {
            string[] firstNames = { "joao", "maria", "jose", "ana", "carlos", "lucia", "paulo", "fernanda" };
            string[] lastNames = { "silva", "santos", "oliveira", "souza", "rodrigues", "ferreira", "alves", "pereira" };
            string[] domains = { "gmail.com", "yahoo.com", "hotmail.com", "outlook.com" };

            string firstName = RandomChoice(firstNames);
            string lastName = RandomChoice(lastNames);
            string domain = RandomChoice(domains);

            return $"{firstName}.{lastName}@{domain}";
        }

        // Método adicional para verificar se o banco já foi populado
        public static bool JaFoiPopulado()
        {
            try
            {
                using (var connection = new SQLiteConnection($"Data Source={dbPath}"))
                {
                    connection.Open();
                    string checkQuery = "SELECT COUNT(*) FROM Nobreaks";
                    using (var cmd = new SQLiteCommand(checkQuery, connection))
                    {
                        long count = (long)cmd.ExecuteScalar();
                        return count > 0;
                    }
                }
            }
            catch
            {
                return false;
            }
        }
    }
}