<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="ConfirmRegistration.aspx.cs" Inherits="HealthCare.Profile.ConfirmRegistration" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .opt-text {
            color: grey;
        }

        .form-group {
            width: 50%;
            margin: auto;
            margin-top: 5%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyContent" runat="server">
    <div class="add-edit-form">

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

        <div class="form-group">
            <label>Enter OTP *: </label>
            <asp:TextBox ID="txtOtp" type="text" class="form-control" placeholder="Enter OTP provided to your mail." runat="server"></asp:TextBox>
            <br />
            <span class="opt-text">Check your mail for otp. It's valid for limited time</span>
        </div>

        <br />
        <center>
            <asp:Button ID="btnAddHospital" runat="server" CssClass="btn btn-primary" Text="Confirm Membership" OnClick="btnAddHospital_Click"></asp:Button>
        </center>
    </div>
</asp:Content>
