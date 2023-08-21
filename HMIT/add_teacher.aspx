<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="add_teacher.aspx.cs" Inherits="HMIT.add_teacher" %>

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
    <link rel="stylesheet"
        href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">
    <style>
        .custom-calendar {
            font-family: Arial, sans-serif;
            border-collapse: collapse;
            color: white;
            background-color: #fff5;
            width: 100%;
        }

            .custom-calendar th {
                background: #415C39;
                text-align: center;
                padding: 5px;
                font-weight: normal;
                font-size: small;
            }

            .custom-calendar td {
                text-align: center;
                padding: 5px;
                font-size: small;
            }

                .custom-calendar td a {
                    text-decoration: none;
                }
    </style>

</head>
<body>
    <form id="add_teacher_form" runat="server">
        <section class="header">
            <nav>
                <a href="home.html">
                    <img src="CSS/Resources/Icons/logo.png"></a>
                <div class="nav-links" id="navLinks">
                    <i class="fa fa-times" onclick="hideMenu()"></i>
                    <ul>
                        <li><a href="home.aspx">HOME</a></li>
                        <li><a href="admin.aspx">ADMIN PAGE</a></li>
                        <li><a href="view_teacher.aspx">VIEW TEACHER RECORDS</a></li>
                        <li><a href="login.aspx">LOGOUT</a></li>
                    </ul>
                </div>
                <i class="fa fa-bars" id="menu" onclick="showMenu()"></i>
            </nav>
            <div class="wrap">
                <div class="wrapper add" style="height: 60px">
                    <div class="form-box login" style="display: flex; align-items: baseline">
                        <asp:FileUpload ID="FileUpload1" runat="server" />
                        <asp:Button ID="btnUpload" runat="server" Text="Upload" Style="width: 30%" OnClick="btnUpload_Click" CssClass="submit-button" />
                        <asp:Label ID="lblMessage" runat="server" Text="1"></asp:Label>
                    </div>
                </div>
            </div>

            <asp:ScriptManager runat="server" />
            <asp:UpdatePanel runat="server" ID="updatePanel" UpdateMode="Conditional">
                <ContentTemplate>
                    <div class="wrap">

                        <div class="wrapper add" style="height: 580px">
                            <div class="form-box login">
                                <asp:Image ID="Image1" Height="300px" Width="100%" runat="server" />

                                <label for="name">Name</label>
                                <asp:TextBox ID="name" CssClass="able" runat="server" OnTextChanged="dept_SelectedIndexChanged" AutoPostBack="true"></asp:TextBox>

                                <label for="dept">Department</label>
                                <asp:DropDownList ID="dept" CssClass="dropdown" runat="server" OnSelectedIndexChanged="dept_SelectedIndexChanged" AutoPostBack="True">
                                    <asp:ListItem Text="" Value=""></asp:ListItem>
                                    <asp:ListItem Text="Civil Engineering" Value="01"></asp:ListItem>
                                    <asp:ListItem Text="Electrical and Electronic Engineering" Value="02"></asp:ListItem>
                                    <asp:ListItem Text="Mechanical Engineering" Value="03"></asp:ListItem>
                                    <asp:ListItem Text="Computer Science and Engineering" Value="04"></asp:ListItem>
                                    <asp:ListItem Text="Electronics and Communication Engineering" Value="05"></asp:ListItem>
                                    <asp:ListItem Text="Biomedical Engineering" Value="06"></asp:ListItem>
                                    <asp:ListItem Text="Material Science and Engineering" Value="07"></asp:ListItem>
                                    <asp:ListItem Text="Industrial Engineering and Management" Value="08"></asp:ListItem>
                                    <asp:ListItem Text="Chemical Engineering" Value="09"></asp:ListItem>
                                    <asp:ListItem Text="Textile Engineering" Value="10"></asp:ListItem>
                                    <asp:ListItem Text="Leather Engineering" Value="11"></asp:ListItem>
                                    <asp:ListItem Text="Energy Science and Engineering" Value="12"></asp:ListItem>
                                    <asp:ListItem Text="Mechatronics Engineering" Value="13"></asp:ListItem>
                                    <asp:ListItem Text="Building Engineering and Construction Management" Value="14"></asp:ListItem>
                                    <asp:ListItem Text="Urban and Regional Planning" Value="15"></asp:ListItem>
                                    <asp:ListItem Text="Architecture" Value="16"></asp:ListItem>
                                    <asp:ListItem Text="Mathematics" Value="17"></asp:ListItem>
                                    <asp:ListItem Text="Chemistry" Value="18"></asp:ListItem>
                                    <asp:ListItem Text="Physics" Value="19"></asp:ListItem>
                                    <asp:ListItem Text="Humanities" Value="20"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="wrapper add" style="height: 740px">
                            <div class="form-box login">

                                <h2 style="margin-bottom: 25px;">Personal
                                        Information</h2>

                                <label for="phone">Phone</label>
                                <asp:TextBox ID="phone" CssClass="able" runat="server"></asp:TextBox>

                                <label for="ad">Address</label>
                                <asp:TextBox ID="ad" CssClass="able" runat="server"></asp:TextBox>

                                <label for="j_date">Join Date</label>
                                <asp:Calendar ID="calDate" runat="server" OnSelectionChanged="dept_SelectedIndexChanged" AutoPostBack="True" CssClass="custom-calendar" ForeColor="Black"></asp:Calendar>
                                <asp:TextBox ID="j_date" runat="server"></asp:TextBox>

                                <label for="designation">Designation</label>
                                <asp:DropDownList ID="designation" runat="server" CssClass="dropdown" OnSelectedIndexChanged="dept_SelectedIndexChanged" AutoPostBack="True">
                                    <asp:ListItem Text="" Value=""></asp:ListItem>
                                </asp:DropDownList>

                            </div>
                        </div>
                        <div class="wrapper add">
                            <div class="form-box login">

                                <h2 style="margin-bottom: 25px;">Professional
                                        Information</h2>

                                <label for="id">Teacher Id</label>
                                <div style="display: flex">
                                    <asp:TextBox ID="code" runat="server"></asp:TextBox>
                                    <asp:TextBox ID="id" CssClass="able" runat="server" OnTextChanged="dept_SelectedIndexChanged" AutoPostBack="true"></asp:TextBox>
                                </div>
                                <label for="grade">Grade</label>
                                <asp:TextBox ID="grd" runat="server"></asp:TextBox>

                                <label for="salary">Salary</label>
                                <asp:TextBox ID="salary" runat="server"></asp:TextBox>

                                <label for="mail">Email</label>
                                <asp:TextBox ID="email" runat="server"></asp:TextBox>

                                <label for="pass">Password</label>
                                <asp:TextBox ID="pass" runat="server"></asp:TextBox>
                            </div>
                        </div>

                    </div>
                    <asp:Button ID="submit" runat="server" Text="Submit" CssClass="submit-button info submit-add" OnClick="submit_Click" />
                    <asp:Label ID="error" runat="server" Text="" CssClass="error-msg"></asp:Label>
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="dept" EventName="SelectedIndexChanged" />
                    <asp:AsyncPostBackTrigger ControlID="id" EventName="TextChanged" />
                    <asp:AsyncPostBackTrigger ControlID="name" EventName="TextChanged" />
                    <asp:AsyncPostBackTrigger ControlID="designation" EventName="SelectedIndexChanged" />
                    <asp:AsyncPostBackTrigger ControlID="calDate" EventName="SelectionChanged" />
                    <asp:PostBackTrigger ControlID="btnUpload" />
                </Triggers>
            </asp:UpdatePanel>

            <br>
            <br>
            <br>
            <br>
        </section>

        <script src="JavaScript/save_info.js"></script>
        <script src="JavaScript/navigation.js"></script>
    </form>
</body>
</html>
