<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Manage.aspx.cs" Inherits="WebApplication.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="assets/bootstrap/css/bootstrap.min.css" rel="stylesheet" />
    <link href="assets/bootstrap/css/bootstrap-theme.min.css" rel="stylesheet" />
    <link href="assets/bootstrap/css/datepicker3.css" rel="stylesheet" />
    <link href="assets/style.css" rel="stylesheet" />
    <script src="assets/bootstrap/js/jquery.js"></script>
    <script src="assets/bootstrap/js/bootstrap.min.js"></script>
    <script src="assets/bootstrap/js/bootstrap-datepicker.js"></script>
    <script src="assets/script.js"></script>
</head>

<body>
    <div class="container">
        <form id="Form1" method="post" class="form-horizontal" enctype="multipart/form-data" runat="server">
        <div class="btn-group pull-right">
        <a href="#" class="btn disabled">Welcome <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label></a>
            <a href="Home.aspx" class="btn btn-default btn-sm">Create</a>
            <a href="#" class="btn btn-default btn-sm active">Manage</a>
            <asp:LinkButton class="btn btn-default btn-sm" ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">Logout</asp:LinkButton>
        </div>
        <legend>Manage employee</legend>
            <div class="row">
                <div class="card">
                    
                        <div role="tabpanel" class="tab-pane" id="search-tab">
                            <div class="container" style="margin-top: 25px;">
                                    <div class="d-block" style="margin-bottom:15px">
                                        <label>Search By:</label>
                                        <asp:DropDownList ID="DropDownList1" runat="server">
                                        </asp:DropDownList>
                                        <asp:TextBox ID="search_query" runat="server" name="search_query"  placeholder="Enter search query"></asp:TextBox>
                                        <asp:Button runat="server" Text="Search" ID="Search" class="btn-default" OnClick="Search_Click" UseSubmitBehavior="False"/>

                                    </div>
                                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Height="137px" Width="1100px" 
                                        class="table table-striped table-bordered table-hover" AllowPaging="True"  AllowSorting="True"
                                        OnRowDeleting="GridView1_RowDeleting" 
                                        OnRowEditing="GridView1_RowEditing" 
                                        OnPageIndexChanging="GridView1_PageIndexChanging" 
                                        OnRowUpdating="GridView1_RowUpdating" 
                                        OnSorting="GridView1_Sorting"
                                        OnRowCommand="GridView1_RowCommand" 
                                        OnRowCancelingEdit="GridView1_RowCancelingEdit">
                                        <Columns>
                                            <asp:TemplateField HeaderText="ID" SortExpression="id">
                                                <ItemTemplate>
                                                    <asp:Label ID="ID" runat="server" Text='<%# Eval("id") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Full name" SortExpression="first_name" ControlStyle-Width="75px">
                                                <EditItemTemplate>
                                                    FName<asp:TextBox ID="first_name" runat="server" Text='<%# Eval("first_name") %>'> </asp:TextBox><br/>
                                                    LName<asp:TextBox ID="last_name" runat="server" Text='<%# Eval("last_name") %>'></asp:TextBox>
                                                </EditItemTemplate>
                                                <ItemTemplate>
                                                <asp:Label ID="Label2" runat="server" Text='<%# 
                    Eval("first_name") + " " + Eval("last_name") %>'></asp:Label>
                                            </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Gender" SortExpression="gender">
                                                <EditItemTemplate>
                                                    <asp:DropDownList ID="gender" runat="server">
                                                        <asp:ListItem Value="Male">Male</asp:ListItem>
                                                        <asp:ListItem Value="Female">Female</asp:ListItem>
                                                    </asp:DropDownList>
                                                </EditItemTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="Label3" runat="server" Text='<%# Eval("gender") %>'></asp:Label>
                                            </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Father Name" SortExpression="father_name" ControlStyle-Width="100px">
                                                <EditItemTemplate>
                                                        <asp:TextBox Width="100px" ID="father_name" runat="server" Text='<%# Eval("father_name") %>'></asp:TextBox> 
                                                </EditItemTemplate>
                                                <ItemTemplate>
                                                    <asp:Label Text='<%# Eval("father_name") %>' runat="server"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="DOB" SortExpression="dob">
                                                <EditItemTemplate>
                                                    <div id="sandbox-container">
                                                        <asp:TextBox Width="100px" ID="dob" runat="server" Text='<%# Eval("dob", "{0:yyy-MM-dd}") %>'></asp:TextBox> 
                                                    </div>   
                                                </EditItemTemplate>
                                                <ItemTemplate>
                                                    <asp:Label Text='<%# Eval("dob", "{0:yyy-MM-dd}") %>' runat="server"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Department" SortExpression="department">
                                                <EditItemTemplate>
                                                    <asp:DropDownList ID="department" runat="server">
                                                        <asp:ListItem Value="IT">IT</asp:ListItem>
                                                        <asp:ListItem Value="Account">Account</asp:ListItem>
                                                        <asp:ListItem Value="Admin">Admin</asp:ListItem>
                                                    </asp:DropDownList>
                                                </EditItemTemplate>
                                                <ItemTemplate>
                                                    <asp:Label Text='<%# Eval("department") %>' runat="server"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Designation" SortExpression="designation">
                                                <EditItemTemplate>
                                                    <asp:TextBox Width="100px" ID="designation" runat="server" Text='<%# Eval("designation") %>'></asp:TextBox> 
                                                </EditItemTemplate>
                                                <ItemTemplate>
                                                    <asp:Label Text='<%# Eval("designation") %>' runat="server"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="P-Address" SortExpression="permanent_address" ControlStyle-Width="120px" >
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="permanent_address" runat="server" Text='<%# Eval("permanent_address") %>' Width="100px"> </asp:TextBox>
                                                </EditItemTemplate>
                                                <ItemTemplate>
                                                <asp:Label ID="Label4" runat="server" Text='<%#  Eval("permanent_address") %>'></asp:Label>
                                            </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Avatar">
                                                <EditItemTemplate>
                                                    <asp:FileUpload ID="UpdateAvatar" runat="server" />
                                                    <asp:Button ID="ClearAvatar" runat="server" Text="Clear Avatar" CausesValidation="False" CommandName="ClearAvatar" DataTextField = "id" CommandArgument='<%# Eval("id") %>'/>
                                                </EditItemTemplate>
                                                <ItemTemplate>
                                                    <image ID="Image1" Height="50px" Width="50px" src= 'http://localhost:56464/Avatar/<%#Eval("avatar_path")%>'/>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:CommandField ButtonType="Button" HeaderText="Actions" ShowDeleteButton="True" ShowEditButton="True" ShowHeader="True" />
                                        </Columns>
                                    </asp:GridView>
                            </div>
                        </div>
                    
                </div>
            </div>
             </form>
    </div>
               
</body>
</html>