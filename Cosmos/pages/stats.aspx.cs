using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
namespace Cosmos.pages
{
    public partial class stats : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Admin"].ToString() == "False")
            {
                Response.Redirect("index.aspx");
            }
            string SQLStr = $"SELECT * FROM currentUsers";
            DataSet ds = Helper.RetrieveTable(SQLStr, "currentUsers");
            DataTable dt = ds.Tables["currentUsers"];
            string table = Helper.BuildStats(dt);
            tableDiv.InnerHtml = table;
            overallusers.InnerHtml = Helper.RetrieveTable($"SELECT * FROM users", "users").Tables["users"].Rows.Count.ToString();
            admins.InnerHtml = Helper.RetrieveTable($"SELECT * FROM users WHERE isAdmin='True'", "users").Tables["users"].Rows.Count.ToString();
        }
    }
}