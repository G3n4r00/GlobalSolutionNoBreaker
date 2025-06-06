using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Org.BouncyCastle.Asn1.Cmp.Challenge;

namespace GlobalSolutionNoBreaker.Data
{
    /// <summary>
    /// Classe estática responsável por popular o banco de dados com dados de exemplo.
    /// Fornece funcionalidades para inserir dados fictícios em todas as tabelas do sistema
    /// para fins de teste e demonstração.
    /// </summary>
    public static class DataPopulator
    {
        /// <summary>
        /// Gerador de números aleatórios utilizado para criar dados fictícios.
        /// </summary>
        private static Random random = new Random();

        /// <summary>
        /// Caminho do diretório da aplicação em AppData\Roaming.
        /// </summary>
        private static string path = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
            "NobreakerSystemApp"
        );

        /// <summary>
        /// Caminho completo do arquivo de banco de dados SQLite.
        /// </summary>
        private static string dbPath = Path.Combine(path, "NoBreakerSystem.db");

        /// <summary>
        /// Array de setores hospitalares utilizados para gerar localizações aleatórias.
        /// </summary>
        private static string[] sectors = { "UTI", "Centro Cirúrgico", "Radiologia", "Emergência", "TI", "Farmácia", "Laboratório de Análise", "Sala do Servidor" };

        /// <summary>
        /// Array de nomes de equipamentos hospitalares para geração de dados fictícios.
        /// </summary>
        private static string[] equipmentNames = { "Monitor cardíaco", "Ventilador pulmonar", "Bomba de infusão", "Ultrassom", "Desfibrilador", "Computador hospitalar", "Servidor Hospitalar" };

        /// <summary>
        /// Array de tipos de equipamentos para classificação.
        /// </summary>
        private static string[] equipmentTypes = { "Crítico", "Suporte", "Diagnóstico" };

        /// <summary>
        /// Array de status operacionais possíveis para os nobreaks.
        /// </summary>
        private static string[] statuses = { "Ativo", "Crítico", "Inativo" };

        /// <summary>
        /// Array de tipos de incidentes que podem ocorrer no sistema.
        /// </summary>
        private static string[] incidentTypes = { "Bateria Fraca", "Falha no Inversor", "Sobrecarga", "Desligamento Inesperado" };

        /// <summary>
        /// Array de status possíveis para os incidentes registrados.
        /// </summary>
        private static string[] incidentStatuses = { "Aberto", "Em Análise", "Resolvido" };

