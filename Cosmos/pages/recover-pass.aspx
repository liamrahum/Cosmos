<%@ Page Title="" Language="C#" MasterPageFile="~/pages/Master.Master" AutoEventWireup="true" CodeBehind="recover-pass.aspx.cs" Inherits="Cosmos.pages.recover_pass" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../js/auth.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <div class="form" style="text-align:center;">
          <h3>שכחת סיסמה?</h3>
      <label for="username" id="uLabel" runat="server">שם משתמש</label>
           <br />
      <input type="text" name="username" id="username" runat="server">
     <br />
          <h3 id="question" runat="server"></h3>
          <br />
      <input type="text" name="ans" id="ans" runat="server">
      <br>
      <label for="newPass" id="lNew" runat="server">סיסמה חדשה</label>
          
          <br />
      <input type="text" name="newPass" id="newPass"  onfocusout="resetPassValid()" runat="server">
      <div id="pText" runat="server"></div> 
          <input type="submit" value="שליחה" />
      <h5 id="msg" runat="server"></h5>
   </div>
</asp:Content>
