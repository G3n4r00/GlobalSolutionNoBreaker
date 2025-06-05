using GlobalSolutionNoBreaker.Repositories;
using ReaLTaiizor.Extension;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace GlobalSolutionNoBreaker.Forms
{
    public partial class DashboardForm : BaseForm
    {
        private DashboardRepository dashboardRepo;
        private System.Windows.Forms.Timer refreshTimer;

        public DashboardForm()
        {
            InitializeComponent();
            dashboardRepo = new DashboardRepository();
            this.Load += DashboardForm_Load; // Garante que o método seja chamado quando o form carregar
        }

        private async void DashboardForm_Load(object sender, EventArgs e)
        {
            await AtualizarDashboardAsync();

            refreshTimer = new System.Windows.Forms.Timer();
            refreshTimer.Interval = 30000; // 30 segundos
            refreshTimer.Tick += async (s, args) => await AtualizarDashboardAsync();
            refreshTimer.Start();
        }

        private async Task AtualizarDashboardAsync()
        {
            try
            {
                // Atualiza os labels
                lblValorAtivos.Text = (await dashboardRepo.ContarNobreaksAtivosAsync()).ToString();
                lblValorIncidentes.Text = (await dashboardRepo.ContarIncidentesHojeAsync()).ToString();
                lblValorManutencao.Text = (await dashboardRepo.ContarManutencaoPendenteAsync()).ToString();
                lblValorCritico.Text = (await dashboardRepo.ContarNobreaksOfflineAsync()).ToString();

                // Atualiza o DataGridView de últimos alertas
                dgvAlertasRecentes.DataSource = await dashboardRepo.ObterUltimosAlertasAsync(10);
                dgvNobreaksTroca.DataSource = await dashboardRepo.ObterProximaBateriaAsync();

                // Atualiza o gráfico de status dos nobreaks
                var dadosGrafico = await dashboardRepo.ObterDadosGraficoStatusAsync();
                AtualizarGraficoStatus(dadosGrafico);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao atualizar dashboard: {ex.Message}");
            }
        }
        private void AtualizarGraficoStatus(Dictionary<string, int> dados)
        {
            chartStatus.Series.Clear();
            chartStatus.Titles.Clear();
            chartStatus.ChartAreas.Clear();
            chartStatus.Legends.Clear();
            chartStatus.BackColor = Color.FromArgb(30, 30, 60); // Fundo azul escuro do gráfico

            // Título
            chartStatus.Titles.Add("Status dos Nobreaks");
            chartStatus.Titles[0].ForeColor = Color.White;
            chartStatus.Titles[0].Font = new Font("Segoe UI", 12, FontStyle.Bold);

            // Área do gráfico
            var chartArea = new ChartArea("Main");
            chartStatus.ChartAreas.Add(chartArea);
            chartArea.BackColor = Color.FromArgb(30, 30, 60); // Fundo da área do gráfico

            // Remover grades
            chartArea.AxisX.MajorGrid.Enabled = false;
            chartArea.AxisY.MajorGrid.Enabled = false;

            // Cor e fonte dos eixos
            chartArea.AxisX.LabelStyle.ForeColor = Color.White;
            chartArea.AxisY.LabelStyle.ForeColor = Color.White;
            chartArea.AxisX.LineColor = Color.White;
            chartArea.AxisY.LineColor = Color.White;

            // Ajustar espaço entre as barras (PointWidth de 0.1 a 1.0)
            chartArea.AxisY.Interval = 1; // 1 por categoria
            chartArea.AxisY.IsLabelAutoFit = false;

            chartStatus.Legends.Add(new Legend("Legend"));
            chartStatus.Legends[0].ForeColor = Color.White;
            chartStatus.Legends[0].BackColor = Color.Transparent;
            

            var ordem = new List<string> { "Crítico", "Alerta", "OK" };

            foreach (var status in ordem)
            {
                if (dados.ContainsKey(status))
                {
                    var serie = new Series(status)
                    {
                        ChartType = SeriesChartType.Bar, 
                        IsValueShownAsLabel = true,
                        LabelForeColor = Color.White,
                        Color = status switch
                        {
                            "OK" => Color.Green,
                            "Alerta" => Color.Orange,
                            "Crítico" => Color.Red,
                            _ => Color.Gray
                        },
                        Font = new Font("Segoe UI", 9, FontStyle.Bold),
                        ["PointWidth"] = "0.7" 
                    };

                    // X = categoria (string vazia para empilhar verticalmente), Y = valor
                    serie.Points.AddXY("", dados[status]);
                    chartStatus.Series.Add(serie);
                }
            }
        }

    }
}