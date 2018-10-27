<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddSupplier.aspx.cs" Inherits="Store.AddSupplier" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
      <aside class="right-side">
                <!-- Content Header (Page header) -->
                <section class="content-header">
                    <h1>
                     Add Supplier
                        <small>Control panel</small>
                    </h1>
                    <ol class="breadcrumb">
                        <li><a href="#"><i class="fa fa-dashboard"></i> Home</a></li>
                        <li class="active">Supplier</li>
                    </ol>
                </section>
           <section class="content">
   
  
    <div class="row">
        <div class="col-md-12">
            <div class="form-group">
                 <asp:Label ID="Label2" runat="server" CssClass="control-label col-md-2"
                    Text="Supplier Name"></asp:Label>
                <div class="col-md-4 input-icon">
                <asp:TextBox runat="server" CssClass="form-control" ID="supplierName"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="supplierName"
                     ValidationGroup="Save" runat="server"></asp:RequiredFieldValidator>
                    </div>
                <asp:Label ID="Label3" runat="server" CssClass="control-label col-md-2"
                    Text="Phone Number"></asp:Label>
                <div class="col-md-4">
                    <asp:TextBox runat="server" CssClass="form-control" ID="phoneNumber"></asp:TextBox>
                </div>
            </div>
        </div>
    </div>


    <div class="row">
        <div class="col-md-12">
            <div class="form-group">
                <div class="col-md-4">
                    <asp:Button ID="btnAdd" Text="Save" ValidationGroup="Save" runat="server"
                        CssClass="btn btn-primary"  OnClick="btnAdd_Click"/>
                </div>
                 
            </div>
        </div>
    </div>

	
	  </section>
     </aside>
</asp:Content>





