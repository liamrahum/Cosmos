<%@ Page Title="הרשמה | Cosmos" Language="C#" MasterPageFile="~/pages/Master.Master" AutoEventWireup="true" CodeBehind="register.aspx.cs" Inherits="Cosmos.pages.register" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   <link href="../css/forms.css" rel="stylesheet" />
    <script src="../js/auth.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <div class="form">
      <label for="firstname">*שם פרטי</label>
      <input type="text" name="firstname" id="firstname" onfocusout="check_name()" required >
      <div id="fText" style="color: red; font-size:14px;"></div>
      <br>
      <label for="lastname">*שם משפחה</label>
      <input type="text" name="lastname" id="lastname" onfocusout="check_Lastname()" required>
            <div id="lText" style="color: red; font-size:14px;"></div>
       <br>
      <label for="username">*שם משתמש</label>
      <input type="text" name="username" id="username" onfocusout="UserValid()" required>
      <div id="uText" style="color: red; font-size:14px;"></div>
      <br>
      <label for="email">*אימייל</label>
      <input type="text" name="email" id="email" onfocusout="check_email()" required>
      <div id="eText" style="color: red; font-size:14px;"></div>
      <br>
      <label for="pwd">*סיסמה</label>
      <input type="password" name="pwd" id="pwd" onfocusout="passValid()"required>
      <div id="pText" style="color: red; font-size:14px;"></div>
      <br>
      <label for="pwd-comf">*אימות סיסמה</label>
      <input type="password" name="pwd-comf" id="pwd-comf" onfocusout="passValid()"required>
      <br>
      <label for="birthdate">*יום הולדת</label>
      <input type="date" name="birthdate" id="birthdate" required/>
      <br />
      <label for="city">עיר</label>
      <input type="text" name="city" id="city" onfocusout="check_city()" />
      <div id="cText" style="color: red; font-size:14px;"></div>
      <br />
      <label>*מגדר</label>
      <input type="radio" name="gender" id="male" value="male" checked />
      <label for="male">זכר</label>
      <input type="radio" name="gender" id="female" value="female" />
      <label for="female">נקבה</label>
      <br>
      <label for="phone">*מספר טלפון</label>
      <input type="tel" id="phone" name="phone" onfocusout="check_phone()" required">
       <div id="phoneText" style="color: red; font-size:14px;"></div>
      <br />
      <label for="recovery" >*מידע לשחזור</label>
      <select name="recovery" id="recovery" required>
         <option value="מה היה שם הנעורים של אמך?">שם הנעורים של אמך</option>
         <option value="שם חיית המחמד הראשונה שלך">שם חיית המחמד הראשונה שלך</option>
         <option value="מה הסדרה האהובה עליך?">שם הסדרה האהובה עליך</option>
      </select>
      <br />
      <label>תשובה</label>
      <input type="text" id="answer" name="answer" required/>
      <br />
       <input type="reset" value="איפוס" />
      <asp:Button ID ="signUpButton" runat="server" Text="הרשמה"  CssClass="submit" OnClientClick="return validForm();" />
      <div id="sText" style="color: red; font-size:14px; "></div>
      <h5 id="msg" runat="server"></h5>
   </div>
</asp:Content>