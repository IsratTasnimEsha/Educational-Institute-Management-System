<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="add_notice.aspx.cs" Inherits="HMIT.add_notice" %>

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
                        <li><a href="view_notice.aspx">VIEW NOTICE</a></li>
                        <li><a href="login.aspx">LOGOUT</a></li>
                    </ul>
                </div>
                <i class="fa fa-bars" id="menu" onclick="showMenu()"></i>
            </nav>
            <div class="wrap">            
                <div class="wrapper notice">
                    <div class="form-box login">
                        <form id="add_notice" runat="server">                       
                            
                            <asp:ScriptManager runat="server" />
                                <asp:UpdatePanel runat="server" ID="updatePanel" UpdateMode="Conditional">
                                    <ContentTemplate>

                                        <label for="from">From</label>

                                        <asp:DropdownList ID="from" CssClass="dropdown" runat="server" AutoPostBack="true" OnSelectedIndexChanged="from_SelectedIndexChanged">
                                            <asp:ListItem Text="" Value=""></asp:ListItem>
                                            <asp:ListItem Text="Government" Value="Government"></asp:ListItem>
                                            <asp:ListItem Text="Chancellor" Value="Chancellor"></asp:ListItem>
                                            <asp:ListItem Text="Vice Chancellor" Value="Vice Chancellor"></asp:ListItem>
                                            <asp:ListItem Text="Faculty Dean" Value="Faculty Dean"></asp:ListItem>
                                            <asp:ListItem Text="Department Head" Value="Department Head"></asp:ListItem>
                                        </asp:DropDownList>

                                        <asp:Label ID="dean_label" runat="server" Text="Select Faculty" Visible="false"></asp:Label>

                                        <asp:DropdownList ID="dean" CssClass="dropdown" runat="server" Visible="false" >
                                            <asp:ListItem Text="" Value=""></asp:ListItem>
                                            <asp:ListItem Text="EEE Faculty Dean" Value="EEE Faculty Dean"></asp:ListItem>
                                            <asp:ListItem Text="ME Faculty Dean" Value="ME Faculty Dean"></asp:ListItem>
                                            <asp:ListItem Text="CE Faculty Dean" Value="CE Faculty Dean"></asp:ListItem>
                                        </asp:DropDownList>

                                        <asp:Label ID="dept_head_label" runat="server" Text="Select Department" Visible="false"></asp:Label>

                                        <asp:DropdownList ID="dept_head" CssClass="dropdown" runat="server" Visible="false">
                                            <asp:ListItem Text="" Value=""></asp:ListItem>
                                            <asp:ListItem Text="CE Department Head" Value="CE Department Head"></asp:ListItem>
                                            <asp:ListItem Text="EEE Department Head" Value="EEE Department Head"></asp:ListItem>
                                            <asp:ListItem Text="ME Department Head" Value="ME Department Head"></asp:ListItem>
                                            <asp:ListItem Text="CSE Department Head" Value="CSE Department Head"></asp:ListItem>
                                            <asp:ListItem Text="ECE Department Head" Value="ECE Department Head"></asp:ListItem>
                                            <asp:ListItem Text="BME Department Head" Value="BME Department Head"></asp:ListItem>
                                            <asp:ListItem Text="MSE Department Head" Value="MSE Department Head"></asp:ListItem>
                                            <asp:ListItem Text="IEM Department Head" Value="IEM Department Head"></asp:ListItem>
                                            <asp:ListItem Text="ChE Department Head" Value="ChE Department Head"></asp:ListItem>
                                            <asp:ListItem Text="TE Department Head" Value="TE Department Head"></asp:ListItem>
                                            <asp:ListItem Text="LE Department Head" Value="LE Department Head"></asp:ListItem>
                                            <asp:ListItem Text="ESE Department Head" Value="ESE Department Head"></asp:ListItem>
                                            <asp:ListItem Text="MTE Department Head" Value="MTE Department Head"></asp:ListItem>
                                            <asp:ListItem Text="BECM Department Head" Value="BECM Department Head"></asp:ListItem>
                                            <asp:ListItem Text="Arch Department Head" Value="Arch Department Head"></asp:ListItem>
                                            <asp:ListItem Text="URP Department Head" Value="URP Department Head"></asp:ListItem>
                                            <asp:ListItem Text="MATH Department Head" Value="MATH Department Head"></asp:ListItem>
                                            <asp:ListItem Text="CHEM Department Head" Value="CHEM Department Head"></asp:ListItem>
                                            <asp:ListItem Text="PHY Department Head" Value="PHY Department Head"></asp:ListItem>
                                            <asp:ListItem Text="HUM Department Head" Value="HUM Department Head"></asp:ListItem>
                                        </asp:DropDownList>                                   
                                    
                                        <label for="to">To</label>             
                                        
                                        <asp:DropdownList ID="to" CssClass="dropdown" runat="server" AutoPostBack="true" OnSelectedIndexChanged="to_SelectedIndexChanged">
                                            <asp:ListItem Text="" Value=""></asp:ListItem>
                                            <asp:ListItem Text="All" Value="All"></asp:ListItem>
                                            <asp:ListItem Text="Teachers" Value="Teachers"></asp:ListItem>
                                            <asp:ListItem Text="Students" Value="Students"></asp:ListItem>
                                        </asp:DropDownList>
                                  
                                        <asp:Label ID="teachers_label" runat="server" Text="Select Teachers" Visible="false"></asp:Label>

                                        <asp:DropdownList ID="teachers" CssClass="dropdown" runat="server" Visible="false">     
                                            <asp:ListItem Text="" Value=""></asp:ListItem>
                                            <asp:ListItem Text="All Teachers" Value="All Teachers"></asp:ListItem>
                                            <asp:ListItem Text="CE Faculty Teachers" Value="CE Faculty Teachers"></asp:ListItem>
                                            <asp:ListItem Text="EEE Faculty Teachers" Value="EEE Faculty Teachers"></asp:ListItem>
                                            <asp:ListItem Text="ME Faculty Teachers" Value="ME Faculty Teachers"></asp:ListItem>
                                            <asp:ListItem Text="CE Deparment Teachers" Value="CE Department Teachers"></asp:ListItem>
                                            <asp:ListItem Text="EEE Deparment Teachers" Value="EEE Department Teachers"></asp:ListItem>
                                            <asp:ListItem Text="ME Deparment Teachers" Value="ME Department Teachers"></asp:ListItem>
                                            <asp:ListItem Text="CSE Deparment Teachers" Value="CSE Department Teachers"></asp:ListItem>
                                            <asp:ListItem Text="ECE Deparment Teachers" Value="ECE Department Teachers"></asp:ListItem>
                                            <asp:ListItem Text="BME Deparment Teachers" Value="BME Department Teachers"></asp:ListItem>
                                            <asp:ListItem Text="MSE Deparment Teachers" Value="MSE Department Teachers"></asp:ListItem>
                                            <asp:ListItem Text="IEM Deparment Teachers" Value="IEM Department Teachers"></asp:ListItem>
                                            <asp:ListItem Text="ChE Deparment Teachers" Value="ChE Department Teachers"></asp:ListItem>
                                            <asp:ListItem Text="TE Deparment Teachers" Value="TE Department Teachers"></asp:ListItem>
                                            <asp:ListItem Text="LE Deparment Teachers" Value="LE Department Teachers"></asp:ListItem>
                                            <asp:ListItem Text="ESE Deparment Teachers" Value="ESE Department Teachers"></asp:ListItem>
                                            <asp:ListItem Text="MTE Deparment Teachers" Value="MTE Department Teachers"></asp:ListItem>
                                            <asp:ListItem Text="BECM Deparment Teachers" Value="BECM Department Teachers"></asp:ListItem>
                                            <asp:ListItem Text="Arch Deparment Teachers" Value="Arch Department Teachers"></asp:ListItem>
                                            <asp:ListItem Text="URP Deparment Teachers" Value="URP Department Teachers"></asp:ListItem>
                                            <asp:ListItem Text="MATH Deparment Teachers" Value="MATH Department Teachers"></asp:ListItem>
                                            <asp:ListItem Text="CHEM Deparment Teachers" Value="CHEM Department Teachers"></asp:ListItem>
                                            <asp:ListItem Text="PHY Deparment Teachers" Value="PHY Department Teachers"></asp:ListItem>
                                            <asp:ListItem Text="HUM Deparment Teachers" Value="HUM Department Teachers"></asp:ListItem>
                                        </asp:DropDownList>

                                        <asp:Label ID="students_label" runat="server" Text="Select Students" Visible="false"></asp:Label>

                                        <asp:DropdownList ID="students" CssClass="dropdown" runat="server" Visible="false">
                                            <asp:ListItem Text="" Value=""></asp:ListItem>                                          
                                            <asp:ListItem Text="All Students" Value="All Students"></asp:ListItem>
                                            <asp:ListItem Text="CE Faculty Students" Value="CE Faculty Students"></asp:ListItem>
                                            <asp:ListItem Text="EEE Faculty Students" Value="EEE Faculty Students"></asp:ListItem>
                                            <asp:ListItem Text="ME Faculty Students" Value="ME Faculty Students"></asp:ListItem>
                                            <asp:ListItem Text="CE Department Students" Value="CE Department Students"></asp:ListItem>
                                            <asp:ListItem Text="EEE Department Students" Value="EEE Department Students"></asp:ListItem>
                                            <asp:ListItem Text="ME Department Students" Value="ME Department Students"></asp:ListItem>
                                            <asp:ListItem Text="CSE Department Students" Value="CSE Department Students"></asp:ListItem>
                                            <asp:ListItem Text="ECE Department Students" Value="ECE Department Students"></asp:ListItem>
                                            <asp:ListItem Text="BME Department Students" Value="BME Department Students"></asp:ListItem>
                                            <asp:ListItem Text="MSE Department Students" Value="MSE Department Students"></asp:ListItem>
                                            <asp:ListItem Text="IEM Department Students" Value="IEM Department Students"></asp:ListItem>
                                            <asp:ListItem Text="ChE Department Students" Value="ChE Department Students"></asp:ListItem>
                                            <asp:ListItem Text="TE Department Students" Value="TE Department Students"></asp:ListItem>
                                            <asp:ListItem Text="LE Department Students" Value="LE Department Students"></asp:ListItem>
                                            <asp:ListItem Text="ESE Department Students" Value="ESE Department Students"></asp:ListItem>
                                            <asp:ListItem Text="MTE Department Students" Value="MTE Department Students"></asp:ListItem>
                                            <asp:ListItem Text="BECM Department Students" Value="BECM Department Students"></asp:ListItem>
                                            <asp:ListItem Text="Arch Department Students" Value="Arch Department Students"></asp:ListItem>
                                            <asp:ListItem Text="URP Department Students" Value="URP Department Students"></asp:ListItem>                             
                                        </asp:DropdownList> 
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="from" EventName="SelectedIndexChanged" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            
                            
                            <label for="sub">Subject</label>
                            <asp:TextBox ID="sub" runat="server" CssClass="able"></asp:TextBox>

                            <label for="msg">Notice</label>
                            <asp:TextBox ID="msg" runat="server" TextMode="MultiLine" CssClass="msg able"></asp:TextBox>
                        
                            <asp:Button ID="submit" CssClass="submit-button info" runat="server" Text="Submit" OnClick="submit_Click"/>
                            <asp:Label ID="error" runat="server" Text="" CssClass="error-msg"></asp:Label>
                            </form>
                    </div>
                    
                </div>
                
            </div>
        </section>

        <script src="JavaScript/save_info.js"></script>
        <script src="JavaScript/navigation.js"></script>
    </body>
</html>