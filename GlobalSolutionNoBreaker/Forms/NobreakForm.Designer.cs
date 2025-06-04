namespace GlobalSolutionNoBreaker.Forms
{
    partial class NobreakForm
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
            dgvNobreak = new DataGridView();
            btnAdicionar = new Button();
            btnExcluir = new Button();
            btnLimpar = new Button();
            btnVoltar = new Button();
            lblModelo = new Label();
            lblLocal = new Label();
            lblCapacidade = new Label();
            lblAquisicao = new Label();
            lblGarantia = new Label();
            lblVida = new Label();
            txtCapacidade = new TextBox();
            dtpAquisicao = new DateTimePicker();
            txtVida = new TextBox();
            cmbModelo = new ComboBox();
            cmbLocal = new ComboBox();
            dtpGarantia = new DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)dgvNobreak).BeginInit();
            SuspendLayout();
            // 
            // dgvNobreak
            // 
            dgvNobreak.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvNobreak.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvNobreak.Location = new Point(8, 8);
            dgvNobreak.Name = "dgvNobreak";
            dgvNobreak.Size = new Size(776, 248);
            dgvNobreak.TabIndex = 0;
            dgvNobreak.CellContentClick += dataGridView1_CellContentClick;
            dgvNobreak.CellDoubleClick += dgvNobreak_CellDoubleClick;
            // 
            // btnAdicionar
            // 
            btnAdicionar.Location = new Point(8, 408);
            btnAdicionar.Name = "btnAdicionar";
            btnAdicionar.Size = new Size(75, 23);
            btnAdicionar.TabIndex = 1;
            btnAdicionar.Text = "Adicionar";
            btnAdicionar.UseVisualStyleBackColor = true;
            btnAdicionar.Click += btnAdicionar_Click;
            // 
            // btnExcluir
            // 
            btnExcluir.Location = new Point(136, 408);
            btnExcluir.Name = "btnExcluir";
            btnExcluir.Size = new Size(75, 23);
            btnExcluir.TabIndex = 2;
            btnExcluir.Text = "Excluir";
            btnExcluir.UseVisualStyleBackColor = true;
            btnExcluir.Click += btnExcluir_Click;
            // 
            // btnLimpar
            // 
            btnLimpar.Location = new Point(280, 408);
            btnLimpar.Name = "btnLimpar";
            btnLimpar.Size = new Size(75, 23);
            btnLimpar.TabIndex = 3;
            btnLimpar.Text = "Limpar";
            btnLimpar.UseVisualStyleBackColor = true;
            btnLimpar.Click += btnLimpar_Click;
            // 
            // btnVoltar
            // 
            btnVoltar.Location = new Point(408, 408);
            btnVoltar.Name = "btnVoltar";
            btnVoltar.Size = new Size(75, 23);
            btnVoltar.TabIndex = 4;
            btnVoltar.Text = "Voltar";
            btnVoltar.UseVisualStyleBackColor = true;
            btnVoltar.Click += btnVoltar_Click;
            // 
            // lblModelo
            // 
            lblModelo.AutoSize = true;
            lblModelo.Location = new Point(16, 280);
            lblModelo.Name = "lblModelo";
            lblModelo.Size = new Size(48, 15);
            lblModelo.TabIndex = 5;
            lblModelo.Text = "Modelo";
            // 
            // lblLocal
            // 
            lblLocal.AutoSize = true;
            lblLocal.Location = new Point(16, 320);
            lblLocal.Name = "lblLocal";
            lblLocal.Size = new Size(98, 15);
            lblLocal.TabIndex = 6;
            lblLocal.Text = "Localização física";
            // 
            // lblCapacidade
            // 
            lblCapacidade.AutoSize = true;
            lblCapacidade.Location = new Point(24, 360);
            lblCapacidade.Name = "lblCapacidade";
            lblCapacidade.Size = new Size(94, 15);
            lblCapacidade.TabIndex = 7;
            lblCapacidade.Text = "Capacidade (VA)";
            // 
            // lblAquisicao
            // 
            lblAquisicao.AutoSize = true;
            lblAquisicao.Location = new Point(400, 296);
            lblAquisicao.Name = "lblAquisicao";
            lblAquisicao.Size = new Size(102, 15);
            lblAquisicao.TabIndex = 8;
            lblAquisicao.Text = "Data de Aquisição";
            // 
            // lblGarantia
            // 
            lblGarantia.AutoSize = true;
            lblGarantia.Location = new Point(400, 336);
            lblGarantia.Name = "lblGarantia";
            lblGarantia.Size = new Size(94, 15);
            lblGarantia.TabIndex = 9;
            lblGarantia.Text = "Data da Garantia";
            lblGarantia.Click += lblVida_Click;
            // 
            // lblVida
            // 
            lblVida.AutoSize = true;
            lblVida.Location = new Point(400, 376);
            lblVida.Name = "lblVida";
            lblVida.Size = new Size(106, 15);
            lblVida.TabIndex = 10;
            lblVida.Text = "Vida util (em anos)";
            // 
            // txtCapacidade
            // 
            txtCapacidade.Location = new Point(120, 360);
            txtCapacidade.Name = "txtCapacidade";
            txtCapacidade.Size = new Size(192, 23);
            txtCapacidade.TabIndex = 14;
            // 
            // dtpAquisicao
            // 
            dtpAquisicao.Location = new Point(512, 296);
            dtpAquisicao.Name = "dtpAquisicao";
            dtpAquisicao.Size = new Size(256, 23);
            dtpAquisicao.TabIndex = 16;
            // 
            // txtVida
            // 
            txtVida.Location = new Point(512, 376);
            txtVida.Name = "txtVida";
            txtVida.Size = new Size(256, 23);
            txtVida.TabIndex = 18;
            // 
            // cmbModelo
            // 
            cmbModelo.FormattingEnabled = true;
            cmbModelo.Location = new Point(72, 280);
            cmbModelo.Name = "cmbModelo";
            cmbModelo.Size = new Size(224, 23);
            cmbModelo.TabIndex = 19;
            // 
            // cmbLocal
            // 
            cmbLocal.FormattingEnabled = true;
            cmbLocal.Location = new Point(120, 320);
            cmbLocal.Name = "cmbLocal";
            cmbLocal.Size = new Size(176, 23);
            cmbLocal.TabIndex = 20;
            // 
            // dtpGarantia
            // 
            dtpGarantia.Location = new Point(512, 336);
            dtpGarantia.Name = "dtpGarantia";
            dtpGarantia.Size = new Size(256, 23);
            dtpGarantia.TabIndex = 21;
            // 
            // NobreakForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(800, 450);
            Controls.Add(dtpGarantia);
            Controls.Add(cmbLocal);
            Controls.Add(cmbModelo);
            Controls.Add(txtVida);
            Controls.Add(dtpAquisicao);
            Controls.Add(txtCapacidade);
            Controls.Add(lblVida);
            Controls.Add(lblGarantia);
            Controls.Add(lblAquisicao);
            Controls.Add(lblCapacidade);
            Controls.Add(lblLocal);
            Controls.Add(lblModelo);
            Controls.Add(btnVoltar);
            Controls.Add(btnLimpar);
            Controls.Add(btnExcluir);
            Controls.Add(btnAdicionar);
            Controls.Add(dgvNobreak);
            Name = "NobreakForm";
            Text = "NobreakForm";
            Load += NobreakForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvNobreak).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvNobreak;
        private Button btnAdicionar;
        private Button btnExcluir;
        private Button btnLimpar;
        private Button btnVoltar;
        private Label lblModelo;
        private Label lblLocal;
        private Label lblCapacidade;
        private Label lblAquisicao;
        private Label lblGarantia;
        private Label lblVida;
        private TextBox txtCapacidade;
        private DateTimePicker dtpAquisicao;
        private TextBox txtVida;
        private ComboBox cmbModelo;
        private ComboBox cmbLocal;
        private DateTimePicker dtpGarantia;
    }
}