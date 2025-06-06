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
    /// <summary>
    /// Representa o formulário de cadastro de novos usuários.
    /// Herda de <see cref="BaseIntroForm"/> para manter a consistência visual com formulários de introdução.
    /// </summary>
    public partial class CadastroForm : BaseForm
    {
        public CadastroForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Realiza a validação dos campos e, se válidos, registra o usuário no sistema.
        /// </summary>
        /// <param name="sender">Objeto que disparou o evento.</param>
        /// <param name="e">Argumentos do evento.</param>
        private void btnCriarUsuarioCadastro_Click(object sender, EventArgs e)
        {
            Usuario usuario = new Usuario
            {
                Email = txtEmailCadastro.Text,
                HashSenha = txtSenhaCadastro.Text
            };

            try
            {
                // Valida o email fornecido
                if (!Utils.ValidaEmail.IsValidEmail(usuario.Email))
                {
                    MessageBox.Show("O email deve ser válido.");
                    return;
                }

                // Valida a força da senha fornecida
                if (!Utils.SenhaUtils.IsStrong(usuario.HashSenha))
                {
                    MessageBox.Show("A senha deve ter pelo menos 8 caracteres, incluindo letras maiúsculas, minúsculas, números e caracteres especiais.");
                    return;
                }

                // Adiciona o usuário ao sistema
                Services.UsuarioServices.AddUsuario(usuario);
                MessageBox.Show("Usuário cadastrado com sucesso!");

                // Fecha o formulário atual e abre o formulário de login
                this.Hide();
                LoginForm form = new LoginForm();
                form.Show();
            }
            catch (Exception ex)
            {
                // Exibe mensagem de erro em caso de falha no cadastro
                MessageBox.Show("Erro ao cadastrar usuário: " + ex.Message);
            }
        }

        /// <summary>
        /// Manipula o clique no botão "Voltar".
        /// Fecha o formulário atual e retorna para o formulário de login.
        /// </summary>
        /// <param name="sender">Objeto que disparou o evento.</param>
        /// <param name="e">Argumentos do evento.</param>
        private void btnVoltarCadastro_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm form = new LoginForm();
            form.Show();
        }
    }
}
