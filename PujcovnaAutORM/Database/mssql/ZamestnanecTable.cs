using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PujcovnaAutORM.Database.mssql
{
    public class ZamestnanecTable
    {
        public static String SQL_SELECT = "SELECT * FROM \"Zamestnanec\"";
        public static String SQL_SELECT_ID = "SELECT * FROM \"Zamestnanec\" WHERE ID_zamestnance = @id_zamestnance";
        public static String SQL_INSERT = "INSERT INTO \"Zamestnanec \" VALUES (@id_zamestnance, @jmeno, @prijmeni, @mesto, " +
            "@ulice, @cislo_popisne, @psc, @email";
        public static String SQL_DELETE_ID = "DELETE FROM \"Zamestnanec\" WHERE Cislo_ridicskeho_prukazu = @id_zamestnance";
        public static String SQL_UPDATE = "UPDATE \"Zamestnanec\" SET Cislo_ridicskeho_prukazu=@id_zamestnance, Jmeno=@jmeno, " +
            "Prijmeni=@prijmeni, Mesto=@mesto, Ulice=@ulice, PSC=@psc, Email=@email";

        #region Abstraktní metody
        /// <summary>
        /// Insert the record.
        /// </summary>
        protected int insert(Zamestnanec zamestnanec, Database pDb = null)
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
            PrepareCommand(command, zamestnanec);
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
        protected int update(Zamestnanec zamestnanec, Database pDb = null)
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
            PrepareCommand(command, zamestnanec);
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
        protected Collection<Zamestnanec> select(Database pDb = null)
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

            Collection<Zamestnanec> zamestnanecs = Read(reader);
            reader.Close();

            if (pDb == null)
            {
                db.Close();
            }

            return zamestnanecs;
        }

        /// <summary>
        /// Select the record.
        /// </summary>
        /// <param name="id">zamestnanec id</param>
        protected Zamestnanec select(string id_zamestnance, Database pDb = null)
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

            command.Parameters.AddWithValue("@id_zamestnance", id_zamestnance);
            SqlDataReader reader = db.Select(command);

            Collection<Zamestnanec> zamestnanecs = Read(reader);
            Zamestnanec zamestnanec = null;
            if (zamestnanecs.Count == 1)
            {
                zamestnanec = zamestnanecs[0];
            }
            reader.Close();

            if (pDb == null)
            {
                db.Close();
            }

            return zamestnanec;
        }

        /// <summary>
        /// Delete the record.
        /// </summary>
        /// <param name="idUser">zamestnanec id</param>
        /// <returns></returns>
        protected int delete(string id_zamestnance, Database pDb = null)
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

            command.Parameters.AddWithValue("@id_zamestnance", id_zamestnance);
            int ret = db.ExecuteNonQuery(command);

            if (pDb == null)
            {
                db.Close();
            }

            return ret;
        }
        #endregion

        private static void PrepareCommand(SqlCommand command, Zamestnanec zamestnanec)
        {
            command.Parameters.AddWithValue("@id_zamestnance", zamestnanec.id_zamestnance);
            command.Parameters.AddWithValue("@pozice", zamestnanec.pozice.id_pozice);
            command.Parameters.AddWithValue("@jmeno", zamestnanec.jmeno);
            command.Parameters.AddWithValue("@prijmeni", zamestnanec.email);
        }

        private static Collection<Zamestnanec> Read(SqlDataReader reader)
        {
            Collection<Zamestnanec> zamestnanecs = new Collection<Zamestnanec>();

            while (reader.Read())
            {
                int i = -1;
                Zamestnanec zamestnanec = new Zamestnanec();
                zamestnanec.id_zamestnance = reader.GetString(++i);
                int id_pozice = reader.GetInt32(++i);
                zamestnanec.pozice = new PoziceTable().select(id_pozice);
                zamestnanec.jmeno = reader.GetString(++i);
                zamestnanec.prijmeni = reader.GetString(++i);
                zamestnanec.email = reader.GetString(++i);

                zamestnanecs.Add(zamestnanec);
            }

            return zamestnanecs;
        }
    }
}
