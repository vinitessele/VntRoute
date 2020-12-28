using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VntRoute.Relatorio
{
    public partial class FrmResultado : Form
    {
        public FrmResultado()
        {
            InitializeComponent();
        }

        private void FrmResultado_Load(object sender, EventArgs e)
        {
            //Vamos considerar que a data seja o dia de hoje, mas pode ser qualquer data.
            DateTime data = DateTime.Today;

            //DateTime com o primeiro dia do mês
            DateTime primeiroDiaDoMes = new DateTime(data.Year, data.Month, 1);
            DateTime ultimoDiaDoMes = new DateTime(data.Year, data.Month, DateTime.DaysInMonth(data.Year, data.Month));
            textBoxInicial.Text = primeiroDiaDoMes.ToShortDateString();
            textBoxFinal.Text = ultimoDiaDoMes.ToShortDateString();
        }

        private void FrmResultado_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            model get = new model();
            List<DtoResultado> ConsolidadoMotorista = get.MovimentacaoMotoristas(textBoxInicial.Text, textBoxFinal.Text);
            List<DtoResultado> ConsolidadoRecebimento = get.getLancamento(textBoxInicial.Text, textBoxFinal.Text);

            this.reportViewer1.LocalReport.DataSources.Clear();

            ReportDataSource rs = new ReportDataSource();
            ReportDataSource rs1 = new ReportDataSource();
            this.reportViewer1.LocalReport.DataSources.Add(rs);
            this.reportViewer1.LocalReport.DataSources.Add(rs1);
            rs.Name = "DsResultado";
            rs.Value = ConsolidadoMotorista;
            rs1.Name = "DsResultadoRecebimento";
            rs1.Value = ConsolidadoRecebimento;
            this.reportViewer1.RefreshReport();
        }
    }
}
