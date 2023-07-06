using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HMIT
{
    public partial class home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void contact_Click(object sender, EventArgs e)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "OpenPage", "window.open('contact.aspx', '_blank');", true);
        }
    }
}