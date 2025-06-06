using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Font = iTextSharp.text.Font;

namespace GlobalSolutionNoBreaker.Repositories
{
    /// <summary>
    /// Gerador de relatórios em PDF para o sistema de monitoramento de Nobreaks.
    /// Utiliza a biblioteca iTextSharp para criação de documentos PDF com informações
    /// completas sobre status, incidentes, manutenção e estatísticas dos equipamentos.
    /// </summary>
    public class NobreakReportGenerator
    {
        /// <summary>
        /// String de conexão com o banco de dados SQLite
        /// </summary>
        private readonly string _connectionString = $"Data Source={NobreakRepository.DbPath};Version=3;";

        /// <summary>
        /// Inicializa uma nova instância do gerador de relatórios.
        /// </summary>
        /// <param name="connectionString">String de conexão personalizada com o banco de dados</param>
        public NobreakReportGenerator(string connectionString)
        {
            _connectionString = connectionString;
        }

        /// <summary>
        /// Gera um relatório completo de monitoramento dos nobreaks em formato PDF.
        /// O relatório inclui resumo executivo, status atual, incidentes recentes,
        /// alertas de manutenção e estatísticas de monitoramento.
        /// </summary>
        /// <param name="caminhoArquivo">Caminho completo onde o arquivo PDF será salvo</param>
        public void GerarRelatorioCompleto(string caminhoArquivo)
        {
            // Criar documento PDF com tamanho A4 e margens definidas
            Document document = new Document(PageSize.A4, 50, 50, 25, 25);

            try
            {
                PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(caminhoArquivo, FileMode.Create));
                document.Open();

                // Configurar fontes padrão para o documento
                BaseFont bf = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                Font titleFont = new Font(bf, 18, Font.BOLD);      // Título principal
                Font headerFont = new Font(bf, 14, Font.BOLD);     // Cabeçalhos de seções
                Font normalFont = new Font(bf, 10, Font.NORMAL);   // Texto normal
                Font smallFont = new Font(bf, 8, Font.NORMAL);     // Texto pequeno para tabelas

                // Título do relatório
                Paragraph title = new Paragraph("Relatório de Monitoramento de Nobreaks", titleFont);
                title.Alignment = Element.ALIGN_CENTER;
                title.SpacingAfter = 20f;
                document.Add(title);

                // Data e hora de geração do relatório
                Paragraph dateInfo = new Paragraph($"Gerado em: {DateTime.Now:dd/MM/yyyy HH:mm}", normalFont);
                dateInfo.Alignment = Element.ALIGN_RIGHT;
                dateInfo.SpacingAfter = 20f;
                document.Add(dateInfo);

                // Adicionar todas as seções do relatório
                AdicionarResumoExecutivo(document, headerFont, normalFont);
                AdicionarStatusNobreaks(document, headerFont, normalFont, smallFont);
                AdicionarIncidentesRecentes(document, headerFont, normalFont, smallFont);
                AdicionarAlertasManutencao(document, headerFont, normalFont, smallFont);
                AdicionarEstatisticasMonitoramento(document, headerFont, normalFont, smallFont);
            }
            finally
            {
                document.Close();
            }
        }

        /// <summary>
        /// Adiciona a seção de resumo executivo ao relatório.
        /// Apresenta indicadores-chave como total de nobreaks, status operacionais e incidentes.
        /// </summary>
        /// <param name="document">Documento PDF onde será adicionada a seção</param>
        /// <param name="headerFont">Fonte para cabeçalhos</param>
        /// <param name="normalFont">Fonte para texto normal</param>
        private void AdicionarResumoExecutivo(Document document, Font headerFont, Font normalFont)
        {
            document.Add(new Paragraph("1. Resumo Executivo", headerFont) { SpacingBefore = 20f, SpacingAfter = 10f });

            using (var connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();

                // Obter estatísticas principais do sistema
                var totalNobreaks = ExecutarScalar(connection, "SELECT COUNT(*) FROM Nobreaks");
                var nobreaksAtivos = ExecutarScalar(connection, "SELECT COUNT(*) FROM Nobreaks WHERE StatusOperacional = 'Ativo'");
                var nobreaksCriticos = ExecutarScalar(connection, "SELECT COUNT(*) FROM Nobreaks WHERE StatusOperacional = 'Crítico'");
                var incidentesAbertos = ExecutarScalar(connection, "SELECT COUNT(*) FROM Incidentes WHERE StatusAtual != 'Resolvido'");
                var totalEquipamentos = ExecutarScalar(connection, "SELECT COUNT(*) FROM Equipamentos");

                // Criar lista com os indicadores principais
                List list = new List(List.UNORDERED);
                list.Add(new ListItem($"Total de Nobreaks: {totalNobreaks}", normalFont));
                list.Add(new ListItem($"Nobreaks Ativos: {nobreaksAtivos}", normalFont));
                list.Add(new ListItem($"Nobreaks Críticos: {nobreaksCriticos}", normalFont));
                list.Add(new ListItem($"Incidentes em Aberto: {incidentesAbertos}", normalFont));
                list.Add(new ListItem($"Equipamentos Monitorados: {totalEquipamentos}", normalFont));

                document.Add(list);
            }
        }

