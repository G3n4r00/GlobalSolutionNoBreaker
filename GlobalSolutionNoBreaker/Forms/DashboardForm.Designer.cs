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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            panAtivos = new Panel();
            panel1 = new Panel();
            panel2 = new Panel();
            lblTituloTroca = new Label();
            dgvNobreaksTroca = new DataGridView();
            lblTituloIncidentesRecentes = new Label();
            dgvAlertasRecentes = new DataGridView();
            panel3 = new Panel();
            chartStatus = new System.Windows.Forms.DataVisualization.Charting.Chart();
            headerLabel1 = new ReaLTaiizor.Controls.HeaderLabel();
            lblValorAtivos = new ReaLTaiizor.Controls.HeaderLabel();
            headerLabel2 = new ReaLTaiizor.Controls.HeaderLabel();
            lblValorIncidentes = new ReaLTaiizor.Controls.HeaderLabel();
            headerLabel3 = new ReaLTaiizor.Controls.HeaderLabel();
            lblValorCritico = new ReaLTaiizor.Controls.HeaderLabel();
            headerLabel4 = new ReaLTaiizor.Controls.HeaderLabel();
            lblValorManutencao = new ReaLTaiizor.Controls.HeaderLabel();
            smallLabel1 = new ReaLTaiizor.Controls.SmallLabel();
            panAtivos.SuspendLayout();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvNobreaksTroca).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvAlertasRecentes).BeginInit();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)chartStatus).BeginInit();
            SuspendLayout();
            // 
            // panAtivos
            // 
            panAtivos.BackColor = SystemColors.ControlDarkDark;
            panAtivos.Controls.Add(lblValorAtivos);
            panAtivos.Controls.Add(headerLabel1);
            panAtivos.Location = new Point(24, 40);
            panAtivos.Margin = new Padding(3, 4, 3, 4);
            panAtivos.Name = "panAtivos";
            panAtivos.Size = new Size(230, 180);
            panAtivos.TabIndex = 0;
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ControlDarkDark;
            panel1.Controls.Add(lblValorIncidentes);
            panel1.Controls.Add(headerLabel2);
            panel1.Location = new Point(280, 40);
            panel1.Margin = new Padding(3, 4, 3, 4);
            panel1.Name = "panel1";
            panel1.Size = new Size(230, 180);
            panel1.TabIndex = 1;
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.ControlDarkDark;
            panel2.Controls.Add(lblValorCritico);
            panel2.Controls.Add(headerLabel3);
            panel2.Location = new Point(544, 40);
            panel2.Margin = new Padding(3, 4, 3, 4);
            panel2.Name = "panel2";
            panel2.Size = new Size(232, 180);
            panel2.TabIndex = 2;
            // 
            // lblTituloTroca
            // 
            lblTituloTroca.AutoSize = true;
            lblTituloTroca.Location = new Point(24, 528);
            lblTituloTroca.Name = "lblTituloTroca";
            lblTituloTroca.Size = new Size(182, 20);
            lblTituloTroca.TabIndex = 3;
            lblTituloTroca.Text = "Proximos Troca de Bateria";
            // 
            // dgvNobreaksTroca
            // 
            dgvNobreaksTroca.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvNobreaksTroca.BackgroundColor = SystemColors.MenuText;
            dgvNobreaksTroca.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvNobreaksTroca.Location = new Point(24, 560);
            dgvNobreaksTroca.Margin = new Padding(3, 4, 3, 4);
            dgvNobreaksTroca.Name = "dgvNobreaksTroca";
            dgvNobreaksTroca.Size = new Size(1032, 96);
            dgvNobreaksTroca.TabIndex = 4;
            // 
            // lblTituloIncidentesRecentes
            // 
            lblTituloIncidentesRecentes.AutoSize = true;
            lblTituloIncidentesRecentes.Location = new Point(24, 664);
            lblTituloIncidentesRecentes.Name = "lblTituloIncidentesRecentes";
            lblTituloIncidentesRecentes.Size = new Size(204, 20);
            lblTituloIncidentesRecentes.TabIndex = 5;
            lblTituloIncidentesRecentes.Text = "Lista Incidentes mais recentes";
            // 
            // dgvAlertasRecentes
            // 
            dgvAlertasRecentes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvAlertasRecentes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAlertasRecentes.Location = new Point(24, 688);
            dgvAlertasRecentes.Margin = new Padding(3, 4, 3, 4);
            dgvAlertasRecentes.Name = "dgvAlertasRecentes";
            dgvAlertasRecentes.Size = new Size(1032, 144);
            dgvAlertasRecentes.TabIndex = 6;
            // 
            // panel3
            // 
            panel3.BackColor = SystemColors.ControlDarkDark;
            panel3.Controls.Add(smallLabel1);
            panel3.Controls.Add(lblValorManutencao);
            panel3.Controls.Add(headerLabel4);
            panel3.Location = new Point(816, 40);
            panel3.Margin = new Padding(3, 4, 3, 4);
            panel3.Name = "panel3";
            panel3.Size = new Size(232, 180);
            panel3.TabIndex = 7;
            panel3.Paint += panel3_Paint;
            // 
            // chartStatus
            // 
            chartArea4.AlignmentOrientation = System.Windows.Forms.DataVisualization.Charting.AreaAlignmentOrientations.Horizontal;
            chartArea4.Name = "ChartArea1";
            chartStatus.ChartAreas.Add(chartArea4);
            legend4.Name = "Legend1";
            chartStatus.Legends.Add(legend4);
            chartStatus.Location = new Point(24, 235);
            chartStatus.Margin = new Padding(3, 4, 3, 4);
            chartStatus.Name = "chartStatus";
            series4.ChartArea = "ChartArea1";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Bar;
            series4.Legend = "Legend1";
            series4.Name = "Series1";
            chartStatus.Series.Add(series4);
            chartStatus.Size = new Size(1024, 277);
            chartStatus.TabIndex = 8;
            chartStatus.Text = "chart1";
            // 
            // headerLabel1
            // 
            headerLabel1.AutoSize = true;
            headerLabel1.BackColor = Color.Transparent;
            headerLabel1.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            headerLabel1.ForeColor = Color.FromArgb(255, 255, 255);
            headerLabel1.Location = new Point(48, 32);
            headerLabel1.Name = "headerLabel1";
            headerLabel1.Size = new Size(139, 20);
            headerLabel1.TabIndex = 2;
            headerLabel1.Text = "Nobreaks Ativos";
            // 
            // lblValorAtivos
            // 
            lblValorAtivos.AutoSize = true;
            lblValorAtivos.BackColor = Color.Transparent;
            lblValorAtivos.Font = new Font("Microsoft Sans Serif", 24F, FontStyle.Bold);
            lblValorAtivos.ForeColor = Color.FromArgb(255, 255, 255);
            lblValorAtivos.Location = new Point(96, 96);
            lblValorAtivos.Name = "lblValorAtivos";
            lblValorAtivos.Size = new Size(36, 37);
            lblValorAtivos.TabIndex = 3;
            lblValorAtivos.Text = "0";
            // 
            // headerLabel2
            // 
            headerLabel2.AutoSize = true;
            headerLabel2.BackColor = Color.Transparent;
            headerLabel2.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            headerLabel2.ForeColor = Color.FromArgb(255, 255, 255);
            headerLabel2.Location = new Point(48, 32);
            headerLabel2.Name = "headerLabel2";
            headerLabel2.Size = new Size(135, 20);
            headerLabel2.TabIndex = 2;
            headerLabel2.Text = "Incidentes Hoje";
            // 
            // lblValorIncidentes
            // 
            lblValorIncidentes.AutoSize = true;
            lblValorIncidentes.BackColor = Color.Transparent;
            lblValorIncidentes.Font = new Font("Microsoft Sans Serif", 24F, FontStyle.Bold);
            lblValorIncidentes.ForeColor = Color.FromArgb(255, 255, 255);
            lblValorIncidentes.Location = new Point(96, 96);
            lblValorIncidentes.Name = "lblValorIncidentes";
            lblValorIncidentes.Size = new Size(36, 37);
            lblValorIncidentes.TabIndex = 3;
            lblValorIncidentes.Text = "0";
            // 
            // headerLabel3
            // 
            headerLabel3.AutoSize = true;
            headerLabel3.BackColor = Color.Transparent;
            headerLabel3.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            headerLabel3.ForeColor = Color.FromArgb(255, 255, 255);
            headerLabel3.Location = new Point(0, 32);
            headerLabel3.Name = "headerLabel3";
            headerLabel3.Size = new Size(232, 20);
            headerLabel3.TabIndex = 3;
            headerLabel3.Text = "Nobreaks em Estado Crítico";
            headerLabel3.Click += headerLabel3_Click;
            // 
            // lblValorCritico
            // 
            lblValorCritico.AutoSize = true;
            lblValorCritico.BackColor = Color.Transparent;
            lblValorCritico.Font = new Font("Microsoft Sans Serif", 24F, FontStyle.Bold);
            lblValorCritico.ForeColor = Color.FromArgb(255, 255, 255);
            lblValorCritico.Location = new Point(88, 96);
            lblValorCritico.Name = "lblValorCritico";
            lblValorCritico.Size = new Size(36, 37);
            lblValorCritico.TabIndex = 4;
            lblValorCritico.Text = "0";
            // 
            // headerLabel4
            // 
            headerLabel4.AutoSize = true;
            headerLabel4.BackColor = Color.Transparent;
            headerLabel4.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            headerLabel4.ForeColor = Color.FromArgb(255, 255, 255);
            headerLabel4.Location = new Point(0, 32);
            headerLabel4.Name = "headerLabel4";
            headerLabel4.Size = new Size(230, 20);
            headerLabel4.TabIndex = 4;
            headerLabel4.Text = "Nobreaks para Manutenção";
            // 
            // lblValorManutencao
            // 
            lblValorManutencao.AutoSize = true;
            lblValorManutencao.BackColor = Color.Transparent;
            lblValorManutencao.Font = new Font("Microsoft Sans Serif", 24F, FontStyle.Bold);
            lblValorManutencao.ForeColor = Color.FromArgb(255, 255, 255);
            lblValorManutencao.Location = new Point(88, 96);
            lblValorManutencao.Name = "lblValorManutencao";
            lblValorManutencao.Size = new Size(36, 37);
            lblValorManutencao.TabIndex = 5;
            lblValorManutencao.Text = "0";
            // 
            // smallLabel1
            // 
            smallLabel1.AutoSize = true;
            smallLabel1.BackColor = Color.Transparent;
            smallLabel1.Font = new Font("Segoe UI", 8F);
            smallLabel1.ForeColor = Color.White;
            smallLabel1.Location = new Point(64, 160);
            smallLabel1.Name = "smallLabel1";
            smallLabel1.Size = new Size(93, 13);
            smallLabel1.TabIndex = 6;
            smallLabel1.Text = "próximos 30 dias";
            // 
            // DashboardForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1079, 843);
            Controls.Add(chartStatus);
            Controls.Add(panel3);
            Controls.Add(dgvAlertasRecentes);
            Controls.Add(lblTituloIncidentesRecentes);
            Controls.Add(dgvNobreaksTroca);
            Controls.Add(lblTituloTroca);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(panAtivos);
            Margin = new Padding(3, 5, 3, 5);
            MinimumSize = new Size(518, 503);
            Name = "DashboardForm";
            Text = "DashboardForm";
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
            ResumeLayout(false);
            PerformLayout();
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
    }
}