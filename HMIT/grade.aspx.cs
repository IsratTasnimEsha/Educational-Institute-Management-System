using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.Emit;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace HMIT
{
    public partial class grade : System.Web.UI.Page
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

                    string query = "SELECT designation, grade, starting_salary, maximum_salary FROM grades order by grade";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        GridViewDesignations.DataSource = dt;
                        GridViewDesignations.DataBind();

                        GridViewDesignations.Visible = true; // Show the GridView after binding the data
                    }
                }
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            if (Session["email"] != null)
            {
                Button btnUpdate = (Button)sender;
                GridViewRow clickedRow = (GridViewRow)btnUpdate.NamingContainer;
                int rowIndex = clickedRow.RowIndex;

                string designation = GridViewDesignations.DataKeys[rowIndex]["designation"].ToString();

                SqlConnection con = new SqlConnection(strcon);
                con.Open();

                SqlCommand cmd = new SqlCommand("delete FROM grades WHERE designation = '" + designation + "'", con);

                cmd.ExecuteNonQuery();
                con.Close();

                Response.Redirect(Request.Url.AbsoluteUri);
            }
        }

        protected void submit_Click(object sender, EventArgs e)
        {
            if (Session["email"] != null)
            {
                if (string.IsNullOrWhiteSpace(grd.SelectedValue) || string.IsNullOrWhiteSpace(des.Text.Trim()) ||
                string.IsNullOrWhiteSpace(s_salary.Text.Trim()) || string.IsNullOrWhiteSpace(m_salary.Text.Trim()))
                {
                    error.Text = "Some Information is Incorrect or Missing!";
                }
                else
                {
                    SqlConnection con = new SqlConnection(strcon);
                    con.Open();

                    SqlCommand checkCmd = new SqlCommand("SELECT COUNT(*) FROM grades WHERE designation = '" + des.Text.Trim() + "'", con);
                    int existingTeacherCount = (int)checkCmd.ExecuteScalar();

                    if (existingTeacherCount > 0)
                    {
                        error.Text = "Designation Already Exists!";
                    }
                    else
                    {
                        SqlCommand cmd = new SqlCommand("INSERT INTO grades VALUES ('" + grd.SelectedValue + "', '" + des.Text.Trim() + "', '" + s_salary.Text.Trim() + "', '" + m_salary.Text.Trim() + "')", con);
                        cmd.ExecuteNonQuery();
                        con.Close();

                        grd.SelectedIndex = 0;
                        des.Text = "";
                        s_salary.Text = "";
                        m_salary.Text = "";
                        error.Text = "";

                        Response.Redirect(Request.Url.AbsoluteUri);
                    }
                }
            }
        }
    }
}