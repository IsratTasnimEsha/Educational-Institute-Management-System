<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="student.aspx.cs" Inherits="HMIT.student" %>

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
        
        <style>
        #assigned {
            background: transparent;
            border: none;
            color: white;
            font-family: "Times New Roman";
            font-size: 13px;
        }

        #assigned:hover {
            cursor: pointer;
        }
    </style>
    </head>
    <body>
        <form id="student_form" runat="server">
        <section class="header">
            <nav>
                <a href="home.html"><img src="CSS/Resources/Icons/logo.png"></a>
                <div class="nav-links" id="navLinks">
                    <i class="fa fa-times" onclick="hideMenu()"></i>
                    <ul>
                        <li><a href="home.aspx">HOME</a></li>
                        <li>
                            <asp:Button ID="assigned" runat="server" Text="STUDENT PAGE" OnClick="assigned_Click"></asp:Button>
                        </li>
                        <li><a href="login.aspx">LOGOUT</a></li>
                    </ul>
                </div>
                <i class="fa fa-bars" id="menu" onclick="showMenu()"></i>
            </nav>
            <div class="wrap">
                <div class="wrapper picture" style="height: 500px">
                    <div class="form-box login">
                        <asp:Image ID="Image1" Height="300px" Width="100%" runat="server" />
                        <p>
                            <asp:Label ID="name" runat="server"></asp:Label>
                            <br>
                            <asp:Label ID="id" runat="server"></asp:Label>
                            <br>
                            <asp:Label ID="dept" runat="server"></asp:Label>
                            <br>
                            <asp:Label ID="mail" runat="server"></asp:Label>
                        </p>
                    </div>
                </div>
                <div class="wrapper personal">
                        <div class="form-box login">

                            <h2 style="margin-bottom: 25px;">Personal Informations</h2>

                            <label for="batch">Batch</label>
                            <asp:TextBox ID="batch" runat="server"></asp:TextBox>

                            <label for="phone">Phone</label>
                            <asp:TextBox ID="phone" CssClass="able" runat="server"></asp:TextBox>

                            <label for="fname">Father's Name</label>
                            <asp:TextBox ID="fname" runat="server"></asp:TextBox>

                            <label for="mname">Mother's Name</label>
                            <asp:TextBox ID="mname" runat="server"></asp:TextBox>

                            <label for="ad">Address</label>
                            <asp:TextBox ID="ad" CssClass="able" runat="server"></asp:TextBox>

                            <br />
                            <br />
                        
                            <asp:Button ID="personal" runat="server" Text="Submit" CssClass="submit-button" OnClick="personal_Click"/>
                            <asp:Label ID="error" runat="server" Text="" CssClass="error-msg"></asp:Label>

                        </div>
                    </div>
                <div class="wrapper reset">
                    <div class="form-box login">
                       
                            <h2 style="margin-bottom: 25px;">Reset Password</h2>
    
                            <label for="old">Old Password</label>
                            <asp:TextBox ID="old" CssClass="able" runat="server" TextMode="Password"></asp:TextBox>
    
                            <label for="new">New Password</label>
                            <asp:TextBox ID="neww" CssClass="able" runat="server" TextMode="Password"></asp:TextBox>

                            <label for="confirm">Confirm Password</label>
                            <asp:TextBox ID="confirm" CssClass="able" runat="server" TextMode="Password"></asp:TextBox>
                                
                        <br />
                        <br />
                        
                            <asp:Button ID="submit" runat="server" Text="Submit" CssClass="submit-button" OnClick="reset_Click"/>
                            <asp:Label ID="error2" runat="server" Text="" CssClass="error-msg"></asp:Label>
                    </div>
                </div>
            </div>
        </section>

        <script src="JavaScript/save_info.js"></script>
        <script src="JavaScript/navigation.js"></script>
            </form>
    </body>
</html>
