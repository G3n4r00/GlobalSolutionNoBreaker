using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalSolutionNoBreaker.Repositories
{
    /// <summary>
    /// Repositório responsável por fornecer dados estatísticos e informações 
    /// para o dashboard do sistema de monitoramento de nobreaks.
    /// </summary>
    /// <remarks>
    /// Esta classe centraliza as consultas de dados agregados utilizados 
    /// na interface do dashboard, incluindo contadores, gráficos e relatórios.
    /// </remarks>
    class DashboardRepository
    {
        /// <summary>
        /// String de conexão com o banco de dados SQLite.
        /// </summary>
        private readonly string connectionString = $"Data Source={NobreakRepository.DbPath};Version=3;";

        /// <summary>
        /// Conta o número de nobreaks que estão atualmente ativos no sistema.
        /// </summary>
        /// <returns>
        /// Uma tarefa que representa a operação assíncrona. 
        /// O valor da tarefa contém o número de nobreaks ativos.
        /// </returns>
        /// <remarks>
        /// Considera apenas nobreaks com StatusOperacional = 'Ativo'.
        /// Em caso de erro, retorna 0 e registra o erro no Debug.
        /// </remarks>
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
                // Registra o erro no console de debug para diagnóstico
                System.Diagnostics.Debug.WriteLine($"Erro ao contar nobreaks ativos: {ex.Message}");
                return 0; // Retorna 0 como valor padrão em caso de erro
            }
        }

        /// <summary>
        /// Conta o número de incidentes que ocorreram no dia atual.
        /// </summary>
        /// <returns>
        /// Uma tarefa que representa a operação assíncrona. 
        /// O valor da tarefa contém o número de incidentes registrados hoje.
        /// </returns>
        /// <remarks>
        /// Utiliza a função DATE('now') do SQLite para comparar com a data atual.
        /// Em caso de erro, retorna 0 e registra o erro no Debug.
        /// </remarks>
        public async Task<int> ContarIncidentesHojeAsync()
        {
            try
            {
                using (var connection = new SQLiteConnection(connectionString))
                {
                    await connection.OpenAsync();
                    // Consulta apenas incidentes da data atual
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

        /// <summary>
        /// Conta quantos nobreaks precisam de manutenção preventiva nos próximos 30 dias.
        /// </summary>
        /// <returns>
        /// Uma tarefa que representa a operação assíncrona. 
        /// O valor da tarefa contém o número de nobreaks que precisam de manutenção.
        /// </returns>
        /// <remarks>
        /// Considera nobreaks ativos cuja data de próxima troca de bateria 
        /// está dentro dos próximos 30 dias. Em caso de erro, retorna 0.
        /// </remarks>
        public async Task<int> ContarManutencaoPendenteAsync()
        {
            try
            {
                using (var connection = new SQLiteConnection(connectionString))
                {
                    await connection.OpenAsync();
                    // Busca nobreaks ativos com troca de bateria nos próximos 30 dias
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

        /// <summary>
        /// Conta o número de nobreaks que estão offline ou inativos.
        /// </summary>
        /// <returns>
        /// Uma tarefa que representa a operação assíncrona. 
        /// O valor da tarefa contém o número de nobreaks offline/inativos.
        /// </returns>
        /// <remarks>
        /// Considera apenas nobreaks com StatusOperacional = 'Inativo'.
        /// Em caso de erro, retorna 0 e registra o erro no Debug.
        /// </remarks>
        public async Task<int> ContarNobreaksOfflineAsync()
        {
            try
            {
                using (var connection = new SQLiteConnection(connectionString))
                {
                    await connection.OpenAsync();
                    string sql = @"SELECT COUNT(*) FROM Nobreaks 
                              WHERE StatusOperacional = 'Inativo'";

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

        /// <summary>
        /// Obtém dados agregados sobre o status dos nobreaks para exibição em gráfico.
        /// </summary>
        /// <returns>
        /// Uma tarefa que representa a operação assíncrona. 
        /// O valor da tarefa contém um dicionário com os status como chave 
        /// e a quantidade de nobreaks como valor.
        /// </returns>
        /// <remarks>
        /// Baseia-se no último monitoramento de cada nobreak ativo.
        /// Os códigos de estado são mapeados para: OK (0), Alerta (1), Crítico (2,3).
        /// Sempre retorna as três categorias principais, mesmo que com valor zero.
        /// </remarks>
        public async Task<Dictionary<string, int>> ObterDadosGraficoStatusAsync()
        {
            var dados = new Dictionary<string, int>();

            try
            {
                using (var connection = new SQLiteConnection(connectionString))
                {
                    await connection.OpenAsync();

                    // Consulta complexa que busca o último monitoramento de cada nobreak ativo
                    // e agrupa por status traduzido
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

            // Garante que as três categorias principais sempre existam no retorno
            // mesmo que não tenham dados no banco
            if (!dados.ContainsKey("OK")) dados["OK"] = 0;
            if (!dados.ContainsKey("Alerta")) dados["Alerta"] = 0;
            if (!dados.ContainsKey("Crítico")) dados["Crítico"] = 0;

            return dados;
        }

        /// <summary>
        /// Obtém os últimos alertas/incidentes registrados no sistema.
        /// </summary>
        /// <param name="limite">Número máximo de registros a retornar. Padrão: 5.</param>
        /// <returns>
        /// Uma tarefa que representa a operação assíncrona. 
        /// O valor da tarefa contém um DataTable com os dados dos últimos alertas.
        /// </returns>
        /// <remarks>
        /// Retorna informações detalhadas incluindo horário, modelo, localização e prioridade.
        /// Os registros são ordenados por data/hora decrescente (mais recentes primeiro).
        /// Em caso de erro, retorna um DataTable vazio.
        /// </remarks>
        public async Task<DataTable> ObterUltimosAlertasAsync(int limite = 5)
        {
            var dataTable = new DataTable();

            try
            {
                using (var connection = new SQLiteConnection(connectionString))
                {
                    await connection.OpenAsync();
                    // Consulta com JOINs para obter informações completas dos incidentes
                    string sql = @"
                    SELECT 
                        TIME(i.DataHora) as Horario,
                        m.Nome as Modelo,
                        n.Id as NobreakId,
                        n.Localizacao as Localizacao,
                        i.TipoIncidente as Tipo,
                        CASE 
                            WHEN i.Prioridade = 1 THEN 'Crítico'
                            WHEN i.Prioridade = 2 THEN 'Alerta'
                            ELSE 'Normal'
                        END as Status
                    FROM Incidentes i
                    INNER JOIN Nobreaks n ON i.NobreakId = n.Id
                    INNER JOIN Modelos m ON n.ModeloId = m.Id
                    ORDER BY i.DataHora DESC
                    LIMIT @limite";

                    using (var command = new SQLiteCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@limite", limite);

                        using (var adapter = new SQLiteDataAdapter(command))
                        {
                            // Executa o preenchimento do DataTable em uma task separada
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

        /// <summary>
        /// Obtém a lista de nobreaks que necessitam troca de bateria nos próximos 30 dias.
        /// </summary>
        /// <returns>
        /// Uma tarefa que representa a operação assíncrona. 
        /// O valor da tarefa contém um DataTable com os dados dos nobreaks 
        /// que precisam de manutenção de bateria.
        /// </returns>
        /// <remarks>
        /// Considera apenas nobreaks ativos cuja data de próxima troca de bateria 
        /// está entre hoje e os próximos 30 dias. Os resultados são ordenados 
        /// por data de troca (mais urgentes primeiro). Em caso de erro, retorna um DataTable vazio.
        /// </remarks>
        public async Task<DataTable> ObterProximaBateriaAsync()
        {
            var dataTable = new DataTable();

            try
            {
                using (var connection = new SQLiteConnection(connectionString))
                {
                    await connection.OpenAsync();
                    // Consulta nobreaks com troca de bateria programada nos próximos 30 dias
                    string sql = @"
                    SELECT 
                        n.Id, m.Nome AS Modelo, n.Localizacao, n.ProximaTrocaBateria 
                    FROM Nobreaks n
                    INNER JOIN Modelos m ON n.ModeloId = m.Id
                    WHERE StatusOperacional = 'Ativo'
                    AND n.ProximaTrocaBateria >= DATE('now')   
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