using GlobalSolutionNoBreaker.Models;
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
            this.Hide();
            LoginForm form = new LoginForm();
            form.Show();
        }
    }
}
