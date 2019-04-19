using PujcovnaAutORM.ORM;
using PujcovnaAutORM.ORM.mssql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PujcovnaAutORM
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void label21_Click(object sender, EventArgs e)
        {

        }

        private void rezDalsiTyd_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void RezDalsiTyd_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void hledatRezB_Click(object sender, EventArgs e)
        {
            int cisloRezervace = (int)cisloRIn.Value;

            Rezervace rezervace = new RezervaceTable().select(cisloRezervace);

            BindingSource binding = new BindingSource();
            binding.DataSource = rezervace;

            detailRez.DataSource = binding;
        }

        private void novaRezB_Click(object sender, EventArgs e)
        {
            NovaRezervace nr = new NovaRezervace();
            nr.Show();
        }
    }
}
