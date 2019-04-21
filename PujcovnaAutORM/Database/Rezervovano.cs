using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PujcovnaAutORM.ORM
{
    public class Rezervovano
    {
        //dodáno kvůli updatu ve vazební tabulce
        public int id_rezervace { get; set; }

        public Rezervace rezervace { get; set; }
        public Auto auto { get; set; }

        public int ciclo_r { get; set; }
        public string auto_spz { get; set; }

        public string toString()
        {
            return this.rezervace.cislo_rezervace.ToString() + " " + this.auto.spz;
        }
    }
}
