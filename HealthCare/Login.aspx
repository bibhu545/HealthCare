<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="HealthCare.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>HealthCare | Login</title>
    <link href="https://fonts.googleapis.com/css?family=Acme|Lobster+Two" rel="stylesheet" />
    <link href="css/bootstrap.min.css" rel="stylesheet" />
    <link href="/css/Master-Style.css" rel="stylesheet" />
    <style>
        .forms {
            padding-top: 14%;
            color: white;
            min-height: 100vh;
        }

        .form-overlay {
            padding-bottom: 5%;
            padding-top: 5%;
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

                            <% if (Request.QueryString["successMessage"] != null){ %>

                                <div class="alert alert-success alert-dismissible fade in">
                                    <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a>
                                    <strong>Success! </strong> <% Response.Write(Request.QueryString["successMessage"]); %>
                                </div>

                            <%} %>

                            <% if (Request.QueryString["errorMessage"] != null){ %>

                                <div class="alert alert-danger alert-dismissible fade in">
                                    <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a>
                                    <strong>Error! </strong> <% Response.Write(Request.QueryString["errorMessage"]); %>
                                </div>

                            <%} %>

                            <center>
                                <h2>Login and start Using Healthcare</h2>
                            </center>
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
                                <div class="col-sm-4 control-label">
                                    <a href="#">Forgot your password?</a>
                                </div>
                                <div class="col-sm-8">
                                    <asp:Button ID="btnLogin" class="btn btn-primary btn-login" runat="server" Text="Login Now" OnClick="btnLogin_Click"></asp:Button>
                                    &nbsp;&nbsp;&nbsp;&nbsp;
                                <a href="Register.aspx" class="btn btn-success">Register Now</a>
                                </div>
                            </div>
                            <br />
                        </div>
                    </div>
                    <div class="col-md-3"></div>
                </div>
            </div>
        </form>
    </div>

    <script src="https://code.jquery.com/jquery-3.4.1.min.js"></script>
    <script src="/js/bootstrap.js"></script>
</body>
</html>