        /// <summary>
        /// Adiciona a seção de status atual dos nobreaks ao relatório.
        /// Apresenta uma tabela com informações detalhadas de cada equipamento.
        /// </summary>
        /// <param name="document">Documento PDF onde será adicionada a seção</param>
        /// <param name="headerFont">Fonte para cabeçalhos</param>
        /// <param name="normalFont">Fonte para texto normal</param>
        /// <param name="smallFont">Fonte pequena para dados da tabela</param>
        private void AdicionarStatusNobreaks(Document document, Font headerFont, Font normalFont, Font smallFont)
        {
            document.Add(new Paragraph("2. Status Atual dos Nobreaks", headerFont) { SpacingBefore = 20f, SpacingAfter = 10f });

            using (var connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();

                // Query para obter status completo dos nobreaks com informações do modelo
                string query = @"
                SELECT n.Id, n.Localizacao, m.Nome as Modelo, n.StatusOperacional, 
                       n.NivelBateriaPercent, n.DataUltimaManutencao, n.ProximaTrocaBateria
                FROM Nobreaks n
                JOIN Modelos m ON n.ModeloId = m.Id
                ORDER BY n.StatusOperacional, n.Localizacao";

                using (var command = new SQLiteCommand(query, connection))
                using (var reader = command.ExecuteReader())
                {
                    // Criar tabela com 6 colunas
                    PdfPTable table = new PdfPTable(6);
                    table.WidthPercentage = 100;
                    table.SetWidths(new float[] { 1f, 2f, 2f, 1.5f, 1f, 1.5f });

                    // Adicionar cabeçalhos da tabela
                    AdicionarCelulaCabecalho(table, "ID", smallFont);
                    AdicionarCelulaCabecalho(table, "Localização", smallFont);
                    AdicionarCelulaCabecalho(table, "Modelo", smallFont);
                    AdicionarCelulaCabecalho(table, "Status", smallFont);
                    AdicionarCelulaCabecalho(table, "Bateria %", smallFont);
                    AdicionarCelulaCabecalho(table, "Próx. Troca", smallFont);

                    // Preencher dados da tabela
                    while (reader.Read())
                    {
                        table.AddCell(new PdfPCell(new Phrase(reader["Id"].ToString(), smallFont)));
                        table.AddCell(new PdfPCell(new Phrase(reader["Localizacao"].ToString(), smallFont)));
                        table.AddCell(new PdfPCell(new Phrase(reader["Modelo"].ToString(), smallFont)));

                        // Destacar status críticos com cor de fundo diferente
                        var status = reader["StatusOperacional"].ToString();
                        var cellStatus = new PdfPCell(new Phrase(status, smallFont));
                        if (status == "Crítico")
                            cellStatus.BackgroundColor = BaseColor.LIGHT_GRAY;
                        table.AddCell(cellStatus);

                        table.AddCell(new PdfPCell(new Phrase(reader["NivelBateriaPercent"].ToString() + "%", smallFont)));

                        // Formatar data da próxima troca ou mostrar N/A
                        var proximaTroca = reader["ProximaTrocaBateria"] != DBNull.Value
                            ? Convert.ToDateTime(reader["ProximaTrocaBateria"]).ToString("dd/MM/yyyy")
                            : "N/A";
                        table.AddCell(new PdfPCell(new Phrase(proximaTroca, smallFont)));
                    }

                    document.Add(table);
                }
            }
        }

