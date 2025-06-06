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
    /// <summary>
    /// Formulário responsável pelo monitoramento dos nobreaks em tempo real.
    /// </summary>
    public partial class MonitoramentoForm : BaseForm
    {
        /// <summary>
        /// Inicializa uma nova instância do formulário de monitoramento.
        /// </summary>
        /// <param name="connectionString">String de conexão com o banco de dados.</param>
        public MonitoramentoForm(string connectionString)
        {
            repository = new MonitoramentoRepository(connectionString);
            InitializeComponent();
            InitializeTimer();
            LoadInitialData();
        }

        #region Fields

        /// <summary>
        /// Repositório utilizado para acesso aos dados de monitoramento.
        /// </summary>
        private readonly MonitoramentoRepository repository;

        /// <summary>
        /// Temporizador responsável pela geração periódica de leituras.
        /// </summary>
        private System.Windows.Forms.Timer monitoringTimer;

        /// <summary>
        /// Indica se o monitoramento está ativo.
        /// </summary>
        private bool isMonitoring = false;

        #endregion

        #region Timer Initialization

        /// <summary>
        /// Inicializa o temporizador com intervalo de 20 segundos.
        /// </summary>
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

        /// <summary>
        /// Evento chamado a cada intervalo do temporizador para gerar novas leituras.
        /// </summary>
        private async void MonitoringTimer_Tick(object sender, EventArgs e)
        {
            await GenerateRandomReadingsAsync();
        }

        #endregion

        #region Monitoring Control

        /// <summary>
        /// Inicia o processo de monitoramento, se houver nobreaks ativos.
        /// </summary>
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

            // Gera a primeira leitura imediatamente
            Task.Run(async () => await GenerateRandomReadingsAsync());
        }

        /// <summary>
        /// Encerra o processo de monitoramento.
        /// </summary>
        private void StopMonitoring()
        {
            isMonitoring = false;
            monitoringTimer.Stop();

            UpdateUIForMonitoringState(false);
        }

        /// <summary>
        /// Atualiza os elementos visuais com base no estado atual do monitoramento.
        /// </summary>
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

        /// <summary>
        /// Gera leituras aleatórias para todos os nobreaks ativos e atualiza a interface.
        /// </summary>
        private async Task GenerateRandomReadingsAsync()
        {
            try
            {
                await Task.Run(() => repository.GenerateRandomReadingsForAllActive());

                // Atualiza a interface na thread principal
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

        /// <summary>
        /// Carrega os dados e estatísticas iniciais do monitoramento.
        /// </summary>
        private void LoadInitialData()
        {
            LoadMonitoringData();
            UpdateStatsDisplay();
        }

        /// <summary>
        /// Recupera os dados de monitoramento do repositório e os exibe na grade.
        /// </summary>
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

        /// <summary>
        /// Atualiza a exibição das estatísticas gerais dos nobreaks.
        /// </summary>
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

        /// <summary>
        /// Configura as colunas da grade de monitoramento.
        /// </summary>
        private void ConfigureGridColumns()
        {
            if (dgvMonitoramento.Columns.Count == 0) return;

            // Primeiro, define AutoSizeMode.None para todas as colunas
            foreach (DataGridViewColumn col in dgvMonitoramento.Columns)
            {
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            }

            // Configura os nomes e larguras das colunas
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

        /// <summary>
        /// Aplica a coloração nas linhas da grade com base no código de estado.
        /// </summary>
        private void ApplyRowStatusColor(DataGridViewRow row, int codigoEstado)
        {
            var colorScheme = GetStatusColorScheme(codigoEstado);
            row.DefaultCellStyle.BackColor = colorScheme.BackColor;
            row.DefaultCellStyle.ForeColor = colorScheme.ForeColor;
            row.DefaultCellStyle.SelectionBackColor = colorScheme.SelectionBackColor;
        }

        /// <summary>
        /// Retorna o esquema de cores de acordo com o estado do nobreak.
        /// </summary>
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

        /// <summary>
        /// Libera os recursos utilizados pelo formulário.
        /// </summary>
        /// <param name="disposing">Indica se deve liberar os recursos gerenciados.</param>
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

        /// <summary>
        /// Evento de clique no botão de iniciar/parar monitoramento.
        /// </summary>
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

        /// <summary>
        /// Evento que formata as células da grade com base no estado do nobreak.
        /// </summary>
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
