namespace GlobalSolutionNoBreaker.Forms
{
    partial class LoginForm
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
            txtEmailLogin = new ReaLTaiizor.Controls.HopeTextBox();
            txtSenhaLogin = new ReaLTaiizor.Controls.HopeTextBox();
            btnEntrarLogin = new ReaLTaiizor.Controls.HopeRoundButton();
            btnCadastrarLogin = new ReaLTaiizor.Controls.HopeRoundButton();
            btnSair = new ReaLTaiizor.Controls.HopeRoundButton();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // foxLabel1
            // 
            foxLabel1.BackColor = Color.Transparent;
            foxLabel1.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            foxLabel1.ForeColor = Color.FromArgb(76, 88, 100);
            foxLabel1.Location = new Point(120, 184);
            foxLabel1.Name = "foxLabel1";
            foxLabel1.Size = new Size(64, 16);
            foxLabel1.TabIndex = 0;
            foxLabel1.Text = "Email:";
            // 
            // foxLabel2
            // 
            foxLabel2.BackColor = Color.Transparent;
            foxLabel2.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            foxLabel2.ForeColor = Color.FromArgb(76, 88, 100);
            foxLabel2.Location = new Point(120, 240);
            foxLabel2.Name = "foxLabel2";
            foxLabel2.Size = new Size(64, 16);
            foxLabel2.TabIndex = 1;
            foxLabel2.Text = "Senha:";
            // 
            // txtEmailLogin
            // 
            txtEmailLogin.BackColor = Color.White;
            txtEmailLogin.BaseColor = Color.FromArgb(44, 55, 66);
            txtEmailLogin.BorderColorA = Color.FromArgb(64, 158, 255);
            txtEmailLogin.BorderColorB = Color.FromArgb(220, 223, 230);
            txtEmailLogin.Font = new Font("Segoe UI", 10F);
            txtEmailLogin.ForeColor = Color.FromArgb(48, 49, 51);
            txtEmailLogin.Hint = "";
            txtEmailLogin.Location = new Point(200, 176);
            txtEmailLogin.MaxLength = 32767;
            txtEmailLogin.Multiline = false;
            txtEmailLogin.Name = "txtEmailLogin";
            txtEmailLogin.PasswordChar = '\0';
            txtEmailLogin.ScrollBars = ScrollBars.None;
            txtEmailLogin.SelectedText = "";
            txtEmailLogin.SelectionLength = 0;
            txtEmailLogin.SelectionStart = 0;
            txtEmailLogin.Size = new Size(448, 34);
            txtEmailLogin.TabIndex = 2;
            txtEmailLogin.TabStop = false;
            txtEmailLogin.UseSystemPasswordChar = false;
            // 
            // txtSenhaLogin
            // 
            txtSenhaLogin.BackColor = Color.White;
            txtSenhaLogin.BaseColor = Color.FromArgb(44, 55, 66);
            txtSenhaLogin.BorderColorA = Color.FromArgb(64, 158, 255);
            txtSenhaLogin.BorderColorB = Color.FromArgb(220, 223, 230);
            txtSenhaLogin.Font = new Font("Segoe UI", 10F);
            txtSenhaLogin.ForeColor = Color.FromArgb(48, 49, 51);
            txtSenhaLogin.Hint = "";
            txtSenhaLogin.Location = new Point(200, 232);
            txtSenhaLogin.MaxLength = 32767;
            txtSenhaLogin.Multiline = false;
            txtSenhaLogin.Name = "txtSenhaLogin";
            txtSenhaLogin.PasswordChar = '*';
            txtSenhaLogin.ScrollBars = ScrollBars.None;
            txtSenhaLogin.SelectedText = "";
            txtSenhaLogin.SelectionLength = 0;
            txtSenhaLogin.SelectionStart = 0;
            txtSenhaLogin.Size = new Size(448, 34);
            txtSenhaLogin.TabIndex = 3;
            txtSenhaLogin.TabStop = false;
            txtSenhaLogin.UseSystemPasswordChar = false;
            // 
            // btnEntrarLogin
            // 
            btnEntrarLogin.BorderColor = Color.FromArgb(220, 223, 230);
            btnEntrarLogin.ButtonType = ReaLTaiizor.Util.HopeButtonType.Primary;
            btnEntrarLogin.DangerColor = Color.FromArgb(245, 108, 108);
            btnEntrarLogin.DefaultColor = Color.FromArgb(255, 255, 255);
            btnEntrarLogin.Font = new Font("Segoe UI", 12F);
            btnEntrarLogin.HoverTextColor = Color.FromArgb(48, 49, 51);
            btnEntrarLogin.InfoColor = Color.FromArgb(144, 147, 153);
            btnEntrarLogin.Location = new Point(120, 312);
            btnEntrarLogin.Name = "btnEntrarLogin";
            btnEntrarLogin.PrimaryColor = Color.FromArgb(64, 158, 255);
            btnEntrarLogin.Size = new Size(190, 40);
            btnEntrarLogin.SuccessColor = Color.FromArgb(103, 194, 58);
            btnEntrarLogin.TabIndex = 4;
            btnEntrarLogin.Text = "Entrar";
            btnEntrarLogin.TextColor = Color.White;
            btnEntrarLogin.WarningColor = Color.FromArgb(230, 162, 60);
            btnEntrarLogin.Click += btnEntrarLogin_Click;
            // 
            // btnCadastrarLogin
            // 
            btnCadastrarLogin.BorderColor = Color.FromArgb(220, 223, 230);
            btnCadastrarLogin.ButtonType = ReaLTaiizor.Util.HopeButtonType.Warning;
            btnCadastrarLogin.DangerColor = Color.FromArgb(245, 108, 108);
            btnCadastrarLogin.DefaultColor = Color.FromArgb(255, 255, 255);
            btnCadastrarLogin.Font = new Font("Segoe UI", 12F);
            btnCadastrarLogin.HoverTextColor = Color.FromArgb(48, 49, 51);
            btnCadastrarLogin.InfoColor = Color.FromArgb(144, 147, 153);
            btnCadastrarLogin.Location = new Point(456, 312);
            btnCadastrarLogin.Name = "btnCadastrarLogin";
            btnCadastrarLogin.PrimaryColor = Color.FromArgb(64, 158, 255);
            btnCadastrarLogin.Size = new Size(190, 40);
            btnCadastrarLogin.SuccessColor = Color.FromArgb(103, 194, 58);
            btnCadastrarLogin.TabIndex = 5;
            btnCadastrarLogin.Text = "Cadastrar-se";
            btnCadastrarLogin.TextColor = Color.White;
            btnCadastrarLogin.WarningColor = Color.FromArgb(230, 162, 60);
            btnCadastrarLogin.Click += btnCadastrarLogin_Click;
            // 
            // btnSair
            // 
            btnSair.BorderColor = Color.FromArgb(220, 223, 230);
            btnSair.ButtonType = ReaLTaiizor.Util.HopeButtonType.Danger;
            btnSair.DangerColor = Color.FromArgb(245, 108, 108);
            btnSair.DefaultColor = Color.FromArgb(255, 255, 255);
            btnSair.Font = new Font("Segoe UI", 12F);
            btnSair.HoverTextColor = Color.FromArgb(48, 49, 51);
            btnSair.InfoColor = Color.FromArgb(144, 147, 153);
            btnSair.Location = new Point(8, 408);
            btnSair.Name = "btnSair";
            btnSair.PrimaryColor = Color.FromArgb(64, 158, 255);
            btnSair.Size = new Size(80, 32);
            btnSair.SuccessColor = Color.FromArgb(103, 194, 58);
            btnSair.TabIndex = 6;
            btnSair.Text = "Sair";
            btnSair.TextColor = Color.White;
            btnSair.WarningColor = Color.FromArgb(230, 162, 60);
            btnSair.Click += btnSair_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.Captura_de_tela_2025_06_05_152207_removebg_preview;
            pictureBox1.Location = new Point(280, 24);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(264, 120);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 7;
            pictureBox1.TabStop = false;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            ControlBox = false;
            Controls.Add(pictureBox1);
            Controls.Add(btnSair);
            Controls.Add(btnCadastrarLogin);
            Controls.Add(btnEntrarLogin);
            Controls.Add(txtSenhaLogin);
            Controls.Add(txtEmailLogin);
            Controls.Add(foxLabel2);
            Controls.Add(foxLabel1);
            Name = "LoginForm";
            Text = "Login";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private ReaLTaiizor.Controls.FoxLabel foxLabel1;
        private ReaLTaiizor.Controls.FoxLabel foxLabel2;
        private ReaLTaiizor.Controls.HopeTextBox txtEmailLogin;
        private ReaLTaiizor.Controls.HopeTextBox txtSenhaLogin;
        private ReaLTaiizor.Controls.HopeRoundButton btnEntrarLogin;
        private ReaLTaiizor.Controls.HopeRoundButton btnCadastrarLogin;
        private ReaLTaiizor.Controls.HopeRoundButton btnSair;
        private PictureBox pictureBox1;
    }
}