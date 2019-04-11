using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PujcovnaAutORM.Database
{
    public class Zamestnanec
    {
        public string id_zamestnance { get; set; }
        public Pozice pozice { get; set; }
        public string jmeno { get; set; }
        public string prijmeni { get; set; }
        public string email { get; set; }

        public string toString()
        {
            return this.id_zamestnance + " " + this.pozice.id_pozice.ToString() + " " + this.jmeno + " " +
                this.prijmeni + " " + this.email;
        }
    }
}
