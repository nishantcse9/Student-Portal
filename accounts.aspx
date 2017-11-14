<%@ Page Title="" Language="C#" MasterPageFile="~/dash.master" AutoEventWireup="true" CodeFile="accounts.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link rel="stylesheet" href="grid.css" type="text/css" media="screen" />
</asp:Content>



<asp:Content ID="Content2" ContentPlaceHolderID="content1" Runat="Server">


     <asp:GridView ID="table1" runat="server" Height="304px" Width="939px"  Class="myGridClass" >
        <Columns>
            
        </Columns>
    </asp:GridView>
    <div class="et">
    <asp:Label ID="label1" Text="BALANCE:" runat="server" class="lbl"></asp:Label>
    <asp:Label ID="label2" Text="" runat="server" CssClass="lbl1" ></asp:Label>
        <br />
        <br />
         <asp:Button ID="button1" runat="server" Text="ADD TRANSACTION" OnClick="button1Clicked" Class="btn1" />
        
        <asp:DropDownList ID="ddl1" Class="ddl" runat="server" Height="28px" Width="198px" Visible="false" >
            <asp:ListItem Value="0">Select</asp:ListItem>
            <asp:ListItem Value="1">CREDIT</asp:ListItem>
            <asp:ListItem Value="2">DEBIT</asp:ListItem>

    </asp:DropDownList>

        <asp:TextBox id=TextBox1 runat="server" placeholder="AMOUNT" Visible="false" Class="tb"></asp:TextBox>
        <asp:Button ID="button2" runat="server" Text="ADD" OnClick="button2Clicked" Class="btn" Visible="false" />

    </div>


</asp:Content>

