using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Npgsql;

namespace KP3000
{
    public class Postgres
    {

        public NpgsqlConnection conn = new NpgsqlConnection("Server=localhost;Port=5432;User Id=KP3000;Password=KP3000;Database=KP3000");





    }
}