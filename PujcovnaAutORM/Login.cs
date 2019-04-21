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
    public partial class Login : Form
    {
        public static Zamestnanec zamestnanec { get; set; }
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (new ZamestnanecTable().select(idZam.Text) != null)
            {
                zamestnanec = new ZamestnanecTable().select(idZam.Text);
                MenuF menu = new MenuF();
                menu.Show();
                this.Close();
            }
                
            else
                MessageBox.Show("Takový zaměstnanec neexistuje");
        }

    }
}
