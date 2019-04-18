using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PujcovnaAutORM.ORM.mssql
{
    public class Typ_platbyTable
    {
        //public static String SQL_SELECT = "SELECT * FROM Typ_platby";
        public static String SQL_SELECT_ID = "SELECT \"ID_typ_platby\", \"Zbusob_platby\" FROM \"Typ_platby\" "+
            "WHERE ID_typ_platby=@id_typ_platby";
        public static String SQL_INSERT = "INSERT INTO \"Typ_platby\" VALUES (@id_typ_platby, @nazev)";
        public static String SQL_DELETE_ID = "DELETE FROM \"Typ_platby\" WHERE ID_typ_platby=@id_typ_platby";
        public static String SQL_UPDATE = "UPDATE \"Typ_platby\" SET Zbusob_platby=@zpusob_platby WHERE ID_typ_platby=@id_typ_platby";

        #region Abstraktní metody
        /// <summary>
        /// Insert the record.
        /// </summary>
        public static int insert(Typ_platby typ_platby, Database pDb = null)
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
            PrepareCommand(command, typ_platby);
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
        /// <param nazev="typ_platby"></param>
        /// <returns></returns>
        public static int update(Typ_platby typ_platby, Database pDb = null)
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
            PrepareCommand(command, typ_platby);
            int ret = db.ExecuteNonQuery(command);
            if (pDb == null)
            {
                db.Close();
            }
            return ret;
        }

        /*
        /// <summary>
        /// Select records.
        /// </summary>
        public Collection<Typ_platby> select()
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

            Collection<Typ_platby> Typ_platbys = Read(reader, true);
            reader.Close();
            db.Close();
            return Typ_platbys;
        }
        */
        /// <summary>
        /// Select records for typ_platby.
        /// </summary>
        public Typ_platby select(int id_typ_platby, Database pDb = null)
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

            command.Parameters.AddWithValue("@id_typ_platby", id_typ_platby);
            SqlDataReader reader = db.Select(command);

            Collection<Typ_platby> typ_platbys = Read(reader);
            Typ_platby typ_platby = null;
            if (typ_platbys.Count == 1)
            {
                typ_platby = typ_platbys[0];
            }
            reader.Close();
            if (pDb == null)
            {
                db.Close();
            }
            return typ_platby;
        }
        /// <summary>
        /// Delete the record.
        /// </summary>
        public static int delete(int id, Database pDb = null)
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

            command.Parameters.AddWithValue("@id_typ_platby", id);
            int ret = db.ExecuteNonQuery(command);

            if (pDb == null)
            {
                db.Close();
            }
            return ret;
        }
        #endregion

        /// <summary>
        /// Prepare a command.
        /// </summary>
        private static void PrepareCommand(SqlCommand command, Typ_platby typ_platby)
        {
            command.Parameters.AddWithValue("@id_typ_platby", typ_platby.id_typ_platby);
            command.Parameters.AddWithValue("@nazev", typ_platby.zpusob_platby);
        }


        private static Collection<Typ_platby> Read(SqlDataReader reader, bool withItemsCount = false)
        {
            Collection<Typ_platby> typ_platbys = new Collection<Typ_platby>();

            while (reader.Read())
            {
                Typ_platby typ_platby = new Typ_platby();
                int i = -1;
                typ_platby.id_typ_platby = reader.GetInt32(++i);
                typ_platby.zpusob_platby = reader.GetString(++i);

                typ_platbys.Add(typ_platby);
            }
            return typ_platbys;
        }
    }
}
