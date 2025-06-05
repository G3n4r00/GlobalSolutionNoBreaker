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
    public partial class ManutencaoForm : BaseForm
    {
        private int selectedNobreakId = -1;
        public ManutencaoForm()
        {
            InitializeComponent();
        }
        private void CarregarNobreaksGridManutencao()
        {
            try
            {
                DataTable dt = NobreakRepository.GetAllNobreaksManutencao();
                dgvManutencao.DataSource = dt;
                //N.Id, M.Nome, N.StatusOperacional, N.Localizacao, M.CapacidadeVa, N.DataUltimaManutencao
                // Configuração opcional para renomear colunas na interface
                dgvManutencao.Columns["Id"].HeaderText = "ID";
                dgvManutencao.Columns["Nome"].HeaderText = "Modelo";
                dgvManutencao.Columns["StatusOperacional"].HeaderText = "Status Operacional";
                dgvManutencao.Columns["Localizacao"].HeaderText = "Localização";
                dgvManutencao.Columns["CapacidadeVa"].HeaderText = "Capacidade (VA)";
                dgvManutencao.Columns["DataUltimaManutencao"].HeaderText = "Data da Ultima Manutenção";

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar nobreaks: " + ex.Message);
            }
        }



        private void dgvManutencao_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    var row = dgvManutencao.Rows[e.RowIndex];
                    selectedNobreakId = Convert.ToInt32(row.Cells["Id"].Value);
                    txtIdManutencao.Text = row.Cells["Id"].Value.ToString();
                    object cellValue = row.Cells["DataUltimaManutencao"].Value;
                    DateTime parsedDate;

                    if (DateTime.TryParse(Convert.ToString(cellValue), out parsedDate))
                        dtpManutencao.Value = parsedDate;
                    else
                        dtpManutencao.Value = DateTime.Today; // Define a data atual se não houver valor
                    cmbStatusManutencao.SelectedItem = row.Cells["StatusOperacional"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar nobreak para manutenção: " + ex.Message);
            }
        }

        private void ManutencaoForm_Load(object sender, EventArgs e)
        {
            var data = NobreakRepository.GetAllNobreaksManutencao();
            dgvManutencao.DataSource = data;
            cmbStatusManutencao.Items.AddRange(new string[] { "Ativo", "Crítico", "Inativo" });
            dtpManutencao.MaxDate = DateTime.Today;
        }

        private void hopeRoundButton1_Click(object sender, EventArgs e)
        {
            try
            {
                var nobreak = new Nobreak
                {
                    DataUltimaManutencao = dtpManutencao.Value.Date,
                    StatusOperacional = cmbStatusManutencao.SelectedItem?.ToString(),
                };
                // Atualizar nobreak existente
                nobreak.Id = selectedNobreakId;
                nobreak.AtualizadoEm = DateTime.Now;
                nobreak.AtualizadoPor = Session.LoggedInEmail; // Captura o usuário que está atualizando
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

        private void LimparCampos()
        {
            cmbStatusManutencao.SelectedIndex = -1;
            txtIdManutencao.Text = "0";
            dtpManutencao.Value = DateTime.Today;
        }

        private void btnVoltarManutencao_Click(object sender, EventArgs e)
        {
            this.Hide();
            MenuForm form = new MenuForm();
            form.Show();
        }
    }
}
