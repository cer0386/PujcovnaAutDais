using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PujcovnaAutORM.Database.mssql
{
    public class RezervaceTable
    {
        public static String SQL_SELECT = "SELECT * FROM \"Rezervace\"";
        public static String SQL_SELECT_ID = "SELECT * FROM \"Rezervace\" WHERE Cislo_rezervace = @cislo_rezervace";
        public static String SQL_INSERT = "INSERT INTO \"Rezervace \" VALUES (@cislo_rezervace, @zakaznik, @zamestnanec," +
            "@vyzvednuti, @vraceni";
        public static String SQL_DELETE_ID = "DELETE FROM \"Rezervace\" WHERE Cislo_rezezervace = @cislo_rezervace";
        public static String SQL_UPDATE = "UPDATE \"Rezervace\" SET Cislo_rezervace=@cislo_rezervace, Zakaznik=@zakaznik, " +
            "Zamestnanec=@zamestnanec, Vyzvednuti=@vyzvednuti, Vraceni=@vraceni";

        #region Abstraktní metody
        /// <summary>
        /// Insert the record.
        /// </summary>
        protected int insert(Rezervace rezervace, Database pDb = null)
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
            PrepareCommand(command, rezervace);
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
        protected int update(Rezervace rezervace, Database pDb = null)
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
            PrepareCommand(command, rezervace);
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
        protected Collection<Rezervace> select(Database pDb = null)
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

            Collection<Rezervace> rezervaces = Read(reader);
            reader.Close();

            if (pDb == null)
            {
                db.Close();
            }

            return rezervaces;
        }

        /// <summary>
        /// Select the record.
        /// </summary>
        /// <param name="id">rezervace id</param>
        public Rezervace select(int cislo_rezervace, Database pDb = null)
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

            command.Parameters.AddWithValue("@cislo_rezervace", cislo_rezervace);
            SqlDataReader reader = db.Select(command);

            Collection<Rezervace> rezervaces = Read(reader);
            Rezervace rezervace = null;
            if (rezervaces.Count == 1)
            {
                rezervace = rezervaces[0];
            }
            reader.Close();

            if (pDb == null)
            {
                db.Close();
            }

            return rezervace;
        }

        /// <summary>
        /// Delete the record.
        /// </summary>
        /// <param name="idUser">rezervace id</param>
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
            SqlCommand command = db.CreateCommand(SQL_DELETE_ID);

            command.Parameters.AddWithValue("@cislo_rezervace", cislo_rezervace);
            int ret = db.ExecuteNonQuery(command);

            if (pDb == null)
            {
                db.Close();
            }

            return ret;
        }
        #endregion

        private static void PrepareCommand(SqlCommand command, Rezervace rezervace)
        {
            command.Parameters.AddWithValue("@cislo_rezervace", rezervace.cislo_rezervace);
            command.Parameters.AddWithValue("@zakaznik", rezervace.zakaznik.cislo_RP);
            command.Parameters.AddWithValue("@zamestnanec", rezervace.zamestnanec.id_zamestnance);
            command.Parameters.AddWithValue("@vyzvednuti", rezervace.vyzvednuti);
            command.Parameters.AddWithValue("@vraceni", rezervace.vraceni);
        }

        private static Collection<Rezervace> Read(SqlDataReader reader)
        {
            Collection<Rezervace> rezervaces = new Collection<Rezervace>();

            while (reader.Read())
            {
                int i = -1;
                Rezervace rezervace = new Rezervace();
                rezervace.cislo_rezervace = reader.GetInt32(++i);
                string idZak = reader.GetString(++i);
                rezervace.zakaznik = new ZakaznikTable().select(idZak);
                string idZam = reader.GetString(++i);
                rezervace.zamestnanec = new ZamestnanecTable().select(idZam);
                rezervace.vyzvednuti = reader.GetDateTime(++i);
                rezervace.vraceni = reader.GetDateTime(++i);

                rezervaces.Add(rezervace);
            }

            return rezervaces;
        }
    }
}
