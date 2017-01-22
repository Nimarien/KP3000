using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KP3000
{
    public class användare
    {
        public int anvid { get; set; }
        public string namn { get; set; }
        public string login { get; set; }
        public string lösen { get; set; }
        public bool anställd { get; set; }
        public bool ärAdmin { get; set; }
        public DateTime testDatum { get; set; }
        public DateTime datumgodkänt { get; set; }
        public int antalRätt { get; set; }
        public int antalFel { get; set; }

        public override string ToString()
        {
            if (ärAdmin == true)
            {
                return namn + "(Admin)";
            }
            else if (anställd == true)
            {
                return namn + "(Anställd)";
            }
            else
            {
                return namn + "(ej anställd)";
            }
        }
    }
}