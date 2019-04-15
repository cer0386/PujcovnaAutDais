using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PujcovnaAutORM.ORM.mssql
{
    public class RezervovanoTable
    {
        public static String SQL_SELECT = "SELECT * FROM \"Rezervovano\"";
        public static String SQL_SELECT_ID_REZ = "SELECT * FROM \"Rezervovano\" WHERE Cislo_rezervace = @cislo_rezervace";
        public static String SQL_SELECT_SPZ = "SELECT * FROM \"Rezervovano\" WHERE SPZ = @spz";
        public static String SQL_INSERT = "INSERT INTO \"Rezervovano \" VALUES (@cislo_rezervace, @spz)";
        public static String SQL_DELETE_ID_REZ = "DELETE FROM \"Rezervovano\" WHERE Cislo_rezezervace = @cislo_rezervace";
        public static String SQL_DELETE_SPZ = "DELETE FROM \"Rezervovano\" WHERE Cislo_rezezervace = @cislo_rezervace "+
            "SPZ=@spz";
        public static String SQL_UPDATE = "UPDATE \"Rezervovano\" SET Cislo_rezervace=@cislo_rezervace, SPZ=@spz " +
            "WHERE Cislo_rezervace=@Cislo_rezervace AND SPZ=@spz";

        #region Abstraktní metody
        /// <summary>
        /// Insert the record.
        /// </summary>
        protected int insert(Rezervovano rezervovano, Database pDb = null)
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
            PrepareCommand(command, rezervovano);
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
        protected int update(Rezervovano rezervovano, Database pDb = null)
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
            PrepareCommand(command, rezervovano);
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
        protected Collection<Rezervovano> select(Database pDb = null)
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

            Collection<Rezervovano> rezervovanos = Read(reader);
            reader.Close();

            if (pDb == null)
            {
                db.Close();
            }

            return rezervovanos;
        }

        /// <summary>
        /// Select the record.
        /// </summary>
        /// <param name="id">rezervovano id</param>
        public Collection<Rezervovano> select(int cislo_rezervace, Database pDb = null)
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

            SqlCommand command = db.CreateCommand(SQL_SELECT_ID_REZ);

            command.Parameters.AddWithValue("@cislo_rezervace", cislo_rezervace);
            SqlDataReader reader = db.Select(command);

            Collection<Rezervovano> rezervovanos = Read(reader);
            reader.Close();

            if (pDb == null)
            {
                db.Close();
            }

            return rezervovanos;
        }

        public Collection<Rezervovano> select(string spz, Database pDb = null)
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

            SqlCommand command = db.CreateCommand(SQL_SELECT_SPZ);

            command.Parameters.AddWithValue("@spz", spz);
            SqlDataReader reader = db.Select(command);

            Collection<Rezervovano> rezervovanos = Read(reader);
            reader.Close();

            if (pDb == null)
            {
                db.Close();
            }

            return rezervovanos;
        }

        /// <summary>
        /// Delete the record.
        /// </summary>
        /// <param name="idUser">rezervovano id</param>
        /// <returns></returns>
        protected int delete(int cislo_rezervace, Database pDb = null)
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
            SqlCommand command = db.CreateCommand(SQL_DELETE_ID_REZ);

            command.Parameters.AddWithValue("@cislo_rezervace", cislo_rezervace);
            int ret = db.ExecuteNonQuery(command);

            if (pDb == null)
            {
                db.Close();
            }

            return ret;
        }
        protected int delete(int cislo_rezervace, string spz, Database pDb = null)
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
            SqlCommand command = db.CreateCommand(SQL_DELETE_SPZ);

            command.Parameters.AddWithValue("@cislo_rezervace", cislo_rezervace);
            command.Parameters.AddWithValue("@spz", spz);
            int ret = db.ExecuteNonQuery(command);

            if (pDb == null)
            {
                db.Close();
            }

            return ret;
        }
        #endregion

        private static void PrepareCommand(SqlCommand command, Rezervovano rezervovano)
        {
            command.Parameters.AddWithValue("@cislo_rezervace", rezervovano.rezervace.cislo_rezervace);
            command.Parameters.AddWithValue("@spz", rezervovano.auto.spz);
        }

        private static Collection<Rezervovano> Read(SqlDataReader reader)
        {
            Collection<Rezervovano> rezervovanos = new Collection<Rezervovano>();

            while (reader.Read())
            {
                int i = -1;
                Rezervovano rezervovano = new Rezervovano();
                int cRez = reader.GetInt32(++i);
                rezervovano.rezervace = new RezervaceTable().select(cRez);
                string spz = reader.GetString(++i);
                rezervovano.auto = new AutoTable().select(spz);
                string idZam = reader.GetString(++i);

                rezervovanos.Add(rezervovano);
            }

            return rezervovanos;
        }
    }
}
