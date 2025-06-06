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
    /// <summary>
    /// Formulário principal do sistema, que permite navegar para outras funcionalidades.
    /// </summary>
    public partial class MenuForm : BaseForm
    {
        /// <summary>
        /// Inicializa os componentes do formulário Menu.
        /// </summary>
        public MenuForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Evento do botão "Sair".
        /// Retorna para a tela de login e limpa o e-mail da sessão.
        /// </summary>
        private void btnSairMenu_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm form = new LoginForm();
            form.Show();
            Session.LoggedInEmail = "";
        }

        /// <summary>
        /// Evento do botão "Dashboard".
        /// Abre o formulário de Dashboard.
        /// </summary>
        private void btnDashboardMenu_Click(object sender, EventArgs e)
        {
            this.Hide();
            DashboardForm form = new DashboardForm();
            form.Show();
        }

        /// <summary>
        /// Evento do botão "Nobreaks".
        /// Abre o formulário de gerenciamento de nobreaks.
        /// </summary>
        private void btnNobreaksMenu_Click(object sender, EventArgs e)
        {
            this.Hide();
            NobreakForm form = new NobreakForm();
            form.Show();
        }

        /// <summary>
        /// Evento do botão "Manutenção".
        /// Abre o formulário de manutenções.
        /// </summary>
        private void btnManutencaoMenu_Click(object sender, EventArgs e)
        {
            this.Hide();
            ManutencaoForm form = new ManutencaoForm();
            form.Show();
        }

        /// <summary>
        /// Evento do botão "Monitoramento".
        /// (Atualmente redireciona para o Login — substituir futuramente pelo formulário de monitoramento).
        /// </summary>
        private void btnMonitoramentoMenu_Click(object sender, EventArgs e)
        {
            string connectionString = $"Data Source={NobreakRepository.DbPath};Version=3;";
            this.Hide();
            MonitoramentoForm form = new MonitoramentoForm(connectionString); 
            form.Show();
        }

        /// <summary>
        /// Evento do botão "Exportar".
        /// Gera e abre um relatório baseado nos dados do banco SQLite.
        /// </summary>
        private void btnExportMenu_Click(object sender, EventArgs e)
        {
            try
            {
                // Cria instância do serviço de relatório, utilizando o caminho do banco de dados
                string connectionString = $"Data Source={NobreakRepository.DbPath};Version=3;";
                var relatorioService = new RelatorioService(connectionString);

                // Gera o relatório e o abre automaticamente
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
    }
}
