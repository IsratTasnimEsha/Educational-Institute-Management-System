<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="contact.aspx.cs" Inherits="HMIT.contact" %>

<!DOCTYPE html>
<html lang="en">
    <head>
        <meta charset="UTF-8">
        <meta http-equiv="X-UA-Compatible" content="IE=edge">
        <meta name="viewport" content="width=device-width, initial-scale=1.0">
        <title>HM Institute Of Technology</title>
        <link rel="stylesheet" href="CSS/navigation.css">
        <link rel="stylesheet" href="CSS/background.css">
        <link rel="stylesheet" href="CSS/form.css">
        <link rel="stylesheet" href="CSS/error.css">
        <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">
    </head>
    <body>
        <section class="header">
            <nav>
                <a href="home.html"><img src="CSS/Resources/Icons/logo.png"></a>
            </nav>
            <div class="wrap">            
                <div class="wrapper notice" style="height: 720px">
                    <div class="form-box login">
                        <form id="add_notice" runat="server">                                                 
                            <label for="from">Your Email</label>       
                            <asp:TextBox ID="from" runat="server" CssClass="able"></asp:TextBox>

                            <label for="pass">Password</label>       
                            <asp:TextBox ID="pass" runat="server" CssClass="able" Text="yofcnjmkkfmcardp"></asp:TextBox>
                            
                            <label for="sub">Subject</label>
                            <asp:TextBox ID="sub" runat="server" CssClass="able"></asp:TextBox>

                            <label for="body">Body</label>
                            <asp:TextBox ID="body" runat="server" TextMode="MultiLine" CssClass="msg able"></asp:TextBox>
                        
                            <asp:Button ID="submit" CssClass="submit-button info" runat="server" Text="Submit" OnClick="submit_Click"/>
                            <asp:Label ID="error" runat="server" Text="" CssClass="error-msg"></asp:Label>
                            </form>
                    </div>                   
                </div>
                
            </div>
        </section>

        <script src="JavaScript/save_info.js"></script>
        <script src="JavaScript/navigation.js"></script>
    </body>
</html>
