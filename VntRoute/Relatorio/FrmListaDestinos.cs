using Microsoft.Reporting.WinForms;
using System.Collections.Generic;
using System.Windows.Forms;

namespace VntRoute.Relatorio
{
    public partial class FrmListaDestinos : Form
    {
        ReportDataSource rs = new ReportDataSource();
        public FrmListaDestinos(List<DtoDestino> listDestinos)
        {
            InitializeComponent();

            rs.Name = "DataSetEntregas";
            rs.Value = listDestinos;

        }

        private void FrmListaDestinos_Load(object sender, System.EventArgs e)
        {
            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(rs);
            this.reportViewer1.RefreshReport();
        }
    }
}
