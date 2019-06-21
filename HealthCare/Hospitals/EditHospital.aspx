﻿<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="EditHospital.aspx.cs" Inherits="HealthCare.Hospitals.EditHospital" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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
                <h3>Edit Hospital Details</h3>
            </center>
            <br />

            <div class="table-responsive">
                <table class="table table-hover">
                    <tr>
                        <th>Hospital Name: </th>
                        <td>
                            <asp:TextBox ID="txtHospitalName" class="form-control" runat="server" required="required"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <th>Address: </th>
                        <td><asp:TextBox ID="txtAddress" class="form-control" runat="server" required="required"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <th>Contact Number: </th>
                        <td><asp:TextBox ID="txtContactNumber" class="form-control" runat="server" required="required"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <th>Alternative Number: </th>
                        <td><asp:TextBox ID="txtAlternativeNumber" class="form-control" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <th>Email</th>
                        <td><asp:TextBox ID="txtEmail" class="form-control" runat="server" required="required"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <th colspan="2">
                            <label class="checkbox-inline"><asp:CheckBox ID="chkSetPrimary" Text="Set Primary" runat="server" /></label>
                        </th>
                    </tr>
                </table>
                <center>
                    <asp:Button ID="btnEditHospital" class="btn btn-primary" runat="server" Text="Update Details" OnClick="btnEditHospital_Click"></asp:Button>
                    &nbsp;&nbsp;&nbsp;&nbsp;
                    <a href="ViewHospitals.aspx" class="btn btn-default">Cancel</a>
                </center>
            </div>
        </div>
        <div class="col-md-2"></div>
    </div>
</asp:Content>
