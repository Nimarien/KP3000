using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.ComponentModel;

namespace KP3000
{
    public partial class admin1 : System.Web.UI.Page
    {
        Postgres db = new Postgres();
        BindingList<användare> licenslista = new BindingList<användare>();
        BindingList<användare> åkulista = new BindingList<användare>();
        användare anv = new användare();

        protected void Page_Load(object sender, EventArgs e)
        {

            adminlogin.Text = Session["användarnamn"].ToString();

            gridLicencierade();
            gridÅKU();

        }

        public void gridLicencierade()
        {

            licenslista = db.hämtaLicensierade();

            var resultat = from användare in licenslista select new { användare.namn, användare.datumgodkänt, användare.antalRätt, användare.antalFel, användare.testDatum};

            GridLicensierade.DataSource = resultat;
            GridLicensierade.DataBind();
        }

        public void gridÅKU()
        {
            licenslista = db.hämtaÅKU();

            var resultat = from användare in licenslista select new { användare.namn, användare.datumgodkänt, användare.antalRätt, användare.antalFel, användare.testDatum };

            GridOlicensierade.DataSource = resultat;
            GridOlicensierade.DataBind();
        }
    }
}