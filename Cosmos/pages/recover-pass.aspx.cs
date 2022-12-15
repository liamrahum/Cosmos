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
    public partial class recover_pass : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["uID"] == null || Request.QueryString["uID"] == "")
            {
                
                ans.Style.Add("display", "none");
                question.Style.Add("display", "none");
                newPass.Style.Add("display", "none");
                lNew.Style.Add("display", "none");
                if (IsPostBack)
                { 
                    string SQLStr = $"SELECT * FROM users " + $"WHERE username = '{username.Value}'";
                    DataSet ds = Helper.RetrieveTable(SQLStr, "users");
                    if (ds.Tables["users"].Rows.Count > 0)
                    {
                        Response.Redirect("recover-pass.aspx?uID=" + ds.Tables["users"].Rows[0]["userID"].ToString());
                    }
                }
            }
            else
            {
                string SQLStr = $"SELECT * FROM users " + $"WHERE userID = '{Request.QueryString["uID"]}'";
                DataRow dt = Helper.RetrieveTable(SQLStr, "users").Tables["users"].Rows[0];
                question.InnerText = dt["question"].ToString();
                username.Style.Add("display", "none");
                uLabel.Style.Add("display", "none");
                newPass.Style.Add("display", "none");
                lNew.Style.Add("display", "none");
                ans.Style.Remove("display");
                if (IsPostBack)
                {
                    string SQLStr2 = $"SELECT * FROM users " + $"WHERE answer LIKE '{ans.Value}'";
                    if (Helper.RetrieveTable(SQLStr, "users").Tables["users"].Rows.Count > 0)
                    {
                        newPass.Style.Remove("display");
                        lNew.Style.Remove("display");
                        ans.Style.Add("display", "none");
                        if (newPass.Value != "" && newPass.Value != null)
                        {
                            Helper.UpdatePass(Convert.ToInt32(Request.QueryString["uID"]), newPass.Value);
                            pText.InnerHtml = "<h3>הסיסמה השתנתה בהצלחה!</h3>";
                        }
                    }
                }
            }
            
        }
    }
}