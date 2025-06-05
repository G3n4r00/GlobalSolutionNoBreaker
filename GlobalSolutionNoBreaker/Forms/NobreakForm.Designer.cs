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
            dgvNobreak.Location = new Point(9, 11);
            dgvNobreak.Margin = new Padding(3, 4, 3, 4);
            dgvNobreak.Name = "dgvNobreak";
            dgvNobreak.Size = new Size(887, 331);
            dgvNobreak.TabIndex = 0;
            dgvNobreak.CellContentClick += dataGridView1_CellContentClick;
            dgvNobreak.CellDoubleClick += dgvNobreak_CellDoubleClick;
            // 
            // btnAdicionar
            // 
            btnAdicionar.Location = new Point(9, 544);
            btnAdicionar.Margin = new Padding(3, 4, 3, 4);
            btnAdicionar.Name = "btnAdicionar";
            btnAdicionar.Size = new Size(86, 31);
            btnAdicionar.TabIndex = 1;
            btnAdicionar.Text = "Adicionar";
            btnAdicionar.UseVisualStyleBackColor = true;
            btnAdicionar.Click += btnAdicionar_Click;
            // 
            // btnExcluir
            // 
            btnExcluir.Location = new Point(155, 544);
            btnExcluir.Margin = new Padding(3, 4, 3, 4);
            btnExcluir.Name = "btnExcluir";
            btnExcluir.Size = new Size(86, 31);
            btnExcluir.TabIndex = 2;
            btnExcluir.Text = "Excluir";
            btnExcluir.UseVisualStyleBackColor = true;
            btnExcluir.Click += btnExcluir_Click;
            // 
            // btnLimpar
            // 
            btnLimpar.Location = new Point(320, 544);
            btnLimpar.Margin = new Padding(3, 4, 3, 4);
            btnLimpar.Name = "btnLimpar";
            btnLimpar.Size = new Size(86, 31);
            btnLimpar.TabIndex = 3;
            btnLimpar.Text = "Limpar";
            btnLimpar.UseVisualStyleBackColor = true;
            btnLimpar.Click += btnLimpar_Click;
            // 
            // btnVoltar
            // 
            btnVoltar.Location = new Point(466, 544);
            btnVoltar.Margin = new Padding(3, 4, 3, 4);
            btnVoltar.Name = "btnVoltar";
            btnVoltar.Size = new Size(86, 31);
            btnVoltar.TabIndex = 4;
            btnVoltar.Text = "Voltar";
            btnVoltar.UseVisualStyleBackColor = true;
            btnVoltar.Click += btnVoltar_Click;
            // 
            // lblModelo
            // 
            lblModelo.AutoSize = true;
            lblModelo.Location = new Point(18, 373);
            lblModelo.Name = "lblModelo";
            lblModelo.Size = new Size(61, 20);
            lblModelo.TabIndex = 5;
            lblModelo.Text = "Modelo";
            // 
            // lblLocal
            // 
            lblLocal.AutoSize = true;
            lblLocal.Location = new Point(18, 427);
            lblLocal.Name = "lblLocal";
            lblLocal.Size = new Size(125, 20);
            lblLocal.TabIndex = 6;
            lblLocal.Text = "Localização física";
            // 
            // lblCapacidade
            // 
            lblCapacidade.AutoSize = true;
            lblCapacidade.Location = new Point(16, 480);
            lblCapacidade.Name = "lblCapacidade";
            lblCapacidade.Size = new Size(120, 20);
            lblCapacidade.TabIndex = 7;
            lblCapacidade.Text = "Capacidade (VA)";
            // 
            // lblAquisicao
            // 
            lblAquisicao.AutoSize = true;
            lblAquisicao.Location = new Point(440, 368);
            lblAquisicao.Name = "lblAquisicao";
            lblAquisicao.Size = new Size(131, 20);
            lblAquisicao.TabIndex = 8;
            lblAquisicao.Text = "Data de Aquisição";
            // 
            // lblGarantia
            // 
            lblGarantia.AutoSize = true;
            lblGarantia.Location = new Point(440, 432);
            lblGarantia.Name = "lblGarantia";
            lblGarantia.Size = new Size(122, 20);
            lblGarantia.TabIndex = 9;
            lblGarantia.Text = "Data da Garantia";
            lblGarantia.Click += lblVida_Click;
            // 
            // lblVida
            // 
            lblVida.AutoSize = true;
            lblVida.Location = new Point(440, 480);
            lblVida.Name = "lblVida";
            lblVida.Size = new Size(134, 20);
            lblVida.TabIndex = 10;
            lblVida.Text = "Vida util (em anos)";
            // 
            // txtCapacidade
            // 
            txtCapacidade.Location = new Point(137, 480);
            txtCapacidade.Margin = new Padding(3, 4, 3, 4);
            txtCapacidade.Name = "txtCapacidade";
            txtCapacidade.Size = new Size(263, 27);
            txtCapacidade.TabIndex = 14;
            // 
            // dtpAquisicao
            // 
            dtpAquisicao.Location = new Point(576, 368);
            dtpAquisicao.Margin = new Padding(3, 4, 3, 4);
            dtpAquisicao.Name = "dtpAquisicao";
            dtpAquisicao.Size = new Size(292, 27);
            dtpAquisicao.TabIndex = 16;
            // 
            // txtVida
            // 
            txtVida.Location = new Point(576, 480);
            txtVida.Margin = new Padding(3, 4, 3, 4);
            txtVida.Name = "txtVida";
            txtVida.Size = new Size(292, 27);
            txtVida.TabIndex = 18;
            // 
            // cmbModelo
            // 
            cmbModelo.FormattingEnabled = true;
            cmbModelo.Location = new Point(144, 368);
            cmbModelo.Margin = new Padding(3, 4, 3, 4);
            cmbModelo.Name = "cmbModelo";
            cmbModelo.Size = new Size(255, 28);
            cmbModelo.TabIndex = 19;
            // 
            // cmbLocal
            // 
            cmbLocal.FormattingEnabled = true;
            cmbLocal.Location = new Point(144, 424);
            cmbLocal.Margin = new Padding(3, 4, 3, 4);
            cmbLocal.Name = "cmbLocal";
            cmbLocal.Size = new Size(256, 28);
            cmbLocal.TabIndex = 20;
            // 
            // dtpGarantia
            // 
            dtpGarantia.Location = new Point(576, 432);
            dtpGarantia.Margin = new Padding(3, 4, 3, 4);
            dtpGarantia.Name = "dtpGarantia";
            dtpGarantia.Size = new Size(292, 27);
            dtpGarantia.TabIndex = 21;
            // 
            // NobreakForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(914, 600);
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
            Margin = new Padding(3, 5, 3, 5);
            MinimumSize = new Size(518, 503);
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