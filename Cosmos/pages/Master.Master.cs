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
    public partial class Master : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if ((bool)Session["Login"] == false)
            {
                users.Style.Add("display", "none");
                logout.Style.Add("display", "none");
                pfp.Style.Add("display", "none");
                uStats.Style.Add("display", "none");
                courseEdit.Style.Add("display", "none");
                fCourseEdit.Style.Add("display", "none");
            }
            else
            { 
                string SQLStr = "SELECT * FROM users " + $"WHERE username = '{Session["username"]}' ";
                DataSet ds = Helper.RetrieveTable(SQLStr, "users");
                DataRow dr = ds.Tables["users"].Rows[0];

                pfp.InnerHtml = "<object class='pfp' data='../assets/user-images/" + dr["userID"].ToString() + ".jpg' type='image/jpg'><img class='pfp' id='pfpImage' src='../assets/user-images/user.jpg'/></object>";
                if (Session["Admin"].ToString() == "False")
                {
                    users.Style.Add("display", "none");
                    fUsers.Style.Add("display", "none");
                    uStats.Style.Add("display", "none");
                    fUStats.Style.Add("display", "none");
                    courseEdit.Style.Add("display", "none");
                    fCourseEdit.Style.Add("display", "none");
                }
                login.Style.Add("display", "none");
                signup.Style.Add("display", "none");
                logout.Style.Add("display", "inline-block");
            }
        }
        protected void LogOut(object sender, EventArgs e)
        {
            Session["Login"] = false;
            Session["Admin"] = false;
            Session["userName"] = "Visitor";
            logout.Style.Add("display", "none");
            Response.Redirect("index.aspx");

        }
    }
}