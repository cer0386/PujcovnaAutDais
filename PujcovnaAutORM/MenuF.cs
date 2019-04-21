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
    public partial class MenuF : Form
    {

        Collection<Rezervace> rezervaceNWeek = new Collection<Rezervace>();
        Collection<Rezervace> rezervace10 = new Collection<Rezervace>();
        Collection<Servis> servisy = new Collection<Servis>();
        public static Rezervace rezervace { get; set; }
        Faktura faktura = new Faktura();
        int rezervaceUpravit;

        public MenuF()
        {
            InitializeComponent();
        }

        private void Menu_Load(object sender, EventArgs e)
        {
            rezDalsiTyd.CellClick += new DataGridViewCellEventHandler(rezDalsiTyd_CellClick);
            rez10.CellClick += new DataGridViewCellEventHandler(rez10_CellClick);

            rezDalsiTyd.ColumnCount = 3;
            rezDalsiTyd.Columns[0].Name = "Číslo rezervace";
            rezDalsiTyd.Columns[1].Name = "Zákazník";
            rezDalsiTyd.Columns[2].Name = "Vrácení";

            rez10.ColumnCount = 3;
            rez10.Columns[0].Name = "Číslo rezervace";
            rez10.Columns[1].Name = "Zákazník";
            rez10.Columns[2].Name = "Vyzvednutí";

            detailRez.ColumnCount = 5;
            detailRez.Columns[0].Name = "Číslo rezervace";
            detailRez.Columns[1].Name = "Zákazník";
            detailRez.Columns[2].Name = "Zaměstnanec";
            detailRez.Columns[3].Name = "Vyzvednutí";
            detailRez.Columns[4].Name = "Vrácení";

            detailFak.ColumnCount = 4;
            detailFak.Columns[0].Name = "Číslo faktury";
            detailFak.Columns[1].Name = "Vytvořeno";
            detailFak.Columns[2].Name = "Potvrzeno";
            detailFak.Columns[3].Name = "Zaplaceno";

            autaNaRez.ColumnCount = 4;
            autaNaRez.Columns[0].Name = "SPZ";
            autaNaRez.Columns[1].Name = "Model";
            autaNaRez.Columns[2].Name = "Značka";
            autaNaRez.Columns[3].Name = "STK";

            servisyA.ColumnCount = 4;
            servisyA.Columns[0].Name = "Pořadí servisu";
            servisyA.Columns[1].Name = "SPZ";
            servisyA.Columns[2].Name = "Od";
            servisyA.Columns[3].Name = "Do";

            detailAuta.ColumnCount = 9;
            detailAuta.Columns[0].Name = "SPZ";
            detailAuta.Columns[1].Name = "Model";
            detailAuta.Columns[2].Name = "Znacka";
            detailAuta.Columns[3].Name = "Zakoupeno";
            detailAuta.Columns[4].Name = "STK";
            detailAuta.Columns[5].Name = "Nehody";
            detailAuta.Columns[6].Name = "Servis";
            detailAuta.Columns[7].Name = "Najeto";
            detailAuta.Columns[8].Name = "Cena/den";

            rezervaceNWeek = new RezervaceTable().selectNextWeek();
            rezervace10 = new RezervaceTable().selectTop10();
            

            foreach (Rezervace r in rezervaceNWeek)
            {
                rezDalsiTyd.Rows.Add(r.cislo_rezervace, r.zakaznik.cislo_RP, r.zamestnanec.id_zamestnance, r.vyzvednuti, r.vraceni);
            }
            foreach (Rezervace r in rezervace10)
            {
                rez10.Rows.Add(r.cislo_rezervace, r.zakaznik.cislo_RP, r.zamestnanec.id_zamestnance, r.vyzvednuti, r.vraceni);
            }

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label21_Click(object sender, EventArgs e)
        {

        }

        private void rezDalsiTyd_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow radek = this.rezDalsiTyd.Rows[e.RowIndex];
                int cisloR = Int32.Parse(radek.Cells[0].Value.ToString());
                rezervaceUpravit = cisloR;
                detailR(cisloR);
            }
        }
        private void rezDalsiTyd_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                DataGridViewRow radek = this.rezDalsiTyd.Rows[e.RowIndex];
                int cisloR = Int32.Parse(radek.Cells[0].Value.ToString());
                rezervaceUpravit = cisloR;
                detailR(cisloR);
            }
        }

        private void hledatRezB_Click(object sender, EventArgs e)
        {
            int cisloRezervace = (int)cisloRIn.Value;

            detailR(cisloRezervace);
        }

        private void novaRezB_Click(object sender, EventArgs e)
        {
            NovaRezervace nr = new NovaRezervace();
            nr.Show();
        }


        private void detailR(int cisloRezervace)
        {
            rezervace = new RezervaceTable().selectCollection(cisloRezervace);

            if (rezervace != null)
            {
                faktura = new FakturaTable().selectCRez(rezervace.cislo_rezervace);
                detailRez.Rows.Clear();
                detailFak.Rows.Clear();
                autaNaRez.Rows.Clear();
                object nZap = "";
                if (faktura.zaplaceno == null)
                {
                    nZap = (string)nZap;
                    nZap = "NEZAPLACENO";
                }
                else
                {

                    nZap = faktura.zaplaceno;
                }

                detailRez.Rows.Add(rezervace.cislo_rezervace, rezervace.zakaznik.cislo_RP, rezervace.id_zam, rezervace.vyzvednuti, rezervace.vraceni);
                detailFak.Rows.Add(faktura.cislo_faktury, faktura.vytvoreno, faktura.potvrzeno, nZap);
                foreach (Auto a in rezervace.autaNaRez)
                {
                    autaNaRez.Rows.Add(a.spz, a.model, a.znacka, a.stk);
                }
            }
        }

        private void rez10_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow radek = this.rez10.Rows[e.RowIndex];
                int cisloR = Int32.Parse(radek.Cells[0].Value.ToString());
                detailR(cisloR);
            }
        }

        private void rez10_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                DataGridViewRow radek = this.rez10.Rows[e.RowIndex];
                int cisloR = Int32.Parse(radek.Cells[0].Value.ToString());
                detailR(cisloR);
            }
            
        }

        private void upravitRezB_Click(object sender, EventArgs e)
        {

        }

        private void vyraditAutoB_Click(object sender, EventArgs e)
        {
            VyraditAuto vyradit = new VyraditAuto();
            vyradit.Show();
        }

        private void novyServisB_Click(object sender, EventArgs e)
        {
            NovyServis ns = new NovyServis();
            ns.Show();
        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void hledatAutoB_Click(object sender, EventArgs e)
        {
            string spz = autoText.Text;
            if(new AutoTable().select(spz) != null)
            {
                Auto a = new AutoTable().select(spz);
                detailAuta.Rows.Clear();
                servisyA.Rows.Clear();
                detailAuta.Rows.Add(a.spz, a.model, a.znacka, a.zakoupeno, a.stk, a.pocet_nehod, a.servis, a.najeto, a.cena_za_den);

                if (new ServisTable().select(spz) != null)
                {
                    servisy = new ServisTable().select(spz);
                    foreach (Servis s in servisy)
                    {
                        servisyA.Rows.Add(s.poradi_s, s.auto_spz, s.od, s.do_);
                    }
                }
            }
            else
                MessageBox.Show("Auto neexistuje");

        }
    }
}
