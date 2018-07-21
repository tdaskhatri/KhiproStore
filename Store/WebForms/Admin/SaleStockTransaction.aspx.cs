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

namespace Store.WebForms.Admin
{
    public partial class SaleStockTransaction : System.Web.UI.Page
    {
        Logger logger = Logger.getInstance();
        string MODULE_NAME = "AddStockTransactions";
        DAStock stock = new DAStock();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                popddlStockType();
                popddlStock();
                //popddlSupplier();
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

        private void popddlStockType()
        {
            try
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("NAME", typeof(string));
                dt.Columns.Add("ID", typeof(string));
                DataRow dr = dt.NewRow();
                dr["NAME"] = Enumaration.StockType.Dozen.ToString();
                dr["ID"] = (int)Enumaration.StockType.Dozen;
                dt.Rows.InsertAt(dr, 0);
                dr = dt.NewRow();
                dr["NAME"] = Enumaration.StockType.Kg.ToString();
                dr["ID"] = (int)Enumaration.StockType.Kg;
                dt.Rows.InsertAt(dr, 0);
                dr = dt.NewRow();
                dr["NAME"] = Enumaration.StockType.Ltr.ToString();
                dr["ID"] = (int)Enumaration.StockType.Ltr;
                dt.Rows.InsertAt(dr, 0);
                dr = dt.NewRow();
                dr["NAME"] = "Select";
                dr["ID"] = -1;
                dt.Rows.InsertAt(dr, 0);
                ddlType.DataTextField = "NAME";
                ddlType.DataValueField = "ID";
                ddlType.DataSource = dt;
                ddlType.DataBind();
            }
            catch (Exception ex)
            {
                logger.Error(MODULE_NAME, "popddlStockType", ex);
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

            //mp1.Show();

            // DataTable dt = getSchemaData();

        }

        public DataTable getSchemaData()
        {
            try
            {
                DataTable dt = (DataTable)ViewState["SALE_TRANSACTION_TABLE"];
                DataRow dr = dt.NewRow();
                dr["STOCK_ID"] = ddlStock.SelectedValue.ToString();
                dr["MEASURE_TYPE"] = ddlType.SelectedValue.ToString();
                // dr["SUPPLIER_ID"] = ddlSupplier.SelectedValue.ToString();
                dr["AMOUNT"] = txtAmount.Text.Trim();
                //dr["AMOUNT_DUE"] = txtAmountDue.Text.Trim();
                //dr["TOTAL_AMOUNT"] = txtTotalAmount.Text.Trim();
                dr["QUANTITY"] = txtQuantity.Text.Trim();
                dr["DISCOUNT"] = txtDiscount.Text.Trim();
                dr["STOCK_NAME"] = ddlStock.SelectedItem.ToString();

                if (ViewState["TOTAL_AMOUNT"] == null)
                {
                    if (Convert.ToDecimal(txtDiscount.Text.Trim().ToString()) > 0)
                    {
                        ViewState["TOTAL_AMOUNT"] = Convert.ToDecimal(txtAmount.Text.Trim().ToString()) 
                         - Convert.ToDecimal(txtDiscount.Text.Trim().ToString());
                    }
                    
                }
                else
                {
                    Decimal amount = Convert.ToDecimal(ViewState["TOTAL_AMOUNT"].ToString());
                    if (Convert.ToDecimal(txtDiscount.Text.Trim().ToString()) > 0)
                    {
                        amount+= Convert.ToDecimal(txtAmount.Text.Trim().ToString()) - Convert.ToDecimal(txtDiscount.Text.Trim().ToString());
                    }
                    ViewState["TOTAL_AMOUNT"] = amount;
                }

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
                dt.Columns.Add("AMOUNT_DUE", typeof(string));
                dt.Columns.Add("MEASURE_TYPE", typeof(string));
                return dt;
            }
            catch (Exception ex)
            {
                logger.Error(MODULE_NAME, "getSchema", ex);
                throw ex;
            }

        }

       
        protected void Save_Click(object sender, EventArgs e)
        {
            DataTable SaleDetail = (DataTable)ViewState["SALE_TRANSACTION_TABLE"];
            DataTable Sale = new DataTable();
            if (SaleDetail.Rows.Count > 0)
            {
                Sale.Columns.Add("TOTAL_AMOUNT", typeof(decimal));
                Sale.Columns.Add("AMOUNT_PAID", typeof(decimal));
                Sale.Columns.Add("CUSTOMER_ID_ID", typeof(int));
                DataRow dr = Sale.NewRow();
                dr["TOTAL_AMOUNT"] = Convert.ToDecimal(ViewState["TOTAL_AMOUNT"].ToString());
                dr["AMOUNT_PAID"] = 0;
                dr["CUSTOMER_ID_ID"] = 0;
                Sale.Rows.InsertAt(dr, 0);
            }
            stock.AddSaleTransaction(SaleDetail, Sale);
        }

        protected void txtQuantity_TextChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(ddlStock.SelectedValue.ToString()) != -1)
            {
                Decimal SaleRetAmount = stock.GetStockSalePrice(Convert.ToInt32(ddlStock.SelectedValue.ToString()));
                SaleRetAmount *= Convert.ToInt32(txtQuantity.Text.ToString());
                txtAmount.Text = SaleRetAmount.ToString();
                txtAmount.Enabled = false;
            }
        }

        protected void btnPrint_Click(object sender, EventArgs e)
        {
            SaleStockTrans.PagerSettings.Visible = false;
            SaleStockTrans.DataBind();
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);

            SaleStockTrans.RenderControl(hw);

            string gridHTML = sw.ToString().Replace("\"", "'")

                .Replace(System.Environment.NewLine, "");

            StringBuilder sb = new StringBuilder();

            sb.Append("<script type = 'text/javascript'>");

            sb.Append("window.onload = new function(){");

            sb.Append("var printWin = window.open('', '', 'left=0");

            sb.Append(",top=0,width=1000,height=600,status=0');");

            sb.Append("printWin.document.write(\"");

            sb.Append(gridHTML);

            sb.Append("\");");

            sb.Append("printWin.document.close();");

            sb.Append("printWin.focus();");

            sb.Append("printWin.print();");

            sb.Append("printWin.close();};");

            sb.Append("</script>");

            ClientScript.RegisterStartupScript(this.GetType(), "GridPrint", sb.ToString());

            SaleStockTrans.PagerSettings.Visible = true;

            SaleStockTrans.DataBind();
        }
    }
}