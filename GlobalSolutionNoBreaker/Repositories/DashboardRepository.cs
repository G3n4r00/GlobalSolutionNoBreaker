using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalSolutionNoBreaker.Repositories
{
    class DashboardRepository
    {
        private readonly string connectionString = $"Data Source={NobreakRepository.DbPath};Version=3;";


        // Contar nobreaks ativos
        public async Task<int> ContarNobreaksAtivosAsync()
        {
            try
            {
                using (var connection = new SQLiteConnection(connectionString))
                {
                    await connection.OpenAsync();
                    string sql = "SELECT COUNT(*) FROM Nobreaks WHERE StatusOperacional = 'Ativo'";

                    using (var command = new SQLiteCommand(sql, connection))
                    {
                        var result = await command.ExecuteScalarAsync();
                        return Convert.ToInt32(result);
                    }
                }
            }
            catch (Exception ex)
            {
                // Log do erro 
                System.Diagnostics.Debug.WriteLine($"Erro ao contar nobreaks ativos: {ex.Message}");
                return 0;
            }
        }

        // Contar incidentes de hoje
        public async Task<int> ContarIncidentesHojeAsync()
        {
            try
            {
                using (var connection = new SQLiteConnection(connectionString))
                {
                    await connection.OpenAsync();
                    string sql = @"SELECT COUNT(*) FROM Incidentes 
                              WHERE DATE(DataHora) = DATE('now')";

                    using (var command = new SQLiteCommand(sql, connection))
                    {
                        var result = await command.ExecuteScalarAsync();
                        return Convert.ToInt32(result);
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Erro ao contar incidentes hoje: {ex.Message}");
                return 0;
            }
        }

        // Contar nobreaks que precisam de manutenção (próxima troca de bateria)
        public async Task<int> ContarManutencaoPendenteAsync()
        {
            try
            {
                using (var connection = new SQLiteConnection(connectionString))
                {
                    await connection.OpenAsync();
                    string sql = @"SELECT COUNT(*) FROM Nobreaks 
                              WHERE StatusOperacional = 'Ativo' 
                              AND DATE(ProximaTrocaBateria) <= DATE('now', '+30 days')";

                    using (var command = new SQLiteCommand(sql, connection))
                    {
                        var result = await command.ExecuteScalarAsync();
                        return Convert.ToInt32(result);
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Erro ao contar manutenções pendentes: {ex.Message}");
                return 0;
            }
        }

        // Contar nobreaks offline/inativos
        public async Task<int> ContarNobreaksOfflineAsync()
        {
            try
            {
                using (var connection = new SQLiteConnection(connectionString))
                {
                    await connection.OpenAsync();
                    string sql = @"SELECT COUNT(*) FROM Nobreaks 
                              WHERE StatusOperacional IN ('Inativo', 'Em Manutenção')";

                    using (var command = new SQLiteCommand(sql, connection))
                    {
                        var result = await command.ExecuteScalarAsync();
                        return Convert.ToInt32(result);
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Erro ao contar nobreaks offline: {ex.Message}");
                return 0;
            }
        }

        // Buscar dados para o gráfico (status dos nobreaks)
        public async Task<Dictionary<string, int>> ObterDadosGraficoStatusAsync()
        {
            var dados = new Dictionary<string, int>();

            try
            {
                using (var connection = new SQLiteConnection(connectionString))
                {
                    await connection.OpenAsync();

                    // Buscar último monitoramento de cada nobreak ativo
                    string sql = @"
                    SELECT 
                        CASE 
                            WHEN m.CodigoEstado = 0 THEN 'OK'
                            WHEN m.CodigoEstado = 1 THEN 'Alerta'
                            WHEN m.CodigoEstado = 2 THEN 'Crítico'
                            WHEN m.CodigoEstado = 3 THEN 'Crítico'
                            ELSE 'Desconhecido'
                        END as Status,
                        COUNT(*) as Quantidade
                    FROM Nobreaks n
                    LEFT JOIN (
                        SELECT NobreakId, CodigoEstado,
                               ROW_NUMBER() OVER (PARTITION BY NobreakId ORDER BY Timestamp DESC) as rn
                        FROM Monitoramento
                    ) m ON n.Id = m.NobreakId AND m.rn = 1
                    WHERE n.StatusOperacional = 'Ativo'
                    GROUP BY 
                        CASE 
                            WHEN m.CodigoEstado = 0 THEN 'OK'
                            WHEN m.CodigoEstado = 1 THEN 'Alerta'
                            WHEN m.CodigoEstado = 2 THEN 'Crítico'
                            WHEN m.CodigoEstado = 3 THEN 'Crítico'
                            ELSE 'Desconhecido'
                        END";

                    using (var command = new SQLiteCommand(sql, connection))
                    {
                        using (var reader = await command.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                string status = reader["Status"].ToString();
                                int quantidade = Convert.ToInt32(reader["Quantidade"]);
                                dados[status] = quantidade;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Erro ao obter dados do gráfico: {ex.Message}");
            }

            // Garantir que sempre temos as 3 categorias
            if (!dados.ContainsKey("OK")) dados["OK"] = 0;
            if (!dados.ContainsKey("Alerta")) dados["Alerta"] = 0;
            if (!dados.ContainsKey("Crítico")) dados["Crítico"] = 0;

            return dados;
        }

        // Buscar últimos alertas/incidentes
        public async Task<DataTable> ObterUltimosAlertasAsync(int limite = 5)
        {
            var dataTable = new DataTable();

            try
            {
                using (var connection = new SQLiteConnection(connectionString))
                {
                    await connection.OpenAsync();
                    string sql = @"
                    SELECT 
                        TIME(i.DataHora) as Horario,
                        n.Modelo as Nobreak,
                        i.TipoIncidente as Tipo,
                        CASE 
                            WHEN i.Prioridade = 1 THEN 'Crítico'
                            WHEN i.Prioridade = 2 THEN 'Alerta'
                            ELSE 'Normal'
                        END as Status
                    FROM Incidentes i
                    INNER JOIN Nobreaks n ON i.NobreakId = n.Id
                    ORDER BY i.DataHora DESC
                    LIMIT @limite";

                    using (var command = new SQLiteCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@limite", limite);

                        using (var adapter = new SQLiteDataAdapter(command))
                        {
                            await Task.Run(() => adapter.Fill(dataTable));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Erro ao obter últimos alertas: {ex.Message}");
            }

            return dataTable;
        }

        public async Task<DataTable> ObterProximaBateriaAsync()
        {
            var dataTable = new DataTable();

            try
            {
                using (var connection = new SQLiteConnection(connectionString))
                {
                    await connection.OpenAsync();
                    string sql = @"
                    SELECT 
                        Id, Modelo, Localizacao, ProximaTrocaBateria 
                    FROM Nobreaks   
                    WHERE StatusOperacional = 'Ativo'
                    AND ProximaTrocaBateria <= DATE('now', '+30 days')
                    ORDER BY ProximaTrocaBateria ASC";

                    using (var command = new SQLiteCommand(sql, connection))
                    {
                        using (var adapter = new SQLiteDataAdapter(command))
                        {
                            await Task.Run(() => adapter.Fill(dataTable));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Erro ao obter próximas Recargas de Bateria: {ex.Message}");
            }

            return dataTable;
        }


    }
}
