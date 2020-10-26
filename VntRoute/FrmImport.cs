using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using iTextSharp.text.pdf.parser;
using iTextSharp.text.pdf;
using System.Globalization;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using GMap.NET.MapProviders;
using GMap.NET;
using System.Text;
using System.Text.RegularExpressions;

namespace VntRoute
{
    public partial class FrmImport : Form
    {

        public FrmImport()
        {
            InitializeComponent();
        }

        private void FrmMenu_Load(object sender, EventArgs e)
        {
            List<DtoMaps> list = new List<DtoMaps>();
            list.Add(new DtoMaps { id = 1, Mapa = "GoogleMap", ProviderMapa = "GoogleMapProvider" });
            list.Add(new DtoMaps { id = 2, Mapa = "CloudMap", ProviderMapa = "CloudMadeMapProvider" });
            list.Add(new DtoMaps { id = 3, Mapa = "OpenCycleMap", ProviderMapa = "OpenCycleMapProvider" });
            list.Add(new DtoMaps { id = 4, Mapa = "OpenStreetMap", ProviderMapa = "OpenStreetMapProvider" });
            list.Add(new DtoMaps { id = 5, Mapa = "WikiMapiaMap", ProviderMapa = "WikiMapiaMapProvider" });
            list.Add(new DtoMaps { id = 6, Mapa = "YahooMap", ProviderMapa = "YahooMapProvider" });
            comboBox1.DataSource = list;
            comboBox1.DisplayMember = "Mapa";
            comboBox1.ValueMember = "ProviderMapa";

            CarregarMapa();
            CarregarDestinos();
        }

        private void CarregarDestinos()
        {
            listBoxDestinos.Items.Clear();

            model get = new model();
            List<DtoDestino> lista = get.getListaDestinos();

            foreach (var l in lista)
            {
                AddMarkerMap(l.latitude, l.longitude, l.documento + "\n" + l.nome + "\n" + l.endereco);
                    this.listBoxDestinos.Items.Add(l.id + "-" + l.documento + "-" + l.nome + "-" + l.bairro);
            }
        }

        #region mapa

        private void CarregarMapa()
        {
            try
            {
                Provider();
                //get tiles from server only
                gMapControl1.Manager.Mode = AccessMode.ServerOnly;
                //center map on toledo
                model get = new model();
                DtoLatLong latlgn = get.getLatlgnEmpresa();
                gMapControl1.Position = new PointLatLng(Convert.ToDouble(latlgn.latitude, CultureInfo.InvariantCulture), Convert.ToDouble(latlgn.longitude, CultureInfo.InvariantCulture));

                //zoom min/max; default both = 2
                gMapControl1.MinZoom = 1;
                gMapControl1.MaxZoom = 100;
                //set zoom
                gMapControl1.Zoom = 13;
            }
            catch (Exception ex)
            {

            }
        }

        private void Provider()
        {
            if (comboBox1.SelectedValue == "GoogleMapProvider")
            {
                //use google provider
                gMapControl1.MapProvider = GoogleMapProvider.Instance;
            }
            else if (comboBox1.SelectedValue == "CloudMadeMapProvider")
            {
                gMapControl1.MapProvider = CloudMadeMapProvider.Instance;
            }
            else if (comboBox1.SelectedValue == "OpenCycleMapProvider")
            {
                gMapControl1.MapProvider = OpenCycleMapProvider.Instance;
            }
            else if (comboBox1.SelectedValue == "OpenStreetMapProvider")
            {
                gMapControl1.MapProvider = OpenStreetMapProvider.Instance;
            }
            else if (comboBox1.SelectedValue == "WikiMapiaMapProvider")
            {
                gMapControl1.MapProvider = WikiMapiaMapProvider.Instance;
            }
            else if (comboBox1.SelectedValue == "YahooMapProvider")
            {
                gMapControl1.MapProvider = YahooMapProvider.Instance;
            }
        }

        private void AddMarkerMap(double latitude, double longitude, string texto)
        {
            PointLatLng point = new PointLatLng(latitude, longitude);

            GMapMarker marker = new GMarkerGoogle(point, GMarkerGoogleType.blue_pushpin);
            GMapOverlay markers = new GMapOverlay("markers");
            markers.Markers.Add(marker);
            gMapControl1.Overlays.Add(markers);

            marker.ToolTipText = texto;
            marker.ToolTip.Fill = Brushes.Black;
            marker.ToolTip.Foreground = Brushes.White;
            marker.ToolTip.Stroke = Pens.Black;
            marker.ToolTip.TextPadding = new Size(20, 20);
        }

        #endregion

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            CarregarMapa();
        }

