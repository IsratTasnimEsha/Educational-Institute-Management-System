using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Policy;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace HMIT
{
    public partial class add_notice : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void from_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Session["email"] != null)
            {
                if (from.SelectedValue == "Faculty Dean")
                {
                    dean_label.Visible = true;
                    dean.Visible = true;
                    dept_head_label.Visible = false;
                    dept_head.Visible = false;
                }
                else if (from.SelectedValue == "Department Head")
                {
                    dean_label.Visible = false;
                    dean.Visible = false;
                    dept_head_label.Visible = true;
                    dept_head.Visible = true;
                }
                else
                {
                    dean_label.Visible = false;
                    dean.Visible = false;
                    dept_head_label.Visible = false;
                    dept_head.Visible = false;
                }
            }
        }

        protected void to_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Session["email"] != null)
            {
                if (to.SelectedValue == "Teachers")
                {
                    teachers_label.Visible = true;
                    teachers.Visible = true;
                    students_label.Visible = false;
                    students.Visible = false;
                }
                else if (to.SelectedValue == "Students")
                {
                    teachers_label.Visible = false;
                    teachers.Visible = false;
                    students_label.Visible = true;
                    students.Visible = true;
                }
                else
                {
                    teachers_label.Visible = false;
                    teachers.Visible = false;
                    students_label.Visible = false;
                    students.Visible = false;
                }
            }
        }

        protected void submit_Click(object sender, EventArgs e)
        {
            if (Session["email"] != null)
            {
                if (string.IsNullOrWhiteSpace(from.SelectedValue) || string.IsNullOrWhiteSpace(to.SelectedValue) ||
                (from.SelectedValue == "Faculty Dean" && string.IsNullOrWhiteSpace(dean.SelectedValue)) ||
                (from.SelectedValue == "Department Head" && string.IsNullOrWhiteSpace(dept_head.SelectedValue)) ||
                (to.SelectedValue == "Teachers" && string.IsNullOrWhiteSpace(teachers.SelectedValue)) ||
                (to.SelectedValue == "Students" && string.IsNullOrWhiteSpace(students.SelectedValue)) ||
                string.IsNullOrWhiteSpace(sub.Text.Trim()) || string.IsNullOrWhiteSpace(msg.Text.Trim()))
                {
                    error.Text = "Some Informations Are Incorrect Or Missing!";
                }

                else
                {
                    String from_whom, to_whom;

                    if (from.SelectedValue == "Faculty Dean")
                    {
                        from_whom = dean.SelectedValue;
                    }

                    else if (from.SelectedValue == "Department Head")
                    {
                        from_whom = dept_head.SelectedValue;
                    }

                    else
                    {
                        from_whom = from.SelectedValue;
                    }

                    if (to.SelectedValue == "Teachers")
                    {
                        to_whom = teachers.SelectedValue;
                    }

                    else if (to.SelectedValue == "Students")
                    {
                        to_whom = students.SelectedValue;
                    }

                    else
                    {
                        to_whom = to.SelectedValue;
                    }


                    SqlConnection con = new SqlConnection(strcon);
                    con.Open();
                    SqlCommand cmd = new SqlCommand("INSERT INTO notice VALUES('" + from_whom + "', '" + to_whom + "', SYSDATETIME(), '" + sub.Text.Trim() + "', '" + msg.Text.Trim() + "')", con);
                    cmd.ExecuteNonQuery();

                    from.SelectedIndex = 0;
                    to.SelectedIndex = 0;

                    dean_label.Visible = false;
                    dean.Visible = false;
                    dean.SelectedIndex = 0;

                    dept_head_label.Visible = false;
                    dept_head.Visible = false;
                    dept_head.SelectedIndex = 0;

                    teachers_label.Visible = false;
                    teachers.Visible = false;
                    teachers.SelectedIndex = 0;

                    students_label.Visible = false;
                    students.Visible = false;
                    students.SelectedIndex = 0;

                    sub.Text = "";
                    msg.Text = "";
                    error.Text = "";

                    con.Close();
                }
            }
        }
    }
}