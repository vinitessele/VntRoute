using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace VntRoute
{
    public partial class FrmCidade : Form
    {
        public FrmCidade()
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
                DtoCidade d = new DtoCidade();
                d.nome = textBoxNome.Text;
                if (textBoxCodIbge.Text != string.Empty)
                    d.codigoibge = Convert.ToInt16(textBoxCodIbge.Text);
                    d.id_estado = Convert.ToInt16(comboBox1.SelectedValue);
                if (textBoxID.Text == string.Empty)
                    set.setCidade(d);
                else
                {
                    d.id = int.Parse(textBoxID.Text);
                    set.AlteraCidade(d);
                }
                this.Close();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void FrmCidade_Load(object sender, EventArgs e)
        {
            model get = new model();
            List<DtoEstado> ListEstado = get.getAllEstados();
            comboBox1.DataSource = null;
            comboBox1.ValueMember = "id";
            comboBox1.DisplayMember = "uf";
            comboBox1.DataSource = ListEstado;
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                model delete = new model();
                delete.DeleteCidade(textBoxID.Text);
                this.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
