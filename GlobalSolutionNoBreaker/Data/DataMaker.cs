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
                            Modelo TEXT NOT NULL,
                            Localizacao TEXT NOT NULL,
                            EnderecoIP TEXT,
                            CapacidadeVA INTEGER NOT NULL,
                            DataAquisicao TEXT NOT NULL,
                            DataGarantia TEXT,
                            DataUltimaManutencao TEXT,
                            VidaUtilAnos INTEGER NOT NULL,
                            ProximaTrocaBateria TEXT,
                            CicloCarga INTEGER NOT NULL DEFAULT 0,
                            StatusOperacional TEXT DEFAULT 'Ativo'
                            EquipamentosRelacionados TEXT,
                        );

                        CREATE TABLE IF NOT EXISTS NobreakEquipamento (
                            NobreakId INTEGER,
                            EquipamentoId INTEGER,
                            PRIMARY KEY (NobreakId, EquipamentoId),
                            FOREIGN KEY (NobreakId) REFERENCES Nobreaks(Id),
                            FOREIGN KEY (EquipamentoId) REFERENCES Equipamentos(Id)
                        );

                        CREATE TABLE IF NOT EXISTS Monitoramento (
                            Id INTEGER PRIMARY KEY AUTOINCREMENT,
                            NobreakId INTEGER NOT NULL,
                            Timestamp TEXT NOT NULL,
                            CargaAtualVA INTEGER NOT NULL,
                            PorcentagemBateria INTEGER NOT NULL,
                            TemperaturaInternaC REAL NOT NULL,
                            StatusSaude TEXT NOT NULL,
                            FOREIGN KEY (NobreakId) REFERENCES Nobreaks(Id) ON DELETE CASCADE
                        );

                        CREATE TABLE IF NOT EXISTS Incidentes (
                            Id INTEGER PRIMARY KEY AUTOINCREMENT,
                            NobreakId INTEGER NOT NULL,
                            ModeloNobreak TEXT NOT NULL,
                            StatusAtual TEXT NOT NULL,
                            ValorDetectado TEXT NOT NULL,
                            DataHora TEXT NOT NULL DEFAULT (datetime('now')),
                            FOREIGN KEY (NobreakId) REFERENCES Nobreaks(Id) ON DELETE CASCADE
                        );

                        CREATE TABLE IF NOT EXISTS EquipamentosAfetados (
                            Id INTEGER PRIMARY KEY AUTOINCREMENT,
                            IncidenteId INTEGER NOT NULL,
                            NomeEquipamento TEXT NOT NULL,
                            TipoEquipamento TEXT NOT NULL,
                            FOREIGN KEY (IncidenteId) REFERENCES Incidentes(Id) ON DELETE CASCADE
                        );

                        CREATE TABLE IF NOT EXISTS LogsEventos (
                            Id INTEGER PRIMARY KEY AUTOINCREMENT,
                            Timestamp TEXT NOT NULL DEFAULT (datetime('now')),
                            Usuario TEXT NOT NULL,
                            TipoEvento TEXT NOT NULL,
                            Descricao TEXT NOT NULL
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
    }
}