        private void btnSelecionar_Click(object sender, EventArgs e)
        {
            try
            {
                this.openFileDialog1.Title = "Selecionar arquivo de importação";
                this.openFileDialog1.InitialDirectory = @"c:\temp";
                DialogResult dr = this.openFileDialog1.ShowDialog();
                labelEndereco.Text = openFileDialog1.FileName;

                if (dr == DialogResult.OK)
                {
                    using (PdfReader reader = new PdfReader(openFileDialog1.FileName))
                    {
                        for (int i = 1; i <= reader.NumberOfPages; i++)
                        {
                            ITextExtractionStrategy Strategy = new LocationTextExtractionStrategy();
                            string thePage = string.Empty;
                            thePage = PdfTextExtractor.GetTextFromPage(reader, i, Strategy);

                            thePage = Encoding.UTF8.GetString(ASCIIEncoding.Convert(Encoding.Default, Encoding.UTF8, Encoding.Default.GetBytes(thePage)));

                            string[] theLines = thePage.Split('\n');

                            if (theLines[0].Contains("JADLOG"))
                            {
                                Jadlog(theLines);
                            }
                            if (theLines[0].Contains("CAF Consolidada"))
                            {
                                TotalExpress(theLines);
                            }
                            if (theLines[1].Contains("DIALOGO"))
                            {
                                DIALOGO(theLines);
                            }
                        }
                    }
                }
            }
            catch (Exception ex) { }
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            FrmDestino frD = new FrmDestino(listBoxDestinos.Text);
            frD.Show();
        }

        private void listBoxDestinos_DoubleClick(object sender, EventArgs e)
        {
            model get = new model();
            DtoLatLong latlgn = get.getLatLngDocId(listBoxDestinos.Text);
            //center map on toledo
            gMapControl1.Position = new PointLatLng(Convert.ToDouble(latlgn.latitude, CultureInfo.InvariantCulture), Convert.ToDouble(latlgn.longitude, CultureInfo.InvariantCulture));
            //set zoom
            gMapControl1.Zoom = 15;
        }

        private void btnListaEnderecos_Click(object sender, EventArgs e)
        {
            CarregarDestinos();
        }

        private void btnRota_Click(object sender, EventArgs e)
        {
            FrmRota fr = new FrmRota();
            fr.Show();
        }

        #region transportadoras

