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
            fr.Show();
        }

        private void parametrosToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            FrmEmpresa fr = new FrmEmpresa();
            fr.Show();
        }

        private void destinosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmDestino frD = new FrmDestino();
            frD.Show();
        }

        private void importarArquivoDeRotasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmImport fr = new FrmImport();
            fr.Show();
        }

        private void motoristasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmMotorista fr = new FrmMotorista();
            fr.Show();
        }

        private void cidadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCidade fr = new FrmCidade();
            fr.Show();
        }

        private void estadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmEstado fr = new FrmEstado();
            fr.Show();
        }

        private void veículoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmVeiculo fr = new FrmVeiculo();
            fr.Show();
        }

        private void BtnCliente_Click(object sender, EventArgs e)
        {
            FrmCliente fr = new FrmCliente();
            fr.Show();
        }

        private void bntVeiculo_Click(object sender, EventArgs e)
        {
            FrmVeiculo fr = new FrmVeiculo();
            fr.Show();
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            FrmImport fr = new FrmImport();
            fr.Show();
        }
    }
}
