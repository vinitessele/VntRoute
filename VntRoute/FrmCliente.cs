using System;
using System.Windows.Forms;
using System.Collections.Generic;

namespace VntRoute
{
    public partial class FrmCliente : Form
    {
        public FrmCliente()
        {
            InitializeComponent();
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
                delete.DeleteCliente(textBoxID.Text);
                this.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                model set = new model();
                DtoCliente c = new DtoCliente();
                c.nome = textBoxNome.Text;
                c.endereco = textBoxEndereco.Text;
                c.telefone = textBoxTelefone.Text;
                c.email = textBoxEmail.Text;
                c.cpfcnpj = textBoxCPF.Text;
                c.ierg = textBoxRG.Text;
                c.id_cidade = Convert.ToInt16(comboBox1.SelectedValue);
                c.observacoes = textBoxObservacao.Text;
                c.complemento = textBoxComplemento.Text;

                if (textBoxID.Text == string.Empty)
                    set.setCliente(c);
                else
                {
                    c.id = int.Parse(textBoxID.Text);
                    set.AlteraCliente(c);
                }
                MessageBox.Show("Registro salvo com sucesso");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void FrmCliente_Load(object sender, EventArgs e)
        {
            model get = new model();
            List<DtoCidadeMap> ListCidades = get.getAllCidades();
            comboBox1.DataSource = null;
            comboBox1.ValueMember = "id";
            comboBox1.DisplayMember = "nome";
            comboBox1.DataSource = ListCidades;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
