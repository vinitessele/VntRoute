using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace VntRoute
{
    public partial class FrmMotorista : Form
    {
        public FrmMotorista()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                model set = new model();
                DtoMotorista c = new DtoMotorista();
                c.nome = textBoxNome.Text;
                c.endereco = textBoxEndereco.Text;
                c.telefone = textBoxTelefone.Text;
                c.email = textBoxEmail.Text;
                c.cpfcnpj = textBoxCPF.Text;
                c.ierg = textBoxRG.Text;
                c.id_cidade = Convert.ToInt16(comboBox1.SelectedValue);
                c.observacoes = textBoxObservacao.Text;
                c.complemento = textBoxComplemento.Text;
                if (textBoxComissao.Text != string.Empty)
                    c.comissao = float.Parse(textBoxComissao.Text);

                if (textBoxID.Text == string.Empty)
                    set.setMotorista(c);
                else
                {
                    c.id = int.Parse(textBoxID.Text);
                    set.AlteraMotorista(c);
                }
                MessageBox.Show("Registro salvo com sucesso");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                model delete = new model();
                delete.DeleteMotorista(textBoxID.Text);
                this.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void FrmMotorista_Load(object sender, EventArgs e)
        {
            model get = new model();
            List<DtoCidadeMap> ListCidades = get.getAllCidades();
            comboBox1.DataSource = null;
            comboBox1.ValueMember = "id";
            comboBox1.DisplayMember = "nome";
            comboBox1.DataSource = ListCidades;

            List<DtoMotorista> d = get.getMotoristasAll();
            CarregarGrid(d);
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            int ID = (Int32)dataGridView1.CurrentRow.Cells[0].Value;

            model get = new model();
            DtoMotorista d = get.getMotoristaId(ID);
            textBoxID.Text = d.id.ToString();
            textBoxNome.Text = d.nome;
            textBoxEndereco.Text = d.endereco;
            textBoxTelefone.Text = d.telefone;
            textBoxEmail.Text = d.email;
            textBoxCPF.Text = d.cpfcnpj;
            textBoxRG.Text = d.ierg;
            comboBox1.SelectedValue = d.id_cidade;
            textBoxObservacao.Text = d.observacoes;
            textBoxComplemento.Text = d.complemento;
            textBoxComissao.Text = d.comissao.ToString();
        }

        private void textBoxPesquisa_TextChanged(object sender, EventArgs e)
        {
            model get = new model();
            List<DtoMotorista> d = get.getMotoristaNome(textBoxPesquisa.Text);
            CarregarGrid(d);
        }

        private void CarregarGrid(List<DtoMotorista> d)
        {
            dataGridView1.DataSource = null;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
            dataGridView1.DataSource = d;
            dataGridView1.Refresh();
        }
    }
}
