using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KP3000
{
    public class användare
    {
        public string Namn { get; set; }
        public string Användarnamn { get; set; }
        public bool Anställd { get; set; }
        public bool klaratTest { get; set; }
        public DateTime klaratSenast { get; set; }
        public bool ärAdmin { get; set; }


        public override string ToString()
        {
            if (ärAdmin == true)
            {
                return Namn + "(Admin)";
            }
            else

            return Namn + "(Anställd)";

        }

    }
    
}