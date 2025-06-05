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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            panAtivos = new Panel();
            lblValorAtivos = new Label();
            lblTituloAtivos = new Label();
            panel1 = new Panel();
            lblValorIncidentes = new Label();
            lblTituloIncidentes = new Label();
            panel2 = new Panel();
            lblValorCritico = new Label();
            lblTituloCritico = new Label();
            lblTituloTroca = new Label();
            dgvNobreaksTroca = new DataGridView();
            lblTituloIncidentesRecentes = new Label();
            dgvAlertasRecentes = new DataGridView();
            panel3 = new Panel();
            lblValorManutencao = new Label();
            label2 = new Label();
            chartStatus = new System.Windows.Forms.DataVisualization.Charting.Chart();
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
            panAtivos.Controls.Add(lblTituloAtivos);
            panAtivos.Location = new Point(24, 40);
            panAtivos.Margin = new Padding(3, 4, 3, 4);
            panAtivos.Name = "panAtivos";
            panAtivos.Size = new Size(230, 180);
            panAtivos.TabIndex = 0;
            // 
            // lblValorAtivos
            // 
            lblValorAtivos.AutoSize = true;
            lblValorAtivos.Location = new Point(64, 88);
            lblValorAtivos.Name = "lblValorAtivos";
            lblValorAtivos.Size = new Size(17, 20);
            lblValorAtivos.TabIndex = 1;
            lblValorAtivos.Text = "0";
            // 
            // lblTituloAtivos
            // 
            lblTituloAtivos.AutoSize = true;
            lblTituloAtivos.Location = new Point(40, 32);
            lblTituloAtivos.Name = "lblTituloAtivos";
            lblTituloAtivos.Size = new Size(92, 20);
            lblTituloAtivos.TabIndex = 0;
            lblTituloAtivos.Text = "Titulo Ativos";
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ControlDarkDark;
            panel1.Controls.Add(lblValorIncidentes);
            panel1.Controls.Add(lblTituloIncidentes);
            panel1.Location = new Point(280, 40);
            panel1.Margin = new Padding(3, 4, 3, 4);
            panel1.Name = "panel1";
            panel1.Size = new Size(230, 180);
            panel1.TabIndex = 1;
            // 
            // lblValorIncidentes
            // 
            lblValorIncidentes.AutoSize = true;
            lblValorIncidentes.Location = new Point(80, 88);
            lblValorIncidentes.Name = "lblValorIncidentes";
            lblValorIncidentes.Size = new Size(17, 20);
            lblValorIncidentes.TabIndex = 1;
            lblValorIncidentes.Text = "0";
            // 
            // lblTituloIncidentes
            // 
            lblTituloIncidentes.AutoSize = true;
            lblTituloIncidentes.Location = new Point(32, 32);
            lblTituloIncidentes.Name = "lblTituloIncidentes";
            lblTituloIncidentes.Size = new Size(118, 20);
            lblTituloIncidentes.TabIndex = 0;
            lblTituloIncidentes.Text = "Titulo Incidentes";
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.ControlDarkDark;
            panel2.Controls.Add(lblValorCritico);
            panel2.Controls.Add(lblTituloCritico);
            panel2.Location = new Point(544, 40);
            panel2.Margin = new Padding(3, 4, 3, 4);
            panel2.Name = "panel2";
            panel2.Size = new Size(230, 180);
            panel2.TabIndex = 2;
            // 
            // lblValorCritico
            // 
            lblValorCritico.AutoSize = true;
            lblValorCritico.Location = new Point(64, 75);
            lblValorCritico.Name = "lblValorCritico";
            lblValorCritico.Size = new Size(17, 20);
            lblValorCritico.TabIndex = 1;
            lblValorCritico.Text = "0";
            // 
            // lblTituloCritico
            // 
            lblTituloCritico.AutoSize = true;
            lblTituloCritico.Location = new Point(55, 32);
            lblTituloCritico.Name = "lblTituloCritico";
            lblTituloCritico.Size = new Size(143, 20);
            lblTituloCritico.TabIndex = 0;
            lblTituloCritico.Text = "Titulo Estado Critico";
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
            panel3.Controls.Add(lblValorManutencao);
            panel3.Controls.Add(label2);
            panel3.Location = new Point(816, 40);
            panel3.Margin = new Padding(3, 4, 3, 4);
            panel3.Name = "panel3";
            panel3.Size = new Size(230, 180);
            panel3.TabIndex = 7;
            panel3.Paint += panel3_Paint;
            // 
            // lblValorManutencao
            // 
            lblValorManutencao.AutoSize = true;
            lblValorManutencao.Location = new Point(64, 75);
            lblValorManutencao.Name = "lblValorManutencao";
            lblValorManutencao.Size = new Size(17, 20);
            lblValorManutencao.TabIndex = 1;
            lblValorManutencao.Text = "0";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(55, 32);
            label2.Name = "label2";
            label2.Size = new Size(192, 20);
            label2.TabIndex = 0;
            label2.Text = "Titulo Quantos Manutencao";
            // 
            // chartStatus
            // 
            chartArea1.AlignmentOrientation = System.Windows.Forms.DataVisualization.Charting.AreaAlignmentOrientations.Horizontal;
            chartArea1.Name = "ChartArea1";
            chartStatus.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            chartStatus.Legends.Add(legend1);
            chartStatus.Location = new Point(24, 235);
            chartStatus.Margin = new Padding(3, 4, 3, 4);
            chartStatus.Name = "chartStatus";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Bar;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            chartStatus.Series.Add(series1);
            chartStatus.Size = new Size(1024, 277);
            chartStatus.TabIndex = 8;
            chartStatus.Text = "chart1";
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
        private Label lblValorAtivos;
        private Label lblTituloAtivos;
        private Panel panel1;
        private Label lblValorIncidentes;
        private Label lblTituloIncidentes;
        private Panel panel2;
        private Label lblValorCritico;
        private Label lblTituloCritico;
        private Label lblTituloTroca;
        private DataGridView dgvNobreaksTroca;
        private Label lblTituloIncidentesRecentes;
        private DataGridView dgvAlertasRecentes;
        private Panel panel3;
        private Label lblValorManutencao;
        private Label label2;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartStatus;
    }
}