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
    public partial class CadastroForm : BaseForm
    {
        public CadastroForm()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm form = new LoginForm();
            form.Show();
        }
        private void btnConfirma_Click(object sender, EventArgs e)
        {
            Usuario usuario = new Usuario
            {
                Email = txtEmail.Text,
                HashSenha = txtSenha.Text // Aqui você deve aplicar o hash na senha antes de salvar
            };

            try
            {
                // Valida o email e a senha antes de adicionar
                if (!Utils.ValidaInput.IsValidEmail(usuario.Email))
                {
                    MessageBox.Show("O email deve ser válido.");
                    return;
                }
                if (!Utils.SenhaUtils.IsStrong(usuario.HashSenha))
                {
                    MessageBox.Show("A senha deve ter pelo menos 8 caracteres, incluindo letras maiúsculas, minúsculas, números e caracteres especiais.");
                    return;
                }
                // Adiciona o usuário
                Services.UsuarioServices.AddUsuario(usuario);
                MessageBox.Show("Usuário cadastrado com sucesso!");
                this.Hide();
                LoginForm form = new LoginForm();
                form.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao cadastrar usuário: " + ex.Message);
            }
        }
    }
}
