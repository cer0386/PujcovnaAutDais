using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PujcovnaAutORM.Database.mssql
{
    public class ZakaznikTable
    {
        public static String SQL_SELECT = "SELECT * FROM \"Zakaznik\"";
        public static String SQL_SELECT_ID = "SELECT * FROM \"Zakaznik\" WHERE Cislo_ridicskeho_prukazu = @cislo_RP";
        public static String SQL_INSERT = "INSERT INTO \"Zakaznik \" VALUES (@cislo_RP, @jmeno, @prijmeni, @mesto, " +
            "@ulice, @cislo_popisne, @psc, @email";
        public static String SQL_DELETE_ID = "DELETE FROM \"Zakaznik\" WHERE Cislo_ridicskeho_prukazu = @cislo_RP";
        public static String SQL_UPDATE = "UPDATE \"Zakaznik\" SET Cislo_ridicskeho_prukazu=@cislo_RP, Jmeno=@jmeno, " +
            "Prijmeni=@prijmeni, Mesto=@mesto, Ulice=@ulice, PSC=@psc, Email=@email";

        #region Abstraktní metody
        /// <summary>
        /// Insert the record.
        /// </summary>
        protected int insert(Zakaznik zakaznik, Database pDb = null)
        {
            Database db;
            if (pDb == null)
            {
                db = new Database();
                db.Connect();
            }
            else
            {
                db = (Database)pDb;
            }

            SqlCommand command = db.CreateCommand(SQL_INSERT);
            PrepareCommand(command, zakaznik);
            int ret = db.ExecuteNonQuery(command);

            if (pDb == null)
            {
                db.Close();
            }

            return ret;
        }

        /// <summary>
        /// Update the record.
        /// </summary>
        protected int update(Zakaznik zakaznik, Database pDb = null)
        {
            Database db;
            if (pDb == null)
            {
                db = new Database();
                db.Connect();
            }
            else
            {
                db = (Database)pDb;
            }

            SqlCommand command = db.CreateCommand(SQL_UPDATE);
            PrepareCommand(command, zakaznik);
            int ret = db.ExecuteNonQuery(command);

            if (pDb == null)
            {
                db.Close();
            }

            return ret;
        }


        /// <summary>
        /// Select the records.
        /// </summary>
        protected Collection<Zakaznik> select(Database pDb = null)
        {
            Database db;
            if (pDb == null)
            {
                db = new Database();
                db.Connect();
            }
            else
            {
                db = (Database)pDb;
            }

            SqlCommand command = db.CreateCommand(SQL_SELECT);
            SqlDataReader reader = db.Select(command);

            Collection<Zakaznik> zakazniks = Read(reader);
            reader.Close();

            if (pDb == null)
            {
                db.Close();
            }

            return zakazniks;
        }

        /// <summary>
        /// Select the record.
        /// </summary>
        /// <param name="id">zakaznik id</param>
        protected Zakaznik select(string cislo_RP, Database pDb = null)
        {
            Database db;
            if (pDb == null)
            {
                db = new Database();
                db.Connect();
            }
            else
            {
                db = (Database)pDb;
            }

            SqlCommand command = db.CreateCommand(SQL_SELECT_ID);

            command.Parameters.AddWithValue("@cislo_RP", cislo_RP);
            SqlDataReader reader = db.Select(command);

            Collection<Zakaznik> zakazniks = Read(reader);
            Zakaznik zakaznik = null;
            if (zakazniks.Count == 1)
            {
                zakaznik = zakazniks[0];
            }
            reader.Close();

            if (pDb == null)
            {
                db.Close();
            }

            return zakaznik;
        }

        /// <summary>
        /// Delete the record.
        /// </summary>
        /// <param name="idUser">zakaznik id</param>
        /// <returns></returns>
        protected int delete(string cislo_RP, Database pDb = null)
        {
            Database db;
            if (pDb == null)
            {
                db = new Database();
                db.Connect();
            }
            else
            {
                db = (Database)pDb;
            }
            SqlCommand command = db.CreateCommand(SQL_DELETE_ID);

            command.Parameters.AddWithValue("@cislo_RP", cislo_RP);
            int ret = db.ExecuteNonQuery(command);

            if (pDb == null)
            {
                db.Close();
            }

            return ret;
        }
        #endregion

        private static void PrepareCommand(SqlCommand command, Zakaznik zakaznik)
        {
            command.Parameters.AddWithValue("@cislo_RP", zakaznik.cislo_RP);
            command.Parameters.AddWithValue("@jmeno", zakaznik.jmeno);
            command.Parameters.AddWithValue("@prijmeni", zakaznik.prijmeni);
            command.Parameters.AddWithValue("@mesto", zakaznik.mesto);
            command.Parameters.AddWithValue("@ulice", zakaznik.ulice);
            command.Parameters.AddWithValue("@cislo_popisne", zakaznik.cislo_popisne);
            command.Parameters.AddWithValue("@psc", zakaznik.psc);
            command.Parameters.AddWithValue("@email", zakaznik.email);
        }

        private static Collection<Zakaznik> Read(SqlDataReader reader)
        {
            Collection<Zakaznik> zakazniks = new Collection<Zakaznik>();

            while (reader.Read())
            {
                int i = -1;
                Zakaznik zakaznik = new Zakaznik();
                zakaznik.cislo_RP = reader.GetString(++i);
                zakaznik.jmeno = reader.GetString(++i);
                zakaznik.prijmeni = reader.GetString(++i);
                zakaznik.mesto = reader.GetString(++i);
                zakaznik.ulice = reader.GetString(++i);
                zakaznik.cislo_popisne = reader.GetInt32(++i);
                zakaznik.psc = reader.GetInt32(++i);
                zakaznik.email = reader.GetString(++i);

                zakazniks.Add(zakaznik);
            }

            return zakazniks;
        }
    }
}
