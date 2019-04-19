using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PujcovnaAutORM.ORM.mssql
{
    public class PlatbaTable
    {
        //static String SQL_SELECT = "SELECT * FROM Platba";

        public static String SQL_SELECT_ID = "SELECT \"ID_platba\", \"Cislo_faktury\", \"ID_typ_platby\", \"Castka\" "+
            "FROM \"Platba\" WHERE ID_platba=@id_platba";

        //Zjištění nejnovějšího čísla platby
        public static String SQL_SELECT_MAXCisloP = "SELECT MAX(ID_platba) FROM \"Platba\"";

        //Výpis všech plateb provedených minulý měsíc
        public static String SQL_SELECT_ZaplacenoMinulyMesic = "SELECT \"ID_platba\", p.\"Cislo_faktury\", \"ID_typ_platby\", \"Castka\" " +
            "FROM \"Platba\" p JOIN \"Faktura\" f ON f.Cislo_faktury=p.Cislo_faktury " +
            "WHERE DATEPART(m, Zaplaceno) = DATEPART(m, DATEADD(m, -1, getdate())) " +
            "AND DATEPART(yyyy, Zaplaceno) = DATEPART(yyyy, DATEADD(m, -1, getdate())) ORDER BY ID_typ_platby";

        public static String SQL_INSERT = "INSERT INTO \"Platba\" VALUES ( @faktura, @typ_platby, @castka)";
        public static String SQL_DELETE_ID = "DELETE FROM \"Platba\" WHERE ID_platba=@id_platba";
        public static String SQL_UPDATE = "UPDATE \"Platba\" SET Cislo_faktury=@faktura, ID_typ_platby=@typ_platby, castka=@castka WHERE ID_platba=@id_platba";

        #region Abstraktní metody
        /// <summary>
        /// Insert the record.
        /// </summary>
        public static int insert(Platba platba, Database pDb = null)
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
            PrepareCommand(command, platba);
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
        /// <param nazev="platba"></param>
        /// <returns></returns>
        public static int update(Platba platba, Database pDb = null)
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
            PrepareCommand(command, platba);
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
        public Collection<Platba> select()
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

            Collection<Platba> Platbas = Read(reader, true);
            reader.Close();
            if (pDb == null)
            {
                db.Close();
            }
            return Platbas;
        }
        */
        /// <summary>
        /// Select records for platba.
        /// </summary>
        public Platba select(int id_platba, Database pDb = null)
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

            command.Parameters.AddWithValue("@id_platba", id_platba);
            SqlDataReader reader = db.Select(command);

            Collection<Platba> platbas = Read(reader);
            Platba platba = null;
            if (platbas.Count == 1)
            {
                platba = platbas[0];
            }
            reader.Close();
            if (pDb == null)
            {
                db.Close();
            }
            return platba;
        }

        /// <summary>
        /// Select records.
        /// </summary>
        public Collection<Platba> selectMinMes(Database pDb = null)
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

            SqlCommand command = db.CreateCommand(SQL_SELECT_ZaplacenoMinulyMesic);
            SqlDataReader reader = db.Select(command);

            Collection<Platba> platbas = Read(reader, true);
            reader.Close();
            if (pDb == null)
            {
                db.Close();
            }
            return platbas;
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

            SqlCommand command = db.CreateCommand(SQL_SELECT_MAXCisloP);
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

            command.Parameters.AddWithValue("@id_platba", id);
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
        private static void PrepareCommand(SqlCommand command, Platba platba)
        {
            command.Parameters.AddWithValue("@id_platba", platba.id_platba);
            command.Parameters.AddWithValue("@faktura", platba.cislo_f);
            command.Parameters.AddWithValue("@typ_platby", platba.typ_pl);
            command.Parameters.AddWithValue("@castka", platba.castka);
        }


        private static Collection<Platba> Read(SqlDataReader reader, bool withItemsCount = false)
        {
            Collection<Platba> platbas = new Collection<Platba>();

            while (reader.Read())
            {
                Platba platba = new Platba();
                int i = -1;
                platba.id_platba = reader.GetInt32(++i);
                platba.cislo_f = reader.GetInt32(++i);
                platba.faktura = new Faktura();
                platba.faktura.cislo_faktury = platba.cislo_f;
                platba.typ_pl = reader.GetInt32(++i);
                platba.typ_platby = new Typ_platby();
                platba.typ_platby.id_typ_platby = platba.typ_pl;
                platba.castka = reader.GetInt32(++i);

                platbas.Add(platba);
            }
            return platbas;
        }
    }
}
