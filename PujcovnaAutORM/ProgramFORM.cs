using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PujcovnaAutORM.ORM.mssql;
using PujcovnaAutORM.ORM;
using System.Collections;
using System.Collections.ObjectModel;
using System.Windows.Forms;

namespace PujcovnaAutORM
{

    class Program
    {
        static void Main(string[] args)
        {
            

            Database db = new Database();
            db.Connect();


            Application.Run(new Login());
            Application.Run(new MenuF());
            

        }
    }
}
