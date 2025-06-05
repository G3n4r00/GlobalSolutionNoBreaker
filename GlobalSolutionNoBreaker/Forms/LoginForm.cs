using GlobalSolutionNoBreaker.Models;
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
    public partial class LoginForm : BaseIntroForm
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnEntrarLogin_Click(object sender, EventArgs e)
        {

            Usuario usuario = new Usuario
            {
                Email = txtEmailLogin.Text,
                HashSenha = txtSenhaLogin.Text
            };
            try
            {
                if (UsuarioRepository.LoginUsuario(usuario))
                {
                    MessageBox.Show("Login realizado com sucesso!");
                    Session.LoggedInEmail = usuario.Email; // Armazena o email do usuário logado na sessão
                    this.Hide();
                    NobreakForm mainForm = new NobreakForm();
                    mainForm.Show();
                }
                else
                {
                    MessageBox.Show("Email ou senha incorretos.");
                }
                ;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao fazer login: " + ex.Message);
            }
        }

        private void btnCadastrarLogin_Click(object sender, EventArgs e)
        {
            this.Hide();
            CadastroForm form = new CadastroForm();
            form.Show();
        }

        private void txtEmailLogin_Click(object sender, EventArgs e)
        {

        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Application.Exit(); // Encerra a aplicação
        }
    }
}
