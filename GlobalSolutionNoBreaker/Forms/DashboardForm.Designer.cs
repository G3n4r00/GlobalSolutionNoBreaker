namespace GlobalSolutionNoBreaker.Forms
{
    partial class DashboardForm
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            panAtivos = new Panel();
            lblValorAtivos = new ReaLTaiizor.Controls.HeaderLabel();
            headerLabel1 = new ReaLTaiizor.Controls.HeaderLabel();
            panel1 = new Panel();
            lblValorIncidentes = new ReaLTaiizor.Controls.HeaderLabel();
            headerLabel2 = new ReaLTaiizor.Controls.HeaderLabel();
            panel2 = new Panel();
            lblValorCritico = new ReaLTaiizor.Controls.HeaderLabel();
            headerLabel3 = new ReaLTaiizor.Controls.HeaderLabel();
            lblTituloTroca = new Label();
            dgvNobreaksTroca = new DataGridView();
            lblTituloIncidentesRecentes = new Label();
            dgvAlertasRecentes = new DataGridView();
            panel3 = new Panel();
            smallLabel1 = new ReaLTaiizor.Controls.SmallLabel();
            lblValorManutencao = new ReaLTaiizor.Controls.HeaderLabel();
            headerLabel4 = new ReaLTaiizor.Controls.HeaderLabel();
            chartStatus = new System.Windows.Forms.DataVisualization.Charting.Chart();
            foxBigLabel1 = new ReaLTaiizor.Controls.FoxBigLabel();
            btnVoltarDashboard = new ReaLTaiizor.Controls.HopeRoundButton();
            panelTop = new Panel();
            panelCardsTop = new Panel();
            panelBotTitle1 = new Panel();
            pannelBottomTitulo0 = new Panel();
            panAtivos.SuspendLayout();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvNobreaksTroca).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvAlertasRecentes).BeginInit();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)chartStatus).BeginInit();
            panelTop.SuspendLayout();
            panelCardsTop.SuspendLayout();
            panelBotTitle1.SuspendLayout();
            pannelBottomTitulo0.SuspendLayout();
            SuspendLayout();
            // 
            // panAtivos
            // 
            panAtivos.BackColor = SystemColors.ControlDarkDark;
            panAtivos.Controls.Add(lblValorAtivos);
            panAtivos.Controls.Add(headerLabel1);
            panAtivos.Location = new Point(40, 8);
            panAtivos.Margin = new Padding(3, 4, 3, 4);
            panAtivos.Name = "panAtivos";
            panAtivos.Size = new Size(128, 120);
            panAtivos.TabIndex = 0;
            // 
            // lblValorAtivos
            // 
            lblValorAtivos.AutoSize = true;
            lblValorAtivos.BackColor = Color.Transparent;
            lblValorAtivos.Font = new Font("Microsoft Sans Serif", 24F, FontStyle.Bold);
            lblValorAtivos.ForeColor = Color.FromArgb(255, 255, 255);
            lblValorAtivos.Location = new Point(48, 56);
            lblValorAtivos.Name = "lblValorAtivos";
            lblValorAtivos.Size = new Size(36, 37);
            lblValorAtivos.TabIndex = 3;
            lblValorAtivos.Text = "0";
            // 
            // headerLabel1
            // 
            headerLabel1.AutoSize = true;
            headerLabel1.BackColor = Color.Transparent;
            headerLabel1.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold);
            headerLabel1.ForeColor = Color.FromArgb(255, 255, 255);
            headerLabel1.Location = new Point(8, 16);
            headerLabel1.Name = "headerLabel1";
            headerLabel1.Size = new Size(109, 15);
            headerLabel1.TabIndex = 2;
            headerLabel1.Text = "Nobreaks Ativos";
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ControlDarkDark;
            panel1.Controls.Add(lblValorIncidentes);
            panel1.Controls.Add(headerLabel2);
            panel1.Location = new Point(520, 8);
            panel1.Margin = new Padding(3, 4, 3, 4);
            panel1.Name = "panel1";
            panel1.Size = new Size(128, 120);
            panel1.TabIndex = 1;
            // 
            // lblValorIncidentes
            // 
            lblValorIncidentes.AutoSize = true;
            lblValorIncidentes.BackColor = Color.Transparent;
            lblValorIncidentes.Font = new Font("Microsoft Sans Serif", 24F, FontStyle.Bold);
            lblValorIncidentes.ForeColor = Color.FromArgb(255, 255, 255);
            lblValorIncidentes.Location = new Point(48, 56);
            lblValorIncidentes.Name = "lblValorIncidentes";
            lblValorIncidentes.Size = new Size(36, 37);
            lblValorIncidentes.TabIndex = 3;
            lblValorIncidentes.Text = "0";
            // 
            // headerLabel2
            // 
            headerLabel2.AutoSize = true;
            headerLabel2.BackColor = Color.Transparent;
            headerLabel2.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold);
            headerLabel2.ForeColor = Color.FromArgb(255, 255, 255);
            headerLabel2.Location = new Point(8, 24);
            headerLabel2.Name = "headerLabel2";
            headerLabel2.Size = new Size(107, 15);
            headerLabel2.TabIndex = 2;
            headerLabel2.Text = "Incidentes Hoje";
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.ControlDarkDark;
            panel2.Controls.Add(lblValorCritico);
            panel2.Controls.Add(headerLabel3);
            panel2.Location = new Point(240, 8);
            panel2.Margin = new Padding(3, 4, 3, 4);
            panel2.Name = "panel2";
            panel2.Size = new Size(208, 120);
            panel2.TabIndex = 2;
            // 
            // lblValorCritico
            // 
            lblValorCritico.AutoSize = true;
            lblValorCritico.BackColor = Color.Transparent;
            lblValorCritico.Font = new Font("Microsoft Sans Serif", 24F, FontStyle.Bold);
            lblValorCritico.ForeColor = Color.FromArgb(255, 255, 255);
            lblValorCritico.Location = new Point(80, 48);
            lblValorCritico.Name = "lblValorCritico";
            lblValorCritico.Size = new Size(36, 37);
            lblValorCritico.TabIndex = 4;
            lblValorCritico.Text = "0";
            // 
            // headerLabel3
            // 
            headerLabel3.AutoSize = true;
            headerLabel3.BackColor = Color.Transparent;
            headerLabel3.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold);
            headerLabel3.ForeColor = Color.FromArgb(255, 255, 255);
            headerLabel3.Location = new Point(8, 16);
            headerLabel3.Name = "headerLabel3";
            headerLabel3.Size = new Size(185, 15);
            headerLabel3.TabIndex = 3;
            headerLabel3.Text = "Nobreaks em Estado Crítico";
            headerLabel3.Click += headerLabel3_Click;
            // 
            // lblTituloTroca
            // 
            lblTituloTroca.AutoSize = true;
            lblTituloTroca.Location = new Point(0, 8);
            lblTituloTroca.Name = "lblTituloTroca";
            lblTituloTroca.Size = new Size(182, 20);
            lblTituloTroca.TabIndex = 3;
            lblTituloTroca.Text = "Proximos Troca de Bateria";
            // 
            // dgvNobreaksTroca
            // 
            dgvNobreaksTroca.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvNobreaksTroca.BackgroundColor = SystemColors.Info;
            dgvNobreaksTroca.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvNobreaksTroca.Dock = DockStyle.Bottom;
            dgvNobreaksTroca.Location = new Point(0, 565);
            dgvNobreaksTroca.Margin = new Padding(3, 4, 3, 4);
            dgvNobreaksTroca.Name = "dgvNobreaksTroca";
            dgvNobreaksTroca.Size = new Size(984, 96);
            dgvNobreaksTroca.TabIndex = 4;
            // 
            // lblTituloIncidentesRecentes
            // 
            lblTituloIncidentesRecentes.AutoSize = true;
            lblTituloIncidentesRecentes.Location = new Point(8, 8);
            lblTituloIncidentesRecentes.Name = "lblTituloIncidentesRecentes";
            lblTituloIncidentesRecentes.Size = new Size(204, 20);
            lblTituloIncidentesRecentes.TabIndex = 5;
            lblTituloIncidentesRecentes.Text = "Lista Incidentes mais recentes";
            // 
            // dgvAlertasRecentes
            // 
            dgvAlertasRecentes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvAlertasRecentes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAlertasRecentes.Dock = DockStyle.Bottom;
            dgvAlertasRecentes.Location = new Point(0, 432);
            dgvAlertasRecentes.Margin = new Padding(3, 4, 3, 4);
            dgvAlertasRecentes.Name = "dgvAlertasRecentes";
            dgvAlertasRecentes.Size = new Size(984, 98);
            dgvAlertasRecentes.TabIndex = 6;
            // 
            // panel3
            // 
            panel3.BackColor = SystemColors.ControlDarkDark;
            panel3.Controls.Add(smallLabel1);
            panel3.Controls.Add(lblValorManutencao);
            panel3.Controls.Add(headerLabel4);
            panel3.Location = new Point(728, 8);
            panel3.Margin = new Padding(3, 4, 3, 4);
            panel3.Name = "panel3";
            panel3.Size = new Size(208, 120);
            panel3.TabIndex = 7;
            panel3.Paint += panel3_Paint;
            // 
            // smallLabel1
            // 
            smallLabel1.AutoSize = true;
            smallLabel1.BackColor = Color.Transparent;
            smallLabel1.Font = new Font("Segoe UI", 8F);
            smallLabel1.ForeColor = Color.White;
            smallLabel1.Location = new Point(64, 96);
            smallLabel1.Name = "smallLabel1";
            smallLabel1.Size = new Size(93, 13);
            smallLabel1.TabIndex = 6;
            smallLabel1.Text = "próximos 30 dias";
            // 
            // lblValorManutencao
            // 
            lblValorManutencao.AutoSize = true;
            lblValorManutencao.BackColor = Color.Transparent;
            lblValorManutencao.Font = new Font("Microsoft Sans Serif", 24F, FontStyle.Bold);
            lblValorManutencao.ForeColor = Color.FromArgb(255, 255, 255);
            lblValorManutencao.Location = new Point(88, 48);
            lblValorManutencao.Name = "lblValorManutencao";
            lblValorManutencao.Size = new Size(36, 37);
            lblValorManutencao.TabIndex = 5;
            lblValorManutencao.Text = "0";
            // 
            // headerLabel4
            // 
            headerLabel4.AutoSize = true;
            headerLabel4.BackColor = Color.Transparent;
            headerLabel4.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold);
            headerLabel4.ForeColor = Color.FromArgb(255, 255, 255);
            headerLabel4.Location = new Point(16, 16);
            headerLabel4.Name = "headerLabel4";
            headerLabel4.Size = new Size(184, 15);
            headerLabel4.TabIndex = 4;
            headerLabel4.Text = "Nobreaks para Manutenção";
            // 
            // chartStatus
            // 
            chartArea3.AlignmentOrientation = System.Windows.Forms.DataVisualization.Charting.AreaAlignmentOrientations.Horizontal;
            chartArea3.Name = "ChartArea1";
            chartStatus.ChartAreas.Add(chartArea3);
            chartStatus.Dock = DockStyle.Fill;
            legend3.Name = "Legend1";
            chartStatus.Legends.Add(legend3);
            chartStatus.Location = new Point(0, 192);
            chartStatus.Margin = new Padding(3, 4, 3, 4);
            chartStatus.Name = "chartStatus";
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Bar;
            series3.Legend = "Legend1";
            series3.Name = "Series1";
            chartStatus.Series.Add(series3);
            chartStatus.Size = new Size(984, 200);
            chartStatus.TabIndex = 8;
            chartStatus.Text = "chart1";
            // 
            // foxBigLabel1
            // 
            foxBigLabel1.BackColor = Color.Transparent;
            foxBigLabel1.Font = new Font("Segoe UI Semibold", 20F);
            foxBigLabel1.ForeColor = Color.White;
            foxBigLabel1.Line = ReaLTaiizor.Controls.FoxBigLabel.Direction.Bottom;
            foxBigLabel1.LineColor = Color.FromArgb(200, 200, 200);
            foxBigLabel1.Location = new Point(8, 8);
            foxBigLabel1.Name = "foxBigLabel1";
            foxBigLabel1.Size = new Size(224, 41);
            foxBigLabel1.TabIndex = 9;
            foxBigLabel1.Text = "Dashboard Geral";
            // 
            // btnVoltarDashboard
            // 
            btnVoltarDashboard.BorderColor = Color.FromArgb(220, 223, 230);
            btnVoltarDashboard.ButtonType = ReaLTaiizor.Util.HopeButtonType.Danger;
            btnVoltarDashboard.DangerColor = Color.FromArgb(245, 108, 108);
            btnVoltarDashboard.DefaultColor = Color.FromArgb(255, 255, 255);
            btnVoltarDashboard.Font = new Font("Segoe UI", 12F);
            btnVoltarDashboard.HoverTextColor = Color.FromArgb(48, 49, 51);
            btnVoltarDashboard.InfoColor = Color.FromArgb(144, 147, 153);
            btnVoltarDashboard.Location = new Point(872, 16);
            btnVoltarDashboard.Name = "btnVoltarDashboard";
            btnVoltarDashboard.PrimaryColor = Color.FromArgb(64, 158, 255);
            btnVoltarDashboard.Size = new Size(110, 24);
            btnVoltarDashboard.SuccessColor = Color.FromArgb(103, 194, 58);
            btnVoltarDashboard.TabIndex = 10;
            btnVoltarDashboard.Text = "Voltar";
            btnVoltarDashboard.TextColor = Color.White;
            btnVoltarDashboard.WarningColor = Color.FromArgb(230, 162, 60);
            btnVoltarDashboard.Click += btnVoltarDashboard_Click;
            // 
            // panelTop
            // 
            panelTop.BackColor = SystemColors.MenuHighlight;
            panelTop.Controls.Add(foxBigLabel1);
            panelTop.Controls.Add(btnVoltarDashboard);
            panelTop.Dock = DockStyle.Top;
            panelTop.Location = new Point(0, 0);
            panelTop.Name = "panelTop";
            panelTop.Size = new Size(984, 48);
            panelTop.TabIndex = 11;
            // 
            // panelCardsTop
            // 
            panelCardsTop.Controls.Add(panAtivos);
            panelCardsTop.Controls.Add(panel1);
            panelCardsTop.Controls.Add(panel2);
            panelCardsTop.Controls.Add(panel3);
            panelCardsTop.Dock = DockStyle.Top;
            panelCardsTop.Location = new Point(0, 48);
            panelCardsTop.Name = "panelCardsTop";
            panelCardsTop.Size = new Size(984, 144);
            panelCardsTop.TabIndex = 12;
            // 
            // panelBotTitle1
            // 
            panelBotTitle1.Controls.Add(lblTituloTroca);
            panelBotTitle1.Dock = DockStyle.Bottom;
            panelBotTitle1.Location = new Point(0, 530);
            panelBotTitle1.Name = "panelBotTitle1";
            panelBotTitle1.Size = new Size(984, 35);
            panelBotTitle1.TabIndex = 13;
            // 
            // pannelBottomTitulo0
            // 
            pannelBottomTitulo0.Controls.Add(lblTituloIncidentesRecentes);
            pannelBottomTitulo0.Dock = DockStyle.Bottom;
            pannelBottomTitulo0.Location = new Point(0, 392);
            pannelBottomTitulo0.Name = "pannelBottomTitulo0";
            pannelBottomTitulo0.Size = new Size(984, 40);
            pannelBottomTitulo0.TabIndex = 14;
            // 
            // DashboardForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(984, 661);
            ControlBox = false;
            Controls.Add(chartStatus);
            Controls.Add(pannelBottomTitulo0);
            Controls.Add(dgvAlertasRecentes);
            Controls.Add(panelBotTitle1);
            Controls.Add(dgvNobreaksTroca);
            Controls.Add(panelCardsTop);
            Controls.Add(panelTop);
            Margin = new Padding(3, 5, 3, 5);
            MinimumSize = new Size(518, 503);
            Name = "DashboardForm";
            Text = "Dashboard Geral";
            panAtivos.ResumeLayout(false);
            panAtivos.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvNobreaksTroca).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvAlertasRecentes).EndInit();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)chartStatus).EndInit();
            panelTop.ResumeLayout(false);
            panelCardsTop.ResumeLayout(false);
            panelBotTitle1.ResumeLayout(false);
            panelBotTitle1.PerformLayout();
            pannelBottomTitulo0.ResumeLayout(false);
            pannelBottomTitulo0.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panAtivos;
        private Panel panel1;
        private Panel panel2;
        private Label lblTituloTroca;
        private DataGridView dgvNobreaksTroca;
        private Label lblTituloIncidentesRecentes;
        private DataGridView dgvAlertasRecentes;
        private Panel panel3;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartStatus;
        private ReaLTaiizor.Controls.HeaderLabel lblValorAtivos;
        private ReaLTaiizor.Controls.HeaderLabel headerLabel1;
        private ReaLTaiizor.Controls.HeaderLabel headerLabel2;
        private ReaLTaiizor.Controls.HeaderLabel lblValorIncidentes;
        private ReaLTaiizor.Controls.HeaderLabel headerLabel3;
        private ReaLTaiizor.Controls.HeaderLabel lblValorCritico;
        private ReaLTaiizor.Controls.SmallLabel smallLabel1;
        private ReaLTaiizor.Controls.HeaderLabel lblValorManutencao;
        private ReaLTaiizor.Controls.HeaderLabel headerLabel4;
        private ReaLTaiizor.Controls.FoxBigLabel foxBigLabel1;
        private ReaLTaiizor.Controls.HopeRoundButton btnVoltarDashboard;
        private Panel panelTop;
        private Panel panelCardsTop;
        private Panel panelBotTitle1;
        private Panel pannelBottomTitulo0;
    }
}