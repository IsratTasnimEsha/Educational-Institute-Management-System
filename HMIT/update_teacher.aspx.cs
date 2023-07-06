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
    public partial class update_teacher : System.Web.UI.Page
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
                    lblMessage.Visible = false;
                    dept.Enabled = false;
                    dept.ForeColor = System.Drawing.Color.Black;
                    id.Enabled = false;
                    id.ForeColor = System.Drawing.Color.Black;
                    code.Enabled = false;
                    code.ForeColor = System.Drawing.Color.Black;
                    mail.Enabled = false;
                    mail.ForeColor = System.Drawing.Color.Black;
                    pass.Enabled = false;
                    pass.ForeColor = System.Drawing.Color.Black;
                    grd.Enabled = false;
                    grd.ForeColor = System.Drawing.Color.Black;
                    salary.Enabled = false;
                    salary.ForeColor = System.Drawing.Color.Black;
                    j_date.Enabled = false;
                    j_date.ForeColor = System.Drawing.Color.Black;
                    j_date.Text = DateTime.Now.ToString("yyyy-MM-dd");

                    SqlConnection con = new SqlConnection(strcon);
                    con.Open();

                    SqlCommand checkCmd = new SqlCommand("SELECT designation FROM grades", con);

                    SqlDataReader reader = checkCmd.ExecuteReader();
                    while (reader.Read())
                    {
                        designation.Items.Add(reader["designation"].ToString());
                    }
                    reader.Close();
                    con.Close();

                    if (Request.QueryString["teacherID"] != null)
                    {
                        string teacherID = HttpUtility.UrlDecode(Request.QueryString["teacherID"]);
                        SqlConnection con1 = new SqlConnection(strcon);
                        con1.Open();
                        SqlCommand cmd1 = new SqlCommand("SELECT * FROM faculty_members WHERE teacher_id='" + teacherID + "'", con1); // Replace SomeCondition with your actual condition
                        SqlDataReader reader1 = cmd1.ExecuteReader();

                        if (reader1.Read())
                        {
                            name.Text = reader1["teacher_name"].ToString();

                            string t_id = reader1["teacher_id"].ToString();
                            code.Text = "" + t_id[0] + t_id[1];
                            id.Text = "" + t_id[2] + t_id[3] + t_id[4];

                            if (reader1["department"].ToString() == "01")
                            {
                                dept.Text = "Civil Engineering";
                            }
                            if (reader1["department"].ToString() == "02")
                            {
                                dept.Text = "Electrical and Electronic Engineering";
                            }
                            if (reader1["department"].ToString() == "03")
                            {
                                dept.Text = "Mechanical Engineering";
                            }
                            if (reader1["department"].ToString() == "04")
                            {
                                dept.Text = "Computer Science and Engineering";
                            }
                            if (reader1["department"].ToString() == "05")
                            {
                                dept.Text = "Electronics and Communication Engineering";
                            }
                            if (reader1["department"].ToString() == "06")
                            {
                                dept.Text = "Biomedical Engineering";
                            }
                            if (reader1["department"].ToString() == "07")
                            {
                                dept.Text = "Material Science and Engineering";
                            }
                            if (reader1["department"].ToString() == "08")
                            {
                                dept.Text = "Industrial Engineering and Management";
                            }
                            if (reader1["department"].ToString() == "09")
                            {
                                dept.Text = "Chemical Engineering";
                            }
                            if (reader1["department"].ToString() == "10")
                            {
                                dept.Text = "Textile Engineering";
                            }
                            if (reader1["department"].ToString() == "11")
                            {
                                dept.Text = "Leather Engineering";
                            }
                            if (reader1["department"].ToString() == "12")
                            {
                                dept.Text = "Energy Science and Engineering";
                            }
                            if (reader1["department"].ToString() == "13")
                            {
                                dept.Text = "Mechatronics Engineering";
                            }
                            if (reader1["department"].ToString() == "14")
                            {
                                dept.Text = "Building Engineering and Construction Management";
                            }
                            if (reader1["department"].ToString() == "15")
                            {
                                dept.Text = "Urban and Regional Planning";
                            }
                            if (reader1["department"].ToString() == "16")
                            {
                                dept.Text = "Architecture";
                            }
                            if (reader1["department"].ToString() == "17")
                            {
                                dept.Text = "Mathematics";
                            }
                            if (reader1["department"].ToString() == "18")
                            {
                                dept.Text = "Chemistry";
                            }
                            if (reader1["department"].ToString() == "19")
                            {
                                dept.Text = "Physics";
                            }
                            if (reader1["department"].ToString() == "20")
                            {
                                dept.Text = "Humanities";
                            }

                            mail.Text = reader1["email"].ToString();
                            phone.Text = reader1["phone"].ToString();
                            j_date.Text = reader1["join_date"].ToString();
                            grd.Text = reader1["grade"].ToString();
                            designation.Text = reader1["designation"].ToString();
                            salary.Text = reader1["salary"].ToString();
                            ad.Text = reader1["t_address"].ToString();
                            lblMessage.Text = reader1["imageID"].ToString();

                            string en_pass = reader1["pass"].ToString();

                            UTF8Encoding encoded = new UTF8Encoding();
                            Decoder decode = encoded.GetDecoder();
                            byte[] todecode_byte = Convert.FromBase64String(en_pass);
                            int char_count = decode.GetCharCount(todecode_byte, 0, todecode_byte.Length);
                            char[] decoded_char = new char[char_count];
                            decode.GetChars(todecode_byte, 0, todecode_byte.Length, decoded_char, 0);
                            string dec_pass = new String(decoded_char);

                            pass.Text = dec_pass;

                            String imageID = reader1["imageID"].ToString();

                            using (SqlConnection con2 = new SqlConnection(strcon))
                            {
                                SqlCommand cmd = new SqlCommand("spGetImageById", con2);
                                cmd.CommandType = CommandType.StoredProcedure;

                                SqlParameter paramId = new SqlParameter()
                                {
                                    ParameterName = "@Id",
                                    Value = imageID
                                };
                                cmd.Parameters.Add(paramId);

                                con2.Open();
                                byte[] bytes = (byte[])cmd.ExecuteScalar();
                                string strBase64 = Convert.ToBase64String(bytes);
                                Image1.ImageUrl = "data:Image/png;base64," + strBase64;

                                con2.Close();
                            }
                        }
                        reader1.Close();
                        con1.Close();
                    }
                }
            }
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            if (Session["email"] != null)
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

                if (!string.IsNullOrEmpty(name.Text) && !string.IsNullOrEmpty(dept.Text) &&
                    !string.IsNullOrEmpty(id.Text) && id.Text.Length == 3)
                {
                    string teacherID = HttpUtility.UrlDecode(Request.QueryString["teacherID"]);
                    pass.Text = name.Text[0] + teacherID;
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
                if (string.IsNullOrWhiteSpace(name.Text.Trim()) || string.IsNullOrWhiteSpace(dept.Text) ||
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

                    string teacherID = HttpUtility.UrlDecode(Request.QueryString["teacherID"]);

                    byte[] encode = new byte[pass.Text.ToString().Length];
                    encode = Encoding.UTF8.GetBytes(pass.Text);
                    string encrypted = Convert.ToBase64String(encode);

                    SqlCommand cmd = new SqlCommand("update faculty_members set teacher_name='" + name.Text.Trim() + "', phone='" + phone.Text.Trim() + "', t_address='" + ad.Text.Trim() + "', designation='" + designation.SelectedValue + "', join_date='" + j_date.Text.Trim() + "', salary='" + salary.Text.Trim() + "', grade='" + grd.Text.Trim() + "', pass='" + encrypted + "', imageID = " + Convert.ToInt32(lblMessage.Text) + " where teacher_id='" + teacherID + "'", con);

                    cmd.ExecuteNonQuery();
                    con.Close();

                    Response.Redirect("view_teacher.aspx");
                }
            }
        }
    }
}