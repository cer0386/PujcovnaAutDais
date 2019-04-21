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
    public partial class NovaRezervace : Form
    {
        Rezervace rezervace = new Rezervace();
        BindingSource binding = new BindingSource();
        Collection<Auto> auta = new Collection<Auto>();
        Collection<string> autaR = new Collection<string>();
        Zakaznik zakaznik = new Zakaznik();
        Rezervovano rezervovano = new Rezervovano();
        DataGridViewRow radek;

        public NovaRezervace()
        {
            InitializeComponent();
        }

        private void NovaRezervace_Load(object sender, EventArgs e)
        {
            rekapR.Items.Add("Datum vyzvednutí");
            rekapR.Items.Add("");
            rekapR.Items.Add("Datum vrácení");
            rekapR.Items.Add("");
            rekapR.Items.Add("Řidičský průkaz");
            rekapR.Items.Add("");
            rekapR.Items.Add("Jméno a přijmení");
            rekapR.Items.Add("");
            rekapR.Items.Add("Auta na rezervaci");

            dostupnaAuta.ColumnCount = 5;
            dostupnaAuta.Columns[0].Name = "SPZ";
            dostupnaAuta.Columns[1].Name = "Model";
            dostupnaAuta.Columns[2].Name = "Značka";
            dostupnaAuta.Columns[3].Name = "Najeto";
            dostupnaAuta.Columns[4].Name = "Cena/den";
            rezervace.cislo_rezervace = -1;

        }

        private void DatOd_ValueChanged(object sender, EventArgs e)
        {

        }

        private void datDo_ValueChanged(object sender, EventArgs e)
        {

        }

        private void vlozitD_Click(object sender, EventArgs e)
        {
            if (datDo.Value.Date >= DatOd.Value.Date)
            {
                if(DatOd.Value.Date >= DateTime.Now.Date)
                {
                    rezervace.vyzvednuti = DatOd.Value.Date;
                    rezervace.vraceni = datDo.Value.Date;

                    rekapR.Items.RemoveAt(1);
                    rekapR.Items.Insert(1, DatOd.Value.Date);
                    rekapR.Items.RemoveAt(3);
                    rekapR.Items.Insert(3, datDo.Value.Date);

                    auta = new AutoTable().select(DatOd.Value.Date, datDo.Value.Date);
                    foreach(Auto a in auta)
                    {
                        dostupnaAuta.Rows.Add(a.spz, a.model, a.znacka, a.najeto, a.cena_za_den);
                    }
                }
                else
                    MessageBox.Show("Nelze zadat datum vyzvednutí v minulosti...");

            }
            else
                MessageBox.Show("Nelze zadat datum vyzvednutí větší než datum vrácení");
            

        }

        private void pridatZakB_Click(object sender, EventArgs e)
        {
            string cisloR = cisloRPText.Text;

            if (new ZakaznikTable().select(cisloR) != null)
            {
                zakaznik = new ZakaznikTable().select(cisloR);
                rezervace.cislo_rp = cisloR;
                rekapR.Items.RemoveAt(5);
                rekapR.Items.Insert(5, cisloR);
                rekapR.Items.RemoveAt(7);
                rekapR.Items.Insert(7, zakaznik.CeleJmeno);

                pridatZakB.Enabled = false;
                odebratZakB.Enabled = true;
            }
            else
                MessageBox.Show("Takový zákazník není v systému");



        }

        private void odebratZakB_Click(object sender, EventArgs e)
        {

            string cisloR = cisloRPText.Text;

            if (new ZakaznikTable().select(cisloR) != null)
            {
                zakaznik = new ZakaznikTable().select(cisloR);
                rezervace.cislo_rp = cisloR;
                rekapR.Items.RemoveAt(5);
                rekapR.Items.Insert(5, "");
                rekapR.Items.RemoveAt(7);
                rekapR.Items.Insert(7, "");

                pridatZakB.Enabled = false;
                odebratZakB.Enabled = true;
            }
            else
                MessageBox.Show("Takový zákazník není v systému");

            pridatZakB.Enabled = true;
            odebratZakB.Enabled = false;
        }

        private void vytvoritRezB_Click(object sender, EventArgs e)
        {
            if(rezervace.cislo_rp == null || rezervace.vyzvednuti == null || rezervace.vraceni == null)
            {
                MessageBox.Show("Nedostatek dat na rezervaci");
            }
            else
            {
                rezervace.id_zam = Login.zamestnanec.id_zamestnance;
                RezervaceTable.insert(rezervace);
                rezervace.cislo_rezervace = new RezervaceTable().selectMax();
                rezervovano.ciclo_r = rezervace.cislo_rezervace;
                vytvoritRezB.Enabled = false;
            }
            
        }

        private void rekapR_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void pridatAutoB_Click(object sender, EventArgs e)
        {
            if(rezervace.cislo_rezervace == -1)
                MessageBox.Show("Nebyla vytvořena rezervace");
            else
            {          
                if (radek == null)
                    MessageBox.Show("Nebylo vybráno auto");
                else
                {        
                    string spz = radek.Cells[0].Value.ToString();
                    Auto a = new AutoTable().select(spz);

                    if (!autaR.Contains(spz))
                    {
                        autaR.Add(spz);
                        rezervovano.auto_spz = a.spz;
                        RezervovanoTable.insert(rezervovano);
                        rekapR.Items.Add(a.spz);
                    }
                    else
                        MessageBox.Show("Auto je na rezervaci");
                }
            }

        }

        private void dostupnaAuta_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
                radek = dostupnaAuta.Rows[e.RowIndex];
        }
        private void dostupnaAuta_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >=0)
                radek = dostupnaAuta.Rows[e.RowIndex];
        }

        private void odebratAutoB_Click(object sender, EventArgs e)
        {
            if (rekapR.SelectedIndex >= 9)
            {
                string spz = rekapR.SelectedItem.ToString();

                if (autaR.Contains(spz))
                {
                    rezervovano.auto_spz = spz;
                    autaR.Remove(spz);
                    rekapR.Items.Remove(spz);
                    RezervovanoTable.delete(rezervovano.ciclo_r, rezervovano.auto_spz);
                }               
            }
        }
    }
}
