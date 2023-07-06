using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HMIT
{
    public partial class student_home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void personal_Click(object sender, EventArgs e)
        {
            if (Session["email"] != null)
            {
                string StudentID = HttpUtility.UrlDecode(Request.QueryString["StudentID"]);
                Response.Redirect("student.aspx?StudentID=" + HttpUtility.UrlEncode(StudentID));
            }
        }

        protected void registration_Click(object sender, EventArgs e)
        {
            if (Session["email"] != null)
            {
                string StudentID = HttpUtility.UrlDecode(Request.QueryString["StudentID"]);
                Response.Redirect("registration.aspx?StudentID=" + HttpUtility.UrlEncode(StudentID));
            }
        }

        protected void result_Click(object sender, EventArgs e)
        {
            if (Session["email"] != null)
            {
                string StudentID = HttpUtility.UrlDecode(Request.QueryString["StudentID"]);
                Response.Redirect("result.aspx?StudentID=" + HttpUtility.UrlEncode(StudentID));
            }
        }
    }
}