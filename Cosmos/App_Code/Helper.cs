using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

public static class Helper
{
    public const string DBName = "Database.mdf";   //Name of the MSSQL Database.
    public const string tblName = "users";      // Name of the user Table in the Database
    public const string conString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\"
                                    + DBName + ";Integrated Security=True";   // The Data Base is in the App_Data = |DataDirectory|


    public static DataSet RetrieveTable(string SQLStr, string tableName)
    // Gets A table from the data base acording to the SELECT Command in SQLStr;
    // Returns DataSet with the Table.
    {
        // connect to DataBase
        SqlConnection con = new SqlConnection(conString);

        // Build SQL Query
        SqlCommand cmd = new SqlCommand(SQLStr, con);

        // Build DataAdapter
        SqlDataAdapter ad = new SqlDataAdapter(cmd);

        // Build DataSet to store the data
        DataSet ds = new DataSet();

        // Get Data form DataBase into the DataSet
        ad.Fill(ds, tableName);

        return ds;
    }

    public static object GetScalar(string SQL)
    {
        // התחברות למסד הנתונים
        SqlConnection con = new SqlConnection(conString);

        // בניית פקודת SQL
        SqlCommand cmd = new SqlCommand(SQL, con);

        // ביצוע השאילתא
        con.Open();
        object scalar = cmd.ExecuteScalar();
        con.Close();

        return scalar;
    }

    public static int ExecuteNonQuery(string SQL)
    {
        // התחברות למסד הנתונים
        SqlConnection con = new SqlConnection(conString);

        // בניית פקודת SQL
        SqlCommand cmd = new SqlCommand(SQL, con);

        // ביצוע השאילתא
        con.Open();
        int n = cmd.ExecuteNonQuery();
        con.Close();

        // return the number of rows affected
        return n;
    }

    public static void Delete(int userIDToDelete)
    // The Array "userIDToDelete" contain the id of the users to delete. 
    // Delets all the users in the array "userIDToDelete".
    {
        // התחברות למסד הנתונים
        SqlConnection con = new SqlConnection(conString);

        // טעינת הנתונים
        string SQL = $"SELECT * FROM {tblName} WHERE userID='{userIDToDelete}'";
        SqlCommand cmd = new SqlCommand(SQL, con);
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        adapter.Fill(ds, tblName);

        DataRow dr = ds.Tables[tblName].Rows[0];
        dr.Delete();
        // עדכון הדאטה סט בבסיס הנתונים
        SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
        adapter.UpdateCommand = builder.GetDeleteCommand();
        adapter.Update(ds, tblName);
        
    }

