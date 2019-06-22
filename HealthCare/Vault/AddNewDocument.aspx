<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="AddNewDocument.aspx.cs" Inherits="HealthCare.Vault.AddNewDocument" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .content-pane{
            padding-top: 10%;
        }
        .ajax-loader{
            position: fixed; 
            text-align: center; 
            height: 100%; 
            width: 100%; 
            top: 0; 
            right: 0; 
            left: 0; 
            z-index: 99999; 
            background-color: #000000; 
            opacity: 0.7;
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
                <h3>Add New Document</h3>
            </center>
            <br />

            <div class="content-form">
                <div class="form-group">
                    <label>Select Document: </label>
                    <asp:FileUpload ID="fileDocuments" AllowMultiple="true" runat="server" />
                </div>
                <div class="form-group">
                    <label>Document Name: </label>
                    <asp:TextBox ID="txtDocumentName" CssClass="form-control" required="required" placeholder="Enter Document Name" runat="server" />
                </div>

                <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <div class="form-group">
                            <label>Hospital Name: </label>
                            <asp:DropDownList ID="ddlHospitals" CssClass="form-control" required="required" AutoPostBack="true" OnSelectedIndexChanged="hospitalSelected" runat="server"></asp:DropDownList>
                        </div>
                        <div class="form-group">
                            <label>Issued By: </label>
                            <asp:DropDownList ID="ddlDoctors" CssClass="form-control" required="required" runat="server"></asp:DropDownList>
                        </div>
                        <asp:UpdateProgress id="updateProgress" runat="server">
                            <ProgressTemplate>
                                <div class="ajax-loader">
                                    <asp:Image ID="imgUpdateProgress" runat="server" ImageUrl="~/images/ajax-loader.gif" AlternateText="Loading ..." ToolTip="Loading ..." style="padding: 10px;position:fixed;top:45%;left:50%;" />
                                </div>
                            </ProgressTemplate>
                        </asp:UpdateProgress>
                    </ContentTemplate>
                </asp:UpdatePanel>

                <div class="form-group">
                    <label>Issue Date: </label>
                    <asp:TextBox ID="txtIssueDate" CssClass="form-control" required="required" placeholder="Enter Document Issue Date" runat="server"></asp:TextBox>
                </div>
                        
                <div class="form-group">
                    <label>Document Type: </label>
                    <asp:DropDownList ID="ddlRecordTypes" CssClass="form-control" required="required" runat="server"></asp:DropDownList>  
                </div>
                
                <center>
                    <asp:Button ID="btnAddDocument" CssClass="btn btn-primary" runat="server" Text="Add Now" OnClick="btnAddDocument_Click"></asp:Button>
                    &nbsp;&nbsp;&nbsp;&nbsp;
                    <a href="ViewDocuments.aspx" class="btn btn-default">Cancel</a>
                </center>
            </div>

        </div>
        <div class="col-md-2"></div>
    </div>

</asp:Content>
