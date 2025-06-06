namespace GlobalSolutionNoBreaker.Forms
{
    partial class CadastroForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            foxLabel1 = new ReaLTaiizor.Controls.FoxLabel();
            foxLabel2 = new ReaLTaiizor.Controls.FoxLabel();
            txtEmailCadastro = new ReaLTaiizor.Controls.HopeTextBox();
            txtSenhaCadastro = new ReaLTaiizor.Controls.HopeTextBox();
            btnCriarUsuarioCadastro = new ReaLTaiizor.Controls.HopeRoundButton();
            btnVoltarCadastro = new ReaLTaiizor.Controls.HopeRoundButton();
            SuspendLayout();
            // 
            // foxLabel1
            // 
            foxLabel1.BackColor = Color.Transparent;
            foxLabel1.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            foxLabel1.ForeColor = Color.FromArgb(76, 88, 100);
            foxLabel1.Location = new Point(128, 184);
            foxLabel1.Name = "foxLabel1";
            foxLabel1.Size = new Size(65, 19);
            foxLabel1.TabIndex = 0;
            foxLabel1.Text = "Email:";
            // 
            // foxLabel2
            // 
            foxLabel2.BackColor = Color.Transparent;
            foxLabel2.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            foxLabel2.ForeColor = Color.FromArgb(76, 88, 100);
            foxLabel2.Location = new Point(128, 232);
            foxLabel2.Name = "foxLabel2";
            foxLabel2.Size = new Size(65, 19);
            foxLabel2.TabIndex = 1;
            foxLabel2.Text = "Senha:";
            // 
            // txtEmailCadastro
            // 
            txtEmailCadastro.BackColor = Color.White;
            txtEmailCadastro.BaseColor = Color.FromArgb(44, 55, 66);
            txtEmailCadastro.BorderColorA = Color.FromArgb(64, 158, 255);
            txtEmailCadastro.BorderColorB = Color.FromArgb(220, 223, 230);
            txtEmailCadastro.Font = new Font("Segoe UI", 9F);
            txtEmailCadastro.ForeColor = Color.FromArgb(48, 49, 51);
            txtEmailCadastro.Hint = "";
            txtEmailCadastro.Location = new Point(208, 176);
            txtEmailCadastro.MaxLength = 32767;
            txtEmailCadastro.Multiline = false;
            txtEmailCadastro.Name = "txtEmailCadastro";
            txtEmailCadastro.PasswordChar = '\0';
            txtEmailCadastro.ScrollBars = ScrollBars.None;
            txtEmailCadastro.SelectedText = "";
            txtEmailCadastro.SelectionLength = 0;
            txtEmailCadastro.SelectionStart = 0;
            txtEmailCadastro.Size = new Size(424, 32);
            txtEmailCadastro.TabIndex = 2;
            txtEmailCadastro.TabStop = false;
            txtEmailCadastro.UseSystemPasswordChar = false;
            // 
            // txtSenhaCadastro
            // 
            txtSenhaCadastro.BackColor = Color.White;
            txtSenhaCadastro.BaseColor = Color.FromArgb(44, 55, 66);
            txtSenhaCadastro.BorderColorA = Color.FromArgb(64, 158, 255);
            txtSenhaCadastro.BorderColorB = Color.FromArgb(220, 223, 230);
            txtSenhaCadastro.Font = new Font("Segoe UI", 9F);
            txtSenhaCadastro.ForeColor = Color.FromArgb(48, 49, 51);
            txtSenhaCadastro.Hint = "";
            txtSenhaCadastro.Location = new Point(208, 224);
            txtSenhaCadastro.MaxLength = 32767;
            txtSenhaCadastro.Multiline = false;
            txtSenhaCadastro.Name = "txtSenhaCadastro";
            txtSenhaCadastro.PasswordChar = '*';
            txtSenhaCadastro.ScrollBars = ScrollBars.None;
            txtSenhaCadastro.SelectedText = "";
            txtSenhaCadastro.SelectionLength = 0;
            txtSenhaCadastro.SelectionStart = 0;
            txtSenhaCadastro.Size = new Size(424, 32);
            txtSenhaCadastro.TabIndex = 3;
            txtSenhaCadastro.TabStop = false;
            txtSenhaCadastro.UseSystemPasswordChar = false;
            // 
            // btnCriarUsuarioCadastro
            // 
            btnCriarUsuarioCadastro.BorderColor = Color.FromArgb(220, 223, 230);
            btnCriarUsuarioCadastro.ButtonType = ReaLTaiizor.Util.HopeButtonType.Primary;
            btnCriarUsuarioCadastro.DangerColor = Color.FromArgb(245, 108, 108);
            btnCriarUsuarioCadastro.DefaultColor = Color.FromArgb(255, 255, 255);
            btnCriarUsuarioCadastro.Font = new Font("Segoe UI", 12F);
            btnCriarUsuarioCadastro.HoverTextColor = Color.FromArgb(48, 49, 51);
            btnCriarUsuarioCadastro.InfoColor = Color.FromArgb(144, 147, 153);
            btnCriarUsuarioCadastro.Location = new Point(128, 328);
            btnCriarUsuarioCadastro.Name = "btnCriarUsuarioCadastro";
            btnCriarUsuarioCadastro.PrimaryColor = Color.FromArgb(64, 158, 255);
            btnCriarUsuarioCadastro.Size = new Size(190, 40);
            btnCriarUsuarioCadastro.SuccessColor = Color.FromArgb(103, 194, 58);
            btnCriarUsuarioCadastro.TabIndex = 4;
            btnCriarUsuarioCadastro.Text = "Criar Usuário";
            btnCriarUsuarioCadastro.TextColor = Color.White;
            btnCriarUsuarioCadastro.WarningColor = Color.FromArgb(230, 162, 60);
            btnCriarUsuarioCadastro.Click += btnCriarUsuarioCadastro_Click;
            // 
            // btnVoltarCadastro
            // 
            btnVoltarCadastro.BorderColor = Color.FromArgb(220, 223, 230);
            btnVoltarCadastro.ButtonType = ReaLTaiizor.Util.HopeButtonType.Danger;
            btnVoltarCadastro.DangerColor = Color.FromArgb(245, 108, 108);
            btnVoltarCadastro.DefaultColor = Color.FromArgb(255, 255, 255);
            btnVoltarCadastro.Font = new Font("Segoe UI", 12F);
            btnVoltarCadastro.HoverTextColor = Color.FromArgb(48, 49, 51);
            btnVoltarCadastro.InfoColor = Color.FromArgb(144, 147, 153);
            btnVoltarCadastro.Location = new Point(440, 328);
            btnVoltarCadastro.Name = "btnVoltarCadastro";
            btnVoltarCadastro.PrimaryColor = Color.FromArgb(64, 158, 255);
            btnVoltarCadastro.Size = new Size(190, 40);
            btnVoltarCadastro.SuccessColor = Color.FromArgb(103, 194, 58);
            btnVoltarCadastro.TabIndex = 5;
            btnVoltarCadastro.Text = "Voltar";
            btnVoltarCadastro.TextColor = Color.White;
            btnVoltarCadastro.WarningColor = Color.FromArgb(230, 162, 60);
            btnVoltarCadastro.Click += btnVoltarCadastro_Click;
            // 
            // CadastroForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            ControlBox = false;
            Controls.Add(btnVoltarCadastro);
            Controls.Add(btnCriarUsuarioCadastro);
            Controls.Add(txtSenhaCadastro);
            Controls.Add(txtEmailCadastro);
            Controls.Add(foxLabel2);
            Controls.Add(foxLabel1);
            Name = "CadastroForm";
            Text = "Formulário de Cadastro";
            ResumeLayout(false);
        }

        #endregion

        private ReaLTaiizor.Controls.FoxLabel foxLabel1;
        private ReaLTaiizor.Controls.FoxLabel foxLabel2;
        private ReaLTaiizor.Controls.HopeTextBox txtEmailCadastro;
        private ReaLTaiizor.Controls.HopeTextBox txtSenhaCadastro;
        private ReaLTaiizor.Controls.HopeRoundButton btnCriarUsuarioCadastro;
        private ReaLTaiizor.Controls.HopeRoundButton btnVoltarCadastro;
    }
}