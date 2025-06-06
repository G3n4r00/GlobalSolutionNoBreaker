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
    /// Representa um formulário base com configurações padrão aplicadas.
    /// Esta classe pode ser herdada por outros formulários para manter uma aparência consistente.
    /// </summary>
    public partial class BaseForm : Form
    {
        /// <summary>
        /// Inicializa uma nova instância da classe <see cref="BaseForm"/>.
        /// Define propriedades padrão do formulário ao inicializar.
        /// </summary>
        public BaseForm()
        {
            InitializeComponent();
            SetStandardProperties();
        }

        /// <summary>
        /// Define propriedades padrão para o formulário, como tamanho, posição inicial e estilo de borda.
        /// </summary>
        private void SetStandardProperties()
        {
            // Define o tamanho padrão do formulário
            this.Size = new Size(960, 680);

            // Define a posição inicial do formulário como centralizada na tela
            this.StartPosition = FormStartPosition.CenterScreen;

            // Define propriedades adicionais padrão
            this.MinimumSize = new Size(400, 300);
            this.MaximizeBox = true;
            this.MinimizeBox = true;
            this.FormBorderStyle = FormBorderStyle.Sizable;
        }

        /// <summary>
        /// Substitui o método <see cref="Form.SetVisibleCore"/> para garantir a centralização do formulário sempre que ele for exibido.
        /// </summary>
        /// <param name="value">Um valor booleano que indica se o formulário deve ser exibido.</param>
        protected override void SetVisibleCore(bool value)
        {
            if (value && this.WindowState == FormWindowState.Normal)
            {
                // Garante que o formulário apareça centralizado na tela toda vez que for exibido
                this.StartPosition = FormStartPosition.CenterScreen;
            }
            base.SetVisibleCore(value);
        }
    }
}
