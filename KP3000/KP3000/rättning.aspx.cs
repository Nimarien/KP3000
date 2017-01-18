using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace KP3000
{
    public partial class rättning : System.Web.UI.Page
    {
        

        protected void Page_Load(object sender, EventArgs e)
        {
            int antalfel = Convert.ToInt32(Session["fel"]);
            int antalrätt = Convert.ToInt32(Session["rätt"]);
            int rättpådelett = Convert.ToInt32(Session["rättpådelett"]);
            int rättpådeltvå = Convert.ToInt32(Session["rättpådeltvå"]);
            int rättpådeltre = Convert.ToInt32(Session["rättpådeltre"]);

            Label1.Text = "Du fick totalt " + antalrätt + " på testet, och " + antalfel + " på testet.";
            rättandet(rättpådelett, rättpådeltvå, rättpådeltre);
        }

        public void rättandet(int a, int b, int c) 
        {
            int delett = 0;
            int deltvå = 0;
            int deltre = 0;

            if ((string)Session["anställd"] == "test")
            {
                string vägen = Server.MapPath("Licenstest.xml");
                XmlDocument Frågorna = new XmlDocument();
                Frågorna.Load(vägen);
                XmlNodeList Frågedetaljer = Frågorna.SelectNodes("frågor/fråga");
                foreach (XmlNode nod in Frågedetaljer)
                {
                    frågor Fråga = new frågor();
                    Fråga.Del = nod["del"].InnerText;
                    if (Fråga.Del == "Produkter och hantering av kundens affärer")
                    {
                        delett++;
                    }
                    else if (Fråga.Del == "Ekonomi – nationalekonomi, finansiell ekonomi och privatekonomi")
                    {
                        deltvå++;
                    }
                    else if (Fråga.Del == "Etik och regelverk")
                    {
                        deltre++;
                    }
                }
            }
            else if ((string)Session["anställd"] == "fel")
            {
                string vägen = Server.MapPath("ÅKU.xml");
                XmlDocument Frågorna = new XmlDocument();
                Frågorna.Load(vägen);
                XmlNodeList Frågedetaljer = Frågorna.SelectNodes("frågor/fråga");
                foreach (XmlNode nod in Frågedetaljer)
                {
                    frågor Fråga = new frågor();
                    Fråga.Del = nod["del"].InnerText;
                    if (Fråga.Del == "Produkter och hantering av kundens affärer")
                    {
                        delett++;
                    }
                    else if (Fråga.Del == "Ekonomi – nationalekonomi, finansiell ekonomi och privatekonomi")
                    {
                        deltvå++;
                    }
                    else if (Fråga.Del == "Etik och regelverk")
                    {
                        deltre++;
                    }
                }
            }
            double max = 100;
            double ab = a;
            double bb = b;
            double cb = c;

            double ett = ab / delett;
            double procentett = ett * max;
            double två = bb / deltvå;
            double procenttvå = två * max;
            double tre = cb / deltre;
            double procenttre = tre * max;
        }
        
    }
}