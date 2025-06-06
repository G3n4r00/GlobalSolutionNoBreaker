using GlobalSolutionNoBreaker.Models;
using GlobalSolutionNoBreaker.Repositories;
using GlobalSolutionNoBreaker.Services;
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
    /// Formulário responsável pela gestão de manutenções dos nobreaks.
    /// </summary>
    public partial class ManutencaoForm : BaseForm
    {
        // Armazena o ID do nobreak selecionado
        private int selectedNobreakId = -1;

        public ManutencaoForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Carrega os nobreaks disponíveis na grid de manutenção.
        /// </summary>
        private void CarregarNobreaksGridManutencao()
        {
            try
            {
                DataTable dt = NobreakRepository.GetAllNobreaksManutencao();
                dgvManutencao.DataSource = dt;

                // Renomeia os cabeçalhos das colunas para melhor exibição
                dgvManutencao.Columns["Id"].HeaderText = "ID";
                dgvManutencao.Columns["Nome"].HeaderText = "Modelo";
                dgvManutencao.Columns["StatusOperacional"].HeaderText = "Status Operacional";
                dgvManutencao.Columns["Localizacao"].HeaderText = "Localização";
                dgvManutencao.Columns["CapacidadeVa"].HeaderText = "Capacidade (VA)";
                dgvManutencao.Columns["DataUltimaManutencao"].HeaderText = "Data da Última Manutenção";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar nobreaks: " + ex.Message);
            }
        }

        /// <summary>
        /// Evento acionado ao dar duplo clique em uma linha da grid.
        /// Preenche os campos do formulário com os dados do nobreak selecionado.
        /// </summary>
        private void dgvManutencao_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    var row = dgvManutencao.Rows[e.RowIndex];
                    selectedNobreakId = Convert.ToInt32(row.Cells["Id"].Value);
                    txtIdManutencao.Text = selectedNobreakId.ToString();

                    // Conversão da data de manutenção
                    object cellValue = row.Cells["DataUltimaManutencao"].Value;
                    DateTime parsedDate;
                    if (DateTime.TryParse(Convert.ToString(cellValue), out parsedDate))
                        dtpManutencao.Value = parsedDate;
                    else
                        dtpManutencao.Value = DateTime.Today;

                    // Seleciona status atual
                    cmbStatusManutencao.SelectedItem = row.Cells["StatusOperacional"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar nobreak para manutenção: " + ex.Message);
            }
        }

        /// <summary>
        /// Evento acionado quando o formulário é carregado.
        /// Inicializa dados e configurações dos controles.
        /// </summary>
        private void ManutencaoForm_Load(object sender, EventArgs e)
        {
            var data = NobreakRepository.GetAllNobreaksManutencao();
            dgvManutencao.DataSource = data;

            cmbStatusManutencao.Items.AddRange(new string[] { "Ativo", "Crítico", "Inativo" });
            dtpManutencao.MaxDate = DateTime.Today;
        }

        /// <summary>
        /// Botão para salvar/registrar a manutenção do nobreak selecionado.
        /// </summary>
        private void hopeRoundButton1_Click(object sender, EventArgs e)
        {
            try
            {
                var nobreak = new Nobreak
                {
                    Id = selectedNobreakId,
                    DataUltimaManutencao = dtpManutencao.Value.Date,
                    StatusOperacional = cmbStatusManutencao.SelectedItem?.ToString(),
                    AtualizadoEm = DateTime.Now,
                    AtualizadoPor = Session.LoggedInEmail // Captura o usuário logado
                };

                NobreakServices.RegistroManutencao(nobreak);

                MessageBox.Show("Nobreak atualizado com sucesso!");
                CarregarNobreaksGridManutencao();
                LimparCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao inserir manutenção: " + ex.Message);
            }
        }

        /// <summary>
        /// Limpa os campos do formulário.
        /// </summary>
        private void LimparCampos()
        {
            cmbStatusManutencao.SelectedIndex = -1;
            txtIdManutencao.Text = "0";
            dtpManutencao.Value = DateTime.Today;
        }

        /// <summary>
        /// Botão de voltar ao menu principal.
        /// </summary>
        private void btnVoltarManutencao_Click(object sender, EventArgs e)
        {
            this.Hide();
            MenuForm form = new MenuForm();
            form.Show();
        }
    }
}
