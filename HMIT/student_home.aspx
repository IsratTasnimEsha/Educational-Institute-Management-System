<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="student_home.aspx.cs" Inherits="HMIT.student_home" %>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>HM Institute Of Technology</title>
    <link rel="stylesheet" href="CSS/background.css">
    <link rel="stylesheet" href="CSS/navigation.css">
    <link rel="stylesheet" href="CSS/admin.css">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">
</head>
<body>
    <form id="admin_add_student_form" runat="server">
        <section class="header">
            <nav>
                <a href="home.html">
                    <img src="CSS/Resources/Icons/logo.png"></a>
                <div class="nav-links" id="navLinks">
                    <i class="fa fa-times" onclick="hideMenu()"></i>
                    <ul>
                        <li><a href="home.aspx">HOME</a></li>
                        <li><a href="login.aspx">LOGOUT</a></li>
                    </ul>
                </div>
                <i class="fa fa-bars" id="menu" onclick="showMenu()"></i>
            </nav>

            <div class="wrap">
                <div class="wrapper picture">
                    <div class="form-box login">
                        <img src="CSS/Resources/Icons/student.png" class="icons">
                        <p>PERSONAL INFORMATIONS</p>
                    </div>
                    <div class="button-area" style="padding: 0px 120px">
                        <asp:Button ID="personal" runat="server" Text="Open" CssClass="submit-button b-view" OnClick="personal_Click" />
                    </div>
                </div>
                <div class="wrapper picture">
                    <div class="form-box login">
                        <img src="CSS/Resources/Icons/registration.png" class="icons">
                        <p>REGISTRATION</p>
                    </div>
                    <div class="button-area" style="padding: 0px 120px">
                        <asp:Button ID="reg" runat="server" Text="Open" CssClass="submit-button b-view" OnClick="registration_Click" />
                    </div>
                </div>
                <div class="wrapper picture">
                    <div class="form-box login">
                        <img src="CSS/Resources/Icons/result.png" class="icons">
                        <p>ACADEMIC RECORDS</p>
                    </div>
                    <div class="button-area" style="padding: 0px 120px">
                        <asp:Button ID="result" runat="server" Text="Open" CssClass="submit-button b-view" OnClick="result_Click" />
                    </div>
                </div>               
            </div>
        </section>
    </form>
    <script src="JavaScript/navigation.js"></script>
</body>
</html>