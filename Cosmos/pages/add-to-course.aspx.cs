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
    public partial class add_to_course : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Admin"].ToString() == "False")
            {
                Response.Redirect("index.aspx");
            }
            if (IsPostBack)
            {
                Helper.AddToCourse(Convert.ToInt32(Request.Form["cID"]), Request.Form["lName"], Request.Form["lLink"], Request.Form["lLength"], Request.Form["lDescription"]);
                Response.Redirect("course.aspx?cID=" + Request.Form["cID"]);
            }
            string SQLStr = "SELECT * FROM courses";
            DataTable dt = Helper.RetrieveTable(SQLStr, "courses").Tables["courses"];
            string data = Helper.CourseEditPage(dt);
            editCourse.InnerHtml = data;

        }
    }
}