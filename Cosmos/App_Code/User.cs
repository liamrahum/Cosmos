using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class User
{
    public int userId;
    public string email;
    public string userName;
    public string password;
    public string firstName;
    public string lastName;
    public DateTime birthday;
    public string city;
    public string gender;
    public string phone;
    public string recoveryQuestion;
    public string recoveryAnswer;
    public bool Admin;
    public User()
    {
        userId = -1;
        email = "";
        userName = "";
        password = "";
        firstName = "";
        lastName = "";
        phone = "";
        birthday = DateTime.Today;
        city = "";
        gender = "";
        Admin = false;
        recoveryQuestion = "";
        recoveryAnswer = "";
    }
    public User(int userId, string uName)
    {
        this.userId = userId;
        userName = uName;
    }
}