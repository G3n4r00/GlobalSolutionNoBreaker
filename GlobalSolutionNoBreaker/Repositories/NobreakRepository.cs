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
    /// <summary>
    /// Repositório responsável pelas operações de acesso a dados dos Nobreaks.
    /// Gerencia a conexão com o banco de dados SQLite e implementa operações CRUD.
    /// </summary>
    public class NobreakRepository
    {
        /// <summary>
        /// Obtém o caminho completo do arquivo de banco de dados SQLite.
        /// O banco é armazenado na pasta ApplicationData do usuário.
        /// </summary>
        /// <returns>Caminho completo para o arquivo do banco de dados</returns>
        public static string DbPath => Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
            "NobreakerSystemApp",
            "NoBreakerSystem.db"
        );

        /// <summary>
        /// Obtém todos os nobreaks com informações do modelo para exibição na página principal.
        /// Inclui dados como nome do modelo, localização, capacidade e datas importantes.
        /// </summary>
        /// <returns>DataTable contendo os dados dos nobreaks com informações do modelo</returns>
        public static DataTable GetAllNobreaksNobreaksPage()
        {
            var dt = new DataTable();

            using (var conn = new SQLiteConnection($"Data Source={DbPath};Version=3;"))
            {
                conn.Open();

                // Query com JOIN para obter dados do nobreak e modelo
                string query = @"SELECT N.Id, M.Nome, N.Localizacao, M.CapacidadeVa, N.DataAquisicao, N.DataGarantia, M.VidaUtilAnos
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

        /// <summary>
        /// Obtém todos os nobreaks com informações específicas para o módulo de manutenção.
        /// Inclui status operacional e data da última manutenção.
        /// </summary>
        /// <returns>DataTable contendo os dados dos nobreaks para manutenção</returns>
        public static DataTable GetAllNobreaksManutencao()
        {
            var dt = new DataTable();

            using (var conn = new SQLiteConnection($"Data Source={DbPath};Version=3;"))
            {
                conn.Open();

                // Query específica para dados de manutenção
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

        /// <summary>
        /// Registra uma manutenção realizada em um nobreak.
        /// Atualiza a data da última manutenção, status operacional e informações de auditoria.
        /// </summary>
        /// <param name="nobreak">Objeto Nobreak com os dados atualizados da manutenção</param>
        public static void RegistroNobreakManutencao(Nobreak nobreak)
        {
            using (var connection = new SQLiteConnection($"Data Source={DbPath};Version=3;"))
            {
                connection.Open();

                // Atualiza apenas os campos relacionados à manutenção
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

        /// <summary>
        /// Insere um novo nobreak no banco de dados.
        /// Calcula automaticamente as datas de garantia e próxima troca de bateria baseado no modelo.
        /// </summary>
        /// <param name="nobreak">Objeto Nobreak a ser inserido</param>
        public static void InsertNobreak(Nobreak nobreak)
        {
            using (var conn = new SQLiteConnection($"Data Source={DbPath};Version=3;"))
            {
                conn.Open();

                // Buscar dados do modelo para calcular datas automáticas
                string modeloQuery = "SELECT TempodeGarantia, TempoTrocaBateria FROM Modelos WHERE Id = @modeloId";
                int tempoGarantiaAnos = 0;
                int tempoTrocaBateriaAnos = 0;

                using (var cmdModelo = new SQLiteCommand(modeloQuery, conn))
                {
                    cmdModelo.Parameters.AddWithValue("@modeloId", nobreak.ModeloId);

                    using (var reader = cmdModelo.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            tempoGarantiaAnos = reader.GetInt32(0); // TempodeGarantia
                            tempoTrocaBateriaAnos = reader.GetInt32(1); // TempoTrocaBateria
                        }
                    }
                }

                // Calcular datas baseadas na data de aquisição
                nobreak.DataGarantia = nobreak.DataAquisicao.AddYears(tempoGarantiaAnos);
                nobreak.ProximaTrocaBateria = nobreak.DataAquisicao.AddYears(tempoTrocaBateriaAnos);

                // Inserir o novo nobreak
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

        /// <summary>
        /// Obtém um nobreak específico pelo seu ID.
        /// </summary>
        /// <param name="id">ID do nobreak a ser buscado</param>
        /// <returns>Objeto Nobreak encontrado ou null se não existir</returns>
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

        /// <summary>
        /// Remove um nobreak do banco de dados pelo seu ID.
        /// </summary>
        /// <param name="id">ID do nobreak a ser removido</param>
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

        /// <summary>
        /// Atualiza os dados básicos de um nobreak existente.
        /// Atualiza modelo, localização, data de aquisição e informações de auditoria.
        /// </summary>
        /// <param name="nobreak">Objeto Nobreak com os dados atualizados</param>
        public static void UpdateNobreak(Nobreak nobreak)
        {
            using (var connection = new SQLiteConnection($"Data Source={DbPath};Version=3;"))
            {
                connection.Open();

                // Buscar dados do modelo para calcular datas automáticas
                string modeloQuery = "SELECT TempodeGarantia, TempoTrocaBateria FROM Modelos WHERE Id = @modeloId";
                int tempoGarantiaAnos = 0;
                int tempoTrocaBateriaAnos = 0;

                using (var cmdModelo = new SQLiteCommand(modeloQuery, connection))
                {
                    cmdModelo.Parameters.AddWithValue("@modeloId", nobreak.ModeloId);

                    using (var reader = cmdModelo.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            tempoGarantiaAnos = reader.GetInt32(0); // TempodeGarantia
                            tempoTrocaBateriaAnos = reader.GetInt32(1); // TempoTrocaBateria
                        }
                    }
                }

                // Calcular datas baseadas na data de aquisição
                nobreak.DataGarantia = nobreak.DataAquisicao.AddYears(tempoGarantiaAnos);
                nobreak.ProximaTrocaBateria = nobreak.DataAquisicao.AddYears(tempoTrocaBateriaAnos);

                // Atualiza apenas os campos básicos do nobreak
                string sqlUpdate = @"UPDATE Nobreaks SET 
                      ModeloId = @ModeloId, 
                      Localizacao = @Localizacao, 
                      DataAquisicao = @DataAquisicao, 
                      DataGarantia = @DataGarantia,
                      ProximaTrocaBateria = @ProximaTrocaBateria,
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
                    command.Parameters.AddWithValue("@DataGarantia", nobreak.DataGarantia?.ToString("yyyy-MM-dd"));
                    command.Parameters.AddWithValue("@ProximaTrocaBateria", nobreak.ProximaTrocaBateria?.ToString("yyyy-MM-dd"));

                    command.ExecuteNonQuery();
                }
            }
        }
    }
}