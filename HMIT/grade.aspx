<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="grade.aspx.cs" Inherits="HMIT.grade" %>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>HM Institute Of Technology</title>
    <link rel="stylesheet" href="CSS/navigation.css">
    <link rel="stylesheet" href="CSS/form.css">
    <link rel="stylesheet" href="CSS/table.css">
    <link rel="stylesheet" href="CSS/error.css">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">
</head>

<body>
    <form id="grade_form" runat="server">
        <section class="header">
            <nav>
                <a href="home.html">
                    <img src="CSS/Resources/Icons/logo.png"></a>
                <div class="nav-links" id="navLinks">
                    <i class="fa fa-times" onclick="hideMenu()"></i>
                    <ul>
                        <li><a href="home.aspx">HOME</a></li>
                        <li><a href="admin.aspx">ADMIN PAGE</a></li>
                        <li><a href="login.aspx">LOGOUT</a></li>
                    </ul>
                </div>
                <i class="fa fa-bars" id="menu" onclick="showMenu()"></i>
            </nav>
            <div style="display: flex;">
                <div class="wrapper" style="width: 60%;">
                    <div class="form-box login">
                        <div class="input-box">
                            <asp:Label ID="Label1" runat="server" Text="Designation"></asp:Label>
                            <asp:TextBox ID="des" CssClass="able" runat="server"></asp:TextBox>
                        </div>
                        <div class="input-box">
                            <asp:Label ID="Label2" runat="server" Text="Grade"></asp:Label>
                            <asp:DropDownList ID="grd" CssClass="dropdown" runat="server" Style="width: 100%; height: 55px">
                                <asp:ListItem Text="" Value=""></asp:ListItem>
                                <asp:ListItem Text="01" Value="01"></asp:ListItem>
                                <asp:ListItem Text="02" Value="02"></asp:ListItem>
                                <asp:ListItem Text="03" Value="03"></asp:ListItem>
                                <asp:ListItem Text="04" Value="04"></asp:ListItem>
                                <asp:ListItem Text="05" Value="05"></asp:ListItem>
                                <asp:ListItem Text="06" Value="06"></asp:ListItem>
                                <asp:ListItem Text="07" Value="07"></asp:ListItem>
                                <asp:ListItem Text="08" Value="08"></asp:ListItem>
                                <asp:ListItem Text="09" Value="09"></asp:ListItem>
                                <asp:ListItem Text="10" Value="10"></asp:ListItem>
                                <asp:ListItem Text="11" Value="11"></asp:ListItem>
                                <asp:ListItem Text="12" Value="12"></asp:ListItem>
                                <asp:ListItem Text="13" Value="13"></asp:ListItem>
                                <asp:ListItem Text="14" Value="14"></asp:ListItem>
                                <asp:ListItem Text="15" Value="15"></asp:ListItem>
                                <asp:ListItem Text="16" Value="16"></asp:ListItem>
                                <asp:ListItem Text="17" Value="17"></asp:ListItem>
                                <asp:ListItem Text="18" Value="18"></asp:ListItem>
                                <asp:ListItem Text="19" Value="19"></asp:ListItem>
                                <asp:ListItem Text="20" Value="20"></asp:ListItem>
                            </asp:DropDownList>
                        </div>

                        <div class="input-box">
                            <asp:Label ID="Label3" runat="server" Text="Starting Salary"></asp:Label>
                            <asp:TextBox ID="s_salary" CssClass="able" runat="server"></asp:TextBox>
                        </div>
                        <div class="input-box">
                            <asp:Label ID="Label4" runat="server" Text="Maximum Salary"></asp:Label>
                            <asp:TextBox ID="m_salary" CssClass="able" runat="server"></asp:TextBox>
                        </div>
                        <br />
                        <asp:Button ID="submit" runat="server" Text="Submit" CssClass="submit-button" OnClick="submit_Click" />
                        <asp:Label ID="error" runat="server" Text="" CssClass="error-msg"></asp:Label>
                    </div>

                </div>
                <main class="table" style="width: 100%; padding: 10px; display: flex; align-items: center; justify-content: center">             
                    <section class="table_body">
                        <asp:GridView ID="GridViewDesignations" runat="server" AutoGenerateColumns="False" DataKeyNames="designation" CssClass="gridview">
                            <HeaderStyle CssClass="header-style" />
                            <Columns>
                                <asp:BoundField DataField="designation" HeaderText="Designation" ItemStyle-HorizontalAlign="Center" />
                                <asp:BoundField DataField="grade" HeaderText="Grade" ItemStyle-HorizontalAlign="Center" />
                                <asp:BoundField DataField="starting_salary" HeaderText="Starting Salary" ItemStyle-HorizontalAlign="Center" />
                                <asp:BoundField DataField="maximum_salary" HeaderText="Maximum Salary" ItemStyle-HorizontalAlign="Center" />
                                <asp:TemplateField HeaderText="Delete" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Button ID="btnDelete" runat="server" Text="Delete" OnClick="btnDelete_Click" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </section>
                </main>
            </div>
        </section>
        <br />
    </form>

    <script src="JavaScript/navigation.js"></script>

    <script type="module"
        src="https://unpkg.com/ionicons@5.5.2/dist/ionicons/ionicons.esm.js"></script>
    <script nomodule
        src="https://unpkg.com/ionicons@5.5.2/dist/ionicons/ionicons.js"></script>
</body>
</html>