        /// <summary>
        /// Popula o banco de dados com dados de exemplo em todas as tabelas.
        /// </summary>
        /// <remarks>
        /// Este método executa a seguinte sequência de operações:
        /// <list type="number">
        /// <item><description>Verifica se o banco já foi populado anteriormente</description></item>
        /// <item><description>Insere modelos padrão de nobreak se necessário</description></item>
        /// <item><description>Cria 20 registros de nobreaks com dados aleatórios</description></item>
        /// <item><description>Associa 1-3 equipamentos a cada nobreak</description></item>
        /// <item><description>Gera 10 registros de monitoramento por nobreak</description></item>
        /// <item><description>Cria 15 incidentes distribuídos aleatoriamente</description></item>
        /// </list>
        /// 
        /// Todos os dados são gerados aleatoriamente usando valores realísticos
        /// para simular um ambiente hospitalar real.
        /// </remarks>
        /// <exception cref="SQLiteException">
        /// Lançada quando ocorrem erros específicos do SQLite durante a inserção.
        /// </exception>
        /// <exception cref="Exception">
        /// Captura e relança qualquer exceção não prevista para permitir tratamento pelo código chamador.
        /// </exception>
        public static void Populate()
        {
            try
            {
                // Estabelece conexão com o banco de dados
                using (var connection = new SQLiteConnection($"Data Source={dbPath}"))
                {
                    connection.Open();

                    // Verifica se as tabelas principais já contêm dados
                    if (TabelasJaPopuladas(connection))
                    {
                        Console.WriteLine("📋 Banco de dados já possui dados. Operação cancelada.");
                        return;
                    }

                    // Insere modelos padrão de nobreak se a tabela estiver vazia
                    InserirModelosPadrao(connection);

                    // Lista para armazenar os IDs dos nobreaks criados
                    List<long> nobreakIds = new List<long>();

                    // 1. Inserção de registros de Nobreaks
                    Console.WriteLine("Inserindo Nobreaks...");
                    for (int i = 0; i < 20; i++)
                    {
                        // Gera dados aleatórios para cada nobreak
                        int modeloId = RandomInt(1, 6);
                        string local = RandomChoice(sectors);
                        string dataAquisicao = RandomDate(1000, 2000);
                        string dataGarantia = FutureDate(30, 365);
                        string ultimaManutencao = RandomDate(365, 30);
                        string proximaTroca = FutureDate(30, 180);
                        string status = RandomChoice(statuses);
                        int nivelBateria = RandomInt(30, 100);
                        string criadoPor = GenerateEmail();

                        // SQL para inserção do nobreak
                        string sql = @"
                            INSERT INTO Nobreaks (
                                ModeloId, Localizacao, DataAquisicao, DataGarantia,
                                DataUltimaManutencao, ProximaTrocaBateria,
                                StatusOperacional, NivelBateriaPercent, CriadoPor
                            ) VALUES (@ModeloId, @Localizacao, @DataAquisicao, @DataGarantia,
                                    @UltimaManutencao, @ProximaTroca, @Status, @NivelBateria, @CriadoPor)";

                        using (var command = new SQLiteCommand(sql, connection))
                        {
                            // Adiciona parâmetros para evitar SQL injection
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

                            // Obtém o ID do registro recém-inserido
                            using (var idCommand = new SQLiteCommand("SELECT last_insert_rowid()", connection))
                            {
                                long lastId = (long)idCommand.ExecuteScalar();
                                nobreakIds.Add(lastId);
                            }
                        }
                    }

                    // 2. Inserção de Equipamentos associados aos nobreaks
                    Console.WriteLine("Inserindo Equipamentos...");
                    foreach (long nobreakId in nobreakIds)
                    {
                        // Cada nobreak terá entre 1 e 3 equipamentos
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

                    // 3. Inserção de dados de Monitoramento
                    Console.WriteLine("Inserindo dados de Monitoramento...");
                    Random rand = new Random();
                    foreach (long nobreakId in nobreakIds)
                    {
                        // Gera 10 registros de monitoramento por nobreak
                        for (int i = 0; i < 10; i++)
                        {
                            
                            int cargaVa = RandomInt(500, 4500);
                            int porcentagem = RandomInt(10, 100);
                            int[] weightedChoices = { 0, 0, 0, 0, 1, 2, 3 };
                            int codigoEstado = weightedChoices[rand.Next(weightedChoices.Length)]; ; // 0: Operacional, 1: BFraca, 2: Sobrecarga, 3: Desligado
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

                    // 4. Inserção de Incidentes
                    Console.WriteLine("Inserindo Incidentes...");


                    for (int i = 0; i < 15; i++)
                    {
                        long nobreakId = RandomChoice(nobreakIds);
                        string tipo = RandomChoice(incidentTypes);
                        string status = RandomChoice(incidentStatuses);
                        int prioridade = RandomInt(1, 3); // 1=Alta, 2=Média, 3=Baixa
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

        /// <summary>
        /// Insere modelos padrão de nobreak na tabela Modelos se ela estiver vazia.
        /// </summary>
        /// <param name="connection">Conexão ativa com o banco de dados SQLite.</param>
        /// <remarks>
        /// Este método insere 6 modelos de nobreak com especificações reais:
        /// - Engetron Double Way Monofásico Modular DWMM 6 kVA
        /// - Intelbras DNB ISO 6 kVA
        /// - Delta Série RT 6 kVA
        /// - TS Shara SYAL EM 4 kVA
        /// - Eaton 9PX3000RT
        /// - APC Symmetra PX 10 kVA
        /// 
        /// Cada modelo inclui informações sobre capacidade, garantia,
        /// tempo de troca de bateria e vida útil.
        /// </remarks>
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

                    // Lista de modelos de nobreak para inserir com especificações reais
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

                    // Insere cada modelo na tabela
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

        /// <summary>
        /// Verifica se as principais tabelas do sistema já foram populadas com dados.
        /// </summary>
        /// <param name="connection">Conexão ativa com o banco de dados SQLite.</param>
        /// <returns>
        /// <c>true</c> se alguma das tabelas principais contém dados; 
        /// <c>false</c> se todas estão vazias.
        /// </returns>
        /// <remarks>
        /// Este método verifica as seguintes tabelas:
        /// - Nobreaks
        /// - Equipamentos  
        /// - Monitoramento
        /// - Incidentes
        /// 
        /// Se qualquer uma dessas tabelas contiver registros, o método retorna true
        /// para evitar duplicação de dados.
        /// </remarks>
        private static bool TabelasJaPopuladas(SQLiteConnection connection)
        {
            try
            {
                // Lista das principais tabelas a serem verificadas
                var tabelasParaVerificar = new[]
                {
                    "Nobreaks",
                    "Equipamentos",
                    "Monitoramento",
                    "Incidentes"
                };

                // Verifica cada tabela para presença de dados
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

        /// <summary>
        /// Gera um número inteiro aleatório dentro do intervalo especificado (inclusivo).
        /// </summary>
        /// <param name="min">Valor mínimo (inclusivo).</param>
        /// <param name="max">Valor máximo (inclusivo).</param>
        /// <returns>Um número inteiro aleatório entre min e max.</returns>
        private static int RandomInt(int min, int max)
        {
            return random.Next(min, max + 1);
        }

        /// <summary>
        /// Seleciona um elemento aleatório de um array.
        /// </summary>
        /// <typeparam name="T">Tipo dos elementos do array.</typeparam>
        /// <param name="array">Array de elementos para seleção.</param>
        /// <returns>Um elemento aleatório do array.</returns>
        private static T RandomChoice<T>(T[] array)
        {
            return array[random.Next(array.Length)];
        }

        /// <summary>
        /// Seleciona um elemento aleatório de uma lista.
        /// </summary>
        /// <typeparam name="T">Tipo dos elementos da lista.</typeparam>
        /// <param name="list">Lista de elementos para seleção.</param>
        /// <returns>Um elemento aleatório da lista.</returns>
        private static T RandomChoice<T>(List<T> list)
        {
            return list[random.Next(list.Count)];
        }

        /// <summary>
        /// Gera uma data aleatória no passado dentro do intervalo especificado.
        /// </summary>
        /// <param name="startDaysAgo">Número de dias atrás para início do intervalo.</param>
        /// <param name="endDaysAgo">Número de dias atrás para fim do intervalo.</param>
        /// <returns>Uma string representando a data no formato "yyyy-MM-dd".</returns>
        /// <remarks>
        /// Se startDaysAgo for maior que endDaysAgo, os valores são trocados automaticamente.
        /// </remarks>
        private static string RandomDate(int startDaysAgo, int endDaysAgo)
        {
            // Garante que startDaysAgo seja menor que endDaysAgo
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

        /// <summary>
        /// Gera uma data aleatória no futuro dentro do intervalo especificado.
        /// </summary>
        /// <param name="startDays">Número mínimo de dias no futuro.</param>
        /// <param name="endDays">Número máximo de dias no futuro.</param>
        /// <returns>Uma string representando a data no formato "yyyy-MM-dd".</returns>
        private static string FutureDate(int startDays, int endDays)
        {
            int days = RandomInt(startDays, endDays);
            DateTime date = DateTime.Now.AddDays(days);
            return date.ToString("yyyy-MM-dd");
        }

        /// <summary>
        /// Gera um horário aleatório no formato "HH:mm:ss".
        /// </summary>
        /// <returns>Uma string representando o horário no formato "HH:mm:ss".</returns>
        private static string RandomTime()
        {
            int hours = random.Next(0, 24);
            int minutes = random.Next(0, 60);
            int seconds = random.Next(0, 60);
            return $"{hours:D2}:{minutes:D2}:{seconds:D2}";
        }

        /// <summary>
        /// Gera um endereço de email aleatório usando nomes e domínios predefinidos.
        /// </summary>
        /// <returns>Uma string representando um endereço de email fictício.</returns>
        /// <remarks>
        /// O email é gerado combinando aleatoriamente:
        /// - Nomes brasileiros comuns
        /// - Sobrenomes brasileiros comuns  
        /// - Domínios de email populares
        /// 
        /// Formato: nome.sobrenome@dominio.com
        /// </remarks>
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

        /// <summary>
        /// Verifica se o banco de dados já foi populado anteriormente.
        /// </summary>
        /// <returns>
        /// <c>true</c> se o banco contém dados na tabela Nobreaks;
        /// <c>false</c> caso contrário ou em caso de erro.
        /// </returns>
        /// <remarks>
        /// Este é um método de conveniência que pode ser usado externamente
        /// para verificar o status de população do banco antes de executar
        /// operações que dependem da presença de dados.
        /// </remarks>
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
                // Em caso de erro, assume que não foi populado
                return false;
            }
        }
    }
}