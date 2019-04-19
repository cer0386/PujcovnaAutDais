using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PujcovnaAutORM.ORM.mssql
{
    public class ServisTable
    {
        //public static String SQL_SELECT = "SELECT * FROM \"Servis\"";
        public static String SQL_SELECT_ID = "SELECT \"Poradi_s\", \"SPZ\", \"Od\", \"Do\" FROM \"Servis\" WHERE Poradi_s = @poradi_s";

        //Zjištění nejnovějšího pořadí servisu pro výpis v ORM
        public static String SQL_SELECT_MAXServis= "SELECT MAX(Poradi_s) FROM \"Servis\"";

        //Zjištění stavu auta (atribut servis)
        public static String SQL_SELECT_status = "SELECT \"Servis\" FROM \"Auto\" WHERE SPZ=@spz";

        //Seznam servisů pro určité auto
        public static String SQL_SELECT_ServisyAuta = "SELECT \"Poradi_s\", \"SPZ\", \"Od\", \"Do\" FROM \"Servis\" WHERE SPZ = @spz";

        public static String SQL_INSERT = "INSERT INTO \"Servis \" VALUES (@spz, @od," +
            "@do_)";
        public static String SQL_DELETE_ID = "DELETE FROM \"Servis\" WHERE Poradi_s = @poradi_s";
        public static String SQL_UPDATE = "UPDATE \"Servis\" SET Poradi_s=@poradi_s, SPZ=@spz, " +
            "Od=@od, Do=@do_";

        #region Abstraktní metody

        //Uložená procedura
        public static int novyServis(string spz, DateTime dOd, DateTime dDo, Database pDb = null)
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
            SqlCommand command = db.CreateCommand("NovyServis");
            command.CommandType = CommandType.StoredProcedure;

            SqlParameter input = new SqlParameter();
            input.ParameterName = "@p_spz";
            input.DbType = DbType.String;
            input.Value = spz;
            input.Direction = ParameterDirection.Input;
            command.Parameters.Add(input);

            SqlParameter input1 = new SqlParameter();
            input1.ParameterName = "@p_od";
            input1.DbType = DbType.Date;
            input1.Value = dOd;
            input1.Direction = ParameterDirection.Input;
            command.Parameters.Add(input1);

            SqlParameter input2 = new SqlParameter();
            input2.ParameterName = "@p_do";
            input2.DbType = DbType.Date;
            input2.Value = dDo;
            input2.Direction = ParameterDirection.Input;
            command.Parameters.Add(input2);

            SqlParameter output = new SqlParameter();
            output.Direction = ParameterDirection.ReturnValue;
            output.DbType = DbType.Int32;
            output.ParameterName = "@ReturnValue";
            command.Parameters.Add(output);

            db.ExecuteNonQuery(command);

            int ret = Convert.ToInt32(command.Parameters["@ReturnValue"].Value);

            if (pDb == null)
            {
                db.Close();
            }
            return ret;
        }

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

        /*
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
        */
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

            SqlCommand command = db.CreateCommand(SQL_SELECT_MAXServis);
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
        /// Select the record.
        /// </summary>
        /// <param name="id">servis id</param>
        public bool selectStatus(string spz, Database pDb = null)
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

            SqlCommand command = db.CreateCommand(SQL_SELECT_status);

            command.Parameters.AddWithValue("@spz", spz);
            SqlDataReader reader = db.Select(command);

            reader.Read();
            bool status = reader.GetBoolean(0);
            reader.Close();

            if (pDb == null)
            {
                db.Close();
            }

            return status;
        }

        public Collection<Servis> select(string spz,Database pDb = null)
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

            SqlCommand command = db.CreateCommand(SQL_SELECT_ServisyAuta);
            command.Parameters.AddWithValue("@spz", spz);
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
            command.Parameters.AddWithValue("@spz", servis.auto_spz);
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
                servis.auto_spz = reader.GetString(++i);
                servis.auto = new Auto();
                servis.auto.spz = servis.auto_spz;
                servis.od = reader.GetDateTime(++i);
                servis.do_ = reader.GetDateTime(++i);

                serviss.Add(servis);
            }

            return serviss;
        }
    }
}
