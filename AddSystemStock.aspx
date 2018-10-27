<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddSystemStock.aspx.cs" Inherits="Store.AddSystemStock" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <aside class="right-side">
                <!-- Content Header (Page header) -->
                <section class="content-header">
                    <h1>
                     Add System Stock
                        <small>Control panel</small>
                    </h1>
                    <ol class="breadcrumb">
                        <li><a href="#"><i class="fa fa-dashboard"></i> Home</a></li>
                        <li class="active">System Stock</li>
                    </ol>
                </section>
           <section class="content">
    <div class="row">
        <div class="col-md-12">
            <div class="form-group">
                <asp:Label ID="lblCompanyName" runat="server" CssClass="control-label col-md-3"
                    Text="Stock Name"></asp:Label>
                <div class="col-md-4 input-icon">
                    <asp:TextBox runat="server" CssClass="form-control" ID="txtStockName"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="fieldVal" ControlToValidate="txtStockName"
                     ValidationGroup="Save" runat="server" ></asp:RequiredFieldValidator>
                </div>
                
                <asp:Label ID="Label1" runat="server" CssClass="control-label col-md-3"
                    Text="Quantity type"></asp:Label>
                <asp:DropDownList ID="ddlType" runat="server"></asp:DropDownList>
                <asp:RequiredFieldValidator ID="fieldType" ControlToValidate="ddlType"
                     ValidationGroup="Save" runat="server" InitialValue="-1"></asp:RequiredFieldValidator>
            </div>
        </div>
    </div>

    <div class="row">
        <div class="col-md-12">
            <div class="form-group">
                 <asp:Label ID="Label2" runat="server" CssClass="control-label col-md-3"
                    Text="Purchase Price"></asp:Label>
                <div class="col-md-4 input-icon">
                    <asp:TextBox runat="server" CssClass="form-control" ID="txtPurchase"></asp:TextBox>
                </div>
                  <asp:RequiredFieldValidator ID="reqPurchaseprice" ControlToValidate="txtPurchase" ValidationGroup="Save" runat="server" ErrorMessage="Purchase price Required" style="color:Red;">
                 </asp:RequiredFieldValidator>
               
            </div>
        </div>
    </div>

    
    <div class="row">
        <div class="col-md-12">
            <div class="form-group">
                
                 <asp:Label ID="Label3" runat="server" CssClass="control-label col-md-3"
                    Text="Sale Price Retail"></asp:Label>
                <div class="col-md-4">
                    <asp:TextBox runat="server" CssClass="form-control" ID="txtSell"></asp:TextBox>
                </div>
                 <asp:RequiredFieldValidator ID="salePriceeRetail" ControlToValidate="txtSell" ValidationGroup="Save" runat="server" ErrorMessage="Retail Sell price Required" style="color:Red;">
                 </asp:RequiredFieldValidator>
            </div>
        </div>
    </div>

   
 

    <div class="row">
        <div class="col-md-12">
            <div class="form-group">
            <asp:Label ID="Label4" runat="server" CssClass="control-label col-md-3"
                    Text="Sale Price Whole"></asp:Label>
                <div class="col-md-4">
                    <asp:TextBox runat="server" CssClass="form-control" ID="txtSaleWhole"></asp:TextBox>
                </div>
                     <asp:RequiredFieldValidator ID="ReqtxtSaleWhole" ControlToValidate="txtSaleWhole" ValidationGroup="Save" runat="server" ErrorMessage="Whole Sale price Required" style="color:Red;">
                 </asp:RequiredFieldValidator>
                </div>
         </div>
    </div>
     

     <div class="row">
        <div class="col-md-12">
            <div class="form-group">
                <div class="col-md-4">
                    <asp:Button ID="btnAdd" Text="Add Stock" ValidationGroup="Save" runat="server"
                        CssClass="btn btn-primary"  OnClick="btnAdd_Click"/>
                </div>
             
            </div>

        </div>
    </div>


    
	  </section>
     </aside>

</asp:Content>



