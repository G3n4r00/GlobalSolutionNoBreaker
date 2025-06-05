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
            label1 = new Label();
            txtEmail = new TextBox();
            lblSenha = new Label();
            txtSenha = new TextBox();
            btnConfirmarCadastro = new ReaLTaiizor.Controls.HopeRoundButton();
            btnVoltarCadastro = new ReaLTaiizor.Controls.HopeRoundButton();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(160, 256);
            label1.Name = "label1";
            label1.Size = new Size(46, 20);
            label1.TabIndex = 0;
            label1.Text = "Email";
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(256, 256);
            txtEmail.Margin = new Padding(3, 4, 3, 4);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(416, 27);
            txtEmail.TabIndex = 1;
            // 
            // lblSenha
            // 
            lblSenha.AutoSize = true;
            lblSenha.Location = new Point(160, 352);
            lblSenha.Name = "lblSenha";
            lblSenha.Size = new Size(49, 20);
            lblSenha.TabIndex = 2;
            lblSenha.Text = "Senha";
            // 
            // txtSenha
            // 
            txtSenha.Location = new Point(248, 352);
            txtSenha.Margin = new Padding(3, 4, 3, 4);
            txtSenha.Name = "txtSenha";
            txtSenha.PasswordChar = '*';
            txtSenha.Size = new Size(416, 27);
            txtSenha.TabIndex = 3;
            // 
            // btnConfirmarCadastro
            // 
            btnConfirmarCadastro.BorderColor = Color.FromArgb(220, 223, 230);
            btnConfirmarCadastro.ButtonType = ReaLTaiizor.Util.HopeButtonType.Primary;
            btnConfirmarCadastro.DangerColor = Color.FromArgb(245, 108, 108);
            btnConfirmarCadastro.DefaultColor = Color.FromArgb(255, 255, 255);
            btnConfirmarCadastro.Font = new Font("Segoe UI", 12F);
            btnConfirmarCadastro.HoverTextColor = Color.FromArgb(48, 49, 51);
            btnConfirmarCadastro.InfoColor = Color.FromArgb(144, 147, 153);
            btnConfirmarCadastro.Location = new Point(80, 496);
            btnConfirmarCadastro.Name = "btnConfirmarCadastro";
            btnConfirmarCadastro.PrimaryColor = Color.FromArgb(64, 158, 255);
            btnConfirmarCadastro.Size = new Size(190, 40);
            btnConfirmarCadastro.SuccessColor = Color.FromArgb(103, 194, 58);
            btnConfirmarCadastro.TabIndex = 7;
            btnConfirmarCadastro.Text = "Confirmar";
            btnConfirmarCadastro.TextColor = Color.White;
            btnConfirmarCadastro.WarningColor = Color.FromArgb(230, 162, 60);
            btnConfirmarCadastro.Click += btnConfirmarCadastro_Click;
            // 
            // btnVoltarCadastro
            // 
            btnVoltarCadastro.BorderColor = Color.FromArgb(220, 223, 230);
            btnVoltarCadastro.ButtonType = ReaLTaiizor.Util.HopeButtonType.Primary;
            btnVoltarCadastro.DangerColor = Color.FromArgb(245, 108, 108);
            btnVoltarCadastro.DefaultColor = Color.FromArgb(255, 255, 255);
            btnVoltarCadastro.Font = new Font("Segoe UI", 12F);
            btnVoltarCadastro.HoverTextColor = Color.FromArgb(48, 49, 51);
            btnVoltarCadastro.InfoColor = Color.FromArgb(144, 147, 153);
            btnVoltarCadastro.Location = new Point(560, 496);
            btnVoltarCadastro.Name = "btnVoltarCadastro";
            btnVoltarCadastro.PrimaryColor = Color.FromArgb(64, 158, 255);
            btnVoltarCadastro.Size = new Size(190, 40);
            btnVoltarCadastro.SuccessColor = Color.FromArgb(103, 194, 58);
            btnVoltarCadastro.TabIndex = 8;
            btnVoltarCadastro.Text = "Voltar";
            btnVoltarCadastro.TextColor = Color.White;
            btnVoltarCadastro.WarningColor = Color.FromArgb(230, 162, 60);
            btnVoltarCadastro.Click += this.hopeRoundButton1_Click;
            // 
            // CadastroForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(914, 600);
            Controls.Add(btnVoltarCadastro);
            Controls.Add(btnConfirmarCadastro);
            Controls.Add(txtSenha);
            Controls.Add(lblSenha);
            Controls.Add(txtEmail);
            Controls.Add(label1);
            Margin = new Padding(3, 5, 3, 5);
            MinimumSize = new Size(518, 503);
            Name = "CadastroForm";
            Text = "Cadastro";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtEmail;
        private Label lblSenha;
        private TextBox txtSenha;
        private ReaLTaiizor.Controls.HopeRoundButton btnConfirmarCadastro;
        private ReaLTaiizor.Controls.HopeRoundButton btnVoltarCadastro;
    }
}