using System;
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
                        namn = dr["användarnamn"].ToString(),
                        login = dr["login"].ToString(),
                        lösen = dr["lösen"].ToString(),
                        ärAdmin = (bool)dr["äradmin"],                    
                        anställd = (bool)dr["anställd"],
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
                string sql = "SELECT användare.användarnamn, test.datumgodkänt, test.datumsenaste, test.antalrätt, test.antalfel " +
                             " FROM användare " +
                             " INNER JOIN test " +
                             " ON användare.användarid = test.användarid " +
                             " WHERE anställd = false";

                NpgsqlCommand cmd = new NpgsqlCommand(sql, conn);
                NpgsqlDataReader dr = cmd.ExecuteReader();

                BindingList<användare> anvlista = new BindingList<användare>();
                användare nyanvändare;

                while (dr.Read())
                {

                        nyanvändare = new användare()
                        {
                            namn = dr["användarnamn"].ToString(),
                            datumgodkänt = dr["datumgodkänt"].ToString(),
                            testDatum = dr["datumsenaste"].ToString(),
                            antalRätt = (int)dr["antalrätt"],
                            antalFel = (int)dr["antalfel"],
                        };
                    anvlista.Add(nyanvändare);
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
        public BindingList<användare> hämtaÅKU()
        {
            try
            {
                conn.Open();
                string sql = "SELECT användare.användarnamn, test.datumgodkänt, test.datumsenaste, test.antalrätt, test.antalfel " +
                             " FROM användare " +
                             " INNER JOIN test " +
                             " ON användare.användarid = test.användarid " +
                             " WHERE anställd = true";

                NpgsqlCommand cmd = new NpgsqlCommand(sql, conn);
                NpgsqlDataReader dr = cmd.ExecuteReader();

                BindingList<användare> anvlista = new BindingList<användare>();
                användare nyanvändare;

                while (dr.Read())
                {
                    nyanvändare = new användare()
                    {
                        namn = dr["användarnamn"].ToString(),
                        datumgodkänt = dr["datumgodkänt"].ToString(),
                        testDatum = dr["datumsenaste"].ToString(),
                        antalRätt = (int)dr["antalrätt"],
                        antalFel = (int)dr["antalfel"],
                    };
                    anvlista.Add(nyanvändare);
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
        /// HÄMTA RESULTAT FÖR MEDARBETARE
        /// </summary>
        /// <param name="anvid"></param>
        /// <returns></returns>
        public BindingList<användare> hämtaresultat(int anvid)
        {
            try
            {
                conn.Open();
                string sql = "SELECT test.datumgodkänt, test.antalrätt, test.antalfel " +
                             " FROM användare " +
                             " INNER JOIN test " +
                             " ON användare.användarid = test.användarid " +
                             " WHERE test.användarid = @anvid";

                NpgsqlCommand cmd = new NpgsqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("anvid", anvid);
                NpgsqlDataReader dr = cmd.ExecuteReader();

                BindingList<användare> anvlista = new BindingList<användare>();
                användare nyanvändare;

                while (dr.Read())
                {
                     nyanvändare = new användare()
                    {
                        datumgodkänt = dr["datumgodkänt"].ToString(),
                        antalRätt = (int)dr["antalrätt"],
                        antalFel = (int)dr["antalfel"],
                    };
                    anvlista.Add(nyanvändare);
                }

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
        /// LÄGG TILL TEST I DATABAS
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="datum"></param>
        /// <param name="anvid"></param>
        /// <param name="rätt"></param>
        /// <param name="fel"></param>
        public void sparaTest(string sql, string datum, int anvid, int rätt, int fel)
        {
            try
            {
                conn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("datum", datum);
                cmd.Parameters.AddWithValue("anvid", anvid);
                cmd.Parameters.AddWithValue("ratt", rätt);
                cmd.Parameters.AddWithValue("fel", fel);
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