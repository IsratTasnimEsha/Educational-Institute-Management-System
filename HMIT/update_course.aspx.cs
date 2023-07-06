using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Policy;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace HMIT
{
    public partial class update_course : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["email"] != null)
            {
                if (!IsPostBack)
                {
                    if (Session["PreviousPage"] != null && Session["PreviousPagePosition"] != null)
                    {
                        string previousPage = Session["PreviousPage"].ToString();
                        int previousPosition = int.Parse(Session["PreviousPagePosition"].ToString());

                        Server.Transfer(previousPage);
                    }

                    dept.Enabled = false;
                    dept.ForeColor = System.Drawing.Color.Black;
                    year.Enabled = false;
                    year.ForeColor = System.Drawing.Color.Black;
                    sem.Enabled = false;
                    sem.ForeColor = System.Drawing.Color.Black;
                    c_no.Enabled = false;
                    c_no.ForeColor = System.Drawing.Color.Black;
                    c_year.Enabled = false;
                    c_year.ForeColor = System.Drawing.Color.Black;
                    c_sem.Enabled = false;
                    c_sem.ForeColor = System.Drawing.Color.Black;
                    c_code.Enabled = false;
                    c_code.ForeColor = System.Drawing.Color.Black;
                    id.Enabled = false;
                    id.ForeColor = System.Drawing.Color.Black;

                    SqlConnection con = new SqlConnection(strcon);
                    con.Open();

                    if (Request.QueryString["CourseNO"] != null)
                    {
                        string courseNO = HttpUtility.UrlDecode(Request.QueryString["CourseNO"]);
                        SqlConnection con1 = new SqlConnection(strcon);
                        con1.Open();
                        SqlCommand cmd1 = new SqlCommand("SELECT * FROM courses WHERE course_no='" + courseNO + "'", con1); // Replace SomeCondition with your actual condition
                        SqlDataReader reader1 = cmd1.ExecuteReader();

                        if (reader1.Read())
                        {
                            if (reader1["department_id"].ToString() == "01")
                            {
                                dept.Text = "Civil Engineering";
                            }
                            if (reader1["department_id"].ToString() == "02")
                            {
                                dept.Text = "Electrical and Electronic Engineering";
                            }
                            if (reader1["department_id"].ToString() == "03")
                            {
                                dept.Text = "Mechanical Engineering";
                            }
                            if (reader1["department_id"].ToString() == "04")
                            {
                                dept.Text = "Computer Science and Engineering";
                            }
                            if (reader1["department_id"].ToString() == "05")
                            {
                                dept.Text = "Electronics and Communication Engineering";
                            }
                            if (reader1["department_id"].ToString() == "06")
                            {
                                dept.Text = "Biomedical Engineering";
                            }
                            if (reader1["department_id"].ToString() == "07")
                            {
                                dept.Text = "Material Science and Engineering";
                            }
                            if (reader1["department_id"].ToString() == "08")
                            {
                                dept.Text = "Industrial Engineering and Management";
                            }
                            if (reader1["department_id"].ToString() == "09")
                            {
                                dept.Text = "Chemical Engineering";
                            }
                            if (reader1["department_id"].ToString() == "10")
                            {
                                dept.Text = "Textile Engineering";
                            }
                            if (reader1["department_id"].ToString() == "11")
                            {
                                dept.Text = "Leather Engineering";
                            }
                            if (reader1["department_id"].ToString() == "12")
                            {
                                dept.Text = "Energy Science and Engineering";
                            }
                            if (reader1["department_id"].ToString() == "13")
                            {
                                dept.Text = "Mechatronics Engineering";
                            }
                            if (reader1["department_id"].ToString() == "14")
                            {
                                dept.Text = "Building Engineering and Construction Management";
                            }
                            if (reader1["department_id"].ToString() == "15")
                            {
                                dept.Text = "Urban and Regional Planning";
                            }
                            if (reader1["department_id"].ToString() == "16")
                            {
                                dept.Text = "Architecture";
                            }
                            if (reader1["department_id"].ToString() == "17")
                            {
                                dept.Text = "Mathematics";
                            }
                            if (reader1["department_id"].ToString() == "18")
                            {
                                dept.Text = "Chemistry";
                            }
                            if (reader1["department_id"].ToString() == "19")
                            {
                                dept.Text = "Physics";
                            }
                            if (reader1["department_id"].ToString() == "20")
                            {
                                dept.Text = "Humanities";
                            }

                            if (reader1["running_year"].ToString() == "1")
                            {
                                year.Text = "First";
                            }
                            if (reader1["running_year"].ToString() == "2")
                            {
                                year.Text = "Second";
                            }
                            if (reader1["running_year"].ToString() == "3")
                            {
                                year.Text = "Third";
                            }
                            if (reader1["running_year"].ToString() == "4")
                            {
                                year.Text = "Fourth";
                            }

                            if (reader1["semester"].ToString() == "1")
                            {
                                sem.Text = "First";
                            }
                            if (reader1["semester"].ToString() == "2")
                            {
                                sem.Text = "Second";
                            }

                            c_code.Text = "" + reader1["course_no"].ToString()[0] + reader1["course_no"].ToString()[1];
                            c_year.Text = "" + reader1["course_no"].ToString()[2];
                            c_sem.Text = "" + reader1["course_no"].ToString()[3];
                            c_no.Text = "" + reader1["course_no"].ToString()[4] + reader1["course_no"].ToString()[5];

                            c_name.Text = reader1["course_title"].ToString();
                            credit.Text = reader1["credit"].ToString();

                            t_from.SelectedIndex = Convert.ToInt32("" + reader1["teacher_id"].ToString()[0] + reader1["teacher_id"].ToString()[1]);

                            SqlConnection con2 = new SqlConnection(strcon);
                            con2.Open();

                            SqlCommand checkCmd = new SqlCommand("SELECT * FROM faculty_members where department='" + t_from.SelectedValue + "'", con2);

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
                            con2.Close();

                            t_name.SelectedValue = reader1["teacher_id"].ToString();
                            id.Text = reader1["teacher_id"].ToString();

                        }
                        reader1.Close();
                        con1.Close();
                    }
                }
            }
        }

        protected void dept_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Session["email"] != null)
            {
                SqlConnection con = new SqlConnection(strcon);
                con.Open();

                SqlCommand checkCmd = new SqlCommand("SELECT * FROM faculty_members where department='" + t_from.SelectedValue + "'", con);

                SqlDataReader reader = checkCmd.ExecuteReader();
                t_name.Items.Clear();
                t_name.Items.Add("");
                while (reader.Read())
                {
                    string teacherId = reader["teacher_id"].ToString();
                    string teacherName = reader["teacher_name"].ToString();
                    ListItem item = new ListItem(teacherName, teacherId);
                    t_name.Items.Add(item);
                }
                reader.Close();

                string selectedValue = Request.Form[t_name.UniqueID];
                ListItem selectedItem = t_name.Items.FindByValue(selectedValue);
                if (selectedItem != null)
                {
                    t_name.SelectedValue = selectedValue;
                    string teacherId = selectedItem.Value;
                    id.Text = teacherId;
                }
            }
        }

        protected void submit_Click(object sender, EventArgs e)
        {
            if (Session["email"] != null)
            {
                if (string.IsNullOrWhiteSpace(c_no.Text.Trim()) || c_no.Text.Length != 2 ||
                string.IsNullOrWhiteSpace(c_name.Text.Trim()) || string.IsNullOrWhiteSpace(credit.Text.Trim()) ||
                string.IsNullOrWhiteSpace(id.Text.Trim()) || string.IsNullOrWhiteSpace(t_name.Text.Trim()))
                {
                    error.Text = "Some Information is Incorrect or Missing!";
                }
                else
                {
                    SqlConnection con = new SqlConnection(strcon);
                    con.Open();

                    SqlCommand cmd = new SqlCommand("update courses set course_title='" + c_name.Text.Trim() + "', credit='" + credit.Text.Trim() + "', teacher_id='" + id.Text.Trim() + "', teacher_name='" + t_name.SelectedItem + "' where course_no= '" + c_code.Text.Trim() + c_year.Text.Trim() + c_sem.Text.Trim() + c_no.Text.Trim() + "'", con);

                    cmd.ExecuteNonQuery();
                    con.Close();

                    Response.Redirect("view_course.aspx");
                }
            }
        }
    }
}