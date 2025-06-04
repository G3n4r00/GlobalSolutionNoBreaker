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
            btnEntrar = new Button();
            label1 = new Label();
            txtEmail = new TextBox();
            label2 = new Label();
            txtSenha = new TextBox();
            btnCadastro = new Button();
            SuspendLayout();
            // 
            // btnEntrar
            // 
            btnEntrar.Location = new Point(360, 320);
            btnEntrar.Name = "btnEntrar";
            btnEntrar.Size = new Size(75, 23);
            btnEntrar.TabIndex = 0;
            btnEntrar.Text = "Entrar";
            btnEntrar.UseVisualStyleBackColor = true;
            btnEntrar.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F);
            label1.Location = new Point(216, 160);
            label1.Name = "label1";
            label1.Size = new Size(48, 21);
            label1.TabIndex = 1;
            label1.Text = "Email";
            label1.Click += label1_Click;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(288, 160);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(272, 23);
            txtEmail.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F);
            label2.Location = new Point(216, 216);
            label2.Name = "label2";
            label2.Size = new Size(53, 21);
            label2.TabIndex = 3;
            label2.Text = "Senha";
            // 
            // txtSenha
            // 
            txtSenha.Location = new Point(288, 216);
            txtSenha.Name = "txtSenha";
            txtSenha.PasswordChar = '*';
            txtSenha.Size = new Size(272, 23);
            txtSenha.TabIndex = 4;
            // 
            // btnCadastro
            // 
            btnCadastro.Location = new Point(328, 376);
            btnCadastro.Name = "btnCadastro";
            btnCadastro.Size = new Size(152, 23);
            btnCadastro.TabIndex = 5;
            btnCadastro.Text = "Realizar Cadastro";
            btnCadastro.UseVisualStyleBackColor = true;
            btnCadastro.Click += btnCadastro_Click;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.InactiveCaption;
            ClientSize = new Size(800, 450);
            Controls.Add(btnCadastro);
            Controls.Add(txtSenha);
            Controls.Add(label2);
            Controls.Add(txtEmail);
            Controls.Add(label1);
            Controls.Add(btnEntrar);
            Name = "LoginForm";
            Text = "Login";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnEntrar;
        private Label label1;
        private TextBox txtEmail;
        private Label label2;
        private TextBox txtSenha;
        private Button btnCadastro;
    }
}