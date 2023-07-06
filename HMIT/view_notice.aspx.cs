using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

namespace HMIT
{
    public partial class view_notice : System.Web.UI.Page
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

                    string query = "SELECT date_time, from_whom, to_whom, sub, msg FROM notice order by date_time desc";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        GridViewNotices.DataSource = dt;
                        GridViewNotices.DataBind();

                        GridViewNotices.Visible = true;
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

                string date_time = GridViewNotices.DataKeys[rowIndex]["date_time"].ToString();

                SqlConnection con = new SqlConnection(strcon);
                con.Open();

                SqlCommand cmd = new SqlCommand("delete FROM notice WHERE date_time = '" + date_time + "'", con);

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

                string selectedSearch = search.Text.Trim();

                string query = "SELECT date_time, from_whom, to_whom, sub, msg FROM notice where date_time like '%" + search.Text.Trim() + "%' or from_whom like '%" + search.Text.Trim() + "%' or to_whom like '%" + search.Text.Trim() + "%' or sub like '%" + search.Text.Trim() + "%' or msg like '%" + search.Text.Trim() + "%' order by date_time desc";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    GridViewNotices.DataSource = dt;
                    GridViewNotices.DataBind();

                    GridViewNotices.Visible = true; // Show the GridView after binding the data
                }
            }
        }
    }
}