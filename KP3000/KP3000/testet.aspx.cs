using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Xml;

namespace KP3000
{
    public partial class testet : System.Web.UI.Page
    {
        List<frågor> AllaFrågorÅ = new List<frågor>();
        List<frågor> AllaFrågorL = new List<frågor>();

        //pageload
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LagraAllaFrågorLicensierad();
                skapaFrågor();


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
            }
            return AllaFrågorL;
        }

        public void skapaFrågor()
        {
            foreach(frågor f in AllaFrågorL)
            {
                string html;

                html = "<div class=\"panel-group\">";
                html += "<form class=\"panel panel-default\" runat=\"server\">";
                html += "<div class=\"panel-heading\">";
                html += "<h4 class=\"panel-title\">";
                html += "<a data-toggle=\"collapse\" href =\"#collapse1\" > Fråga 1: <asp:Label ID=\"Label2\" runat =\"server\" Text =\"Label\" ></asp:Label></a>";
                html += "</h4>";
                html += "</div>";
                html += "<div id=\"collapse1\" class=\"panel -collapse collapse\" > ";
                html += "<div style=\"padding-left: 20px;\" > ";
                html += "<asp:RadioButton ID=\"RadioButton1\" runat =\"server\" GroupName =\"svar\" />";
                html += "</div>";
                html += "<div style=\"padding -left: 20px; \" > ";
                html += "<asp:RadioButton ID=\"RadioButton2\" runat =\"server\" GroupName =\"svar\" />";
                html += "</div>";
                html += "<div style=\"padding -left: 20px; \" > ";
                html += "<asp:RadioButton ID=\"RadioButton3\" runat =\"server\" GroupName =\"svar\" />";
                html += "</div>";
                html += "<button type=\"button\" class=\"btn btn-default\" > ";
                html += "<span class=\"glyphicon glyphicon-step-backward\" aria -hidden=\"true\" ></span> Föregående";
                html += "</button>";
                html += "<button type=\"button\" class=\"btn btn-default\">";
                html += "<span class=\"glyphicon glyphicon-step-forward\" aria-hidden=\"true\"></span> Nästa";
                html += "</button>";
                html += "<div class=\"panel -footer\" > ";
                html += "<span class=\"label label-success\" > Rätt</span>";
                html += "</div>";
                html += "</div>";
                html += "</form>";
                html += "</div>";

                //här borde kanske ett index-nummer på frågorna föras vidare i en metod??
                //det borde passeras en variabel varje gång man trycker på knappen "nästa", som gör ett nytt indexnummer, sammtidigt som föregående fråga rättas.

                Label1.Text = AllaFrågorL[0].Del.ToString();
                Label2.Text = AllaFrågorL[0].Text.ToString();
                RadioButton1.Text = AllaFrågorL[0].Alternativ1.ToString();
                RadioButton2.Text = AllaFrågorL[0].Alternativ2.ToString();
                RadioButton3.Text = AllaFrågorL[0].Alternativ3.ToString();

            }
        }



        protected void Button1_Click1(object sender, EventArgs e)
        {

        }

        protected void Button2_Click(object sender, EventArgs e)
        {

        }
    }
}