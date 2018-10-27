<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SearchCustomer.aspx.cs" Inherits="Store.SearchCustomer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
      <aside class="right-side">
                <!-- Content Header (Page header) -->
                <section class="content-header">
                    <h1>
                      Search Customer
                        <small>Control panel</small>
                    </h1>
                    <ol class="breadcrumb">
                        <li><a href="#"><i class="fa fa-dashboard"></i> Home</a></li>
                        <li class="active">Customers</li>
                    </ol>
                </section>
           <section class="content">
    <div class="row">
        <div class="col-md-12">
            <div class="form-group">
                <asp:Label ID="lblCompanyName" runat="server" CssClass="control-label col-md-2"
                    Text="Search Customer"></asp:Label>
                <div class="col-md-4 input-icon">
                    <asp:DropDownList ID="ddlStock"  OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" AutoPostBack="True" runat="server"></asp:DropDownList>
                    <asp:RequiredFieldValidator ID="fieldVal" ControlToValidate="ddlStock"
                     ValidationGroup="Save" runat="server"></asp:RequiredFieldValidator>
                </div>
                
                 </div>
        </div>
    </div>

    <div class="row">
        <div class="col-md-12">
            <div class="form-group">
               
                 <asp:Label ID="Label3" runat="server" CssClass="control-label col-md-2"
                    Text="Amount Due"></asp:Label>
                <div class="col-md-4 input-icon">
                <asp:TextBox runat="server" ReadOnly ="true" CssClass="form-control" ID="amountDue"></asp:TextBox>
                
                    </div>

               
            </div>
        </div>
    </div>
     <div class="row">
        <div class="col-md-12">
            <div class="form-group">
                 <asp:Label ID="Label1" runat="server" CssClass="control-label col-md-2"
                    Text="Amount Pay"></asp:Label>
                <div class="col-md-4 input-icon">
                <asp:TextBox runat="server"  CssClass="form-control" ID="amountPay"></asp:TextBox>
                
                    </div>
                  <asp:RequiredFieldValidator ID="reqName" ControlToValidate="amountPay" ValidationGroup="Save" runat="server" ErrorMessage="Enter Amount To pay - if the due amount zero insert 0" style="color:Red;">
                 </asp:RequiredFieldValidator> 

                
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

     </section>
          </aside><!-- /.right-side -->
</asp:Content>
















