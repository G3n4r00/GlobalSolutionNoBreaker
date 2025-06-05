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
    public class NobreakReportGenerator
    {
        private readonly string _connectionString = $"Data Source={NobreakRepository.DbPath};Version=3;";

        public NobreakReportGenerator(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void GerarRelatorioCompleto(string caminhoArquivo)
        {
            Document document = new Document(PageSize.A4, 50, 50, 25, 25);

            try
            {
                PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(caminhoArquivo, FileMode.Create));
                document.Open();

                // Configurar fontes
                BaseFont bf = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                Font titleFont = new Font(bf, 18, Font.BOLD);
                Font headerFont = new Font(bf, 14, Font.BOLD);
                Font normalFont = new Font(bf, 10, Font.NORMAL);
                Font smallFont = new Font(bf, 8, Font.NORMAL);

                // Título do relatório
                Paragraph title = new Paragraph("Relatório de Monitoramento de Nobreaks", titleFont);
                title.Alignment = Element.ALIGN_CENTER;
                title.SpacingAfter = 20f;
                document.Add(title);

                // Data de geração
                Paragraph dateInfo = new Paragraph($"Gerado em: {DateTime.Now:dd/MM/yyyy HH:mm}", normalFont);
                dateInfo.Alignment = Element.ALIGN_RIGHT;
                dateInfo.SpacingAfter = 20f;
                document.Add(dateInfo);

                // 1. Resumo Executivo
                AdicionarResumoExecutivo(document, headerFont, normalFont);

                // 2. Status dos Nobreaks
                AdicionarStatusNobreaks(document, headerFont, normalFont, smallFont);

                // 3. Incidentes Recentes
                AdicionarIncidentesRecentes(document, headerFont, normalFont, smallFont);

                // 4. Alertas de Manutenção
                AdicionarAlertasManutencao(document, headerFont, normalFont, smallFont);

                // 5. Estatísticas de Monitoramento
                AdicionarEstatisticasMonitoramento(document, headerFont, normalFont, smallFont);
            }
            finally
            {
                document.Close();
            }
        }

        private void AdicionarResumoExecutivo(Document document, Font headerFont, Font normalFont)
        {
            document.Add(new Paragraph("1. Resumo Executivo", headerFont) { SpacingBefore = 20f, SpacingAfter = 10f });

            using (var connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();

                // Total de nobreaks
                var totalNobreaks = ExecutarScalar(connection, "SELECT COUNT(*) FROM Nobreaks");

                // Nobreaks ativos
                var nobreaksAtivos = ExecutarScalar(connection, "SELECT COUNT(*) FROM Nobreaks WHERE StatusOperacional = 'Ativo'");

                // Nobreaks críticos
                var nobreaksCriticos = ExecutarScalar(connection, "SELECT COUNT(*) FROM Nobreaks WHERE StatusOperacional = 'Crítico'");

                // Incidentes em aberto
                var incidentesAbertos = ExecutarScalar(connection, "SELECT COUNT(*) FROM Incidentes WHERE StatusAtual != 'Resolvido'");

                // Equipamentos monitorados
                var totalEquipamentos = ExecutarScalar(connection, "SELECT COUNT(*) FROM Equipamentos");

                List list = new List(List.UNORDERED);
                list.Add(new ListItem($"Total de Nobreaks: {totalNobreaks}", normalFont));
                list.Add(new ListItem($"Nobreaks Ativos: {nobreaksAtivos}", normalFont));
                list.Add(new ListItem($"Nobreaks Críticos: {nobreaksCriticos}", normalFont));
                list.Add(new ListItem($"Incidentes em Aberto: {incidentesAbertos}", normalFont));
                list.Add(new ListItem($"Equipamentos Monitorados: {totalEquipamentos}", normalFont));

                document.Add(list);
            }
        }

        private void AdicionarStatusNobreaks(Document document, Font headerFont, Font normalFont, Font smallFont)
        {
            document.Add(new Paragraph("2. Status Atual dos Nobreaks", headerFont) { SpacingBefore = 20f, SpacingAfter = 10f });

            using (var connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();

                string query = @"
                SELECT n.Id, n.Localizacao, m.Nome as Modelo, n.StatusOperacional, 
                       n.NivelBateriaPercent, n.DataUltimaManutencao, n.ProximaTrocaBateria
                FROM Nobreaks n
                JOIN Modelos m ON n.ModeloId = m.Id
                ORDER BY n.StatusOperacional, n.Localizacao";

                using (var command = new SQLiteCommand(query, connection))
                using (var reader = command.ExecuteReader())
                {
                    PdfPTable table = new PdfPTable(6);
                    table.WidthPercentage = 100;
                    table.SetWidths(new float[] { 1f, 2f, 2f, 1.5f, 1f, 1.5f });

                    // Cabeçalhos
                    AdicionarCelulaCabecalho(table, "ID", smallFont);
                    AdicionarCelulaCabecalho(table, "Localização", smallFont);
                    AdicionarCelulaCabecalho(table, "Modelo", smallFont);
                    AdicionarCelulaCabecalho(table, "Status", smallFont);
                    AdicionarCelulaCabecalho(table, "Bateria %", smallFont);
                    AdicionarCelulaCabecalho(table, "Próx. Troca", smallFont);

                    while (reader.Read())
                    {
                        table.AddCell(new PdfPCell(new Phrase(reader["Id"].ToString(), smallFont)));
                        table.AddCell(new PdfPCell(new Phrase(reader["Localizacao"].ToString(), smallFont)));
                        table.AddCell(new PdfPCell(new Phrase(reader["Modelo"].ToString(), smallFont)));

                        // Colorir status crítico
                        var status = reader["StatusOperacional"].ToString();
                        var cellStatus = new PdfPCell(new Phrase(status, smallFont));
                        if (status == "Crítico")
                            cellStatus.BackgroundColor = BaseColor.LIGHT_GRAY;
                        table.AddCell(cellStatus);

                        table.AddCell(new PdfPCell(new Phrase(reader["NivelBateriaPercent"].ToString() + "%", smallFont)));

                        var proximaTroca = reader["ProximaTrocaBateria"] != DBNull.Value
                            ? Convert.ToDateTime(reader["ProximaTrocaBateria"]).ToString("dd/MM/yyyy")
                            : "N/A";
                        table.AddCell(new PdfPCell(new Phrase(proximaTroca, smallFont)));
                    }

                    document.Add(table);
                }
            }
        }

        private void AdicionarIncidentesRecentes(Document document, Font headerFont, Font normalFont, Font smallFont)
        {
            document.Add(new Paragraph("3. Incidentes Recentes (Últimos 30 dias)", headerFont) { SpacingBefore = 20f, SpacingAfter = 10f });

            using (var connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();

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
                    if (!reader.HasRows)
                    {
                        document.Add(new Paragraph("Nenhum incidente registrado nos últimos 30 dias.", normalFont));
                        return;
                    }

                    PdfPTable table = new PdfPTable(6);
                    table.WidthPercentage = 100;
                    table.SetWidths(new float[] { 0.5f, 2f, 2f, 1.5f, 1f, 1.5f });

                    // Cabeçalhos
                    AdicionarCelulaCabecalho(table, "ID", smallFont);
                    AdicionarCelulaCabecalho(table, "Localização", smallFont);
                    AdicionarCelulaCabecalho(table, "Tipo", smallFont);
                    AdicionarCelulaCabecalho(table, "Status", smallFont);
                    AdicionarCelulaCabecalho(table, "Prioridade", smallFont);
                    AdicionarCelulaCabecalho(table, "Data/Hora", smallFont);

                    while (reader.Read())
                    {
                        table.AddCell(new PdfPCell(new Phrase(reader["Id"].ToString(), smallFont)));
                        table.AddCell(new PdfPCell(new Phrase(reader["Localizacao"].ToString(), smallFont)));
                        table.AddCell(new PdfPCell(new Phrase(reader["TipoIncidente"].ToString(), smallFont)));
                        table.AddCell(new PdfPCell(new Phrase(reader["StatusAtual"].ToString(), smallFont)));

                        string prioridade = ObterTextoPrioridade(Convert.ToInt32(reader["Prioridade"]));
                        table.AddCell(new PdfPCell(new Phrase(prioridade, smallFont)));

                        var dataHora = Convert.ToDateTime(reader["DataHora"]).ToString("dd/MM/yyyy HH:mm");
                        table.AddCell(new PdfPCell(new Phrase(dataHora, smallFont)));
                    }

                    document.Add(table);
                }
            }
        }

        private void AdicionarAlertasManutencao(Document document, Font headerFont, Font normalFont, Font smallFont)
        {
            document.Add(new Paragraph("4. Alertas de Manutenção", headerFont) { SpacingBefore = 20f, SpacingAfter = 10f });

            using (var connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();

                // Nobreaks que precisam trocar bateria nos próximos 60 dias
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

        private void AdicionarEstatisticasMonitoramento(Document document, Font headerFont, Font normalFont, Font smallFont)
        {
            document.Add(new Paragraph("5. Estatísticas de Monitoramento (Últimos 7 dias)", headerFont) { SpacingBefore = 20f, SpacingAfter = 10f });

            using (var connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();

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

        private void AdicionarCelulaCabecalho(PdfPTable table, string texto, Font font)
        {
            PdfPCell cell = new PdfPCell(new Phrase(texto, font));
            cell.BackgroundColor = BaseColor.LIGHT_GRAY;
            cell.HorizontalAlignment = Element.ALIGN_CENTER;
            cell.Padding = 5f;
            table.AddCell(cell);
        }

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

        private object ExecutarScalar(SQLiteConnection connection, string query)
        {
            using (var command = new SQLiteCommand(query, connection))
            {
                return command.ExecuteScalar() ?? 0;
            }
        }
    }

    // Classe para uso em Controller ou Service
    public class RelatorioService
    {
        private readonly string _connectionString;

        public RelatorioService(string connectionString)
        {
            _connectionString = connectionString;
        }

        public string GerarRelatorioPDF(string nomeUsuario = "Sistema")
        {
            try
            {
                // Definir caminho do arquivo
                string nomeArquivo = $"Relatorio_Nobreaks_{DateTime.Now:yyyyMMdd_HHmmss}.pdf";
                string caminhoCompleto = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), nomeArquivo);

                // Gerar o relatório
                var generator = new NobreakReportGenerator(_connectionString);
                generator.GerarRelatorioCompleto(caminhoCompleto);

                return caminhoCompleto;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao gerar relatório PDF: {ex.Message}", ex);
            }
        }
        public string GerarEAbrirRelatorio()
        {
            try
            {
                string nomeArquivo = $"Relatorio_Nobreaks_{DateTime.Now:yyyyMMdd_HHmmss}.pdf";
                string caminhoCompleto = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), nomeArquivo);

                var generator = new NobreakReportGenerator(_connectionString);
                generator.GerarRelatorioCompleto(caminhoCompleto);

                // Abrir o arquivo automaticamente
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo()
                {
                    FileName = caminhoCompleto,
                    UseShellExecute = true
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
}
