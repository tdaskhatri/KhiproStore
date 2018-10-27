<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SaleReports.aspx.cs" Inherits="Store.SaleReports" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<style>
    .mGrid { 
    width: 100%; 
    background-color: #fff; 
     
    border: solid 1px #525252; 
    border-collapse:collapse; 
    margin-left:30px;
}
    .mGrid td { 
    padding: 2px; 
    border: solid 1px #c1c1c1; 
    color: #717171; 
}
    .mGrid th { 
    padding: 2px 2px; 
    color: #fff; 
    background-color: #3c8dbc;
    border-color: #367fa9;
    border-left: solid 1px #525252; 
    font-size: 1.2em; 
    text-align: Center;
}
.mGrid .alt { background: #fcfcfc url(grd_alt.png) repeat-x top; }
.mGrid .pgr { background: #424242 url(grd_pgr.png) repeat-x top; }
.mGrid .pgr table { margin: 5px 5px; }
.mGrid .pgr td { 
    border-width: 0; 
    padding: 8px 6px; 
    border-left: solid 1px #666; 
    font-weight: bold; 
    color: #fff; 
    line-height: 12px; 
    text-align: Center;
 }   
.mGrid .pgr a { color: #666; text-decoration: none; }
.mGrid .pgr a:hover { color: #000; text-decoration: none; }
</style>
<script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.9.1/jquery.min.js"></script>
<script type="text/javascript" src="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
<link rel="stylesheet" href="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" />

    <aside class="right-side">
   <section class="content-header">
        <h1>
            Sale Reports
            <small>Report  panel</small>
        </h1>
        <ol class="breadcrumb">
            <li><a href="#"><i class="fa fa-dashboard"></i> Home</a></li>
             <li class="active">Reports</li>
         </ol>
    </section>
     <section class="content" id ="main_section" runat="server">
      <div class="row">
        <div class="col-md-12">
            <div class="form-group">
                <asp:Label ID="FromDate" runat="server" CssClass="control-label col-md-2"
                    Text="From Date"></asp:Label>
                <div class="col-md-4 input-icon">
                  <input type="date" id="datepicker1" value="YYYY-MM-DD" runat="server">
                </div>
                 <asp:Label ID="Label2" runat="server" CssClass="control-label col-md-2"
                    Text="To Date"></asp:Label>
                 <div class="col-md-4 input-icon">
                  <input type="date" id="datepicker2" value="YYYY-MM-DD"  runat="server">
                </div>
            </div>
        </div>
    </div>
<div class="row">
        <div class="col-md-12">
            <div class="form-group">
               
               <div class="col-md-4">
                   <asp:Button ID="Button1" Text="Today Report"  runat="server"
                        CssClass="btn btn-primary"  OnClick="btnSaleReportDetail_Click"/>
                    <asp:Button ID="Generate" Text="Generate Report" ValidationGroup="Save" runat="server"
                        CssClass="btn btn-primary" Style="margin-left:40px"   OnClick="btnSaleReport_Click"/>
                </div>
            </div>
        </div>
 </div>
<div class="row" runat="server" id="sale_total" visible="false" style="margin-left:520px">
        <div class="col-md-12">
            <div class="form-group">
              <asp:Label ID="Button2" Text="Total Sale"  runat="server" Style="font:bold;" 
                          />
                    <asp:Label ID="Label_Total_sale" Text="Generate Report" runat="server"
                         Style="margin-left:40px"/>
                <asp:Button ID="Button3" Text="Print Report"  runat="server"
                        CssClass="btn btn-primary"  OnClick="btnSaleReportPrint_Click"/>
              

           </div>  
        </div>
 </div>
          
    </section>

     <section id ="total_sale" runat="server" style="margin-right:50px;">
       <asp:GridView ID="SaleStockTrans" runat="server"
        AutoGenerateColumns="False"
           GridLines="None"
    AllowPaging="true"
            emptydatatext="No data in the data source."
       ShowHeaderWhenEmpty="True"
       CssClass="mGrid"
         PagerStyle-CssClass="pgr"
        AlternatingRowStyle-CssClass="alt"
         
      >
    
        <Columns>
                <asp:BoundField HeaderText="ID"
                DataField="ID"
                ></asp:BoundField>
             <asp:BoundField HeaderText="Customer Name"
                DataField="NAME"
                ></asp:BoundField>
            <asp:BoundField HeaderText="Total Amount"
                DataField="TOTAL_AMOUNT"></asp:BoundField>
            <asp:BoundField HeaderText="Amount Paid"
                DataField="AMOUNT_PAID" ></asp:BoundField>
            <asp:BoundField HeaderText="Date"
                DataField="CREATED_ON" > 
                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                
            </asp:BoundField>
             <asp:TemplateField HeaderText="Detail">
                    <ItemTemplate>
                    <asp:LinkButton ID="lnkBtnEdit" runat="server" Text="Detail" CssClass="btn btn-info"
                            OnClick="Display"></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            
        
        </Columns>

    </asp:GridView>
         </section>

    <div class="modal fade" id="myModal" role="dialog" style="margin-top: 100px;">
            <div class="modal-dialog" style="width: 800px;">
                <!-- Modal content-->
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal">
                            &times;</button>
                        <h4 class="modal-title">
                           <asp:Label ID="CustName" runat="server"></asp:Label></h4>
                    </div>
                  <asp:GridView ID="GridView1" runat="server"
                   AutoGenerateColumns="False"
                   GridLines="None"
                   AllowPaging="true"
                        emptydatatext="No data in the data source."
      
                        ShowHeaderWhenEmpty="True"
                       
                   CssClass="mGrid"
                      width="90%"
                   PagerStyle-CssClass="pgr"
                    AlternatingRowStyle-CssClass="alt"
                       >
    
        <Columns>
                <asp:BoundField HeaderText="Stock Name"
                DataField="NAME"
                ></asp:BoundField>
             <asp:BoundField HeaderText="Quantity"
                DataField="QUANTITY"
                ></asp:BoundField>
            <asp:BoundField HeaderText="Amount"
                DataField="AMOUNT"></asp:BoundField>
            <asp:BoundField HeaderText="CREATED_ON"
                DataField="CREATED_ON" ></asp:BoundField>
        </Columns>
        </asp:GridView>
<div class="modal-footer">
    <asp:Button ID="btnSave" runat="server" Text="Print" OnClick="btnPrint_Click" CssClass="btn btn-info" />
     <asp:Button ID="btnClose" runat="server" Text="Close" OnClick="btnClose_Click" CssClass="btn btn-info" />
</div>
</div>
            </div>
            <script type='text/javascript'>
                function openModal() {
                    $('[id*=myModal]').modal('show');
                } 
            </script>
        </div>
               

</aside>
</asp:Content>
