using System;
using System.Data.SQLite;
using System.IO;

namespace GlobalSolutionNoBreaker.Data
{
    public static class DataMaker
    {
        public static void CreateDatabase()
        {
            // Define o caminho para AppData\Roaming\NobreakerSystemApp
            string path = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                "NobreakerSystemApp"
            );

            Directory.CreateDirectory(path); // Cria a pasta, se não existir

            // Caminho completo do arquivo .db
            string dbPath = Path.Combine(path, "NoBreakerSystem.db");

            // Verifica se o arquivo já existe
            if (!File.Exists(dbPath))
            {
                // Cria o arquivo do banco de dados no caminho correto
                SQLiteConnection.CreateFile(dbPath);

                // Usa o caminho completo para conectar
                using (var connection = new SQLiteConnection($"Data Source={dbPath};Version=3;"))
                {
                    connection.Open();

                    string createTables = @"
                        CREATE TABLE IF NOT EXISTS Nobreaks (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        ModeloId TEXT NOT NULL, --Link com o modelo do nobreak
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

                    using (var cmd = new SQLiteCommand(createTables, connection))
                    {
                        cmd.ExecuteNonQuery();
                    }

                    connection.Close();
                }
            }
        }

        public static void InitializeDatabase()
        {
            DataPopulator.Populate();
        }
    }
}