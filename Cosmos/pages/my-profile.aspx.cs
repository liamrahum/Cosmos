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
    public partial class my_profile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((bool)Session["Login"] == false)
            {
                Response.Redirect("login.aspx");
            }
            else if (Request.QueryString["uID"] == null || Request.QueryString["uID"] == "")
            {
                Response.Redirect("my-profile.aspx?uID=" + Session["userID"]);
            }
            else if (Request.QueryString["uID"] != Session["userID"].ToString() && Session["Admin"].ToString() == "False")
            {
                Response.Redirect("my-profile.aspx?uID=" + Session["userID"]);
            }
            if (!IsPostBack)
            {
                string SQLStr = "SELECT * FROM users " + $"WHERE userID = '{Request.QueryString["uID"]}' " ;
                DataSet ds = Helper.RetrieveTable(SQLStr, "users");
                DataRow dr = ds.Tables["users"].Rows[0];
                string data = Helper.BuildUserProfile(dr, Request.QueryString["uID"]);
                userData.InnerHtml = data;
            }
        }
    }
}