using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HMIT
{
    public partial class view_student : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["email"] != null)
            {
                if (!IsPostBack)
                {
                    int currentYear = DateTime.Now.Year;

                    for (int year = currentYear; year >= currentYear - 10; year--)
                    {
                        batch.Items.Add(new ListItem(year.ToString(), year.ToString()));
                    }

                    SqlConnection con = new SqlConnection(strcon);
                    con.Open();

                    string query = "SELECT department, student_id, student_name, batch, email FROM students order by student_id";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        GridViewStudents.DataSource = dt;
                        GridViewStudents.DataBind();

                        GridViewStudents.Visible = true;
                    }
                }
            }
        }

        protected void GridViewStudents_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (Session["email"] != null)
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    string department = DataBinder.Eval(e.Row.DataItem, "department").ToString();

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

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            if (Session["email"] != null)
            {
                Button btnUpdate = (Button)sender;
                GridViewRow clickedRow = (GridViewRow)btnUpdate.NamingContainer;
                int rowIndex = clickedRow.RowIndex;

                string studentID = GridViewStudents.DataKeys[rowIndex]["student_id"].ToString();

                Response.Redirect("update_student.aspx?studentID=" + studentID);
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            if (Session["email"] != null)
            {
                Button btnDelete = (Button)sender;
                GridViewRow clickedRow = (GridViewRow)btnDelete.NamingContainer;
                int rowIndex = clickedRow.RowIndex;

                string studentID = GridViewStudents.DataKeys[rowIndex]["student_id"].ToString();

                SqlConnection con = new SqlConnection(strcon);
                con.Open();

                SqlCommand cmd = new SqlCommand("DELETE FROM students WHERE student_id = @StudentID", con);
                cmd.Parameters.AddWithValue("@StudentID", studentID);

                cmd.ExecuteNonQuery();
                con.Close();

                Response.Redirect(Request.Url.AbsoluteUri);
            }
        }

        protected void year_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Session["email"] != null)
            {
                SqlConnection con = new SqlConnection(strcon);

                string selectedDept = dept.SelectedValue;
                string selectedDes = batch.SelectedValue;
                string selectedSearch = search.Text.Trim();

                string query = "SELECT department, student_id, student_name, batch, email FROM students where (student_name like '%" + search.Text.Trim() + "%' or student_id like '%" + search.Text.Trim() + "%') and (batch like '%" + batch.SelectedValue + "%' and department like '%" + dept.SelectedValue + "%') order by student_id";


                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    GridViewStudents.DataSource = dt;
                    GridViewStudents.DataBind();

                    GridViewStudents.Visible = true; // Show the GridView after binding the data
                }
            }
        }
    }
}