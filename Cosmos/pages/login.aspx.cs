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
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if((bool)Session["Login"] == true)
            {
                Response.Redirect("index.aspx");
            }    
            if (IsPostBack)
            {
                if (Request.Form["username"] == "" || Request.Form["pwd"] == "")
                {
                    msg.InnerHtml = "Please fill all the forms";
                    return;
                }
                string SQLStr = $"SELECT * FROM users " + $"WHERE username = '{Request.Form["username"]}' AND password = '{Request.Form["pwd"]}'";
                DataSet ds = Helper.RetrieveTable(SQLStr, "users");

                if (ds.Tables["users"].Rows.Count > 0)
                {
                    Session["username"] = Request.Form["username"];
                    Session["Login"] = true;
                    Session["Admin"] = ds.Tables[0].Rows[0]["isAdmin"];
                    Session["userID"] = ds.Tables[0].Rows[0]["userID"];
                    if (Session["Admin"].ToString() == "True")
                        Helper.UpdateActive("admins", "users", 1);
                    else
                        Helper.UpdateActive("users", "admins", 1);
                    Response.Redirect("index.aspx");
                }
                else
                {
                    Session["username"] = "Visitor";
                    Session["userID"] = 0;
                    Session["Login"] = false;
                    msg.InnerHtml = "Unknown username or password";
                }
            }
        }
    }
}