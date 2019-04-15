using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PujcovnaAutORM.ORM.mssql
{
    public class ServisTable
    {
        public static String SQL_SELECT = "SELECT * FROM \"Servis\"";
        public static String SQL_SELECT_ID = "SELECT * FROM \"Servis\" WHERE Poradi_s = @poradi_s";
        public static String SQL_INSERT = "INSERT INTO \"Servis \" VALUES (@poradi_s, @spz, @od," +
            "@do_";
        public static String SQL_DELETE_ID = "DELETE FROM \"Servis\" WHERE Cislo_rezezervace = @poradi_s";
        public static String SQL_UPDATE = "UPDATE \"Servis\" SET Poradi_s=@poradi_s, SPZ=@spz, " +
            "Od=@od, Do=@do_";

        #region Abstraktní metody
        /// <summary>
        /// Insert the record.
        /// </summary>
        public static int insert(Servis servis, Database pDb = null)
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
            PrepareCommand(command, servis);
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
        public static int update(Servis servis, Database pDb = null)
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
            PrepareCommand(command, servis);
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
        public Collection<Servis> select(Database pDb = null)
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

            Collection<Servis> serviss = Read(reader);
            reader.Close();

            if (pDb == null)
            {
                db.Close();
            }

            return serviss;
        }

        /// <summary>
        /// Select the record.
        /// </summary>
        /// <param name="id">servis id</param>
        public Servis select(int poradi_s, Database pDb = null)
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

            command.Parameters.AddWithValue("@poradi_s", poradi_s);
            SqlDataReader reader = db.Select(command);

            Collection<Servis> serviss = Read(reader);
            Servis servis = null;
            if (serviss.Count == 1)
            {
                servis = serviss[0];
            }
            reader.Close();

            if (pDb == null)
            {
                db.Close();
            }

            return servis;
        }

        /// <summary>
        /// Delete the record.
        /// </summary>
        /// <param name="idUser">servis id</param>
        /// <returns></returns>
        public static int delete(int poradi_s, Database pDb = null)
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

            command.Parameters.AddWithValue("@poradi_s", poradi_s);
            int ret = db.ExecuteNonQuery(command);

            if (pDb == null)
            {
                db.Close();
            }

            return ret;
        }
        #endregion

        private static void PrepareCommand(SqlCommand command, Servis servis)
        {
            command.Parameters.AddWithValue("@poradi_s", servis.poradi_s);
            command.Parameters.AddWithValue("@spz", servis.auto.spz);
            command.Parameters.AddWithValue("@od", servis.od);
            command.Parameters.AddWithValue("@do_", servis.do_);
        }

        private static Collection<Servis> Read(SqlDataReader reader)
        {
            Collection<Servis> serviss = new Collection<Servis>();

            while (reader.Read())
            {
                int i = -1;
                Servis servis = new Servis();
                servis.poradi_s = reader.GetInt32(++i);
                string spz = reader.GetString(++i);
                servis.auto = new AutoTable().select(spz);
                servis.od = reader.GetDateTime(++i);
                servis.do_ = reader.GetDateTime(++i);

                serviss.Add(servis);
            }

            return serviss;
        }
    }
}
