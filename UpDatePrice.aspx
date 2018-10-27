<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UpDatePrice.aspx.cs" Inherits="Store.UpdatePrice" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
      <aside class="right-side">
                <!-- Content Header (Page header) -->
                <section class="content-header">
                    <h1>
                    Manage Items
                        <small>Control panel</small>
                    </h1>
                    <ol class="breadcrumb">
                        <li><a href="#"><i class="fa fa-dashboard"></i> Home</a></li>
                        <li class="active">Update Price</li>
                    </ol>
                </section>
  <section class="content">
    <div class="row">
        <div class="col-md-12">
            <div class="form-group">
                <asp:Label ID="lblCompanyName" runat="server" CssClass="control-label col-md-2"
                    Text="Stock Name"></asp:Label>
                <div class="col-md-4 input-icon">
                    <asp:DropDownList ID="ddlStock" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" AutoPostBack="True" runat="server"></asp:DropDownList>
                    <asp:RequiredFieldValidator ID="fieldVal" ControlToValidate="ddlStock"
                     ValidationGroup="Save" runat="server"></asp:RequiredFieldValidator>
                </div>     
             </div>
        </div>
    </div>
      
    <div class="row">
        <div class="col-md-12">
            <div class="form-group">
                 <asp:Label ID="Label2" runat="server" CssClass="control-label col-md-2"
                    Text="Purchase Price"></asp:Label>
                <div class="col-md-4 input-icon">
                <asp:TextBox runat="server" ReadOnly ="true" CssClass="form-control" ID="OldPurchasePrice"></asp:TextBox>
                
                    </div>
              
                 <div class="col-md-4 input-icon">
                         <asp:TextBox runat="server" CssClass="form-control" ID="NewPurchasePrice"></asp:TextBox>
                  </div> 
                   <asp:RequiredFieldValidator ID="reqName" ControlToValidate="NewPurchasePrice" ValidationGroup="Save" runat="server" ErrorMessage="New Price Req" style="color:Red;">
                 </asp:RequiredFieldValidator>        
            </div>
        </div>
    </div>
      <div class="row">
        <div class="col-md-12">
            <div class="form-group">
                 <asp:Label ID="Label1" runat="server" CssClass="control-label col-md-2"
                    Text="Sale  Price"></asp:Label>
                <div class="col-md-4 input-icon">
                <asp:TextBox runat="server" ReadOnly ="true" CssClass="form-control" ID="OldSalePrice"></asp:TextBox>
                
                    </div>
              
                 <div class="col-md-4 input-icon">
                         <asp:TextBox runat="server" CssClass="form-control" ID="NewSalePrice"></asp:TextBox>
                  </div>    
                  <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="NewSalePrice" ValidationGroup="Save" runat="server" ErrorMessage="New Price Req" style="color:Red;">
                 </asp:RequiredFieldValidator>      
            </div>
        </div>
    </div>
       <div class="row">
        <div class="col-md-12">
            <div class="form-group">
              
                <div class="col-md-4">
                    <asp:Button ID="btnAdd" Text="Update Price" ValidationGroup="Save" runat="server"
                        CssClass="btn btn-primary"  OnClick="btnAdd_Click"/>
                </div>
                 
            </div>
        </div>
    </div>



    </section>
</aside>
</asp:Content>
