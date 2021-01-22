using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASPTest
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lel.Controls.Add(new LinkButton() { ID = "hah", Text = "pute" });
            if (IsPostBack)
            {
                Response.Write("<br>Page has been posted back.");
            }
            
        }


    }
}