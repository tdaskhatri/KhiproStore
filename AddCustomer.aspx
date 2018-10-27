
<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddCustomer.aspx.cs" Inherits="Store.AddCustomer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script type ="text/javascript">
    function chkvalidation()  
        {  
            var exitval = false;  
            var rsltcount = 0;  
            var msgtext = "";       
            //Mobile Validation  
            var mobileval = document.getElementById("<%= phoneNumber.ClientID %>").value;  
            var mobilerslt = false;  
            if ( mobileval.length != 10){  
                msgtext = msgtext + "\n Invalid mobile number ";  
                rsltcount += 1  
            }  
            else {  
                mobilerslt = OnlyNumbers(document.getElementById("<%= phoneNumber.ClientID %>"));  
                if (mobilerslt == false) {  
                    msgtext = msgtext + "\n Invalid mobile number or mobile number required.";  
                    rsltcount += 1  
                }  
            }  
        // Name Validation
        if (document.getElementById("<%= customerName.ClientID %>").value == "") {;
            alert("Name Feild can not be blank");
            
                 return false;
        }/////CNIC Validation
         //Mobile Validation  
            var cnicval = document.getElementById("<%= cnic.ClientID %>").value;  
            var cnicrslt = false;  
            if (cnicval.length > 0 && cnicval.length != 13) {
                msgtext = msgtext + "\n Invalid CNIC number ";  
                rsltcount += 1  
            }  
            else {  
               
            }  
  
            if (rsltcount > 0)  
            {  
                exitval = false;  
            }  
            else  
            {  
                exitval = true;  
            }  
              
            alert(msgtext);  
            return exitval;  
            }  
    </script>
          <aside class="right-side">
                <!-- Content Header (Page header) -->
                <section class="content-header">
                    <h1>
                      Add Customer
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
                        CssClass="btn btn-primary"  OnClick="btnAdd_Click" />
                </div>
             
            </div>

        </div>
    </div>
               </section>
          </aside>
</asp:Content>

