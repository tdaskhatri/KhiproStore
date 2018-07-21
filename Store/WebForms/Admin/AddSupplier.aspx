<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddSupplier.aspx.cs"
    MasterPageFile="~/WebForms/BasePage.Master"
     Inherits="Store.WebForms.Admin.AddSupplier" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

  
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
</asp:Content>





