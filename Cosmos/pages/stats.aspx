<%@ Page Title="" Language="C#" MasterPageFile="~/pages/Master.Master" AutoEventWireup="true" CodeBehind="stats.aspx.cs" Inherits="Cosmos.pages.stats" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
            <div class="custom-spacing"></div>
    <div style="text-align: center;">
       <h2>מספר המשתמשים באתר (סה"כ)</h2>
        <div id="overallusers" runat="server" dir="ltr"></div>
    <h2>מספר המנהלים באתר</h2>
        <div id="admins" runat="server" dir="ltr"></div>
    <h2>מספר הכניסות (login) לאתר סה"כ</h2>
        <div id="tableDiv" runat="server" dir="ltr"></div>
       </div>
        <div class="custom-spacing"></div>
       <div class="custom-spacing"></div>
       <div class="custom-spacing"></div>
</asp:Content>