        /// <summary>
        /// Adiciona a seção de incidentes recentes ao relatório.
        /// Mostra os incidentes registrados nos últimos 30 dias, limitado aos 10 mais recentes.
        /// </summary>
        /// <param name="document">Documento PDF onde será adicionada a seção</param>
        /// <param name="headerFont">Fonte para cabeçalhos</param>
        /// <param name="normalFont">Fonte para texto normal</param>
        /// <param name="smallFont">Fonte pequena para dados da tabela</param>
        private void AdicionarIncidentesRecentes(Document document, Font headerFont, Font normalFont, Font smallFont)
        {
            document.Add(new Paragraph("3. Incidentes Recentes (Últimos 30 dias)", headerFont) { SpacingBefore = 20f, SpacingAfter = 10f });

            using (var connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();

                // Query para incidentes dos últimos 30 dias
                string query = @"
                SELECT i.Id, n.Localizacao, i.TipoIncidente, i.StatusAtual, 
                       i.Prioridade, i.DataHora
                FROM Incidentes i
                JOIN Nobreaks n ON i.NobreakId = n.Id
                WHERE date(i.DataHora) >= date('now', '-30 days')
                ORDER BY i.DataHora DESC
                LIMIT 10";

                using (var command = new SQLiteCommand(query, connection))
                using (var reader = command.ExecuteReader())
                {
                    // Verifica se há incidentes para mostrar
                    if (!reader.HasRows)
                    {
                        document.Add(new Paragraph("Nenhum incidente registrado nos últimos 30 dias.", normalFont));
                        return;
                    }

                    // Cria tabela para incidentes
                    PdfPTable table = new PdfPTable(6);
                    table.WidthPercentage = 100;
                    table.SetWidths(new float[] { 0.5f, 2f, 2f, 1.5f, 1f, 1.5f });

                    // Cabeçalhos da tabela
                    AdicionarCelulaCabecalho(table, "ID", smallFont);
                    AdicionarCelulaCabecalho(table, "Localização", smallFont);
                    AdicionarCelulaCabecalho(table, "Tipo", smallFont);
                    AdicionarCelulaCabecalho(table, "Status", smallFont);
                    AdicionarCelulaCabecalho(table, "Prioridade", smallFont);
                    AdicionarCelulaCabecalho(table, "Data/Hora", smallFont);

                    // Preenche dados dos incidentes
                    while (reader.Read())
                    {
                        table.AddCell(new PdfPCell(new Phrase(reader["Id"].ToString(), smallFont)));
                        table.AddCell(new PdfPCell(new Phrase(reader["Localizacao"].ToString(), smallFont)));
                        table.AddCell(new PdfPCell(new Phrase(reader["TipoIncidente"].ToString(), smallFont)));
                        table.AddCell(new PdfPCell(new Phrase(reader["StatusAtual"].ToString(), smallFont)));

                        // Converter código de prioridade para texto
                        string prioridade = ObterTextoPrioridade(Convert.ToInt32(reader["Prioridade"]));
                        table.AddCell(new PdfPCell(new Phrase(prioridade, smallFont)));

                        var dataHora = Convert.ToDateTime(reader["DataHora"]).ToString("dd/MM/yyyy HH:mm");
                        table.AddCell(new PdfPCell(new Phrase(dataHora, smallFont)));
                    }

                    document.Add(table);
                }
            }
        }

