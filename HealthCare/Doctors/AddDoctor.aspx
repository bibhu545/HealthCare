<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="AddDoctor.aspx.cs" Inherits="HealthCare.Doctors.AddDoctor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .content-pane{
            padding-top: 10%;
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
                <h3>Add New Doctor</h3>
            </center>

            <div class="">
                <div class="form-group">
                    <label>First Name: </label>
                    <asp:TextBox ID="txtFirstName" CssClass="form-control" required="required" placeholder="Enter First Name" runat="server" />
                </div>

                <div class="form-group">
                    <label>Last Name: </label>
                    <asp:TextBox ID="txtLastName" CssClass="form-control" required="required" placeholder="Enter Last Name" runat="server" />
                </div>

                <div class="form-group">
                    <label>Select Hospital: </label>
                    <asp:DropDownList ID="ddlHospitals" CssClass="form-control" runat="server"></asp:DropDownList>
                </div>

                <div class="form-group">
                    <label>Select Speciality: </label>
                <asp:DropDownList ID="ddlSpecialities" CssClass="form-control" runat="server"></asp:DropDownList>
                </div>
                        
                <div class="form-group">
                    <label>Address: </label>
                    <asp:TextBox ID="txtAddress" CssClass="form-control" required="required" placeholder="Enter Address" runat="server" />  
                </div>
                
                <div class="form-group">
                    <label>Contact Number: </label>
                    <asp:TextBox ID="txtContact" CssClass="form-control" required="required" placeholder="Enter Contact Number" runat="server" />  
                </div>
                
                <div class="form-group">
                    <label>Alternative Contact Number: </label>
                    <asp:TextBox ID="txtAlternativeContact" CssClass="form-control" placeholder="Enter alternative Number" runat="server" />  
                </div>
                
                <div class="form-group">
                    <label>Email: </label>
                    <asp:TextBox type="email" ID="txtEmail" CssClass="form-control" required="required" placeholder="Enter Doctor's Email" runat="server" />  
                </div>
                
                <div class="form-group">
                    <label class="checkbox-inline"><asp:CheckBox ID="chkSetPrimary" Text="Set Primary" runat="server" /></label> 
                </div>
                
                <center>
                    <asp:Button ID="btnAddDoctor" CssClass="btn btn-primary" runat="server" Text="Add Now" OnClick="btnAddDoctor_Click"></asp:Button>
                    &nbsp;&nbsp;&nbsp;&nbsp;
                    <a href="ViewDoctors.aspx" class="btn btn-default">Cancel</a>
                </center>
            </div>

        </div>
        <div class="col-md-2"></div>
    </div>

</asp:Content>
