<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="result.aspx.cs" Inherits="HMIT.result" %>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>HM Institute Of Technology</title>
    <link rel="stylesheet" href="CSS/navigation.css">
    <link rel="stylesheet" href="CSS/table.css">
    <link rel="stylesheet" href="CSS/form.css">
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
    <form runat="server">
        <section class="header">
            <nav>
                <a href="home.html">
                    <img src="CSS/Resources/Icons/logo.png"></a>
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
            <div>                
                <div style="display: flex; padding-left: 5%; padding-right: 5%">
                    <div class="wrapper add" style="height: 300px; width: 40%" >
                        <div class="form-box login">
                            <h2 style="margin-bottom: 25px;">First Year</h2>
                            <label>1st Semester</label>
                            <asp:TextBox ID="_1_1" runat="server"></asp:TextBox>
                            <label>2nd Semester</label>
                            <asp:TextBox ID="_1_2" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="wrapper add" style="height: 300px; width: 40%">
                        <div class="form-box login">
                            <h2 style="margin-bottom: 25px;">Second Year</h2>
                            <label>1st Semester</label>
                            <asp:TextBox ID="_2_1" runat="server"></asp:TextBox>
                            <label>2nd Semester</label>
                            <asp:TextBox ID="_2_2" runat="server"></asp:TextBox>
                        </div>
                    </div>                                    
                </div>

                <div style="display: flex; padding-left: 5%; padding-right: 5%">
                    <div class="wrapper add" style="height: 300px; width: 40%" >
                        <div class="form-box login">
                            <h2 style="margin-bottom: 25px;">Third Year</h2>
                            <label>1st Semester</label>
                            <asp:TextBox ID="_3_1" runat="server"></asp:TextBox>
                            <label>2nd Semester</label>
                            <asp:TextBox ID="_3_2" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="wrapper add" style="height: 300px; width: 40%">
                        <div class="form-box login">
                            <h2 style="margin-bottom: 25px;">Fourth Year</h2>
                            <label>1st Semester</label>
                            <asp:TextBox ID="_4_1" runat="server"></asp:TextBox>
                            <label>2nd Semester</label>
                            <asp:TextBox ID="_4_2" runat="server"></asp:TextBox>
                        </div>
                    </div>                                    
                </div>

                <div style="display: flex; padding-left: 5%; padding-right: 5%">
                    <div class="wrapper add" style="height: 200px; width: 40%" >
                        <div class="form-box login">
                            <h2 style="margin-bottom: 25px;">CGPA</h2>                           
                            <asp:TextBox ID="cgpa" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="wrapper add" style="height: 200px; width: 40%" >
                        <div class="form-box login">
                            <h2 style="margin-bottom: 25px;">Graduation</h2>                           
                            <asp:TextBox ID="graduation" runat="server"></asp:TextBox>
                        </div>
                    </div>                    
                </div>

                <main class="table">
                    <asp:ScriptManager runat="server" />
                    <asp:UpdatePanel runat="server" ID="updatePanel" UpdateMode="Conditional">
                        <ContentTemplate>
                            <section class="table_header" style="padding-left: 40px; padding-right: 40px;">
                                <div>
                                    <label for="year" style="font-weight: bold;">Year</label>
                                    <asp:DropDownList ID="year" CssClass="dropdown" Style="color: black; height: 40px" runat="server" OnSelectedIndexChanged="year_SelectedIndexChanged" AutoPostBack="True">
                                        <asp:ListItem Text="" Value=""></asp:ListItem>
                                        <asp:ListItem Text="First" Value="1"></asp:ListItem>
                                        <asp:ListItem Text="Second" Value="2"></asp:ListItem>
                                        <asp:ListItem Text="Third" Value="3"></asp:ListItem>
                                        <asp:ListItem Text="Fourth" Value="4"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div>
                                    <label for="sem" style="font-weight: bold;">Semester</label>
                                    <asp:DropDownList ID="sem" CssClass="dropdown" Style="color: black; height: 40px" runat="server" OnSelectedIndexChanged="year_SelectedIndexChanged" AutoPostBack="True">
                                        <asp:ListItem Text="" Value=""></asp:ListItem>
                                        <asp:ListItem Text="First" Value="1"></asp:ListItem>
                                        <asp:ListItem Text="Second" Value="2"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div>
                                    <label for="search" style="font-weight: bold;">Search Course No. Or Course Title</label>
                                    <asp:TextBox ID="search" runat="server" CssClass="able" Style="width: 100%" OnTextChanged="year_SelectedIndexChanged" AutoPostBack="true"></asp:TextBox>
                                </div>
                            </section>

                            <section class="table_body">
                                <asp:GridView ID="GridViewCourses" runat="server" AutoGenerateColumns="False" DataKeyNames="course_no" CssClass="gridview">
                                    <HeaderStyle CssClass="header-style" />
                                    <Columns>
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
                                        <asp:TemplateField HeaderText="Obtained Marks" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Label ID="marks" runat="server" Text='<%# Bind("marks") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Grade Point" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Label ID="grade" runat="server" Text='<%# Bind("grade_point") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Letter Grade" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Label ID="l_grade" runat="server" Text='<%# Bind("letter_grade") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Attempt" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Label ID="attempt" runat="server" Text='<%# Bind("attempt") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </section>

                            <br />
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
