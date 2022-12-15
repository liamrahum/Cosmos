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
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((bool)Session["Login"] == true)
            {
                headerSignUp.Style.Add("display", "none");
                aboutSignUp.Style.Add("display", "none");
            }
            if (!IsPostBack)
            {
                string[] courseCategories = { "Math", "Philosophy", "Graphic Design", "Finance" };
                foreach(string category in courseCategories)
                {
                    string SQLStr = $"SELECT * FROM courses " + $"WHERE courseCategory = '{category}'";
                    DataSet ds = Helper.RetrieveTable(SQLStr, "courses");
                    DataTable dt = ds.Tables["courses"];
                    string table = "";
                    foreach (DataRow row in dt.Rows)
                    {
                        table += Helper.BuildCoursesTab(dt, (int)row["courseID"], category);
                    }
                    
                    coursesDiv.InnerHtml += table;
                }
            }
        }
    }
}