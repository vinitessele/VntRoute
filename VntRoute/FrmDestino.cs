using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;

namespace VntRoute
{
    public partial class FrmDestino : Form
    {
        public FrmDestino()
        {
            InitializeComponent();
        }

        public FrmDestino(string valor)
        {
            InitializeComponent();
            model get = new model();
            DtoDestino d = get.getDestinoDocumento(valor);
            textBoxID.Text = d.id.ToString();
            textBoxNome.Text = d.nome;
            textBoxDocumento.Text = d.documento;
            textBoxEndereco.Text = d.endereco;
            textBoxLatitude.Text = d.latitude.ToString();
            textBoxLongitude.Text = d.longitude.ToString();
            textBoxTransportadora.Text = d.transportadora;
            textBoxBairro.Text = d.bairro;
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            model get = new model();
            DtoLatLong latlong = get.GetLatLongGoogle(textBoxEndereco.Text);
            try
            {
                textBoxLatitude.Text = latlong.latitude;
                textBoxLongitude.Text = latlong.longitude;
                textBoxDistancia.Text = latlong.distancia;
                textBoxDuracao.Text = latlong.duracao;
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
                DtoDestino d = new DtoDestino();
                d.nome = textBoxNome.Text;
                d.documento = textBoxDocumento.Text;
                d.endereco = textBoxEndereco.Text;
                d.latitude = Convert.ToDouble(textBoxLatitude.Text, CultureInfo.InvariantCulture);
                d.longitude = Convert.ToDouble(textBoxLongitude.Text, CultureInfo.InvariantCulture);
                d.transportadora = textBoxTransportadora.Text;
                d.bairro = textBoxBairro.Text;
                d.duracao = textBoxDuracao.Text;
                d.distancia = Convert.ToDouble(textBoxDistancia.Text, CultureInfo.InvariantCulture);
                d.status = "I";

                if (textBoxID.Text == "")
                    set.setDestino(d);
                else
                    set.AlteraDestino(d);
                MessageBox.Show("Registro salvo com sucesso");

                CarregaDestinos();
                limpaCampos();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void limpaCampos()
        {
            textBoxID.Text = string.Empty;
            textBoxNome.Text = string.Empty;
            textBoxDocumento.Text = string.Empty;
            textBoxEndereco.Text = string.Empty;
            textBoxLatitude.Text = string.Empty;
            textBoxLongitude.Text = string.Empty;
            textBoxTransportadora.Text = string.Empty;
            textBoxBairro.Text = string.Empty;
            textBoxDistancia.Text = string.Empty;
            textBoxDuracao.Text = string.Empty;
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                model delete = new model();
                delete.DeleteDestino(textBoxDocumento.Text);
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

        private void FrmDestino_Load(object sender, EventArgs e)
        {
            CarregaDestinos();
        }

        private void CarregaDestinos()
        {
            model get = new model();
            List<DtoDestino> d = get.getListDestino();
            dataGridView1.DataSource = null;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
            dataGridView1.DataSource = d;
            dataGridView1.Refresh();
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            int ID = (Int32)dataGridView1.CurrentRow.Cells[0].Value;

            model get = new model();
            DtoDestino d = get.getDestinoId(ID);
            textBoxID.Text = d.id.ToString();
            textBoxNome.Text = d.nome;
            textBoxDocumento.Text = d.documento;
            textBoxEndereco.Text = d.endereco;
            textBoxLatitude.Text = d.latitude.ToString();
            textBoxLongitude.Text = d.longitude.ToString();
            textBoxTransportadora.Text = d.transportadora;
            textBoxBairro.Text = d.bairro;
        }
    }
}