        /// <summary>
        /// Adiciona a seção de alertas de manutenção ao relatório.
        /// Identifica nobreaks que precisam trocar bateria nos próximos 60 dias.
        /// </summary>
        /// <param name="document">Documento PDF onde será adicionada a seção</param>
        /// <param name="headerFont">Fonte para cabeçalhos</param>
        /// <param name="normalFont">Fonte para texto normal</param>
        /// <param name="smallFont">Fonte pequena para dados da tabela</param>
        private void AdicionarAlertasManutencao(Document document, Font headerFont, Font normalFont, Font smallFont)
        {
            document.Add(new Paragraph("4. Alertas de Manutenção", headerFont) { SpacingBefore = 20f, SpacingAfter = 10f });

            using (var connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();

                // Query para nobreaks que precisam trocar bateria nos próximos 60 dias
                string query = @"
                SELECT n.Id, n.Localizacao, m.Nome as Modelo, n.ProximaTrocaBateria,
                       julianday(n.ProximaTrocaBateria) - julianday('now') as DiasRestantes
                FROM Nobreaks n
                JOIN Modelos m ON n.ModeloId = m.Id
                WHERE n.ProximaTrocaBateria IS NOT NULL 
                AND date(n.ProximaTrocaBateria) <= date('now', '+60 days')
                AND date(n.ProximaTrocaBateria) >= date('now')
                ORDER BY n.ProximaTrocaBateria";

                using (var command = new SQLiteCommand(query, connection))
                using (var reader = command.ExecuteReader())
                {
                    if (!reader.HasRows)
                    {
                        document.Add(new Paragraph("Nenhum alerta de manutenção nos próximos 60 dias.", normalFont));
                        return;
                    }

                    // Cria tabela para alertas de manutenção
                    PdfPTable table = new PdfPTable(4);
                    table.WidthPercentage = 100;
                    table.SetWidths(new float[] { 1f, 2f, 2f, 1.5f });

                    AdicionarCelulaCabecalho(table, "ID", smallFont);
                    AdicionarCelulaCabecalho(table, "Localização", smallFont);
                    AdicionarCelulaCabecalho(table, "Modelo", smallFont);
                    AdicionarCelulaCabecalho(table, "Dias Restantes", smallFont);

                    while (reader.Read())
                    {
                        table.AddCell(new PdfPCell(new Phrase(reader["Id"].ToString(), smallFont)));
                        table.AddCell(new PdfPCell(new Phrase(reader["Localizacao"].ToString(), smallFont)));
                        table.AddCell(new PdfPCell(new Phrase(reader["Modelo"].ToString(), smallFont)));

                        // Destaca alertas urgentes (30 dias ou menos)
                        var diasRestantes = Math.Round(Convert.ToDouble(reader["DiasRestantes"]));
                        var cellDias = new PdfPCell(new Phrase(diasRestantes.ToString() + " dias", smallFont));
                        if (diasRestantes <= 30)
                            cellDias.BackgroundColor = BaseColor.LIGHT_GRAY;
                        table.AddCell(cellDias);
                    }

                    document.Add(table);
                }
            }
        }

