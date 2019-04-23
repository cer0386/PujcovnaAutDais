using PujcovnaAutORM.ORM;
using PujcovnaAutORM.ORM.mssql;
using System;
using System.Collections.ObjectModel;
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
    public partial class NovyZam : Form
    {
        Zamestnanec zamestnanec = new Zamestnanec();
        public NovyZam()
        {
            InitializeComponent();
        }

        private void novyZamB_Click(object sender, EventArgs e)
        {
            zamestnanec.jmeno = jmenoText.Text;
            zamestnanec.prijmeni = prijmeniText.Text;

            if(jmeno.Text != null && jmenoText.Text != "")
            {
                if (prijmeniText.Text != null && prijmeniText.Text != "")
                {
                    if (poziceCB.Text != null && poziceCB.Text != "")
                    {
                        zamestnanec.pozice = new PoziceTable().select(poziceCB.Text);
                        zamestnanec.id_Pozice = zamestnanec.pozice.id_pozice;
                        int status = ZamestnanecTable.insert(zamestnanec);
                        if (status >= 0)
                        {
                            MessageBox.Show("Zaměstnanec úspěšně vytvořen");
                        }
                        else
                            MessageBox.Show("Chyba při vytváření nového zaměstnance");
                    }
                    else
                        MessageBox.Show("Je potřeba vybrat pozici zaměstnance");
                }
                else
                    MessageBox.Show("Je potřeba zadat příjmení zaměstnance");
            }
            else
                MessageBox.Show("Je potřeba zadat jméno zaměstnance");
        }

        private void NovyZam_Load(object sender, EventArgs e)
        {
            Collection<Pozice> poz = new PoziceTable().select();
            foreach(Pozice p in poz)
            {
                poziceCB.Items.Add(p.nazev);
            }
        }
    }
}
