using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Policy;
using System.Xml.Linq;

namespace HMIT
{
    public partial class add_result : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["email"] != null)
            {
                if (!IsPostBack)
                {
                    string StudentID = HttpUtility.UrlDecode(Request.QueryString["StudentID"]);

                    string query = "SELECT student_id, course_no, course_title, credit, marks, grade_point, letter_grade, attempt FROM result order by student_id, course_no";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        GridViewCourses.DataSource = dt;
                        GridViewCourses.DataBind();

                        GridViewCourses.Visible = true; // Show the GridView after binding the data                                                             
                    }
                }
            }
        }

        protected void assigned_Click(object sender, EventArgs e)
        {
            if (Session["email"] != null)
            {
                string StudentID = HttpUtility.UrlDecode(Request.QueryString["StudentID"]);
                Response.Redirect("student_home.aspx?StudentID=" + HttpUtility.UrlEncode(StudentID));
            }
        }


        protected void marks_TextChanged(object sender, EventArgs e)
        {
            if (Session["email"] != null)
            {
                TextBox marksTextBox = (TextBox)sender;
                GridViewRow row = (GridViewRow)marksTextBox.NamingContainer;

                Label idLabel = (Label)row.FindControl("s_id");
                Label courseLabel = (Label)row.FindControl("c_no");
                Label gradeLabel = (Label)row.FindControl("grade");
                Label letterLabel = (Label)row.FindControl("letter");

                int o_marks = Convert.ToInt32(marksTextBox.Text);

                if (o_marks >= 80)
                {
                    gradeLabel.Text = "4.00";
                    letterLabel.Text = "A+";
                }
                else if (o_marks >= 75)
                {
                    gradeLabel.Text = "3.75";
                    letterLabel.Text = "A";
                }
                else if (o_marks >= 70)
                {
                    gradeLabel.Text = "3.50";
                    letterLabel.Text = "A-";
                }
                else if (o_marks >= 65)
                {
                    gradeLabel.Text = "3.25";
                    letterLabel.Text = "B+";
                }
                else if (o_marks >= 60)
                {
                    gradeLabel.Text = "3.00";
                    letterLabel.Text = "B";
                }
                else if (o_marks >= 55)
                {
                    gradeLabel.Text = "2.75";
                    letterLabel.Text = "B-";
                }
                else if (o_marks >= 50)
                {
                    gradeLabel.Text = "2.50";
                    letterLabel.Text = "C+";
                }
                else if (o_marks >= 45)
                {
                    gradeLabel.Text = "2.25";
                    letterLabel.Text = "C";
                }
                else if (o_marks >= 40)
                {
                    gradeLabel.Text = "2.00";
                    letterLabel.Text = "D";
                }
                else
                {
                    gradeLabel.Text = "0.00";
                    letterLabel.Text = "F";
                }

                con.Open();
                SqlCommand cmd = new SqlCommand("update result set marks='" + marksTextBox.Text.ToString() + "', grade_point = '" + gradeLabel.Text + "', letter_grade = '" + letterLabel.Text + "' where student_id='" + idLabel.Text + "' AND course_no='" + courseLabel.Text + "'", con);
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        protected void year_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Session["email"] != null)
            {
                string selectedDept = dept.SelectedValue;
                string selectedYear = year.SelectedValue;
                string selectedSemester = sem.SelectedValue;
                string selectedSearch = search.Text.Trim();

                string StudentID = HttpUtility.UrlDecode(Request.QueryString["StudentID"]);

                string query = "SELECT student_id, course_no, course_title, credit, marks, grade_point, letter_grade, attempt FROM result where (department_id like '%" + selectedDept + "%' AND running_year like '%" + selectedYear + "%' AND semester like '%" + selectedSemester + "%') AND (student_id like '%" + selectedSearch + "%' OR course_no like '%" + selectedSearch + "%' OR course_title like '%" + selectedSearch + "%') order by student_id, course_no";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    GridViewCourses.DataSource = dt;
                    GridViewCourses.DataBind();

                    GridViewCourses.Visible = true; // Show the GridView after binding the data
                }
            }
        }
    }
}