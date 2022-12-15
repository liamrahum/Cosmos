<%@ Page Title="משתמשים | Cosmos" Language="C#" MasterPageFile="~/pages/Master.Master" AutoEventWireup="true" CodeBehind="users-table.aspx.cs" Inherits="Cosmos.pages.users_table" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="custom-spacing"></div>
    <div style="display: block; margin: 0 auto;">
        <label for="select">סינון</label>
    <select id="select" name="select" runat="server">
        <option value="*">All</option>
        <option value="userID">ID</option>
        <option value="username">Username</option>
        <option value="isAdmin">Admins</option>
        <option value="firstName">First name</option>
        <option value="lastName">Last name</option>
        <option value="gender">Gender</option>
        <option value="birthday">Birthday</option>
        <option value="phone">Phone</option>
    </select>
        <label for="column">מיון</label>
        <select id="column" name="column" runat="server">
        <option value="userID">ID</option>
        <option value="username">Username</option>
        <option value="isAdmin">Admins</option>
        <option value="firstName">First name</option>
        <option value="lastName">Last name</option>
        <option value="gender">Gender</option>
        <option value="birthday">Birthday</option>
        <option value="phone">Phone</option>
    </select>
        <label for="order">סדר</label>
    <select id="order" name="order" runat="server">
        <option value="ASC">Ascending</option>
        <option value="DESC">Descending</option>
    </select>
    <input type="submit" value="מיון וסינון"/>
        </div>
    <div id="tableDiv" runat="server" dir="ltr"></div>
       <div class="custom-spacing"></div>
       <div class="custom-spacing"></div>
       <div class="custom-spacing"></div>
</asp:Content>
