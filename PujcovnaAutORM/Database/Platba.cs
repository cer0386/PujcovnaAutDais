using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PujcovnaAutORM.ORM
{
    public class Platba
    {
        public int id_platba { get; set; }
        public Faktura faktura { get; set; }
        public Typ_platby typ_platby { get; set; }
        public int castka { get; set; }

        public int cislo_f { get; set; }
        public int typ_pl { get; set; }

        public string toString()
        {
            return this.id_platba.ToString() + " " + this.faktura.cislo_faktury.ToString() +
                " " + typ_platby.id_typ_platby.ToString() + " " + this.castka.ToString(); 
        }
    }
}
