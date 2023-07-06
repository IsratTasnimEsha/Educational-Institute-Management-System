using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Security.Policy;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace HMIT
{
    public partial class registration : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {

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
                string StudentID = HttpUtility.UrlDecode(Request.QueryString["StudentID"]);

                string query = "SELECT course_no, course_title, credit FROM courses WHERE department_id = @department AND running_year = @year AND semester = @semester order by course_no";

                SqlConnection con = new SqlConnection(strcon);

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@department", "" + StudentID[2] + StudentID[3]);
                    cmd.Parameters.AddWithValue("@year", selectedYear);
                    cmd.Parameters.AddWithValue("@semester", selectedSemester);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    GridViewCourses.DataSource = dt;
                    GridViewCourses.DataBind();

                    GridViewCourses.Visible = true;
                }
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (Session["email"] != null)
            {
                string StudentID = HttpUtility.UrlDecode(Request.QueryString["StudentID"]);

                foreach (GridViewRow row in GridViewCourses.Rows)
                {
                    CheckBox checkBox = (CheckBox)row.FindControl("check");

                    if (checkBox.Checked)
                    {
                        string courseNo = row.Cells[1].Text;
                        string courseTitle = row.Cells[2].Text;
                        string credit = row.Cells[3].Text;

                        SqlConnection con = new SqlConnection(strcon);
                        con.Open();

                        SqlCommand checkCmd = new SqlCommand("SELECT COUNT(*) FROM registration WHERE student_id = @id and course_no = @c_no", con);
                        checkCmd.Parameters.AddWithValue("@id", StudentID);
                        checkCmd.Parameters.AddWithValue("@c_no", courseNo);
                        int idCount = (int)checkCmd.ExecuteScalar();

                        if (idCount == 0)
                        {
                            SqlConnection con1 = new SqlConnection(strcon);
                            con1.Open();

                            SqlCommand cmd = new SqlCommand("INSERT INTO registration VALUES(@id, @dept, @year, @semester, @c_no, @c_name, @credit, @status)", con1);
                            cmd.Parameters.AddWithValue("@id", StudentID);
                            cmd.Parameters.AddWithValue("@dept", "" + StudentID[2] + StudentID[3]);
                            cmd.Parameters.AddWithValue("@year", year.SelectedValue);
                            cmd.Parameters.AddWithValue("@semester", sem.SelectedValue);
                            cmd.Parameters.AddWithValue("@c_no", courseNo);
                            cmd.Parameters.AddWithValue("@c_name", courseTitle);
                            cmd.Parameters.AddWithValue("@credit", credit);
                            cmd.Parameters.AddWithValue("@status", "Waiting");
                            cmd.ExecuteNonQuery();

                            con1.Close();
                        }

                        else
                        {
                            SqlConnection con2 = new SqlConnection(strcon);
                            con2.Open();

                            SqlCommand checkCmd1 = new SqlCommand("SELECT COUNT(*) FROM result WHERE student_id = '" + StudentID + "' and course_no = '" + courseNo + "' and letter_grade = 'F'", con2);
                            SqlCommand checkCmd2 = new SqlCommand("SELECT COUNT(*) FROM result WHERE student_id = '" + StudentID + "' and course_no = '" + courseNo + "' and letter_grade = '-'", con2);

                            int idCount1 = (int)checkCmd1.ExecuteScalar();
                            int idCount2 = (int)checkCmd2.ExecuteScalar();

                            if (idCount1 > 0 && idCount2 == 0)
                            {
                                SqlCommand checkCmd3 = new SqlCommand("SELECT COUNT(*) FROM registration WHERE student_id = @id and course_no = @c_no and r_status = 'waiting'", con);
                                checkCmd3.Parameters.AddWithValue("@id", StudentID);
                                checkCmd3.Parameters.AddWithValue("@c_no", courseNo);
                                int idCount3 = (int)checkCmd3.ExecuteScalar();

                                if (idCount3 == 0)
                                {
                                    SqlConnection con1 = new SqlConnection(strcon);
                                    con1.Open();

                                    SqlCommand cmd = new SqlCommand("INSERT INTO registration VALUES(@id, @dept, @year, @semester, @c_no, @c_name, @credit, @status)", con1);
                                    cmd.Parameters.AddWithValue("@id", StudentID);
                                    cmd.Parameters.AddWithValue("@dept", "" + StudentID[2] + StudentID[3]);
                                    cmd.Parameters.AddWithValue("@year", year.SelectedValue);
                                    cmd.Parameters.AddWithValue("@semester", sem.SelectedValue);
                                    cmd.Parameters.AddWithValue("@c_no", courseNo);
                                    cmd.Parameters.AddWithValue("@c_name", courseTitle);
                                    cmd.Parameters.AddWithValue("@credit", credit);
                                    cmd.Parameters.AddWithValue("@status", "Waiting");
                                    cmd.ExecuteNonQuery();

                                    con1.Close();
                                }
                            }
                            con2.Close();
                        }
                        con.Close();

                        checkBox.Checked = false;
                    }
                }
            }
        }
    }
}