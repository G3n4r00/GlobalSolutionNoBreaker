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
            dtpAquisicao = new DateTimePicker();
            cmbLocal = new ReaLTaiizor.Controls.HopeComboBox();
            cmbModelo = new ReaLTaiizor.Controls.HopeComboBox();
            btnVoltarNobreak = new ReaLTaiizor.Controls.HopeRoundButton();
            btnLimpar = new ReaLTaiizor.Controls.HopeRoundButton();
            btnExcluir = new ReaLTaiizor.Controls.HopeRoundButton();
            btnAdicionar = new ReaLTaiizor.Controls.HopeRoundButton();
            headerLabel1 = new ReaLTaiizor.Controls.HeaderLabel();
            headerLabel2 = new ReaLTaiizor.Controls.HeaderLabel();
            headerLabel3 = new ReaLTaiizor.Controls.HeaderLabel();
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
            dgvNobreak.Size = new Size(895, 373);
            dgvNobreak.TabIndex = 0;
            dgvNobreak.CellContentClick += dataGridView1_CellContentClick;
            dgvNobreak.CellDoubleClick += dgvNobreak_CellDoubleClick;
            // 
            // dtpAquisicao
            // 
            dtpAquisicao.Location = new Point(600, 416);
            dtpAquisicao.Margin = new Padding(3, 4, 3, 4);
            dtpAquisicao.Name = "dtpAquisicao";
            dtpAquisicao.Size = new Size(292, 27);
            dtpAquisicao.TabIndex = 16;
            // 
            // cmbLocal
            // 
            cmbLocal.DrawMode = DrawMode.OwnerDrawFixed;
            cmbLocal.FlatStyle = FlatStyle.Flat;
            cmbLocal.Font = new Font("Segoe UI", 10F);
            cmbLocal.FormattingEnabled = true;
            cmbLocal.ItemHeight = 24;
            cmbLocal.Location = new Point(296, 488);
            cmbLocal.Name = "cmbLocal";
            cmbLocal.Size = new Size(328, 30);
            cmbLocal.TabIndex = 21;
            // 
            // cmbModelo
            // 
            cmbModelo.DrawMode = DrawMode.OwnerDrawFixed;
            cmbModelo.FlatStyle = FlatStyle.Flat;
            cmbModelo.Font = new Font("Segoe UI", 10F);
            cmbModelo.FormattingEnabled = true;
            cmbModelo.ItemHeight = 24;
            cmbModelo.Location = new Point(120, 416);
            cmbModelo.Name = "cmbModelo";
            cmbModelo.Size = new Size(280, 30);
            cmbModelo.TabIndex = 22;
            // 
            // btnVoltarNobreak
            // 
            btnVoltarNobreak.BorderColor = Color.FromArgb(220, 223, 230);
            btnVoltarNobreak.ButtonType = ReaLTaiizor.Util.HopeButtonType.Primary;
            btnVoltarNobreak.DangerColor = Color.FromArgb(245, 108, 108);
            btnVoltarNobreak.DefaultColor = Color.FromArgb(255, 255, 255);
            btnVoltarNobreak.Font = new Font("Segoe UI", 12F);
            btnVoltarNobreak.HoverTextColor = Color.FromArgb(48, 49, 51);
            btnVoltarNobreak.InfoColor = Color.FromArgb(144, 147, 153);
            btnVoltarNobreak.Location = new Point(16, 552);
            btnVoltarNobreak.Name = "btnVoltarNobreak";
            btnVoltarNobreak.PrimaryColor = Color.FromArgb(64, 158, 255);
            btnVoltarNobreak.Size = new Size(128, 32);
            btnVoltarNobreak.SuccessColor = Color.FromArgb(103, 194, 58);
            btnVoltarNobreak.TabIndex = 23;
            btnVoltarNobreak.Text = "Voltar";
            btnVoltarNobreak.TextColor = Color.White;
            btnVoltarNobreak.WarningColor = Color.FromArgb(230, 162, 60);
            // 
            // btnLimpar
            // 
            btnLimpar.BorderColor = Color.FromArgb(220, 223, 230);
            btnLimpar.ButtonType = ReaLTaiizor.Util.HopeButtonType.Primary;
            btnLimpar.DangerColor = Color.FromArgb(245, 108, 108);
            btnLimpar.DefaultColor = Color.FromArgb(255, 255, 255);
            btnLimpar.Font = new Font("Segoe UI", 12F);
            btnLimpar.HoverTextColor = Color.FromArgb(48, 49, 51);
            btnLimpar.InfoColor = Color.FromArgb(144, 147, 153);
            btnLimpar.Location = new Point(600, 552);
            btnLimpar.Name = "btnLimpar";
            btnLimpar.PrimaryColor = Color.FromArgb(64, 158, 255);
            btnLimpar.Size = new Size(128, 32);
            btnLimpar.SuccessColor = Color.FromArgb(103, 194, 58);
            btnLimpar.TabIndex = 24;
            btnLimpar.Text = "Limpar";
            btnLimpar.TextColor = Color.White;
            btnLimpar.WarningColor = Color.FromArgb(230, 162, 60);
            // 
            // btnExcluir
            // 
            btnExcluir.BorderColor = Color.FromArgb(220, 223, 230);
            btnExcluir.ButtonType = ReaLTaiizor.Util.HopeButtonType.Primary;
            btnExcluir.DangerColor = Color.FromArgb(245, 108, 108);
            btnExcluir.DefaultColor = Color.FromArgb(255, 255, 255);
            btnExcluir.Font = new Font("Segoe UI", 12F);
            btnExcluir.HoverTextColor = Color.FromArgb(48, 49, 51);
            btnExcluir.InfoColor = Color.FromArgb(144, 147, 153);
            btnExcluir.Location = new Point(448, 552);
            btnExcluir.Name = "btnExcluir";
            btnExcluir.PrimaryColor = Color.FromArgb(64, 158, 255);
            btnExcluir.Size = new Size(128, 32);
            btnExcluir.SuccessColor = Color.FromArgb(103, 194, 58);
            btnExcluir.TabIndex = 25;
            btnExcluir.Text = "Excluir";
            btnExcluir.TextColor = Color.White;
            btnExcluir.WarningColor = Color.FromArgb(230, 162, 60);
            // 
            // btnAdicionar
            // 
            btnAdicionar.BorderColor = Color.FromArgb(220, 223, 230);
            btnAdicionar.ButtonType = ReaLTaiizor.Util.HopeButtonType.Primary;
            btnAdicionar.DangerColor = Color.FromArgb(245, 108, 108);
            btnAdicionar.DefaultColor = Color.FromArgb(255, 255, 255);
            btnAdicionar.Font = new Font("Segoe UI", 12F);
            btnAdicionar.HoverTextColor = Color.FromArgb(48, 49, 51);
            btnAdicionar.InfoColor = Color.FromArgb(144, 147, 153);
            btnAdicionar.Location = new Point(760, 552);
            btnAdicionar.Name = "btnAdicionar";
            btnAdicionar.PrimaryColor = Color.FromArgb(64, 158, 255);
            btnAdicionar.Size = new Size(128, 32);
            btnAdicionar.SuccessColor = Color.FromArgb(103, 194, 58);
            btnAdicionar.TabIndex = 26;
            btnAdicionar.Text = "Adicionar";
            btnAdicionar.TextColor = Color.White;
            btnAdicionar.WarningColor = Color.FromArgb(230, 162, 60);
            // 
            // headerLabel1
            // 
            headerLabel1.AutoSize = true;
            headerLabel1.BackColor = Color.Transparent;
            headerLabel1.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Bold);
            headerLabel1.ForeColor = Color.FromArgb(255, 255, 255);
            headerLabel1.Location = new Point(128, 496);
            headerLabel1.Name = "headerLabel1";
            headerLabel1.Size = new Size(154, 18);
            headerLabel1.TabIndex = 27;
            headerLabel1.Text = "Localização Física:";
            // 
            // headerLabel2
            // 
            headerLabel2.AutoSize = true;
            headerLabel2.BackColor = Color.Transparent;
            headerLabel2.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Bold);
            headerLabel2.ForeColor = Color.FromArgb(255, 255, 255);
            headerLabel2.Location = new Point(32, 424);
            headerLabel2.Name = "headerLabel2";
            headerLabel2.Size = new Size(69, 18);
            headerLabel2.TabIndex = 28;
            headerLabel2.Text = "Modelo:";
            // 
            // headerLabel3
            // 
            headerLabel3.AutoSize = true;
            headerLabel3.BackColor = Color.Transparent;
            headerLabel3.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Bold);
            headerLabel3.ForeColor = Color.FromArgb(255, 255, 255);
            headerLabel3.Location = new Point(464, 424);
            headerLabel3.Name = "headerLabel3";
            headerLabel3.Size = new Size(126, 18);
            headerLabel3.TabIndex = 29;
            headerLabel3.Text = "Data Aquisição:";
            // 
            // NobreakForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(914, 600);
            Controls.Add(headerLabel3);
            Controls.Add(headerLabel2);
            Controls.Add(headerLabel1);
            Controls.Add(btnAdicionar);
            Controls.Add(btnExcluir);
            Controls.Add(btnLimpar);
            Controls.Add(btnVoltarNobreak);
            Controls.Add(cmbModelo);
            Controls.Add(cmbLocal);
            Controls.Add(dtpAquisicao);
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
        private DateTimePicker dtpAquisicao;
        //private ComboBox cmbLocal;
        private ReaLTaiizor.Controls.HopeComboBox cmbLocal;
        private ReaLTaiizor.Controls.HopeComboBox cmbModelo;
        private ReaLTaiizor.Controls.HopeRoundButton btnVoltarNobreak;
        private ReaLTaiizor.Controls.HopeRoundButton btnLimpar;
        private ReaLTaiizor.Controls.HopeRoundButton btnExcluir;
        private ReaLTaiizor.Controls.HopeRoundButton btnAdicionar;
        private ReaLTaiizor.Controls.HeaderLabel headerLabel1;
        private ReaLTaiizor.Controls.HeaderLabel headerLabel2;
        private ReaLTaiizor.Controls.HeaderLabel headerLabel3;
    }
}