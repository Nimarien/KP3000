using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KP3000
{
    public partial class admin1 : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {

            adminlogin.Text = Session["användarnamn"].ToString();
            
        }

        protected void btn_ändrafrågor_Click(object sender, EventArgs e)
        {

        }
    }
}