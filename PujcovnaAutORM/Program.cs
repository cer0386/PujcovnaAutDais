using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PujcovnaAutORM.ORM.mssql;
using PujcovnaAutORM.ORM;


namespace PujcovnaAutORM
{
    class Program
    {
        static void Main(string[] args)
        {
            Database db = new Database();
            db.Connect();

            DateTime dnes = new DateTime(2019, 4, 14);

            

            Auto a = new Auto();
            a.spz = "A123456";
            a.model = "Kombi";
            a.znacka = "Škoda";
            a.zakoupeno = new DateTime(2014, 6, 22);
            a.stk = new DateTime(2019, 12, 22);
            a.najeto = 22000.2m;
            a.servis = false;
            a.cena_za_den = 1200;

            AutoTable.insert(a, db);
            Console.WriteLine(new AutoTable().select(a.spz, db).toString());
            AutoTable.delete(a.spz, db);

            Auto a2 = new Auto();
            a2.spz = "B123456";
            a2.model = "Kombi";
            a2.znacka = "BWM";
            a2.zakoupeno = new DateTime(2010, 6, 22);
            a2.stk = new DateTime(2019, 4, 1);
            a2.najeto = 12000.2m;
            a.servis = true;
            a2.cena_za_den = 1600;

            Auto a3 = new Auto();
            a3.spz = "C123456";
            a3.model = "Dodávka";
            a3.znacka = "Ford";
            a3.zakoupeno = new DateTime(2018, 6, 22);
            a3.stk = new DateTime(2022, 12, 22);
            a3.najeto = 2000.4m;
            a.servis = false;
            a3.cena_za_den = 2000;

            Auto a4 = new Auto();
            a4.spz = "D123456";
            a4.model = "Sedan";
            a4.znacka = "BMW";
            a4.zakoupeno = new DateTime(2012, 7, 22);
            a4.stk = new DateTime(2019, 12, 22);
            a4.najeto = 40000;
            a.servis = false;
            a4.cena_za_den = 2200;

            Auto a5 = new Auto();
            a5.spz = "E123456";
            a5.model = "Dodávka";
            a5.znacka = "BMW";
            a5.zakoupeno = new DateTime(2016, 6, 22);
            a5.stk = new DateTime(2020, 1, 22);
            a5.najeto = 20000.2m;
            a.servis = false;
            a5.cena_za_den = 3200;

            Pozice p1 = new Pozice();
            p1.id_pozice = 1;
            p1.nazev = "Zaměstnanec";

            Pozice p2 = new Pozice();
            p2.id_pozice = 2;
            p2.nazev = "Manažer";

            Zamestnanec z = new Zamestnanec();
            z.jmeno = "Tonda";
            z.prijmeni = "Jonda";
            z.pozice = p1;

            Zamestnanec z2 = new Zamestnanec();
            z2.jmeno = "Juk";
            z2.prijmeni = "Bruk";
            z2.pozice = p2;


            Zakaznik zak = new Zakaznik();
            zak.cislo_RP = "123BD456";
            zak.jmeno = "Jarek";
            zak.prijmeni = "Morda";
            zak.mesto = "Ostrava";
            zak.ulice = "Rudná";
            zak.cislo_popisne = 44;
            zak.psc = 70020;
            zak.email = "joroZoro@gmail.com";

            Zakaznik zak2 = new Zakaznik();
            zak2.cislo_RP = "223BD456";
            zak2.jmeno = "Pavel";
            zak2.prijmeni = "Konva";
            zak2.mesto = "Ostrava";
            zak2.ulice = "Rudná";
            zak2.cislo_popisne = 55;
            zak2.psc = 70020;
            zak2.email = "konvaP@gmail.com";

            Zakaznik zak3 = new Zakaznik();
            zak3.cislo_RP = "323BD456";
            zak3.jmeno = "Karel";
            zak3.prijmeni = "Kvadlibuk";
            zak3.mesto = "Třinec";
            zak3.ulice = "Alešova";
            zak3.cislo_popisne = 100;
            zak3.psc = 70020;
            zak3.email = "kajmanKKK@gmail.com";

            Typ_platby tp = new Typ_platby();
            tp.id_typ_platby = 1;
            tp.zpusob_platby = "Karta";

            Typ_platby tp2 = new Typ_platby();
            tp2.id_typ_platby = 2;
            tp2.zpusob_platby = "Hotovost";

            Typ_platby tp3 = new Typ_platby();
            tp3.id_typ_platby = 3;
            tp3.zpusob_platby = "Převod";


            Servis s = new Servis();
            s.poradi_s = 1;
            s.od = new DateTime(2019, 4, 15);
            s.do_ = new DateTime(2019, 4, 18);

            Rezervace r1 = new Rezervace();
            r1.cislo_rezervace = 1; //select na pocet rez v db
            

            Rezervovano re11 = new Rezervovano();

            Rezervovano re12 = new Rezervovano();

            Faktura f1 = new Faktura();

            Platba pl1 = new Platba();


            Console.ReadLine();
        }
    }
}
