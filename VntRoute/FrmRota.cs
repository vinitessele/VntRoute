using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace VntRoute
{
    public partial class FrmRota : Form
    {
        public FrmRota()
        {
            InitializeComponent();
        }
        public class Inicial
        {
            public IList<string> legs { get; set; }
            public string start_address { get; set; }
            public IList<string> commands { get; set; }
            public string end_address { get; set; }
        }

        public void FrmRota_Load(object sender, EventArgs e)
        {
            CarregarMapa();

            listBoxDestinos.Items.Clear();
            checkedListBox1.Items.Clear();

            model get = new model();
            List<DtoBairro> listBairros = get.getBairros();
            foreach (var l in listBairros)
            {
                try
                {
                    if (!l.bairro.Equals(null))
                        checkedListBox1.Items.Add(l.bairro);
                }
                catch
                {
                    checkedListBox1.Items.Add('-');
                }
            }
        }

        private void Rota(List<DtoBairro> listBairro)
        {
            model get = new model();
            List<DtoRota> listRota = get.getRotaGoogle(listBairro);

            foreach (var l in listRota)
            {
                double start_latitude = Convert.ToDouble(l.start_latitude, CultureInfo.InvariantCulture);
                double start_longitude = Convert.ToDouble(l.start_longitude, CultureInfo.InvariantCulture);
                double end_latitude = Convert.ToDouble(l.end_latitude, CultureInfo.InvariantCulture);
                double end_longitude = Convert.ToDouble(l.end_longitude, CultureInfo.InvariantCulture);

                PointLatLng startp = new PointLatLng(start_latitude, start_longitude);
                PointLatLng endp = new PointLatLng(end_latitude, end_longitude);
                GoogleMapProvider.Instance.ApiKey = "AIzaSyAwjnJzF57fQddVy_dL8yTC01Zw7ufVuY8";
                //OpenStreetMapProvider.Instance.GetRoute
                //MapRoute route = BingMapProvider.Instance.GetRoute(startp, endp, false, false, 15);
                MapRoute route = GoogleMapProvider.Instance.GetRoute(startp, endp, false, false, 16);
                if (route != null)
                {
                    GMapRoute r = new GMapRoute(route.Points, "MinhaRota");
                    GMapOverlay routesOverlay = new GMapOverlay("MinhaRota");
                    routesOverlay.Routes.Add(r);
                    gMapControl1.Overlays.Add(routesOverlay);
                    r.Stroke.Width = 3;
                    r.Stroke.Color = Color.SeaGreen;
                }
            }
        }

        private void CarregarMapa()
        {
            //use google provider
            //gMapControl1.MapProvider = BingMapProvider.Instance;
            gMapControl1.MapProvider = GoogleMapProvider.Instance;
            //get tiles from server only
            gMapControl1.Manager.Mode = AccessMode.ServerOnly;
            //not use proxy
            GMapProvider.WebProxy = null;
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

        private void AddMarkerMap(double latitude, double longitude, string texto)
        {
            PointLatLng point = new PointLatLng(latitude, longitude);

            GMapMarker marker = new GMarkerGoogle(point, GMarkerGoogleType.green_dot);
            GMapOverlay markers = new GMapOverlay("markers");
            markers.Markers.Add(marker);
            gMapControl1.Overlays.Add(markers);

            marker.ToolTipText = texto;
            marker.ToolTip.Fill = Brushes.Black;
            marker.ToolTip.Foreground = Brushes.White;
            marker.ToolTip.Stroke = Pens.Black;
            marker.ToolTip.TextPadding = new Size(20, 20);
        }

        private void listBoxDestinos_DoubleClick(object sender, EventArgs e)
        {
            model get = new model();
            DtoLatLong latlgn = get.getLatLngId(listBoxDestinos.Text);
            //center map 
            gMapControl1.Position = new PointLatLng(Convert.ToDouble(latlgn.latitude, CultureInfo.InvariantCulture), Convert.ToDouble(latlgn.longitude, CultureInfo.InvariantCulture));
            //set zoom
            gMapControl1.Zoom = 15;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            model model = new model();
            int idRota = model.getIdRota();
            idRota++;
            List<DtoDestino> lista = model.getListaDestinos();
            foreach (var l in lista)
            {
                model.addRota(l.id, idRota, "F");
            }
        }

        private void btnSelecionar_Click(object sender, EventArgs e)
        {
            List<DtoBairro> listBairros = new List<DtoBairro>();
            foreach (string l in checkedListBox1.CheckedItems)
            {
                DtoBairro b = new DtoBairro();
                b.bairro = l;
                listBairros.Add(b);
            }
            Rota(listBairros);
        }

        private void Btn_selecionarMapa_Click(object sender, EventArgs e)
        {
            listBoxDestinos.Items.Clear();
            List<DtoBairro> listBairros = new List<DtoBairro>();
            foreach (string l in checkedListBox1.CheckedItems)
            {
                DtoBairro b = new DtoBairro();
                b.bairro = l;
                listBairros.Add(b);
            }
            //RotaCoordenadas(listBairros);
            model get = new model();
            List<DtoDestino> listRota = get.getListaDestinosBairro(listBairros);

            foreach (DtoDestino l in listRota)
            {
                string texto = "Documento:" + l.documento + " \n" + l.nome + " \n" + l.endereco;

                this.listBoxDestinos.Items.Add(l.id.ToString() + " - Entrega - " + texto);
                AddMarkerMap(l.latitude, l.longitude, texto);
            }
        }

        private void RotaCoordenadas(List<DtoBairro> listBairros)
        {
            {
                listBoxDestinos.Items.Clear();

                model get = new model();
                List<DtoDestino> listRota = get.getListaDestinosBairro(listBairros);
                for (int i = 0; i < listRota.Count - 1; i++)
                {
                    double start_latitude = Convert.ToDouble(listRota[i].latitude, CultureInfo.InvariantCulture);
                    double start_longitude = Convert.ToDouble(listRota[i].longitude, CultureInfo.InvariantCulture);
                    double end_latitude = Convert.ToDouble(listRota[i + 1].latitude, CultureInfo.InvariantCulture);
                    double end_longitude = Convert.ToDouble(listRota[i + 1].longitude, CultureInfo.InvariantCulture);

                    PointLatLng point = new PointLatLng(start_latitude, start_longitude);

                    GMapMarker marker = new GMarkerGoogle(point, GMarkerGoogleType.green);
                    GMapOverlay markers = new GMapOverlay("markers");
                    markers.Markers.Add(marker);
                    gMapControl1.Overlays.Add(markers);

                    marker.ToolTipText = "Documento:" + listRota[i].documento + "\n End:" + listRota[i].endereco;
                    marker.ToolTip.Fill = Brushes.White;
                    marker.ToolTip.Foreground = Brushes.Black;
                    marker.ToolTip.Stroke = Pens.Black;
                    marker.ToolTip.TextPadding = new Size(20, 20);

                    this.listBoxDestinos.Items.Add(listRota[i].id.ToString() + " - Inicio - " + listRota[i].endereco);
                    this.listBoxDestinos.Items.Add(listRota[i].id.ToString() + " - Fim - " + listRota[i + 1].endereco);
                }
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            var isChecked = ((CheckBox)sender).Checked;
            if (isChecked)
                checkBox1.Text = "Desmarcar Todos";
            else
                checkBox1.Text = "Marcar Todos";

            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                checkedListBox1.SetItemChecked(i, isChecked);
            }
        }
    }
}

