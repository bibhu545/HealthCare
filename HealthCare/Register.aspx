<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="HealthCare.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>HealthCare | Register</title>
    <link href="https://fonts.googleapis.com/css?family=Acme|Lobster+Two" rel="stylesheet" />
    <link href="css/bootstrap.min.css" rel="stylesheet" />
    <link href="css/Style.css" rel="stylesheet" />
    <style>
        .forms {
            padding-top: 8%;
            color: white;
            min-height: 100vh;
        }
    </style>
</head>
<body class="register-body">
    <div class="login-page-overlay">
    <form id="form1" runat="server">
        <div class="container forms">
            <div class="row">
                <div class="col-md-3"></div>
                <div class="col-md-6">
                    <div class="form-overlay">
                        <center>
                                <h2>Register and start discovering Healthcare</h2>
                            </center>
                        <br />

                        <div class="form-group">
                            <label class="control-label col-sm-4">First Name:</label>
                            <div class="col-sm-8">
                                <div class="input-group">
                                    <span class="input-group-addon"><i class="glyphicon glyphicon-user"></i></span>
                                    <asp:TextBox ID="txtFirstName" type="text" class="form-control" placeholder="Enter First Name" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <br />
                        <br />
                        <div class="form-group">
                            <label class="control-label col-sm-4">Last Name:</label>
                            <div class="col-sm-8">
                                <div class="input-group">
                                    <span class="input-group-addon"><i class="glyphicon glyphicon-user"></i></span>
                                    <asp:TextBox ID="txtLastName" type="text" class="form-control" placeholder="Enter Last Name" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <br />
                        <br />
                        <div class="form-group">
                            <label class="control-label col-sm-4" for="email">Email:</label>
                            <div class="col-sm-8">
                                <div class="input-group">
                                    <span class="input-group-addon"><i class="glyphicon glyphicon-envelope"></i></span>
                                    <asp:TextBox ID="txtEmail" type="email" class="form-control" placeholder="Enter Email" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <br />
                        <br />
                        <div class="form-group">
                            <label class="control-label col-sm-4" for="password">Password:</label>
                            <div class="col-sm-8">
                                <div class="input-group">
                                    <span class="input-group-addon"><i class="glyphicon glyphicon-lock"></i></span>
                                    <asp:TextBox ID="txtPassword" type="password" class="form-control" placeholder="Enter Password" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <br />
                        <br />
                        <div class="form-group">
                            <label class="control-label col-sm-4">Confirm Password:</label>
                            <div class="col-sm-8">
                                <div class="input-group">
                                    <span class="input-group-addon"><i class="glyphicon glyphicon-lock"></i></span>
                                    <asp:TextBox ID="txtConfirmPassword" type="password" class="form-control" placeholder="ReEnter Password" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <br />
                        <br />
                        <center>
                                <asp:Button ID="btnRegister" class="btn btn-success" runat="server" Text="Register Now"></asp:Button> 
                                &nbsp;&nbsp;&nbsp;&nbsp;
                                <a href="Login.aspx" class="btn btn-primary btn-login">Login now</a>
                        </center>
                        <br />
                    </div>
                </div>
                <div class="col-md-3"></div>
            </div>
        </div>
    </form>
    </div>

    <script src="https://code.jquery.com/jquery-3.4.1.min.js"></script>
    <script src="js/bootstrap.js"></script>
</body>
</html>
