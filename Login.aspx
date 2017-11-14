<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
  <head runat="server">
        <meta charset="utf-8"/>
        <title>Login Page</title>
        <style>
            
        

        #entry {
                    margin-top: -100px;
                    position: absolute;
                    top: 50%;
                    left: 50%;
                    transform: translate(-50%, -50%);
                    background-color: #505050;
                    border-radius: 10px;
                    width:500px;
                    padding-top:50px;
                    padding-bottom:50px;
            
                }

        #p1     {
                    text-align: center;
                    margin-top:-5px;
                    font-family:sans-serif;
                    padding-bottom:15px;
                    
                }

        
            
        #form1  {
                     text-align: center; 
                }

         #textbox2
                {
                    margin-top: 8px;
                    margin-bottom:15px;
                    background-color: #F0F0F0;
                }
            
        body    {
                    background-color:#F0F0F0;
                }

        input[type=submit] 
                {
                     margin-top: 15px;
                     width: 120px;
                     height:20px;
                     padding:4px;
                     border-radius: 3px;
                     background-color: #F0F0F0;
                     border-style: hidden;
                 }





                
        input[type=submit]:hover 
                {
                      background-color: red;
                }




         input[type=text] 
                {
                      width: 250px;
                      padding: 5px;
                      border-radius: 3px;
                      border-style:hidden;
                      background-color: #F0F0F0;
                }



        input[type=password] 
                {
                      width: 250px;
                      padding: 5px;
                      border-radius: 3px;
                      border-style:hidden;
                 }

        p{

                 color: #F0F0F0; font-family: 'Open Sans Condensed', sans-serif;
                 font-size: 38px; 
                 font-weight: 700; 
                 line-height: 64px; margin: 0 0 0; 

                 text-align: center; 
                 text-transform: uppercase; 

                }
        
            
        </style>
</head>

    
<body>


       

         <div id="entry">
            
            <p id=p1>SECRETARY LOGIN</p>
            
            <form id="form1" runat="server">
                <asp:TextBox ID="textbox1"  runat="server" name="userid" placeholder="USER ID" ></asp:TextBox>
                <br>
                <asp:TextBox ID="textbox2" TextMode="Password" name="pass" runat="server"  placeholder="PASSWORD"></asp:TextBox>
                <br>
                <asp:Button ID="button1" runat="server" Text="SUBMIT" OnClick="button1Clicked" />

                </form>
            </div>
                
</body>
</html>
