using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PujcovnaAutORM.ORM.mssql;
using PujcovnaAutORM.ORM;
using System.Collections;
using System.Collections.ObjectModel;
using System.Windows.Forms;

namespace PujcovnaAutORM
{

    class Program
    {
        static void Main(string[] args)
        {

            Database db = new Database();
            db.Connect();

            Auto a = new Auto();
            a.spz = "A123456";
            a.model = "Kombi";
            a.znacka = "Škoda";
            a.zakoupeno = new DateTime(2014, 6, 22);
            a.stk = new DateTime(2019, 12, 22);
            a.najeto = 22000.2m;
            a.servis = false;
            a.cena_za_den = 1200;

            Console.WriteLine("Test výpisu vložených aut");
            AutoTable.insert(a, db);
            Console.WriteLine(new AutoTable().select(a.spz, db).toString());

            Auto a2 = new Auto();
            a2.spz = "B123456";
            a2.model = "Kombi";
            a2.znacka = "BWM";
            a2.zakoupeno = new DateTime(2010, 6, 22);
            a2.stk = new DateTime(2019, 4, 1);
            a2.najeto = 12000.2m;
            a.servis = true;
            a2.cena_za_den = 1600;

            AutoTable.insert(a2, db);
            Console.WriteLine(new AutoTable().select(a2.spz, db).toString());

            Auto a3 = new Auto();
            a3.spz = "C123456";
            a3.model = "Dodávka";
            a3.znacka = "Ford";
            a3.zakoupeno = new DateTime(2018, 6, 22);
            a3.stk = new DateTime(2022, 12, 22);
            a3.najeto = 2000.4m;
            a.servis = false;
            a3.cena_za_den = 2000;

            AutoTable.insert(a3, db);
            Console.WriteLine(new AutoTable().select(a3.spz, db).toString());

            Auto a4 = new Auto();
            a4.spz = "D123456";
            a4.model = "Sedan";
            a4.znacka = "BMW";
            a4.zakoupeno = new DateTime(2012, 7, 22);
            a4.stk = new DateTime(2019, 12, 22);
            a4.najeto = 40000;
            a.servis = false;
            a4.cena_za_den = 2200;

            AutoTable.insert(a4, db);
            Console.WriteLine(new AutoTable().select(a4.spz, db).toString());

            Auto a5 = new Auto();
            a5.spz = "E123456";
            a5.model = "Dodávka";
            a5.znacka = "BMW";
            a5.zakoupeno = new DateTime(2016, 6, 22);
            a5.stk = new DateTime(2020, 1, 22);
            a5.najeto = 20000.2m;
            a.servis = false;
            a5.cena_za_den = 3200;

            AutoTable.insert(a5, db);
            Console.WriteLine(new AutoTable().select(a5.spz, db).toString());


            Console.WriteLine("\n---------------------------------------------------------------------------\n");
            //Pozice-------------------------------------------------------------------------------------------
            Pozice p1 = new Pozice();
            p1.id_pozice = 1;
            p1.nazev = "Zaměstnanec";

            Pozice p2 = new Pozice();
            p2.id_pozice = 2;
            p2.nazev = "Manažer";

            Console.WriteLine("Test výpisu vložených pozic");
            PoziceTable.insert(p1, db);
            Console.WriteLine(new PoziceTable().select(p1.id_pozice, db).toString());
            PoziceTable.insert(p2, db);
            Console.WriteLine(new PoziceTable().select(p2.id_pozice, db).toString());


            Console.WriteLine("\n---------------------------------------------------------------------------\n");
            //Zaměstnanci
            Zamestnanec z = new Zamestnanec();
            z.jmeno = "Tonda";
            z.prijmeni = "Jonda";
            z.pozice = p1;
            z.id_Pozice = p1.id_pozice;

            Console.WriteLine("Test výpisu vložených zaměstnanců");
            ZamestnanecTable.insert(z);
            Console.WriteLine(new ZamestnanecTable().select("jon000", db).toString());

            Zamestnanec z2 = new Zamestnanec();
            z2.jmeno = "Juk";
            z2.prijmeni = "Jonda";
            z2.pozice = p2;
            z2.id_Pozice = p2.id_pozice;

            ZamestnanecTable.insert(z2);
            Console.WriteLine(new ZamestnanecTable().select("jon001", db).toString());

            Console.WriteLine("\n---------------------------------------------------------------------------\n");
            //Zákazníci
            Zakaznik zak = new Zakaznik();
            zak.cislo_RP = "123BD456";
            zak.jmeno = "Jarek";
            zak.prijmeni = "Morda";
            zak.mesto = "Ostrava";
            zak.ulice = "Rudná";
            zak.cislo_popisne = 44;
            zak.psc = 70020;
            zak.email = "joroZoro@gmail.com";

            Console.WriteLine("Test výpisu vložených zákazníků");
            ZakaznikTable.insert(zak);
            Console.WriteLine(new ZakaznikTable().select(zak.cislo_RP, db).toString());

            Zakaznik zak2 = new Zakaznik();
            zak2.cislo_RP = "223BD456";
            zak2.jmeno = "Pavel";
            zak2.prijmeni = "Konva";
            zak2.mesto = "Ostrava";
            zak2.ulice = "Rudná";
            zak2.cislo_popisne = 55;
            zak2.psc = 70020;
            zak2.email = "konvaP@gmail.com";

            ZakaznikTable.insert(zak2);
            Console.WriteLine(new ZakaznikTable().select(zak2.cislo_RP, db).toString());


            Console.WriteLine("\n---------------------------------------------------------------------------\n");
            //Typy platby
            Typ_platby tp = new Typ_platby();
            tp.id_typ_platby = 1;
            tp.zpusob_platby = "Karta";

            Console.WriteLine("Test výpisu vložených typů platby");
            Typ_platbyTable.insert(tp);
            Console.WriteLine(new Typ_platbyTable().select(tp.id_typ_platby, db).toString());

            Typ_platby tp2 = new Typ_platby();
            tp2.id_typ_platby = 2;
            tp2.zpusob_platby = "Hotovost";

            Typ_platbyTable.insert(tp2);
            Console.WriteLine(new Typ_platbyTable().select(tp2.id_typ_platby, db).toString());

            Typ_platby tp3 = new Typ_platby();
            tp3.id_typ_platby = 3;
            tp3.zpusob_platby = "Převod";

            Typ_platbyTable.insert(tp3);
            Console.WriteLine(new Typ_platbyTable().select(tp3.id_typ_platby, db).toString());


            Console.WriteLine("\n---------------------------------------------------------------------------\n");
            //Servis
            Servis s = new Servis();
            s.poradi_s = 1;
            s.auto_spz = a.spz;
            s.auto = a;
            s.od = new DateTime(2019, 4, 15);
            s.do_ = new DateTime(2019, 4, 18);

            Console.WriteLine("Test výpisu vložených servisů");
            ServisTable.insert(s);
            Console.WriteLine(new ServisTable().select(s.poradi_s, db).toString());


            Console.WriteLine("\n---------------------------------------------------------------------------\n");
            //Rezervace
            Rezervace r1 = new Rezervace();
            r1.cislo_rp = zak.cislo_RP;
            r1.id_zam = "jon000";
            r1.vyzvednuti = new DateTime(2019, 03, 1);
            r1.vraceni = new DateTime(2019, 03, 20);

            RezervaceTable.insert(r1);
            r1.cislo_rezervace = new RezervaceTable().selectMax(db);

            Rezervace r2 = new Rezervace();
            r2.cislo_rp = zak.cislo_RP;
            r2.id_zam = "jon001";
            r2.vyzvednuti = new DateTime(2019, 04, 1);
            r2.vraceni = new DateTime(2019, 04, 20);

            RezervaceTable.insert(r2);
            r2.cislo_rezervace = new RezervaceTable().selectMax(db);

            Console.WriteLine("Test výpisu vložených rezervací");

            Console.WriteLine(new RezervaceTable().select(r1.cislo_rezervace, db).toString());

            Console.WriteLine(new RezervaceTable().select(r2.cislo_rezervace, db).toString());

            Console.WriteLine("\n---------------------------------------------------------------------------\n");
            //Auta na rezervaci
            Rezervovano re11 = new Rezervovano();
            re11.auto_spz = a5.spz;
            re11.ciclo_r = r1.cislo_rezervace;
            Rezervovano re12 = new Rezervovano();
            re12.auto_spz = a4.spz;
            re12.ciclo_r = r1.cislo_rezervace;

            Rezervovano re21 = new Rezervovano();
            re21.auto_spz = a4.spz;
            re21.ciclo_r = r2.cislo_rezervace;
            Console.WriteLine("Test výpisu vložených aut na rezervaci");

            RezervovanoTable.insert(re11);
            RezervovanoTable.insert(re12);
            Collection<Rezervovano> r = new RezervovanoTable().select(r1.cislo_rezervace, db);
            foreach (Rezervovano item in r)
            {
                Console.WriteLine(item.toString());
            }

            RezervovanoTable.insert(re21);
            r.Clear();
            r = new RezervovanoTable().select(r2.cislo_rezervace, db);
            foreach (Rezervovano item in r)
            {
                Console.WriteLine(item.toString());
            }

            Console.WriteLine("\n---------------------------------------------------------------------------\n");
            //Faktura
            Faktura f1 = new Faktura();
            f1.cislo_faktury = 1;
            f1.cislo_r = r1.cislo_rezervace;
            f1.vytvoreno = new DateTime(2019, 3, 1);
            f1.potvrzeno = f1.vytvoreno;
            f1.zaplaceno = null;

            Faktura f2 = new Faktura();
            f2.cislo_faktury = 2;
            f2.cislo_r = r2.cislo_rezervace;
            f2.vytvoreno = new DateTime(2019, 4, 1);
            f2.potvrzeno = f1.vytvoreno;
            f2.zaplaceno = new DateTime(2019, 4, 10);

            Console.WriteLine("Test výpisu vložených faktur");
            FakturaTable.insert(f1);
            Console.WriteLine(new FakturaTable().select(1, db).toString());
            FakturaTable.insert(f2);
            Console.WriteLine(new FakturaTable().select(2, db).toString());

            Console.WriteLine("\n---------------------------------------------------------------------------\n");
            //Platba
            Platba pl1 = new Platba();
            pl1.id_platba = 1;
            pl1.typ_pl = 2;

            pl1.cislo_f = f2.cislo_faktury;
            pl1.castka = 6000;

            Console.WriteLine("Test výpisu vložených plateb");
            PlatbaTable.insert(pl1);
            Console.WriteLine(new PlatbaTable().select(1, db).toString());

            Console.WriteLine("\n---------------------------------------------------------------------------\n");
            Console.WriteLine("\n---------------------------------------------------------------------------\n");
            Console.WriteLine("\n---------------------------------------------------------------------------\n");
            Console.WriteLine("\n---------------------------------------------------------------------------\n");
            //seznamy
            Console.WriteLine("Seznam všech zákazníků, seřazených dle jména");
            Collection<Zakaznik> zakazniks = new ZakaznikTable().select(db);
            foreach (Zakaznik item in zakazniks)
            {
                Console.WriteLine(item.toString());
            }
            Console.WriteLine("\n---------------------------------------------------------------------------\n");
            Console.WriteLine("Seznam rezervací končící následující týden");
            Collection<Rezervace> rezervaces = new RezervaceTable().selectNextWeek(db);
            foreach (Rezervace item in rezervaces)
            {
                Console.WriteLine(item.toString());
            }
            Console.WriteLine("\n---------------------------------------------------------------------------\n");
            Console.WriteLine("\n---------------------------------------------------------------------------\n");
            Console.WriteLine("Seznam zákazníkových rezervací podle data sestupně");
            rezervaces.Clear();
            rezervaces = new RezervaceTable().selectZak(zak.cislo_RP, db);
            foreach (Rezervace item in rezervaces)
            {
                Console.WriteLine(item.toString());
            }
            Console.WriteLine("\n---------------------------------------------------------------------------\n");
            Console.WriteLine("Seznam rezervací sjednané zaměstnancem");
            rezervaces.Clear();
            rezervaces = new RezervaceTable().selectZam("jon000", db);
            foreach (Rezervace item in rezervaces)
            {
                Console.WriteLine(item.toString());
            }
            Console.WriteLine("\n---------------------------------------------------------------------------\n");
            Console.WriteLine("Seznam rezervací auta");
            rezervaces.Clear();
            rezervaces = new RezervaceTable().selectAuto(a5.spz, db);
            foreach (Rezervace item in rezervaces)
            {
                Console.WriteLine(item.toString());
            }
            Console.WriteLine("\n---------------------------------------------------------------------------\n");
            Console.WriteLine("\n---------------------------------------------------------------------------\n");
            Console.WriteLine("Seznam zaměstnanců s jejich počtem sjednaných rezervací");
            Collection<Zamestnanec> zamestnanecs = new ZamestnanecTable().select(db);
            foreach (Zamestnanec item in zamestnanecs)
            {
                Console.WriteLine(item.toString());
            }
            Console.WriteLine("\n---------------------------------------------------------------------------\n");
            Console.WriteLine("\n---------------------------------------------------------------------------\n");
            Console.WriteLine("Seznam dostupných aut podle intervalu");
            Collection<Auto> autos = new AutoTable().select(new DateTime(2019, 5, 1), new DateTime(2019, 5, 20), db);
            foreach (Auto item in autos)
            {
                Console.WriteLine(item.toString());
            }
            Console.WriteLine("\n---------------------------------------------------------------------------\n");
            Console.WriteLine("\n---------------------------------------------------------------------------\n");
            Console.WriteLine("Seznam faktur zákazníka");
            Collection<Faktura> fakturas = new FakturaTable().selectZakaznikovy(zak.cislo_RP, db);
            foreach (Faktura item in fakturas)
            {
                Console.WriteLine(item.toString());
            }
            Console.WriteLine("\n---------------------------------------------------------------------------\n");
            Console.WriteLine("Seznam nezaplacených faktur");
            fakturas.Clear();
            fakturas = new FakturaTable().selectNezaplace(db);
            foreach (Faktura item in fakturas)
            {
                Console.WriteLine(item.toString());
            }
            Console.WriteLine("\n---------------------------------------------------------------------------\n");
            Console.WriteLine("\n---------------------------------------------------------------------------\n");
            Console.WriteLine("Seznam plateb podle typu platby za poslední měsíc");
            /*Console.WriteLine(new PlatbaTable().select(pl1.id_platba));
            Collection<Zakaznik> zakazniks = new ZakaznikTable().select(db);
            foreach (Zakaznik item in zakazniks)
            {
                Console.WriteLine(item.toString());
            }*/
            Console.WriteLine("\n---------------------------------------------------------------------------\n");
            Console.WriteLine("\n---------------------------------------------------------------------------\n");
            Console.WriteLine("Seznam servisů pro určité auto");
            Collection<Servis> servis = new ServisTable().select(a.spz, db);
            foreach (Servis item in servis)
            {
                Console.WriteLine(item.toString());
            }
            Console.WriteLine("\n---------------------------------------------------------------------------\n");
            Console.WriteLine("\n---------------------------------------------------------------------------\n");
            Console.WriteLine("Seznam aut na rezervaci");
            /*Console.WriteLine(new RezervovanoTable().select(r1.cislo_rezervace, db));
            Collection<Zakaznik> zakazniks = new ZakaznikTable().select(db);
            foreach (Zakaznik item in zakazniks)
            {
                Console.WriteLine(item.toString());
            }*/
            Console.WriteLine("\n---------------------------------------------------------------------------\n");


            //Procedury a funkce
            Console.WriteLine("Nová rezervace");

            Console.WriteLine("\n---------------------------------------------------------------------------\n");
            Console.WriteLine("Vyřazení auta");

            Console.WriteLine("\n---------------------------------------------------------------------------\n");

            Console.WriteLine("Nový servis");

            Application.Run(new Menu());

            //Delete testovacích záznamů vytvořených zde
            ServisTable.delete(s.poradi_s, db);
            //platby
            Typ_platbyTable.delete(tp.id_typ_platby, db);
            Typ_platbyTable.delete(tp2.id_typ_platby, db);
            Typ_platbyTable.delete(tp3.id_typ_platby, db);
            PlatbaTable.delete(pl1.id_platba);
            FakturaTable.delete(f1.cislo_faktury, db);
            FakturaTable.delete(f2.cislo_faktury, db);
            //rezervovano
            RezervovanoTable.delete(re11.ciclo_r);
            RezervovanoTable.delete(re21.ciclo_r);
            //rezervace

            RezervaceTable.delete(r1.cislo_rezervace,db);
            RezervaceTable.delete(r2.cislo_rezervace, db);
            AutoTable.delete(a.spz, db);
            AutoTable.delete(a2.spz, db);
            AutoTable.delete(a3.spz, db);
            AutoTable.delete(a4.spz, db);
            AutoTable.delete(a5.spz, db);

            ZamestnanecTable.delete("jon000", db);
            ZamestnanecTable.delete("jon001", db);
            PoziceTable.delete(p1.id_pozice, db);
            PoziceTable.delete(p2.id_pozice, db);

            ZakaznikTable.delete(zak.cislo_RP, db);
            ZakaznikTable.delete(zak2.cislo_RP, db);
           

            

            Console.ReadLine();
        }
    }
}
