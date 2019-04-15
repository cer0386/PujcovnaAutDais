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
        public static String SQL_SELECT = "SELECT * FROM \"Faktura\"";
        public static String SQL_SELECT_ID = "SELECT * FROM \"Faktura\" WHERE Cislo_faktury = @cislo_faktury";
        public static String SQL_INSERT = "INSERT INTO \"Faktura \" VALUES (@cislo_faktury, @rezervace, @vytvoreno," +
            "@potvrzeno, @zaplaceno";
        public static String SQL_DELETE_ID = "DELETE FROM \"Faktura\" WHERE Cislo_faktury = @cislo_faktury";
        public static String SQL_UPDATE = "UPDATE \"Faktura\" SET Cislo_faktury=@cislo_faktury, Cislo_rezervace=@rezervace, " +
            "Vytvoreno=@vytvoreno, Potvrzeno=@potvrzeno, Zaplaceno=@zaplaceno";

        #region Abstraktní metody
        /// <summary>
        /// Insert the record.
        /// </summary>
        protected int insert(Faktura faktura, Database pDb = null)
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
        protected int update(Faktura faktura, Database pDb = null)
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


        /// <summary>
        /// Select the records.
        /// </summary>
        protected Collection<Faktura> select(Database pDb = null)
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
        /// Delete the record.
        /// </summary>
        /// <param name="idUser">faktura id</param>
        /// <returns></returns>
        protected int delete(int cislo_faktury, Database pDb = null)
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
            command.Parameters.AddWithValue("@cislo_faktura", faktura.cislo_faktury);
            command.Parameters.AddWithValue("@zakaznik", faktura.rezervace.cislo_rezervace);
            command.Parameters.AddWithValue("@zamestnanec", faktura.vytvoreno);
            command.Parameters.AddWithValue("@vyzvednuti", faktura.potvrzeno);
            command.Parameters.AddWithValue("@vraceni", faktura.zaplaceno);
        }

        private static Collection<Faktura> Read(SqlDataReader reader)
        {
            Collection<Faktura> fakturas = new Collection<Faktura>();

            while (reader.Read())
            {
                int i = -1;
                Faktura faktura = new Faktura();
                faktura.cislo_faktury = reader.GetInt32(++i);
                int cisloR = reader.GetInt32(++i);
                faktura.rezervace = new RezervaceTable().select(cisloR);
                faktura.vytvoreno = reader.GetDateTime(++i);
                faktura.potvrzeno = reader.GetDateTime(++i);
                faktura.zaplaceno = reader.GetDateTime(++i);

                fakturas.Add(faktura);
            }

            return fakturas;
        }
    }
}
