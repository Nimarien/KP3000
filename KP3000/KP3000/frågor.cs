using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;

namespace KP3000
{
    public class frågor
    {
        public string Del { get; set; }
        public string Nummer { get; set; }
        public string Text { get; set; }
        public string Alternativ1 { get; set; }
        public string Alternativ2 { get; set; }
        public string Alternativ3 { get; set; }
        public string Svar { get; set; }
        public string Svar2 { get; set; }
        public string användarsvar { get; set; }


        public override string ToString()
        {
            return Text + användarsvar + Svar;
        }
    }
}