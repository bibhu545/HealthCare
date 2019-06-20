﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="HealthCare.Home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>HealthCare</title>
    <link href="https://fonts.googleapis.com/css?family=Acme|Lobster+Two" rel="stylesheet" />
    <link href="css/bootstrap.min.css" rel="stylesheet" />
    <link href="css/Style.css" rel="stylesheet" />
</head>
<body class="home-body">
    <div class="overlay">
        <nav class="navbar navbar-inverse navbar-fixed-top">
            <div class="container">
                <div class="navbar-header">
                    <button type="button" class="navbar-toggle" data-toggle="collapse" data-target="#myNavbar">
                        <span class="icon-bar"></span>
                        <span class="icon-bar"></span>
                        <span class="icon-bar"></span>                        
                    </button>
                    <a class="navbar-brand active" href="Home.aspx"><span style="color:red;">H</span>ealth<span style="color:red;">C</span>are.com</a>
                </div>
                <div class="collapse navbar-collapse" id="myNavbar">
                    <ul class="nav navbar-nav navbar-right">
                        <li class="active"><a href="Register.aspx"><span class="glyphicon glyphicon-user"></span> Sign Up</a></li>
                        <li class="active"><a href="Login.aspx"><span class="glyphicon glyphicon-log-in"></span> Login</a></li>
                    </ul>
                </div>
            </div>
        </nav>
        <form id="form1" runat="server">
            <div class="container">
                <div class="row home">
                
                        <div class="col-md-2"></div>
                        <div class="col-md-8 home-content">
                            <h2>Welcome to HealthCare</h2>
                            <br /><br />
                            <p>Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. </p>
                            <br /><br />
                            <a href="Register.aspx" class="btn btn-success">Register and Become a Member</a> 
                            &nbsp;&nbsp;&nbsp;&nbsp;
                            <a href="Login.aspx" class="btn btn-primary">Already a user? Login now</a>
                        </div>
                        <div class="col-md-2"></div>
                
                </div>
            </div>
        </form>
    </div>

    <script src="https://code.jquery.com/jquery-3.4.1.min.js"></script>
    <script src="js/bootstrap.js"></script>
</body>
</html>