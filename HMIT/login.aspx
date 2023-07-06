<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="HMIT.login" %>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>HM Institute Of Technology</title>
    <link rel="stylesheet" href="CSS/background.css">
    <link rel="stylesheet" href="CSS/navigation.css">
    <link rel="stylesheet" href="CSS/login.css">
    <link rel="stylesheet" href="CSS/error.css">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">
</head>

<body>
    <section class="header">
        <nav>
            <a href="home.html">
                <img src="CSS/Resources/Icons/logo.png"></a>
            <div class="nav-links" id="navLinks">
                <i class="fa fa-times" onclick="hideMenu()"></i>
                <ul>
                    <li><a href="home.aspx">HOME</a></li>
                    <li><a href="about.aspx" target="_blank">ABOUT</a></li>
                </ul>
            </div>
            <i class="fa fa-bars" id="menu" onclick="showMenu()"></i>
        </nav>
        <div class="wrapper">
            <div class="form-box login">
                <h2>Login</h2>
                <form id="login_form" runat="server">
                    <div class="input-box">
                        <span class="icon">
                            <ion-icon name="mail"></ion-icon>
                        </span>
                        <asp:TextBox ID="mail" CssClass="able" runat="server"></asp:TextBox>
                        <label>Email</label>
                    </div>
                    <div class="input-box">
                        <span class="icon">
                            <ion-icon name="lock-closed"></ion-icon>
                        </span>
                        <asp:TextBox ID="pass" CssClass="able" runat="server" TextMode="Password"></asp:TextBox>
                        <label>Password</label>
                    </div>
                    <asp:Button ID="submit" runat="server" Text="Submit" CssClass="submit-button" OnClick="submit_Click" />
                    <asp:Label ID="error" runat="server" Text="" CssClass="error-msg"></asp:Label>
                </form>
            </div>
        </div>
    </section>

    <script src="JavaScript/navigation.js"></script>

    <script type="module"
        src="https://unpkg.com/ionicons@5.5.2/dist/ionicons/ionicons.esm.js"></script>
    <script nomodule
        src="https://unpkg.com/ionicons@5.5.2/dist/ionicons/ionicons.js"></script>
</body>
</html>
