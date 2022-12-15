<%@ Page Title="" Language="C#" MasterPageFile="~/pages/Master.Master" AutoEventWireup="true" CodeBehind="about.aspx.cs" Inherits="Cosmos.pages.about" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="short-about" >
      <div>
         <a href="https://shorturl.at/cfwB5" target="_blank">
         <img src="../assets/videos.png" /></a>
      </div>
      <div class="about-text" id="about">
         <h2 class="h2-title"><span style="color: var(--accent)!important;">קצת על</span> Cosmos</h2>
         <p>אנחנו אתר קורסים ולימודים אונליין, לתלמידים שאפתנים עם רצון לעשות בחייהם יותר. המטרה שלנו היא להפוך לימודים לנגישים לכולם ולכן כל התכנים באתר הם בחינם לגמרי!</p>
         <a class="gbutton" href="register.aspx" id="aboutSignUp" runat="server">להרשמה</a>
      </div>
   </div>
    <div class="custom-spacing"></div>
    <div class="custom-spacing"></div>
    <div class="custom-spacing"></div>
</asp:Content>