    public static void Update(User user)
    // The Method recieve a user objects. Find the user in the DataBase acording to his userID and update all the other properties in DB.
    {
        // HttpRequest Request
        // התחברות למסד הנתונים
        SqlConnection con = new SqlConnection(conString);

        // בניית פקודת SQL
        string SQLStr = "SELECT * FROM " + Helper.tblName + $" Where userID={user.userId}";
        SqlCommand cmd = new SqlCommand(SQLStr, con);

        //  טעינת הנתונים לתוך DataSet
        DataSet ds = new DataSet();
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        adapter.Fill(ds, tblName);

        // בניית השורה להוספה
        DataRow dr = ds.Tables[tblName].Rows[0];
        dr["firstName"] = user.firstName;
        dr["lastName"] = user.lastName;
        dr["username"] = user.userName;
        dr["password"] = user.password;
        dr["birthday"] = user.birthday;
        dr["city"] = user.city;

        // עדכון הדאטה סט בבסיס הנתונים
        SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
        adapter.UpdateCommand = builder.GetUpdateCommand();
        adapter.Update(ds, tblName);

    }
    public static void UpdateUser(int uID, string fName, string lName, string aboutMe)
    // The Method recieve a user objects. Find the user in the DataBase acording to his userID and update all the other properties in DB.
    {
        // HttpRequest Request
        // התחברות למסד הנתונים
        SqlConnection con = new SqlConnection(conString);

        // בניית פקודת SQL
        string SQLStr = "SELECT * FROM " + Helper.tblName + $" Where userID={uID}";
        SqlCommand cmd = new SqlCommand(SQLStr, con);

        //  טעינת הנתונים לתוך DataSet
        DataSet ds = new DataSet();
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        adapter.Fill(ds, tblName);

        // בניית השורה להוספה
        DataRow dr = ds.Tables[tblName].Rows[0];
        dr["firstName"] = fName;
        dr["lastName"] = lName;
        dr["aboutMe"] = aboutMe;

        // עדכון הדאטה סט בבסיס הנתונים
        SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
        adapter.UpdateCommand = builder.GetUpdateCommand();
        adapter.Update(ds, tblName);

    }
    public static void UpdateActive(string updating,string column2, int amount)
    // The Method recieve a user objects. Find the user in the DataBase acording to his userID and update all the other properties in DB.
    {
        // HttpRequest Request
        // התחברות למסד הנתונים
        SqlConnection con = new SqlConnection(conString);

        // בניית פקודת SQL
        string SQLStr = $"SELECT * FROM currentUsers";
        SqlCommand cmd = new SqlCommand(SQLStr, con);

        //  טעינת הנתונים לתוך DataSet
        DataSet ds = new DataSet();
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        adapter.Fill(ds, "currentUsers");

        // בניית השורה להוספה
        DataRow dr = ds.Tables["currentUsers"].Rows[0];
        dr[updating] = Convert.ToInt32(dr[updating]) + amount;
        dr["overall"] = Convert.ToInt32(dr[updating]) + Convert.ToInt32(dr[column2]);
        // עדכון הדאטה סט בבסיס הנתונים
        SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
        adapter.UpdateCommand = builder.GetUpdateCommand();
        adapter.Update(ds, "currentUsers");

    }
    public static void UpdatePass(int uID, string pass)
    {
        // HttpRequest Request
        // התחברות למסד הנתונים
        SqlConnection con = new SqlConnection(conString);

        // בניית פקודת SQL
        string SQLStr = "SELECT * FROM " + Helper.tblName + $" Where userID={uID}";
        SqlCommand cmd = new SqlCommand(SQLStr, con);

        //  טעינת הנתונים לתוך DataSet
        DataSet ds = new DataSet();
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        adapter.Fill(ds, tblName);

        // בניית השורה להוספה
        DataRow dr = ds.Tables[tblName].Rows[0];
        dr["password"] = pass;

        SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
        adapter.UpdateCommand = builder.GetUpdateCommand();
        adapter.Update(ds, tblName);
    }
    public static void Insert(User user)
    // The Method recieve a user objects and insert it to the Database as new row. 
    // The Method does't check if the user is already taken.
    {
        //HttpRequest Request
        // התחברות למסד הנתונים
        SqlConnection con = new SqlConnection(conString);

        // בניית פקודת SQL
        string SQLStr = $"SELECT * FROM " + tblName + " WHERE 0=1";
        SqlCommand cmd = new SqlCommand(SQLStr, con);

        // בניית DataSet
        DataSet ds = new DataSet();

        // טעינת סכימת הנתונים
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        adapter.Fill(ds, tblName);

        // בניית השורה להוספה
        DataRow dr = ds.Tables[tblName].NewRow();
        dr["firstName"] = user.firstName;
        dr["lastName"] = user.lastName;
        dr["email"] = user.email;
        dr["username"] = user.userName;
        dr["password"] = user.password;
        dr["birthday"] = user.birthday;
        dr["city"] = user.city;
        dr["phone"] = user.phone;
        dr["gender"] = user.gender;
        dr["question"] = user.recoveryQuestion;
        dr["answer"] = user.recoveryAnswer;
        dr["isAdmin"] = user.Admin;
        ds.Tables[tblName].Rows.Add(dr);

        // עדכון הדאטה סט בבסיס הנתונים
        SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
        adapter.UpdateCommand = builder.GetInsertCommand();
        adapter.Update(ds, tblName);
    }

    public static User GetRow(string username, string password)
    // The Method check if there is a user with username and Password. 
    // If true the Method return a user with the first Name and Admin property.
    // If not the Method return a user wuth first name "Visitor" and Admin = false

