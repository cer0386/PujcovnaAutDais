using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PujcovnaAutORM.ORM.mssql
{
    public class ZamestnanecTable
    {
        //public static String SQL_SELECT = "SELECT * FROM \"Zamestnanec\"";
        public static String SQL_SELECT_ID = "SELECT \"ID_zamestnance\", \"ID_pozice\", \"Jmeno\", \"Prijmeni\", \"Email\" "+
            "FROM \"Zamestnanec\" WHERE ID_zamestnance = @id_zamestnance";

        //Seznam zaměstnanců s jejich počtem sjednaných rezervací 3.6
        public static String SQL_SELECT_SeznamZamPocetRez =
            "SELECT z.\"ID_zamestnance\", z.\"ID_pozice\", z.\"Jmeno\", z.\"Prijmeni\", z.\"Email\", COUNT(r.Cislo_Rezervace) AS Pocet_Rezervaci " +
            "FROM \"Zamestnanec\" z " +
            "JOIN \"Rezervace\" r ON r.ID_zamestnance=z.ID_zamestnance " +
            "JOIN \"Pozice\" p ON p.ID_pozice=z.ID_pozice " +
            "WHERE Nazev = \'Zaměstnanec\' " +
            "GROUP BY z.\"ID_zamestnance\", z.\"ID_pozice\", z.\"Jmeno\", z.\"Prijmeni\", z.\"Email\"";

        public static String SQL_INSERT = "INSERT INTO \"Zamestnanec \" VALUES (@id_zamestnance, @pozice, @jmeno, @prijmeni, @email)";

        public static String SQL_DELETE_ID = "DELETE FROM \"Zamestnanec\" WHERE ID_zamestnance = @id_zamestnance";
        public static String SQL_UPDATE = "UPDATE \"Zamestnanec\" SET ID_zamestnance=@id_zamestnance, Jmeno=@jmeno, " +
            "Prijmeni=@prijmeni, Email=@email";

        public static String SQL_GenID = "SELECT dbo.GeneraceIDZamestnance(@prijmeni)";
        public static String SQL_GenEmail = "SELECT dbo.GeneraceEmailu(@id)";

        #region Abstraktní metody
        /// <summary>
        /// Insert the record.
        /// </summary>
        public static int insert(Zamestnanec zamestnanec, Database pDb = null)
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

            SqlCommand cmdID = db.CreateCommand(SQL_GenID);
            cmdID.Parameters.AddWithValue("@prijmeni", zamestnanec.prijmeni);
            zamestnanec.id_zamestnance = (string)cmdID.ExecuteScalar();

            SqlCommand cmdEmail = db.CreateCommand(SQL_GenEmail);
            cmdEmail.Parameters.AddWithValue("@id", zamestnanec.id_zamestnance);
            zamestnanec.email = (string)cmdEmail.ExecuteScalar();


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
        public static int update(Zamestnanec zamestnanec, Database pDb = null)
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

        /*
        /// <summary>
        /// Select the records.
        /// </summary>
        public Collection<Zamestnanec> select(Database pDb = null)
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
        */
        /// <summary>
        /// Select the record.
        /// </summary>
        /// <param name="id">zamestnanec id</param>
        public Zamestnanec select(string id_zamestnance, Database pDb = null)
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

        public Collection<Zamestnanec> select(Database pDb = null)
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

            SqlCommand command = db.CreateCommand(SQL_SELECT_SeznamZamPocetRez);
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
        /// Delete the record.
        /// </summary>
        /// <param name="idUser">zamestnanec id</param>
        /// <returns></returns>
        public static int delete(string id_zamestnance, Database pDb = null)
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
            command.Parameters.AddWithValue("@pozice", zamestnanec.id_Pozice);
            command.Parameters.AddWithValue("@jmeno", zamestnanec.jmeno);
            command.Parameters.AddWithValue("@prijmeni", zamestnanec.prijmeni);
            command.Parameters.AddWithValue("@email", zamestnanec.email);
        }

        private static Collection<Zamestnanec> Read(SqlDataReader reader, bool sPoctemRezervaci = false)
        {
            Collection<Zamestnanec> zamestnanecs = new Collection<Zamestnanec>();

            while (reader.Read())
            {
                int i = -1;
                Zamestnanec zamestnanec = new Zamestnanec();
                zamestnanec.id_zamestnance = reader.GetString(++i);
                zamestnanec.id_Pozice = reader.GetInt32(++i);
                zamestnanec.pozice = new Pozice();
                zamestnanec.pozice.id_pozice = zamestnanec.id_Pozice;
                zamestnanec.jmeno = reader.GetString(++i);
                zamestnanec.prijmeni = reader.GetString(++i);
                zamestnanec.email = reader.GetString(++i);
                if (sPoctemRezervaci)
                {
                    if (!reader.IsDBNull(++i))
                    {
                        zamestnanec.pocetRezervaci = reader.GetInt32(i);
                    }
                }

                zamestnanecs.Add(zamestnanec);
            }

            return zamestnanecs;
        }
    }
}
