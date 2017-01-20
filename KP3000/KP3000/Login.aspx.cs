using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.ComponentModel;

namespace KP3000
{
    public partial class Login : System.Web.UI.Page
    {
        BindingList<användare> användarna = new BindingList<användare>();
        användare användaren = new användare();
        List<string> SvarL = new List<string>();
        List<string> SvarÅ = new List<string>();
        List<frågor> felsvar = new List<frågor>();
        Postgres db = new Postgres();

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
            användaren = db.hämtaAnvändarInfo(anvNamn, lsn);

            if (användaren.anställd == true)
            {
                sessionInfo();
                Response.Redirect("inloggad.aspx");

            }
            else if (användaren.anställd == false)
            {
                sessionInfo();
                Response.Redirect("inloggad.aspx");

            }
            else if (användaren.ärAdmin == true)
            {
                sessionInfo();
                Response.Redirect("admin.aspx");
            }
            else
            {
                //här händer ingenting
            }

        }

        //Lagrar information från databas i session
        public void sessionInfo()
        {
            Session["anvid"] = användaren.anvid;
            Session["användarnamn"] = användaren.användarnamn;
            Session["login"] = användaren.login;
            Session["lösen"] = användaren.lösen;
            Session["anställd"] = användaren.anställd;
            Session["admin"] = användaren.ärAdmin;
            Session["testdatum"] = användaren.testDatum;

            Session["Lsvar"] = SvarL;
            Session["Åsvar"] = SvarÅ;
            Session["felsvar"] = felsvar;
        }

    }
}