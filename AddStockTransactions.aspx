<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddStockTransactions.aspx.cs" Inherits="Store.AddStockTransactions" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <aside class="right-side">
                <!-- Content Header (Page header) -->
                <section class="content-header">
                    <h1>
                     Add Stock Transaction
                        <small>Control panel</small>
                    </h1>
                    <ol class="breadcrumb">
                        <li><a href="#"><i class="fa fa-dashboard"></i> Home</a></li>
                        <li class="active">Stock</li>
                    </ol>
                </section>
<section class="content" ID = "SECTION"  runat="server">
    
    <div class="row">
        <div class="col-md-12">
            <div class="form-group">
                 <asp:Label ID="Label6" runat="server" CssClass="control-label col-md-2"
                    Text="Supplier Name"></asp:Label>
                <div class="col-md-4">
                    <asp:DropDownList ID="ddlSupplier" runat="server"></asp:DropDownList>
                 </div>
            </div>
        </div>
    </div>

   
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
             </div>
        </div>
    </div>

    <div class="row">
        <div class="col-md-12">
            <div class="form-group">
                 <asp:Label ID="Label2" runat="server" CssClass="control-label col-md-2"
                    Text="Quantity"></asp:Label>
                <div class="col-md-4 input-icon">
                <asp:TextBox runat="server" CssClass="form-control" ID="txtQuantity"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="txtQuantity"
                     ValidationGroup="Save" runat="server"></asp:RequiredFieldValidator>
                    </div>
                <asp:Label ID="Label3" runat="server" CssClass="control-label col-md-2"
                    Text="AMOUNT"></asp:Label>
                <div class="col-md-4 input-icon">
                <asp:TextBox runat="server" CssClass="form-control" ID="AMOUNT"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="AMOUNT"
                     ValidationGroup="Save" runat="server"></asp:RequiredFieldValidator>
                    </div>
            </div>
        </div>
    </div>
     <div class="row">
        <div class="col-md-12">
            <div class="form-group">
               
               <div class="col-md-4">
                    <asp:Button ID="Button1" Text="ADD" ValidationGroup="Save" runat="server"
                        CssClass="btn btn-primary"  OnClick="btnAdd_Click"/>
                </div>
            </div>
        </div>
    </div>


   
     <div class="row">
     <asp:GridView ID="SaleStockTrans" runat="server"
        AutoGenerateColumns="False"
        BorderWidth="1px" BackColor="#DEBA84"
        CellPadding="3" CellSpacing="3" BorderStyle="None" 
        BorderColor="#DEBA84"
           OnRowDataBound = "OnRowDataBound"
        OnRowDeleting="OnRowDeleting">
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
            <asp:BoundField HeaderText="Quantity"
                DataField="QUANTITY"
                SortExpression="QuantityPerUnit"></asp:BoundField>
             <asp:BoundField HeaderText="Amount"
                DataField="Amount"
                SortExpression="Amount"></asp:BoundField>   
             <asp:CommandField ShowDeleteButton="True" ButtonType="Button" />    
        </Columns>

        <SelectedRowStyle ForeColor="White" Font-Bold="True"
            BackColor="#738A9C"></SelectedRowStyle>
        <RowStyle ForeColor="#8C4510"
            BackColor="#FFF7E7"></RowStyle>
    </asp:GridView>
         <div class="col-md-4">
                    <asp:Button ID="saveStock" Text="SAVE"  runat="server"
                        CssClass="btn btn-primary"  OnClick="btnSave_Click"/>
           </div>
    </div>
                 
                  
                
     </section>
<section runat="server" id ="paymentSection" style="margin-left:130px;margin-top:130px">
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
                <asp:TextBox runat="server" CssClass="form-control" ID="Amountpaid" OnTextChanged="txtQuantity_TextChanged" AutoPostBack="true"></asp:TextBox>
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
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="AmountDue"
                     ValidationGroup="Save" runat="server"></asp:RequiredFieldValidator>
                 </div>
             </div>
         </div>
     </div>
    <div class="row">
        <div class="col-md-12">
            <div class="form-group">
               
               <div class="col-md-4">
                    <asp:Button ID="Button2" Text="Pay" ValidationGroup="Pay"  runat="server"
                        CssClass="btn btn-primary"  OnClick="btnPay_Click"/>
                </div>
                  <div class="col-md-4">
                    <asp:Button ID="Button3" Text="Edit" ValidationGroup="Edit" runat="server"
                        CssClass="btn btn-primary"  OnClick="btnEdit_Click"/>
                </div>
            </div>
        </div>
    </div>
    </section>
   </aside> 
</asp:Content>




