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
            ((System.ComponentModel.ISupportInitialize)dgvManutencao).BeginInit();
            SuspendLayout();
            // 
            // dgvManutencao
            // 
            dgvManutencao.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvManutencao.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvManutencao.Location = new Point(16, 56);
            dgvManutencao.Margin = new Padding(3, 4, 3, 4);
            dgvManutencao.Name = "dgvManutencao";
            dgvManutencao.Size = new Size(880, 296);
            dgvManutencao.TabIndex = 1;
            dgvManutencao.CellDoubleClick += dgvManutencao_CellDoubleClick;
            // 
            // foxBigLabel1
            // 
            foxBigLabel1.BackColor = Color.Transparent;
            foxBigLabel1.Font = new Font("Segoe UI Semibold", 20F);
            foxBigLabel1.ForeColor = Color.FromArgb(76, 88, 100);
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
            headerLabel1.Location = new Point(568, 424);
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
            lblIdManutencao.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Bold);
            lblIdManutencao.ForeColor = Color.FromArgb(255, 255, 255);
            lblIdManutencao.Location = new Point(400, 368);
            lblIdManutencao.Name = "lblIdManutencao";
            lblIdManutencao.RightToLeft = RightToLeft.Yes;
            lblIdManutencao.Size = new Size(119, 18);
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
            btnSalvarManutencao.Location = new Point(568, 552);
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
            headerLabel2.Location = new Point(24, 424);
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
            cmbStatusManutencao.Location = new Point(24, 456);
            cmbStatusManutencao.Name = "cmbStatusManutencao";
            cmbStatusManutencao.Size = new Size(320, 26);
            cmbStatusManutencao.TabIndex = 11;
            // 
            // dtpManutencao
            // 
            dtpManutencao.Location = new Point(568, 456);
            dtpManutencao.Name = "dtpManutencao";
            dtpManutencao.Size = new Size(328, 27);
            dtpManutencao.TabIndex = 12;
            // 
            // txtIdManutencao
            // 
            txtIdManutencao.AutoSize = true;
            txtIdManutencao.BackColor = Color.Transparent;
            txtIdManutencao.Font = new Font("Microsoft Sans Serif", 30F, FontStyle.Bold);
            txtIdManutencao.ForeColor = Color.FromArgb(255, 255, 255);
            txtIdManutencao.Location = new Point(432, 400);
            txtIdManutencao.Name = "txtIdManutencao";
            txtIdManutencao.Size = new Size(43, 46);
            txtIdManutencao.TabIndex = 13;
            txtIdManutencao.Text = "0";
            // 
            // btnVoltarManutencao
            // 
            btnVoltarManutencao.BorderColor = Color.FromArgb(220, 223, 230);
            btnVoltarManutencao.ButtonType = ReaLTaiizor.Util.HopeButtonType.Primary;
            btnVoltarManutencao.DangerColor = Color.FromArgb(245, 108, 108);
            btnVoltarManutencao.DefaultColor = Color.FromArgb(255, 255, 255);
            btnVoltarManutencao.Font = new Font("Segoe UI", 12F);
            btnVoltarManutencao.HoverTextColor = Color.FromArgb(48, 49, 51);
            btnVoltarManutencao.InfoColor = Color.FromArgb(144, 147, 153);
            btnVoltarManutencao.Location = new Point(24, 552);
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
            // ManutencaoForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(914, 600);
            Controls.Add(btnVoltarManutencao);
            Controls.Add(txtIdManutencao);
            Controls.Add(dtpManutencao);
            Controls.Add(cmbStatusManutencao);
            Controls.Add(headerLabel2);
            Controls.Add(btnSalvarManutencao);
            Controls.Add(lblIdManutencao);
            Controls.Add(headerLabel1);
            Controls.Add(foxBigLabel1);
            Controls.Add(dgvManutencao);
            Margin = new Padding(3, 5, 3, 5);
            MinimumSize = new Size(518, 503);
            Name = "ManutencaoForm";
            Text = "ManutencaoForm";
            Load += ManutencaoForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvManutencao).EndInit();
            ResumeLayout(false);
            PerformLayout();
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
    }
}