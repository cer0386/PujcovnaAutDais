using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PujcovnaAutORM.ORM
{
    public class Pozice
    {
        public int id_pozice { get; set; }
        public string nazev { get; set; }

        public string toString()
        {
            return this.id_pozice.ToString() + " " + this.nazev;
        }
    }
}
