<%@ Page Title="כניסה | Cosmos" Language="C#" MasterPageFile="~/pages/Master.Master" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="Cosmos.pages.login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../css/forms.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
       <div class="form" style="text-align:center;">
      <label for="username">שם משתמש</label>
           <br />
      <input type="text" name="username" id="username" onfocusout="UserValid()"required>
      <div id="uText" style="color: red;"></div>
      <br>
      <label for="pwd">סיסמה</label>
           <br />
      <input type="password" name="pwd" id="pwd" onfocusout="passValid()"required>
      <div id="pText" style="color: red; "></div>
      <br>
      <asp:Button ID ="signUpButton" runat="server" Text="כניסה"  CssClass="submit" OnClientClick="return validForm();" />
      <a style="text-decoration: none;" href="recover-pass.aspx">שכחת סיסמה?</a>
           <div id="sText" style="color: red; "></div>
      <h5 id="msg" runat="server"></h5>
   </div>
</asp:Content>
