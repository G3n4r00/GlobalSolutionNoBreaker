using GlobalSolutionNoBreaker.Data;
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
    public partial class NobreakForm : Form
    {
        public NobreakForm()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            try
            {
                // Pega o valor selecionado do ComboBox Modelo (assumindo que a propriedade ValueMember está configurada para string do modelo)
                string modelo = cmbModelo.SelectedItem?.ToString();
                if (string.IsNullOrEmpty(modelo))
                {
                    MessageBox.Show("Selecione um modelo.");
                    return;
                }

                // Pega o valor selecionado do ComboBox Localização
                string localizacao = cmbLocal.SelectedItem?.ToString();
                if (string.IsNullOrEmpty(localizacao))
                {
                    MessageBox.Show("Selecione a localização.");
                    return;
                }

                // Capacidade VA continua vindo de TextBox, validação igual
                if (!int.TryParse(txtCapacidade.Text, out int capacidadeVA) || capacidadeVA <= 0)
                {
                    MessageBox.Show("Informe uma capacidade válida (>0).");
                    return;
                }

                // Data de aquisição pelo DateTimePicker, que sempre retorna uma data válida
                DateTime dataAquisicao = dtpAquisicao.Value.Date;
                if (dataAquisicao > DateTime.Today)
                {
                    MessageBox.Show("A data de aquisição não pode ser no futuro.");
                    return;
                }

                // Vida útil em anos (TextBox com validação)
                if (!int.TryParse(txtVida.Text, out int vidaUtil) || vidaUtil <= 0)
                {
                    MessageBox.Show("Informe uma vida útil válida (>0).");
                    return;
                }

                int cicloCargaInicial = 0;
                if (!string.IsNullOrWhiteSpace(txtCiclo.Text))
                {
                    if (!int.TryParse(txtCiclo.Text, out cicloCargaInicial) || cicloCargaInicial < 0)
                    {
                        MessageBox.Show("Informe um ciclo de carga inicial válido (≥0).");
                        return;
                    }
                }

                NobreakRepository.InsertNobreak(modelo, localizacao, capacidadeVA, dataAquisicao, vidaUtil, cicloCargaInicial);

                MessageBox.Show("Nobreak inserido com sucesso!");
                LoadNobreaksToGrid();

                // Limpa campos para novo cadastro
                cmbModelo.SelectedIndex = -1;
                cmbLocal.SelectedIndex = -1;
                txtCapacidade.Clear();
                dtpAquisicao.Value = DateTime.Today;
                txtVida.Clear();
                txtCiclo.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao inserir nobreak: {ex.Message}");
            }

        }

        private void LoadNobreaksToGrid()
        {
            try
            {
                DataTable dt = NobreakRepository.GetAllNobreaks();
                dgvNobreak.DataSource = dt;
                
                // Configuração opcional para renomear colunas na interface
                dgvNobreak.Columns["Id"].HeaderText = "ID";
                dgvNobreak.Columns["Modelo"].HeaderText = "Modelo";
                dgvNobreak.Columns["Localizacao"].HeaderText = "Localização";
                dgvNobreak.Columns["CapacidadeVA"].HeaderText = "Capacidade (VA)";
                dgvNobreak.Columns["DataAquisicao"].HeaderText = "Data de Aquisição";
                dgvNobreak.Columns["VidaUtilAnos"].HeaderText = "Vida Útil (anos)";
                dgvNobreak.Columns["CicloCargaInicial"].HeaderText = "Ciclo Inicial";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar nobreaks: " + ex.Message);
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {

        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            txtCapacidade.Clear();   
            txtCiclo.Clear();
            txtVida.Clear(); 
            cmbModelo.SelectedIndex = -1;   
            cmbLocal.SelectedIndex = -1;
            dtpAquisicao.Value = DateTime.Today;
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {

        }

        private void dgvNobreak_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void NobreakForm_Load(object sender, EventArgs e)
        {
            var data = NobreakRepository.GetAllNobreaks();
            dgvNobreak.DataSource = data;
            cmbModelo.Items.AddRange(new string[] { "Modelo A", "Modelo B", "Modelo C" });
            cmbLocal.Items.AddRange(new string[] { "Sala 1", "Sala 2", "Sala 3" });

            dtpAquisicao.MaxDate = DateTime.Today;
        }
    }
}
