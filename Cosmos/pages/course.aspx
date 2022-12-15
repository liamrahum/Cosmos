<%@ Page Title="Cosmos | קוסמוס" Language="C#" MasterPageFile="~/pages/Master.Master" AutoEventWireup="true" CodeBehind="course.aspx.cs" Inherits="Cosmos.pages.course" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="courseData" runat="server"></div>
    <div class="navigation" runat="server" id="nagivation">
        <asp:Button runat="server" Text="הקודם"  CssClass="navigate" ID="previous" OnClick="prevL" />
        <asp:Button runat="server" Text="הבא"  CssClass="navigate" ID="next" OnClick="nextL" />
    </div>
</asp:Content>
