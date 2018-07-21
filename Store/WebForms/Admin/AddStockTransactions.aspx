<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddStockTransactions.aspx.cs"
    MasterPageFile="~/WebForms/BasePage.Master"
     Inherits="Store.WebForms.Admin.AddStockTransactions" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="row">
        <div class="col-md-12">
            <div class="form-group">
                <asp:Label ID="lblCompanyName" runat="server" CssClass="control-label col-md-2"
                    Text="Stock Name"></asp:Label>
                <div class="col-md-4 input-icon">
                    <asp:DropDownList ID="ddlStock" runat="server"></asp:DropDownList>
                    <asp:RequiredFieldValidator ID="fieldVal" ControlToValidate="ddlStock"
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
                    Text="Supplier Name"></asp:Label>
                <div class="col-md-4 input-icon">
                <asp:TextBox runat="server" CssClass="form-control" ID="txtQuantity"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="txtQuantity"
                     ValidationGroup="Save" runat="server"></asp:RequiredFieldValidator>
                    </div>
                <asp:Label ID="Label3" runat="server" CssClass="control-label col-md-2"
                    Text="Total Amount"></asp:Label>
                <div class="col-md-4">
                    <asp:TextBox runat="server" CssClass="form-control" ID="txtTotalAmount"></asp:TextBox>
                </div>
            </div>
        </div>
    </div>

    <div class="row">
        <div class="col-md-12">
            <div class="form-group">
                 <asp:Label ID="Label4" runat="server" CssClass="control-label col-md-2"
                    Text="Amount Paid"></asp:Label>
                <div class="col-md-4 input-icon">
                 <asp:TextBox runat="server" CssClass="form-control" ID="txtAmountPaid"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="ddlType"
                     ValidationGroup="Save" runat="server"></asp:RequiredFieldValidator>
                    </div>
                <asp:Label ID="Label5" runat="server" CssClass="control-label col-md-2"
                    Text="Amount Due"></asp:Label>
                <div class="col-md-4">
                    <asp:TextBox runat="server" CssClass="form-control" ID="txtAmountDue"></asp:TextBox>
                </div>
            </div>
        </div>
    </div>

    <div class="row">
        <div class="col-md-12">
            <div class="form-group">
                 <asp:Label ID="Label6" runat="server" CssClass="control-label col-md-2"
                    Text="Supplier Name"></asp:Label>
                <div class="col-md-4">
                <asp:DropDownList ID="ddlSupplier" runat="server"></asp:DropDownList>
                    </div>
                <div class="col-md-4">
                    <asp:Button ID="btnAdd" Text="Save" ValidationGroup="Save" runat="server"
                        CssClass="btn btn-primary"  OnClick="btnAdd_Click"/>
                </div>
                 
            </div>
        </div>
    </div>

  
</asp:Content>




