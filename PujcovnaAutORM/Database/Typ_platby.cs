using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PujcovnaAutORM.ORM
{
    public class Typ_platby
    {
        public int id_typ_platby { get; set; }
        public string zpusob_platby { get; set; }

        public string toString()
        {
            return this.id_typ_platby.ToString() + " " + this.zpusob_platby;
        }
    }
}
