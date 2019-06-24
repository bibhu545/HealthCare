<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="UserHome.aspx.cs" Inherits="HealthCare.Profile.UserHome" %>

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
            <div class="table-responsive">

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

                <br />
                <center>
                    <h3>My Profile</h3>
                </center>
                <br />
                <table class="table table-hover cover-details">
                    <tr>
                        <th>First Name: </th>
                        <td><% Response.Write(user.FirstName); %></td>
                    </tr>
                    <tr>
                        <th>Last Name: </th>
                        <td><% Response.Write(user.LastName); %></td>
                    </tr>
                    <tr>
                        <th>Email: </th>
                        <td><% Response.Write(user.Email); %></td>
                    </tr>
                    <tr>
                        <th>Phone: </th>
                        <td>
                            <% if (user.Phone.Equals("")){ %>
                                <span class="blank-span"><i>Please click edit to add Phone Number.</i></span>
                            <% }else { %>
                            <% Response.Write(user.Phone);}%>
                        </td>
                    </tr>
                    <tr>
                        <th>Address: </th>
                        <td>
                            <% if (user.Phone.Equals("")){ %>
                                <span class="blank-span"><i>Please click edit to add Address.</i></span>
                            <% }else { %>
                            <% Response.Write(user.Address);}%>
                        </td>
                    </tr>
                </table>
                <br />
                <center>
                    <a href="EditProfile.aspx" class="btn btn-primary">Edit Profile</a>
                </center>
            </div>
        </div>
        <div class="col-md-2"></div>
    </div>

</asp:Content>
