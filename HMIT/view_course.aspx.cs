using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

namespace HMIT
{
    public partial class view_course : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["email"] != null)
            {
                if (!IsPostBack)
                {
                    string query = "SELECT department_id, running_year, semester, course_no, course_title, credit FROM courses order by course_no";

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

        protected void GridViewCourses_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (Session["email"] != null)
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    string department = DataBinder.Eval(e.Row.DataItem, "department_id").ToString();

                    if (department == "01")
                    {
                        e.Row.Cells[0].Text = "Civil Engineering";
                    }
                    if (department == "02")
                    {
                        e.Row.Cells[0].Text = "Electrical and Electronic Engineering";
                    }
                    if (department == "03")
                    {
                        e.Row.Cells[0].Text = "Mechanical Engineering";
                    }
                    if (department == "04")
                    {
                        e.Row.Cells[0].Text = "Computer Science and Engineering";
                    }
                    if (department == "05")
                    {
                        e.Row.Cells[0].Text = "Electronics and Communication Engineering";
                    }
                    if (department == "06")
                    {
                        e.Row.Cells[0].Text = "Biomedical Engineering";
                    }
                    if (department == "07")
                    {
                        e.Row.Cells[0].Text = "Material Science and Engineering";
                    }
                    if (department == "08")
                    {
                        e.Row.Cells[0].Text = "Industrial Engineering and Management";
                    }
                    if (department == "09")
                    {
                        e.Row.Cells[0].Text = "Chemical Engineering";
                    }
                    if (department == "10")
                    {
                        e.Row.Cells[0].Text = "Textile Engineering";
                    }
                    if (department == "11")
                    {
                        e.Row.Cells[0].Text = "Leather Engineering";
                    }
                    if (department == "12")
                    {
                        e.Row.Cells[0].Text = "Energy Science and Engineering";
                    }
                    if (department == "13")
                    {
                        e.Row.Cells[0].Text = "Mechatronics Engineering";
                    }
                    if (department == "14")
                    {
                        e.Row.Cells[0].Text = "Building Engineering and Construction Management";
                    }
                    if (department == "15")
                    {
                        e.Row.Cells[0].Text = "Urban and Regional Planning";
                    }
                    if (department == "16")
                    {
                        e.Row.Cells[0].Text = "Architecture";
                    }
                    if (department == "17")
                    {
                        e.Row.Cells[0].Text = "Mathematics";
                    }
                    if (department == "18")
                    {
                        e.Row.Cells[0].Text = "Chemistry";
                    }
                    if (department == "19")
                    {
                        e.Row.Cells[0].Text = "Physics";
                    }
                    if (department == "20")
                    {
                        e.Row.Cells[0].Text = "Humanities";
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

                string query = "SELECT department_id, running_year, semester, course_no, course_title, credit FROM courses WHERE (course_no like '%" + selectedDept + "%' AND running_year like '%" + selectedYear + "%' AND semester like '%" + selectedSemester + "%') AND (course_no like '%" + selectedSearch + "%' OR course_title like '%" + selectedSearch + "%') order by course_no";

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

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            if (Session["email"] != null)
            {
                Button btnUpdate = (Button)sender;
                GridViewRow clickedRow = (GridViewRow)btnUpdate.NamingContainer;
                int rowIndex = clickedRow.RowIndex;

                string courseNO = GridViewCourses.DataKeys[rowIndex]["course_no"].ToString();

                Response.Redirect("update_course.aspx?CourseNO=" + courseNO);
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            if (Session["email"] != null)
            {
                Button btnDelete = (Button)sender;
                GridViewRow clickedRow = (GridViewRow)btnDelete.NamingContainer;
                int rowIndex = clickedRow.RowIndex;

                string courseNO = GridViewCourses.DataKeys[rowIndex]["course_no"].ToString();

                con.Open();

                SqlCommand cmd = new SqlCommand("DELETE FROM courses WHERE course_no = '" + courseNO + "'", con);

                cmd.ExecuteNonQuery();
                con.Close();

                Response.Redirect(Request.Url.AbsoluteUri);
            }
        }
    }
}