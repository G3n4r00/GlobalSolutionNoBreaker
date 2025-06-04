using GlobalSolutionNoBreaker.Models;
using GlobalSolutionNoBreaker.Repositories;
using GlobalSolutionNoBreaker.Services;
using System.Data;

namespace GlobalSolutionNoBreaker.Forms
{
    public partial class NobreakForm : Form
    {
        private int? _nobreakIdSelecionado = null; // null = novo, valor = edição

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
                var dto = new NobreakDTO
                {
                    //Id = _nobreakIdSelecionado,
                    Modelo = cmbModelo.SelectedItem?.ToString(),
                    Localizacao = cmbLocal.SelectedItem?.ToString(),
                    CapacidadeVA = txtCapacidade.Text,
                    DataAquisicao = dtpAquisicao.Value.Date,
                    VidaUtil = txtVida.Text,
                    CicloInicial = txtCiclo.Text
                };

                NobreakServices.AdicionarNobreak(dto);

                MessageBox.Show("Nobreak inserido com sucesso!");
                CarregarNobreaksGrid();
                LimparCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao inserir nobreak: " + ex.Message);
            }
        }

        private void CarregarNobreaksGrid()
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
                        
            try
            {
                DataGridViewRow nobreakrow = dgvNobreak.SelectedRows[0];
                var idValue = nobreakrow.Cells[0].Value;
                int id = Convert.ToInt32(idValue);
                MessageBox.Show(id.ToString());
                NobreakServices.DeletarNobreak(id);
                MessageBox.Show("Nobreak excluído com sucesso!");
                CarregarNobreaksGrid();
                LimparCampos();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Selecione um nobreak válido para excluir.");
            }   
            
        }

        private void LimparCampos()
        {
            txtCapacidade.Clear();
            txtCiclo.Clear();
            txtVida.Clear();
            cmbModelo.SelectedIndex = -1;
            cmbLocal.SelectedIndex = -1;
            dtpAquisicao.Value = DateTime.Today;
        }
        private void btnLimpar_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }

        private void btnVoltar_Click(object sender, EventArgs e)
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

        private void dgvNobreak_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    var row = dgvNobreak.Rows[e.RowIndex];
                    _nobreakIdSelecionado = Convert.ToInt32(row.Cells["Id"].Value); // Nome da coluna Id

                    cmbModelo.SelectedItem = row.Cells["Modelo"].Value.ToString();
                    cmbLocal.SelectedItem = row.Cells["Localizacao"].Value.ToString();
                    txtCapacidade.Text = row.Cells["CapacidadeVA"].Value.ToString();
                    dtpAquisicao.Value = Convert.ToDateTime(row.Cells["DataAquisicao"].Value);
                    txtVida.Text = row.Cells["VidaUtilAnos"].Value.ToString();
                    txtCiclo.Text = row.Cells["CicloCargaInicial"].Value.ToString();

                    btnAdicionar.Text = "Salvar Alterações";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar nobreak para edição: " + ex.Message);
            }

        }
    }
}
