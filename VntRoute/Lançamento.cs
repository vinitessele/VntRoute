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
            }
            catch (Exception ex)
            {
                throw ex;
            }
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
                delete.DeleteLancamento(textBoxID.Text);
                this.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
