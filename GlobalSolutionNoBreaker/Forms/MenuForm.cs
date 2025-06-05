using GlobalSolutionNoBreaker.Models;
using GlobalSolutionNoBreaker.Repositories;
using NobreakSystem.Repository;
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
    public partial class MenuForm : BaseForm
    {
        public MenuForm()
        {
            InitializeComponent();
        }

        private void btnSairMenu_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm form = new LoginForm();
            form.Show();
            Session.LoggedInEmail = "";
        }

        private void btnDashboardMenu_Click(object sender, EventArgs e)
        {
            this.Hide();
            DashboardForm form = new DashboardForm();
            form.Show();
        }

        private void btnNobreaksMenu_Click(object sender, EventArgs e)
        {
            this.Hide();
            NobreakForm form = new NobreakForm();
            form.Show();
        }

        private void btnManutencaoMenu_Click(object sender, EventArgs e)
        {
            this.Hide();
            ManutencaoForm form = new ManutencaoForm();
            form.Show();
        }

        private void btnMonitoramentoMenu_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm form = new LoginForm();
            form.Show();
        }

        private void btnExportMenu_Click(object sender, EventArgs e)
        {
            try
            {
                string connectionString = $"Data Source={NobreakRepository.DbPath};Version=3;";
                var relatorioService = new RelatorioService(connectionString);

                // Método específico que salva no desktop e abre automaticamente
                string arquivo = relatorioService.GerarEAbrirRelatorio();

                MessageBox.Show($"Relatório gerado com sucesso!\nSalvo em: {arquivo}",
                               "Relatório Gerado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao gerar relatório:\n{ex.Message}",
                               "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void foxBigLabel1_Click(object sender, EventArgs e)
        {

        }
    }
}
