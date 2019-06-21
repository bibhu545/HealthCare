<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="DoctorDetails.aspx.cs" Inherits="HealthCare.Doctors.DoctorDetails" %>

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
                <% if (Convert.ToInt32(dt.Rows[0]["isprimary"]) == 1){ %>
                <span class="primary-hospital"><h4>Primary Doctor</h4></span>
                <%} %>
            </center>
            <br />

            <div class="table-responsive">
                <table class="table table-hover">
                    <tr>
                        <th>First Name: </th>
                        <td><% Response.Write(dt.Rows[0]["firstname"]); %></td>
                    </tr>
                    <tr>
                        <th>Last Name: </th>
                        <td><% Response.Write(dt.Rows[0]["lastname"]); %></td>
                    </tr>
                    <tr>
                        <th>Hospital Name: </th>
                        <td><% Response.Write(dt.Rows[0]["hospitalname"]); %></td>
                    </tr>
                    <tr>
                        <th>Speciality: </th>
                        <td><% Response.Write(dt.Rows[0]["speciality"]); %></td>
                    </tr>
                    <tr>
                        <th>Address: </th>
                        <td><% Response.Write(dt.Rows[0]["address"]); %></td>
                    </tr>
                    <tr>
                        <th>Contact Number: </th>
                        <td><% Response.Write(dt.Rows[0]["phone1"]); %></td>
                    </tr>
                    <tr>
                        <th>Alternative Number: </th>
                        <td><% Response.Write(dt.Rows[0]["phone2"]); %></td>
                    </tr>
                    <tr>
                        <th>Email</th>
                        <td><% Response.Write(dt.Rows[0]["email"]); %></td>
                    </tr>
                </table>
                <center>
                    <a href="EditDoctor.aspx?id=<% Response.Write(dt.Rows[0]["doctorid"]); %>" class="btn btn-primary">Edit Details</a>
                    <a href="ViewDoctors.aspx" class="btn btn-success">View All Doctors</a>
                </center>
            </div>
        </div>
        <div class="col-md-2"></div>
    </div>

</asp:Content>
