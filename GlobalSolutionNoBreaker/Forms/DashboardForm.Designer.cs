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
            panAtivos.SuspendLayout();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvNobreaksTroca).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvAlertasRecentes).BeginInit();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // panAtivos
            // 
            panAtivos.BackColor = SystemColors.ControlDarkDark;
            panAtivos.Controls.Add(lblValorAtivos);
            panAtivos.Controls.Add(lblTituloAtivos);
            panAtivos.Location = new Point(24, 32);
            panAtivos.Name = "panAtivos";
            panAtivos.Size = new Size(144, 112);
            panAtivos.TabIndex = 0;
            // 
            // lblValorAtivos
            // 
            lblValorAtivos.AutoSize = true;
            lblValorAtivos.Location = new Point(56, 56);
            lblValorAtivos.Name = "lblValorAtivos";
            lblValorAtivos.Size = new Size(13, 15);
            lblValorAtivos.TabIndex = 1;
            lblValorAtivos.Text = "0";
            // 
            // lblTituloAtivos
            // 
            lblTituloAtivos.AutoSize = true;
            lblTituloAtivos.Location = new Point(48, 24);
            lblTituloAtivos.Name = "lblTituloAtivos";
            lblTituloAtivos.Size = new Size(74, 15);
            lblTituloAtivos.TabIndex = 0;
            lblTituloAtivos.Text = "Titulo Ativos";
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ControlDarkDark;
            panel1.Controls.Add(lblValorIncidentes);
            panel1.Controls.Add(lblTituloIncidentes);
            panel1.Location = new Point(192, 32);
            panel1.Name = "panel1";
            panel1.Size = new Size(160, 128);
            panel1.TabIndex = 1;
            // 
            // lblValorIncidentes
            // 
            lblValorIncidentes.AutoSize = true;
            lblValorIncidentes.Location = new Point(56, 56);
            lblValorIncidentes.Name = "lblValorIncidentes";
            lblValorIncidentes.Size = new Size(13, 15);
            lblValorIncidentes.TabIndex = 1;
            lblValorIncidentes.Text = "0";
            // 
            // lblTituloIncidentes
            // 
            lblTituloIncidentes.AutoSize = true;
            lblTituloIncidentes.Location = new Point(48, 24);
            lblTituloIncidentes.Name = "lblTituloIncidentes";
            lblTituloIncidentes.Size = new Size(95, 15);
            lblTituloIncidentes.TabIndex = 0;
            lblTituloIncidentes.Text = "Titulo Incidentes";
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.ControlDarkDark;
            panel2.Controls.Add(lblValorCritico);
            panel2.Controls.Add(lblTituloCritico);
            panel2.Location = new Point(368, 32);
            panel2.Name = "panel2";
            panel2.Size = new Size(176, 120);
            panel2.TabIndex = 2;
            // 
            // lblValorCritico
            // 
            lblValorCritico.AutoSize = true;
            lblValorCritico.Location = new Point(56, 56);
            lblValorCritico.Name = "lblValorCritico";
            lblValorCritico.Size = new Size(13, 15);
            lblValorCritico.TabIndex = 1;
            lblValorCritico.Text = "0";
            // 
            // lblTituloCritico
            // 
            lblTituloCritico.AutoSize = true;
            lblTituloCritico.Location = new Point(48, 24);
            lblTituloCritico.Name = "lblTituloCritico";
            lblTituloCritico.Size = new Size(114, 15);
            lblTituloCritico.TabIndex = 0;
            lblTituloCritico.Text = "Titulo Estado Critico";
            // 
            // lblTituloTroca
            // 
            lblTituloTroca.AutoSize = true;
            lblTituloTroca.Location = new Point(8, 416);
            lblTituloTroca.Name = "lblTituloTroca";
            lblTituloTroca.Size = new Size(143, 15);
            lblTituloTroca.TabIndex = 3;
            lblTituloTroca.Text = "Proximos Troca de Bateria";
            // 
            // dgvNobreaksTroca
            // 
            dgvNobreaksTroca.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvNobreaksTroca.Location = new Point(8, 448);
            dgvNobreaksTroca.Name = "dgvNobreaksTroca";
            dgvNobreaksTroca.Size = new Size(784, 64);
            dgvNobreaksTroca.TabIndex = 4;
            // 
            // lblTituloIncidentesRecentes
            // 
            lblTituloIncidentesRecentes.AutoSize = true;
            lblTituloIncidentesRecentes.Location = new Point(8, 520);
            lblTituloIncidentesRecentes.Name = "lblTituloIncidentesRecentes";
            lblTituloIncidentesRecentes.Size = new Size(163, 15);
            lblTituloIncidentesRecentes.TabIndex = 5;
            lblTituloIncidentesRecentes.Text = "Lista Incidentes mais recentes";
            // 
            // dgvAlertasRecentes
            // 
            dgvAlertasRecentes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvAlertasRecentes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAlertasRecentes.Location = new Point(8, 552);
            dgvAlertasRecentes.Name = "dgvAlertasRecentes";
            dgvAlertasRecentes.Size = new Size(784, 72);
            dgvAlertasRecentes.TabIndex = 6;
            // 
            // panel3
            // 
            panel3.BackColor = SystemColors.ControlDarkDark;
            panel3.Controls.Add(lblValorManutencao);
            panel3.Controls.Add(label2);
            panel3.Location = new Point(584, 32);
            panel3.Name = "panel3";
            panel3.Size = new Size(176, 120);
            panel3.TabIndex = 7;
            // 
            // lblValorManutencao
            // 
            lblValorManutencao.AutoSize = true;
            lblValorManutencao.Location = new Point(56, 56);
            lblValorManutencao.Name = "lblValorManutencao";
            lblValorManutencao.Size = new Size(13, 15);
            lblValorManutencao.TabIndex = 1;
            lblValorManutencao.Text = "0";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(48, 24);
            label2.Name = "label2";
            label2.Size = new Size(156, 15);
            label2.TabIndex = 0;
            label2.Text = "Titulo Quantos Manutencao";
            // 
            // DashboardForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(944, 632);
            Controls.Add(panel3);
            Controls.Add(dgvAlertasRecentes);
            Controls.Add(lblTituloIncidentesRecentes);
            Controls.Add(dgvNobreaksTroca);
            Controls.Add(lblTituloTroca);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(panAtivos);
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
    }
}