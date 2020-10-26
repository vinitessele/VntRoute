using Npgsql;
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
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void bntCancelar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void bntLogin_Click(object sender, EventArgs e)
        {
            try
            {
                NpgsqlConnection conn = new NpgsqlConnection("Server=localhost;Port=5432; User Id=postgres;Password=123456; Database=postgres;");
                conn.Open();

                NpgsqlCommand cmd = new NpgsqlCommand("Select * from usuario where login= '" + textBoxUsuario.Text + "' and senha = '" + textBoxSenha.Text + "'", conn);
                NpgsqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    FrmMenu fr2 = new FrmMenu();
                    fr2.Show();
                    this.Hide();
                }
                dr.Close();
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
