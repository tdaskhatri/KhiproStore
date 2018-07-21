<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddSystemStock.aspx.cs"
     MasterPageFile="~/WebForms/BasePage.Master"
  Inherits="Store.WebForms.Admin.AddSystemStock" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="row">
        <div class="col-md-12">
            <div class="form-group">
                <asp:Label ID="lblCompanyName" runat="server" CssClass="control-label col-md-2"
                    Text="Stock Name"></asp:Label>
                <div class="col-md-4 input-icon">
                    <asp:TextBox runat="server" CssClass="form-control" ID="txtStockName"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="fieldVal" ControlToValidate="txtStockName"
                     ValidationGroup="Save" runat="server"></asp:RequiredFieldValidator>
                </div>
                
                <asp:Label ID="Label1" runat="server" CssClass="control-label col-md-2"
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
                 <asp:Label ID="Label2" runat="server" CssClass="control-label col-md-2"
                    Text="Purchase Price"></asp:Label>
                <div class="col-md-4 input-icon">
                    <asp:TextBox runat="server" CssClass="form-control" ID="txtPurchase"></asp:TextBox>
                </div>
                <asp:Label ID="Label3" runat="server" CssClass="control-label col-md-2"
                    Text="Sale Price Retail"></asp:Label>
                <div class="col-md-4">
                    <asp:TextBox runat="server" CssClass="form-control" ID="txtSell"></asp:TextBox>
                </div>
            </div>
        </div>
    </div>

   
 

    <div class="row">
        <div class="col-md-12">
            <div class="form-group">
            <asp:Label ID="Label4" runat="server" CssClass="control-label col-md-2"
                    Text="Sale Price Whole"></asp:Label>
                <div class="col-md-4">
                    <asp:TextBox runat="server" CssClass="form-control" ID="txtSaleWhole"></asp:TextBox>
                </div>
                    <asp:Button ID="btnAdd" Text="Save" ValidationGroup="Save" runat="server"
                        CssClass="btn btn-primary"  OnClick="btnAdd_Click"/>
                </div>
                </div>
    </div>

</asp:Content>


