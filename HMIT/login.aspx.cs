using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace HMIT
{
    public partial class login : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void submit_Click(object sender, EventArgs e)
        {
            string email = mail.Text.Trim();
            string password = pass.Text.Trim();

            if (string.IsNullOrWhiteSpace(email))
            {
                error.Text = "Email Or Password Is Wrong!";
            }

            else if (email[0] == 's')
            {
                if (ValidateStudent(email, password))
                {
                    Session["email"] = email;
                    Response.Redirect("student_home.aspx?StudentID=" + HttpUtility.UrlEncode("" + email[1] + email[2] + email[3] + email[4] + email[5] + email[6] + email[7]));
                }
                else
                {
                    error.Text = "Email Or Password Is Wrong!";
                }
            }

            else if (email[0] == 't')
            {
                if (ValidateTeacher(email, password))
                {
                    Session["email"] = email;
                    Response.Redirect("teacher.aspx?TeacherID=" + HttpUtility.UrlEncode("" + email[1] + email[2] + email[3] + email[4] + email[5]));
                }
                else
                {
                    error.Text = "Email Or Password Is Wrong!";
                }
            }

            else if (email == "admin@hmit.edu" && password == "admin")
            {
                Session["email"] = email;
                Response.Redirect("admin.aspx");
            }

            else
            {
                error.Text = "Email Or Password Is Wrong!";
            }
        }

        private bool ValidateStudent(string email, string password)
        {
            bool isValidUser = false;

            using (SqlConnection con = new SqlConnection(strcon))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM students WHERE email = @Email", con);
                cmd.Parameters.AddWithValue("@Email", email);

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

                    if (dec_pass == pass.Text)
                    {
                        isValidUser = true;
                    }
                }
                reader.Close();
                con.Close();
            }
            return isValidUser;
        }

        private bool ValidateTeacher(string email, string password)
        {
            bool isValidUser = false;

            using (SqlConnection con = new SqlConnection(strcon))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM faculty_members WHERE email = @Email", con);
                cmd.Parameters.AddWithValue("@Email", email);    
               
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

                    if (dec_pass == pass.Text)
                    {
                        isValidUser = true;
                    }
                }
                reader.Close();
                con.Close();
            }
            return isValidUser;
        }
    }
}