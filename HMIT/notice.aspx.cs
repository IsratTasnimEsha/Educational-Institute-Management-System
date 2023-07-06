using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HMIT
{
    public partial class notice : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SqlConnection con = new SqlConnection(strcon);
                con.Open();

                string query = "SELECT date_time, from_whom, to_whom, sub, msg FROM notice";

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

        protected void year_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(strcon);

            string selectedSearch = search.Text.Trim();

            string query = "SELECT date_time, from_whom, to_whom, sub, msg FROM notice where date_time like '%" + search.Text.Trim() + "%' or from_whom like '%" + search.Text.Trim() + "%' or to_whom like '%" + search.Text.Trim() + "%' or sub like '%" + search.Text.Trim() + "%' or msg like '%" + search.Text.Trim() + "%'";

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