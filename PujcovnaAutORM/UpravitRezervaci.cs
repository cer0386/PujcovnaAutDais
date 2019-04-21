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
    public partial class UpravitRezervaci : Form
    {
        public UpravitRezervaci()
        {
            InitializeComponent();
        }

        private void vlozitD_Click(object sender, EventArgs e)
        {
            if (datDo.Value.Date >= DatOd.Value.Date)
            {
                Rezervace rezervace = MenuF.rezervace;
                rezervace.vyzvednuti = DatOd.Value.Date;
                rezervace.vraceni = datDo.Value.Date;
                RezervaceTable.update(rezervace);
            }
            else
                MessageBox.Show("Nelze zadat datum vyzvednutí větší než datum vrácení");
        }
    }
}
