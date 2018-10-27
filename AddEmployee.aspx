<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddEmployee.aspx.cs" Inherits="Store.AddEmployee" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<aside class="right-side">
                <!-- Content Header (Page header) -->
                <section class="content-header">
                    <h1>
                      Add New Employee
                        <small>Control panel</small>
                    </h1>
                    <ol class="breadcrumb">
                        <li><a href="#"><i class="fa fa-dashboard"></i> Home</a></li>
                        <li class="active">Employee</li>
                    </ol>
                </section>
           <section class="content">
    <div class="row">
        <div class="col-md-12">
            <div class="form-group">

                 <asp:Label ID="Label4" runat="server" CssClass="control-label col-md-3"
                    Text="Customer Name"></asp:Label>
                <div class="col-md-4 input-icon">
                 <asp:TextBox runat="server" CssClass="form-control" ID="customerName"></asp:TextBox>
                    </div>
               
                 <asp:RequiredFieldValidator ID="reqName" ControlToValidate="customerName" ValidationGroup="Save" runat="server" ErrorMessage="Name Required" style="color:Red;">
                 </asp:RequiredFieldValidator>
                
            </div>
        </div>
    </div>
 <div class="row">
        <div class="col-md-12">
            <div class="form-group">
                 <asp:Label ID="Label5" runat="server" CssClass="control-label col-md-3"
                    Text="Phone"></asp:Label>
                <div class="col-md-4">
                    <asp:TextBox runat="server" CssClass="form-control" ID="phoneNumber"></asp:TextBox>
                </div>
                  <asp:RequiredFieldValidator ID="Phone" ControlToValidate="phoneNumber" ValidationGroup="Save" runat="server" ErrorMessage="Phone Number Required" style="color:Red;">
                 </asp:RequiredFieldValidator>
                 <asp:RegularExpressionValidator runat="server" 
                    ControlToValidate="phoneNumber" 
                    ValidationGroup="Save"
                    ErrorMessage="Please enter a valid phone number."
                    ValidationExpression="^\(?([0-9]{3})\)?[-.●]?([0-9]{3})[-.●]?([0-9]{4})$" style="color:Red;">
                  </asp:RegularExpressionValidator>
               
                
                
               
            </div>
        </div>
    </div>



    <div class="row">
        <div class="col-md-12">
            <div class="form-group">
                 <asp:Label ID="Label9" runat="server" CssClass="control-label col-md-3"
                    Text="CNIC"></asp:Label>
                <div class="col-md-4 input-icon">
                 <asp:TextBox runat="server" CssClass="form-control" ID="cnic"></asp:TextBox>
                    </div>
                 <asp:RegularExpressionValidator runat="server" 
                    ControlToValidate="cnic" 
                    ValidationGroup="Save"
                    ErrorMessage="Please enter a valid CNIC without space."
                    ValidationExpression="^[0-9]{13}$" style="color:Red;">
                  </asp:RegularExpressionValidator>
                
            </div>
        </div>
    </div>
     <div class="row">
        <div class="col-md-12">
            <div class="form-group">               
                <asp:Label ID="Label10" runat="server" CssClass="control-label col-md-3"
                    Text="Address"></asp:Label>
                <div class="col-md-4">
                    <asp:TextBox runat="server" CssClass="form-control" ID="address"></asp:TextBox>
                </div>
                 <asp:RequiredFieldValidator ID="Adress" ControlToValidate="address" ValidationGroup="Save" runat="server" ErrorMessage="Address Required" style="color:Red;">
                 </asp:RequiredFieldValidator>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-md-12">
            <div class="form-group">
                <div class="col-md-4">
                    <asp:Button ID="btnAdd" Text="Add Customer" ValidationGroup="Save" runat="server"
                        CssClass="btn btn-primary"   />
                </div>
             
            </div>

        </div>
    </div>
               </section>
          </aside>
</asp:Content>

