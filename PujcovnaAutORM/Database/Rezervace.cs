using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PujcovnaAutORM.ORM
{
    public class Rezervace
    {
        public int cislo_rezervace { get; set; }
        public Zakaznik zakaznik { get; set; }
        public Zamestnanec zamestnanec { get; set; }
        public DateTime vyzvednuti { get; set; }
        public DateTime vraceni { get; set; }
        
        public ICollection<Auto> autaNaRez { get; set; }

        public string cislo_rp { get; set; }
        public string id_zam { get; set; }

        public string toString()
        {
            return this.cislo_rezervace.ToString() + " " + this.zakaznik.cislo_RP + " " +
                this.zamestnanec.id_zamestnance + " " + this.vyzvednuti.ToString() + " " +
                this.vraceni.ToString();
        }
    }
}
