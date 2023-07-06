<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="registration.aspx.cs" Inherits="HMIT.registration" %>

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
        .checkbox {
            height: 35px;
            width: 35px;
            cursor: pointer;
        }

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
    <script>
        function beAlert() {
            window.alert("Registration Completed");
        }
    </script>
</head>
<body>
    <form runat="server">
        <section class="header">
            <nav>
                <a href="home.html">
                    <img src="CSS/Resources/Icons/logo.png"></a>
                <div class="nav-links" id="navLinks">
                    <i class="fa fa-times" onclick="hideMenu()"></i>
                    <ul>
                        <li><a href="home.html">HOME</a></li>
                        <li>
                            <asp:Button ID="assigned" runat="server" Text="STUDENT PAGE" OnClick="assigned_Click"></asp:Button>
                        </li>
                        <li><a href="login.aspx">LOGOUT</a></li>
                    </ul>
                </div>
                <i class="fa fa-bars" id="menu" onclick="showMenu()"></i>
            </nav>
            <div>

                <main class="table">
                    <h1>Course Registration</h1>
                </main>
                <main class="table">
                    <asp:ScriptManager runat="server" />
                    <asp:UpdatePanel runat="server" ID="updatePanel" UpdateMode="Conditional">
                        <ContentTemplate>
                            <section class="table_header" style="padding-left: 200px; padding-right: 200px;">
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
                            </section>


                            <section class="table_body">
                                <asp:GridView ID="GridViewCourses" runat="server" AutoGenerateColumns="False" CssClass="gridview">
                                    <HeaderStyle CssClass="header-style" />
                                    <Columns>
                                        <asp:TemplateField ItemStyle-Width="130px">
                                            <HeaderTemplate>
                                                <p>Select Course</p>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <div style="text-align: center;">
                                                    <asp:CheckBox ID="check" CssClass="checkbox" runat="server" />
                                                </div>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="course_no" HeaderText="Course ID" ItemStyle-HorizontalAlign="Center" />
                                        <asp:BoundField DataField="course_title" HeaderText="Course Title" ItemStyle-HorizontalAlign="Center" />
                                        <asp:BoundField DataField="credit" HeaderText="Credit" ItemStyle-HorizontalAlign="Center" />
                                    </Columns>
                                </asp:GridView>
                            </section>

                            <div class="foot">
                                <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="submit" OnClick="btnSubmit_Click" OnClientClick="beAlert()" />
                            </div>
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="year" EventName="SelectedIndexChanged" />
                            <asp:AsyncPostBackTrigger ControlID="sem" EventName="SelectedIndexChanged" />
                        </Triggers>
                    </asp:UpdatePanel>
                </main>
            </div>
        </section>
    </form>
    <script src="JavaScript/navigation.js"></script>
</body>
</html>
