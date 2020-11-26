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
    public partial class FrmMenu : Form
    {
        public FrmMenu()
        {
            InitializeComponent();
        }
        #region menu

        #endregion

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCliente fr = new FrmCliente();
            fr.ShowDialog();
        }

        private void parametrosToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            FrmEmpresa fr = new FrmEmpresa();
            fr.ShowDialog();
        }

        private void destinosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmDestino frD = new FrmDestino();
            frD.ShowDialog();
        }

        private void importarArquivoDeRotasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmImport fr = new FrmImport();
            fr.ShowDialog();
        }

        private void motoristasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmMotorista fr = new FrmMotorista();
            fr.ShowDialog();
        }

        private void cidadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCidade fr = new FrmCidade();
            fr.ShowDialog();
        }

        private void estadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmEstado fr = new FrmEstado();
            fr.ShowDialog();
        }

        private void veículoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmVeiculo fr = new FrmVeiculo();
            fr.ShowDialog();
        }

        private void BtnCliente_Click(object sender, EventArgs e)
        {
            FrmCliente fr = new FrmCliente();
            fr.ShowDialog();
        }

        private void bntVeiculo_Click(object sender, EventArgs e)
        {
            FrmVeiculo fr = new FrmVeiculo();
            fr.ShowDialog();
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            FrmImport fr = new FrmImport();
            fr.ShowDialog();
        }

        private void lançamentosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLancamento fr = new frmLancamento();
            fr.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmLancamento fr = new frmLancamento();
            fr.ShowDialog();
        }

        private void clientesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Relatorio.FrmRelCliente fr = new Relatorio.FrmRelCliente();
            fr.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrmMotorista fr = new FrmMotorista();
            fr.ShowDialog();
        }

        private void btnDestinos_Click(object sender, EventArgs e)
        {
            FrmDestino frD = new FrmDestino();
            frD.ShowDialog();
        }

        private void movimentaçãoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Relatorio.FrmRelLancamentos fr = new Relatorio.FrmRelLancamentos();
            fr.ShowDialog();
        }
    }
}
