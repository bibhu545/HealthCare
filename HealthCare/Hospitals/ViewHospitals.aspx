<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="ViewHospitals.aspx.cs" Inherits="HealthCare.Hospitals.ViewHospitals" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .content-pane{
            padding-top: 10%;
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
                <h3>All Hospitals</h3>
            </center>
            <br />
            <div class="table-responsive">
                <asp:gridview ID="gvHospitals" runat="server" class="table table-striped table-bordered table-hover" AutoGenerateColumns="false" AllowSorting="true" OnSorting="OnSorting">
                    <Columns>
                        <asp:BoundField HeaderText="Hospital Name" DataField="hospitalname" SortExpression="hospitalname"/>
                        <asp:BoundField HeaderText="Address" DataField="address" SortExpression="address"/>
                        <asp:BoundField HeaderText="Email" DataField="email" SortExpression="email"/>
                        <asp:BoundField HeaderText="Contact Number" DataField="phone1" SortExpression="phone1"/>
                        <asp:BoundField HeaderText="Alternative Number" DataField="phone2" SortExpression="phone2"/>
                        <asp:TemplateField HeaderText="Action">
                            <ItemTemplate>
                                <div class="btn-group">
                                    <a href="HospitalDetails.aspx?id=<%# Eval("hospitalid").ToString() %>" class="btn btn-primary">View</a>
                                    <a href="EditHospital.aspx?id=<%# Eval("hospitalid").ToString() %>" class="btn btn-primary">Edit</a>
                                    <a href="DeleteHospital.aspx?id=<%# Eval("hospitalid").ToString() %>" class="btn btn-danger">Delete</a>
                                </div>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:gridview>
            </div>
        </div>
    </div>
</asp:Content>
