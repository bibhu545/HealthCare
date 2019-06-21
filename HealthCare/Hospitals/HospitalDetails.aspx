<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="HospitalDetails.aspx.cs" Inherits="HealthCare.Hospitals.HospitalDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .primary-hospital{
            color: darkgreen;
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
                <h3>Hospital Details</h3>
                <% if (hospital.IsPrimary == 1){ %>
                <span class="primary-hospital"><h4>Primary Hospital</h4></span>
                <%} %>
            </center>
            <br />

            <div class="table-responsive">
                <table class="table table-hover">
                    <tr>
                        <th>Hospital Name: </th>
                        <td><% Response.Write(hospital.HospitalName); %></td>
                    </tr>
                    <tr>
                        <th>Address: </th>
                        <td><% Response.Write(hospital.Address); %></td>
                    </tr>
                    <tr>
                        <th>Contact Number: </th>
                        <td><% Response.Write(hospital.Phone1); %></td>
                    </tr>
                    <tr>
                        <th>Alternative Number: </th>
                        <td><% Response.Write(hospital.Phone2); %></td>
                    </tr>
                    <tr>
                        <th>Email</th>
                        <td><% Response.Write(hospital.Email); %></td>
                    </tr>
                </table>
                <center>
                    <a href="EditHospital.aspx?id=<% Response.Write(hospital.HospitalId); %>" class="btn btn-primary">Edit Details</a>
                    <a href="ViewHospitals.aspx" class="btn btn-success">View All Hospitals</a>
                </center>
            </div>
        </div>
        <div class="col-md-2"></div>
    </div>

</asp:Content>
