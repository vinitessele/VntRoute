using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace VntRoute
{
    public partial class frmLancamento : Form
    {
        public frmLancamento()
        {
            InitializeComponent();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                model set = new model();
                DtoLancamento lanc = new DtoLancamento();
                lanc.dt_lancamento = Convert.ToDateTime(textBoxData.Text);
                lanc.dt_record = DateTime.Now;
                lanc.id_cliente = Convert.ToInt16(comboBoxCliente.SelectedValue);
                lanc.id_motorista = Convert.ToInt16(comboBoxMotorista.SelectedValue);
                lanc.observacao = textBoxObservacao.Text;
                if (textBoxValor.Text != string.Empty)
                    lanc.valor = float.Parse(textBoxValor.Text);
                if (textBoxControle.Text != string.Empty)
                    lanc.nr_controle = int.Parse(textBoxControle.Text);

                if (textBoxID.Text != string.Empty)
                {
                    lanc.id = int.Parse(textBoxID.Text);
                    set.alterLancamento(lanc);
                }
                else
                {
                    set.setLancamento(lanc);
                }
                MessageBox.Show("Registro salvo com sucesso");
                limpaCampos();
                CarregarGrid();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void limpaCampos()
        {
            textBoxID.Text = string.Empty;
            textBoxObservacao.Text = string.Empty;
            textBoxControle.Text = string.Empty;
            textBoxValor.Text = string.Empty;
            textBoxData.Text = string.Empty;
            textBoxData.Text = DateTime.Now.ToShortDateString();
        }

        private void Lançamento_Load(object sender, EventArgs e)
        {
            textBoxData.Text = DateTime.Now.ToShortDateString();
            model get = new model();
            List<DtoCliente> ListClientes = get.getAllClientes();
            comboBoxCliente.DataSource = null;
            comboBoxCliente.ValueMember = "id";
            comboBoxCliente.DisplayMember = "nome";
            comboBoxCliente.DataSource = ListClientes;

            List<DtoMotorista> ListMotorista = get.getAllMotorista();
            comboBoxMotorista.DataSource = null;
            comboBoxMotorista.ValueMember = "id";
            comboBoxMotorista.DisplayMember = "nome";
            comboBoxMotorista.DataSource = ListMotorista;

            CarregarGrid();
        }

        private void CarregarGrid()
        {
            model get = new model();
            List<DtoLancamento2> d = get.getLancamentosLimited();
            dataGridView1.DataSource = null;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
            dataGridView1.DataSource = d;
            dataGridView1.Refresh();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                model delete = new model();
                if (textBoxID.Text != string.Empty)
                    delete.DeleteLancamento(textBoxID.Text);
                else
                    MessageBox.Show("Selecione um registro");
                this.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            int ID = (Int32)dataGridView1.CurrentRow.Cells[0].Value;

            model get = new model();
            DtoLancamento2 d = get.getLancamentosId(ID);
            textBoxID.Text = d.id.ToString();
            textBoxData.Text = d.dt_lancamento.ToString();
            textBoxControle.Text = d.nr_controle.ToString();
            textBoxValor.Text = d.valor.ToString();
            textBoxObservacao.Text = d.observacao.ToString();
            comboBoxCliente.SelectedValue = d.id_cliente.Value;
            comboBoxMotorista.SelectedValue = d.id_motorista.Value;
        }

        private void textBoxPesquisa_TextChanged(object sender, EventArgs e)
        {
            model get = new model();

            string verifica = "^[0-9]";
            List<DtoLancamento2> d = new List<DtoLancamento2>();
            if (Regex.IsMatch(textBoxPesquisa.Text, verifica))
            {
                d = get.getLancamentoControle(textBoxPesquisa.Text);
            }
            else
            {
                d = get.getLancamentoNomeCliente(textBoxPesquisa.Text);
            }

            dataGridView1.DataSource = null;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
            dataGridView1.DataSource = d;
            dataGridView1.Refresh();
        }
    }
}
