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
    public partial class chat : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if((bool)Session["Login"] == false)
            {
                Response.Redirect("index.aspx");
            }
            if(!IsPostBack)
            {
                string SQLStr = "SELECT * FROM chat";
                DataSet ds = Helper.RetrieveTable(SQLStr, "chat");
                DataTable dt = ds.Tables["chat"];
                string table = Helper.BuildChat(dt, (int)Session["userID"]);
                chatData.InnerHtml = table;
                
            }

        }

        protected void sendMsg_Click(object sender, EventArgs e)
        {
            Helper.InsertMessage(msgInput.Value, (int)Session["userID"]);
            string SQLStr = "SELECT * FROM chat";
            DataSet ds = Helper.RetrieveTable(SQLStr, "chat");
            DataTable dt = ds.Tables["chat"];
            string table = Helper.BuildChat(dt, (int)Session["userID"]);
            chatData.InnerHtml = table;
            msgInput.Value = "";
        }
    }
}