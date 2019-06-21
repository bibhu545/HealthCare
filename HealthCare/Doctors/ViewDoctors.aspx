<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="ViewDoctors.aspx.cs" Inherits="HealthCare.Doctors.ViewDoctors" %>

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
                <h3>All Doctors</h3>
            </center>
            <br />
            <div class="table-responsive">
                <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:gridview ID = "gvDoctors" runat="server" class="table table-striped table-bordered table-hover" AutoGenerateColumns="false"  AllowSorting="true" OnSorting = "OnSorting" AllowPaging = "true" OnPageIndexChanging = "OnPageIndexChanging" PageSize = "4">
                            
                            <Columns>
						        <asp:TemplateField HeaderText="Doctor's Name" SortExpression = "firstname">
							        <ItemTemplate>
								        <%#ViewPrimaryDoctor(Eval("isprimary").ToString(), Eval("firstname").ToString())%>
							        </ItemTemplate>
						        </asp:TemplateField>
                                <asp:BoundField HeaderText = "Hospital Name" DataField = "hospitalname" SortExpression = "hospitalname"/>
                                <asp:BoundField HeaderText = "Address" DataField = "address" SortExpression = "address"/>
                                <asp:BoundField HeaderText = "Contact Number" DataField = "phone1" SortExpression = "phone1"/>
                                <asp:TemplateField HeaderText = "Action">
                                    <ItemTemplate>
                                        <div class = "btn-group">
                                            <a href = "DoctorDetails.aspx?id=<%# Eval("doctorid").ToString() %>" class = "btn btn-primary">View</a>
                                            <a href = "EditDoctor.aspx?id=<%# Eval("doctorid").ToString() %>" class = "btn btn-primary">Edit</a>
                                            <a href = "DeleteDoctor.aspx?id=<%# Eval("doctorid").ToString() %>" class = "btn btn-danger">Delete</a>
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
                <a href="AddDoctor.aspx" class="btn btn-primary">Add New Doctor</a>
            </center>
        </div>
    </div>
</asp:Content>
