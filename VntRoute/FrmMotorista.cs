using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

                if (textBoxID.Text == string.Empty)
                    set.setMotorista(c);
                else
                {
                    c.id = int.Parse(textBoxID.Text);
                    set.AlteraMotorista(c);
                }

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
        }
    }
}
