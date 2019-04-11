﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PujcovnaAutORM.Database
{
    public class Servis
    {
        public int poradi_s { get; set; }
        public Auto auto { get; set; }
        public DateTime od { get; set; }
        public DateTime do_ { get; set; }

        public string toString()
        {
            return this.poradi_s.ToString() + " " + this.auto.spz + " " + this.od.ToString() + " " +
                this.do_.ToString();
        }
}
}