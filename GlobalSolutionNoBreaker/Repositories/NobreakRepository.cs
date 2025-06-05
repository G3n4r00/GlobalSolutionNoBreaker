using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GlobalSolutionNoBreaker.Models;
namespace GlobalSolutionNoBreaker.Repositories
{
    public class NobreakRepository
    {
        public static string DbPath => Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
            "NobreakerSystemApp",
            "NoBreakerSystem.db"
        );

        public static DataTable GetAllNobreaksNobreaksPage()
        {
            var dt = new DataTable();

            using (var conn = new SQLiteConnection($"Data Source={DbPath};Version=3;"))
            {
                conn.Open();

                string query = @"SELECT N.Id, M.Nome, N.Localizacao, M.CapacidadeVa, N.DataAquisicao, N.DataGarantia,  M.VidaUtilAnos
                FROM Nobreaks N 
                INNER JOIN Modelos M ON N.ModeloId = M.Id";


                using (var cmd = new SQLiteCommand(query, conn))
                using (var adapter = new SQLiteDataAdapter(cmd))
                {
                    adapter.Fill(dt);
                }

                conn.Close();
            }

            return dt;
        }

        public static DataTable GetAllNobreaksManutencao()
        {
            var dt = new DataTable();

            using (var conn = new SQLiteConnection($"Data Source={DbPath};Version=3;"))
            {
                conn.Open();

                string query = @"SELECT N.Id, M.Nome, N.StatusOperacional, N.Localizacao, M.CapacidadeVa, N.DataUltimaManutencao
                FROM Nobreaks N 
                INNER JOIN Modelos M ON N.ModeloId = M.Id";


                using (var cmd = new SQLiteCommand(query, conn))
                using (var adapter = new SQLiteDataAdapter(cmd))
                {
                    adapter.Fill(dt);
                }

                conn.Close();
            }

            return dt;
        }

        public static void RegistroNobreakManutencao(Nobreak nobreak)
        {

            using (var connection = new SQLiteConnection($"Data Source={DbPath};Version=3;"))
            {
                connection.Open();
                string sqlUpdate = @"UPDATE Nobreaks SET 
                      DataUltimaManutencao = @DataUltimaManutencao, 
                      StatusOperacional = @StatusOperacional, 
                      AtualizadoPor = @AtualizadoPor, 
                      AtualizadoEm = @AtualizadoEm
                      WHERE Id = @Id";

                using (var command = new SQLiteCommand(sqlUpdate, connection))
                {
                    command.Parameters.AddWithValue("@Id", nobreak.Id);
                    command.Parameters.AddWithValue("@DataUltimaManutencao", nobreak.DataUltimaManutencao);
                    command.Parameters.AddWithValue("@StatusOperacional", nobreak.StatusOperacional);
                    command.Parameters.AddWithValue("@AtualizadoPor", nobreak.AtualizadoPor);
                    command.Parameters.AddWithValue("@AtualizadoEm", nobreak.AtualizadoEm);

                    command.ExecuteNonQuery();

                }
            }

        }

        public static void InsertNobreak(Nobreak nobreak)
        {
            using (var conn = new SQLiteConnection($"Data Source={DbPath};Version=3;"))
            {
                conn.Open();

                // Buscar dados do modelo
                string modeloQuery = "SELECT TempodeGarantia, TempoTrocaBateria FROM Modelos WHERE Id = @modeloId";
                int tempoGarantiaAnos = 0;
                int tempoTrocaBateriaAnos = 0;

                using (var cmdModelo = new SQLiteCommand(modeloQuery, conn))
                {
                    cmdModelo.Parameters.AddWithValue("@modeloId", nobreak.ModeloId); // precisa garantir que ModeloId esteja definido

                    using (var reader = cmdModelo.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            tempoGarantiaAnos = reader.GetInt32(0); // TempodeGarantia
                            int trocaAnos = reader.GetInt32(1);     // TempoTrocaBateria
                        }
                    }
                }

                // Calcular datas
                nobreak.DataGarantia = nobreak.DataAquisicao.AddYears(tempoGarantiaAnos);
                nobreak.ProximaTrocaBateria = nobreak.DataAquisicao.AddYears(tempoTrocaBateriaAnos);


                string query = @"
                    INSERT INTO Nobreaks (
                        ModeloId, Localizacao, DataAquisicao, DataGarantia,
                        ProximaTrocaBateria, CriadoEm, CriadoPor
                    ) VALUES (
                        @modeloId, @localizacao, @dataAquisicao, @dataGarantia,
                        @proximaTroca, @criadoEm, @criadoPor
                    );
                ";

                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@modeloId", nobreak.ModeloId);
                    cmd.Parameters.AddWithValue("@localizacao", nobreak.Localizacao);
                    cmd.Parameters.AddWithValue("@dataAquisicao", nobreak.DataAquisicao.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("@dataGarantia", nobreak.DataGarantia?.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("@proximaTroca", nobreak.ProximaTrocaBateria?.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("@criadoEm", nobreak.CriadoEm);
                    cmd.Parameters.AddWithValue("@criadoPor", nobreak.CriadoPor);


                    cmd.ExecuteNonQuery();
                }

                conn.Close();
            }

        }

        public static Nobreak GetNobreakById(int id)
        {
            using (var conn = new SQLiteConnection($"Data Source={DbPath};Version=3;"))
            {
                conn.Open();
                string query = "SELECT * FROM Nobreaks WHERE Id = @id;";
                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Nobreak
                            {
                                Id = reader.GetInt32(0),
                                ModeloId = reader.GetInt32(1),
                                Localizacao = reader.GetString(2),
                                DataAquisicao = DateTime.Parse(reader.GetString(3)),
                            };
                        }
                    }
                }
                conn.Close();
            }
            return null;
        }

        public static void DeleteNobreak(int id)
        {
            using (var conn = new SQLiteConnection($"Data Source={DbPath};Version=3;"))
            {
                conn.Open();
                string query = "DELETE FROM Nobreaks WHERE Id = @id;";
                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
                conn.Close();
            }
        }

        public static void UpdateNobreak(Nobreak nobreak)
        {

            using (var connection = new SQLiteConnection($"Data Source={DbPath};Version=3;"))
            {
                connection.Open();
                string sqlUpdate = @"UPDATE Nobreaks SET 
                      ModeloId = @ModeloId, 
                      Localizacao = @Localizacao, 
                      DataAquisicao = @DataAquisicao, 
                      AtualizadoPor = @AtualizadoPor, 
                      AtualizadoEm = @AtualizadoEm
                      WHERE Id = @Id";

                using (var command = new SQLiteCommand(sqlUpdate, connection))
                {
                    command.Parameters.AddWithValue("@Id", nobreak.Id);
                    command.Parameters.AddWithValue("@ModeloId", nobreak.ModeloId);
                    command.Parameters.AddWithValue("@Localizacao", nobreak.Localizacao);
                    command.Parameters.AddWithValue("@DataAquisicao", nobreak.DataAquisicao);
                    command.Parameters.AddWithValue("@AtualizadoPor", nobreak.AtualizadoPor);
                    command.Parameters.AddWithValue("@AtualizadoEm", nobreak.AtualizadoEm);

                    command.ExecuteNonQuery();

                }
            }

        }
    }
}

