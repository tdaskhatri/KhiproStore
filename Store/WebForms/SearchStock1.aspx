<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SearchStock.aspx.cs"
    MasterPageFile="~/WebForms/BasePage.Master"
    Inherits="Store.WebForms.SearchStock" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="row">
        <div class="col-md-12">
            <div class="form-group">
                <asp:Label ID="lblCompanyName" runat="server" CssClass="control-label col-md-2"
                    Text="Stock Name"></asp:Label>
                <div class="col-md-4 input-icon">
                    <asp:TextBox runat="server" CssClass="form-control" ID="txtStockName"></asp:TextBox>
                </div>

                <div class="col-md-6">
                    <asp:Button ID="btnAdd" runat="server" CssClass="btn btn-primary" class="btn yellow" Text="Add" ValidationGroup="Save"  />
                    <asp:Button ID="btnSearch" runat="server" class="btn yellow" Text="Search"  />
                </div>
            </div>
        </div>
    </div>

    <div class="grid-view">
        <%--<asp:GridView ID="gvStock" runat="server" AutoGenerateColumns="False"
            CellPadding="0" EnableTheming="False"
            EmptyDataText="<%$ Resources:Messages, NoRecordsToShow_EmptyDataMsg %>"
            ShowHeader="true" 
            CssClass="table table-striped table-bordered table-hover default-grid"
            BorderStyle="Solid" ShowHeaderWhenEmpty="true" AllowPaging="false" PageSize="10">
            <Columns>
                <asp:BoundField DataField="ID" HeaderStyle-CssClass="hideGridColumn"
                    ItemStyle-CssClass="hideGridColumn"
                    HeaderText="<%$ Resources:Messages, StockSearSearch_lblID %>">
                    <HeaderStyle Width="10%" />
                </asp:BoundField>
                <asp:BoundField DataField="STOCK_NAME"
                    HeaderText="<%$ Resources:Messages, StockSearSearch_lblItem %>">
                    <HeaderStyle Width="10%" />
                </asp:BoundField>
                <asp:BoundField DataField="RECEIVING_DATE"
                    HeaderText="<%$ Resources:Messages, StockSearSearch_grdRecevingDate%>">
                    <HeaderStyle Width="3%" />
                </asp:BoundField>
                <asp:BoundField DataField="RECEIVED_QUANTITY"
                    HeaderText="<%$ Resources:Messages, StockSearSearch_grdReceivedQuantity %>">
                    <HeaderStyle Width="10%" />
                </asp:BoundField>
                <asp:BoundField DataField="RECEIVING_PERSON"
                    HeaderText="<%$ Resources:Messages,StockSearSearch_grdReceivingPerson %>">
                    <HeaderStyle Width="10%" />
                </asp:BoundField>
                <asp:BoundField DataField="UNIT_PRICE"
                    HeaderText="<%$ Resources:Messages,StockSearSearch_grdUnitPrice %>">
                    <HeaderStyle Width="10%" />
                </asp:BoundField>

                <asp:BoundField DataField="TOTAL_PRICE"
                    HeaderText="<%$ Resources:Messages, StockSearSearch_grdTotalPrice %>">
                    <HeaderStyle Width="10%" />
                </asp:BoundField>


                <asp:TemplateField HeaderText="<%$ Resources:Messages, lblView%>">
                    <HeaderStyle Width="15%" CssClass="no-sort" />
                    <ItemTemplate>
                        <asp:HyperLink ID="ViewStock" CssClass="gridActionIcon" runat="server"
                            Visible="true" ToolTip="View"
                            NavigateUrl='<%# DataBinder.Eval( Container.DataItem , "ID" ,"AddStock.aspx?Id={0}" )%>'>
                                    <i class="icon-pencil font-blue"></i>
                        </asp:HyperLink>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>--%>
    </div>






</asp:Content>

