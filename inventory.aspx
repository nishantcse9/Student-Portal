<%@ Page Title="" Language="C#" MasterPageFile="~/dash.master" AutoEventWireup="true" CodeFile="inventory.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link rel="stylesheet" href="grid.css" type="text/css" media="screen" />
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="content1" Runat="Server">


     <asp:DropDownList ID="ddl1" Class="ddl" runat="server" Height="28px" Width="198px" >
        <asp:ListItem Value=""> Category</asp:ListItem>
    </asp:DropDownList>
    <asp:Button ID="button1" runat="server" Text="SUBMIT" OnClick="button1Clicked" Class="btn" />
    

     <asp:GridView ID="table1" runat="server" Height="304px" Width="939px"  Class="myGridClass" Visible="false">
        <Columns>
            
        </Columns>
    </asp:GridView>

     <div class="et">

     <asp:Button ID="Button2" runat="server" Text="ADD INVENTORY" OnClick="button2Clicked" CssClass="btn" />
        <asp:TextBox id=TextBox1 runat="server" placeholder="PRODUCT ID" Visible="false" Class="tb"></asp:TextBox>
        <asp:TextBox id=TextBox2 runat="server" placeholder="ITEM" Visible="false" Class="tb"></asp:TextBox>
        <asp:TextBox id=TextBox3 runat="server" placeholder="QUANTITY" Visible="false" Class="tb"></asp:TextBox><br />
        <asp:Button id="button3" OnClick="Button3Clicked" runat="server" Text="ADD ITEM " Visible=false class="btn" ></asp:Button>
        <asp:Button id="button4" OnClick="Button4Clicked" runat="server" Text="DONE" Visible=false class="btn"></asp:Button>
         </div>

</asp:Content>