    {
        // התחברות למסד הנתונים
        SqlConnection con = new SqlConnection(conString);

        // בניית פקודת SQL
        string SQL = $"SELECT firstName, isAdmin FROM " + tblName +
                $" WHERE username='{username}' AND password = '{password}'";
        SqlCommand cmd = new SqlCommand(SQL, con);

        // ביצוע השאילתא
        con.Open();
        SqlDataReader reader = cmd.ExecuteReader();

        // שימוש בנתונים שהתקבלו
        User user = new User();
        if (reader.HasRows)
        {
            reader.Read();
            user.userName = reader.GetString(0);
            user.Admin = reader.GetBoolean(1);
        }
        else
        {
            user.userName = "Visitor";
            user.Admin = false;
        }
        reader.Close();
        con.Close();
        return user;
    }
    public static string BuildUsersTable(DataTable dt, int uID)
    // the Method Build HTML user Table with checkBoxes using the users in the DataTable dt.
    {

        string str = "<table class='usersTable' align='center'>";
        str += "<tr>";
        str += "<td> </td>";
        foreach (DataColumn column in dt.Columns)
        {
            str += "<td>" + column.ColumnName + "</td>";
        }

        foreach (DataRow row in dt.Rows)
        {
            str += "<tr>";
            str += "<td>" + "<a href='my-profile.aspx?uID=" + row["userID"] + "'>profile</a></td>";
            foreach (DataColumn column in dt.Columns)
            {
                str += "<td>" + row[column] + "</td>";
            }
            str += "</tr>";
        }
        str += "</tr>";
        str += "</Table>";
        return str;
    }
    public static string BuildStats(DataTable dt)
    // the Method Build HTML user Table with checkBoxes using the users in the DataTable dt.
    {

        string str = "<table class='usersTable' align='center'>";
        str += "<tr>";
        str += "<td> </td>";
        foreach (DataColumn column in dt.Columns)
        {
            str += "<td>" + column.ColumnName + "</td><td></td>";
        }

        foreach (DataRow row in dt.Rows)
        {
            str += "<tr>";
            foreach (DataColumn column in dt.Columns)
            {
                str += "<td>" + row[column] + "</td>";
                str += "<td></td>";
            }
            str += "</tr>";
        }
        str += "</tr>";
        str += "</Table>";
        return str;
    }

    public static string CreateRadioBtn(string id)
    {
        return $"<input type='checkbox' name='chk{id}' id='chk{id}' runat='server' />";
    }

    public static DataTable SortTable(DataTable dt, string column, string dir)
    {
        dt.DefaultView.Sort = column + " " + dir;
        return dt.DefaultView.ToTable();
    }

