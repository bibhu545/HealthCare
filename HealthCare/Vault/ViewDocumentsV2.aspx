<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="ViewDocumentsV2.aspx.cs" Inherits="HealthCare.Vault.ViewDocumentsV2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .content-pane {
            padding-top: 7%;
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

            <div class="row">
                <div class="col-md-2"></div>
                <div class="col-md-3">
                    <asp:TextBox ID="txtFromDate" CssClass="form-control" required="required" placeholder="Enter Start Date" runat="server"></asp:TextBox>
                </div>
                <div class="col-md-3">
                    <asp:TextBox ID="txtToDate" CssClass="form-control" required="required" placeholder="Enter End Date" runat="server"></asp:TextBox>
                </div>
                <div class="col-md-2">
                    <asp:Button ID="btnFilterDocument" CssClass="btn btn-primary" runat="server" Text="Filter Documents" OnClick="btnFilterDocument_Click" />
                </div>
                <div class="col-md-2"></div>
            </div>
            <br />

            <div class="table-responsive">
                <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:GridView ID="gvFiles" runat="server" class="table table-bordered table-hover" AutoGenerateColumns="false" AllowSorting="true" OnSorting="OnSorting" AllowPaging="true" OnPageIndexChanging="OnPageIndexChanging" PageSize="4">
                            <Columns>
                                <asp:TemplateField HeaderText="FileName" SortExpression="filepath">
                                    <ItemTemplate>
                                        <a href="<%# Eval("filepath").ToString() %>" style="text-decoration:none" target="_blank"><%# GetFileName(Eval("filepath").ToString()) %></a>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField HeaderText="Hospital Name" DataField="hospitalname" SortExpression="hospitalname" />
                                <asp:BoundField HeaderText="Issued By" DataField="firstname" SortExpression="firstname" />
                                <asp:BoundField HeaderText="Document Type" DataField="recordtype" SortExpression="recordtype" />
                                <asp:TemplateField HeaderText="Issued On" SortExpression="issuedate">
                                    <ItemTemplate>
                                        <%# GetFormattedDate(Eval("issueDate").ToString()) %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Action">
                                    <ItemTemplate>
                                        <div class="btn-group">
                                            <a href="<%# Eval("filepath").ToString() %>" class="btn btn-primary" target="_blank">View</a>
                                            <a href="Download.aspx?fileName=<%# Eval("filepath").ToString() %>" class="btn btn-primary">Download</a>
                                            <a href="DeleteDocument.aspx?id=<%# Eval("documentid").ToString() %>" class="btn btn-danger">Delete</a>
                                        </div>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <PagerStyle HorizontalAlign="Center" CssClass="GridPager" />
                        </asp:GridView>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>

</asp:Content>
