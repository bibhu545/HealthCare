<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="ViewHospitals.aspx.cs" Inherits="HealthCare.Hospitals.ViewHospitals" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .content-pane{
            padding-top: 10%;
        }
        th, td{
            text-align: center;
        }
        .GridPager td:first-child{
            padding-left: 200px;
        }
        .GridPager a, .GridPager span{
            text-decoration: none;
            height: 15px;
            width: 15px;
            border: 1px solid;
            padding: 3px 5px 3px 5px;
            margin: 0px 2px 0px 2px;
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
                <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:gridview ID = "gvHospitals" runat="server" class="table table-bordered table-hover" AutoGenerateColumns="false"  AllowSorting="true" OnSorting = "OnSorting" AllowPaging = "true" OnPageIndexChanging = "OnPageIndexChanging" PageSize = "4">
                            
                            <Columns>
						        <asp:TemplateField HeaderText="Hospital Name" SortExpression = "hospitalname">
							        <ItemTemplate>
								        <%#ViewPrimaryHospital(Eval("isprimary").ToString(), Eval("hospitalname").ToString())%>
							        </ItemTemplate>
						        </asp:TemplateField>
                                <asp:BoundField HeaderText = "Address" DataField = "address" SortExpression = "address"/>
                                <asp:BoundField HeaderText = "Email" DataField = "email" SortExpression = "email"/>
                                <asp:BoundField HeaderText = "Contact Number" DataField = "phone1" SortExpression = "phone1"/>
                                <asp:BoundField HeaderText = "Alternative Number" DataField = "phone2" SortExpression = "phone2"/>
                                <asp:TemplateField HeaderText = "Action">
                                    <ItemTemplate>
                                        <div class = "btn-group">
                                            <a href = "HospitalDetails.aspx?id=<%# Eval("hospitalid").ToString() %>" class = "btn btn-primary">View</a>
                                            <a href = "EditHospital.aspx?id=<%# Eval("hospitalid").ToString() %>" class = "btn btn-primary">Edit</a>
                                            <a href = "DeleteHospital.aspx?id=<%# Eval("hospitalid").ToString() %>" class = "btn btn-danger">Delete</a>
                                        </div>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <PagerStyle HorizontalAlign="Center" CssClass = "GridPager" />
                            
                        </asp:gridview>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
            <center>
                <a href="AddHospital.aspx" class="btn btn-primary">Add New Hospital</a>
            </center>
        </div>
    </div>
</asp:Content>
