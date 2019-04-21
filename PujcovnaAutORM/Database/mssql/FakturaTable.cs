using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PujcovnaAutORM.ORM.mssql
{
    public class FakturaTable
    {
        //public static String SQL_SELECT = "SELECT * FROM \"Faktura\"";
        public static String SQL_SELECT_ID = "SELECT \"Cislo_faktury\", \"Cislo_rezervace\", \"Vytvoreno\", \"Potvrzeno\", \"Zaplaceno\" "+
            "FROM \"Faktura\" WHERE Cislo_faktury = @cislo_faktury";

        //Faktura podle čísla rezervace - nové
        public static String SQL_SELECT_REZ = "SELECT \"Cislo_faktury\", \"Cislo_rezervace\", \"Vytvoreno\", \"Potvrzeno\", \"Zaplaceno\" " +
            "FROM \"Faktura\" WHERE Cislo_rezervace = @rezervace";

        //Zjištění nejnovějšího čísla faktury
        public static String SQL_SELECT_MAXCisloF = "SELECT MAX(Cislo_faktury) FROM \"Faktura\"";

        //Seznam nezaplacených faktur
        public static String SQL_SELECT_NEZAPLACENE = "SELECT \"Cislo_faktury\", \"Cislo_rezervace\", \"Vytvoreno\", \"Potvrzeno\", \"Zaplaceno\" " +
            "FROM \"Faktura\" WHERE Zaplaceno IS NULL";

        //seznam zákazníkových faktur
        public static String SQL_SELECT_ZAKAZNIKOVY = "SELECT \"Cislo_faktury\", f.\"Cislo_rezervace\", \"Vytvoreno\", \"Potvrzeno\", "+
            "\"Zaplaceno\" FROM \"Faktura\" f JOIN \"Rezervace\" r ON r.Cislo_rezervace = f.Cislo_rezervace " +
            "WHERE Cislo_ridickeho_prukazu=@cisloRP";

        public static String SQL_INSERT = "INSERT INTO \"Faktura \" VALUES (@rezervace, @vytvoreno," +
            "@potvrzeno, @zaplaceno)";

        public static String SQL_DELETE_ID = "DELETE FROM \"Faktura\" WHERE Cislo_faktury = @cislo_faktury";
        public static String SQL_UPDATE = "UPDATE \"Faktura\" SET Cislo_rezervace=@rezervace, " +
            "Vytvoreno=@vytvoreno, Potvrzeno=@potvrzeno, Zaplaceno=@zaplaceno WHERE Cislo_faktury=@cislo_faktury";

        #region Abstraktní metody
        /// <summary>
        /// Insert the record.
        /// </summary>
        public static int insert(Faktura faktura, Database pDb = null)
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
            PrepareCommand(command, faktura);
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
        public static int update(Faktura faktura, Database pDb = null)
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
            PrepareCommand(command, faktura);
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
        public Collection<Faktura> select(Database pDb = null)
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

            Collection<Faktura> fakturas = Read(reader);
            reader.Close();

            if (pDb == null)
            {
                db.Close();
            }

            return fakturas;
        }
        */
        /// <summary>
        /// Select the record.
        /// </summary>
        /// <param name="id">faktura id</param>
        public Faktura selectCRez(int cislo_rezervace, Database pDb = null)
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

            SqlCommand command = db.CreateCommand(SQL_SELECT_REZ);

            command.Parameters.AddWithValue("@rezervace", cislo_rezervace);
            SqlDataReader reader = db.Select(command);

            Collection<Faktura> fakturas = Read(reader);
            Faktura faktura = null;
            if (fakturas.Count == 1)
            {
                faktura = fakturas[0];
            }
            reader.Close();

            if (pDb == null)
            {
                db.Close();
            }

            return faktura;
        }

        /// <summary>
        /// Select the record.
        /// </summary>
        /// <param name="id">faktura id</param>
        public Faktura select(int cislo_faktury, Database pDb = null)
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

            command.Parameters.AddWithValue("@cislo_faktury", cislo_faktury);
            SqlDataReader reader = db.Select(command);

            Collection<Faktura> fakturas = Read(reader);
            Faktura faktura = null;
            if (fakturas.Count == 1)
            {
                faktura = fakturas[0];
            }
            reader.Close();

            if (pDb == null)
            {
                db.Close();
            }

            return faktura;
        }

        /// <summary>
        /// Select the records.
        /// </summary>
        public Collection<Faktura> selectNezaplace(Database pDb = null)
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

            SqlCommand command = db.CreateCommand(SQL_SELECT_NEZAPLACENE);
            SqlDataReader reader = db.Select(command);

            Collection<Faktura> fakturas = Read(reader);
            reader.Close();

            if (pDb == null)
            {
                db.Close();
            }

            return fakturas;
        }

        /// <summary>
        /// Select the records.
        /// </summary>
        public Collection<Faktura> selectZakaznikovy(string cisloRP ,Database pDb = null)
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

            SqlCommand command = db.CreateCommand(SQL_SELECT_ZAKAZNIKOVY);
            command.Parameters.AddWithValue("@cisloRP", cisloRP);
            SqlDataReader reader = db.Select(command);

            Collection<Faktura> fakturas = Read(reader);
            reader.Close();

            if (pDb == null)
            {
                db.Close();
            }

            return fakturas;
        }

        public int selectMax(Database pDb = null)
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

            SqlCommand command = db.CreateCommand(SQL_SELECT_MAXCisloF);
            SqlDataReader reader = db.Select(command);
            reader.Read();
            int maxVal = reader.GetInt32(0);
            reader.Close();

            if (pDb == null)
            {
                db.Close();
            }

            return maxVal;
        }

        /// <summary>
        /// Delete the record.
        /// </summary>
        /// <param name="idUser">faktura id</param>
        /// <returns></returns>
        public static int delete(int cislo_faktury, Database pDb = null)
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

            command.Parameters.AddWithValue("@cislo_faktury", cislo_faktury);
            int ret = db.ExecuteNonQuery(command);

            if (pDb == null)
            {
                db.Close();
            }

            return ret;
        }
        #endregion

        private static void PrepareCommand(SqlCommand command, Faktura faktura)
        {
            command.Parameters.AddWithValue("@cislo_faktury", faktura.cislo_faktury);
            command.Parameters.AddWithValue("@rezervace", faktura.cislo_r);
            command.Parameters.AddWithValue("@vytvoreno", faktura.vytvoreno);
            command.Parameters.AddWithValue("@potvrzeno", faktura.potvrzeno == null ? DBNull.Value : (object)faktura.potvrzeno);
            command.Parameters.AddWithValue("@zaplaceno", faktura.zaplaceno == null ? DBNull.Value : (object)faktura.zaplaceno);
        }

        private static Collection<Faktura> Read(SqlDataReader reader)
        {
            Collection<Faktura> fakturas = new Collection<Faktura>();

            while (reader.Read())
            {
                int i = -1;
                Faktura faktura = new Faktura();
                faktura.cislo_faktury = reader.GetInt32(++i);
                faktura.cislo_r = reader.GetInt32(++i);
                faktura.rezervace = new Rezervace();
                faktura.rezervace.cislo_rezervace = faktura.cislo_r;
                faktura.vytvoreno = reader.GetDateTime(++i);

                if (!reader.IsDBNull(++i)){
                    faktura.potvrzeno = reader.GetDateTime(i);
                }
                //i++;
                if (!reader.IsDBNull(++i))
                {
                    faktura.zaplaceno = reader.GetDateTime(i);
                }

                fakturas.Add(faktura);
            }

            return fakturas;
        }
    }
}
