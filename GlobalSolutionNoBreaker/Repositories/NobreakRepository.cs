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

                string query = "SELECT Id, ModeloId, Localizacao DataAquisicao, DataGarantia FROM Nobreaks;";
                using (var cmd = new SQLiteCommand(query, conn))
                using (var adapter = new SQLiteDataAdapter(cmd))
                {
                    adapter.Fill(dt);
                }

                conn.Close();
            }

            return dt;
        }

        public static void InsertNobreak(Nobreak nobreak)
        {
            using (var conn = new SQLiteConnection($"Data Source={DbPath};Version=3;"))
            {
                conn.Open();

                string query = @"
                    INSERT INTO Nobreaks (Modelo, Localizacao, CapacidadeVA, DataAquisicao, DataGarantia, VidaUtilAnos, CriadoEm, CriadoPor) 
                    VALUES (@modelo, @localizacao, @capacidadeVA, @dataAquisicao, @dataGarantia, @vidaUtilAnos, @criadoEm, @criadoPor);
                    ";

                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@modelo", nobreak.Modelo);
                    cmd.Parameters.AddWithValue("@localizacao", nobreak.Localizacao);
                    cmd.Parameters.AddWithValue("@capacidadeVA", nobreak.CapacidadeVA);
                    cmd.Parameters.AddWithValue("@dataAquisicao", nobreak.DataAquisicao.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("@vidaUtilAnos", nobreak.VidaUtilAnos);
                    cmd.Parameters.AddWithValue("@dataGarantia", nobreak.DataGarantia.ToString("yyyy-MM-dd"));
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
                                Modelo = reader.GetString(1),
                                Localizacao = reader.GetString(2),
                                CapacidadeVA = reader.GetInt32(3),
                                DataAquisicao = DateTime.Parse(reader.GetString(4)),
                                DataGarantia = DateTime.Parse(reader.GetString(5)),
                                VidaUtilAnos = reader.GetInt32(6),
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
                      Modelo = @Modelo, 
                      Localizacao = @Localizacao, 
                      CapacidadeVA = @CapacidadeVA, 
                      DataAquisicao = @DataAquisicao, 
                      VidaUtilAnos = @VidaUtilAnos, 
                      DataGarantia = @DataGarantia 
                      WHERE Id = @Id";

                using (var command = new SQLiteCommand(sqlUpdate, connection))
                {
                    command.Parameters.AddWithValue("@Id", nobreak.Id);
                    command.Parameters.AddWithValue("@Modelo", nobreak.Modelo);
                    command.Parameters.AddWithValue("@Localizacao", nobreak.Localizacao);
                    command.Parameters.AddWithValue("@CapacidadeVA", nobreak.CapacidadeVA);
                    command.Parameters.AddWithValue("@DataAquisicao", nobreak.DataAquisicao);
                    command.Parameters.AddWithValue("@VidaUtilAnos", nobreak.VidaUtilAnos);
                    command.Parameters.AddWithValue("@DataGarantia", nobreak.DataGarantia);
                    command.Parameters.AddWithValue("@AtualizadoPor", nobreak.AtualizadoPor);
                    command.Parameters.AddWithValue("@AtualizadoEm", nobreak.AtualizadoEm);

                    command.ExecuteNonQuery();

                }

                string sqlAddWhoWhen = @"UPDATE Nobreaks SET 
                      AtualizadoPor = @AtualizadoPor, 
                      AtualizadoEm = @AtualizadoEm
                      WHERE Id = @Id";

                using (var command = new SQLiteCommand(sqlAddWhoWhen, connection))
                {
                    command.Parameters.AddWithValue("@Id", nobreak.Id);
                    command.Parameters.AddWithValue("@AtualizadoPor", nobreak.AtualizadoPor);
                    command.Parameters.AddWithValue("@AtualizadoEm", nobreak.AtualizadoEm);
                    command.ExecuteNonQuery();
                }

            }

        }
    }
}

