namespace GlobalSolutionNoBreaker.Forms
{
    partial class MonitoramentoForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing && (components != null))
        //    {
        //        components.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panelTop = new Panel();
            lblStatus = new ReaLTaiizor.Controls.HeaderLabel();
            btnStartStop = new ReaLTaiizor.Controls.HopeRoundButton();
            panelStats = new Panel();
            headerLabel1 = new ReaLTaiizor.Controls.HeaderLabel();
            dgvMonitoramento = new DataGridView();
            panelTop.SuspendLayout();
            panelStats.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMonitoramento).BeginInit();
            SuspendLayout();
            // 
            // panelTop
            // 
            panelTop.BackColor = SystemColors.MenuHighlight;
            panelTop.Controls.Add(lblStatus);
            panelTop.Controls.Add(btnStartStop);
            panelTop.Dock = DockStyle.Top;
            panelTop.Location = new Point(0, 0);
            panelTop.Name = "panelTop";
            panelTop.Padding = new Padding(10);
            panelTop.Size = new Size(914, 60);
            panelTop.TabIndex = 0;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.BackColor = Color.Transparent;
            lblStatus.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold);
            lblStatus.ForeColor = Color.FromArgb(255, 255, 255);
            lblStatus.Location = new Point(256, 24);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(101, 15);
            lblStatus.TabIndex = 1;
            lblStatus.Text = "Status: Parado";
            // 
            // btnStartStop
            // 
            btnStartStop.BorderColor = Color.FromArgb(220, 223, 230);
            btnStartStop.ButtonType = ReaLTaiizor.Util.HopeButtonType.Success;
            btnStartStop.DangerColor = Color.FromArgb(245, 108, 108);
            btnStartStop.DefaultColor = Color.FromArgb(255, 255, 255);
            btnStartStop.Font = new Font("Segoe UI", 12F);
            btnStartStop.HoverTextColor = Color.FromArgb(48, 49, 51);
            btnStartStop.InfoColor = Color.FromArgb(144, 147, 153);
            btnStartStop.Location = new Point(16, 16);
            btnStartStop.Name = "btnStartStop";
            btnStartStop.PrimaryColor = Color.FromArgb(64, 158, 255);
            btnStartStop.Size = new Size(216, 35);
            btnStartStop.SuccessColor = Color.FromArgb(103, 194, 58);
            btnStartStop.TabIndex = 0;
            btnStartStop.Text = "Iniciar Monitoramento";
            btnStartStop.TextColor = Color.White;
            btnStartStop.WarningColor = Color.FromArgb(230, 162, 60);
            btnStartStop.Click += btnStartStop_Click;
            // 
            // panelStats
            // 
            panelStats.BackColor = SystemColors.Highlight;
            panelStats.Controls.Add(headerLabel1);
            panelStats.Dock = DockStyle.Top;
            panelStats.Location = new Point(0, 60);
            panelStats.Name = "panelStats";
            panelStats.Padding = new Padding(10, 5, 10, 5);
            panelStats.Size = new Size(914, 40);
            panelStats.TabIndex = 1;
            // 
            // headerLabel1
            // 
            headerLabel1.AutoSize = true;
            headerLabel1.BackColor = Color.Transparent;
            headerLabel1.Dock = DockStyle.Fill;
            headerLabel1.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold);
            headerLabel1.ForeColor = Color.FromArgb(255, 255, 255);
            headerLabel1.Location = new Point(10, 5);
            headerLabel1.Name = "headerLabel1";
            headerLabel1.Size = new Size(171, 15);
            headerLabel1.TabIndex = 0;
            headerLabel1.Text = "Carregando Estatísticas...";
            // 
            // dgvMonitoramento
            // 
            dgvMonitoramento.AllowUserToAddRows = false;
            dgvMonitoramento.AllowUserToDeleteRows = false;
            dgvMonitoramento.AllowUserToResizeRows = false;
            dgvMonitoramento.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvMonitoramento.BorderStyle = BorderStyle.None;
            dgvMonitoramento.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvMonitoramento.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMonitoramento.Dock = DockStyle.Fill;
            dgvMonitoramento.EnableHeadersVisualStyles = false;
            dgvMonitoramento.Location = new Point(0, 100);
            dgvMonitoramento.MultiSelect = false;
            dgvMonitoramento.Name = "dgvMonitoramento";
            dgvMonitoramento.ReadOnly = true;
            dgvMonitoramento.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvMonitoramento.Size = new Size(914, 461);
            dgvMonitoramento.TabIndex = 2;
            dgvMonitoramento.CellFormatting += dgvMonitoramento_CellFormatting;
            // 
            // MonitoramentoForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(914, 561);
            ControlBox = false;
            Controls.Add(dgvMonitoramento);
            Controls.Add(panelStats);
            Controls.Add(panelTop);
            Name = "MonitoramentoForm";
            Text = "Monitormaneto Em Tempo Real";
            panelTop.ResumeLayout(false);
            panelTop.PerformLayout();
            panelStats.ResumeLayout(false);
            panelStats.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMonitoramento).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelTop;
        private ReaLTaiizor.Controls.HeaderLabel lblStatus;
        private ReaLTaiizor.Controls.HopeRoundButton btnStartStop;
        private Panel panelStats;
        private ReaLTaiizor.Controls.HeaderLabel headerLabel1;
        private DataGridView dgvMonitoramento;
    }
}