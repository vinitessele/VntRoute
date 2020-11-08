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
    public partial class FrmEstado : Form
    {
        public FrmEstado()
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
                DtoEstado d = new DtoEstado();
                d.nome = textBoxNome.Text;
                d.uf = textBoxUF.Text;
                d.codigouf =int.Parse(textBoxCodEstado.Text);
                if (textBoxID.Text == string.Empty)
                    set.setEstado(d);
                else
                    set.AlteraEstado(d);
                MessageBox.Show("Registro salvo com sucesso");
                this.Close();
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
                delete.DeleteEstado(int.Parse(textBoxID.Text));
                this.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