    public static DataTable FilterTable(DataTable dt, string column, string criteria)
    {
        dt.DefaultView.RowFilter = column + "=" + criteria;
        return dt.DefaultView.ToTable();
    }
    public static string GetCourseLessons(int cID) {
        string SQLStr = $"SELECT * FROM lessons " + $"WHERE courseID = '" + cID.ToString() + "'";
        DataSet ds = Helper.RetrieveTable(SQLStr, "lessons");
        DataTable dt = ds.Tables["lessons"];
        string str = "";
        int amount = dt.Rows.Count;
        DataRow row;
        if (amount > 3)
        {
            amount = 3;
        }
        for (int i = 0; i < amount; i++)
        {
            row = dt.Rows[i];
            str += "<div class='lesson'><img src='../assets/play-icon.svg' style='width: 40px; height:40px;' />";
            str += "<h2>" + row["lessonTitle"] + "</h2>";
            str += "<h3>" + row["lessonLength"] + " דקות </h3>";
            str += "</div><div class='lSeparator'></div>";
        }
        return str;
    }
    public static string BuildCoursesTab(DataTable dt, int cID, string category)
    {

        string str = "<div class='course-tab' id='" + category + "'>";
        foreach (DataRow row in dt.Rows)
        {
            str += "<div class='course'>";
            str += "<div style='width: 50%;' dir='ltr'><div class='course-image-bg'>";
            str += "<object data='../assets/course-images/" + row["courseID"] + ".jpg' type='image/jpg'><img src='../assets/course-images/course.jpg' /></object></div></div>";
            str += "<div style='width:40px;'></div><div style='width:45%;'><h1>" + row["courseTitle"] + "</h1>";
            str += "<p>" + row["courseDescription"] + "</p> <br />";
            str += "<div class='lessons'>" + GetCourseLessons(cID) + "</div>";
            str += "<br />";
            str += "<a class='gbutton' style='background-color:var(--extra);padding:6px 50px!important; font-size: 16px;' href='course.aspx?cID=" + cID.ToString() +"'>לקורס המלא</a>";
            str += "</div>";
            str += "</div>";
            str += "<div class='custom-spacing'></div>";
        }
        str += "</div>";


        return str;
    }
    public static string GetUserProgress(int uID)
    {
        string SQLStr = $"SELECT * FROM userProgress " + $"WHERE userID = '" + uID.ToString() + "'";
        DataRow cName;

        DataSet ds = Helper.RetrieveTable(SQLStr, "userProgress");
        DataTable dt = ds.Tables["userProgress"];
        string str = "";
        string cString = "";
        double progress = 0;
        foreach (DataRow row in dt.Rows)
        {
            cString = $"SELECT * FROM courses " + $"WHERE courseID = '" + row["courseID"] + "'";
            cName = Helper.RetrieveTable(cString, "courses").Tables["courses"].Rows[0];
            str += "<h3>" + cName["courseTitle"] + "</h3>";
            progress = (Convert.ToDouble(row["progress"]) / Convert.ToDouble(cName["numLessons"]) * 100);
            if (progress >= 100)
            {
                str += "<div class='progress-bar completed-bar' dir='ltr'><div style='width:100%;'></div></div>";
            }
            else
            {
                str += "<div class='progress-bar' dir='ltr'><div style='width:" + progress.ToString() + "%;'></div></div>";
            }

        }
        return str;
    }
    public static string BuildUserProfile(DataRow row, string uID)
    {
        string progress = GetUserProgress((int)row["userID"]);
        string str = "<div class='side-data'><object data='../assets/user-images/" + row["userID"] + ".jpg'><img id='pfpimg' src='../assets/user-images/user.jpg' /></object>";
        str += "<h2>" + row["firstName"] + " " + row["lastName"] + "</h2>";
        str += "<h3>קצת עליי</h3>";
        str += "<p>" + row["aboutMe"] + "</p><br />";
        str += "<a class='gbutton' style='cursor: pointer;' href='edit-profile.aspx?uID=" + uID + "'>עריכה</a>";
        str += "<div class='custom-spacing'></div></div>";
        str += "<div class='my-progress'>";
        str += "<h1>ההתקדמות שלי</h1>";
        str += progress == "" ? "<h3>נראה שאתה לא רשום לקורסים...</h3>" : progress;
        str += "</div>";
        return str;
    }
    public static string EditUserProfile(DataRow row)
    {
        string str = "<div class='edit-profile'><br>";
        str += "<h3>שם פרטי</h3><input name='firstName' type='text' value='" + row["firstName"] + "'>" + "<h3>שם משפחה</h3><input type='text' name='lastName' value='" + row["lastName"] + "'>";
        str += "<h3>קצת עליי</h3>";
        str += "<textarea name='aboutMe' id='aboutMe' rows='4' cols='40'>" + row["aboutMe"] + "</textarea><br>";

        str += "<div class='custom-spacing'></div></div>";
        str += "<div class='my-progress'>";
        str += "</div>";
        return str;
    }
    public static string CourseEditPage(DataTable dt)
    {
        string str = "<div style='display: block; margin: 0 auto;'><h3>בחר קורס</h3><select name='cID'>";
        foreach (DataRow row in dt.Rows)
        {
            str += $"<option value='{row["courseID"]}'>{row["courseTitle"]}</option>";
        }
        str += "</select>";
        str += "<h3>שם השיעור</h3>";
        str += "<input type='text' name='lName' />";
        str += "<h3>אורך השיעור</h3>";
        str += "<input type='text' name='lLength' />";
        str += "<h3>קישור לשיעור (watch?v=INPUTLINK)</h3>";
        str += "<input type='text' name='lLink' />";
        str += "<h3>תיאור השיעור</h3>";
        str += "<textarea name='lDescription' id='description' rows='4' cols='40'></textarea><br>";
        str += "<input type='submit' value='שמירה' class='cbutton'>";
        str += "<div class='custom-spacing'></div></div>";
        str += "</div>";
        return str;
    }
    public static void AddToCourse(int cID, string lName, string lLink, string lLength,string lDescription)
    // The Method recieve a user objects. Find the user in the DataBase acording to his userID and update all the other properties in DB.
    {
        string cSQL = "SELECT * FROM lessons " + $"WHERE courseID={cID}";
        int lNum = Helper.RetrieveTable(cSQL, "lessons").Tables["lessons"].Rows.Count;
        // HttpRequest Request
        // התחברות למסד הנתונים
        SqlConnection con = new SqlConnection(conString);

        // בניית פקודת SQL
        string SQLStr = "SELECT * FROM lessons";
        SqlCommand cmd = new SqlCommand(SQLStr, con);

        //  טעינת הנתונים לתוך DataSet
        DataSet ds = new DataSet();
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        adapter.Fill(ds, "lessons");

        // בניית השורה להוספה
        DataRow dr = ds.Tables["lessons"].NewRow();
        dr["courseID"] = cID;
        dr["lessonTitle"] = lName;
        dr["lessonDescription"] = lDescription;
        dr["lessonVideo"] = lLink;
        dr["lessonLength"] = lLength;
        dr["lessonNumber"] = lNum + 1;
        ds.Tables["lessons"].Rows.Add(dr);

        // עדכון הדאטה סט בבסיס הנתונים
        SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
        adapter.UpdateCommand = builder.GetUpdateCommand();
        adapter.Update(ds, "lessons");
        UpdateCourseLessonsNum(cID, lNum + 1);

    }
    public static void UpdateCourseLessonsNum(int cID, int num)
    // The Method recieve a user objects. Find the user in the DataBase acording to his userID and update all the other properties in DB.
    {
        // HttpRequest Request
        // התחברות למסד הנתונים
        SqlConnection con = new SqlConnection(conString);

        // בניית פקודת SQL
        string SQLStr = "SELECT * FROM courses " + $"WHERE courseID={cID}"; ;
        SqlCommand cmd = new SqlCommand(SQLStr, con);

        //  טעינת הנתונים לתוך DataSet
        DataSet ds = new DataSet();
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        adapter.Fill(ds, "courses");

        // בניית השורה להוספה
        DataRow dr = ds.Tables["courses"].Rows[0];
        dr["numLessons"] = num;
        // עדכון הדאטה סט בבסיס הנתונים
        SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
        adapter.UpdateCommand = builder.GetUpdateCommand();
        adapter.Update(ds, "courses");

    }
    public static string BuildChat(DataTable dt, int sID)
    {
        string str = "";
        foreach (DataRow row in dt.Rows)
        {
            if (row["senderID"].ToString() == sID.ToString())
            {
                str += "<div class='user-message'>";
            }
            else
            {
                str += "<div class='message'>";
            }
            str += "<object class='pfp' data='../assets/user-images/" + row["senderID"] + ".jpg' type='image/jpg'><img class='pfp' src='../assets/user-images/user.jpg' /></object>";
            str += "<p>" + row["messageText"] + "</p>";
            str += "</div>";

        }
        return str;
    }

