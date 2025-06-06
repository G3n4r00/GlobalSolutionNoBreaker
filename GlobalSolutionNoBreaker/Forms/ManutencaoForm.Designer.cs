namespace GlobalSolutionNoBreaker.Forms
{
    partial class ManutencaoForm
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
            dgvManutencao = new DataGridView();
            foxBigLabel1 = new ReaLTaiizor.Controls.FoxBigLabel();
            headerLabel1 = new ReaLTaiizor.Controls.HeaderLabel();
            lblIdManutencao = new ReaLTaiizor.Controls.HeaderLabel();
            btnSalvarManutencao = new ReaLTaiizor.Controls.HopeRoundButton();
            headerLabel2 = new ReaLTaiizor.Controls.HeaderLabel();
            cmbStatusManutencao = new ReaLTaiizor.Controls.HopeComboBox();
            dtpManutencao = new DateTimePicker();
            txtIdManutencao = new ReaLTaiizor.Controls.HeaderLabel();
            btnVoltarManutencao = new ReaLTaiizor.Controls.HopeRoundButton();
            panel1 = new Panel();
            panel2 = new Panel();
            panel3 = new Panel();
            panel4 = new Panel();
            ((System.ComponentModel.ISupportInitialize)dgvManutencao).BeginInit();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            panel4.SuspendLayout();
            SuspendLayout();
            // 
            // dgvManutencao
            // 
            dgvManutencao.AllowUserToAddRows = false;
            dgvManutencao.AllowUserToDeleteRows = false;
            dgvManutencao.AllowUserToResizeRows = false;
            dgvManutencao.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvManutencao.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvManutencao.Dock = DockStyle.Fill;
            dgvManutencao.Location = new Point(0, 64);
            dgvManutencao.Margin = new Padding(3, 4, 3, 4);
            dgvManutencao.Name = "dgvManutencao";
            dgvManutencao.ReadOnly = true;
            dgvManutencao.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvManutencao.Size = new Size(914, 333);
            dgvManutencao.TabIndex = 1;
            dgvManutencao.CellDoubleClick += dgvManutencao_CellDoubleClick;
            // 
            // foxBigLabel1
            // 
            foxBigLabel1.BackColor = Color.Transparent;
            foxBigLabel1.Font = new Font("Segoe UI Semibold", 20F);
            foxBigLabel1.ForeColor = Color.White;
            foxBigLabel1.Line = ReaLTaiizor.Controls.FoxBigLabel.Direction.Bottom;
            foxBigLabel1.LineColor = Color.FromArgb(200, 200, 200);
            foxBigLabel1.Location = new Point(16, 8);
            foxBigLabel1.Name = "foxBigLabel1";
            foxBigLabel1.Size = new Size(312, 41);
            foxBigLabel1.TabIndex = 2;
            foxBigLabel1.Text = "Registro de Manutenção";
            // 
            // headerLabel1
            // 
            headerLabel1.AutoSize = true;
            headerLabel1.BackColor = Color.Transparent;
            headerLabel1.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Bold);
            headerLabel1.ForeColor = Color.FromArgb(255, 255, 255);
            headerLabel1.Location = new Point(376, 24);
            headerLabel1.Name = "headerLabel1";
            headerLabel1.RightToLeft = RightToLeft.Yes;
            headerLabel1.Size = new Size(163, 18);
            headerLabel1.TabIndex = 5;
            headerLabel1.Text = "Data da Manutenção";
            // 
            // lblIdManutencao
            // 
            lblIdManutencao.AutoSize = true;
            lblIdManutencao.BackColor = Color.Transparent;
            lblIdManutencao.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold);
            lblIdManutencao.ForeColor = Color.FromArgb(255, 255, 255);
            lblIdManutencao.Location = new Point(304, 16);
            lblIdManutencao.Name = "lblIdManutencao";
            lblIdManutencao.RightToLeft = RightToLeft.Yes;
            lblIdManutencao.Size = new Size(150, 24);
            lblIdManutencao.TabIndex = 7;
            lblIdManutencao.Text = "Id Selecionado";
            // 
            // btnSalvarManutencao
            // 
            btnSalvarManutencao.BorderColor = Color.FromArgb(220, 223, 230);
            btnSalvarManutencao.ButtonType = ReaLTaiizor.Util.HopeButtonType.Primary;
            btnSalvarManutencao.DangerColor = Color.FromArgb(245, 108, 108);
            btnSalvarManutencao.DefaultColor = Color.FromArgb(255, 255, 255);
            btnSalvarManutencao.Font = new Font("Segoe UI", 12F);
            btnSalvarManutencao.HoverTextColor = Color.FromArgb(48, 49, 51);
            btnSalvarManutencao.InfoColor = Color.FromArgb(144, 147, 153);
            btnSalvarManutencao.Location = new Point(544, 8);
            btnSalvarManutencao.Name = "btnSalvarManutencao";
            btnSalvarManutencao.PrimaryColor = Color.FromArgb(64, 158, 255);
            btnSalvarManutencao.Size = new Size(328, 32);
            btnSalvarManutencao.SuccessColor = Color.FromArgb(103, 194, 58);
            btnSalvarManutencao.TabIndex = 9;
            btnSalvarManutencao.Text = "Salvar";
            btnSalvarManutencao.TextColor = Color.White;
            btnSalvarManutencao.WarningColor = Color.FromArgb(230, 162, 60);
            btnSalvarManutencao.Click += hopeRoundButton1_Click;
            // 
            // headerLabel2
            // 
            headerLabel2.AutoSize = true;
            headerLabel2.BackColor = Color.Transparent;
            headerLabel2.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Bold);
            headerLabel2.ForeColor = Color.FromArgb(255, 255, 255);
            headerLabel2.Location = new Point(8, 24);
            headerLabel2.Name = "headerLabel2";
            headerLabel2.RightToLeft = RightToLeft.Yes;
            headerLabel2.Size = new Size(152, 18);
            headerLabel2.TabIndex = 10;
            headerLabel2.Text = "Status Operacional";
            // 
            // cmbStatusManutencao
            // 
            cmbStatusManutencao.DrawMode = DrawMode.OwnerDrawFixed;
            cmbStatusManutencao.FlatStyle = FlatStyle.Flat;
            cmbStatusManutencao.Font = new Font("Segoe UI", 10F);
            cmbStatusManutencao.FormattingEnabled = true;
            cmbStatusManutencao.ItemHeight = 20;
            cmbStatusManutencao.Location = new Point(168, 24);
            cmbStatusManutencao.Name = "cmbStatusManutencao";
            cmbStatusManutencao.Size = new Size(192, 26);
            cmbStatusManutencao.TabIndex = 11;
            // 
            // dtpManutencao
            // 
            dtpManutencao.Location = new Point(552, 24);
            dtpManutencao.Name = "dtpManutencao";
            dtpManutencao.Size = new Size(328, 27);
            dtpManutencao.TabIndex = 12;
            // 
            // txtIdManutencao
            // 
            txtIdManutencao.AutoSize = true;
            txtIdManutencao.BackColor = Color.Transparent;
            txtIdManutencao.Font = new Font("Microsoft Sans Serif", 22F, FontStyle.Bold);
            txtIdManutencao.ForeColor = Color.FromArgb(255, 255, 255);
            txtIdManutencao.Location = new Point(472, 8);
            txtIdManutencao.Name = "txtIdManutencao";
            txtIdManutencao.Size = new Size(33, 36);
            txtIdManutencao.TabIndex = 13;
            txtIdManutencao.Text = "0";
            // 
            // btnVoltarManutencao
            // 
            btnVoltarManutencao.BackgroundImageLayout = ImageLayout.Center;
            btnVoltarManutencao.BorderColor = Color.FromArgb(220, 223, 230);
            btnVoltarManutencao.ButtonType = ReaLTaiizor.Util.HopeButtonType.Danger;
            btnVoltarManutencao.DangerColor = Color.FromArgb(245, 108, 108);
            btnVoltarManutencao.DefaultColor = Color.FromArgb(255, 255, 255);
            btnVoltarManutencao.Font = new Font("Segoe UI", 12F);
            btnVoltarManutencao.HoverTextColor = Color.FromArgb(48, 49, 51);
            btnVoltarManutencao.InfoColor = Color.FromArgb(144, 147, 153);
            btnVoltarManutencao.Location = new Point(8, 8);
            btnVoltarManutencao.Name = "btnVoltarManutencao";
            btnVoltarManutencao.PrimaryColor = Color.FromArgb(64, 158, 255);
            btnVoltarManutencao.Size = new Size(328, 32);
            btnVoltarManutencao.SuccessColor = Color.FromArgb(103, 194, 58);
            btnVoltarManutencao.TabIndex = 14;
            btnVoltarManutencao.Text = "Voltar";
            btnVoltarManutencao.TextColor = Color.White;
            btnVoltarManutencao.WarningColor = Color.FromArgb(230, 162, 60);
            btnVoltarManutencao.Click += btnVoltarManutencao_Click;
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.MenuHighlight;
            panel1.Controls.Add(btnVoltarManutencao);
            panel1.Controls.Add(btnSalvarManutencao);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(0, 513);
            panel1.Name = "panel1";
            panel1.Size = new Size(914, 48);
            panel1.TabIndex = 15;
            // 
            // panel2
            // 
            panel2.Controls.Add(cmbStatusManutencao);
            panel2.Controls.Add(headerLabel2);
            panel2.Controls.Add(dtpManutencao);
            panel2.Controls.Add(headerLabel1);
            panel2.Dock = DockStyle.Bottom;
            panel2.Location = new Point(0, 445);
            panel2.Name = "panel2";
            panel2.Size = new Size(914, 68);
            panel2.TabIndex = 16;
            // 
            // panel3
            // 
            panel3.Controls.Add(txtIdManutencao);
            panel3.Controls.Add(lblIdManutencao);
            panel3.Dock = DockStyle.Bottom;
            panel3.Location = new Point(0, 397);
            panel3.Name = "panel3";
            panel3.Size = new Size(914, 48);
            panel3.TabIndex = 17;
            // 
            // panel4
            // 
            panel4.BackColor = SystemColors.MenuHighlight;
            panel4.Controls.Add(foxBigLabel1);
            panel4.Dock = DockStyle.Top;
            panel4.Location = new Point(0, 0);
            panel4.Name = "panel4";
            panel4.Size = new Size(914, 64);
            panel4.TabIndex = 18;
            // 
            // ManutencaoForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(914, 561);
            ControlBox = false;
            Controls.Add(dgvManutencao);
            Controls.Add(panel4);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Margin = new Padding(3, 5, 3, 5);
            MinimumSize = new Size(518, 500);
            Name = "ManutencaoForm";
            Text = "Manutenção Geral";
            Load += ManutencaoForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvManutencao).EndInit();
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel4.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private DataGridView dgvManutencao;
        private ReaLTaiizor.Controls.FoxBigLabel foxBigLabel1;
        private ReaLTaiizor.Controls.HeaderLabel headerLabel1;
        private ReaLTaiizor.Controls.HeaderLabel lblIdManutencao;
        private ReaLTaiizor.Controls.HopeRoundButton btnSalvarManutencao;
        private ReaLTaiizor.Controls.HeaderLabel headerLabel2;
        private ReaLTaiizor.Controls.HopeComboBox cmbStatusManutencao;
        private DateTimePicker dtpManutencao;
        private ReaLTaiizor.Controls.HeaderLabel txtIdManutencao;
        private ReaLTaiizor.Controls.HopeRoundButton btnVoltarManutencao;
        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
        private Panel panel4;
    }
}