        private void DIALOGO(string[] theLines)
        {
            try
            {
                for (int i = 0; i < theLines.Count(); i++)
                {
                    if (i >= 19)
                    {
                        DtoDestino destino = new DtoDestino();
                        destino.transportadora = "DIALOGO";
                        destino.documento = Regex.Match(theLines[i].Substring(11, 9), @"\d+").Value;

                        if (theLines[i + 1].Contains("CENTRO"))
                            destino.bairro = "CENTRO";
                        else
                        if (theLines[i + 1].Contains("VILA INDUSTRIAL"))
                            destino.bairro = "VILA INDUSTRIAL";
                        else
                        if (theLines[i + 1].Contains("JARDIM PORTO ALEGRE"))
                            destino.bairro = "JARDIM PORTO ALEGRE";
                        else
                        if (theLines[i + 1].Contains("JARDIM POR"))
                            destino.bairro = "JARDIM PORTO ALEGRE";
                        else
                        if (theLines[i + 1].Contains("JD PTO ALEGRE"))
                            destino.bairro = "JARDIM PORTO ALEGRE";
                        else
                        if (theLines[i + 1].Contains("JD PORTO ALEGRE"))
                            destino.bairro = "JARDIM PORTO ALEGRE";
                        else
                        if (theLines[i + 1].Contains("SANTA CLARA 4"))
                            destino.bairro = "SANTA CLARA IV";
                        else
                        if (theLines[i + 1].Contains("SANTA CLARA IV"))
                            destino.bairro = "SANTA CLARA IV";
                        else
                        if (theLines[i + 1].Contains("JARDIM EUR"))
                            destino.bairro = "JARDIM EUROPA";
                        else
                        if (theLines[i + 1].Contains("JD EUROPA"))
                            destino.bairro = "JARDIM EUROPA";
                        else
                        if (theLines[i + 1].Contains("VILA PIONEIRO"))
                            destino.bairro = "VILA PIONEIRO";
                        else
                        if (theLines[i + 1].Contains("Vila Pioneiro"))
                            destino.bairro = "VILA PIONEIRO";
                        else
                        if (theLines[i + 1].Contains("VILA PIONE"))
                            destino.bairro = "VILA PIONEIRO";
                        else
                        if (theLines[i + 1].Contains("VL PIONEIRO"))
                            destino.bairro = "VILA PIONEIRO";
                        else
                        if (theLines[i + 1].Contains("JARDIM PAULISTA"))
                            destino.bairro = "JARDIM PAULISTA";
                        else
                        if (theLines[i + 1].Contains("JARDIM PAU"))
                            destino.bairro = "JARDIM PAULISTA";
                        else
                        if (theLines[i + 1].Contains("JARDIM PANORAMA"))
                            destino.bairro = "JARDIM PANORAMA";
                        else
                        if (theLines[i + 1].Contains("JARDIM PAN"))
                            destino.bairro = "JARDIM PANORAMA";
                        else
                        if (theLines[i + 1].Contains("JARDIM BRESSAN"))
                            destino.bairro = "JARDIM BRESSAN";
                        else
                        if (theLines[i + 1].Contains("JARDIM BRE"))
                            destino.bairro = "JARDIM BRESSAN";
                        else
                        if (theLines[i + 1].Contains("JARDIM PARIZZOTTO"))
                            destino.bairro = "JARDIM PARIZZOTTO";
                        else
                        if (theLines[i + 1].Contains("SAO FRANCISCO"))
                            destino.bairro = "SAO FRANCISCO";
                        else
                        if (theLines[i + 1].Contains("SAO FRANCI"))
                            destino.bairro = "SAO FRANCISCO";
                        else
                        if (theLines[i + 1].Contains("BOA ESPERANCA"))
                            destino.bairro = "BOA ESPERANCA";
                        else
                        if (theLines[i + 1].Contains("JARDIM CONCORDIA"))
                            destino.bairro = "JARDIM CONCORDIA";
                        else
                          if (theLines[i + 1].Contains("JARDIM CON"))
                            destino.bairro = "JARDIM CONCORDIA";
                        else
                          if (theLines[i + 1].Contains("JARDIM COOPAGRO"))
                            destino.bairro = "JARDIM COOPAGRO";
                        else
                          if (theLines[i + 1].Contains("MARACANA"))
                            destino.bairro = "MARACANA";
                        else
                          if (theLines[i + 1].Contains("INDEPENDENCIA"))
                            destino.bairro = "INDEPENDENCIA";
                        else
                          if (theLines[i + 1].Contains("VILA OPERARIA"))
                            destino.bairro = "VILA OPERARIA";
                        else
                            destino.bairro = "Não encontrado";

                        model get = new model();
                        Boolean existeDocumento = get.getDestinoDocumento(destino.documento, destino.transportadora);

                        if (!existeDocumento)
                        {
                            if (theLines[i + 1].Contains("-"))
                            {
                                int posicao = theLines[i + 1].IndexOf("-") + 3;
                                destino.nome = theLines[i + 1].Substring(posicao, 25);
                            }
                            else
                            {
                                destino.nome = theLines[i + 1].Substring(0, 30);
                            }
                            int posicaoDacte = theLines[i + 2].IndexOf("DACTE") - 5;
                            destino.endereco = theLines[i + 2].Substring(3, posicaoDacte).Replace('/', ',') + ",Toledo, PR";

                            try
                            {
                                model getlatlng = new model();
                                DtoLatLong latlong = getlatlng.GetLatLongGoogle(destino.endereco);
                                destino.latitude = Convert.ToDouble(latlong.latitude, CultureInfo.InvariantCulture);
                                destino.longitude = Convert.ToDouble(latlong.longitude, CultureInfo.InvariantCulture);
                            }
                            catch (Exception)
                            {
                                destino.status = "E";
                            }
                            destino.status = "I";
                            model post = new model();
                            post.set(destino);
                            i++;

                        }
                        i++;

                    }
                }
            }
            catch (Exception ex)
            { }
        }