        /// <summary>
        /// Adiciona a seção de estatísticas de monitoramento ao relatório.
        /// Apresenta métricas dos últimos 7 dias como médias de carga, bateria e contadores de alertas.
        /// </summary>
        /// <param name="document">Documento PDF onde será adicionada a seção</param>
        /// <param name="headerFont">Fonte para cabeçalhos</param>
        /// <param name="normalFont">Fonte para texto normal</param>
        /// <param name="smallFont">Fonte pequena (não utilizada neste método)</param>
        private void AdicionarEstatisticasMonitoramento(Document document, Font headerFont, Font normalFont, Font smallFont)
        {
            document.Add(new Paragraph("5. Estatísticas de Monitoramento (Últimos 7 dias)", headerFont) { SpacingBefore = 20f, SpacingAfter = 10f });

            using (var connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();

                // Query para estatísticas de monitoramento dos últimos 7 dias
                string query = @"
                SELECT 
                    COUNT(*) as TotalLeituras,
                    AVG(CargaAtualVA) as MediaCarga,
                    AVG(PorcentagemBateria) as MediaBateria,
                    SUM(CASE WHEN CodigoEstado = 1 THEN 1 ELSE 0 END) as AlertasBateriaFraca,
                    SUM(CASE WHEN CodigoEstado = 2 THEN 1 ELSE 0 END) as AlertasSobrecarga,
                    SUM(CASE WHEN CodigoEstado = 3 THEN 1 ELSE 0 END) as EventosDesligamento
                FROM Monitoramento 
                WHERE date(Timestamp) >= date('now', '-7 days')";

                using (var command = new SQLiteCommand(query, connection))
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        // Criar lista com as estatísticas principais
                        List list = new List(List.UNORDERED);
                        list.Add(new ListItem($"Total de Leituras: {reader["TotalLeituras"]}", normalFont));
                        list.Add(new ListItem($"Carga Média: {Convert.ToDouble(reader["MediaCarga"]):F1} VA", normalFont));
                        list.Add(new ListItem($"Nível Médio de Bateria: {Convert.ToDouble(reader["MediaBateria"]):F1}%", normalFont));
                        list.Add(new ListItem($"Alertas de Bateria Fraca: {reader["AlertasBateriaFraca"]}", normalFont));
                        list.Add(new ListItem($"Alertas de Sobrecarga: {reader["AlertasSobrecarga"]}", normalFont));
                        list.Add(new ListItem($"Eventos de Desligamento: {reader["EventosDesligamento"]}", normalFont));

                        document.Add(list);
                    }
                }
            }
        }

        /// <summary>
        /// Adiciona uma célula de cabeçalho formatada à tabela PDF.
        /// A célula possui fundo cinza claro, texto centralizado e padding definido.
        /// </summary>
        /// <param name="table">Tabela PDF onde a célula será adicionada</param>
        /// <param name="texto">Texto a ser exibido na célula</param>
        /// <param name="font">Fonte a ser utilizada no texto</param>
        private void AdicionarCelulaCabecalho(PdfPTable table, string texto, Font font)
        {
            PdfPCell cell = new PdfPCell(new Phrase(texto, font));
            cell.BackgroundColor = BaseColor.LIGHT_GRAY;
            cell.HorizontalAlignment = Element.ALIGN_CENTER;
            cell.Padding = 5f;
            table.AddCell(cell);
        }

        /// <summary>
        /// Converte o código numérico de prioridade em texto legível.
        /// </summary>
        /// <param name="prioridade">Código numérico da prioridade (1=Alta, 2=Média, 3=Baixa)</param>
        /// <returns>Texto correspondente à prioridade ou "N/A" se inválido</returns>
        private string ObterTextoPrioridade(int prioridade)
        {
            return prioridade switch
            {
                1 => "Alta",
                2 => "Média",
                3 => "Baixa",
                _ => "N/A"
            };
        }

        /// <summary>
        /// Executa uma query que retorna um único valor escalar.
        /// Utilizado para consultas de contagem e agregação simples.
        /// </summary>
        /// <param name="connection">Conexão ativa com o banco de dados</param>
        /// <param name="query">Query SQL a ser executada</param>
        /// <returns>Valor retornado pela query ou 0 se nulo</returns>
        private object ExecutarScalar(SQLiteConnection connection, string query)
        {
            using (var command = new SQLiteCommand(query, connection))
            {
                return command.ExecuteScalar() ?? 0;
            }
        }
    }

    /// <summary>
    /// Serviço de alto nível para geração de relatórios de nobreaks.
    /// Fornece métodos simplificados para criação e abertura automática de relatórios PDF.
    /// </summary>
    public class RelatorioService
    {
        /// <summary>
        /// String de conexão com o banco de dados
        /// </summary>
        private readonly string _connectionString;

        /// <summary>
        /// Inicializa uma nova instância do serviço de relatórios.
        /// </summary>
        /// <param name="connectionString">String de conexão com o banco de dados</param>
        public RelatorioService(string connectionString)
        {
            _connectionString = connectionString;
        }

        /// <summary>
        /// Gera um relatório PDF completo e retorna o caminho do arquivo criado.
        /// O arquivo é salvo na área de trabalho do usuário com timestamp no nome.
        /// </summary>
        /// <param name="nomeUsuario">Nome do usuário que está gerando o relatório (opcional)</param>
        /// <returns>Caminho completo do arquivo PDF gerado</returns>
        /// <exception cref="Exception">Lançada quando ocorre erro na geração do arquivo</exception>
        public string GerarRelatorioPDF(string nomeUsuario = "Sistema")
        {
            try
            {
                // Definir nome e caminho do arquivo com timestamp
                string nomeArquivo = $"Relatorio_Nobreaks_{DateTime.Now:yyyyMMdd_HHmmss}.pdf";
                string caminhoCompleto = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), nomeArquivo);

                // Gerar o relatório utilizando o gerador interno
                var generator = new NobreakReportGenerator(_connectionString);
                generator.GerarRelatorioCompleto(caminhoCompleto);

                return caminhoCompleto;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao gerar relatório PDF: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Gera um relatório PDF completo e abre automaticamente no visualizador padrão do sistema.
        /// Combina a geração do arquivo com sua abertura imediata para facilitar a visualização.
        /// </summary>
        /// <returns>Caminho completo do arquivo PDF gerado e aberto</returns>
        /// <exception cref="Exception">Lançada quando ocorre erro na geração ou abertura do arquivo</exception>
        public string GerarEAbrirRelatorio()
        {
            try
            {
                // Gerar arquivo com nome baseado em timestamp
                string nomeArquivo = $"Relatorio_Nobreaks_{DateTime.Now:yyyyMMdd_HHmmss}.pdf";
                string caminhoCompleto = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), nomeArquivo);

                // Criar o relatório
                var generator = new NobreakReportGenerator(_connectionString);
                generator.GerarRelatorioCompleto(caminhoCompleto);

                // Abrir o arquivo automaticamente com o aplicativo padrão
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo()
                {
                    FileName = caminhoCompleto,
                    UseShellExecute = true  // Necessário para abrir com aplicativo padrão
                });

                return caminhoCompleto;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao gerar e abrir relatório: {ex.Message}", ex);
            }
        }
    }
}