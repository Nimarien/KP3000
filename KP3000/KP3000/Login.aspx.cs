﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KP3000
{
    public partial class Login : System.Web.UI.Page
    {
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

            if (anvNamn == "test" && lsn == "test")
            {
                Response.Redirect("inloggad.aspx");
            }
            else
            {

            }

        }
    }
}