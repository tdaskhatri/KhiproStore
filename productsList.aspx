<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="productsList.aspx.cs" Inherits="Store.productsList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <aside class="right-side">
                
                <section class="content-header">
                    <h1>
                      Product List
                        <small>Control panel</small>
                    </h1>
                    <ol class="breadcrumb">
                        <li><a href="#"><i class="fa fa-dashboard"></i> Home</a></li>
                        <li class="active">Product</li>
                    </ol>
                </section>
           <section class="content">
         
           <div>
               <asp:GridView ID="StockList" runat="server" AutoGenerateColumns="false">
                   <Columns>
                   <asp:BoundField DataField="NAME" HeaderText="NAME"/>
                   <asp:BoundField DataField="CREATED_ON" HeaderText="CREATED_ON"/>
                   <asp:BoundField DataField="CURRENT_QUANTITY" HeaderText="CURRENT_QUANTITY"/>
                   <asp:BoundField DataField="PURCHASE_PRICE" HeaderText="PURCHASE_PRICE"/>
                   <asp:BoundField DataField="SELL_PRICE_RETAIL" HeaderText="SELL_PRICE_RETAIL"/>
                    </Columns>
                </asp:GridView>
            </div>

               
               </section>
          </aside>
        
</asp:Content>
