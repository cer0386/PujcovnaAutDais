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
    public partial class NovyServis : Form
    {
        public Servis servis = new Servis();
        public NovyServis()
        {
            InitializeComponent();
        }

        private void servisB_Click(object sender, EventArgs e)
        {
            servis.auto_spz = spzText.Text;
            if (new AutoTable().select(servis.auto_spz) != null)
            {
                if (datDo.Value.Date >= datOd.Value.Date)
                {               
                    servis.od = datOd.Value.Date;
                    servis.do_ = datDo.Value.Date;
                    int status = ServisTable.novyServis(servis.auto_spz, datOd.Value.Date, datDo.Value.Date);
                    if(status == 0)
                    {
                        MessageBox.Show("Auto má naplánovanou rezervaci, je třeba jej nahradit!");
                    }
                    else if(status == 12)
                    {
                        MessageBox.Show("Vytvoření nového servisu selhalo");
                    }
                    else if(status == 1 || status == 2)
                    {
                        MessageBox.Show("Nový servis byl vytvořen");
                    }
                }
                else
                    MessageBox.Show("Nelze zadat datum \"OD\" větší než datum \"DO\"");
            }
            else
                MessageBox.Show("Takové auto neexistuje");


        }

        private void vyraditB_Click(object sender, EventArgs e)
        {
            VyraditAuto va = new VyraditAuto();
            va.Show();
        }
    }
}
