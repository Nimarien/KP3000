using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KP3000
{
    public partial class inloggad : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

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