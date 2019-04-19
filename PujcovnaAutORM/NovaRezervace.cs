using PujcovnaAutORM.ORM;
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
    public partial class NovaRezervace : Form
    {
        Rezervace rezervace = new Rezervace();
        BindingSource binding = new BindingSource();
        

        public NovaRezervace()
        {
            InitializeComponent();
        }

        private void NovaRezervace_Load(object sender, EventArgs e)
        {

        }

        private void DatOd_ValueChanged(object sender, EventArgs e)
        {

        }

        private void datDo_ValueChanged(object sender, EventArgs e)
        {

        }

        private void vlozitD_Click(object sender, EventArgs e)
        {

            if (datDo.Value < DatOd.Value)
                MessageBox.Show("Nelze zadat datum vyzvednutí větší než datum vrácení");
            else
            {
                rezervace.vyzvednuti = DatOd.Value;
                rezervace.vraceni = datDo.Value;
                binding.DataSource = rezervace;
                rekapRez.DataSource = binding;
            }
                
            

        }
    }
}
