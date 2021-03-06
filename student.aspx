﻿<%@ Page Title="" Language="C#" MasterPageFile="~/dash.master" AutoEventWireup="true" CodeFile="student.aspx.cs" Inherits="student" %>



<asp:Content id=hc1 ContentPlaceHolderID="head" runat="server">
     <link rel="stylesheet" href="grid.css" type="text/css" media="screen" />
</asp:Content>




<asp:Content id=c1 ContentPlaceHolderID="content1" runat="server">


    <asp:GridView ID="table1" runat="server" Height="304px" Width="939px" AutoGenerateColumns="False" Class="myGridClass">
        <Columns>
            <asp:BoundField DataField="id" HeaderText="STUDENT ID" />
            <asp:BoundField DataField="name" HeaderText="NAME" />
            <asp:BoundField DataField="dob" HeaderText="D.O.B" DataFormatString="{0:dd-M-yyyy}"/>
            <asp:BoundField DataField="address" HeaderText="ADDRESS" />
        </Columns>
    </asp:GridView>




    <div class="et">
        <asp:Button ID="Button1" runat="server" Text="NEW ADMISSION" OnClick="button1Clicked" CssClass="btn" />
        <asp:TextBox id=TextBox1 runat="server" placeholder="STUDENT ID" Visible="false" CssClass="tb" ></asp:TextBox>
        <asp:TextBox id=TextBox2 runat="server" placeholder="NAME" Visible="false" class="tb"></asp:TextBox>
        <asp:TextBox id=TextBox3 runat="server" placeholder="ADDRESS" Visible="false" class="tb"></asp:TextBox>
        <asp:TextBox id=TextBox4 runat="server" placeholder="DOB" Visible="false" class="tb"></asp:TextBox><br />
        <asp:Button id="button2" OnClick="Button2Clicked" runat="server" Text="Add Record" Visible=false class="btn" ></asp:Button>
        <asp:Button id="button3" OnClick="Button3Clicked" runat="server" Text="DONE" Visible=false class="btn"></asp:Button>

    </div>

</asp:Content>

