using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PujcovnaAutORM.Database
{
    public class Zakaznik
    {
        public string cislo_RP { get; set; }
        public string jmeno { get; set; }
        public string prijmeni { get; set; }
        public string mesto { get; set; }
        public string ulice { get; set; }
        public int cislo_popisne { get; set; }
        public int psc { get; set; }
        public string email { get; set; }

        public string CeleJmeno { get { return this.jmeno + " " + this.prijmeni; } }

        public string toString()
        {
            return this.cislo_RP + " " + this.jmeno + " " + this.prijmeni + " " + this.mesto + " " +
                this.ulice + " " + this.cislo_popisne.ToString() + " " + this.psc.ToString() + " " + this.email;
        }
    }
}
