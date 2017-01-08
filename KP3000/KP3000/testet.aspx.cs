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

        //skapar frågorna (somtyvärr töms vid varje postback)
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

        //spara svaren
        public void sparafråga(int a)
        {
            string svar = "inget";
            //XmlDocument Frågorna = new XmlDocument();
            
            if ((string)Session["anställd"] == "test")
            {
                
                if (RadioButton1.Checked)
                {
                    svar = RadioButton1.Text;
                    //SvarL.Add(svar);
                }
                else if (RadioButton2.Checked)
                {
                    svar = RadioButton2.Text;
                    //SvarL.Add(svar);
                }
                else if (RadioButton3.Checked)
                {
                    svar = RadioButton3.Text;
                    //SvarL.Add(svar);
                }
                
                string theroad = Server.MapPath("svarL.xml");

                //XmlDocument dok = new XmlDocument();
                //dok.Load(theroad);
                //XmlNodeList nyttsvar = dok.SelectNodes("svaren");           
                //XmlElement xmlnummer = dok.CreateElement("nummer");
                //xmlnummer.InnerText = a.ToString();
                //dok.DocumentElement.AppendChild(xmlnummer);
                //XmlElement xmltext = dok.CreateElement("text");                
                //xmltext.InnerText = svar;
                //dok.DocumentElement.AppendChild(xmltext);

                //XmlNode svaret = dok.CreateNode(XmlNodeType.Element, "svar", null);
                //dok.DocumentElement.AppendChild(svaret);

                //XmlWriterSettings settings = new XmlWriterSettings();
                //settings.Indent = true;               
                //XmlWriter writer = XmlWriter.Create(theroad, settings);
                //dok.Save(writer);


                //den här skiten skriver ju över eländet varje gång
                XmlDocument xmlDoc = new XmlDocument();
                XmlNode rootNode = xmlDoc.CreateElement("svaren");
                xmlDoc.AppendChild(rootNode);

                XmlNode userNode = xmlDoc.CreateElement("svar");
                XmlAttribute attribute = xmlDoc.CreateAttribute("nummer");
                attribute.Value = a.ToString();
                userNode.Attributes.Append(attribute);
                userNode.InnerText = svar;
                rootNode.AppendChild(userNode);

                
                xmlDoc.Save(theroad);




                //XmlWriter skrivare = null;
                //skrivare = XmlWriter.Create(theroad);
                ////skrivare ska stoppa in allt under svaren
                //skrivare.WriteStartElement("svar");
                //skrivare.WriteElementString("nummer", a.ToString());
                //skrivare.WriteElementString("text", svar.ToString());
                ////skrivare.Flush();
                //skrivare.Close();
            }
            else if ((string)Session["anställd"] == "fel")
            {
                if (RadioButton1.Checked)
                {
                    svar = RadioButton1.Text;
                    SvarÅ.Add(svar);
                }
                else if (RadioButton2.Checked)
                {
                    svar = RadioButton2.Text;
                    SvarÅ.Add(svar);
                }
                else if (RadioButton3.Checked)
                {
                    svar = RadioButton3.Text;
                    SvarÅ.Add(svar);
                }
                string theroad = Server.MapPath("svarL.xml");
                XmlDocument dok = new XmlDocument();
                dok.Load(theroad);
                XmlNodeList nyttsvar = dok.SelectNodes("svaren");
                XmlElement xmlnummer = dok.CreateElement("nummer");
                XmlElement xmltext = dok.CreateElement("text");
                xmlnummer.InnerText = a.ToString();
                xmltext.InnerText = svar.ToString();
                dok.Save("svarÅ.xml");
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
            int nummer = Convert.ToInt32(Session["counter"]);
            //här ska svaret från föregående fråga sparar i en lista
            sparafråga(nummer);
            Session["counter"] = Convert.ToInt32(Session["counter"]) + 1;

            skapaFrågor();
            

            
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            //lämna in frågorna för rättning, visa alla frågor och svar, rätta svar och brickor med rätt/fel
        }
    }
}