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
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            Usuario usuario = new Usuario
            {
                Email = txtEmail.Text,
                HashSenha = txtSenha.Text 
            };
            try
            {
                UsuarioRepository.LoginUsuario(usuario);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao fazer login: " + ex.Message);
            }

        }
    }
}
