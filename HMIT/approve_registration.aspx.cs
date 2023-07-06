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
    public partial class approve_registration : System.Web.UI.Page
    {
        String strcon = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["email"] != null)
            {
                if (!IsPostBack)
                {
                    string query = "SELECT student_id, course_no, course_title, credit, r_status FROM registration order by student_id, course_no";
                    SqlConnection con = new SqlConnection(strcon);
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        GridViewCourses.DataSource = dt;
                        GridViewCourses.DataBind();

                        GridViewCourses.Visible = true; // Show the GridView after binding the data             
                    }
                    con.Close();
                }
            }
        }

        protected void GridViewCourses_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (Session["email"] != null)
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    Label status = (Label)e.Row.FindControl("status");

                    if (status.Text == "Approved")
                    {
                        status.ForeColor = System.Drawing.Color.Green;
                    }

                    if (status.Text == "Rejected")
                    {
                        status.ForeColor = System.Drawing.Color.Red;
                    }
                }
            }
        }

        protected void year_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Session["email"] != null)
            {
                string selectedDept = dept.SelectedValue;
                string selectedYear = year.SelectedValue;
                string selectedSemester = sem.SelectedValue;
                String selectedStatus = d_status.SelectedValue;
                string selectedSearch = search.Text.Trim();

                string query = "SELECT student_id, course_no, course_title, credit, r_status FROM registration WHERE (department_id like '%" + selectedDept + "%' AND running_year like '%" + selectedYear + "%' AND semester like '%" + selectedSemester + "%' AND r_status like '%" + selectedStatus + "%') AND (course_no like '%" + selectedSearch + "%' OR course_title like '%" + selectedSearch + "%' OR student_id like '%" + selectedSearch + "%') order by student_id, course_no";

                SqlConnection con = new SqlConnection(strcon);

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    GridViewCourses.DataSource = dt;
                    GridViewCourses.DataBind();

                    GridViewCourses.Visible = true;
                }
                con.Close();
            }
        }

        protected void btnApprove_Click(object sender, EventArgs e)
        {
            if (Session["email"] != null)
            {
                Button btnApprove = (Button)sender;
                GridViewRow row = (GridViewRow)btnApprove.NamingContainer;
                Label status = (Label)row.FindControl("status");
                Label student_id = (Label)row.FindControl("s_id");
                Label course_no = (Label)row.FindControl("c_no");
                String department_id = "" + course_no.Text.ToString()[0] + course_no.Text.ToString()[1];
                String year = "" + course_no.Text.ToString()[2];
                String semester = "" + course_no.Text.ToString()[3];
                Label course_title = (Label)row.FindControl("c_name");
                Label credit = (Label)row.FindControl("credit");

                status.Text = "Approved";
                status.ForeColor = System.Drawing.Color.Green;

                SqlConnection con = new SqlConnection(strcon);
                con.Open();
                SqlCommand cmd = new SqlCommand("update registration set r_status='" + status.Text.ToString() + "' where student_id='" + student_id.Text.ToString() + "' AND course_no='" + course_no.Text.ToString() + "'", con);
                cmd.ExecuteNonQuery();
                con.Close();

                SqlConnection con2 = new SqlConnection(strcon);
                con2.Open();

                SqlCommand checkCmd = new SqlCommand("SELECT COUNT(*) FROM registration WHERE student_id = @id and course_no = @c_no", con2);
                checkCmd.Parameters.AddWithValue("@id", student_id.Text.ToString());
                checkCmd.Parameters.AddWithValue("@c_no", course_no.Text.ToString());

                int idCount = (int)checkCmd.ExecuteScalar();
                if (idCount == 1)
                {
                    SqlConnection con1 = new SqlConnection(strcon);
                    con1.Open();

                    SqlCommand cmd1 = new SqlCommand("insert into result values (@student_id, @department_id, @year, @semester, @course_no, @course_title, @credit, '', '0.00', '-', '1')", con1);
                    cmd1.Parameters.AddWithValue("@student_id", student_id.Text.ToString());
                    cmd1.Parameters.AddWithValue("@department_id", department_id);
                    cmd1.Parameters.AddWithValue("@year", year);
                    cmd1.Parameters.AddWithValue("@semester", semester);
                    cmd1.Parameters.AddWithValue("@course_no", course_no.Text.ToString());
                    cmd1.Parameters.AddWithValue("@course_title", course_title.Text.ToString());
                    cmd1.Parameters.AddWithValue("@credit", credit.Text.ToString());

                    cmd1.ExecuteNonQuery();
                    con1.Close();
                }

                else
                {
                    SqlConnection con1 = new SqlConnection(strcon);
                    con1.Open();

                    SqlCommand cmd1 = new SqlCommand("update result set attempt = @attempt, marks='', grade_point='0.00', letter_grade='-' where student_id = @student_id and course_no = @course_no", con1);
                    cmd1.Parameters.AddWithValue("@student_id", student_id.Text.ToString());
                    cmd1.Parameters.AddWithValue("@course_no", course_no.Text.ToString());
                    cmd1.Parameters.AddWithValue("@attempt", Convert.ToString(idCount));

                    cmd1.ExecuteNonQuery();
                    con1.Close();
                }

                con2.Close();
            }
        }
        protected void btnReject_Click(object sender, EventArgs e)
        {
            if (Session["email"] != null)
            {
                Button btnApprove = (Button)sender;
                GridViewRow row = (GridViewRow)btnApprove.NamingContainer;
                Label status = (Label)row.FindControl("status");
                Label student_id = (Label)row.FindControl("s_id");
                Label course_no = (Label)row.FindControl("c_no");

                status.Text = "Rejected";
                status.ForeColor = System.Drawing.Color.Red;

                SqlConnection con = new SqlConnection(strcon);
                con.Open();
                SqlCommand cmd = new SqlCommand("update registration set r_status='" + status.Text.ToString() + "' where student_id='" + student_id.Text.ToString() + "' AND course_no='" + course_no.Text.ToString() + "'", con);
                cmd.ExecuteNonQuery();
                con.Close();

                con.Open();
                SqlCommand cmd1 = new SqlCommand("delete from result where student_id = @student_id and course_no = @course_no", con);
                cmd1.Parameters.AddWithValue("@student_id", student_id.Text.ToString());
                cmd1.Parameters.AddWithValue("@course_no", course_no.Text.ToString());
                cmd1.ExecuteNonQuery();
                con.Close();
            }
        }
    }
}