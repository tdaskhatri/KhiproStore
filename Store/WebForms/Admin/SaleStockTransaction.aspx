<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SaleStockTransaction.aspx.cs"
    MasterPageFile="~/WebForms/BasePage.Master"
    Inherits="Store.WebForms.Admin.SaleStockTransaction" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

   <%-- <asp:ToolKitScriptManager ID="ScriptManager1" runat="server">
</asp:ToolKitScriptManager>--%>

    <asp:Button ID="btnShow" runat="server" Text="Show Modal Popup" />
    <!-- ModalPopupExtender -->
    <asp:ModalPopupExtender id="mp1" runat="server" popupcontrolid="Panel1" targetcontrolid="btnShow"
        cancelcontrolid="btnClose" backgroundcssclass="modalBackground">
</asp:ModalPopupExtender>
    <asp:Panel ID="Panel1" runat="server" CssClass="modalPopup" align="center" Style="display: none">
        <div style="height: 100px">
            Do you like this product?&nbsp;
       
        </div>
        <asp:Button ID="btnClose" runat="server" Text="Close" />
    </asp:Panel>

    <div class="row">
        <div class="col-md-12">
            <div class="form-group">
                <asp:Label ID="StockName" runat="server" CssClass="control-label col-md-2"
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
                    Text="Quantity"></asp:Label>
                <div class="col-md-4 input-icon">
                    <asp:TextBox runat="server" CssClass="form-control" ID="txtQuantity" OnTextChanged="txtQuantity_TextChanged" AutoPostBack="true"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="txtQuantity"
                        ValidationGroup="Save" runat="server"></asp:RequiredFieldValidator>
                </div>
                <asp:Label ID="Label3" runat="server" CssClass="control-label col-md-2"
                    Text="Total Amount"></asp:Label>
                <div class="col-md-4">
                    <asp:TextBox runat="server" CssClass="form-control" ID="txtAmount"></asp:TextBox>
                </div>
            </div>
        </div>
    </div>

    <div class="row">
        <div class="col-md-12">
            <div class="form-group">
                <asp:Label ID="Label6" runat="server" CssClass="control-label col-md-2"
                    Text="Discount"></asp:Label>
                <div class="col-md-4">
                    <asp:TextBox runat="server" CssClass="form-control" ID="txtDiscount"></asp:TextBox>
                </div>
                <div class="col-md-4">
                    <asp:Button ID="btnAdd" Text="Add" ValidationGroup="Save" runat="server"
                        CssClass="btn btn-primary" OnClick="btnAdd_Click" />
                </div>

                <div class="col-md-4">
                    <asp:Button ID="btnPrint" Text="Print Bill"  CausesValidation="false" runat="server"
                        CssClass="btn btn-primary" OnClick="btnPrint_Click" />
                </div>

            </div>
        </div>
    </div>

    <asp:GridView ID="SaleStockTrans" runat="server"
        AutoGenerateColumns="False"
        BorderWidth="1px" BackColor="#DEBA84"
        CellPadding="3" CellSpacing="2" BorderStyle="None"
        BorderColor="#DEBA84">
        <FooterStyle ForeColor="#8C4510"
            BackColor="#F7DFB5"></FooterStyle>
        <PagerStyle ForeColor="#8C4510"
            HorizontalAlign="Center"></PagerStyle>
        <HeaderStyle ForeColor="White" Font-Bold="True"
            BackColor="#A55129"></HeaderStyle>
        <Columns>

            <asp:BoundField HeaderText="Stock Name"
                DataField="STOCK_NAME"
                SortExpression="ProductName"></asp:BoundField>
            <asp:BoundField HeaderText="Qty/Unit"
                DataField="QUANTITY"
                SortExpression="QuantityPerUnit"></asp:BoundField>
            <asp:BoundField HeaderText="Price/Unit"
                DataField="AMOUNT" SortExpression="AMOUNT">
                <ItemStyle HorizontalAlign="Right"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField HeaderText="Discount"
                DataField="DISCOUNT"
                SortExpression="UnitsInStock"
                DataFormatString="{0:d}">
                <ItemStyle HorizontalAlign="Right"></ItemStyle>
            </asp:BoundField>
        </Columns>
        <SelectedRowStyle ForeColor="White" Font-Bold="True"
            BackColor="#738A9C"></SelectedRowStyle>
        <RowStyle ForeColor="#8C4510"
            BackColor="#FFF7E7"></RowStyle>
    </asp:GridView>

    <div class="container-fluid">
        <div class="row" style="margin-left: 800px;">
            <div class="col-md-6 text-right">
                <%--<button type="button" class="btn btn-warning custom-button-width .navbar-right">z2</button>--%>
                <%--<button type="button" class="btn btn-primary custom-button-width">Save</button>--%>
                <asp:Button ID="Save" Text="Save" ValidationGroup="Save" runat="server"
                    CssClass="btn btn-primary custom-button-width" OnClick="Save_Click" />
            </div>
        </div>
    </div>

</asp:Content>
