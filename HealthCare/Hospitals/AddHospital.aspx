<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="AddHospital.aspx.cs" Inherits="HealthCare.Hospitals.AddHospital" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .content-pane{
            padding-top: 10%;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="bodyContent" runat="server">
    <div class="row">
        <div class="col-md-2"></div>
        <div class="col-md-8">

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
                <h3>Add New Hospital</h3>
            </center>

            <div class="">
                <div class="form-group">
                    <label>Name: </label>
                    <asp:TextBox ID="txtHospitalName" CssClass="form-control" required="required" placeholder="Enter Hospital Name" runat="server" />  
                </div>
                <div class="form-group">
                    <label>Address: </label>
                    <asp:TextBox ID="txtAddress" CssClass="form-control" required="required" placeholder="Enter Hospital Address" runat="server" />  
                </div>
                <div class="form-group">
                    <label>Contact Number: </label>
                    <asp:TextBox ID="txtContact" CssClass="form-control" required="required" placeholder="Enter Contact Number" runat="server" />  
                </div>
                <div class="form-group">
                    <label>Alternative Contact Number: </label>
                    <asp:TextBox ID="txtAlternativeContact" CssClass="form-control" placeholder="Enter alternative Number" runat="server" />  
                </div>
                <div class="form-group">
                    <label>Email: </label>
                    <asp:TextBox type="email" ID="txtEmail" CssClass="form-control" required="required" placeholder="Enter Hospital Email" runat="server" />  
                </div>
                <div class="form-group">
                    <label class="checkbox-inline"><asp:CheckBox ID="chkSetPrimary" Text="Set Primary" runat="server" /></label> 
                </div>
                <center>
                    <asp:Button ID="btnAddHospital" CssClass="btn btn-primary" runat="server" Text="Add Now" OnClick="btnAddHospital_Click"></asp:Button>
                </center>
            </div>

        </div>
        <div class="col-md-2"></div>
    </div>

</asp:Content>
