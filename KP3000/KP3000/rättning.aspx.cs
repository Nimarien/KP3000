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
            double procentett;
            double proenttvå;
            double procenttre;
            bool klaradetestet = false;

            Label1.Text = "Du fick totalt " + antalrätt + " rätt på testet, och " + antalfel + " fel på testet.";
            rättandet(rättpådelett, rättpådeltvå, rättpådeltre, out procentett, out proenttvå, out procenttre);
            gridd1(procentett, proenttvå, procenttre);
            gridd2();
            klar(procentett, proenttvå, procenttre, antalrätt, out klaradetestet);
            gridd3(klaradetestet);
        }

        public void rättandet(int a, int b, int c, out double d, out double e, out double f)
        {
            int delett = 0;
            int deltvå = 0;
            int deltre = 0;



            if ((bool)Session["anställd"] == true)
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
            else if ((bool)Session["anställd"] == false)
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

            d = procentett;
            e = procenttvå;
            f = procenttre;
        }

        //griddview1
        public void gridd1 (double d, double e, double f)
        {
            List<gridview1> hubbabubba = new List<gridview1>();

            string delett = "Produkter och hantering av kundens affärer";
            string deltvå = "Ekonomi – nationalekonomi, finansiell ekonomi och privatekonomi";
            string deltre = "Etik och regelverk";
          
            gridview1 nydel1 = new gridview1();

            nydel1.del = delett;
            nydel1.procent = Math.Round(d, 2);
            if (d >= 60)
            {                
                nydel1.godkänd = "ja";
            }
            else if (d < 60)
            {
                nydel1.godkänd = "nej";
            }
            hubbabubba.Add(nydel1);

            gridview1 nydel2 = new gridview1();

            nydel2.del = deltvå;
            nydel2.procent = Math.Round(e, 2);
            if (e >= 60)
            {
                nydel2.godkänd = "ja";
            }
            else if (e < 60)
            {
                nydel2.godkänd = "nej";
            }
            
            hubbabubba.Add(nydel2);


            gridview1 nydel3 = new gridview1();

            nydel3.del = deltre;
            nydel3.procent = Math.Round(f, 2);
            if (f >= 60)
            {
                nydel3.godkänd = "ja";
            }
            else if (f < 60)
            {
                nydel3.godkänd = "nej";
            }
            hubbabubba.Add(nydel3);

            Gridden.DataSource = hubbabubba;
            Gridden.DataBind();
        }

        //griddview2
        public void gridd2 ()
        {
            List<frågor> felsvar = (List<frågor>)Session["felsvar"];

            var resultat = from frågor in felsvar select new { frågor.Text, frågor.användarsvar, frågor.Svar, frågor.Svar2 };
            //felsvar.Where(frågor => frågor.Text != null && frågor.användarsvar != null && frågor.Svar != null && frågor.Svar2 != null);

            Gridden2.DataSource = resultat.ToList();
            Gridden2.DataBind();


        }

        public void sparatilldatabas()
        {

        }

        //för att se om allt användare är godkänd totalt
        public void klar (double a, double b, double c, int e, out bool d)
        {
            d = false;
            double p = 0;
            int måsteuppitvå = 0;

            if (a >= 60)
            {
                måsteuppitvå++;
            }
            if (b >= 60 )
            {
                måsteuppitvå++;
            }
            if (c >= 60)
            {
                måsteuppitvå++;

            }
            if ((bool)Session["anställd"] == true)
            {
                double max = 25;
                double hundra = 100;
                double rätten = e;

                double k = rätten / max;
                p = k * hundra;
                Math.Round(p, 2);
            }
            else if ((bool)Session["anställd"] == false)
            {
                double max = 15;
                double hundra = 100;
                double rätten = e;

                double k = rätten / max;
                p = k * hundra;
                Math.Round(p, 2);
            }

            if (måsteuppitvå >= 2 || p >= 70)
            {
                d = true;
            }
            else
            {
                d = false;
            }
        
        }

        //visa i label om hen är godkänd
        public void gridd3 (bool a)
        {
            if (a == true)
            {
                Label3.Text = "grattis!! du klarade testet";
            }
            else if (a == false)
            {
                Label3.Text = "det blir till att göra om, sopa!";
            }

        }
    }
}