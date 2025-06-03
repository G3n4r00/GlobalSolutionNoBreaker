using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalSolutionNoBreaker.Data
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

        public static void InsertNobreak(
            string modelo,
            string localizacao,
            int capacidadeVA,
            DateTime dataAquisicao,
            int vidaUtilAnos,
            int cicloCargaInicial = 0)
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
                    cmd.Parameters.AddWithValue("@modelo", modelo);
                    cmd.Parameters.AddWithValue("@localizacao", localizacao);
                    cmd.Parameters.AddWithValue("@capacidadeVA", capacidadeVA);
                    cmd.Parameters.AddWithValue("@dataAquisicao", dataAquisicao.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("@vidaUtilAnos", vidaUtilAnos);
                    cmd.Parameters.AddWithValue("@cicloCargaInicial", cicloCargaInicial);

                    cmd.ExecuteNonQuery();
                }

                conn.Close();
            }
        }

    }

}

