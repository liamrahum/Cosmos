<%@ Page Title="צ'אט | Cosmos" Language="C#" MasterPageFile="~/pages/Master.Master" AutoEventWireup="true" CodeBehind="chat.aspx.cs" Inherits="Cosmos.pages.chat" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="chat-wrapper">
        <div class="chat-system" >
            <div id="chatData" runat="server"></div>
         <input name="msgInput" id="msgInput" runat="server" class="msgText" type="text" placeholder="כתוב הודעה חדשה" onkeypress="return event.keyCode!=13" required/>
        <asp:Button ID ="sendMsg" CssClass="sendMsg" runat="server" Text="שליחה"  OnClick="sendMsg_Click"/>

        </div>
        <div class="chat-about">
            <h1>ברוכים הבאים לצ'אט של Cosmos!</h1>
            <h3>לפניכם נושאים מעניינים לשיחות-</h3>
            <ul>
                <li>כמה קלמרים צריך כדי שסגול?</li>
                <li>ידעתם שבתנ"ך אין את המילה אגס 249 פעמים?</li>
                <li>השיר החדש של שלמה ארצי</li>
                <li>האם האתר הזה מדהים? (תשובה: כן.)</li>
            </ul>
        </div>
    </div>
</asp:Content>
