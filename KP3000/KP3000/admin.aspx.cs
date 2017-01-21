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
        BindingList<användare> anvlista = new BindingList<användare>();
        användare anv = new användare();

        protected void Page_Load(object sender, EventArgs e)
        {

            adminlogin.Text = Session["användarnamn"].ToString();
            
        }

        public void gridLicencierade()
        {

            anvlista = db.hämtaLicensierade();
            GridView gridlicens = new GridView();

            gridlicens.DataSource = anvlista;



        }

        public void gridÅKU()
        {
            anvlista = db.hämtaÅKU();


        }
    }
}