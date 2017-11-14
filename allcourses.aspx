<%@ Page Title="" Language="C#" MasterPageFile="~/dash.master" AutoEventWireup="true" CodeFile="allcourses.aspx.cs" Inherits="_Default" %>

<asp:Content id=hc1 ContentPlaceHolderID="head" runat="server">
 <link rel="stylesheet" href="grid.css" type="text/css" media="screen" />
</asp:Content>

<asp:Content id=c1 ContentPlaceHolderID="content1" runat="server">
    <asp:GridView ID="table1" runat="server" Height="304px" Width="939px" AutoGenerateColumns="False" Class="myGridClass">
        <Columns>
            <asp:BoundField DataField="cid" HeaderText="COURSE ID" />
            <asp:BoundField DataField="cname" HeaderText="COURSE" />
            <asp:BoundField DataField="stream" HeaderText="STREAM" />
            
        </Columns>
    
    </asp:GridView>

        

    <div class="et">

        <asp:Button ID="Button1" runat="server" Text="ADD COURSE" OnClick="button1Clicked" CssClass="btn" />
        <asp:TextBox id=TextBox1 runat="server" placeholder="COURSE ID" Visible="false" Class="tb"></asp:TextBox>
        <asp:TextBox id=TextBox2 runat="server" placeholder="COURSE" Visible="false" Class="tb"></asp:TextBox>
        <asp:TextBox id=TextBox3 runat="server" placeholder="STREAM" Visible="false" Class="tb"></asp:TextBox><br />
        <asp:Button id="button2" OnClick="Button2Clicked" runat="server" Text="Add Record" Visible=false class="btn" ></asp:Button>
        <asp:Button id="button3" OnClick="Button3Clicked" runat="server" Text="DONE" Visible=false class="btn"></asp:Button>

    </div>

</asp:Content>


