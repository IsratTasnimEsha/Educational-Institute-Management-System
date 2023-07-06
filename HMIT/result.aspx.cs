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
    public partial class result : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["email"] != null)
            {
                if (!IsPostBack)
                {
                    _1_1.Enabled = false;
                    _1_1.ForeColor = System.Drawing.Color.Black;
                    _1_2.Enabled = false;
                    _1_2.ForeColor = System.Drawing.Color.Black;
                    _2_1.Enabled = false;
                    _2_1.ForeColor = System.Drawing.Color.Black;
                    _2_2.Enabled = false;
                    _2_2.ForeColor = System.Drawing.Color.Black;
                    _3_1.Enabled = false;
                    _3_1.ForeColor = System.Drawing.Color.Black;
                    _3_2.Enabled = false;
                    _3_2.ForeColor = System.Drawing.Color.Black;
                    _4_1.Enabled = false;
                    _4_1.ForeColor = System.Drawing.Color.Black;
                    _4_2.Enabled = false;
                    _4_2.ForeColor = System.Drawing.Color.Black;
                    cgpa.Enabled = false;
                    cgpa.ForeColor = System.Drawing.Color.Black;
                    graduation.Enabled = false;
                    graduation.ForeColor = System.Drawing.Color.Black;

                    string StudentID = HttpUtility.UrlDecode(Request.QueryString["StudentID"]);

                    string query = "SELECT course_no, course_title, credit, marks, grade_point, letter_grade, attempt FROM result where student_id = '" + StudentID + "' order by course_no";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        GridViewCourses.DataSource = dt;
                        GridViewCourses.DataBind();

                        GridViewCourses.Visible = true; // Show the GridView after binding the data             
                    }

                    if (Request.QueryString["StudentID"] != null)
                    {
                        con.Open();
                        SqlCommand cmd = new SqlCommand(@"
                        SELECT                
                    FORMAT(SUM(CASE WHEN running_year = '1' AND semester = '1' THEN CONVERT(float, grade_point) * CONVERT(float, credit) ELSE 0 END)
                        / NULLIF(SUM(CASE WHEN running_year = '1' AND semester = '1' THEN CONVERT(float, credit) ELSE 0 END), 0), 'N2') AS _1_1,
                    FORMAT(SUM(CASE WHEN running_year = '1' AND semester = '2' THEN CONVERT(float, grade_point) * CONVERT(float, credit) ELSE 0 END)
                        / NULLIF(SUM(CASE WHEN running_year = '1' AND semester = '2' THEN CONVERT(float, credit) ELSE 0 END), 0), 'N2') AS _1_2,
                    FORMAT(SUM(CASE WHEN running_year = '2' AND semester = '1' THEN CONVERT(float, grade_point) * CONVERT(float, credit) ELSE 0 END)
                        / NULLIF(SUM(CASE WHEN running_year = '2' AND semester = '1' THEN CONVERT(float, credit) ELSE 0 END), 0), 'N2') AS _2_1,
                    FORMAT(SUM(CASE WHEN running_year = '2' AND semester = '2' THEN CONVERT(float, grade_point) * CONVERT(float, credit) ELSE 0 END)
                        / NULLIF(SUM(CASE WHEN running_year = '2' AND semester = '2' THEN CONVERT(float, credit) ELSE 0 END), 0), 'N2') AS _2_2,
                    FORMAT(SUM(CASE WHEN running_year = '3' AND semester = '1' THEN CONVERT(float, grade_point) * CONVERT(float, credit) ELSE 0 END)
                        / NULLIF(SUM(CASE WHEN running_year = '3' AND semester = '1' THEN CONVERT(float, credit) ELSE 0 END), 0), 'N2') AS _3_1,
                    FORMAT(SUM(CASE WHEN running_year = '3' AND semester = '2' THEN CONVERT(float, grade_point) * CONVERT(float, credit) ELSE 0 END)
                        / NULLIF(SUM(CASE WHEN running_year = '3' AND semester = '2' THEN CONVERT(float, credit) ELSE 0 END), 0), 'N2') AS _3_2,
                    FORMAT(SUM(CASE WHEN running_year = '4' AND semester = '1' THEN CONVERT(float, grade_point) * CONVERT(float, credit) ELSE 0 END)
                        / NULLIF(SUM(CASE WHEN running_year = '4' AND semester = '1' THEN CONVERT(float, credit) ELSE 0 END), 0), 'N2') AS _4_1,
                    FORMAT(SUM(CASE WHEN running_year = '4' AND semester = '2' THEN CONVERT(float, grade_point) * CONVERT(float, credit) ELSE 0 END)
                        / NULLIF(SUM(CASE WHEN running_year = '4' AND semester = '2' THEN CONVERT(float, credit) ELSE 0 END), 0), 'N2') AS _4_2,
                    FORMAT(SUM(CONVERT(float, grade_point) * CONVERT(float, credit))
                        / NULLIF(SUM(CONVERT(float, credit)), 0), 'N2') AS cgpa
                    FROM result
                        WHERE CONVERT(float, credit) <> 0 AND CONVERT(float, grade_point) <> 0
                        and student_id = '" + StudentID + "' group by student_id", con);

                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            _1_1.Text = reader["_1_1"].ToString();
                            _1_2.Text = reader["_1_2"].ToString();
                            _2_1.Text = reader["_2_1"].ToString();
                            _2_2.Text = reader["_2_2"].ToString();
                            _3_1.Text = reader["_3_1"].ToString();
                            _3_2.Text = reader["_3_2"].ToString();
                            _4_1.Text = reader["_4_1"].ToString();
                            _4_2.Text = reader["_4_2"].ToString();
                            cgpa.Text = reader["cgpa"].ToString();
                        }
                        con.Close();

                        con.Open();

                        string obtainedQuery = "SELECT COUNT(*) FROM result WHERE student_id = @studentId AND letter_grade != 'F'";
                        SqlCommand obtainedCommand = new SqlCommand(obtainedQuery, con);
                        obtainedCommand.Parameters.AddWithValue("@studentId", StudentID);
                        int obtainedCount = (int)obtainedCommand.ExecuteScalar();

                        string assignedQuery = "SELECT COUNT(*) FROM courses WHERE department_id = @studentId";
                        SqlCommand assignedCommand = new SqlCommand(assignedQuery, con);
                        assignedCommand.Parameters.AddWithValue("@studentId", "" + StudentID[2] + StudentID[3]);
                        int assignedCount = (int)assignedCommand.ExecuteScalar();

                        if (obtainedCount == assignedCount)
                        {
                            graduation.Text = "Completed";
                        }
                        else
                        {
                            graduation.Text = "Running";
                        }

                        con.Close();
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

        protected void year_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Session["email"] != null)
            {
                string selectedYear = year.SelectedValue;
                string selectedSemester = sem.SelectedValue;
                string selectedSearch = search.Text.Trim();

                string StudentID = HttpUtility.UrlDecode(Request.QueryString["StudentID"]);

                string query = "SELECT course_no, course_title, credit, marks, grade_point, letter_grade, attempt FROM result where student_id = '" + StudentID + "' AND (running_year like '%" + selectedYear + "%' AND semester like '%" + selectedSemester + "%') AND (course_no like '%" + selectedSearch + "%' OR course_title like '%" + selectedSearch + "%') order by course_no";

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