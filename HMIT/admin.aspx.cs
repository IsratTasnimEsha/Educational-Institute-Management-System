using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HMIT
{
    public partial class admin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void teacher_add_Click(object sender, EventArgs e)
        {
            if (Session["email"] != null)
            {
                Response.Redirect("add_teacher.aspx");
            }
        }

        protected void teacher_view_Click(object sender, EventArgs e)
        {
            if (Session["email"] != null)
            {
                Response.Redirect("view_teacher.aspx");
            }
        }

        protected void student_add_Click(object sender, EventArgs e)
        {
            if (Session["email"] != null)
            {
                Response.Redirect("add_student.aspx");
            }
        }

        protected void student_view_Click(object sender, EventArgs e)
        {
            if (Session["email"] != null)
            {
                Response.Redirect("view_student.aspx");
            }
        }

        protected void notice_add_Click(object sender, EventArgs e)
        {
            if (Session["email"] != null)
            {
                Response.Redirect("add_notice.aspx");
            }
        }

        protected void notice_view_Click(object sender, EventArgs e)
        {
            if (Session["email"] != null)
            {
                Response.Redirect("view_notice.aspx");
            }
        }

        protected void course_add_Click(object sender, EventArgs e)
        {
            if (Session["email"] != null)
            {
                Response.Redirect("add_courses.aspx");
            }
        }

        protected void course_view_Click(object sender, EventArgs e)
        {
            if (Session["email"] != null)
            {
                Response.Redirect("view_course.aspx");
            }
        }

        protected void registration_approve_Click(object sender, EventArgs e)
        {
            if (Session["email"] != null)
            {
                Response.Redirect("approve_registration.aspx");
            }
        }

        protected void result_add_Click(object sender, EventArgs e)
        {
            if (Session["email"] != null)
            {
                Response.Redirect("add_result.aspx");
            }
        }

        protected void result_view_Click(object sender, EventArgs e)
        {
            if (Session["email"] != null)
            {
                Response.Redirect("view_result.aspx");
            }
        }

        protected void designation_add_Click(object sender, EventArgs e)
        {
            if (Session["email"] != null)
            {
                Response.Redirect("grade.aspx");
            }
        }
    }
}