using System;
using System.Data.SQLite;
using System.IO;

namespace GlobalSolutionNoBreaker.Data
{
    /// <summary>
    /// Classe estática responsável pela criação e inicialização do banco de dados SQLite.
    /// Gerencia a estrutura de tabelas e a configuração inicial do sistema NoBreaker.
    /// </summary>
    public static class DataMaker
    {
        /// <summary>
        /// Cria o banco de dados SQLite e todas as tabelas necessárias para o sistema.
        /// </summary>
        /// <remarks>
        /// Este método:
        /// <list type="bullet">
        /// <item><description>Cria o diretório da aplicação em %APPDATA%\NobreakerSystemApp</description></item>
        /// <item><description>Cria o arquivo de banco de dados NoBreakerSystem.db se não existir</description></item>
        /// <item><description>Executa scripts DDL para criar e linkar todas as tabelas do sistema</description></item>
        /// </list>
        /// 
        /// Tabelas criadas:
        /// <list type="bullet">
        /// <item><description>Nobreaks - Armazena informações dos equipamentos nobreak</description></item>
        /// <item><description>Modelos - Catálogo de modelos de nobreak disponíveis</description></item>
        /// <item><description>Equipamentos - Equipamentos conectados aos nobreaks</description></item>
        /// <item><description>Monitoramento - Dados de monitoramento em tempo real</description></item>
        /// <item><description>Incidentes - Registro de incidentes do sistema</description></item>
        /// <item><description>EquipamentosIncidente - Relacionamento entre equipamentos e incidentes</description></item>
        /// <item><description>Usuarios - Dados de autenticação dos usuários</description></item>
        /// </list>
        /// </remarks>
        /// <exception cref="DirectoryNotFoundException">
        /// Pode ser lançada se houver problemas ao criar o diretório da aplicação.
        /// </exception>
        /// <exception cref="SQLiteException">
        /// Lançada quando ocorrem erros específicos do SQLite durante a criação do banco.
        /// </exception>
        /// <exception cref="IOException">
        /// Lançada quando há problemas de acesso ao sistema de arquivos.
        /// </exception>
        public static void CreateDatabase()
        {
            // Define o caminho para a pasta da aplicação em AppData\Roaming\NobreakerSystemApp
            string path = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                "NobreakerSystemApp"
            );

            // Cria o diretório se ele não existir
            Directory.CreateDirectory(path);

            // Define o caminho completo do arquivo de banco de dados
            string dbPath = Path.Combine(path, "NoBreakerSystem.db");

            // Verifica se o banco de dados já existe para evitar recriação
            if (!File.Exists(dbPath))
            {
                // Cria o arquivo físico do banco de dados SQLite
                SQLiteConnection.CreateFile(dbPath);

                // Estabelece conexão com o banco de dados recém-criado
                using (var connection = new SQLiteConnection($"Data Source={dbPath};Version=3;"))
                {
                    connection.Open();

                    // Script DDL para criação de todas as tabelas do sistema
                    string createTables = @"
                        CREATE TABLE IF NOT EXISTS Nobreaks (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        ModeloId INTEGER NOT NULL, --Link com o modelo do nobreak
                        Localizacao TEXT NOT NULL,
                        DataAquisicao DATE NOT NULL,
                        DataGarantia DATE, -- Calculada como DataAquisicao + TempodeGarantia do modelo
                        DataUltimaManutencao DATE, --Definida na pagina de manutenção e atualizada
                        ProximaTrocaBateria DATE, -- Calculada como DataAquisicao + TempoTrocaBateria do modelo
                        StatusOperacional TEXT DEFAULT 'Ativo', -- Ativo, Crítico, Inativo
                        NivelBateriaPercent INTEGER DEFAULT 100, 
                        CriadoEm DATETIME DEFAULT (datetime('now')), 
                        CriadoPor TEXT,
                        AtualizadoEm DATETIME,
                        AtualizadoPor TEXT,
                        FOREIGN KEY (ModeloId) REFERENCES Modelos(Id) ON DELETE CASCADE
                        );

                        CREATE TABLE IF NOT EXISTS Modelos (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        Nome TEXT NOT NULL,
                        CapacidadeVA INTEGER NOT NULL,
                        TempodeGarantia INTEGER NOT NULL, -- em anos
                        TempoTrocaBateria INTEGER NOT NULL, -- em anos
                        VidaUtilAnos INTEGER NOT NULL
                        );

                        CREATE TABLE IF NOT EXISTS Equipamentos (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        Nome TEXT NOT NULL, -- Nome do equipamento conectado ao nobreak
                        Tipo TEXT, -- Ex: Servidor, Máquina, Roteador, Respirador.
                        NobreakId INTEGER NOT NULL,
                        FOREIGN KEY (NobreakId) REFERENCES Nobreaks(Id) ON DELETE CASCADE
                        );

                        CREATE TABLE IF NOT EXISTS Monitoramento (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        NobreakId INTEGER NOT NULL,
                        Timestamp TEXT NOT NULL DEFAULT (datetime('now')),
                        CargaAtualVA INTEGER NOT NULL,
                        PorcentagemBateria INTEGER NOT NULL,
                        CodigoEstado INTEGER NOT NULL, --0: Operacional, 1: BFraca, 2: Sobrecarga 3: Desligado
                        FOREIGN KEY (NobreakId) REFERENCES Nobreaks(Id) ON DELETE CASCADE
                        );


                        CREATE TABLE IF NOT EXISTS Incidentes (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        NobreakId INTEGER NOT NULL,
                        TipoIncidente TEXT NOT NULL,
                        StatusAtual TEXT NOT NULL,
                        Prioridade INTEGER NOT NULL, -- 1=Alta,2=Média,3=Baixa
                        DataHora TEXT NOT NULL DEFAULT (datetime('now')),
                        FOREIGN KEY (NobreakId) REFERENCES Nobreaks(Id) ON DELETE CASCADE
                        );

                        CREATE TABLE IF NOT EXISTS EquipamentosIncidente (
                        IncidenteId INTEGER NOT NULL,
                        EquipamentoId INTEGER NOT NULL, -- Link com o equipamento afetado pelo incidente
                        PRIMARY KEY (IncidenteId, EquipamentoId),
                        FOREIGN KEY (IncidenteId) REFERENCES Incidentes(Id),
                        FOREIGN KEY (EquipamentoId) REFERENCES Equipamentos(EquipamentoId)
                        );

                        CREATE TABLE IF NOT EXISTS Usuarios(
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        Email TEXT NOT NULL,
                        senhaHash TEXT NOT NULL
                       );

                    ";

                    // Executa o script DDL para criar todas as tabelas
                    using (var cmd = new SQLiteCommand(createTables, connection))
                    {
                        cmd.ExecuteNonQuery();
                    }

                    // Fecha a conexão com o banco de dados
                    connection.Close();
                }
            }
        }

        /// <summary>
        /// Inicializa o banco de dados com dados padrão após sua criação.
        /// </summary>
        /// <remarks>
        /// Este método delega a população inicial do banco de dados para a classe DataPopulator,
        /// que é responsável por inserir dados de exemplo, configurações padrão e registros
        /// necessários para o funcionamento inicial do sistema.
        /// </remarks>
        /// <seealso cref="DataPopulator.Populate"/>
        public static void InitializeDatabase()
        {
            // Chama o método responsável por popular o banco com dados iniciais
            DataPopulator.Populate();
        }
    }
}