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
    public class AutoTable
    {
        //public static String SQL_SELECT = "SELECT * FROM \"Auto\"";
        public static String SQL_SELECT_SPZ = "SELECT \"SPZ\", \"Model\", \"Znacka\", \"Zakoupeno\", \"STK\", \"Pocet_nehod\","+
            "\"Servis\", \"Najeto\", \"Cena_za_den\" FROM \"Auto\" WHERE SPZ = @spz";

        //auta na rezervaci
        public static String SQL_SELECT_AutaNaRez = "SELECT a.\"SPZ\", \"Model\", \"Znacka\", \"Zakoupeno\", \"STK\", \"Pocet_nehod\"," +
            "\"Servis\", \"Najeto\", \"Cena_za_den\" FROM \"Rezervovano\" re JOIN \"Auto\" a on a.SPZ=re.SPZ WHERE Cislo_rezervace=@cislo_rezervace";

        //Vyřazená auta - nové
        public static String SQL_SELECT_VyrazenaAuta = "SELECT \"SPZ\", \"Model\", \"Znacka\", \"Zakoupeno\", \"STK\", \"Pocet_nehod\"," +
            "\"Servis\", \"Najeto\", \"Cena_za_den\" FROM \"Auto\" WHERE Servis=1";

        //pocet rezervací auta v zadaném intervalu
        public static String SQL_SELECT_PocetRez = "SELECT COUNT(r.Cislo_rezervace) FROM \"Rezervace\" r JOIN \"Rezervovano\" re " +
            "ON re.Cislo_Rezervace = r.Cislo_Rezervace WHERE r.Vyzvednuti < @Do AND r.Vraceni > @Od AND SPZ = @spz";

        //Počet budoucích rezervací(kontrola jestli je auto zapůjčeno)
        public static String SQL_SELECT_KontrolaZapujceni = "SELECT COUNT(r.Cislo_rezervace) FROM \"Rezervace\" r JOIN \"Rezervovano\" re " +
            "ON re.Cislo_Rezervace = r.Cislo_Rezervace WHERE r.Vraceni > @Od AND SPZ = @spz";

        //seznam dostupných aut podle intervalu
        public static String SQL_SELECT_DostupnaAuta = "SELECT \"SPZ\", \"Model\", \"Znacka\", \"Zakoupeno\", \"STK\", \"Pocet_nehod\"," +
            "\"Servis\", \"Najeto\", \"Cena_za_den\" FROM \"Auto\" " +
            "EXCEPT "+
            "SELECT a.\"SPZ\", \"Model\", \"Znacka\", \"Zakoupeno\", \"STK\", \"Pocet_nehod\"," +
            "\"Servis\", \"Najeto\", \"Cena_za_den\" FROM \"Auto\" a " +
            "JOIN \"Rezervovano\" re on re.SPZ = a.SPZ "+
            "JOIN \"Rezervace\" r on r.Cislo_Rezervace = re.Cislo_Rezervace " +
            "JOIN \"Servis\" s on s.SPZ = a.SPZ "+
            "WHERE ((r.Vyzvednuti< @Do AND r.Vraceni> @Od) "+
            "OR(s.Od > @Do AND s.Do< @Od)) "+
            "OR a.servis = 1";

        //seznam dostupných aut z podobné cenové relace
        public static String SQL_SELECT_PodobneAuta = "SELECT \"SPZ\", \"Model\", \"Znacka\", \"Zakoupeno\", \"STK\", \"Pocet_nehod\"," +
            "\"Servis\", \"Najeto\", \"Cena_za_den\" FROM \"Auto\" WHERE Cena_za_den BETWEEN (@cena_za_denA - 200) AND (@cena_za_denA +200) " +
            "EXCEPT "+
            "SELECT a.\"SPZ\", \"Model\", \"Znacka\", \"Zakoupeno\", \"STK\", \"Pocet_nehod\"," +
            "\"Servis\", \"Najeto\", \"Cena_za_den\" FROM \"Auto\" a " +
            "JOIN \"Rezervovano\" re on re.SPZ = a.SPZ " +
            "JOIN \"Rezervace\" r on re.Cislo_rezervace = r.Cislo_rezervace "+
            "WHERE (r.Vyzvednuti<@vraceni AND r.Vraceni> @vyzvednuti)";


        public static String SQL_INSERT = "INSERT INTO \"Auto \" VALUES (@spz, @model, @znacka, @zakoupeno, " +
            "@stk, @pocet_nehod, @servis, @najeto, @cena_za_den)";
        public static String SQL_DELETE_SPZ = "DELETE FROM \"Auto\" WHERE SPZ = @spz";
        public static String SQL_UPDATE = "UPDATE \"Auto\" SET Model=@model, " +
            "Znacka=@znacka, Zakoupeno=@zakoupeno, STK=@stk, Pocet_nehod=@pocet_nehod, Servis=@servis,najeto=@najeto, " +
            "Cena_za_den=@cena_za_den WHERE SPZ=@spz";
        public static String SQL_UPDATE_Servis = "UPDATE \"Auto\" SET Servis=@servis WHERE SPZ=@spz";

        //nahrazení auta na rezervaci
        public static String SQL_UPDATE_NahraditAuta = "UPDATE \"Rezervovano\" SET SPZ = @newSPZ where Cislo_rezervace = (SELECT DISTINCT(r.Cislo_Rezervace) FROM \"Rezervovano\" re " +
            "JOIN \"Rezervace\" r on r.Cislo_rezervace = re.Cislo_Rezervace " +
            "WHERE spz=@spz AND " +
            "(r.Vraceni > @vyzvednuti AND r.Vyzvednuti<@vraceni))"; 


        #region Abstraktní metody

        //vyřazení auta Uložená proscedura, vracející data pro vyzvednutí a vrácení
        public Collection<DateTime?>  vyrazeniAutaData(string spz, Database pDb = null)
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
            SqlCommand command = db.CreateCommand("VyraditAutoData");
            command.CommandType = CommandType.StoredProcedure;

            SqlParameter input = new SqlParameter();
            input.ParameterName = "@p_spz";
            input.DbType = DbType.String;
            input.Value = spz;
            input.Direction = ParameterDirection.Input;
            command.Parameters.Add(input);

            SqlParameter output2 = new SqlParameter();
            output2.Direction = ParameterDirection.Output;
            output2.DbType = DbType.Date;
            output2.ParameterName = "@vyzvednuti";
            command.Parameters.Add(output2);

            SqlParameter output3 = new SqlParameter();
            output3.Direction = ParameterDirection.Output;
            output3.DbType = DbType.Date;
            output3.ParameterName = "@vraceni";
            command.Parameters.Add(output3);

            db.ExecuteNonQuery(command);

            DateTime? vyz = null;
            if (command.Parameters["@vyzvednuti"].Value != DBNull.Value && command.Parameters["@vyzvednuti"].SqlValue != DBNull.Value)
                vyz = Convert.ToDateTime(command.Parameters["@vyzvednuti"].Value);
            DateTime? vrac = null;
            if (command.Parameters["@vraceni"].Value != DBNull.Value)
                vrac = Convert.ToDateTime(command.Parameters["@vraceni"].Value);

            Collection<DateTime?> data = new Collection<DateTime?>();
            data.Add(vyz);
            data.Add(vrac);

            if (pDb == null)
            {
                db.Close();
            }
            return data;
        }

        /// <summary>
        /// Insert the record.
        /// </summary>
        public static int insert(Auto auto, Database pDb = null)
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
            PrepareCommand(command, auto);
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
        public static int update(Auto auto, Database pDb = null)
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
            PrepareCommand(command, auto);
            int ret = db.ExecuteNonQuery(command);

            if (pDb == null)
            {
                db.Close();
            }

            return ret;
        }

        public int updateServis(string spz, bool servis, Database pDb = null)
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

            SqlCommand command = db.CreateCommand(SQL_UPDATE_Servis);
            command.Parameters.AddWithValue("@spz", spz);
            command.Parameters.AddWithValue("@servis", servis);
            int ret = db.ExecuteNonQuery(command);

            if (pDb == null)
            {
                db.Close();
            }

            return ret;
        }

        public static int updateRez(string spz, string newSPZ, DateTime vyz, DateTime vrac, Database pDb = null)
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

            SqlCommand command = db.CreateCommand(SQL_UPDATE_NahraditAuta);
            command.Parameters.AddWithValue("@spz", spz);
            command.Parameters.AddWithValue("@newSPZ", newSPZ);
            command.Parameters.AddWithValue("@vyzvednuti", vyz);
            command.Parameters.AddWithValue("@vraceni", vrac);
            int ret = db.ExecuteNonQuery(command);

            if (pDb == null)
            {
                db.Close();
            }

            return ret;
        }
        /// <summary>
        /// Select the record.
        /// </summary>
        /// <param name="id">rezervovano id</param>
        public Collection<Auto> selectAuta(int cislo_rezervace, Database pDb = null)
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

            SqlCommand command = db.CreateCommand(SQL_SELECT_AutaNaRez);

            command.Parameters.AddWithValue("@cislo_rezervace", cislo_rezervace);
            SqlDataReader reader = db.Select(command);

            Collection<Auto> auta = Read(reader);
            reader.Close();

            if (pDb == null)
            {
                db.Close();
            }

            return auta;
        }


        /*
        /// <summary>
        /// Select the records.
        /// </summary>
        public Collection<Auto> select(Database pDb = null)
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

            Collection<Auto> autos = Read(reader);
            reader.Close();

            if (pDb == null)
            {
                db.Close();
            }

            return autos;
        }
        */
        /// <summary>
        /// Select the record.
        /// </summary>
        /// <param name="id">auto id</param>
        public Auto select(string spz, Database pDb = null)
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

            Collection<Auto> autos = Read(reader);
            Auto auto = null;
            if (autos.Count == 1)
            {
                auto = autos[0];
            }
            reader.Close();

            if (pDb == null)
            {
                db.Close();
            }

            return auto;
        }

        /// <summary>
        /// Select the record.
        /// </summary>
        /// <param name="id">auto id</param>
        public int selectPocetRez(string spz, DateTime vyz, DateTime vra, Database pDb = null)
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

            SqlCommand command = db.CreateCommand(SQL_SELECT_PocetRez);

            command.Parameters.AddWithValue("@spz", spz);
            command.Parameters.AddWithValue("@Od", vyz);
            command.Parameters.AddWithValue("@Do", vra);
            SqlDataReader reader = db.Select(command);
            reader.Read();
            int pocet = reader.GetInt32(0);
            reader.Close();

            if (pDb == null)
            {
                db.Close();
            }

            return pocet;
        }

        /// <summary>
        /// Select the record.
        /// </summary>
        /// <param name="id">auto id</param>
        public int selectPocetBudRez(string spz, DateTime vra, Database pDb = null)
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

            SqlCommand command = db.CreateCommand(SQL_SELECT_KontrolaZapujceni);

            command.Parameters.AddWithValue("@spz", spz);
            command.Parameters.AddWithValue("@Do", vra);
            SqlDataReader reader = db.Select(command);
            reader.Read();
            int pocet = reader.GetInt32(0);
            reader.Close();

            if (pDb == null)
            {
                db.Close();
            }

            return pocet;
        }

        public Collection<Auto> select(DateTime od, DateTime do_, Database pDb = null)
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

            SqlCommand command = db.CreateCommand(SQL_SELECT_DostupnaAuta);
            command.Parameters.AddWithValue("@Od", od);
            command.Parameters.AddWithValue("@Do", do_);
            SqlDataReader reader = db.Select(command);

            Collection<Auto> autos = Read(reader);
            reader.Close();

            if (pDb == null)
            {
                db.Close();
            }

            return autos;
        }

        public Collection<Auto> selectVyrAuta(Database pDb = null)
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

            SqlCommand command = db.CreateCommand(SQL_SELECT_VyrazenaAuta);
            SqlDataReader reader = db.Select(command);

            Collection<Auto> autos = Read(reader);
            reader.Close();

            if (pDb == null)
            {
                db.Close();
            }

            return autos;
        }

        public Collection<Auto> select(DateTime od, DateTime do_, int cenaZaDen, string spz, Database pDb = null)
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

            SqlCommand command = db.CreateCommand(SQL_SELECT_PodobneAuta);
            command.Parameters.AddWithValue("@vyzvednuti", od);
            command.Parameters.AddWithValue("@vraceni", do_);
            command.Parameters.AddWithValue("@cena_za_denA ", cenaZaDen);
            SqlDataReader reader = db.Select(command);

            Collection<Auto> autos = Read(reader);
            reader.Close();

            if (pDb == null)
            {
                db.Close();
            }

            return autos;
        }

        /// <summary>
        /// Delete the record.
        /// </summary>
        /// <param name="idUser">auto id</param>
        /// <returns></returns>
        public static int delete(string spz, Database pDb = null)
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

            command.Parameters.AddWithValue("@spz", spz);
            int ret = db.ExecuteNonQuery(command);

            if (pDb == null)
            {
                db.Close();
            }

            return ret;
        }
        #endregion

        private static void PrepareCommand(SqlCommand command, Auto auto)
        {
            command.Parameters.AddWithValue("@spz", auto.spz);
            command.Parameters.AddWithValue("@model", auto.model);
            command.Parameters.AddWithValue("@znacka", auto.znacka);
            command.Parameters.AddWithValue("@zakoupeno", auto.zakoupeno);
            command.Parameters.AddWithValue("@stk", auto.stk);
            command.Parameters.AddWithValue("@pocet_nehod", auto.pocet_nehod);
            command.Parameters.AddWithValue("@servis", auto.servis);
            command.Parameters.AddWithValue("@najeto", auto.najeto);
            command.Parameters.AddWithValue("@cena_za_den", auto.cena_za_den);
        }

        private static Collection<Auto> Read(SqlDataReader reader)
        {
            Collection<Auto> autos = new Collection<Auto>();

            while (reader.Read())
            {
                int i = -1;
                Auto auto = new Auto();
                auto.spz = reader.GetString(++i);
                auto.model = reader.GetString(++i);
                auto.znacka = reader.GetString(++i);
                auto.zakoupeno = reader.GetDateTime(++i);
                auto.stk = reader.GetDateTime(++i);
                auto.pocet_nehod = reader.GetInt32(++i);
                auto.servis = reader.GetBoolean(++i);
                auto.najeto = reader.GetDecimal(++i);
                auto.cena_za_den = reader.GetInt32(++i);

                autos.Add(auto);
            }

            return autos;
        }
    }
}
