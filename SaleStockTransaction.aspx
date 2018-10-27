<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SaleStockTransaction.aspx.cs" Inherits="Store.SaleStockTransaction" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
 <aside class="right-side">
   <section class="content-header">
        <h1>
            Sale Stock Transaction
            <small>Control panel</small>
        </h1>
        <ol class="breadcrumb">
            <li><a href="#"><i class="fa fa-dashboard"></i> Home</a></li>
             <li class="active">Stock</li>
         </ol>
    </section>


<section class="content" id ="main_section" runat="server">
      <div class="row">
        <div class="col-md-12">
            <div class="form-group">
                <asp:Label ID="CustomerName" runat="server" CssClass="control-label col-md-2"
                    Text="Customer Name"></asp:Label>
                <div class="col-md-4 input-icon">
                    <asp:DropDownList ID="ddlcustomer" runat="server"></asp:DropDownList>
                    <asp:RequiredFieldValidator ID="customer" ControlToValidate="ddlcustomer"
                        ValidationGroup="ADD" runat="server"></asp:RequiredFieldValidator>
                </div>
            </div>
        </div>
    </div>

    <div class="row">
        <div class="col-md-12">
            <div class="form-group">
                <asp:Label ID="StockName" runat="server" CssClass="control-label col-md-2"
                    Text="Stock Name"></asp:Label>
                <div class="col-md-4 input-icon">
                    <asp:DropDownList ID="ddlStock" runat="server"></asp:DropDownList>
                    <asp:RequiredFieldValidator ID="fieldVal" ControlToValidate="ddlStock"
                        ValidationGroup="ADD" runat="server"></asp:RequiredFieldValidator>
                </div>

                
            </div>
        </div>
    </div>

    <div class="row">
        <div class="col-md-12">
            <div class="form-group">
                <asp:Label ID="Label2" runat="server" CssClass="control-label col-md-2"
                    Text="Quantity"></asp:Label>
                <div class="col-md-4 input-icon">
                    <asp:TextBox runat="server" CssClass="form-control" ID="txtQuantity" onClick="Onclick_method" OnTextChanged="txtQuantity_TextChanged" AutoPostBack="true"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="txtQuantity"
                        ValidationGroup="ADD" runat="server"></asp:RequiredFieldValidator>
                </div>
               <asp:Label ID="QuantityMax" runat="server" CssClass="control-label col-md-2"
                    Text=""></asp:Label>
            </div>
        </div>
    </div>
  <div class="row">
        <div class="col-md-12">
            <div class="form-group">
          <asp:Label ID="Label3" runat="server" CssClass="control-label col-md-2"
                    Text="Total Amount"></asp:Label>
                <div class="col-md-4">
                    <asp:TextBox runat="server" ReadOnly="true" CssClass="form-control" ID="txtAmount"></asp:TextBox>
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
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtDiscount"
                        ValidationGroup="ADD" runat="server"></asp:RequiredFieldValidator>
                </div>
                <div class="col-md-4">
                    <asp:Button ID="btnAdd" Text="Add"  runat="server"
                        CssClass="btn btn-primary" ValidationGroup="ADD" OnClick="btnAdd_Click" />
                </div>

            </div>
        </div>
    </div>

    <asp:GridView ID="SaleStockTrans" runat="server"
        AutoGenerateColumns="False"
        BorderWidth="1px" BackColor="#DEBA84"
        CellPadding="3" CellSpacing="2" BorderStyle="None"
        BorderColor="#DEBA84"
          OnRowDataBound = "OnRowDataBound"
        OnRowDeleting="OnRowDeleting"
      >
        <FooterStyle ForeColor="#8C4510"
            BackColor="#F7DFB5"></FooterStyle>
        <PagerStyle ForeColor="#8C4510"
            HorizontalAlign="Center"></PagerStyle>
        <HeaderStyle ForeColor="White" Font-Bold="True"
            BackColor="#A55129"></HeaderStyle>
        <Columns>
             <asp:BoundField HeaderText="Stock ID"
                DataField="STOCK_ID"
                SortExpression="ProductName"></asp:BoundField>
            <asp:BoundField HeaderText="Stock Name"
                DataField="STOCK_NAME"
                SortExpression="ProductName"></asp:BoundField>
            <asp:BoundField HeaderText="Qty"
                DataField="QUANTITY"
                SortExpression="QuantityPerUnit"></asp:BoundField>
            <asp:BoundField HeaderText="Price"
                DataField="AMOUNT" SortExpression="AMOUNT">
                <ItemStyle HorizontalAlign="Right"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField HeaderText="Discount"
                DataField="DISCOUNT"
                SortExpression="UnitsInStock"
                DataFormatString="{0:d}">
                <ItemStyle HorizontalAlign="Right"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField HeaderText="Net Amount"
                DataField="NET_AMOUNT"
                SortExpression="AMOUNT"
            >
                <ItemStyle HorizontalAlign="Right"></ItemStyle>
            </asp:BoundField>
            <asp:CommandField ShowDeleteButton="True" ButtonType="Button" />
        </Columns>
        <SelectedRowStyle ForeColor="White" Font-Bold="True"
            BackColor="#738A9C"></SelectedRowStyle>
        <RowStyle ForeColor="#8C4510"
            BackColor="#FFF7E7"></RowStyle>
    </asp:GridView>

    <div class="col-md-4">
                    <asp:Button ID="btnPrint" Text="Print Bill"  CausesValidation="false" runat="server"
                        CssClass="btn btn-primary" OnClick="btnPrint_Click" />
  </div>
 </section>
