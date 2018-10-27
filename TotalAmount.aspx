<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TotalAmount.aspx.cs" Inherits="Store.TotalAmount" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
   <style type="text/css">
    .modalPopup
    {
        background-color: #ffffdd;
        border-width: 3px;
        border-style: solid;
        border-color: Gray;
        padding: 3px;
        width: 350px;
    }
    .modalBackground
    {
        background-color: Gray;
        filter: alpha(opacity=70);
        opacity: 0.7;
    }
</style>
<script type="text/javascript">
    function ok(sender, e) {
        $find('ModalPopupExtender1').hide();
        __doPostBack('editBox_OK', e);
    }
    function cancel(sender, e) {
        $find('ModalPopupExtender1').hide();
    }
    function pageLoad(sender, args) {
        //Note that the OnKeyPress event handler will not work unless you register it with the Microsoft AJAX Library. The best place to run this registration code is the pageLoad function, like so:
        
        $addHandler(document, "keydown", onKeyDown);
        $find("ModalPopupExtender1").add_showing(onModalShowing);
    }
    function onModalShowing(sender, args) {
        $get("pnlEditCustomer").style.backgroundColor = "yellow";
    }
    function onKeyDown(args) {
        //Closing the Popup Using the Esc Key
        if (args.keyCode == Sys.UI.Key.esc) {
            $find('ModalPopupExtender1').hide();
        }
    } 
</script>
</head>
<body>

    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"/>
    <div>
        <!--Using Partial Rendering to Update the Customer View -->
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <table>
                    <tr>
                        <td><b>Customer ID:</b></td>
                        <td><asp:Label runat="server" ID="lblCustomerID" Text="C00001"/></td>
                    </tr>
                    <tr>
                        <td><b>Company Name:</b></td>
                        <td><asp:Label runat="server" ID="lblCompanyName" Text="Eastern Connection"/></td>
                    </tr>
                    <tr>
                        <td><b>Contact Name:</b></td>
                        <td><asp:Label runat="server" ID="lblContactName" Text="Ann Devon"/></td>
                    </tr>
                    <tr>
                        <td><b>Country:</b></td>   
                        <td><asp:Label runat="server" ID="lblCountry" Text="Germany"/></td>
                    </tr>
                     <tr>
                        <td>
                            <asp:Button runat="server" ID="btnEditText" Text="Edit text" OnClick="btnEditText_Click" />
                        </td>
                        <td>
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="editBox_OK"/>
            </Triggers>
        </asp:UpdatePanel>
    </div>
    <div>
        <asp:Button runat="server" ID="hiddenTargetControlForModalPopup" Style="display: none" />
        <asp:UpdatePanel runat="server" ID="DialogBoxUpdatePanel" UpdateMode="Conditional">
            <ContentTemplate>
                
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    <div>
         <!-- Dialog box:: Edit customer info -->
         <!--The Content of a Modal Popup Supports Partial Rendering -->
        <asp:Panel ID="pnlEditCustomer" runat="server" CssClass="modalPopup" style="display:block;">
            <div style="margin:10px">
            <asp:UpdatePanel runat="server" ID="ModalPanel1" RenderMode="Inline" UpdateMode="Conditional"> 
                <ContentTemplate>
                <table>            
                    <tr>
                        <td><b>Customer ID:</b></td>
                        <td><asp:Label runat="server" id="editCustomerID" />
                        </td>
                    </tr>            
                    <tr>
                        <td><b>Company Name:</b></td>
                        <td><asp:TextBox runat="server" id="editTxtCompanyName" /></td>
                    </tr>
                    <tr>
                        <td><b>Contact Name:</b></td>
                        <td><asp:TextBox runat="server" id="editTxtContactName" /></td>
                    </tr>
                    <tr>
                        <td><b>Country:</b></td>
                        <td><asp:TextBox runat="server" id="editTxtCountry" /></td>
                    </tr>
                </table>   
                <hr />
                <asp:Button ID="btnApply" runat="server" Text="Apply" width="50px" OnClick="btnApply_Click"/>
                </ContentTemplate>
                </asp:UpdatePanel>              
                <asp:Button ID="editBox_OK" runat="server" Text="OK" width="50px" 
                    onclick="editBox_OK_Click"/>
                <asp:Button ID="editBox_Cancel" runat="server" Text="Cancel" width="50px" />
            </div>
        </asp:Panel>
    </div>
    <div>
        <asp:ModalPopupExtender ID="ModalPopupExtender1" runat="server"  
            TargetControlID="hiddenTargetControlForModalPopup"
            PopupControlID="pnlEditCustomer"
            BackgroundCssClass="modalBackground"
            DropShadow="false"
            OkControlID="editBox_OK"
            OnOkScript="ok()"
            OnCancelScript="cancel()"
            CancelControlID="editBox_Cancel" /> 
    </div>    
    </form>
</body>
</html>
