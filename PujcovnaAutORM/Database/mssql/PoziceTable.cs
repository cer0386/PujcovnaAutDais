using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PujcovnaAutORM.ORM.mssql
{
    public class PoziceTable
    {
        public static String TABLE_NAME = "Pozice";

        public static String SQL_SELECT_ID = "SELECT * FROM Pozice WHERE ID_pozice=@id_pozice";
        public static String SQL_SELECT= "SELECT * FROM Pozice";
        public static String SQL_INSERT = "INSERT INTO Pozice VALUES (@id_pozice, @nazev)";
        public static String SQL_DELETE_ID = "DELETE FROM Pozice WHERE ID_pozice=@id_pozice";
        public static String SQL_UPDATE = "UPDATE Pozice SET Nazev=@nazev WHERE id_pozice=@id_pozice";

        #region Abstraktní metody
        /// <summary>
        /// Insert the record.
        /// </summary>
        protected int insert(Pozice pozice)
        {
            Database db = new Database();
            db.Connect();
            SqlCommand command = db.CreateCommand(SQL_INSERT);
            PrepareCommand(command, pozice);
            int ret = db.ExecuteNonQuery(command);
            db.Close();
            return ret;
        }

        /// <summary>
        /// Update the record.
        /// </summary>
        /// <param nazev="pozice"></param>
        /// <returns></returns>
        protected  int update(Pozice pozice)
        {
            Database db = new Database();
            db.Connect();
            SqlCommand command = db.CreateCommand(SQL_UPDATE);
            PrepareCommand(command, pozice);
            int ret = db.ExecuteNonQuery(command);
            db.Close();
            return ret;
        }


        /// <summary>
        /// Select records.
        /// </summary>
        protected  Collection<Pozice> select()
        {
            Database db = new Database();
            db.Connect();

            SqlCommand command = db.CreateCommand(SQL_SELECT);
            SqlDataReader reader = db.Select(command);

            Collection<Pozice> Pozices = Read(reader, true);
            reader.Close();
            db.Close();
            return Pozices;
        }

        /// <summary>
        /// Select records for pozice.
        /// </summary>
        public Pozice select(int id_pozice)
        {
            Database db = new Database();
            db.Connect();
            SqlCommand command = db.CreateCommand(SQL_SELECT_ID);

            command.Parameters.AddWithValue("@id_pozice", id_pozice);
            SqlDataReader reader = db.Select(command);

            Collection<Pozice> pozices = Read(reader);
            Pozice pozice = null;
            if (pozices.Count == 1)
            {
                pozice = pozices[0];
            }
            reader.Close();
            db.Close();
            return pozice;
        }
        /// <summary>
        /// Delete the record.
        /// </summary>
        protected  int delete(int id)
        {
            Database db = new Database();
            db.Connect();
            SqlCommand command = db.CreateCommand(SQL_DELETE_ID);

            command.Parameters.AddWithValue("@id_pozice", id);
            int ret = db.ExecuteNonQuery(command);

            db.Close();
            return ret;
        }
        #endregion

        /// <summary>
        /// Prepare a command.
        /// </summary>
        private static void PrepareCommand(SqlCommand command, Pozice pozice)
        {
            command.Parameters.AddWithValue("@id_pozice", pozice.id_pozice);
            command.Parameters.AddWithValue("@nazev", pozice.nazev);
        }


        private static Collection<Pozice> Read(SqlDataReader reader, bool withItemsCount = false)
        {
            Collection<Pozice> pozices = new Collection<Pozice>();

            while (reader.Read())
            {
                Pozice pozice = new Pozice();
                int i = -1;
                pozice.id_pozice = reader.GetInt32(++i);
                pozice.nazev = reader.GetString(++i);

                pozices.Add(pozice);
            }
            return pozices;
        }
    }
}
