<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="ViewDocumentsV3.aspx.cs" Inherits="HealthCare.Vault.ViewDocumentsV3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .content-pane {
            padding-top: 7%;
        }
        th, td{
            text-align: center;
        }
    </style>
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="bodyContent" runat="server">

    <div class="row">
        <div class="col-md-12">

            <% if (Request.QueryString["successMessage"] != null){ %>

            <div class="alert alert-success alert-dismissible fade in">
                <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a>
                <strong>Success! </strong><% Response.Write(Request.QueryString["successMessage"]); %>
            </div>

            <%} %>

            <% if (Request.QueryString["errorMessage"] != null){ %>

            <div class="alert alert-danger alert-dismissible fade in">
                <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a>
                <strong>Error! </strong><% Response.Write(Request.QueryString["errorMessage"]); %>
            </div>

            <%} %>

            <center>
                <h3>My Documents</h3>
            </center>
            <br />

                <table id="datatable">
                    <thead>
                        <tr>
                            <th>DocumentId</th>
                            <th>HospitalName</th>
                            <th>DoctorName</th>
                            <th>IssueDate</th>
                            <th>DocumentTypeName</th>
                            <th>Path</th>
                            <th>View</th>
                        </tr>
                    </thead>
                </table>
            </div>
    </div>

</asp:Content>
