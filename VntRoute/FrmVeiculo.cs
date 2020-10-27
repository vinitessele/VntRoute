using System;
using System.Windows.Forms;

namespace VntRoute
{
    public partial class FrmVeiculo : Form
    {
        public FrmVeiculo()
        {
            InitializeComponent();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                model set = new model();
                DtoVeiculo v = new DtoVeiculo();
                v.marcamodelo = textBoxMarcaModelo.Text;
                if (textBoxKm.Text != string.Empty)
                    v.km_atual =int.Parse(textBoxKm.Text);
                v.placa = textBoxAnoModelo.Text;
                if (textBoxID.Text == string.Empty)
                {
                    set.setVeiculo(v);
                }
                else {
                    v.id = int.Parse(textBoxID.Text);
                    set.AlteraVeiculo(v);
                }
            }
            catch (Exception ex) {
            }
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
                delete.DeleteVeiculo(int.Parse(textBoxID.Text));
                this.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
