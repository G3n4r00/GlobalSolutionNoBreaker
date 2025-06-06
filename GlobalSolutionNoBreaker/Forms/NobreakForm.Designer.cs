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
            foxBigLabel1 = new ReaLTaiizor.Controls.FoxBigLabel();
            panelTopNobreaks = new Panel();
            pannelBottomDown = new Panel();
            panelBottomUp = new Panel();
            ((System.ComponentModel.ISupportInitialize)dgvNobreak).BeginInit();
            panelTopNobreaks.SuspendLayout();
            pannelBottomDown.SuspendLayout();
            panelBottomUp.SuspendLayout();
            SuspendLayout();
            // 
            // dgvNobreak
            // 
            dgvNobreak.AllowUserToAddRows = false;
            dgvNobreak.AllowUserToDeleteRows = false;
            dgvNobreak.AllowUserToOrderColumns = true;
            dgvNobreak.AllowUserToResizeRows = false;
            dgvNobreak.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvNobreak.BackgroundColor = SystemColors.ActiveCaption;
            dgvNobreak.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dgvNobreak.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvNobreak.Dock = DockStyle.Fill;
            dgvNobreak.Location = new Point(0, 60);
            dgvNobreak.Margin = new Padding(3, 4, 3, 4);
            dgvNobreak.Name = "dgvNobreak";
            dgvNobreak.ReadOnly = true;
            dgvNobreak.ScrollBars = ScrollBars.Vertical;
            dgvNobreak.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvNobreak.Size = new Size(914, 325);
            dgvNobreak.TabIndex = 0;
            dgvNobreak.CellDoubleClick += dgvNobreak_CellDoubleClick;
            // 
            // dtpAquisicao
            // 
            dtpAquisicao.Location = new Point(208, 48);
            dtpAquisicao.Margin = new Padding(3, 4, 3, 4);
            dtpAquisicao.Name = "dtpAquisicao";
            dtpAquisicao.Size = new Size(312, 27);
            dtpAquisicao.TabIndex = 16;
            // 
            // cmbLocal
            // 
            cmbLocal.DrawMode = DrawMode.OwnerDrawFixed;
            cmbLocal.FlatStyle = FlatStyle.Flat;
            cmbLocal.Font = new Font("Segoe UI", 10F);
            cmbLocal.FormattingEnabled = true;
            cmbLocal.ItemHeight = 20;
            cmbLocal.Location = new Point(608, 24);
            cmbLocal.Name = "cmbLocal";
            cmbLocal.Size = new Size(288, 26);
            cmbLocal.TabIndex = 20;
            // 
            // cmbModelo
            // 
            cmbModelo.DrawMode = DrawMode.OwnerDrawFixed;
            cmbModelo.FlatStyle = FlatStyle.Flat;
            cmbModelo.Font = new Font("Segoe UI", 10F);
            cmbModelo.FormattingEnabled = true;
            cmbModelo.ItemHeight = 20;
            cmbModelo.Location = new Point(208, 8);
            cmbModelo.Name = "cmbModelo";
            cmbModelo.Size = new Size(312, 26);
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
            btnVoltarNobreak.Location = new Point(16, 8);
            btnVoltarNobreak.Name = "btnVoltarNobreak";
            btnVoltarNobreak.PrimaryColor = Color.FromArgb(64, 158, 255);
            btnVoltarNobreak.Size = new Size(128, 32);
            btnVoltarNobreak.SuccessColor = Color.FromArgb(103, 194, 58);
            btnVoltarNobreak.TabIndex = 23;
            btnVoltarNobreak.Text = "Voltar";
            btnVoltarNobreak.TextColor = Color.White;
            btnVoltarNobreak.WarningColor = Color.FromArgb(230, 162, 60);
            btnVoltarNobreak.Click += btnVoltarNobreak_Click;
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
            btnLimpar.Location = new Point(512, 8);
            btnLimpar.Name = "btnLimpar";
            btnLimpar.PrimaryColor = Color.FromArgb(64, 158, 255);
            btnLimpar.Size = new Size(176, 32);
            btnLimpar.SuccessColor = Color.FromArgb(103, 194, 58);
            btnLimpar.TabIndex = 24;
            btnLimpar.Text = "Limpar";
            btnLimpar.TextColor = Color.White;
            btnLimpar.WarningColor = Color.FromArgb(230, 162, 60);
            btnLimpar.Click += btnLimpar_Click_1;
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
            btnExcluir.Location = new Point(328, 8);
            btnExcluir.Name = "btnExcluir";
            btnExcluir.PrimaryColor = Color.FromArgb(64, 158, 255);
            btnExcluir.Size = new Size(176, 32);
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
            btnAdicionar.Location = new Point(696, 8);
            btnAdicionar.Name = "btnAdicionar";
            btnAdicionar.PrimaryColor = Color.FromArgb(64, 158, 255);
            btnAdicionar.Size = new Size(208, 32);
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
            headerLabel1.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            headerLabel1.ForeColor = Color.FromArgb(255, 255, 255);
            headerLabel1.Location = new Point(32, 8);
            headerLabel1.Name = "headerLabel1";
            headerLabel1.Size = new Size(161, 20);
            headerLabel1.TabIndex = 27;
            headerLabel1.Text = "Localização Física:";
            // 
            // headerLabel2
            // 
            headerLabel2.AutoSize = true;
            headerLabel2.BackColor = Color.Transparent;
            headerLabel2.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            headerLabel2.ForeColor = Color.FromArgb(255, 255, 255);
            headerLabel2.Location = new Point(536, 32);
            headerLabel2.Name = "headerLabel2";
            headerLabel2.Size = new Size(72, 20);
            headerLabel2.TabIndex = 28;
            headerLabel2.Text = "Modelo:";
            // 
            // headerLabel3
            // 
            headerLabel3.AutoSize = true;
            headerLabel3.BackColor = Color.Transparent;
            headerLabel3.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            headerLabel3.ForeColor = Color.FromArgb(255, 255, 255);
            headerLabel3.Location = new Point(40, 48);
            headerLabel3.Name = "headerLabel3";
            headerLabel3.Size = new Size(136, 20);
            headerLabel3.TabIndex = 29;
            headerLabel3.Text = "Data Aquisição:";
            // 
            // foxBigLabel1
            // 
            foxBigLabel1.BackColor = Color.Transparent;
            foxBigLabel1.Font = new Font("Segoe UI Semibold", 20F);
            foxBigLabel1.ForeColor = Color.Black;
            foxBigLabel1.Line = ReaLTaiizor.Controls.FoxBigLabel.Direction.Bottom;
            foxBigLabel1.LineColor = Color.FromArgb(200, 200, 200);
            foxBigLabel1.Location = new Point(16, 8);
            foxBigLabel1.Name = "foxBigLabel1";
            foxBigLabel1.Size = new Size(272, 41);
            foxBigLabel1.TabIndex = 30;
            foxBigLabel1.Text = "Registro de Nobreaks";
            // 
            // panelTopNobreaks
            // 
            panelTopNobreaks.BackColor = SystemColors.MenuHighlight;
            panelTopNobreaks.Controls.Add(foxBigLabel1);
            panelTopNobreaks.Dock = DockStyle.Top;
            panelTopNobreaks.Location = new Point(0, 0);
            panelTopNobreaks.Name = "panelTopNobreaks";
            panelTopNobreaks.Size = new Size(914, 60);
            panelTopNobreaks.TabIndex = 31;
            // 
            // pannelBottomDown
            // 
            pannelBottomDown.BackColor = SystemColors.MenuHighlight;
            pannelBottomDown.Controls.Add(btnVoltarNobreak);
            pannelBottomDown.Controls.Add(btnExcluir);
            pannelBottomDown.Controls.Add(btnAdicionar);
            pannelBottomDown.Controls.Add(btnLimpar);
            pannelBottomDown.Dock = DockStyle.Bottom;
            pannelBottomDown.Location = new Point(0, 505);
            pannelBottomDown.Name = "pannelBottomDown";
            pannelBottomDown.Size = new Size(914, 56);
            pannelBottomDown.TabIndex = 32;
            // 
            // panelBottomUp
            // 
            panelBottomUp.Controls.Add(headerLabel2);
            panelBottomUp.Controls.Add(headerLabel3);
            panelBottomUp.Controls.Add(cmbModelo);
            panelBottomUp.Controls.Add(cmbLocal);
            panelBottomUp.Controls.Add(headerLabel1);
            panelBottomUp.Controls.Add(dtpAquisicao);
            panelBottomUp.Dock = DockStyle.Bottom;
            panelBottomUp.Location = new Point(0, 385);
            panelBottomUp.Name = "panelBottomUp";
            panelBottomUp.Size = new Size(914, 120);
            panelBottomUp.TabIndex = 33;
            // 
            // NobreakForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(914, 561);
            ControlBox = false;
            Controls.Add(dgvNobreak);
            Controls.Add(panelBottomUp);
            Controls.Add(pannelBottomDown);
            Controls.Add(panelTopNobreaks);
            Margin = new Padding(3, 5, 3, 5);
            MinimumSize = new Size(518, 500);
            Name = "NobreakForm";
            Text = "Registro de Nobreak";
            Load += NobreakForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvNobreak).EndInit();
            panelTopNobreaks.ResumeLayout(false);
            pannelBottomDown.ResumeLayout(false);
            panelBottomUp.ResumeLayout(false);
            panelBottomUp.PerformLayout();
            ResumeLayout(false);
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
        private ReaLTaiizor.Controls.FoxBigLabel foxBigLabel1;
        private Panel panelTopNobreaks;
        private Panel pannelBottomDown;
        private Panel panelBottomUp;
    }
}