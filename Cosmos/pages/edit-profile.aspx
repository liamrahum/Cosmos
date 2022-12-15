<%@ Page Title="עריכת פרופיל | Cosmos" Language="C#" MasterPageFile="~/pages/Master.Master" AutoEventWireup="true" CodeBehind="edit-profile.aspx.cs" Inherits="Cosmos.pages.edit_profile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <div id="userData" runat="server" class="user-data">
        </div>
        <asp:Button Text="שמירה" OnClick="Update_Click" CssClass="cbutton" runat="server"/>
    <asp:Button Text="מחיקת משתמש" OnClick="Delete_Click" CssClass="cbutton" runat="server"/>
</asp:Content>
