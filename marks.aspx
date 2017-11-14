<%@ Page Title="" Language="C#" MasterPageFile="~/dash.master" AutoEventWireup="true" CodeFile="marks.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
     <link rel="stylesheet" href="grid.css" type="text/css" media="screen" />
</asp:Content>



<asp:Content ID="Content2" ContentPlaceHolderID="content1" Runat="Server">
    <asp:DropDownList ID="ddl1" Class="ddl" runat="server" Height="28px" Width="198px" >
        <asp:ListItem Value="">Select Course</asp:ListItem>
    </asp:DropDownList>
    <asp:Button ID="button1" runat="server" Text="SUBMIT" OnClick="button1Clicked" Class="btn" />
    

     <asp:GridView ID="table1" runat="server" Height="304px" Width="939px" AutoGenerateColumns="False" Class="myGridClass" Visible="false">
        <Columns>
            <asp:BoundField DataField="id" HeaderText="STUDENT ID" />
            <asp:BoundField DataField="name" HeaderText="NAME" />
        </Columns>


    
    </asp:GridView>

    <div class="et">
    <asp:Button ID="Button2" runat="server" Text="New Registration" OnClick="Button2Clicked" CssClass="btn" Visible="false"  />

     <asp:DropDownList ID="ddl2" Class="ddl" runat="server" Height="28px" Width="198px" visible="false">
        <asp:ListItem Value="">Select Student</asp:ListItem>
    </asp:DropDownList>
    
     <asp:Button ID="Button3" runat="server" Text="Register"  CssClass="btn" Visible="false" OnClick="Button3Clicked"/>

</div>

</asp:Content>

