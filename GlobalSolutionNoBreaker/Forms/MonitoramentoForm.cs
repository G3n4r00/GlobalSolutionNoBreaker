using NobreakSystem.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GlobalSolutionNoBreaker.Forms
{
    public partial class MonitoramentoForm : BaseForm
    {
        public MonitoramentoForm(string connectionString)
        {
            repository = new MonitoramentoRepository(connectionString);
            InitializeComponent();
            InitializeTimer();
            LoadInitialData();
        }

        #region Fields
        private readonly MonitoramentoRepository repository;
        private System.Windows.Forms.Timer monitoringTimer;
        private bool isMonitoring = false;
        #endregion

        #region Timer Initialization
        private void InitializeTimer()
        {
            monitoringTimer = new System.Windows.Forms.Timer
            {
                Interval = 20000 // 20 segundos
            };
            monitoringTimer.Tick += MonitoringTimer_Tick;
        }
        #endregion

        #region Event Handlers

        private async void MonitoringTimer_Tick(object sender, EventArgs e)
        {
            await GenerateRandomReadingsAsync();
        }

        
        #endregion

        #region Monitoring Control
        private void StartMonitoring()
        {
            if (!repository.HasActiveNobreaks())
            {
                MessageBox.Show("Não há nobreaks ativos para monitorar.", "Aviso",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            isMonitoring = true;
            monitoringTimer.Start();

            UpdateUIForMonitoringState(true);

            // Gera primeira leitura imediatamente
            Task.Run(async () => await GenerateRandomReadingsAsync());
        }

        private void StopMonitoring()
        {
            isMonitoring = false;
            monitoringTimer.Stop();

            UpdateUIForMonitoringState(false);
        }

        private void UpdateUIForMonitoringState(bool isMonitoring)
        {
            if (isMonitoring)
            {
                btnStartStop.Text = "PARAR MONITORAMENTO";
                btnStartStop.ButtonType = ReaLTaiizor.Util.HopeButtonType.Danger;
                lblStatus.Text = "Status: Monitorando...";
                lblStatus.ForeColor = Color.FromArgb(46, 125, 50);
            }
            else
            {
                btnStartStop.Text = "INICIAR MONITORAMENTO";
                btnStartStop.ButtonType = ReaLTaiizor.Util.HopeButtonType.Success;
                lblStatus.Text = "Status: Parado";
                lblStatus.ForeColor = Color.FromArgb(84, 84, 84);
            }
        }
        #endregion

        #region Data Management
        private async Task GenerateRandomReadingsAsync()
        {
            try
            {
                await Task.Run(() => repository.GenerateRandomReadingsForAllActive());

                // Atualiza UI na thread principal
                if (this.InvokeRequired)
                {
                    this.Invoke(new Action(() =>
                    {
                        LoadMonitoringData();
                        UpdateStatsDisplay();
                    }));
                }
                else
                {
                    LoadMonitoringData();
                    UpdateStatsDisplay();
                }
            }
            catch (Exception ex)
            {
                this.Invoke(new Action(() =>
                {
                    MessageBox.Show($"Erro ao gerar leituras: {ex.Message}", "Erro",
                                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                }));
            }
        }

        private void LoadInitialData()
        {
            LoadMonitoringData();
            UpdateStatsDisplay();
        }

        private void LoadMonitoringData()
        {
            try
            {
                DataTable dataTable = repository.GetMonitoringData();
                dgvMonitoramento.DataSource = dataTable;
                ConfigureGridColumns();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar dados: {ex.Message}", "Erro",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateStatsDisplay()
        {
            try
            {
                var stats = repository.GetMonitoringStats();
                lblStatus.Text = $"Total: {stats.TotalNobreaks} | " +
                               $"Operacionais: {stats.Operacionais} | " +
                               $"Bateria Fraca: {stats.BateriaFraca} | " +
                               $"Sobrecarga: {stats.Sobrecarga} | " +
                               $"Desligados: {stats.Desligados}";
            }
            catch (Exception ex)
            {
                lblStatus.Text = $"Erro ao carregar estatísticas: {ex.Message}";
            }
        }
        #endregion

        #region UI Configuration
        private void ConfigureGridColumns()
        {
            if (dgvMonitoramento.Columns.Count == 0) return;

            // Primeiro, define AutoSizeMode.None para todas as colunas
            foreach (DataGridViewColumn col in dgvMonitoramento.Columns)
            {
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            }

            // Agora configura normalmente
            var columnConfig = new[]
            {
                new { Name = "Id", Header = "ID", Width = 80 },
                new { Name = "Modelo", Header = "Modelo", Width = 182 },
                new { Name = "Localizacao", Header = "Localização", Width = 170 },
                new { Name = "CargaAtual", Header = "Carga Atual (VA)", Width = 80 },
                new { Name = "PorcentagemBateria", Header = "% Bateria", Width = 80 },
                new { Name = "Status", Header = "Status", Width = 140 },
                new { Name = "UltimaLeitura", Header = "Última Leitura", Width = 140 }
            };

            foreach (var config in columnConfig)
            {
                if (dgvMonitoramento.Columns[config.Name] != null)
                {
                    dgvMonitoramento.Columns[config.Name].HeaderText = config.Header;
                    dgvMonitoramento.Columns[config.Name].Width = config.Width;
                }
            }

            // Oculta coluna auxiliar
            if (dgvMonitoramento.Columns["CodigoEstado"] != null)
                dgvMonitoramento.Columns["CodigoEstado"].Visible = false;
        }

        private void ApplyRowStatusColor(DataGridViewRow row, int codigoEstado)
        {
            var colorScheme = GetStatusColorScheme(codigoEstado);
            row.DefaultCellStyle.BackColor = colorScheme.BackColor;
            row.DefaultCellStyle.ForeColor = colorScheme.ForeColor;
            row.DefaultCellStyle.SelectionBackColor = colorScheme.SelectionBackColor;
        }

        private (Color BackColor, Color ForeColor, Color SelectionBackColor) GetStatusColorScheme(int codigoEstado)
        {
            return codigoEstado switch
            {
                0 => (Color.FromArgb(232, 245, 233), Color.FromArgb(27, 94, 32), Color.FromArgb(200, 230, 201)), // Operacional
                1 => (Color.FromArgb(255, 248, 225), Color.FromArgb(230, 81, 0), Color.FromArgb(255, 224, 178)), // Bateria Fraca
                2 or 3 => (Color.FromArgb(255, 235, 238), Color.FromArgb(198, 40, 40), Color.FromArgb(255, 205, 210)), // Sobrecarga/Desligado
                _ => (Color.White, Color.Black, Color.LightBlue) // Padrão
            };
        }
        #endregion

        #region Disposal
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                monitoringTimer?.Stop();
                monitoringTimer?.Dispose();
            }
            base.Dispose(disposing);
        }
        #endregion
    
        private void btnStartStop_Click(object sender, EventArgs e)
        {
            if (!isMonitoring)
            {
                StartMonitoring();
            }
            else
            {
                StopMonitoring();
            }
        }

        private void dgvMonitoramento_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvMonitoramento.Rows.Count)
            {
                var row = dgvMonitoramento.Rows[e.RowIndex];

                if (row.Cells["CodigoEstado"].Value != null)
                {
                    int codigoEstado = Convert.ToInt32(row.Cells["CodigoEstado"].Value);
                    ApplyRowStatusColor(row, codigoEstado);
                }
            }
        }
    }
}
