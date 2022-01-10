<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebApplication.WebForm3" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
   <head runat="server">
      <title></title>
      <link href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/css/bootstrap.min.css" rel="stylesheet"/>
      <script src="//maxcdn.bootstrapcdn.com/bootstrap/3.3.5/js/bootstrap.min.js"></script>
      <script src="//ajax.googleapis.com/ajax/libs/jquery/1.11.3/jquery.min.js"></script>
   </head>
   <body>
       <div class="container center_div">
        <div class="row">
      <form id="form1" runat="server">
         <div>
            <div class="panel panel-default">
               <div class="panel-heading h4 text-primary text-center">
                  Login panel
               </div>
               <div class="panel-body">
                  <div class="form-horizontal" role="form">
                     <div class="form-group">
                        <label class="col-sm-2 control-label" for="email">Email</label>
                        <div class="col-sm-10">
                           <asp:textbox class="form-control" id="email" placeholder="Enter Email ID" runat="server"></asp:textbox>
                           <span><asp:RequiredFieldValidator ControlToValidate="email" ForeColor="red" ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please enter email"></asp:RequiredFieldValidator></span>
                        </div>
                     </div>
                     <div class="form-group">
                        <label class="col-sm-2 control-label" for="pwd">Password</label>
                        <div class="col-sm-10">
                           <asp:textbox class="form-control" id="pwd" placeholder="Enter Password" runat="server" textmode="Password"></asp:textbox>
                            <span><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ForeColor="Red" ErrorMessage="Please enter password" ControlToValidate="pwd"></asp:RequiredFieldValidator></span>

                        </div>
                     </div>
                     <div class="form-group">
                        <div class="col-sm-offset-2 col-sm-10">
                           <asp:label cssclass="label label-danger" id="lblmsg" runat="server"></asp:label>
                        </div>
                     </div>
                     <div class="form-group">
                        <div class="col-sm-offset-2 col-sm-10">
                           <asp:button cssclass="btn btn-success" id="btnLogin"  runat="server" text="Submit" OnClick="btnLogin_Click">
                           </asp:button>
                        </div>
                     </div>
                  </div>
               </div>
            </div>
         </div>
      </form>
            </div></div>
   </body>
</html>