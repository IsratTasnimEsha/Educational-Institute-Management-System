<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="view_student.aspx.cs" Inherits="HMIT.view_student" %>

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
			<a href="home.html"><img src="CSS/Resources/Icons/logo.png"></a>
			<div class="nav-links" id="navLinks">
				<i class="fa fa-times" onclick="hideMenu()"></i>
				<ul>
					<li><a href="home.aspx">HOME</a></li>
                    <li><a href="admin.aspx">ADMIN PAGE</a></li>
                    <li><a href="add_student.aspx">ADD STUDENT RECORDS</a></li>
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
                                <asp:DropDownList ID="dept" style="width: 90%;" CssClass="dropdown" runat="server" OnSelectedIndexChanged="year_SelectedIndexChanged" AutoPostBack="True">
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
                                <label for="batch" style="font-weight: bold;">Batch</label>
                                <asp:DropDownList ID="batch" style="width: 100%;" CssClass="dropdown" runat="server" OnSelectedIndexChanged="year_SelectedIndexChanged" AutoPostBack="True">
                                    <asp:ListItem Text="" Value=""></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div>
                                <label for="search" style="font-weight: bold;">Search Name Or ID</label>
                                <asp:TextBox ID="search" runat="server" CssClass="able" style="width: 100%" OnTextChanged="year_SelectedIndexChanged" AutoPostBack="true"></asp:TextBox>
                            </div>              
                        </section>

                        <section class="table_body">
                            <asp:GridView ID="GridViewStudents" runat="server" AutoGenerateColumns="False" DataKeyNames="student_id" CssClass="gridview" OnRowDataBound="GridViewStudents_RowDataBound">
                                <HeaderStyle CssClass="header-style" />
                                <Columns>                              
                                    <asp:BoundField DataField="department" HeaderText="Department" ItemStyle-HorizontalAlign="Center" />
                                    <asp:BoundField DataField="student_id" HeaderText="ID" ItemStyle-HorizontalAlign="Center" />
                                    <asp:BoundField DataField="student_name" HeaderText="Name" ItemStyle-HorizontalAlign="Center" />
                                    <asp:BoundField DataField="batch" HeaderText="Batch" ItemStyle-HorizontalAlign="Center" />
                                    <asp:BoundField DataField="email" HeaderText="Email" ItemStyle-HorizontalAlign="Center" />
                                    <asp:TemplateField HeaderText="Update" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Delete" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:Button ID="btnDelete" runat="server" Text="Delete" OnClick="btnDelete_Click"/>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </section>                    
                        <br />
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="dept" EventName="SelectedIndexChanged" />
                        <asp:AsyncPostBackTrigger ControlID="batch" EventName="SelectedIndexChanged" />
                        <asp:AsyncPostBackTrigger ControlID="search" EventName="TextChanged" />
                    </Triggers>
                </asp:UpdatePanel>
        </main>
    </form>
	</div>
	</section>

	<script src="JavaScript/navigation.js"></script>
</body>
</html>