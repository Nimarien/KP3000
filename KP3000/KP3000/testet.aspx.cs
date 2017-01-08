using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Xml;

namespace KP3000
{
    public partial class testet : System.Web.UI.Page
    {
        int räkna;
        List<frågor> AllaFrågorÅ = new List<frågor>();
        List<frågor> AllaFrågorL = new List<frågor>();
        List<string> SvarL = new List<string>();
        List<string> SvarÅ = new List<string>();


        //pageload
        protected void Page_Load(object sender, EventArgs e)
        {
           if (!IsPostBack)
            {
                skapaFrågor();
                Session["counter"] = 0;
            }

            Button1.Enabled = true;
            Button3.Enabled = false;

            if  (Convert.ToInt32(Session["counter"]) == 0)
            {
                Button1.Enabled = false;
            }
            else if (Convert.ToInt32(Session["counter"]) == räkna)
            {
                Button2.Enabled = false;
                Button3.Enabled = true;
            }


        }

        //ladda alla frågor vid Åku
        public List<frågor> LagraAllaFrågorÅku()
        {
            string vägen = Server.MapPath("ÅKU.xml");
            XmlDocument Frågorna = new XmlDocument();
            Frågorna.Load(vägen);
            XmlNodeList Frågedetaljer = Frågorna.SelectNodes("frågor/fråga");
            foreach (XmlNode nod in Frågedetaljer)
            {
                frågor Fråga = new frågor();
                Fråga.Del = nod["del"].InnerText;
                Fråga.Nummer = nod["nummer"].InnerText;
                Fråga.Text = nod["text"].InnerText;
                Fråga.Alternativ1 = nod["alternativett"].InnerText;
                Fråga.Alternativ2 = nod["alternativtvå"].InnerText;
                Fråga.Alternativ3 = nod["alternativtre"].InnerText;
                Fråga.Svar = nod["svar"].InnerText;
                Fråga.Svar2 = nod["svartvå"].InnerText;

                AllaFrågorÅ.Add(Fråga);
                räkna++;
            }
            return AllaFrågorÅ;
        }

        //ladda in alla frågor vid licensiering
        public List<frågor> LagraAllaFrågorLicensierad()
        {
            string vägen = Server.MapPath("Licenstest.xml");
            XmlDocument Frågorna = new XmlDocument();
            Frågorna.Load(vägen);
            XmlNodeList Frågedetaljer = Frågorna.SelectNodes("frågor/fråga");
            foreach (XmlNode nod in Frågedetaljer)
            {
                frågor Fråga = new frågor();
                Fråga.Del = nod["del"].InnerText;
                Fråga.Nummer = nod["nummer"].InnerText;
                Fråga.Text = nod["text"].InnerText;
                Fråga.Alternativ1 = nod["alternativett"].InnerText;
                Fråga.Alternativ2 = nod["alternativtvå"].InnerText;
                Fråga.Alternativ3 = nod["alternativtre"].InnerText;
                Fråga.Svar = nod["svar"].InnerText;
                Fråga.Svar2 = nod["svartvå"].InnerText;

                AllaFrågorL.Add(Fråga);
                räkna++;
            }
            return AllaFrågorL;
        }

        public void skapaFrågor()
        {

                if ((string)Session["anställd"] == "test")
                {
                    LagraAllaFrågorLicensierad();

                    Label1.Text = AllaFrågorL[Convert.ToInt32(Session["counter"])].Del.ToString();
                    Label2.Text = AllaFrågorL[Convert.ToInt32(Session["counter"])].Text.ToString();
                    RadioButton1.Text = AllaFrågorL[Convert.ToInt32(Session["counter"])].Alternativ1.ToString();
                    RadioButton2.Text = AllaFrågorL[Convert.ToInt32(Session["counter"])].Alternativ2.ToString();
                    RadioButton3.Text = AllaFrågorL[Convert.ToInt32(Session["counter"])].Alternativ3.ToString();
                }
                else if ((string)Session["anställd"] == "fel")
                {
                    LagraAllaFrågorÅku();

                    Label1.Text = AllaFrågorÅ[Convert.ToInt32(Session["counter"])].Del.ToString();
                    Label2.Text = AllaFrågorÅ[Convert.ToInt32(Session["counter"])].Text.ToString();
                    RadioButton1.Text = AllaFrågorÅ[Convert.ToInt32(Session["counter"])].Alternativ1.ToString();
                    RadioButton2.Text = AllaFrågorÅ[Convert.ToInt32(Session["counter"])].Alternativ2.ToString();
                    RadioButton3.Text = AllaFrågorÅ[Convert.ToInt32(Session["counter"])].Alternativ3.ToString();
                }
        }



        protected void Button1_Click1(object sender, EventArgs e)
        {

            if(Convert.ToInt32(Session["counter"]) == 0)
            {
                //ska inte gå att backa när man redan är på 0
            }
            else
            {
                Session["counter"] = Convert.ToInt32(Session["counter"]) - 1;
                skapaFrågor();

            }

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Session["counter"] = Convert.ToInt32(Session["counter"]) + 1;

            skapaFrågor();

        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            //lämna in frågorna för rättning, visa alla frågor och svar, rätta svar och brickor med rätt/fel
        }
    }
}