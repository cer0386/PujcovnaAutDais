using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PujcovnaAutORM.Database.mssql
{
    public class PlatbaTable
    {
        public static String TABLE_NAME = "Platba";

        public static String SQL_SELECT_ID = "SELECT * FROM Platba WHERE ID_platba=@id_platba";
        public static String SQL_SELECT = "SELECT * FROM Platba";
        public static String SQL_INSERT = "INSERT INTO Platba VALUES (@id_platba, @faktura, @typ_platby, @castka)";
        public static String SQL_DELETE_ID = "DELETE FROM Platba WHERE ID_platba=@id_platba";
        public static String SQL_UPDATE = "UPDATE Platba SET Cislo_faktury=@faktura, ID_typ_platby=@typ_platby, castka=@castka WHERE ID_platba=@id_platba";

        #region Abstraktní metody
        /// <summary>
        /// Insert the record.
        /// </summary>
        protected int insert(Platba platba)
        {
            Database db = new Database();
            db.Connect();
            SqlCommand command = db.CreateCommand(SQL_INSERT);
            PrepareCommand(command, platba);
            int ret = db.ExecuteNonQuery(command);
            db.Close();
            return ret;
        }

        /// <summary>
        /// Update the record.
        /// </summary>
        /// <param nazev="platba"></param>
        /// <returns></returns>
        protected int update(Platba platba)
        {
            Database db = new Database();
            db.Connect();
            SqlCommand command = db.CreateCommand(SQL_UPDATE);
            PrepareCommand(command, platba);
            int ret = db.ExecuteNonQuery(command);
            db.Close();
            return ret;
        }


        /// <summary>
        /// Select records.
        /// </summary>
        protected Collection<Platba> select()
        {
            Database db = new Database();
            db.Connect();

            SqlCommand command = db.CreateCommand(SQL_SELECT);
            SqlDataReader reader = db.Select(command);

            Collection<Platba> Platbas = Read(reader, true);
            reader.Close();
            db.Close();
            return Platbas;
        }

        /// <summary>
        /// Select records for platba.
        /// </summary>
        public Platba select(int id_platba)
        {
            Database db = new Database();
            db.Connect();
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
            db.Close();
            return platba;
        }
        /// <summary>
        /// Delete the record.
        /// </summary>
        protected int delete(int id)
        {
            Database db = new Database();
            db.Connect();
            SqlCommand command = db.CreateCommand(SQL_DELETE_ID);

            command.Parameters.AddWithValue("@id_platba", id);
            int ret = db.ExecuteNonQuery(command);

            db.Close();
            return ret;
        }
        #endregion

        /// <summary>
        /// Prepare a command.
        /// </summary>
        private static void PrepareCommand(SqlCommand command, Platba platba)
        {
            command.Parameters.AddWithValue("@id_platba", platba.id_platba);
            command.Parameters.AddWithValue("@nazev", platba.faktura.cislo_faktury);
            command.Parameters.AddWithValue("@nazev", platba.typ_platby.id_typ_platby);
            command.Parameters.AddWithValue("@nazev", platba.castka);
        }


        private static Collection<Platba> Read(SqlDataReader reader, bool withItemsCount = false)
        {
            Collection<Platba> platbas = new Collection<Platba>();

            while (reader.Read())
            {
                Platba platba = new Platba();
                int i = -1;
                platba.id_platba = reader.GetInt32(++i);
                int cislo_fak = reader.GetInt32(++i);
                platba.faktura = new FakturaTable().select(cislo_fak);
                int id_p = reader.GetInt32(++i);
                platba.typ_platby = new Typ_platbyTable().select(id_p);
                platba.castka = reader.GetInt32(++i);

                platbas.Add(platba);
            }
            return platbas;
        }
    }
}
