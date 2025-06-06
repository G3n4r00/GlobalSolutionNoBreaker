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
    /// <summary>
    /// Formulário responsável pelo login do usuário.
    /// </summary>
    public partial class LoginForm : BaseForm
    {
        /// <summary>
        /// Inicializa o formulário de login.
        /// </summary>
        public LoginForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Evento acionado ao clicar no botão "Entrar".
        /// Realiza a tentativa de login com os dados fornecidos.
        /// </summary>
        private void btnEntrarLogin_Click(object sender, EventArgs e)
        {
            // Cria objeto do tipo Usuario com os dados preenchidos pelo usuário
            Usuario usuario = new Usuario
            {
                Email = txtEmailLogin.Text,
                HashSenha = txtSenhaLogin.Text // A senha já deve estar criptografada ou será tratada no repositório
            };

            try
            {
                // Verifica se o login foi bem-sucedido
                if (UsuarioRepository.LoginUsuario(usuario))
                {
                    MessageBox.Show("Login realizado com sucesso!");

                    // Armazena o e-mail do usuário logado na sessão
                    Session.LoggedInEmail = usuario.Email;

                    // Abre a tela principal e oculta a de login
                    this.Hide();
                    MenuForm mainForm = new MenuForm();
                    mainForm.Show();
                }
                else
                {
                    MessageBox.Show("Email ou senha incorretos.");
                }
            }
            catch (Exception ex)
            {
                // Mostra erro em caso de exceção durante o login
                MessageBox.Show("Erro ao fazer login: " + ex.Message);
            }
        }

        /// <summary>
        /// Evento acionado ao clicar no botão "Cadastrar".
        /// Abre o formulário de cadastro de novo usuário.
        /// </summary>
        private void btnCadastrarLogin_Click(object sender, EventArgs e)
        {
            this.Hide();
            CadastroForm form = new CadastroForm();
            form.Show();
        }

        /// <summary>
        /// Encerra a aplicação.
        /// </summary>
        private void btnSair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
