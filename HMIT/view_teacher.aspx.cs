using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HMIT
{
    public partial class view_teacher : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["email"] != null)
            {
                if (!IsPostBack)
                {
                    SqlConnection con = new SqlConnection(strcon);
                    con.Open();

                    SqlCommand checkCmd = new SqlCommand("SELECT designation FROM grades", con);

                    SqlDataReader reader = checkCmd.ExecuteReader();
                    while (reader.Read())
                    {
                        designation.Items.Add(reader["designation"].ToString());
                    }
                    reader.Close();

                    string query = "SELECT department, teacher_id, teacher_name, designation, email FROM faculty_members order by teacher_id";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        GridViewTeachers.DataSource = dt;
                        GridViewTeachers.DataBind();

                        GridViewTeachers.Visible = true; // Show the GridView after binding the data
                    }
                }
            }
        }

        protected void GridViewTeachers_RowDataBound(object sender, GridViewRowEventArgs e)
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

                string teacherID = GridViewTeachers.DataKeys[rowIndex]["teacher_id"].ToString();

                Response.Redirect("update_teacher.aspx?teacherID=" + teacherID);
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            if (Session["email"] != null)
            {
                Button btnUpdate = (Button)sender;
                GridViewRow clickedRow = (GridViewRow)btnUpdate.NamingContainer;
                int rowIndex = clickedRow.RowIndex;

                string teacherID = GridViewTeachers.DataKeys[rowIndex]["teacher_id"].ToString();

                SqlConnection con = new SqlConnection(strcon);
                con.Open();

                SqlCommand cmd = new SqlCommand("delete FROM faculty_members WHERE teacher_iD = '" + teacherID + "'", con);

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
                string selectedDes = designation.SelectedValue;
                string selectedSearch = search.Text.Trim();

                string query;

                if (!String.IsNullOrEmpty(dept.SelectedValue) && !String.IsNullOrEmpty(designation.SelectedValue))
                {
                    query = "SELECT department, teacher_id, teacher_name, designation, email FROM faculty_members where (teacher_name like '%" + search.Text.Trim() + "%' or teacher_id like '%" + search.Text.Trim() + "%') and (designation ='" + designation.SelectedValue + "' and department='" + dept.SelectedValue + "') order by teacher_id";
                }
                else if (!String.IsNullOrEmpty(designation.SelectedValue))
                {
                    query = "SELECT department, teacher_id, teacher_name, designation, email FROM faculty_members where (teacher_name like '%" + search.Text.Trim() + "%' or teacher_id like '%" + search.Text.Trim() + "%') and (designation ='" + designation.SelectedValue + "') order by teacher_id";
                }
                else if (!String.IsNullOrEmpty(dept.SelectedValue))
                {
                    query = "SELECT department, teacher_id, teacher_name, designation, email FROM faculty_members where (teacher_name like '%" + search.Text.Trim() + "%' or teacher_id like '%" + search.Text.Trim() + "%') and (department = '" + dept.SelectedValue + "') order by teacher_id";
                }
                else
                {
                    query = "SELECT department, teacher_id, teacher_name, designation, email FROM faculty_members where teacher_name like '%" + search.Text.Trim() + "%' or teacher_id like '%" + search.Text.Trim() + "%' order by teacher_id";
                }

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    GridViewTeachers.DataSource = dt;
                    GridViewTeachers.DataBind();

                    GridViewTeachers.Visible = true; // Show the GridView after binding the data
                }
            }
        }
    }
}