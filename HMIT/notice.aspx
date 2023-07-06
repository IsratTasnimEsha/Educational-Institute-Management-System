<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="notice.aspx.cs" Inherits="HMIT.notice" %>

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
                                <label for="search" style="font-weight: bold;">Search</label>
                                <asp:TextBox ID="search" runat="server" CssClass="able" OnTextChanged="year_SelectedIndexChanged" AutoPostBack="true"></asp:TextBox>
                            </div>              
                        </section>
                           
                        <section class="table_body">
                            <asp:GridView ID="GridViewNotices" runat="server" AutoGenerateColumns="False" DataKeyNames="date_time" CssClass="gridview">
                                <HeaderStyle CssClass="header-style" />
                                <Columns>
                                    <asp:BoundField DataField="date_time" HeaderText="Time" ItemStyle-HorizontalAlign="Center" />
                                    <asp:BoundField DataField="from_whom" HeaderText="From" ItemStyle-HorizontalAlign="Center" />
                                    <asp:BoundField DataField="to_whom" HeaderText="To" ItemStyle-HorizontalAlign="Center" />
                                    <asp:BoundField DataField="sub" HeaderText="Subject" ItemStyle-HorizontalAlign="Center" />
                                    <asp:BoundField DataField="msg" HeaderText="Notice" ItemStyle-HorizontalAlign="Center" />                                
                                </Columns>
                            </asp:GridView>
                        </section>                    
                        <br />
                    </ContentTemplate>
                    <Triggers>
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