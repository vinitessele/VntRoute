using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace VntRoute.Relatorio
{
    public partial class FrmRelLancamentos : Form
    {
        public FrmRelLancamentos()
        {
            InitializeComponent();
        }

        private void FrmRelLancamentos_Load(object sender, EventArgs e)
        {
            //Vamos considerar que a data seja o dia de hoje, mas pode ser qualquer data.
            DateTime data = DateTime.Today;

            //DateTime com o primeiro dia do mês
            DateTime primeiroDiaDoMes = new DateTime(data.Year, data.Month, 1);
            DateTime ultimoDiaDoMes = new DateTime(data.Year, data.Month, DateTime.DaysInMonth(data.Year, data.Month));
            textBoxInicial.Text = primeiroDiaDoMes.ToShortDateString();
            textBoxFinal.Text = ultimoDiaDoMes.ToShortDateString();
            model get = new model();

            CarregarClientes();

        }

        private void radioButtonCliente_CheckedChanged(object sender, EventArgs e)
        {
            CarregarClientes();
        }

        private void CarregarClientes()
        {
            model get = new model();
            List<DtoCliente> ListClientes = get.getAllClientes();
            comboBoxNome.DataSource = null;
            comboBoxNome.ValueMember = "id";
            comboBoxNome.DisplayMember = "nome";
            comboBoxNome.DataSource = ListClientes;
        }

        private void radioButtonEntregador_CheckedChanged(object sender, EventArgs e)
        {
            CarregarMMotoristas();
        }

        private void CarregarMMotoristas()
        {
            model get = new model();
            List<DtoMotorista> ListMotorista = get.getAllMotorista();
            comboBoxNome.DataSource = null;
            comboBoxNome.ValueMember = "id";
            comboBoxNome.DisplayMember = "nome";
            comboBoxNome.DataSource = ListMotorista;
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            model get = new model();
            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.RefreshReport();

            List<DtoLancamento2> list = new List<DtoLancamento2>();
            int id_nome = Convert.ToInt16(comboBoxNome.SelectedValue);
            if (radioButtonCliente.Checked)
                list = get.getLancamentoFiltro("cliente", textBoxInicial.Text, textBoxFinal.Text, id_nome);
            else
                list = get.getLancamentoFiltro("entregador", textBoxInicial.Text, textBoxFinal.Text, id_nome);

            DtoEmpresa empresa = get.getEndEmpresa();

            ReportDataSource rs = new ReportDataSource();
            this.reportViewer1.LocalReport.DataSources.Add(rs);
            rs.Name = "DtoLancamento";
            rs.Value = list;
            this.reportViewer1.RefreshReport();
        }
    }
}
