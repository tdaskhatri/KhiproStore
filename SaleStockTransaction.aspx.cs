using eLearning.Common.Utils;
using eLearning.DAL.DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;


using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html.simpleparser;


namespace Store
{
    public partial class SaleStockTransaction : System.Web.UI.Page
    {
        Logger logger = Logger.getInstance();
        string MODULE_NAME = "AddStockTransactions";
        DAStock stock = new DAStock();
        Hashtable ht = new Hashtable();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
              
                popddlStock();
                popddlCustomer();
                main_section.Visible = true;
                btnPrint.Visible = false;
                bill_section.Visible = false;


            }
        }

        


        private void popddlCustomer()
        {
            try
            {
                DataTable dt = stock.GetCustomers();
                DataRow dr = dt.NewRow();
                dr["ID"] = "-1";
                dr["NAME"] = "Select";
                dt.Rows.InsertAt(dr, 0);
                ddlcustomer.DataTextField = "NAME";
                ddlcustomer.DataValueField = "ID";
                ddlcustomer.DataSource = dt;
                ddlcustomer.DataBind();
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
            stock.UpdateStockQuantity(txtQuantity.Text.Trim().ToString(), ddlStock.SelectedItem.Value.ToString());
      

            txtQuantity.Text = "";
            txtAmount.Text = "";
            txtDiscount.Text = "";
            btnPrint.Visible = true;



        }

        public DataTable getSchemaData()
        {
            try
            {
                DataTable dt = (DataTable)ViewState["SALE_TRANSACTION_TABLE"];
                DataRow dr = dt.NewRow();
                dr["STOCK_ID"] = ddlStock.SelectedValue.ToString();
                dr["STOCK_NAME"] = ddlStock.SelectedItem.ToString();
                dr["QUANTITY"] = txtQuantity.Text.Trim();
                dr["AMOUNT"] = txtAmount.Text.Trim();
                dr["DISCOUNT"] = txtDiscount.Text.Trim();
                dr["NET_AMOUNT"] = Convert.ToDecimal(txtAmount.Text.Trim().ToString()) - Convert.ToDecimal(txtDiscount.Text.Trim().ToString());
                dt.Rows.InsertAt(dr, 0);
                return dt;
            }
            catch (Exception ex)
            {
                logger.Error(MODULE_NAME, "getSchemaData", ex);
                throw ex;
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
                dt.Columns.Add("DISCOUNT", typeof(string));
                dt.Columns.Add("NET_AMOUNT", typeof(string));
                return dt;
            }
            catch (Exception ex)
            {
                logger.Error(MODULE_NAME, "getSchema", ex);
                throw ex;
            }

        }



        protected void txtQuantity_TextChanged(object sender, EventArgs e)
        {
            
            int stock_quantiy = stock.StockQuantity(ddlStock.SelectedItem.Value.ToString());
            decimal txtqnt = Convert.ToDecimal(txtQuantity.Text.Trim().ToString());
            if (txtqnt > stock_quantiy)
            {
               
                QuantityMax.Text = "qunatity is high, reenter max "+ stock_quantiy.ToString();
                txtQuantity.Text = "";;
                txtQuantity.Focus();

            }
            else
            {
                QuantityMax.Text = "";

                if (Convert.ToInt32(ddlStock.SelectedValue.ToString()) != -1)
                {
                    Decimal SaleRetAmount = stock.GetStockSalePrice(Convert.ToInt32(ddlStock.SelectedValue.ToString()));
                    SaleRetAmount *= Convert.ToInt32(txtQuantity.Text.ToString());
                    txtAmount.Text = SaleRetAmount.ToString();
                    txtAmount.Enabled = false;
                    string discount = "0";
                    txtDiscount.Text = discount.ToString();
                }
            } 
        }

        protected void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                main_section.Visible = false;
                bill_section.Visible = true;
                DataTable SaleDetail = (DataTable)ViewState["SALE_TRANSACTION_TABLE"];
                Decimal finalamount = 0;
              
               
                    foreach (DataRow dr in SaleDetail.Rows)
                    {
                        finalamount += Convert.ToDecimal(dr["NET_AMOUNT"].ToString());
                    }
                    totalAmount.Text = finalamount.ToString();

                }
            catch (Exception ex) {
                logger.Error(MODULE_NAME, "btnPrint_Click", ex);
                throw ex;
            }
         
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            displaymsg.Text = "";
            displaymsg1.Text = "";
            totalAmount.Text = "";
            Amountpaid.Text = "";
            AmountDue.Text = "";
            Pay.Visible = true;
            bill_section.Visible = false;
            main_section.Visible = true;
        }

        protected void btnPay_Click(object sender, EventArgs e)
        {
            DataTable SaleDetail = (DataTable)ViewState["SALE_TRANSACTION_TABLE"];
            Decimal finalamount = 0;
            Decimal amountPaid = 0, amountDue = 0;
            try
            {
                foreach (DataRow dr in SaleDetail.Rows)
                {
                    finalamount += Convert.ToDecimal(dr["NET_AMOUNT"].ToString());
                }
                totalAmount.Text = finalamount.ToString();
                amountPaid = Convert.ToDecimal(Amountpaid.Text.Trim());
                amountDue = finalamount - amountPaid;

                DataTable Sale = new DataTable();
                if (SaleDetail.Rows.Count > 0)
                {
                    Sale.Columns.Add("CUSTOMER_ID", typeof(int));
                    Sale.Columns.Add("TOTAL_AMOUNT", typeof(decimal));
                    Sale.Columns.Add("AMOUNT_PAID", typeof(decimal));
                    Sale.Columns.Add("AMOUNT_DUE", typeof(decimal));
 
                    DataRow dr = Sale.NewRow();
                    dr["CUSTOMER_ID"] = ddlcustomer.SelectedValue.ToString();
                    dr["TOTAL_AMOUNT"] = finalamount.ToString();
                    dr["AMOUNT_PAID"] = Amountpaid.Text.Trim();
                    dr["AMOUNT_DUE"] = amountDue.ToString();
                    Sale.Rows.InsertAt(dr, 0);
                }
                stock.AddSaleTransaction(SaleDetail, Sale);

                main_section.Visible = true;
                bill_section.Visible = false;
                Response.Redirect(Request.Url.AbsoluteUri);
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "Alert", "Data has been saved", true);

            }
            catch (Exception ex)
            {
                logger.Error(MODULE_NAME, "btnPay_Click", ex);
                throw ex;
            }
        }
        protected void Amount_TextChanged(object sender, EventArgs e)
        {
            DataTable SaleDetail = (DataTable)ViewState["SALE_TRANSACTION_TABLE"];
            Decimal finalamount = 0;
            Decimal amountPaid = 0, amountDue = 0;
            foreach (DataRow dr in SaleDetail.Rows)
            {
                finalamount += Convert.ToDecimal(dr["NET_AMOUNT"].ToString());
            }
            amountPaid = Convert.ToDecimal(Amountpaid.Text.Trim());
            amountDue = finalamount - amountPaid;
            AmountDue.Text = amountDue.ToString();
            if (ddlcustomer.SelectedValue.ToString() == "-1" && amountDue > 0) {
                displaymsg.Text = "Select customer";
                  displaymsg1.Text ="or receive full payment";
                Pay.Visible = false;

            }

        }

        protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string item = e.Row.Cells[1].Text;
                foreach (Button button in e.Row.Cells[6].Controls.OfType<Button>())
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
            int iStock_id,iQunatity;
            iStock_id = Convert.ToInt32(e.Values["STOCK_ID"]);
            iQunatity = Convert.ToInt32(e.Values["QUANTITY"]);
            int index = Convert.ToInt32(e.RowIndex);



            DataTable dt = ViewState["SALE_TRANSACTION_TABLE"] as DataTable;
            dt.Rows[index].Delete();
            ViewState["SALE_TRANSACTION_TABLE"] = dt;

            SaleStockTrans.DataSource = ViewState["SALE_TRANSACTION_TABLE"] as DataTable;
            SaleStockTrans.DataBind();
            stock.UpdateStockQuantityAfterDelete(iQunatity,iStock_id);
        }


    }
}