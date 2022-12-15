<%@ Page Title="Cosmos | קוסמוס" Language="C#" MasterPageFile="~/pages/Master.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="Cosmos.pages.index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   <script src="../js/tabs.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <div class="header">
      <div class="header-white">
         <h1><span style="color: var(--accent)!important;">קידום</span> זה</h1>
         <h1>שם המשחק.</h1>
         <p class="header-about">
            אנחנו השילוב בין למידה, פרקטיקה, ניהול זמן<br />
            וקידום אישי בצורה היעילה ביותר.
         </p>
         <a class="gbutton" href="register.aspx" id="headerSignUp" runat="server">להרשמה</a>
         <a class="gbutton" href="#about" style="border-color: var(--accent)!important;">עוד עלינו</a>
      </div>
      <div class="header-black">
         <img src="../assets/header-illustration.svg" />
      </div>
   </div>
   <div class="short-about" >
      <div>
         <a href="https://shorturl.at/cfwB5" target="_blank">
         <img src="../assets/videos.png" /></a>
      </div>
      <div class="about-text" id="about">
         <h2 class="h2-title"><span style="color: var(--accent)!important;">מופשט,</span> אבל לא פשוט.</h2>
         <p>אנחנו אתר קורסים ולימודים אונליין, לתלמידים שאפתנים עם רצון לעשות בחייהם יותר. המטרה שלנו היא להפוך לימודים לנגישים לכולם ולכן כל התכנים באתר הם בחינם לגמרי!</p>
         <a class="gbutton" href="register.aspx" id="aboutSignUp" runat="server">להרשמה</a>
      </div>
   </div>
   <div class="custom-spacing"></div>
   <div class="custom-spacing"></div>
   <div class="custom-spacing"></div>
   <div class="homepage-courses">
      <h3 class="h3-title" style="line-height: 10px;">טעימה קטנה</h3>
      <h2 class="h2-title" style="line-height: 10px; text-align: center;">הקורסים שלנו</h2>
      <div class="separator"></div>
      <br />
      <div class="courses-categories">
         <button type="button" class="cbutton active-cbutton" onclick="openTab(event, 'Math')">מתמטיקה</button>
         <button type="button" class="cbutton" onclick="openTab(event, 'Philosophy')">פילוסופיה</button>
         <button type="button" class="cbutton" onclick="openTab(event, 'Graphic Design')">גרפיקה</button>
         <button type="button" class="cbutton" onclick="openTab(event, 'Finance')">כלכלה</button>
      </div>
      <div class="custom-spacing"></div>
        <div class="course-tabs" id="coursesDiv" runat="server">
      </div>
   </div>
</asp:Content>