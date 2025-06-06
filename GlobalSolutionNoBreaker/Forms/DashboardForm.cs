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
    /// <summary>
    /// Representa o formulário principal de visualização de dados do sistema.
    /// Exibe estatísticas, alertas e gráficos de status dos nobreaks.
    /// </summary>
    public partial class DashboardForm : BaseForm
    {
        private DashboardRepository dashboardRepo;
        private System.Windows.Forms.Timer refreshTimer;

        /// <summary>
        /// Inicializa uma nova instância da classe <see cref="DashboardForm"/>.
        /// Configura cores dos DataGridViews e associa o carregamento do formulário ao evento Load.
        /// </summary>
        public DashboardForm()
        {
            InitializeComponent();
            dashboardRepo = new DashboardRepository();

            // Garante que o método de carregamento seja executado quando o formulário for aberto
            this.Load += DashboardForm_Load;

            // Define o fundo escuro dos DataGridViews para manter a estética da interface
            dgvNobreaksTroca.BackgroundColor = Color.FromArgb(30, 30, 60);
            dgvAlertasRecentes.BackgroundColor = Color.FromArgb(30, 30, 60);
        }

        /// <summary>
        /// Evento executado quando o formulário é carregado.
        /// Inicia a atualização dos dados e configura o temporizador de atualização automática.
        /// </summary>
        private async void DashboardForm_Load(object sender, EventArgs e)
        {
            await AtualizarDashboardAsync();

            // Define intervalo do temporizador para 30 segundos
            refreshTimer = new System.Windows.Forms.Timer();
            refreshTimer.Interval = 30000; // 30 segundos

            // A cada tick (30s), atualiza o dashboard
            refreshTimer.Tick += async (s, args) => await AtualizarDashboardAsync();
            refreshTimer.Start();
        }

        /// <summary>
        /// Atualiza as informações exibidas no dashboard: contadores, listas e gráfico.
        /// </summary>
        private async Task AtualizarDashboardAsync()
        {
            try
            {
                // Atualiza os valores dos contadores principais
                lblValorAtivos.Text = (await dashboardRepo.ContarNobreaksAtivosAsync()).ToString();
                lblValorIncidentes.Text = (await dashboardRepo.ContarIncidentesHojeAsync()).ToString();
                lblValorManutencao.Text = (await dashboardRepo.ContarManutencaoPendenteAsync()).ToString();
                lblValorCritico.Text = (await dashboardRepo.ContarNobreaksOfflineAsync()).ToString();

                // Atualiza a tabela com os últimos alertas
                dgvAlertasRecentes.DataSource = await dashboardRepo.ObterUltimosAlertasAsync(10);

                // Atualiza a tabela com nobreaks próximos da troca de bateria
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

        /// <summary>
        /// Atualiza o gráfico de status dos nobreaks com base nos dados fornecidos.
        /// </summary>
        /// <param name="dados">Dicionário com os status e suas respectivas quantidades.</param>
        private void AtualizarGraficoStatus(Dictionary<string, int> dados)
        {
            // Limpa elementos anteriores do gráfico
            chartStatus.Series.Clear();
            chartStatus.Titles.Clear();
            chartStatus.ChartAreas.Clear();
            chartStatus.Legends.Clear();

            // Define cor de fundo do gráfico
            chartStatus.BackColor = Color.FromArgb(30, 30, 60);

            // Título do gráfico
            chartStatus.Titles.Add("Status dos Nobreaks");
            chartStatus.Titles[0].ForeColor = Color.White;
            chartStatus.Titles[0].Font = new Font("Segoe UI", 12, FontStyle.Bold);

            // Configuração da área principal do gráfico
            var chartArea = new ChartArea("Main");
            chartStatus.ChartAreas.Add(chartArea);
            chartArea.BackColor = Color.FromArgb(30, 30, 60);

            // Remove linhas de grade
            chartArea.AxisX.MajorGrid.Enabled = false;
            chartArea.AxisY.MajorGrid.Enabled = false;

            // Estiliza eixos com cor branca
            chartArea.AxisX.LabelStyle.ForeColor = Color.White;
            chartArea.AxisY.LabelStyle.ForeColor = Color.White;
            chartArea.AxisX.LineColor = Color.White;
            chartArea.AxisY.LineColor = Color.White;

            chartArea.AxisY.Interval = 1; // Define espaçamento vertical entre barras
            chartArea.AxisY.IsLabelAutoFit = false;

            // Adiciona legenda personalizada
            chartStatus.Legends.Add(new Legend("Legend"));
            chartStatus.Legends[0].ForeColor = Color.White;
            chartStatus.Legends[0].BackColor = Color.Transparent;

            // Ordem de exibição dos status
            var ordem = new List<string> { "Crítico", "Alerta", "OK" };

            // Adiciona as séries ao gráfico com base nos dados fornecidos
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

                    // Adiciona ponto à série: eixo X vazio para barras verticais empilhadas, Y com o valor do status
                    serie.Points.AddXY("", dados[status]);
                    chartStatus.Series.Add(serie);
                }
            }
        }

        /// <summary>
        /// Evento de pintura do painel 3 (não utilizado atualmente).
        /// </summary>
        private void panel3_Paint(object sender, PaintEventArgs e)
        {
            // Intencionalmente vazio - pode ser usado futuramente para desenhar elementos personalizados
        }

        /// <summary>
        /// Evento de clique no rótulo do cabeçalho 3 (não utilizado atualmente).
        /// </summary>
        private void headerLabel3_Click(object sender, EventArgs e)
        {
            // Intencionalmente vazio
        }

        /// <summary>
        /// Manipula o clique no botão de voltar. Fecha o formulário atual e retorna ao menu principal.
        /// </summary>
        private void btnVoltarDashboard_Click(object sender, EventArgs e)
        {
            this.Hide();
            MenuForm form = new MenuForm();
            form.Show();
        }
    }
}
