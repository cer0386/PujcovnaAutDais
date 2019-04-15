using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PujcovnaAutORM.ORM
{
    public class Rezervovano
    {
        public Rezervace rezervace { get; set; }
        public Auto auto { get; set; }

        public string toString()
        {
            return this.rezervace.cislo_rezervace.ToString() + " " + this.auto.spz;
        }
    }
}
