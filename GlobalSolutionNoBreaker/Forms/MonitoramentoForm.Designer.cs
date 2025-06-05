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
            foxBigLabel1 = new ReaLTaiizor.Controls.FoxBigLabel();
            SuspendLayout();
            // 
            // foxBigLabel1
            // 
            foxBigLabel1.BackColor = Color.Transparent;
            foxBigLabel1.Font = new Font("Segoe UI Semibold", 20F);
            foxBigLabel1.ForeColor = Color.FromArgb(76, 88, 100);
            foxBigLabel1.Line = ReaLTaiizor.Controls.FoxBigLabel.Direction.Bottom;
            foxBigLabel1.LineColor = Color.FromArgb(200, 200, 200);
            foxBigLabel1.Location = new Point(16, 16);
            foxBigLabel1.Name = "foxBigLabel1";
            foxBigLabel1.Size = new Size(344, 40);
            foxBigLabel1.TabIndex = 0;
            foxBigLabel1.Text = "Central de Monitoramento";
            // 
            // MonitoramentoForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(foxBigLabel1);
            Name = "MonitoramentoForm";
            Text = "MonitoramentoForm";
            ResumeLayout(false);
        }

        #endregion

        private ReaLTaiizor.Controls.FoxBigLabel foxBigLabel1;
    }
}