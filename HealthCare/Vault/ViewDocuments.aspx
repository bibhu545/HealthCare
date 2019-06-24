<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="ViewDocuments.aspx.cs" Inherits="HealthCare.Vault.ViewDocuments" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .content-pane{
            padding-top: 7%;
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
                <h3>My Documents</h3>
            </center>
            <br />

            <div class="file-container">

		        <div class="well clearfix">

			        <div class="btn-group filters-button-group">
				        <button type="button" class="btn btn-default" data-filter="*">Show All</button>
				        <button type="button" class="btn btn-default" data-filter=".record">Health Records</button>
				        <button type="button" class="btn btn-default" data-filter=".report">Reports</button>
				        <button type="button" class="btn btn-default" data-filter=".prescription">Prescriptions</button>
			        </div>

			        <div class="btn-group sort-button-group pull-right">
				        <button class="btn btn-default" data-sort-direction="asc" data-sort-value="filedate" type="button">
                            Date 
                            <span aria-hidden="true" class="glyphicon glyphicon-chevron-up"></span>
				        </button> 
				        <button class="btn btn-default" data-sort-direction="asc" data-sort-value="filename" type="button">
                            File Name  
                            <span aria-hidden="true" class="glyphicon glyphicon-chevron-up"></span>
				        </button> 
			        </div>

		        </div>

                <div class="all-items row">
                    <% for (int i = 0; i < fileData.FilePath.Count; i++){ %>
                        <% if (fileData.RecordType.ElementAt(i).Equals("1")){%>

                        <div class="item record col-md-4">
                            <div class="inner-item">
                                <a href="<%  Response.Write(fileData.FilePath.ElementAt(i)); %>" style="text-decoration:none" target="_blank">
                                    <div class="inner-icon">
                                        <span class="glyphicon glyphicon-file"></span>
                                    </div>
                                </a>
                                <div class="inner-data">
                                    <a href="<%  Response.Write(fileData.FilePath.ElementAt(i)); %>" style="text-decoration:none" target="_blank">
                                        <span class="file-name"><%  Response.Write(fileData.FileName.ElementAt(i)); %></span>
                                    </a>
                                    <br />
                                    <small class="file-date"> <%  Response.Write(fileData.HospitalName.ElementAt(i)); %> </small>
                                    <span class="badge span-badge">
                                        <small class="file-date"> <%  Response.Write(fileData.IssueDate.ElementAt(i)); %> </small> - 
                                        <%  Response.Write(fileData.Extension.ElementAt(i)); %>
                                    </span>
                                </div>
                            </div>
                        </div>

                        <%}else if (fileData.RecordType.ElementAt(i).Equals("2")){ %>

                        <div class="item report col-md-4">
                            <div class="inner-item">
                                <a href="<%  Response.Write(fileData.FilePath.ElementAt(i)); %>" style="text-decoration:none" target="_blank">
                                    <div class="inner-icon">
                                        <span class="glyphicon glyphicon-file"></span>
                                    </div>
                                </a>
                                <div class="inner-data">
                                    <a href="<%  Response.Write(fileData.FilePath.ElementAt(i)); %>" style="text-decoration:none" target="_blank">
                                        <span class="file-name"><%  Response.Write(fileData.FileName.ElementAt(i)); %></span>
                                    </a>
                                    <br />
                                    <small class="file-date"> <%  Response.Write(fileData.HospitalName.ElementAt(i)); %> </small>
                                    <span class="badge span-badge">
                                        <small class="file-date"> <%  Response.Write(fileData.IssueDate.ElementAt(i)); %> </small> - 
                                        <%  Response.Write(fileData.Extension.ElementAt(i)); %>
                                    </span>
                                </div>
                            </div>
                        </div>

                        <%}else{ %>

                        <div class="item prescription col-md-4">
                            <div class="inner-item">
                                <a href="<%  Response.Write(fileData.FilePath.ElementAt(i)); %>" style="text-decoration:none" target="_blank">
                                    <div class="inner-icon">
                                        <span class="glyphicon glyphicon-file"></span>
                                    </div>
                                </a>
                                <div class="inner-data">
                                    <a href="<%  Response.Write(fileData.FilePath.ElementAt(i)); %>" style="text-decoration:none" target="_blank">
                                        <span class="file-name"><%  Response.Write(fileData.FileName.ElementAt(i)); %></span>
                                    </a>
                                    <br />
                                    <small class="file-date"> <%  Response.Write(fileData.HospitalName.ElementAt(i)); %> </small>
                                    <span class="badge span-badge">
                                        <small class="file-date"> <%  Response.Write(fileData.IssueDate.ElementAt(i)); %> </small> - 
                                        <%  Response.Write(fileData.Extension.ElementAt(i)); %>
                                    </span>
                                </div>
                            </div>
                        </div>

                    <%} } %>
                    
                </div>
            </div>

        </div>
    </div>

</asp:Content>
