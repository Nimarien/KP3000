using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace KP3000
{
    public partial class WebForm1 : System.Web.UI.Page
    {

        List<frågor> AllaFrågor = new List<frågor>();

        protected void Page_Load(object sender, EventArgs e)
        {
  
        }

        //ladda in alla frågor vid ÅKU
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

                AllaFrågor.Add(Fråga);   
            }
            return AllaFrågor;
        }

        //ladda in alla frågor vid licensiering
        public List<frågor> LagraAllaFrågorLicensierad()
        {
            string vägen = Server.MapPath("Licensierad.xml");
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

                AllaFrågor.Add(Fråga);
            }
            return AllaFrågor;
        }
    }
}