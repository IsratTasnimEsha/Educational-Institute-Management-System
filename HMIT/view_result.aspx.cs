using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Text.RegularExpressions;

namespace HMIT
{
    public partial class view_result : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["email"] != null)
            {
                if (!IsPostBack)
                {
                    using (SqlConnection connection = new SqlConnection(strcon))
                    {
                        SqlCommand command = new SqlCommand(@"
                        SELECT
                    student_id,
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
                        GROUP BY student_id", connection);

                        connection.Open();

                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        GridViewCombinedResult.DataSource = dt;
                        GridViewCombinedResult.DataBind();

                        connection.Close();
                    }
                }
            }
        }

        protected void GridViewCombinedResult_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (Session["email"] != null)
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    Label graduation = e.Row.FindControl("graduation") as Label;
                    if (graduation != null)
                    {
                        String StudentID = DataBinder.Eval(e.Row.DataItem, "student_id").ToString();

                        SqlConnection con = new SqlConnection(strcon);
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

                        con.Close();
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
                string selectedSearch = search.Text.Trim();

                using (SqlConnection connection = new SqlConnection(strcon))
                {
                    SqlCommand command = new SqlCommand(@"
                SELECT
                    student_id,
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
                WHERE 
                    CONVERT(float, credit) <> 0 
                    AND CONVERT(float, grade_point) <> 0
                    AND department_id LIKE @selectedDept
                    AND running_year LIKE @selectedYear
                    AND semester LIKE @selectedSemester
                    AND student_id LIKE @selectedSearch
                GROUP BY student_id
                ORDER BY student_id", connection);

                    command.Parameters.AddWithValue("@selectedDept", "%" + selectedDept + "%");
                    command.Parameters.AddWithValue("@selectedYear", "%" + selectedYear + "%");
                    command.Parameters.AddWithValue("@selectedSemester", "%" + selectedSemester + "%");
                    command.Parameters.AddWithValue("@selectedSearch", "%" + selectedSearch + "%");

                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    GridViewCombinedResult.DataSource = dt;
                    GridViewCombinedResult.DataBind();
                }
            }
        }
    }
}