<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ErrorPage.aspx.cs" Inherits="HealthCare.ErrorPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>HealthCare: Error</title>
    <link href="https://fonts.googleapis.com/css?family=Acme|Lobster+Two" rel="stylesheet" />
    <link href="css/bootstrap.min.css" rel="stylesheet" />
    <link href="/css/Master-Style.css" rel="stylesheet" />
    <style>
        .left-div img{
            border: 1px solid blue;
            border-radius: 10px;
        }
        .jumbotron{
            margin: auto;
            text-align:center;
            margin-top:10%;
            border: 1px solid blue;
            border-radius: 10px;
        }
        .right-div{
            margin: auto;
            text-align:center;
            padding-top: 5%;
            padding-bottom: 5%;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="jumbotron">
                <div class="row">
                    <div class="col-md-6 left-div">
                        <img src="/images/bb8.gif" alt="Alternate Text" />
                    </div>
                    <div class="col-md-6 right-div">
                        <h2>Oops..Some error occured...</h2>
                        <br />
                        <a href="/home.aspx" class="btn btn-lg btn-primary">Take me Home</a>
                    </div>
                </div>
            </div>
        </div>
    </form>

    <script src="https://code.jquery.com/jquery-3.4.1.min.js"></script>
    <script src="/js/bootstrap.js"></script>
</body>
</html>
