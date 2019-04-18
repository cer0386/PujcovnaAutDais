using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PujcovnaAutORM.ORM.mssql
{
    public class RezervaceTable
    {
        //public static String SQL_SELECT = "SELECT * FROM \"Rezervace\"";
        public static String SQL_SELECT_ID = "SELECT \"Cislo_Rezervace\", \"Cislo_ridickeho_prukazu\", \"ID_zamestnance\", "+
            "\"Vyzvednuti\", \"Vraceni\" FROM \"Rezervace\" "
            +"WHERE Cislo_rezervace = @cislo_rezervace";

        public static String SQL_SELECT_MAXCisloR = "SELECT MAX(Cislo_rezervace) FROM \"Rezervace\""; 

        public static String SQL_SELECT_NEXTWEEK = "SELECT \"Cislo_Rezervace\", \"Cislo_ridickeho_prukazu\", \"ID_zamestnance\", " +
            "\"Vyzvednuti\", \"Vraceni\" FROM \"Rezervace\" "+
            "WHERE Vraceni>CAST(GETDATE() AS DATE) AND Vraceni<DATEADD(week,2,CAST(GETDATE() AS DATE))";

        public static String SQL_SELECT_ZAK = "SELECT \"Cislo_Rezervace\", \"Cislo_ridickeho_prukazu\", \"ID_zamestnance\", " +
            "\"Vyzvednuti\", \"Vraceni\" FROM \"Rezervace\" WHERE Cislo_ridickeho_prukazu=@cislo_RP ORDER BY Vyzvednuti";

        public static String SQL_SELECT_ZAM = "SELECT \"Cislo_Rezervace\", \"Cislo_ridickeho_prukazu\", \"ID_zamestnance\", " +
            "\"Vyzvednuti\", \"Vraceni\" FROM \"Rezervace\" WHERE ID_zamestnance=@idZamestnance";

        public static String SQL_SELECT_AUTO = "SELECT r.\"Cislo_Rezervace\", \"Cislo_ridickeho_prukazu\", \"ID_zamestnance\", " +
            "\"Vyzvednuti\", \"Vraceni\" FROM \"Rezervace\" r JOIN \"Rezervovano\" re ON r.Cislo_Rezervace=re.Cislo_Rezervace" +
            " where re.SPZ=@spz";

        public static String SQL_INSERT = "INSERT INTO \"Rezervace \" VALUES ( @zakaznik, @zamestnanec," +
            "@vyzvednuti, @vraceni)";

        public static String SQL_DELETE_ID = "DELETE FROM \"Rezervace\" WHERE Cislo_rezezervace = @cislo_rezervace";
        public static String SQL_UPDATE = "UPDATE \"Rezervace\" SET Cislo_rezervace=@cislo_rezervace, Zakaznik=@zakaznik, " +
            "Zamestnanec=@zamestnanec, Vyzvednuti=@vyzvednuti, Vraceni=@vraceni";

        #region Abstraktní metody
        /// <summary>
        /// Insert the record.
        /// </summary>
        public static int insert(Rezervace rezervace, Database pDb = null)
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
        public static int update(Rezervace rezervace, Database pDb = null)
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

        /*
        /// <summary>
        /// Select the records.
        /// </summary>
        public Collection<Rezervace> select(Database pDb = null)
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
        */
        /// <summary>
        /// Select the records.
        /// </summary>
        public Collection<Rezervace> selectNextWeek(Database pDb = null)
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

            SqlCommand command = db.CreateCommand(SQL_SELECT_NEXTWEEK);
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
        /// Select the records.
        /// </summary>
        public Collection<Rezervace> selectZak(string cislo_RP,Database pDb = null)
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

            SqlCommand command = db.CreateCommand(SQL_SELECT_ZAK);
            command.Parameters.AddWithValue("@cislo_RP", cislo_RP);
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
        /// Select the records.
        /// </summary>
        public Collection<Rezervace> selectZam(string zam_ID, Database pDb = null)
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

            SqlCommand command = db.CreateCommand(SQL_SELECT_ZAM);
            command.Parameters.AddWithValue("@idZamestnance", zam_ID);
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
        /// Select the records.
        /// </summary>
        public Collection<Rezervace> selectAuto(string spz, Database pDb = null)
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

            SqlCommand command = db.CreateCommand(SQL_SELECT_AUTO);
            command.Parameters.AddWithValue("@spz", spz);
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

        public int selectMax( Database pDb = null)
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

            SqlCommand command = db.CreateCommand(SQL_SELECT_MAXCisloR);
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
        /// <param name="idUser">rezervace id</param>
        /// <returns></returns>
        public static int delete(int cislo_rezervace, Database pDb = null)
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
            command.Parameters.AddWithValue("@zakaznik", rezervace.cislo_rp);
            command.Parameters.AddWithValue("@zamestnanec", rezervace.id_zam);
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
                rezervace.cislo_rp = reader.GetString(++i);
                rezervace.zakaznik = new Zakaznik();
                rezervace.zakaznik.cislo_RP = rezervace.cislo_rp;
                rezervace.id_zam = reader.GetString(++i);
                rezervace.zamestnanec = new Zamestnanec();
                rezervace.zamestnanec.id_zamestnance = rezervace.id_zam;
                rezervace.vyzvednuti = reader.GetDateTime(++i);
                rezervace.vraceni = reader.GetDateTime(++i);

                rezervaces.Add(rezervace);
            }

            return rezervaces;
        }
    }
}
