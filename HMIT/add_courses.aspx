<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="add_courses.aspx.cs" Inherits="HMIT.add_courses" %>

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
    </head>
    <body>
        <form id="add_courses_form" runat="server">
        <section class="header">
            <nav>
                <a href="home.html"><img src="CSS/Resources/Icons/logo.png"></a>
                <div class="nav-links" id="navLinks">
                    <i class="fa fa-times" onclick="hideMenu()"></i>
                    <ul>
                        <li><a href="home.aspx">HOME</a></li>
                        <li><a href="admin.aspx">ADMIN PAGE</a></li>
                        <li><a href="view_course.aspx">VIEW COURSES</a></li>
                        <li><a href="login.aspx">LOGOUT</a></li>
                    </ul>
                </div>
                <i class="fa fa-bars" id="menu" onclick="showMenu()"></i>
            </nav>
            <asp:ScriptManager runat="server" />
                <asp:UpdatePanel runat="server" ID="updatePanel" UpdateMode="Conditional">
                    <ContentTemplate>
                        <div class="wrap">
                    
                                <div class="wrapper add" style="height:450px">
                                    <div class="form-box login">  
                            
                                        <h2 style="margin-bottom: 25px;">Running Semester</h2>

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

                                        <label for="year">Year</label>
                                        <asp:DropDownList ID="year" CssClass="dropdown" runat="server" OnSelectedIndexChanged="dept_SelectedIndexChanged" AutoPostBack="True">
                                            <asp:ListItem Text="" Value=""></asp:ListItem>
                                            <asp:ListItem Text="First" Value="1" ></asp:ListItem>
                                            <asp:ListItem Text="Second" Value="2"></asp:ListItem>
                                            <asp:ListItem Text="Third" Value="3"></asp:ListItem>
                                            <asp:ListItem Text="Fourth" Value="4"></asp:ListItem>
                                        </asp:DropDownList>

                                        <label for="sem">Semester</label>
                                        <asp:DropDownList ID="sem" CssClass="dropdown" runat="server" OnSelectedIndexChanged="dept_SelectedIndexChanged" AutoPostBack="True">
                                            <asp:ListItem Text="" Value=""></asp:ListItem>
                                            <asp:ListItem Text="First" Value="1" ></asp:ListItem>
                                            <asp:ListItem Text="Second" Value="2"></asp:ListItem>
                                        </asp:DropDownList>

                                    </div>
                                </div>
                                <div class="wrapper add" style="height:450px">
                                    <div class="form-box login">

                                        <h2 style="margin-bottom: 25px;">Course</h2>

                                        <label for="c_no">Course No</label>
                                        <div style="display: flex">
                                            <asp:TextBox ID="c_code" runat="server"></asp:TextBox>  
                                            <asp:TextBox ID="c_year" runat="server"></asp:TextBox>  
                                            <asp:TextBox ID="c_sem" runat="server"></asp:TextBox>  
                                            <asp:TextBox ID="c_no" CssClass="able" runat="server"></asp:TextBox>                         
                                        </div>                        

                                        <label for="c_name">Course Name</label>
                                        <asp:TextBox ID="c_name" CssClass="able" runat="server"></asp:TextBox>

                                        <label for="credit">Credit</label>
                                        <asp:TextBox ID="credit" CssClass="able" runat="server"></asp:TextBox>

                                    </div>
                                </div>
                                <div class="wrapper add" style="height:450px">
                                    <div class="form-box login">

                                        <h2 style="margin-bottom: 25px;">Assigned Teacher
                                        </h2>

                                        <label for="id">Teacher From</label>

                                        <asp:DropDownList ID="t_from" CssClass="dropdown" runat="server" OnSelectedIndexChanged="dept_SelectedIndexChanged" AutoPostBack="True">
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
                                       
                                        <label for="t_name">Teacher's Name</label>
                                        <asp:DropDownList ID="t_name" runat="server" CssClass="dropdown" OnSelectedIndexChanged="dept_SelectedIndexChanged" AutoPostBack="True">
                                        </asp:DropDownList> 

                                        <label for="id">Teacher Id</label>
                                        <asp:TextBox ID="id" runat="server"></asp:TextBox>
                          
                                    </div>
                                </div>
                            </div>
                            <asp:Button ID="submit" runat="server" Text="Submit" CssClass="submit-button info submit-add" OnClick="submit_Click"/>
                            <asp:Label ID="error" runat="server" Text="" CssClass="error-msg"></asp:Label>
                            <br>
                            <br>
                            <br>
                            <br>
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="dept" EventName="SelectedIndexChanged" />
                            <asp:AsyncPostBackTrigger ControlID="year" EventName="SelectedIndexChanged" />
                            <asp:AsyncPostBackTrigger ControlID="sem" EventName="SelectedIndexChanged" />
                            <asp:AsyncPostBackTrigger ControlID="t_from" EventName="SelectedIndexChanged" />
                            <asp:AsyncPostBackTrigger ControlID="t_name" EventName="SelectedIndexChanged" />
                        </Triggers>
                    </asp:UpdatePanel>
                
             
        </section>

        <script src="JavaScript/save_info.js"></script>
        <script src="JavaScript/navigation.js"></script>
        </form>
    </body>
</html>

