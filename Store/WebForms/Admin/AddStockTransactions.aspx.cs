using eLearning.Common.Utils;
using eLearning.DAL.DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Store.WebForms.Admin
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
                popddlStockType();
                popddlStock();
                popddlSupplier();
            }

        }


        private void popddlSupplier()
        {
            try
            {
                DataTable dt = stock.GetSupplier();
                DataRow dr = dt.NewRow();
                dr["ID"] = "-1";
                dr["SUPPLIER_NAME"] = "Select";
                dt.Rows.InsertAt(dr, 0);
                ddlSupplier.DataTextField = "SUPPLIER_NAME";
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
            Page.Validate("Save");
            if (Page.IsValid)
            {
                DataTable data = getSchemaData();
                stock.AddStockTransactions(data);
            }
        }

        public DataTable getSchemaData()
        {
            try
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("STOCK_ID", typeof(string));
                dt.Columns.Add("QUANTITY", typeof(string));
                dt.Columns.Add("TOTAL_AMOUNT", typeof(string));
                dt.Columns.Add("AMOUNT_PAID", typeof(string));
                dt.Columns.Add("AMOUNT_DUE", typeof(string));
                dt.Columns.Add("MEASURE_TYPE", typeof(string));
                dt.Columns.Add("SUPPLIER_ID", typeof(string));
                DataRow dr = dt.NewRow();
                dr["STOCK_ID"] = ddlStock.SelectedValue.ToString();
                dr["MEASURE_TYPE"] = ddlType.SelectedValue.ToString();
                dr["SUPPLIER_ID"] = ddlSupplier.SelectedValue.ToString();
                dr["AMOUNT_PAID"] = txtAmountPaid.Text.Trim();
                dr["AMOUNT_DUE"] = txtAmountDue.Text.Trim();
                dr["TOTAL_AMOUNT"] = txtTotalAmount.Text.Trim();
                dr["QUANTITY"] = txtTotalAmount.Text.Trim();
                dt.Rows.InsertAt(dr, 0);
                return dt;
            }
            catch (Exception ex)
            {
                logger.Error(MODULE_NAME, "getSchemaData", ex);
                throw ex;
            }

        }
    }
}