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
        private static string DbPath => Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
            "NobreakerSystemApp",
            "NoBreakerSystem.db"
        );

        public static DataTable GetAllNobreaks()
        {
            var dt = new DataTable();

            using (var conn = new SQLiteConnection($"Data Source={DbPath};Version=3;"))
            {
                conn.Open();

                string query = "SELECT Id, Modelo, Localizacao, CapacidadeVA, DataAquisicao, VidaUtilAnos, CicloCargaInicial FROM Nobreaks;";
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
                    INSERT INTO Nobreaks (Modelo, Localizacao, CapacidadeVA, DataAquisicao, VidaUtilAnos, CicloCargaInicial) 
                    VALUES (@modelo, @localizacao, @capacidadeVA, @dataAquisicao, @vidaUtilAnos, @cicloCargaInicial);
                    ";

                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@modelo", nobreak.Modelo);
                    cmd.Parameters.AddWithValue("@localizacao", nobreak.Localizacao);
                    cmd.Parameters.AddWithValue("@capacidadeVA", nobreak.CapacidadeVA);
                    cmd.Parameters.AddWithValue("@dataAquisicao", nobreak.DataAquisicao.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("@vidaUtilAnos", nobreak.VidaUtilAnos);
                    cmd.Parameters.AddWithValue("@cicloCargaInicial", nobreak.CicloCarga);

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
                                VidaUtilAnos = reader.GetInt32(5),
                                CicloCarga = reader.GetInt32(6)
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

    }

}

