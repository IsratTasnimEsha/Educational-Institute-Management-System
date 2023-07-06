<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="admin.aspx.cs" Inherits="HMIT.admin" %>

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
                        <img src="CSS/Resources/Icons/teachers.png" class="icons">
                        <p>FACULTY MEMBERS</p>
                    </div>
                    <div class="button-area">
                        <asp:Button ID="teacher_add" runat="server" Text="Add Records" CssClass="submit-button b-add" OnClick="teacher_add_Click" />
                        <asp:Button ID="teacher_view" runat="server" Text="View Records" CssClass="submit-button b-view" OnClick="teacher_view_Click" />
                    </div>
                </div>
                <div class="wrapper picture">
                    <div class="form-box login">
                        <img src="CSS/Resources/Icons/student.png" class="icons">
                        <p>STUDENTS</p>
                    </div>
                    <div class="button-area">
                        <asp:Button ID="student_add" runat="server" Text="Add Records" CssClass="submit-button b-add" OnClick="student_add_Click" />
                        <asp:Button ID="student_view" runat="server" Text="View Records" CssClass="submit-button b-view" OnClick="student_view_Click" />
                    </div>
                </div>
                <div class="wrapper picture">
                    <div class="form-box login">
                        <img src="CSS/Resources/Icons/notice.jpg" class="icons">
                        <p>NOTICE</p>
                    </div>
                    <div class="button-area">
                        <asp:Button ID="notice_add" runat="server" Text="Add Records" CssClass="submit-button b-add" OnClick="notice_add_Click" />
                        <asp:Button ID="notice_view" runat="server" Text="View Records" CssClass="submit-button b-view" OnClick="notice_view_Click"/>
                    </div>
                </div>
                <div class="wrapper picture">
                    <div class="form-box login">
                        <img src="CSS/Resources/Icons/course.jpg" class="icons">
                        <p>DEPARMENT COURSE</p>
                    </div>
                    <div class="button-area">
                        <asp:Button ID="course_add" runat="server" Text="Add Courses" CssClass="submit-button b-add" OnClick="course_add_Click" />
                        <asp:Button ID="course_view" runat="server" Text="View Courses" CssClass="submit-button b-view" OnClick="course_view_Click"/>
                    </div>
                </div>
                <div class="wrapper picture">
                    <div class="form-box login">
                        <img src="CSS/Resources/Icons/registration.png" class="icons">
                        <p>STUDENT REGISTRATION</p>
                    </div>
                    <div class="button-area">
                        <asp:Button ID="reg_approve" runat="server" Text="Approve Registrations" CssClass="submit-button b-add" OnClick="registration_approve_Click"/>
                    </div>
                </div>
                <div class="wrapper picture">
                    <div class="form-box login">
                        <img src="CSS/Resources/Icons/result.png" class="icons">
                        <p>RESULT</p>
                    </div>
                    <div class="button-area">
                        <asp:Button ID="result_add" runat="server" Text="Add Results" CssClass="submit-button b-add" OnClick="result_add_Click"/>
                        <asp:Button ID="result_view" runat="server" Text="View Results" CssClass="submit-button b-view" OnClick="result_view_Click"/>
                    </div>
                </div>
                <div class="wrapper picture down">
                    <div class="form-box login">
                        <img src="CSS/Resources/Icons/grade.png" class="icons">
                        <p>Designation, Grade, Salary</p>
                    </div>
                    <div class="button-area">
                        <asp:Button ID="designation_add" runat="server" Text="Add And View Records" CssClass="submit-button b-add" OnClick="designation_add_Click" />
                    </div>
                </div>
            </div>
        </section>
    </form>
    <script src="JavaScript/navigation.js"></script>
</body>
</html>
