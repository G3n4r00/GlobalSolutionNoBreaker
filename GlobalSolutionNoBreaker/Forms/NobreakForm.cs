using GlobalSolutionNoBreaker.Models;
using GlobalSolutionNoBreaker.Repositories;
using GlobalSolutionNoBreaker.Services;
using System.Data;

namespace GlobalSolutionNoBreaker.Forms
{


    public partial class NobreakForm : Form
    {
        private bool isEditMode = false;
        private int selectedNobreakId = -1;

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
                var nobreak = new Nobreak
                {
                    Modelo = cmbModelo.SelectedItem?.ToString(),
                    Localizacao = cmbLocal.SelectedItem?.ToString(),
                    CapacidadeVA = Convert.ToInt32(txtCapacidade.Text),
                    DataAquisicao = dtpAquisicao.Value.Date,
                    VidaUtilAnos = Convert.ToInt32(txtVida.Text),
                    DataGarantia = dtpGarantia.Value.Date,
                };

                if (isEditMode)
                {
                    // Atualizar nobreak existente
                    nobreak.Id = selectedNobreakId;
                    nobreak.AtualizadoEm = DateTime.Now;
                    nobreak.AtualizadoPor = Session.LoggedInEmail; // Captura o usuário que está atualizando
                    NobreakServices.UpdateNobreak(nobreak);
                    MessageBox.Show("Nobreak atualizado com sucesso!");
                    isEditMode = false;
                    btnAdicionar.Text = "Adicionar";
                    CarregarNobreaksGrid();
                    LimparCampos();
                }
                else
                {
                    nobreak.CriadoEm = DateTime.Now;
                    nobreak.CriadoPor = Session.LoggedInEmail; 
                    NobreakServices.AddNobreak(nobreak);
                    MessageBox.Show("Nobreak inserido com sucesso!");
                    CarregarNobreaksGrid();
                    LimparCampos();
                    
                }

                
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
                DataTable dt = NobreakRepository.GetAllNobreaksNobreaksPage();
                dgvNobreak.DataSource = dt;

                // Configuração opcional para renomear colunas na interface
                dgvNobreak.Columns["Id"].HeaderText = "ID";
                dgvNobreak.Columns["Modelo"].HeaderText = "Modelo";
                dgvNobreak.Columns["Localizacao"].HeaderText = "Localização";
                dgvNobreak.Columns["CapacidadeVA"].HeaderText = "Capacidade (VA)";
                dgvNobreak.Columns["DataAquisicao"].HeaderText = "Data de Aquisição";
                dgvNobreak.Columns["DataGarantia"].HeaderText = "Data de Garantia";
                dgvNobreak.Columns["VidaUtilAnos"].HeaderText = "Vida Útil (anos)";
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
                var confirmar = MessageBox.Show($"Você tem certeza que deseja deletar o Nobreak de id {id}??",
                                     $"Confirme a Exclusão do Nobreaker de id {id}!!",
                                     MessageBoxButtons.YesNo);
                if (confirmar == DialogResult.No)
                {
                    MessageBox.Show("Exclusão cancelada!"); 
                    LimparCampos(); 
                }
                else
                {
                    NobreakServices.DeleteNobreak(id);
                    MessageBox.Show("Nobreak excluído com sucesso!");
                    CarregarNobreaksGrid();
                    LimparCampos();
                }
                    
            }
            catch (Exception ex)
            {
                MessageBox.Show("Selecione um nobreak válido para excluir.");
            }

        }

        private void LimparCampos()
        {
            txtCapacidade.Clear();
            txtVida.Clear();
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
            var data = NobreakRepository.GetAllNobreaksNobreaksPage();
            dgvNobreak.DataSource = data;
            cmbModelo.Items.AddRange(new string[] { "Modelo A", "Modelo B", "Modelo C" });
            cmbLocal.Items.AddRange(new string[] { "Sala 1", "Sala 2", "Sala 3" });

            dtpAquisicao.MaxDate = DateTime.Today;
            dtpGarantia.MinDate = DateTime.Today;   
        }

        private void dgvNobreak_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    var row = dgvNobreak.Rows[e.RowIndex];
                    selectedNobreakId = Convert.ToInt32(row.Cells["Id"].Value);
                    

                    cmbModelo.SelectedItem = row.Cells["Modelo"].Value.ToString();
                    cmbLocal.SelectedItem = row.Cells["Localizacao"].Value.ToString();
                    txtCapacidade.Text = row.Cells["CapacidadeVA"].Value.ToString();
                    dtpAquisicao.Value = Convert.ToDateTime(row.Cells["DataAquisicao"].Value);
                    dtpGarantia.Value = Convert.ToDateTime(row.Cells["DataGarantia"].Value);
                    txtVida.Text = row.Cells["VidaUtilAnos"].Value.ToString();

                    isEditMode = true;
                    btnAdicionar.Text = "Salvar Alterações";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar nobreak para edição: " + ex.Message);
            }

        }

        private void lblVida_Click(object sender, EventArgs e)
        {

        }
    }
}
