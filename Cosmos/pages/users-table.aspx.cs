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
    public partial class users_table : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Admin"].ToString() == "False")
            {
                Response.Redirect("index.aspx");
            }
            string SQLStr = "";
            if (select.Value != "userID" && select.Value != "*")
             SQLStr = $"SELECT {select.Value}, userID FROM users ORDER BY {column.Value} {order.Value}" ;
            else
                SQLStr = $"SELECT {select.Value} FROM users ORDER BY {column.Value} {order.Value}";
            DataSet ds = Helper.RetrieveTable(SQLStr, "users");
            DataTable dt = ds.Tables["users"];
            string table = Helper.BuildUsersTable(dt, Convert.ToInt32(Session["userID"]));
            tableDiv.InnerHtml = table;
        }
    }
}