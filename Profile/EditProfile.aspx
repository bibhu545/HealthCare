<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="EditProfile.aspx.cs" Inherits="HealthCare.Profile.EditProfile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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

                <center>
                    <h3>Edit Profile</h3>
                </center>
                <table class="table table-hover cover-details">
                    <tr>
                        <th>First Name: </th>
                        <td><asp:TextBox ID="txtFirstName" CssClass="form-control" runat="server" placeholder="Enter First Name" required="required"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <th>Last Name: </th>
                        <td><asp:TextBox ID="txtLastName" CssClass="form-control" runat="server" placeholder="Enter Last Name" required="required"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <th>Email: </th>
                        <td><asp:TextBox type="email" ID="txtEmail" CssClass="form-control" runat="server" placeholder="Enter Email" required="required"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <th>Phone: </th>
                        <td><asp:TextBox ID="txtPhone" CssClass="form-control" runat="server" placeholder="Enter Phone Number"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <th>Address: </th>
                        <td><asp:TextBox ID="txtAddress" CssClass="form-control" runat="server" placeholder="Enter Address"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <th>Profile picture: </th>
                        <td><asp:FileUpload ID="fileProfilePicture" runat="server" /></td>
                    </tr>
                </table>
                <br />
                <center>
                    <asp:Button ID="btnEditProfile" runat="server" class="btn btn-primary" Text="Update Now" OnClick="btnEditProfile_Click"></asp:Button>
                </center>
            </div>
        </div>
        <div class="col-md-2"></div>
    </div>

</asp:Content>