    public static string GetProgressData(int uID, string cID)
    {
        string SQLStr = $"SELECT * FROM userProgress " + $"WHERE userID = '" + uID.ToString() + "' AND courseID = '" + cID + "'";
        DataRow cName;
        DataSet ds = Helper.RetrieveTable(SQLStr, "userProgress");
        DataRow dr = ds.Tables["userProgress"].Rows[0];
        string str = "";
        string cString = "";
        double progress = 0;
        cString = $"SELECT * FROM courses " + $"WHERE courseID = '" + dr["courseID"] + "'";
        cName = Helper.RetrieveTable(cString, "courses").Tables["courses"].Rows[0];
        progress = (Convert.ToDouble(dr["progress"]) / Convert.ToDouble(cName["numLessons"]) * 100);
        if (progress >= 100)
        {
            str += "<div class='progress-bar completed-bar' dir='ltr'><div style='width:100%;'></div></div>";
        }
        else
        {
            str += "<div class='progress-bar' dir='ltr'><div style='width:" + progress.ToString() + "%;'></div></div>";
        }
        return str;
    }
    public static int InsertProgress(int uID, string cID)
    {
        SqlConnection con = new SqlConnection(conString);
        string SQLStr = $"SELECT * FROM userProgress WHERE 0=1";
        SqlCommand cmd = new SqlCommand(SQLStr, con);

        // בניית DataSet
        DataSet ds = new DataSet();

        // טעינת סכימת הנתונים
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        adapter.Fill(ds, "userProgress");

        // בניית השורה להוספה
        DataRow dr = ds.Tables["userProgress"].NewRow();
        dr["userID"] = uID;
        dr["courseID"] = int.Parse(cID);
        dr["progress"] = 1;
        ds.Tables["userProgress"].Rows.Add(dr);

        // עדכון הדאטה סט בבסיס הנתונים
        SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
        adapter.UpdateCommand = builder.GetInsertCommand();
        adapter.Update(ds, "userProgress");
        return 1;
    }

