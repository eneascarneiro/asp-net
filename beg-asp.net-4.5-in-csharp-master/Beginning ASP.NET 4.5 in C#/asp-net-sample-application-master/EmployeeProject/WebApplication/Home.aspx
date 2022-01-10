<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="WebApplication.WebForm1" %>

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
        <a href="#" class="btn btn-default btn-sm active">Create</a>
        <a href="Manage.aspx" class="btn btn-default btn-sm">Manage</a>
            
        <asp:LinkButton class="btn btn-default btn-sm" ID="LinkButton1" runat="server" CausesValidation="false" OnClick="LinkButton1_Click">Logout</asp:LinkButton>
      
        </div>
        <legend>Employee registration</legend>
            
            <div class="row" style="background-color:white; padding:15px">
                <div class="card">
                        <div role="tabpanel" id="register-tab" style="margin-top:25px">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label class="col-sm-3 control-label"><font color="red"><b>*</b></font>Title</label>
                                    <asp:DropDownList ID="DropDownList1" runat="server" class="col-sm-6 form-control" name="title" style="width:50%">
                                        <asp:ListItem Selected="True" Value="-1">Select</asp:ListItem>
                                        <asp:ListItem Value="Mr.">Mr.</asp:ListItem>
                                        <asp:ListItem Value="Mrs.">Mrs.</asp:ListItem>
                                        <asp:ListItem Value="Ms.">Ms.</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="Select title" InitialValue="-1" ControlToValidate="DropDownList1" ForeColor="Red"></asp:RequiredFieldValidator>
                                </div>

                                <div class="form-group">
                                    <label class="col-sm-3 control-label"><font color="red"><b>*</b></font>First Name</label>
                                    <div class="col-sm-6">
                                        <asp:TextBox runat="server" type="text" class="form-control" name="first_name" id="first_name"
                                            placeholder="Firstname" />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="First name is required" ControlToValidate="first_name" ForeColor="Red"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="col-sm-3 control-label"><font color="red"><b>*</b></font>Last Name</label>
                                    <div class="col-sm-6">
                                        <asp:TextBox runat="server" type="text" class="form-control" name="last_name" id="last_name" placeholder="Lastname" />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Last name is required" ControlToValidate="last_name" ForeColor="Red"></asp:RequiredFieldValidator>

                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="col-sm-3 control-label">Gender</label>
                                    <div class="col-sm-6">
                                        <input type="radio" name="gender" id="gender" value='Male' checked="checked">&nbsp;Male &nbsp;
								            <input type="radio" name="gender" id="gender" value='Female'>&nbsp;Female 
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="col-sm-3 control-label">Father Name</label>
                                    <div class="col-sm-6">
                                        <asp:TextBox runat="server" type="text" class="form-control" name="father_name" id="father_name" placeholder="Father name" />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Father name is required" ControlToValidate="father_name" ForeColor="Red"></asp:RequiredFieldValidator>

                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="col-sm-3 control-label">Designation</label>
                                    <div class="col-sm-6">
                                        <asp:TextBox runat="server" type="text" class="form-control" name="designation" id="designation" placeholder="Designation" />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Designation is required" ControlToValidate="designation" ForeColor="Red"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label for="dob" class="col-sm-3 control-label">DOB</label>
                                    <div id="sandbox-container" class="col-sm-6">
                                        <asp:TextBox runat="server" type="text" name="dob" id="dob" class="form-control" />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="DOB is required" ControlToValidate="dob" ForeColor="Red"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="col-sm-3 control-label">Select avatar</label>
                                    <div class="col-sm-6">
                                        <input type="file" class="form-control" name="avatar" id="avatar" placeholder="Select" />
                                    </div>
                                </div>
                            </div>    
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label>Department</label>
                                    <select class="form-control" id="department" name="department">
                                        <option selected>Choose...</option>
                                        <option value="IT">IT</option>
                                        <option value="Account">Account</option>
                                        <option value="Admin">Admin</option>
                                        </select>
                                </div>
                                <div class="form-group">
                                    <label>Spouse name</label>
                                    <input type="text" class="form-control" name="spouse_name" id="spouse_name" placeholder="Spouse name">
                                </div>
                                <div class="form-group">
                                    <label>Current address</label>
                                    <textarea class="form-control" rows="2" name="c_address" id="c_address" placeholder="Current address"></textarea>
                                </div>
                                <div class="form-group">
                                    <label>Permanent address</label>
                                    <textarea class="form-control" rows="2" name="p_address" id="p_address" placeholder="Permanent address"></textarea>
                                </div>
                                <div class="form-group">
                                    <asp:Button runat="server" Text="Submit" ID="Save" class="btn-lg btn-success"  OnClick="Save_Click" UseSubmitBehavior="False" Height="40px" />
                                </div>
                            </div>        
                        </div>
                </div>
            </div>
           </form>
      </div>
</body>
</html>
