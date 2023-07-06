using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HMIT
{
    public partial class add_teacher : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
        DateTime selectedDate;
        string selectedDateString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["email"] != null)
            {
                if (!IsPostBack)
                {
                    string DeptID = HttpUtility.UrlDecode(Request.QueryString["DeptID"]);

                    lblMessage.Visible = false;
                    code.Enabled = false;
                    code.ForeColor = System.Drawing.Color.Black;
                    email.Enabled = false;
                    email.ForeColor = System.Drawing.Color.Black;
                    pass.Enabled = false;
                    pass.ForeColor = System.Drawing.Color.Black;
                    grd.Enabled = false;
                    grd.ForeColor = System.Drawing.Color.Black;
                    salary.Enabled = false;
                    salary.ForeColor = System.Drawing.Color.Black;
                    j_date.Enabled = false;
                    j_date.ForeColor = System.Drawing.Color.Black;
                    j_date.Text = DateTime.Now.ToString("yyyy-MM-dd");

                    dept.SelectedIndex = Convert.ToInt32(DeptID);
                    code.Text = DeptID;

                    string teacherID = HttpUtility.UrlDecode(Request.QueryString["TeacherID"]);


                    SqlConnection con = new SqlConnection(strcon);
                    con.Open();

                    SqlCommand checkCmd = new SqlCommand("SELECT designation FROM grades", con);

                    SqlDataReader reader = checkCmd.ExecuteReader();
                    while (reader.Read())
                    {
                        designation.Items.Add(reader["designation"].ToString());
                    }
                    reader.Close();
                }
            }
        }


        protected void btnUpload_Click(object sender, EventArgs e)
        {
            if (Session["email"] != null)
            {
                if (FileUpload1.HasFile)
                {
                    HttpPostedFile postedFile = FileUpload1.PostedFile;
                    string filename = Path.GetFileName(postedFile.FileName);
                    string fileExtension = Path.GetExtension(filename);
                    int fileSize = postedFile.ContentLength;

                    if (fileExtension.ToLower() == ".jpg" || fileExtension.ToLower() == ".gif"
                        || fileExtension.ToLower() == ".png" || fileExtension.ToLower() == ".bmp")
                    {
                        Stream stream = postedFile.InputStream;
                        BinaryReader binaryReader = new BinaryReader(stream);
                        Byte[] bytes = binaryReader.ReadBytes((int)stream.Length);

                        using (SqlConnection con = new SqlConnection(strcon))
                        {
                            SqlCommand cmd = new SqlCommand("spUploadImage", con);
                            cmd.CommandType = CommandType.StoredProcedure;

                            SqlParameter paramName = new SqlParameter()
                            {
                                ParameterName = @"Name",
                                Value = filename
                            };
                            cmd.Parameters.Add(paramName);

                            SqlParameter paramSize = new SqlParameter()
                            {
                                ParameterName = "@Size",
                                Value = fileSize
                            };
                            cmd.Parameters.Add(paramSize);

                            SqlParameter paramImageData = new SqlParameter()
                            {
                                ParameterName = "@ImageData",
                                Value = bytes
                            };
                            cmd.Parameters.Add(paramImageData);

                            SqlParameter paramNewId = new SqlParameter()
                            {
                                ParameterName = "@NewId",
                                Value = -1,
                                Direction = ParameterDirection.Output
                            };
                            cmd.Parameters.Add(paramNewId);

                            con.Open();
                            cmd.ExecuteNonQuery();
                            con.Close();

                            string strBase64 = Convert.ToBase64String(bytes);
                            Image1.ImageUrl = "data:Image/png;base64," + strBase64;

                            lblMessage.Text = cmd.Parameters["@NewId"].Value.ToString();
                        }
                    }
                }

                updatePanel.Update();
            }
        }

        protected void dept_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Session["email"] != null)
            {
                selectedDate = calDate.SelectedDate;
                selectedDateString = selectedDate.ToString("yyyy-MM-dd");

                if (selectedDateString != "0001-01-01")
                {
                    j_date.Text = selectedDateString;
                }

                SqlConnection con = new SqlConnection(strcon);
                con.Open();
                SqlCommand cmd1 = new SqlCommand("select grade, starting_salary, maximum_salary from grades where designation='" + designation.Text.Trim() + "'", con);

                SqlDataReader reader = cmd1.ExecuteReader();
                if (reader.Read())
                {
                    grd.Text = reader["grade"].ToString();

                    int timeDifference = DateTime.Now.Year - selectedDate.Year;

                    if (DateTime.Now.Month < selectedDate.Month || (DateTime.Now.Month == selectedDate.Month && DateTime.Now.Day < selectedDate.Day))
                    {
                        timeDifference--;
                    }

                    double salary1 = Convert.ToDouble(reader["starting_salary"]) + Convert.ToDouble(reader["starting_salary"]) * timeDifference * 0.05;
                    int salary2 = Convert.ToInt32(salary1);

                    if (timeDifference < 0)
                    {
                        salary.Text = "0";
                    }

                    else if (salary2 < Convert.ToInt32(reader["maximum_salary"]))
                    {
                        salary.Text = Convert.ToString(salary2);
                    }

                    else
                    {
                        salary.Text = Convert.ToString(reader["maximum_salary"]);
                    }

                }
                reader.Close();
                con.Close();
                if (!string.IsNullOrEmpty(dept.SelectedValue))
                {
                    code.Text = dept.SelectedValue;
                }
                if (!string.IsNullOrEmpty(dept.SelectedValue) && !string.IsNullOrEmpty(id.Text) && id.Text.Length == 3)
                {
                    email.Text = "t" + dept.SelectedValue + id.Text.Trim() + "@hmit.edu";
                }
                else
                {
                    email.Text = "";
                }

                if (!string.IsNullOrEmpty(name.Text) && !string.IsNullOrEmpty(dept.SelectedValue) &&
                    !string.IsNullOrEmpty(id.Text) && id.Text.Length == 3)
                {
                    pass.Text = name.Text[0] + dept.SelectedValue + id.Text.Trim();
                }
                else
                {
                    pass.Text = "";
                }
            }
        }

        protected void submit_Click(object sender, EventArgs e)
        {
            if (Session["email"] != null)
            {
                if (string.IsNullOrWhiteSpace(name.Text.Trim()) || string.IsNullOrWhiteSpace(dept.SelectedValue) ||
                string.IsNullOrWhiteSpace(phone.Text.Trim()) || phone.Text.Trim().Length != 11 ||
                string.IsNullOrWhiteSpace(ad.Text.Trim()) || string.IsNullOrWhiteSpace(designation.SelectedValue) ||
                string.IsNullOrWhiteSpace(salary.Text.Trim()) || string.IsNullOrWhiteSpace(id.Text.Trim()) ||
                id.Text.Trim().Length != 3 || string.IsNullOrWhiteSpace(grd.Text.Trim()))
                {
                    error.Text = "Some Information is Incorrect or Missing!";
                }
                else
                {
                    SqlConnection con = new SqlConnection(strcon);
                    con.Open();

                    // Check if the teacher ID already exists in the database
                    SqlCommand checkCmd = new SqlCommand("SELECT COUNT(*) FROM faculty_members WHERE teacher_iD = @TeacherID", con);
                    checkCmd.Parameters.AddWithValue("@TeacherID", code.Text.Trim() + id.Text.Trim());
                    int existingTeacherCount = (int)checkCmd.ExecuteScalar();

                    if (existingTeacherCount > 0)
                    {
                        error.Text = "Teacher ID already exists!";
                    }
                    else
                    {
                        byte[] encode = new byte[pass.Text.ToString().Length];
                        encode = Encoding.UTF8.GetBytes(pass.Text);
                        string encrypted = Convert.ToBase64String(encode);

                        // Insert the teacher record into the database
                        SqlCommand cmd = new SqlCommand("INSERT INTO faculty_members VALUES ('" + name.Text.Trim() + "', '" + dept.Text.Trim() + "', '" + phone.Text.Trim() + "', '" + ad.Text.Trim() + "', '" + designation.SelectedValue + "', '" + j_date.Text.Trim() + "', '" + salary.Text.Trim() + "', '" + code.Text.Trim() + id.Text.Trim() + "', '" + grd.Text.Trim() + "', '" + email.Text.Trim() + "', '" + encrypted + "', " + Convert.ToInt32(lblMessage.Text) + ")", con);

                        cmd.ExecuteNonQuery();
                        con.Close();

                        Response.Redirect("add_teacher.aspx?DeptID=" + HttpUtility.UrlEncode(dept.Text));
                    }
                }
            }
        }
    }
}