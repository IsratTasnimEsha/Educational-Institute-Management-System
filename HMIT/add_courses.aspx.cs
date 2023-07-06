using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace HMIT
{
    public partial class add_courses : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["email"] != null)
            {
                if (!IsPostBack)
                {
                    c_code.Enabled = false;
                    c_code.ForeColor = System.Drawing.Color.Black;
                    c_year.Enabled = false;
                    c_year.ForeColor = System.Drawing.Color.Black;
                    c_sem.Enabled = false;
                    c_sem.ForeColor = System.Drawing.Color.Black;
                    id.Enabled = false;
                    id.ForeColor = System.Drawing.Color.Black;
                }
            }
        }

        protected void dept_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Session["email"] != null)
            {
                c_code.Text = dept.SelectedValue;
                c_year.Text = year.SelectedValue;
                c_sem.Text = sem.SelectedValue;

                SqlConnection con = new SqlConnection(strcon);
                con.Open();

                SqlCommand checkCmd = new SqlCommand("SELECT * FROM faculty_members where department='" + t_from.SelectedValue + "'", con);

                SqlDataReader reader = checkCmd.ExecuteReader();
                t_name.Items.Clear(); // Clear the t_name DropDownList before adding new items
                t_name.Items.Add("");
                while (reader.Read())
                {
                    string teacherId = reader["teacher_id"].ToString();
                    string teacherName = reader["teacher_name"].ToString();
                    ListItem item = new ListItem(teacherName, teacherId);
                    t_name.Items.Add(item);
                }
                reader.Close();

                // Check if the selected value exists in the t_name DropDownList and select it
                string selectedValue = Request.Form[t_name.UniqueID]; // Get the selected value from the t_name DropDownList
                ListItem selectedItem = t_name.Items.FindByValue(selectedValue);
                if (selectedItem != null)
                {
                    t_name.SelectedValue = selectedValue;
                    string teacherId = selectedItem.Value; // Get the teacher_id for the selected teacher_name
                    id.Text = teacherId;
                }

                con.Close();
            }
        }

        protected void submit_Click(object sender, EventArgs e)
        {
            if (Session["email"] != null)
            {
                if (string.IsNullOrWhiteSpace(year.SelectedValue) || string.IsNullOrWhiteSpace(sem.SelectedValue) ||
                string.IsNullOrWhiteSpace(c_no.Text.Trim()) || c_no.Text.Length != 2 ||
                string.IsNullOrWhiteSpace(c_name.Text.Trim()) || string.IsNullOrWhiteSpace(credit.Text.Trim()) ||
                string.IsNullOrWhiteSpace(id.Text.Trim()) || string.IsNullOrWhiteSpace(t_name.Text.Trim()))
                {
                    error.Text = "Some Information is Incorrect or Missing!";
                }
                else
                {
                    SqlConnection con = new SqlConnection(strcon);
                    con.Open();

                    // Check if the teacher ID already exists in the database
                    SqlCommand checkCmd = new SqlCommand("SELECT COUNT(*) FROM courses WHERE course_no = '" + c_code.Text.Trim() + c_year.Text.Trim() + c_sem.Text.Trim() + c_no.Text.Trim() + "'", con);
                    int existingTeacherCount = (int)checkCmd.ExecuteScalar();

                    if (existingTeacherCount > 0)
                    {
                        error.Text = "Course ID already exists!";
                    }
                    else
                    {
                        SqlCommand cmd = new SqlCommand("INSERT INTO courses VALUES ('" + dept.SelectedValue + "', '" + year.Text.Trim() + "', '" + sem.Text.Trim() + "', '" + c_code.Text.Trim() + c_year.Text.Trim() + c_sem.Text.Trim() + c_no.Text.Trim() + "', '" + c_name.Text.Trim() + "', '" + credit.Text.Trim() + "', '" + id.Text.Trim() + "', '" + t_name.SelectedItem + "')", con);

                        cmd.ExecuteNonQuery();
                        con.Close();

                        c_name.Text = "";
                        c_no.Text = "";
                        credit.Text = "";
                        id.Text = "";
                        t_name.Text = "";
                        t_from.SelectedIndex = 0;
                        error.Text = "";
                    }
                }
            }
        }
    }
}