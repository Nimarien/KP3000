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
        public NpgsqlConnection conn = new NpgsqlConnection("Server=localhost;Port=5432;User Id=KP3000;Password=KP3000;Database=KP3000");

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

                användare användaren = new användare();

                while (dr.Read())
                { 
                     användaren = new användare()
                    {
                        anvid = (int)dr["användarid"],
                        login = dr["login"].ToString(),
                        lösen = dr["lösen"].ToString(),
                        användarnamn = dr["användarnamn"].ToString(),
                        ärAdmin = (bool)dr["äradmin"],
                        testDatum = (DateTime)dr["testdatum"]
                    };
                }
                return användaren;
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

    }
}