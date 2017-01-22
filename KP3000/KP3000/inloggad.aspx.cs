using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.ComponentModel;


namespace KP3000
{
    public partial class inloggad : System.Web.UI.Page
    {
        Postgres db = new Postgres();
        BindingList<användare> anv = new BindingList<användare>();

        protected void Page_Load(object sender, EventArgs e)
        {
            userinlog.Text = Session["användarnamn"].ToString();

            visatest();

        }

        protected void visatest()
        {
            string test = "";
            anv = db.hämtaresultat((int)Session["anvid"]);

            if (anv[0].datumgodkänt == "")
            {
                anv[0].datumgodkänt = "Inget godkänt resultat!";
                test = "<br />" + anv[0].datumgodkänt + "<br />" + "Resultat: antal rätt - " + anv[0].antalRätt + " antal fel - " + anv[0].antalFel;
            }
            else

                test = "<br /> Godkänt datum: " + anv[0].datumgodkänt + "<br />" + "Resultat: antal rätt - " + anv[0].antalRätt + " antal fel - " + anv[0].antalFel;

            testlabel.Text = test;
        }

        protected void btnGörTest_Click(object sender, EventArgs e)
        {

            Session["counter"] = 0;
            Session["rätt"] = 0;
            Session["fel"] = 0;
            Session["del"] = 0;
            Session["rättpådelett"] = 0;
            Session["rättpådeltvå"] = 0;
            Session["rättpådeltre"] = 0;
            
            Response.Redirect("testet.aspx");
        }
    }
}