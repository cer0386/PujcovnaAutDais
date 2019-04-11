using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PujcovnaAutORM.Database
{
    public class Rezervace
    {
        public int cislo_rezervace { get; set; }
        public Zakaznik zakaznik { get; set; }
        public Zakaznik zamestnanec { get; set; }
        public DateTime vyzvednuti { get; set; }
        public DateTime vraceni { get; set; }
        
        public string toString()
        {
            return this.cislo_rezervace.ToString() + " " + this.zakaznik.cislo_RP + " " +
                this.zamestnanec.id_zamestnance + " " + this.vyzvednuti.ToString() + " " +
                this.vraceni.ToString();
        }
    }
}
