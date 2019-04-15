using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PujcovnaAutORM.ORM
{
    public class Faktura
    {
        public int cislo_faktury { get; set; }
        public Rezervace rezervace { get; set; }
        public DateTime vytvoreno { get; set; }
        public DateTime? potvrzeno { get; set; }
        public DateTime? zaplaceno { get; set; }

        public string toString()
        {
            return this.cislo_faktury.ToString() + " " + this.rezervace.cislo_rezervace.ToString() +
                " " + this.vytvoreno.ToString() + " " + this.potvrzeno.ToString() + " " +
                this.zaplaceno.ToString();
        }
    }
}
