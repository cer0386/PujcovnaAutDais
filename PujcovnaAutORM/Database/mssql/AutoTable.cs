﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PujcovnaAutORM.ORM.mssql
{
    public class AutoTable
    {
        public static String SQL_SELECT = "SELECT * FROM \"Auto\"";
        public static String SQL_SELECT_SPZ = "SELECT * FROM \"Auto\" WHERE SPZ = @spz";
        public static String SQL_INSERT = "INSERT INTO \"Auto \" VALUES (@spz, @model, @znacka, @zakoupeno, " +
            "@stk, @pocet_nehod, @sevis, @najeto, @cena_za_den";
        public static String SQL_DELETE_SPZ = "DELETE FROM \"Auto\" WHERE SPZ = @spz";
        public static String SQL_UPDATE = "UPDATE \"Auto\" SET SPZ=@spz, Model=@model, " +
            "Znacka=@znacka, Zakoupeno=@zakoupeno, STK=@stk, Pocet_nehod=@pocet_nehod, Servis=@servis,najeto=@najeto" +
            "Cena_za_den=@cena_za_den";

        #region Abstraktní metody
        /// <summary>
        /// Insert the record.
        /// </summary>
        protected int insert(Auto auto, Database pDb = null)
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
        protected int update(Auto auto, Database pDb = null)
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


        /// <summary>
        /// Select the records.
        /// </summary>
        protected Collection<Auto> select(Database pDb = null)
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
        /// Delete the record.
        /// </summary>
        /// <param name="idUser">auto id</param>
        /// <returns></returns>
        protected int delete(string spz, Database pDb = null)
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
                auto.najeto = reader.GetDouble(++i);
                auto.cena_za_den = reader.GetInt32(++i);

                autos.Add(auto);
            }

            return autos;
        }
    }
}
