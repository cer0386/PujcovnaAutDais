using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PujcovnaAutORM.ORM
{
    public class Auto
    {
        public string spz { get; set; }
        public string model { get; set; }
        public string znacka { get; set; }
        public DateTime zakoupeno { get; set; }
        public DateTime stk { get; set; }
        public int pocet_nehod { get; set; }
        public bool servis { get; set; }
        public decimal najeto { get; set; }
        public int cena_za_den { get; set; }
        

        public string toString()
        {
            return this.spz + " " + this.model + " " + this.znacka + " " + this.zakoupeno.ToString() +
                " " + this.stk.ToString() + " " + this.servis.ToString() + " " + this.najeto + " " +
                this.cena_za_den;
        }
    }
}