        private void TotalExpress(string[] theLines)
        {
            try
            {
                int linha = 0;
                foreach (var l in theLines)
                {
                    linha++;
                    if (linha >= 15 && linha < 48)
                    {
                        string theLine = l.ToLower();
                        DtoDestino destino = new DtoDestino();
                        destino.transportadora = "TotalExpress";

                        string nrLinha = theLine.Substring(0, 2);
                        if (nrLinha.Trim().Length == 1)
                        {
                            destino.documento = theLine.Substring(20, 9);
                            destino.nome = theLine.Substring(35);
                            int posicao = theLine.IndexOf("/") + 2;
                            destino.bairro = theLine.Substring(posicao);

                            model get = new model();
                            Boolean existeDocumento = get.getDestinoDocumento(destino.documento, destino.transportadora);

                            if (!existeDocumento)
                            {
                                if (theLine.Contains("avenida"))
                                {
                                    int posicaoAvenia = theLine.IndexOf("avenida");
                                    destino.endereco = theLine.Substring(posicaoAvenia).Replace('/', ',') + ",Toledo, PR";
                                }
                                else
                                if (theLine.Contains("rua"))
                                {
                                    int posicaoRua = theLine.IndexOf("rua");
                                    destino.endereco = theLine.Substring(posicaoRua).Replace('/', ',') + ",Toledo, PR";
                                }
                                else
                                {
                                    destino.endereco = theLine.Substring(61).Replace('/', ',') + ",Toledo, PR";
                                }
                                try
                                {
                                    model getlatlng = new model();
                                    DtoLatLong latlong = getlatlng.GetLatLongGoogle(destino.endereco);
                                    destino.latitude = Convert.ToDouble(latlong.latitude, CultureInfo.InvariantCulture);
                                    destino.longitude = Convert.ToDouble(latlong.longitude, CultureInfo.InvariantCulture);
                                }
                                catch (Exception)
                                {
                                    destino.status = "E";
                                }
                            }
                        }
                        else
                        {
                            destino.documento = theLine.Substring(20, 9);
                            destino.nome = theLine.Substring(36);
                            int posicao = theLine.IndexOf("/") + 2;
                            destino.bairro = theLine.Substring(posicao);

                            destino.documento = theLine.Substring(20, 9);
                            model get = new model();
                            Boolean existeDocumento = get.getDestinoDocumento(destino.documento, destino.transportadora);

                            if (!existeDocumento)
                            {
                                if (theLine.Contains("avenida"))
                                {
                                    int posicaoAvenia = theLine.IndexOf("avenida");
                                    destino.endereco = theLine.Substring(posicaoAvenia).Replace('/', ',') + ",Toledo, PR";
                                }
                                else
                                if (theLine.Contains("rua"))
                                {
                                    int posicaoRua = theLine.IndexOf("rua");
                                    destino.endereco = theLine.Substring(posicaoRua).Replace('/', ',') + ",Toledo, PR";
                                }
                                else if (theLine.Contains("rodovia"))
                                {
                                    int posicaoRua = theLine.IndexOf("rodovia");
                                    destino.endereco = theLine.Substring(posicaoRua).Replace('/', ',') + ",Toledo, PR";
                                }
                                else
                                {
                                    destino.endereco = theLine.Substring(61).Replace('/', ',') + ",Toledo, PR";
                                }
                                try
                                {
                                    model getlatlng = new model();
                                    DtoLatLong latlong = getlatlng.GetLatLongGoogle(destino.endereco);
                                    destino.latitude = Convert.ToDouble(latlong.latitude, CultureInfo.InvariantCulture);
                                    destino.longitude = Convert.ToDouble(latlong.longitude, CultureInfo.InvariantCulture);
                                }
                                catch (Exception)
                                {
                                    destino.status = "E";
                                }
                            }
                        }

                        destino.status = "I";
                        model post = new model();
                        post.set(destino);

                    }
                }

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void Jadlog(string[] theLines)
        {
            try
            {
                for (int i = 0; i < theLines.Count(); i++)
                {
                    if (theLines[i].Contains("Nome") && theLines[i].Contains("Cep"))
                    {
                        DtoDestino destino = new DtoDestino();
                        destino.transportadora = "JADLOG";
                        if (theLines[i].Contains("NomeNome"))
                            destino.documento = theLines[i].Substring(9, 14);
                        else
                            destino.documento = theLines[i].Substring(5, 14);
                        model get = new model();
                        Boolean existeDocumento = get.getDestinoDocumento(destino.documento, destino.transportadora);

                        if (!existeDocumento)
                        {
                            destino.nome = theLines[i + 1].Substring(0, 29);
                            int posicao = theLines[i + 1].IndexOf("-");
                            int posicaobairro = (theLines[i - 1].IndexOf("-")) + 1;

                            string bairro = theLines[i - 1].Substring(posicaobairro);
                            destino.bairro = bairro;
                            destino.endereco = theLines[i + 1].Substring(posicao + 1).Replace('/', ',') + "," + bairro + ",Toledo, PR";

                            model getlatlng = new model();
                            DtoLatLong latlong = getlatlng.GetLatLongGoogle(destino.endereco);
                            try
                            {
                                destino.latitude = double.Parse(latlong.latitude, CultureInfo.InvariantCulture);
                                destino.longitude = double.Parse(latlong.longitude, CultureInfo.InvariantCulture);
                            }
                            catch (Exception)
                            {
                                destino.status = "E";
                            }
                            destino.status = "I";
                            model post = new model();
                            post.set(destino);
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        #endregion
    }
}
