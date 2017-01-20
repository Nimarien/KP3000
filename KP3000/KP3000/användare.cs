using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KP3000
{
    public class användare
    {
        public int anvid { get; set; }
        public string användarnamn { get; set; }
        public string login { get; set; }
        public string lösen { get; set; }
        public bool anställd { get; set; }
        public bool ärAdmin { get; set; }
        public DateTime testDatum { get; set; }


        public override string ToString()
        {
            if (ärAdmin == true)
            {
                return användarnamn + "(Admin)";
            }
            else if (anställd == true)
            {
                return användarnamn + "(Anställd)";
            }
            else
            {
                return användarnamn + "(ej anställd)";
            }
        }
    }
}