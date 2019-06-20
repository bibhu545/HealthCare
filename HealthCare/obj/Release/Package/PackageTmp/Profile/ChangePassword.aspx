<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="ChangePassword.aspx.cs" Inherits="HealthCare.Profile.ChangePassword" %>
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
                    <h3>Change Profile</h3>
                </center>
                <table class="table table-hover cover-details">
                    <tr>
                        <th>Current Password: </th>
                        <td>
                            <asp:TextBox type="password" ID="txtCurrentPassword" CssClass="form-control" runat="server" placeholder="Enter Current Password"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <th>New Password: </th>
                        <td>
                            <asp:TextBox type="password" ID="txtNewPassword" CssClass="form-control" runat="server" placeholder="Enter New Password">
                            </asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <th>Confirm Password: </th>
                        <td>
                            <asp:TextBox type="password" ID="txtConfirmPassword" CssClass="form-control" runat="server" placeholder="Confirm New Password"></asp:TextBox>
                        </td>
                    </tr>
                </table>
                <br />
                <center>
                    <asp:Button ID="btnChangePassword" class="btn btn-primary" runat="server" Text="Change Now" OnClick="btnChangePassword_Click"></asp:Button>
                </center>
            </div>
        </div>
        <div class="col-md-2"></div>
    </div>
</asp:Content>
