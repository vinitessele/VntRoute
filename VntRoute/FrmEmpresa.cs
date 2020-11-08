using System;
using System.Globalization;
using System.Windows.Forms;

namespace VntRoute
{
    public partial class FrmEmpresa : Form
    {
        public FrmEmpresa()
        {
            InitializeComponent();
            model get = new model();
            DtoEmpresa e = get.getEndEmpresa();
            if (e != null)
            {
                textBoxID.Text = e.id.ToString();
                textBoxNome.Text = e.nome.ToString();
                textBoxLatitude.Text = e.latitude.ToString();
                textBoxLongitude.Text = e.longitude.ToString();
                textBoxEndereco.Text = e.endereco.ToString();
            }
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            model get = new model();
            DtoLatLong latlong = get.GetLatLongGoogle(textBoxEndereco.Text);
            try
            {
                textBoxLatitude.Text = latlong.latitude;
                textBoxLongitude.Text = latlong.longitude;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                model set = new model();
                DtoEmpresa d = new DtoEmpresa();
                d.nome = textBoxNome.Text;
                d.endereco = textBoxEndereco.Text;
                d.latitude = Convert.ToDouble(textBoxLatitude.Text, CultureInfo.InvariantCulture);
                d.longitude = Convert.ToDouble(textBoxLongitude.Text, CultureInfo.InvariantCulture);
                if (textBoxID.Text == string.Empty)
                    set.setEmpresa(d);
                else
                {
                    d.id =int.Parse(textBoxID.Text);
                    set.AlteraEmpresa(d);
                }
                MessageBox.Show("Registro salvo com sucesso");
                this.Close();
            }
            catch (Exception ex)
            {
                throw ex;
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
                delete.DeleteEmpresa(int.Parse(textBoxID.Text));
                this.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
