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
    public partial class add_student : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["email"] != null)
            {
                if (!IsPostBack)
                {
                    string DeptID = HttpUtility.UrlDecode(Request.QueryString["DeptID"]);
                    string BatchID = HttpUtility.UrlDecode(Request.QueryString["BatchID"]);

                    lblMessage.Visible = false;
                    code.Enabled = false;
                    code.ForeColor = System.Drawing.Color.Black;
                    btch.Enabled = false;
                    btch.ForeColor = System.Drawing.Color.Black;
                    mail.Enabled = false;
                    mail.ForeColor = System.Drawing.Color.Black;
                    pass.Enabled = false;
                    pass.ForeColor = System.Drawing.Color.Black;

                    int currentYear = DateTime.Now.Year;

                    for (int year = currentYear; year >= currentYear - 10; year--)
                    {
                        batch.Items.Add(new ListItem(year.ToString(), year.ToString()));
                    }

                    dept.SelectedIndex = Convert.ToInt32(DeptID);
                    code.Text = DeptID;
                    batch.SelectedValue = BatchID;
                    btch.Text = BatchID;
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
                if (!String.IsNullOrEmpty(batch.SelectedValue))
                {
                    btch.Text = "" + batch.SelectedValue[2] + batch.SelectedValue[3];
                }
                if (!String.IsNullOrEmpty(dept.SelectedValue))
                {
                    code.Text = dept.SelectedValue;
                }
                if (!string.IsNullOrEmpty(dept.SelectedValue) && !string.IsNullOrEmpty(batch.SelectedValue) &&
                    !string.IsNullOrEmpty(id.Text) && id.Text.Length == 3)
                {
                    mail.Text = "s" + batch.SelectedValue[2] + batch.SelectedValue[3] + dept.SelectedValue + id.Text.Trim() + "@hmit.edu";
                }
                else
                {
                    mail.Text = "";
                }

                if (!string.IsNullOrEmpty(dept.SelectedValue) && !string.IsNullOrEmpty(batch.SelectedValue) &&
                    !string.IsNullOrEmpty(id.Text) && id.Text.Length == 3 && !string.IsNullOrEmpty(name.Text))
                {
                    pass.Text = "" + name.Text[0] + batch.SelectedValue[2] + batch.SelectedValue[3] + dept.SelectedValue + id.Text.Trim();
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
                if (string.IsNullOrWhiteSpace(name.Text) || string.IsNullOrWhiteSpace(dept.SelectedValue) ||
                string.IsNullOrWhiteSpace(phone.Text) || phone.Text.Length != 11 ||
                string.IsNullOrWhiteSpace(fname.Text) || string.IsNullOrWhiteSpace(mname.Text) ||
                string.IsNullOrWhiteSpace(ad.Text) || string.IsNullOrEmpty(batch.SelectedValue) ||
                string.IsNullOrWhiteSpace(code.Text) || string.IsNullOrWhiteSpace(btch.Text) ||
                string.IsNullOrWhiteSpace(id.Text) || id.Text.Length != 3 ||
                string.IsNullOrWhiteSpace(pass.Text))
                {
                    error.Text = "Some Informations Are Incorrect Or Missing!";
                }

                else
                {
                    SqlConnection con = new SqlConnection(strcon);
                    con.Open();
                    SqlCommand checkCmd = new SqlCommand("SELECT COUNT(*) FROM students WHERE student_id = @id", con);
                    checkCmd.Parameters.AddWithValue("@id", "" + batch.SelectedValue[2] + batch.SelectedValue[3] + code.Text.Trim() + id.Text.Trim());
                    int idCount = (int)checkCmd.ExecuteScalar();

                    if (idCount > 0)
                    {
                        error.Text = "Studnt Id Already Exists!";
                    }
                    else
                    {
                        byte[] encode = new byte[pass.Text.ToString().Length];
                        encode = Encoding.UTF8.GetBytes(pass.Text);
                        string encrypted = Convert.ToBase64String(encode);

                        SqlCommand cmd = new SqlCommand("INSERT INTO students VALUES(@name, @dept, @phone, @fname, @mname, @ad, @batch, @id, @mail, @pass, " + lblMessage.Text + ")", con);
                        cmd.Parameters.AddWithValue("@name", name.Text.Trim());
                        cmd.Parameters.AddWithValue("@dept", dept.Text.Trim());
                        cmd.Parameters.AddWithValue("@phone", phone.Text.Trim());
                        cmd.Parameters.AddWithValue("@fname", fname.Text.Trim());
                        cmd.Parameters.AddWithValue("@mname", mname.Text.Trim());
                        cmd.Parameters.AddWithValue("@ad", ad.Text.Trim());
                        cmd.Parameters.AddWithValue("@batch", batch.Text.Trim());
                        cmd.Parameters.AddWithValue("@id", "" + batch.SelectedValue[2] + batch.SelectedValue[3] + code.Text.Trim() + id.Text.Trim());
                        cmd.Parameters.AddWithValue("@mail", mail.Text.Trim());
                        cmd.Parameters.AddWithValue("@pass", encrypted);
                        cmd.ExecuteNonQuery();

                        Response.Redirect("add_student.aspx?DeptID=" + HttpUtility.UrlEncode(dept.Text) + "&BatchID=" + HttpUtility.UrlEncode(batch.SelectedValue));
                    }
                    con.Close();
                }
            }
        }
    }
}