<%@ Page Title="" Language="C#" MasterPageFile="~/Hospital/Hospital.Master" AutoEventWireup="true" CodeBehind="AddHospital.aspx.cs" Inherits="HealthCare.Hospital.AddHospital" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="bodyContent" runat="server">
    <div class="add-edit-form">
        <div class="form-group">
          <label>Hospital Name:</label>
          <asp:TextBox ID="txtName" type="text" class="form-control" placeholder="Enter Hospital Name" runat="server"></asp:TextBox>
        </div>
        <div class="form-group">
          <label>Hospital Address:</label>
          <asp:TextBox ID="txtAddress" type="text" class="form-control" placeholder="Enter Hospital Address" runat="server"></asp:TextBox>
        </div>
        <div class="form-group">
          <label>Email:</label>
          <asp:TextBox ID="txtEmail" type="text" class="form-control" placeholder="Enter Hospital Email" runat="server"></asp:TextBox>
        </div>
        <div class="form-group">
          <label>Contact Number:</label>
          <asp:TextBox ID="txtNumber" type="text" class="form-control" placeholder="Enter Hospital Contact Number" runat="server"></asp:TextBox>
        </div>
        <div class="form-group">
          <label>Alternative Contact Number:</label>
          <asp:TextBox ID="txtAlternativeNumber" type="text" class="form-control" placeholder="Enter Alternative Contact Number" runat="server"></asp:TextBox>
        </div>
        <br />
        <center>
            <asp:Button ID="btnAddHospital" runat="server" CssClass="btn btn-primary" Text="Add New Hospital"></asp:Button>
        </center>
    </div>
</asp:Content>
