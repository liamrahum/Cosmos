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
    public partial class register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((bool)Session["Login"] == true)
            {
                Response.Redirect("index.aspx");
            }
            if (IsPostBack)
            {
                if (Request.Form["username"] == "" || Request.Form["pwd"] == "")
                {
                    msg.InnerHtml = "אנא מלא את כל הטופס";
                    return;
                }
                if (Request.Form["pwd"] != Request.Form["pwd-comf"])
                {
                    msg.InnerHtml = "הסיסמאות לא תואמות";
                    return;
                }
                string checkUsers = $"SELECT * FROM users " + $"WHERE username = '{Request.Form["username"]}'";
                DataSet checkUsersDS = Helper.RetrieveTable(checkUsers, "users");
                if (checkUsersDS.Tables["users"].Rows.Count > 0)
                {
                    msg.InnerHtml = "שם המשתמש כבר קיים";
                    return;
                }

                User user = new User();
                user.userName = Request.Form["username"];
                user.firstName = Request.Form["firstname"];
                user.email = Request.Form["email"];
                user.password = Request.Form["pwd"];
                user.lastName = Request.Form["lastname"];
                user.gender = Request.Form["gender"];
                user.phone = Request.Form["phone"];
                user.city = Request.Form["city"];
                user.recoveryQuestion = Request.Form["recovery"];
                user.recoveryAnswer = Request.Form["answer"];
                user.Admin = false;

                    Helper.Insert(user);
                Response.Redirect("login.aspx");

            }
        }

    }
}