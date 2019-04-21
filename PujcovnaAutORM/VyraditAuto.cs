using PujcovnaAutORM.ORM;
using PujcovnaAutORM.ORM.mssql;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PujcovnaAutORM
{
    public partial class VyraditAuto : Form
    {
        Auto a;
        Collection<Auto> vyrAuta = new Collection<Auto>();
        Collection<Auto> nahrAuta = new Collection<Auto>();
        Collection<Auto> stkAuta = new Collection<Auto>();
        Collection<DateTime?> data;
        DataGridViewRow radek;
        DataGridViewRow radekVyr;

        DateTime dOd;
        DateTime dDo;

        public VyraditAuto()
        {
            InitializeComponent();
        }
        private void VyraditAuto_Load(object sender, EventArgs e)
        {
            vyrazenaA.CellClick += new DataGridViewCellEventHandler(vyrazenaA_CellClick);
            nahradniA.CellClick += new DataGridViewCellEventHandler(nahradniA_CellClick);

            hledaneAuto.ColumnCount = 3;
            hledaneAuto.Columns[0].Name = "SPZ";
            hledaneAuto.Columns[1].Name = "STK";
            hledaneAuto.Columns[2].Name = "Servis";

            vyrazenaA.ColumnCount = 3;
            vyrazenaA.Columns[0].Name = "SPZ";
            vyrazenaA.Columns[1].Name = "Model";
            vyrazenaA.Columns[2].Name = "Znacka";

            autaKVyr.ColumnCount = 4;
            autaKVyr.Columns[0].Name = "SPZ";
            autaKVyr.Columns[1].Name = "Model";
            autaKVyr.Columns[2].Name = "Znacka";
            autaKVyr.Columns[3].Name = "STK";

            nahradniA.ColumnCount = 6;
            nahradniA.Columns[0].Name = "SPZ";
            nahradniA.Columns[1].Name = "Model";
            nahradniA.Columns[2].Name = "Znacka";
            nahradniA.Columns[3].Name = "STK";
            nahradniA.Columns[4].Name = "Najeto";
            nahradniA.Columns[5].Name = "Cena/den";

            vyrAuta = new AutoTable().selectVyrAuta();
            vyrazenaA.Rows.Clear();
            foreach(Auto a in vyrAuta)
            {
                vyrazenaA.Rows.Add(a.spz, a.model, a.znacka);
            }
        }


        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (new AutoTable().select(spzText.Text) != null)
            {
                a = new AutoTable().select(spzText.Text);
                if (!a.servis)
                {
                    data = new AutoTable().vyrazeniAutaData(a.spz);

                    if (data[0] != null)
                    {
                        dOd = (DateTime)data[0];
                        dDo = (DateTime)data[1];
                        MessageBox.Show("Auto je potřeba nahradit");
                        nahrAuta = new AutoTable().select(dOd, dDo, a.cena_za_den, a.spz);
                        nahradniA.Rows.Clear();
                        foreach (Auto au in nahrAuta)
                        {
                            nahradniA.Rows.Add(au.spz, au.model, au.znacka, au.stk, au.najeto, au.cena_za_den);
                        }
                    }
                    else
                    {
                        a.servis = true;
                        AutoTable.update(a);
                        vyrAuta = new AutoTable().selectVyrAuta();
                        vyrazenaA.Rows.Clear();
                        foreach (Auto a in vyrAuta)
                        {
                            vyrazenaA.Rows.Add(a.spz, a.model, a.znacka);
                        }
                    }
                }
                else
                    MessageBox.Show("Auto je již vyřazeno");
            }
            else
                MessageBox.Show("Auto neexistuje");
            
                    
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(radek == null)
            {
                MessageBox.Show("Je potřeba vybrat auto");
            }
            else
            {
                string spz = radek.Cells[0].Value.ToString();
                int status = AutoTable.updateRez(a.spz, spz, dOd, dDo);
                if(status >= 0)
                {
                    MessageBox.Show("Úspěšně nahrazeno");
                }
                else
                    MessageBox.Show("Nenahrazeno");
            }
            

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void hledatB_Click(object sender, EventArgs e)
        {
            if(new AutoTable().select(spzText.Text)  != null)
            {
                a = new AutoTable().select(spzText.Text);
                nahradniA.Rows.Clear();
                hledaneAuto.Rows.Clear();
                hledaneAuto.Rows.Add(a.spz, a.model, a.znacka, a.servis);
                
            }
            else
                MessageBox.Show("Auto neexistuje");
        }

        private void nahradniA_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                radek = nahradniA.Rows[e.RowIndex];
            }
        }

        private void nahradniA_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                radek = nahradniA.Rows[e.RowIndex];
            }
        }

        private void zaraditB_Click(object sender, EventArgs e)
        {
            if (radekVyr == null)
            {
                MessageBox.Show("Je potřeba vybrat auto");
            }
            else
            {
                string spz = radekVyr.Cells[0].Value.ToString();
                Auto aZar = new AutoTable().select(spz);
                aZar.servis = false;
                int status = AutoTable.update(aZar);
                if (status >= 0)
                {
                    vyrAuta = new AutoTable().selectVyrAuta();
                    vyrazenaA.Rows.Clear();
                    foreach (Auto a in vyrAuta)
                    {
                        vyrazenaA.Rows.Add(a.spz, a.model, a.znacka);
                    }
                    MessageBox.Show("Úspěšně zařazeno");
                }
                else
                    MessageBox.Show("Nezařazeno");
            }
        }

        private void vyrazenaA_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                radekVyr = vyrazenaA.Rows[e.RowIndex];
            }
        }
        private void vyrazenaA_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                radekVyr = vyrazenaA.Rows[e.RowIndex];
            }
        }
    }
}
