using GlobalSolutionNoBreaker.Models;
using GlobalSolutionNoBreaker.Repositories;
using GlobalSolutionNoBreaker.Services;
using System.Data;

namespace GlobalSolutionNoBreaker.Forms
{
    /// <summary>
    /// Formulário para gerenciamento dos nobreaks,
    /// permitindo adicionar, editar, excluir e visualizar os nobreaks cadastrados.
    /// </summary>
    public partial class NobreakForm : BaseForm
    {
        private bool isEditMode = false;
        private int selectedNobreakId = -1;

        /// <summary>
        /// Inicializa uma nova instância do formulário NobreakForm.
        /// </summary>
        public NobreakForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Carrega os nobreaks no DataGridView para visualização.
        /// </summary>
        private void CarregarNobreaksGrid()
        {
            try
            {
                DataTable dt = NobreakRepository.GetAllNobreaksNobreaksPage();
                dgvNobreak.DataSource = dt;

                // Configuração das colunas para melhor exibição
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

        /// <summary>
        /// Remove o nobreak selecionado após confirmação.
        /// </summary>
        private void btnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridViewRow nobreakrow = dgvNobreak.SelectedRows[0];
                var idValue = nobreakrow.Cells[0].Value;
                int id = Convert.ToInt32(idValue);

                var confirmar = MessageBox.Show(
                    $"Você tem certeza que deseja deletar o Nobreak de id {id}?",
                    $"Confirme a Exclusão do Nobreak de id {id}",
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
                // Caso nenhum nobreak válido esteja selecionado
                MessageBox.Show("Selecione um nobreak válido para excluir.");
            }
        }

        /// <summary>
        /// Limpa os campos do formulário, resetando seleção e datas.
        /// </summary>
        private void LimparCampos()
        {
            cmbModelo.SelectedIndex = -1;
            cmbLocal.SelectedIndex = -1;
            dtpAquisicao.Value = DateTime.Today;
        }

        /// <summary>
        /// Dicionário que relaciona nome do modelo com seu respectivo ID.
        /// </summary>
        private Dictionary<string, int> modelosDict = new()
        {
            { "Engetron Double Way Monofásico Modular DWMM 6 kVA", 1 },
            { "Intelbras DNB ISO 6 kVA", 2 },
            { "Delta Série RT 6 kVA", 3 },
            { "TS Shara SYAL EM 4 kVA", 4 },
            { "Eaton 9PX3000RT", 5 },
            { "APC Symmetra PX 10 kVA", 6 }
        };

        /// <summary>
        /// Evento disparado ao carregar o formulário, inicializa combos e carrega dados.
        /// </summary>
        private void NobreakForm_Load(object sender, EventArgs e)
        {
            var data = NobreakRepository.GetAllNobreaksNobreaksPage();
            dgvNobreak.DataSource = data;

            // Preenche combo com opções de modelos
            cmbModelo.Items.AddRange(new string[]
            {
                "Engetron Double Way Monofásico Modular DWMM 6 kVA",
                "Intelbras DNB ISO 6 kVA",
                "Delta Série RT 6 kVA",
                "TS Shara SYAL EM 4 kVA",
                "Eaton 9PX3000RT",
                "APC Symmetra PX 10 kVA"
            });

            // Preenche combo com possíveis locais
            cmbLocal.Items.AddRange(new string[] { "UTI", "Centro Cirúrgico", "Radiologia", "Emergência", "TI", "Farmácia", "Laboratório de Análise", "Sala do Servidor" });

            dtpAquisicao.MaxDate = DateTime.Today;

            CarregarNobreaksGrid();
        }

        /// <summary>
        /// Evento de duplo clique em célula do DataGridView para carregar nobreak selecionado para edição.
        /// </summary>
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
                    btnAdicionar.Refresh();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar nobreak para edição: " + ex.Message);
            }
        }

        /// <summary>
        /// Evento para retornar ao menu principal e esconder este formulário.
        /// </summary>
        private void btnVoltarNobreak_Click(object sender, EventArgs e)
        {
            this.Hide();
            MenuForm form = new MenuForm();
            form.Show();
        }

        /// <summary>
        /// Limpa todos os campos do formulário e reseta o modo de edição.
        /// </summary>
        private void btnLimpar_Click_1(object sender, EventArgs e)
        {
            // Limpa os campos do formulário
            LimparCampos();

            // Reseta o modo de edição
            isEditMode = false;
            selectedNobreakId = -1;

            // Restaura o texto original do botão
            btnAdicionar.Text = "Adicionar";
            btnAdicionar.Refresh(); // Força o redesenho imediato do botão
        }

        /// <summary>
        /// Evento de clique no botão Adicionar/Salvar, para inserir ou atualizar um nobreak.
        /// </summary>
        /// 
        private void btnAdicionar_Click_1(object sender, EventArgs e)
        {
            try
            {
                // Obtém o modelo selecionado no combobox e seu ID via dicionário
                string modeloSelecionado = cmbModelo.SelectedItem?.ToString();
                modelosDict.TryGetValue(modeloSelecionado, out int modeloId);

                // Cria objeto nobreak com dados preenchidos no formulário
                var nobreak = new Nobreak
                {
                    ModeloId = modeloId,
                    Localizacao = cmbLocal.SelectedItem?.ToString(),
                    DataAquisicao = dtpAquisicao.Value.Date
                };

                if (isEditMode)
                {
                    // Atualiza nobreak existente
                    nobreak.Id = selectedNobreakId;
                    nobreak.AtualizadoEm = DateTime.Now;
                    nobreak.AtualizadoPor = Session.LoggedInEmail; // Usuário logado realizando a alteração
                    NobreakServices.UpdateNobreak(nobreak);
                    MessageBox.Show("Nobreak atualizado com sucesso!");
                    isEditMode = false;
                    btnAdicionar.Text = "Adicionar";
                    CarregarNobreaksGrid();
                    LimparCampos();
                    btnAdicionar.Refresh(); // Força o redesenho imediato do botão
                }
                else
                {
                    // Insere novo nobreak
                    nobreak.CriadoEm = DateTime.Now;
                    nobreak.CriadoPor = Session.LoggedInEmail;
                    NobreakServices.AddNobreak(nobreak);
                    MessageBox.Show("Nobreak inserido com sucesso!");
                    CarregarNobreaksGrid();
                    LimparCampos();
                    btnAdicionar.Refresh();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao inserir nobreak: " + ex.Message);
            }
        }
    }
}
