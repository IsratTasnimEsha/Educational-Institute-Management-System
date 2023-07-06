using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace HMIT
{
    public partial class teacher : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["email"] != null)
            {
                if (!IsPostBack)
                {
                    j_date.Enabled = false;
                    grade.Enabled = false;
                    position.Enabled = false;
                    salary.Enabled = false;
                    j_date.ForeColor = System.Drawing.Color.Black;
                    grade.ForeColor = System.Drawing.Color.Black;
                    position.ForeColor = System.Drawing.Color.Black;
                    salary.ForeColor = System.Drawing.Color.Black;
                    if (Request.QueryString["TeacherID"] != null)
                    {
                        string teacherID = HttpUtility.UrlDecode(Request.QueryString["TeacherID"]);

                        SqlConnection con = new SqlConnection(strcon);
                        con.Open();
                        SqlCommand cmd = new SqlCommand("SELECT * FROM faculty_members WHERE teacher_id='" + teacherID + "'", con); // Replace SomeCondition with your actual condition
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            name.Text = reader["teacher_name"].ToString();
                            id.Text = reader["teacher_id"].ToString();

                            if (reader["department"].ToString() == "01")
                            {
                                dept.Text = "Civil Engineering";
                            }
                            if (reader["department"].ToString() == "02")
                            {
                                dept.Text = "Electrical and Electronic Engineering";
                            }
                            if (reader["department"].ToString() == "03")
                            {
                                dept.Text = "Mechanical Engineering";
                            }
                            if (reader["department"].ToString() == "04")
                            {
                                dept.Text = "Computer Science and Engineering";
                            }
                            if (reader["department"].ToString() == "05")
                            {
                                dept.Text = "Electronics and Communication Engineering";
                            }
                            if (reader["department"].ToString() == "06")
                            {
                                dept.Text = "Biomedical Engineering";
                            }
                            if (reader["department"].ToString() == "07")
                            {
                                dept.Text = "Material Science and Engineering";
                            }
                            if (reader["department"].ToString() == "08")
                            {
                                dept.Text = "Industrial Engineering and Management";
                            }
                            if (reader["department"].ToString() == "09")
                            {
                                dept.Text = "Chemical Engineering";
                            }
                            if (reader["department"].ToString() == "10")
                            {
                                dept.Text = "Textile Engineering";
                            }
                            if (reader["department"].ToString() == "11")
                            {
                                dept.Text = "Leather Engineering";
                            }
                            if (reader["department"].ToString() == "12")
                            {
                                dept.Text = "Energy Science and Engineering";
                            }
                            if (reader["department"].ToString() == "13")
                            {
                                dept.Text = "Mechatronics Engineering";
                            }
                            if (reader["department"].ToString() == "14")
                            {
                                dept.Text = "Building Engineering and Construction Management";
                            }
                            if (reader["department"].ToString() == "15")
                            {
                                dept.Text = "Urban and Regional Planning";
                            }
                            if (reader["department"].ToString() == "16")
                            {
                                dept.Text = "Architecture";
                            }
                            if (reader["department"].ToString() == "17")
                            {
                                dept.Text = "Mathematics";
                            }
                            if (reader["department"].ToString() == "18")
                            {
                                dept.Text = "Chemistry";
                            }
                            if (reader["department"].ToString() == "19")
                            {
                                dept.Text = "Physics";
                            }
                            if (reader["department"].ToString() == "20")
                            {
                                dept.Text = "Humanities";
                            }
                            mail.Text = reader["email"].ToString();
                            phone.Text = reader["phone"].ToString();
                            j_date.Text = reader["join_date"].ToString();
                            grade.Text = reader["grade"].ToString();
                            position.Text = reader["designation"].ToString();
                            salary.Text = reader["salary"].ToString();
                            ad.Text = reader["t_address"].ToString();

                            String imageID = reader["imageID"].ToString();

                            using (SqlConnection con2 = new SqlConnection(strcon))
                            {
                                SqlCommand cmd1 = new SqlCommand("spGetImageById", con2);
                                cmd1.CommandType = CommandType.StoredProcedure;

                                SqlParameter paramId = new SqlParameter()
                                {
                                    ParameterName = "@Id",
                                    Value = imageID
                                };
                                cmd1.Parameters.Add(paramId);

                                con2.Open();
                                byte[] bytes = (byte[])cmd1.ExecuteScalar();
                                string strBase64 = Convert.ToBase64String(bytes);
                                Image1.ImageUrl = "data:Image/png;base64," + strBase64;

                                con2.Close();
                            }
                            reader.Close();
                            con.Close();
                        }
                    }
                }
            }
        }

        protected void assigned_Click(object sender, EventArgs e)
        {
            if (Session["email"] != null)
            {
                Response.Redirect("teacher_courses.aspx?teacherID=" + HttpUtility.UrlEncode(id.Text.Trim()));
            }
        }

        protected void personal_Click(object sender, EventArgs e)
        {
            if (Session["email"] != null)
            {
                string teacherID = HttpUtility.UrlDecode(Request.QueryString["TeacherID"]);

                if (string.IsNullOrWhiteSpace(phone.Text.Trim()) || string.IsNullOrWhiteSpace(ad.Text.Trim()))
                {
                    error.Text = "Phone Or Address Can't Be Empty";
                }

                else
                {
                    SqlConnection con = new SqlConnection(strcon);

                    con.Open();
                    SqlCommand cmd = new SqlCommand("update faculty_members set phone = '" + phone.Text.Trim() + "', t_address = '" + ad.Text.Trim() + "' where teacher_id = '" + teacherID + "';", con);
                    cmd.ExecuteNonQuery();
                    con.Close();

                    error.Text = "";
                }
            }
        }

        protected void reset_Click(object sender, EventArgs e)
        {
            if (Session["email"] != null)
            {
                if (string.IsNullOrWhiteSpace(old.Text.Trim()) ||
                string.IsNullOrWhiteSpace(neww.Text.Trim()) ||
                string.IsNullOrWhiteSpace(confirm.Text.Trim()))
                {
                    error2.Text = "Some Information is Incorrect or Missing!";
                }

                else
                {
                    string teacherID = HttpUtility.UrlDecode(Request.QueryString["TeacherID"]);
                    SqlConnection con = new SqlConnection(strcon);

                    con.Open();
                    SqlCommand cmd = new SqlCommand("select pass from faculty_members where teacher_id='" + teacherID + "'", con);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        string en_pass = reader["pass"].ToString();

                        UTF8Encoding encoded = new UTF8Encoding();
                        Decoder decode = encoded.GetDecoder();
                        byte[] todecode_byte = Convert.FromBase64String(en_pass);
                        int char_count = decode.GetCharCount(todecode_byte, 0, todecode_byte.Length);
                        char[] decoded_char = new char[char_count];
                        decode.GetChars(todecode_byte, 0, todecode_byte.Length, decoded_char, 0);
                        string dec_pass = new String(decoded_char);

                        if (old.Text == dec_pass && neww.Text.Trim() == confirm.Text.Trim())
                        {
                            reader.Close();

                            byte[] encode = new byte[neww.Text.ToString().Length];
                            encode = Encoding.UTF8.GetBytes(neww.Text);
                            string encrypted = Convert.ToBase64String(encode);

                            SqlCommand cmdpass = new SqlCommand("update faculty_members set pass = '" + encrypted + "' where teacher_id='" + teacherID + "'", con);
                            cmdpass.ExecuteNonQuery();

                            old.Text = "";
                            neww.Text = "";
                            confirm.Text = "";
                            error2.Text = "";
                        }

                        else
                        {
                            error2.Text = "Password Didn't Match";
                        }
                    }
                    reader.Close();
                    con.Close();
                }
            }
        }
    }
}