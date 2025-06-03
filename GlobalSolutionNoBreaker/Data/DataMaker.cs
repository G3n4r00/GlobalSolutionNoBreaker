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
                            CapacidadeVA INTEGER NOT NULL CHECK(CapacidadeVA > 0),
                            DataAquisicao TEXT NOT NULL CHECK(date(DataAquisicao) <= date('now')),
                            VidaUtilAnos INTEGER NOT NULL CHECK(VidaUtilAnos > 0),
                            CicloCargaInicial INTEGER NOT NULL DEFAULT 0 CHECK(CicloCargaInicial >= 0)
                        );

                        CREATE TABLE IF NOT EXISTS EquipamentosDependentes (
                            Id INTEGER PRIMARY KEY AUTOINCREMENT,
                            Nome TEXT NOT NULL,
                            Tipo TEXT NOT NULL,
                            NobreakId INTEGER NOT NULL,
                            DataInstalacao TEXT NOT NULL CHECK(date(DataInstalacao) <= date('now')),
                            ConsumoWatts INTEGER CHECK(ConsumoWatts > 0),
                            FOREIGN KEY (NobreakId) REFERENCES Nobreaks(Id) ON DELETE CASCADE
                        );

                        CREATE TABLE IF NOT EXISTS Monitoramento (
                            Id INTEGER PRIMARY KEY AUTOINCREMENT,
                            NobreakId INTEGER NOT NULL,
                            Timestamp TEXT NOT NULL DEFAULT (datetime('now')),
                            CargaAtualVA INTEGER NOT NULL,
                            EstadoBateria INTEGER NOT NULL CHECK(EstadoBateria >= 0 AND EstadoBateria <= 100),
                            TemperaturaInternaC REAL NOT NULL,
                            StatusSaude TEXT NOT NULL CHECK(StatusSaude IN ('Operacional', 'Bateria Fraca', 'Sobrecarga', 'Desligado')),
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
                            TipoEquipamento TEXT NOT NULL CHECK(TipoEquipamento IN ('Servidor', 'Roteador', 'Câmera', 'Estação de Trabalho', 'Outros')),
                            FOREIGN KEY (IncidenteId) REFERENCES Incidentes(Id) ON DELETE CASCADE
                        );

                        CREATE TABLE IF NOT EXISTS LogsEventos (
                            Id INTEGER PRIMARY KEY AUTOINCREMENT,
                            Timestamp TEXT NOT NULL DEFAULT (datetime('now')),
                            Usuario TEXT NOT NULL,
                            TipoEvento TEXT NOT NULL CHECK(TipoEvento IN ('Cadastro', 'Atualização', 'Leitura', 'Incidente', 'Notificação', 'Relatório')),
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