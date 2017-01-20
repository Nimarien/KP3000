﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Npgsql;
using System.ComponentModel;

namespace KP3000
{

    public class Postgres
    {
        public string ex { get; set; }
        public NpgsqlConnection conn = new NpgsqlConnection("Server=localhost;Port=5432;User Id=KP3000;Password=KP3000;Database=KP3000;");

        /// <summary>
        /// HÄMTA INFO UTIFRÅN INLOGGNING
        /// </summary>
        /// <param name="anv"></param>
        /// <param name="lösen"></param>
        /// <returns></returns>
        public användare hämtaAnvändarInfo(string anv, string lösen)
        {
            try
            {
                conn.Open();
                string sql = "SELECT * FROM användare WHERE login = @anv AND lösen = @losen";
                NpgsqlCommand cmd = new NpgsqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("anv", anv);
                cmd.Parameters.AddWithValue("losen", lösen);
                NpgsqlDataReader dr = cmd.ExecuteReader();

                användare användaren;

                while (dr.Read())
                { 
                     användaren = new användare()
                    {
                        anvid = (int)dr["användarid"],
                        användarnamn = dr["användarnamn"].ToString(),
                        login = dr["login"].ToString(),
                        lösen = dr["lösen"].ToString(),
                        ärAdmin = (bool)dr["äradmin"],
                        testDatum = (DateTime)dr["testdatum"],
                        anställd = (bool)dr["anställd"]
                     };
                    dr.Close();
                return användaren;
                }
                return null;
                
            }
            catch (NpgsqlException ex)
            {
                this.ex = ex.Message;
                return null;
            }
            finally
            {
                conn.Close();
            }

        }


        /// <summary>
        /// HÄMTA ALLA LICENSIERADE FRÅN DATABAS
        /// </summary>
        /// <returns></returns>
        public BindingList<användare> hämtaLicensierade()
        {
            try
            {
                conn.Open();
                string sql = "SELECT * FROM användare WHERE anställd = 'true'";

                NpgsqlCommand cmd = new NpgsqlCommand(sql, conn);

                NpgsqlDataReader dr = cmd.ExecuteReader();

                BindingList<användare> anvlista = new BindingList<användare>();
                användare nyanvändare;

                while (dr.Read())
                {
                    nyanvändare = new användare()
                    {
                        //frånvaroid = (int)dr["frånvaroid"],
                        //orsak = dr["orsak"].ToString(),
                        //starttid = dr["starttid"].ToString(),
                        //sluttid = dr["sluttid"].ToString(),
                        //datum = (DateTime)dr["datum"],
                        //heldag = (bool)dr["heldag"],
                    };

                }
                dr.Close();
                return anvlista;
            }
            catch (NpgsqlException ex)
            {
                this.ex = ex.Message;
                return null;
            }
            finally
            {
                conn.Close();
            }
        }

        /// <summary>
        /// HÄMTA ALLA OLICENSERIADE FRÅN DATABAS
        /// </summary>
        /// <returns></returns>
        public BindingList<användare> hämtaOlicensierade()
        {
            return null;
        }

        /// <summary>
        /// LÄGG TILL NYTT GODKÄNT TESTDATUM
        /// </summary>
        /// <param name="datum"></param>
        /// <param name="anvid"></param>
        public void nyttTestdatum(DateTime datum, int anvid)
        {
            string testdatum = datum.ToShortDateString();

            try
            {
                conn.Open();
                string sql = "INSERT INTO användare (testdatum) VALUES (@testdatum) WHERE användarid = @anvid";

                NpgsqlCommand cmd = new NpgsqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("testdatum", testdatum);
                cmd.Parameters.AddWithValue("anvid", anvid);
                cmd.ExecuteNonQuery();
            }
            catch (NpgsqlException ex)
            {
                this.ex = ex.Message;
            }
            conn.Close();
        }

        /// <summary>
        /// ÄNDRA GODKÄNT TESTDATUM 
        /// </summary>
        /// <param name="datum"></param>
        /// <param name="anvid"></param>
        public void ändraDatum(DateTime datum, int anvid)
        {
            string testdatum = datum.ToShortDateString();

            try
            {
                conn.Open();
                string sql = "UPDATE användare SET testdatum = @testdatum WHERE användarid = @anvid";

                NpgsqlCommand cmd = new NpgsqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("testdatum", testdatum);
                cmd.Parameters.AddWithValue("anvid", anvid);
                cmd.ExecuteNonQuery();
            }
            catch (NpgsqlException ex)
            {
                this.ex = ex.Message;
            }
            conn.Close();
        }


    }
}