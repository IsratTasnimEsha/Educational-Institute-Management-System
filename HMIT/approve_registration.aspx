﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="approve_registration.aspx.cs" Inherits="HMIT.approve_registration" %>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>HM Institute Of Technology</title>
    <link rel="stylesheet" href="CSS/navigation.css">
    <link rel="stylesheet" href="CSS/table.css">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">

    <style>
        input[type=text], input[type=password] {
            padding: 5px 10px;
            display: inline-block;
            border: 1px solid #ccc;
            border-radius: 4px;
            box-sizing: border-box;
            font-family: Gabriola;
            font-size: large;
            color: black;
        }

        .able {
            background: transparent;
        }
    </style>
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
                    <li><a href="admin.aspx">ADMIN PAGE</a></li>
                    <li><a href="add_result.aspx">ADD RESULT</a></li>
                    <li><a href="view_result.aspx">VIEW RESULT</a></li>
                    <li><a href="login.aspx">LOGOUT</a></li>
                </ul>
            </div>
            <i class="fa fa-bars" id="menu" onclick="showMenu()"></i>
        </nav>
        <div>
            <form runat="server">
                <main class="table">
                    <asp:ScriptManager runat="server" />
                    <asp:UpdatePanel runat="server" ID="updatePanel" UpdateMode="Conditional">
                        <ContentTemplate>
                            <section class="table_header" style="padding-left: 40px; padding-right: 40px;">
                                <div>
                                    <label for="dept" style="font-weight: bold;">Department</label>
                                    <asp:DropDownList ID="dept" Style="width: 90%;" CssClass="dropdown" runat="server" OnSelectedIndexChanged="year_SelectedIndexChanged" AutoPostBack="True">
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
                                <div>
                                    <label for="year" style="font-weight: bold;">Year</label>
                                    <asp:DropDownList ID="year" CssClass="dropdown" runat="server" OnSelectedIndexChanged="year_SelectedIndexChanged" AutoPostBack="True">
                                        <asp:ListItem Text="" Value=""></asp:ListItem>
                                        <asp:ListItem Text="First" Value="1"></asp:ListItem>
                                        <asp:ListItem Text="Second" Value="2"></asp:ListItem>
                                        <asp:ListItem Text="Third" Value="3"></asp:ListItem>
                                        <asp:ListItem Text="Fourth" Value="4"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div>
                                    <label for="sem" style="font-weight: bold;">Semester</label>
                                    <asp:DropDownList ID="sem" CssClass="dropdown" runat="server" OnSelectedIndexChanged="year_SelectedIndexChanged" AutoPostBack="True">
                                        <asp:ListItem Text="" Value=""></asp:ListItem>
                                        <asp:ListItem Text="First" Value="1"></asp:ListItem>
                                        <asp:ListItem Text="Second" Value="2"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>                            
                                <div>
                                    <label for="d_status" style="font-weight: bold;">Status</label>
                                    <asp:DropDownList ID="d_status" CssClass="dropdown" runat="server" OnSelectedIndexChanged="year_SelectedIndexChanged" AutoPostBack="True">
                                        <asp:ListItem Text="" Value=""></asp:ListItem>
                                        <asp:ListItem Text="Approved" Value="Approved"></asp:ListItem>
                                        <asp:ListItem Text="Rejected" Value="Rejected"></asp:ListItem>
                                        <asp:ListItem Text="Waiting" Value="Waiting"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div>
                                    <label for="search" style="font-weight: bold;">Search Student ID or Course No. Or Course Title</label>
                                    <asp:TextBox ID="search" runat="server" CssClass="able" style="width: 100%" OnTextChanged="year_SelectedIndexChanged" AutoPostBack="true"></asp:TextBox>
                                </div> 
                            </section>

                            <section class="table_body">
                                <asp:GridView ID="GridViewCourses" runat="server" AutoGenerateColumns="False" DataKeyNames="course_no" CssClass="gridview" OnRowDataBound="GridViewCourses_RowDataBound">
                                    <HeaderStyle CssClass="header-style" />
                                    <Columns>                          
                                        <asp:TemplateField HeaderText="Student ID" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Label ID="s_id" runat="server" Text='<%# Bind("student_id") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Course No." ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Label ID="c_no" runat="server" Text='<%# Bind("course_no") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Course Title" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Label ID="c_name" runat="server" Text='<%# Bind("course_title") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Credit" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Label ID="credit" runat="server" Text='<%# Bind("credit") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Status" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Label ID="status" runat="server" Text='<%# Bind("r_status") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Approve" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Button ID="btnApprove" runat="server" Text="Approve" OnClick="btnApprove_Click" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Reject" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Button ID="btnReject" runat="server" Text="Reject" OnClick="btnReject_Click" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </section>

                            <br />
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="dept" EventName="SelectedIndexChanged" />
                            <asp:AsyncPostBackTrigger ControlID="year" EventName="SelectedIndexChanged" />
                            <asp:AsyncPostBackTrigger ControlID="sem" EventName="SelectedIndexChanged" />
                        </Triggers>
                    </asp:UpdatePanel>
                </main>
            </form>
        </div>
    </section>

    <script src="JavaScript/navigation.js"></script>
</body>
</html>

