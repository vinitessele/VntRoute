using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace VntRoute.Relatorio
{
    public partial class FrmRelCliente : Form
    {
        public FrmRelCliente()
        {
            InitializeComponent();
        }

        private void FrmRelCliente_Load(object sender, EventArgs e)
        {
            ReportDataSource rs = new ReportDataSource();
            model get = new model();
            List<DtoCliente> list = get.getAllClientes();
            rs.Name = "DataSetCliente";
            rs.Value = list;
            this.reportViewer2.LocalReport.DataSources.Clear();
            this.reportViewer2.LocalReport.DataSources.Add(rs);
            this.reportViewer2.RefreshReport();
        }
    }
}
