using eLearning.Common.Utils;
using eLearning.DAL.DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Store
{
    public partial class AddStockTransactions : System.Web.UI.Page
    {
        Logger logger = Logger.getInstance();
        string MODULE_NAME = "AddStockTransactions";
        DAStock stock = new DAStock();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                popddlStock();
                popddlSupplier();
            
                saveStock.Visible = false;
                paymentSection.Visible = false;
            }

        }


        private void popddlSupplier()
        {
            try
            {
                DataTable dt = stock.GetSupplier();
                DataRow dr = dt.NewRow();
                dr["ID"] = "-1";
                dr["NAME"] = "Select";
                dt.Rows.InsertAt(dr, 0);
                ddlSupplier.DataTextField = "NAME";
                ddlSupplier.DataValueField = "ID";
                ddlSupplier.DataSource = dt;
                ddlSupplier.DataBind();
            }
            catch (Exception ex)
            {
                logger.Error(MODULE_NAME, "popddlStock", ex);
            }
        }
        private void popddlStock()
        {
            try
            {
                DataTable dt = stock.GetStock();
                DataRow dr = dt.NewRow();
                dr["ID"] = "-1";
                dr["NAME"] = "Select";
                dt.Rows.InsertAt(dr, 0);
                ddlStock.DataTextField = "NAME";
                ddlStock.DataValueField = "ID";
                ddlStock.DataSource = dt;
                ddlStock.DataBind();
            }
            catch (Exception ex)
            {
                logger.Error(MODULE_NAME, "popddlStock", ex);
            }

        }


        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Page.Validate("Save");
            if (Page.IsValid)
            {
                if (ViewState["SALE_TRANSACTION_TABLE"] == null)
                {
                    ViewState["SALE_TRANSACTION_TABLE"] = getSchema();
                    ViewState["SALE_TRANSACTION_TABLE"] = getSchemaData();
                    //GridBinding
                    SaleStockTrans.DataSource = (DataTable)ViewState["SALE_TRANSACTION_TABLE"];
                    SaleStockTrans.DataBind();
                }
                else
                {
                    ViewState["SALE_TRANSACTION_TABLE"] = getSchemaData();
                    //GridBinding
                    SaleStockTrans.DataSource = (DataTable)ViewState["SALE_TRANSACTION_TABLE"];
                    SaleStockTrans.DataBind();
                }
                saveStock.Visible = true;
                AMOUNT.Text = "";
                txtQuantity.Text = "";
            }
        }

        public DataTable getSchema()
        {
            try
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("STOCK_ID", typeof(string));
                dt.Columns.Add("STOCK_NAME", typeof(string));
                dt.Columns.Add("QUANTITY", typeof(string));
                dt.Columns.Add("AMOUNT", typeof(string));
                dt.Columns.Add("SUPPLIER_ID", typeof(string));
                return dt;
            }
            catch (Exception ex)
            {
                logger.Error(MODULE_NAME, "getSchema", ex);
                throw ex;
            }
        }
        public DataTable getSchemaData()
        {
            try
            {
                DataTable dt = (DataTable)ViewState["SALE_TRANSACTION_TABLE"];
                DataRow dr = dt.NewRow();
                dr["STOCK_ID"] = ddlStock.SelectedValue.ToString();
                dr["SUPPLIER_ID"] = ddlSupplier.SelectedValue.ToString();
                dr["STOCK_NAME"] = ddlStock.SelectedItem.ToString();
                dr["QUANTITY"] = txtQuantity.Text.Trim();
                dr["AMOUNT"] = AMOUNT.Text.Trim();
                dt.Rows.InsertAt(dr, 0);
                return dt;
            }
            catch (Exception ex)
            {
                logger.Error(MODULE_NAME, "getSchemaData", ex);
                throw ex;
            }
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            DataTable SaleDetail = (DataTable)ViewState["SALE_TRANSACTION_TABLE"];
            Decimal finalamount = 0;
            foreach (DataRow dr in SaleDetail.Rows)
            {
                finalamount += Convert.ToDecimal(dr["AMOUNT"].ToString());
            }
            totalAmount.Text = finalamount.ToString();
            SECTION.Visible = false;
            paymentSection.Visible = true;


        }
        protected void btnPay_Click(object sender, EventArgs e)
        {
            DataTable PurchaseDetail = (DataTable)ViewState["SALE_TRANSACTION_TABLE"];
            Decimal finalamount = 0;
            Decimal amountPaid = 0, amountDue = 0;
            foreach (DataRow dr in PurchaseDetail.Rows)
            {
                finalamount += Convert.ToDecimal(dr["AMOUNT"].ToString());
            }
            totalAmount.Text = finalamount.ToString();
            amountPaid = Convert.ToDecimal(Amountpaid.Text.Trim());
            amountDue = finalamount - amountPaid;

            DataTable Purchase = new DataTable();
            if (PurchaseDetail.Rows.Count > 0)
            {
                Purchase.Columns.Add("SUPPLIER_ID", typeof(int));
                Purchase.Columns.Add("TOTAL_AMOUNT", typeof(decimal));
                Purchase.Columns.Add("AMOUNT_PAID", typeof(decimal));
                Purchase.Columns.Add("AMOUNT_DUE", typeof(int));
                DataRow dr = Purchase.NewRow();
                dr["SUPPLIER_ID"]   = ddlSupplier.SelectedValue.ToString();
                dr["TOTAL_AMOUNT"]  = finalamount.ToString();
                dr["AMOUNT_PAID"]   = Amountpaid.Text.Trim();
                dr["AMOUNT_DUE"]    = amountDue.ToString();
                Purchase.Rows.InsertAt(dr, 0);
            }
            stock.AddPurchaseTransaction(PurchaseDetail, Purchase);

            SECTION.Visible = true;
            paymentSection.Visible = false;


        }
        protected void btnEdit_Click(object sender, EventArgs e)
        {
            
            SECTION.Visible = true;
            paymentSection.Visible = false;


        }
        protected void txtQuantity_TextChanged(object sender, EventArgs e)
        {
            DataTable SaleDetail = (DataTable)ViewState["SALE_TRANSACTION_TABLE"];
            Decimal finalamount = 0;
            Decimal amountPaid = 0,amountDue=0;
            foreach (DataRow dr in SaleDetail.Rows)
            {
                finalamount += Convert.ToDecimal(dr["AMOUNT"].ToString());
            }
            amountPaid = Convert.ToDecimal(Amountpaid.Text.Trim());
            amountDue = finalamount - amountPaid;
            AmountDue.Text = amountDue.ToString();

        }

        protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string item = e.Row.Cells[0].Text;
                foreach (Button button in e.Row.Cells[3].Controls.OfType<Button>())
                {
                    if (button.CommandName == "Delete")
                    {
                        button.Attributes["onclick"] = "if(!confirm('Do you want to delete " + item + "?')){ return false; };";
                    }
                }
            }
        }

        protected void OnRowDeleting(object sender, GridViewDeleteEventArgs e)
        {

            int index = Convert.ToInt32(e.RowIndex);



            DataTable dt = ViewState["SALE_TRANSACTION_TABLE"] as DataTable;
            dt.Rows[index].Delete();
            ViewState["SALE_TRANSACTION_TABLE"] = dt;

            SaleStockTrans.DataSource = ViewState["SALE_TRANSACTION_TABLE"] as DataTable;
            SaleStockTrans.DataBind();
  
        }


    }
}