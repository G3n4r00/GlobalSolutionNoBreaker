using GlobalSolutionNoBreaker.Models;
using GlobalSolutionNoBreaker.Repositories;
using GlobalSolutionNoBreaker.Services;
using System.Data;

namespace GlobalSolutionNoBreaker.Forms
{


    public partial class NobreakForm : BaseForm
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

                string modeloSelecionado = cmbModelo.SelectedItem?.ToString();
                modelosDict.TryGetValue(modeloSelecionado, out int modeloId);

                var nobreak = new Nobreak
                {
                    ModeloId = modeloId,
                    Localizacao = cmbLocal.SelectedItem?.ToString(),
                    DataAquisicao = dtpAquisicao.Value.Date
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
                dgvNobreak.Columns["Nome"].HeaderText = "Modelo";
                dgvNobreak.Columns["Localizacao"].HeaderText = "Localização";
                dgvNobreak.Columns["CapacidadeVa"].HeaderText = "Capacidade (VA)";
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

        private Dictionary<string, int> modelosDict = new()
        {
            { "Engetron Double Way Monofásico Modular DWMM 6 kVA", 1 },
            { "Intelbras DNB ISO 6 kVA", 2 },
            { "Delta Série RT 6 kVA", 3 },
            { "TS Shara SYAL EM 4 kVA", 4 },
            { "Eaton 9PX3000RT", 5 },
            { "APC Symmetra PX 10 kVA", 6 }
        };




        private void NobreakForm_Load(object sender, EventArgs e)
        {
            var data = NobreakRepository.GetAllNobreaksNobreaksPage();
            dgvNobreak.DataSource = data;
            cmbModelo.Items.AddRange(new string[]
            {
                "Engetron Double Way Monofásico Modular DWMM 6 kVA",
                "Intelbras DNB ISO 6 kVA",
                "Delta Série RT 6 kVA",
                "TS Shara SYAL EM 4 kVA",
                "Eaton 9PX3000RT",
                "APC Symmetra PX 10 kVA"
            });
            cmbLocal.Items.AddRange(new string[] { "UTI", "Centro Cirúrgico", "Radiologia", "Emergência", "TI", "Farmácia", "Laboratório de Análise", "Sala do Servidor" });

            dtpAquisicao.MaxDate = DateTime.Today;
            CarregarNobreaksGrid();
        }

        private void dgvNobreak_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    var row = dgvNobreak.Rows[e.RowIndex];
                    selectedNobreakId = Convert.ToInt32(row.Cells["Id"].Value);
                    cmbModelo.SelectedItem = row.Cells["Nome"].Value.ToString();
                    cmbLocal.SelectedItem = row.Cells["Localizacao"].Value.ToString();
                    dtpAquisicao.Value = Convert.ToDateTime(row.Cells["DataAquisicao"].Value);

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

        private void btnVoltarNobreak_Click(object sender, EventArgs e)
        {
            this.Hide();
            MenuForm form = new MenuForm();
            form.Show();
        }
    }
}