    public static int GetUserCurrentLesson(int uID, string cID)
    {
        string SQLStr = $"SELECT * FROM userProgress " + $"WHERE userID = '" + uID.ToString() + "' AND courseID = '" + cID + "'";
        DataTable dr = Helper.RetrieveTable(SQLStr, "userProgress").Tables["userProgress"];
        if (dr.Rows.Count == 0)
        {
            return InsertProgress(uID, cID);
        }
        else
        {
            return (int)dr.Rows[0]["progress"];
        }
    }
    public static void UpdateCurrentLesson(int uID, string cID, int update)
    {
        // HttpRequest Request
        // התחברות למסד הנתונים
        SqlConnection con = new SqlConnection(conString);

        // בניית פקודת SQL
        string SQLStr = "SELECT * FROM " + "userProgress" + $" WHERE userID={uID} AND courseID = {cID}";
        SqlCommand cmd = new SqlCommand(SQLStr, con);

        //  טעינת הנתונים לתוך DataSet
        DataSet ds = new DataSet();
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        adapter.Fill(ds, "userProgress");
        // בניית השורה להוספה
        DataRow dr = ds.Tables["userProgress"].Rows[0];
        if ((int)dr["progress"] == 1 && update == -1)
            return;
        else
            dr["progress"] = (int)dr["progress"] + update;

        // עדכון הדאטה סט בבסיס הנתונים
        SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
        adapter.UpdateCommand = builder.GetUpdateCommand();
        adapter.Update(ds, "userProgress");

    }
    public static string BuildLessonPage(DataTable dt, int uID, string cID)
    {
        string str = "";
        DataTable datatable;
        DataRow currentLesson;

        string lString = $"SELECT * FROM lessons " + $"WHERE courseID = '" + cID +"' AND lessonNumber = '" + GetUserCurrentLesson(uID, cID).ToString()+"'";
        datatable = Helper.RetrieveTable(lString, "lessons").Tables["lessons"];
        if(datatable.Rows.Count == 0)
        {
            return "ERROR";
        }
        else
        {
            currentLesson = datatable.Rows[0];
        }
        str += "<h2 class='lesson-title'>שיעור " + currentLesson["lessonNumber"].ToString() + " - " + currentLesson["lessonTitle"] +"</h2>";
        str += "<iframe class='lesson-video' width='560' height='315'  src= 'https://youtube.com/embed/" + currentLesson["lessonVideo"] + "' ";
        str += "frameborder='0' allow='accelerometer; clipboard-write; encrypted-media; gyroscope; picture-in-picture' allowfullscreen>";
        str += "</iframe>";
        str += $"<p class='lesson-description'>{currentLesson["lessonDescription"]}</p>";
        str += "<h3 style='text-align: center;'>ההתקדמות שלי</p>";
        str += GetProgressData(uID, cID);
        str += "<div class='custom-spacing'></div>";
        return str;
    }
    public static void InsertMessage(string text, int sID)
    {
        SqlConnection con = new SqlConnection(conString);

        // בניית פקודת SQL
        string SQLStr = $"SELECT * FROM chat WHERE 0=1";
        SqlCommand cmd = new SqlCommand(SQLStr, con);
        
        // בניית DataSet
        DataSet ds = new DataSet();

        // טעינת סכימת הנתונים
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        adapter.Fill(ds, "chat");

        // בניית השורה להוספה
        DataRow dr = ds.Tables["chat"].NewRow();
        dr["messageText"] = text;
        dr["senderID"] = sID;
        ds.Tables["chat"].Rows.Add(dr);
        // עדכון הדאטה סט בבסיס הנתונים
        SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
        adapter.UpdateCommand = builder.GetInsertCommand();
        adapter.Update(ds, "chat");
    }


}