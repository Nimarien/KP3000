using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KP3000
{
    public partial class Login : System.Web.UI.Page
    {
        List<användare> användarna = new List<användare>();
        List<string> SvarL = new List<string>();
        List<string> SvarÅ = new List<string>();
        List<frågor> felsvar = new List<frågor>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }
            
        }

        protected void Loginknapp_Click(object sender, EventArgs e)
        {
            string anvNamn = användarnamn.Value;
            string lsn = lösen.Value;
            Session["Lsvar"] = SvarL;
            Session["Åsvar"] = SvarÅ;
            Session["felsvar"] = felsvar;


            if (anvNamn == "test" && lsn == "test")
            {
                användare nyanvändare = new användare();
                nyanvändare.Namn = "Eskil Testsson";
                nyanvändare.Användarnamn = "test";
                nyanvändare.Anställd = true;

                Session["anställd"] = "test";
                Response.Redirect("inloggad.aspx");

            }
            else if (anvNamn == "fel" && lsn == "fel")
            {
                användare nyanvändare = new användare();
                nyanvändare.Namn = "Felet Andersson";
                nyanvändare.Användarnamn = "fel";
                nyanvändare.Anställd = false;

                Session["anställd"] = "fel";
                Response.Redirect("inloggad.aspx");

            }
            else if (anvNamn == "admin" && lsn == "admin")
            {
                användare nyanvändare = new användare();
                nyanvändare.Namn = "Admin Adminlund";
                nyanvändare.Användarnamn = "admin";
                nyanvändare.Anställd = true;
                Response.Redirect("inloggad.aspx");
                nyanvändare.ärAdmin = true;

                Session["anställd"] = "admin";
            }
            else
            {
                //här händer ingenting
            }

        }
    }
}