<section id ="bill_section" runat="server" style="margin-left:130px;margin-top:130px">
     <div class="row" >
        <div class="col-md-12">
            <div class="form-group">
                <asp:Label ID="displaymsg" runat="server" CssClass="control-label col-md-2" Style="color:red"
                    Text=""></asp:Label>
                 <asp:Label ID="displaymsg1" runat="server" CssClass="control-label col-md-2" Style="color:red"
                    Text=""></asp:Label>
                
             </div>
         </div>
     </div>
     <div class="row" >
        <div class="col-md-12">
            <div class="form-group">
                <asp:Label ID="Label1" runat="server" CssClass="control-label col-md-2"
                    Text="Total Bill"></asp:Label>
                <div class="col-md-4 input-icon">
                <asp:TextBox runat="server" ReadOnly="true" CssClass="form-control" ID="totalAmount"></asp:TextBox>
                 </div>
             </div>
         </div>
     </div>
     
  <div class="row" >
        <div class="col-md-12">
            <div class="form-group">
                <asp:Label ID="Label4" runat="server" CssClass="control-label col-md-2"
                    Text="Make Payment"></asp:Label>
                <div class="col-md-4 input-icon">
                <asp:TextBox runat="server" CssClass="form-control" ID="Amountpaid" OnTextChanged="Amount_TextChanged" AutoPostBack="true"></asp:TextBox>
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="Amountpaid"
                     ValidationGroup="Pay" runat="server"></asp:RequiredFieldValidator>
                 </div>
             </div>
         </div>
     </div>
         <div class="row" >
        <div class="col-md-12">
            <div class="form-group">
                <asp:Label ID="Label5" runat="server" CssClass="control-label col-md-2"
                    Text="Amount Due"></asp:Label>
                <div class="col-md-4 input-icon">
                <asp:TextBox runat="server" ReadOnly="true" CssClass="form-control" ID="AmountDue"></asp:TextBox>
                   
                 </div>
             </div>
         </div>
     </div>
    <div class="row">
        <div class="col-md-12">
            <div class="form-group">
               
               <div class="col-md-4">
                    <asp:Button ID="Pay" Text="Pay" ValidationGroup="Pay"  OnClick="btnPay_Click" runat="server"
                        CssClass="btn btn-primary" />
                </div>
                  <div class="col-md-4">
                    <asp:Button ID="Button3" Text="Edit" ValidationGroup="Edit" OnClick="btnEdit_Click" runat="server"
                        CssClass="btn btn-primary"  />
                </div>
            </div>
        </div>
    </div>

</section>    

 </aside>
</asp:Content>

