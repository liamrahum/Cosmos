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
    public partial class course : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((bool)Session["Login"] == false || Request.QueryString["cID"] == null)
            {
                Response.Redirect("login.aspx");
            }
            string SQLStr = "SELECT * FROM courses " + $"WHERE courseID = '{Request.QueryString["cID"]}' ";
            string current = Helper.GetUserCurrentLesson((int)Session["userID"], Request.QueryString["cID"]).ToString();
            bool finishedCourse = Helper.RetrieveTable(SQLStr, "courses").Tables["courses"].Rows[0]["numLessons"].ToString() == current;
            if(finishedCourse)
                next.Style.Add("display", "none");
            else
                next.Style.Remove("display");
            if (current == "1")
                previous.Style.Add("display", "none");
            else
                previous.Style.Remove("display");

            DataSet ds = Helper.RetrieveTable(SQLStr, "courses");
            DataTable dt = ds.Tables["courses"];
            string data = Helper.BuildLessonPage(dt, (int)Session["userID"], Request.QueryString["cID"]);
            courseData.InnerHtml = data;
            if(data == "ERROR")
            {
                Response.Redirect("index.aspx");
            }
        }
        protected void nextL(object sender, EventArgs e)
        {
            Helper.UpdateCurrentLesson((int)Session["userID"], Request.QueryString["cID"], 1);
            Response.Redirect(Request.RawUrl);
        }
        protected void prevL(object sender, EventArgs e)
        {
            Helper.UpdateCurrentLesson((int)Session["userID"], Request.QueryString["cID"], -1);
            Response.Redirect(Request.RawUrl);
        }
    }
}