using GlobalSolutionNoBreaker.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GlobalSolutionNoBreaker.Forms
{
    public partial class DashboardForm : Form
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
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao atualizar dashboard: {ex.Message}");
            }
        }
    }
}