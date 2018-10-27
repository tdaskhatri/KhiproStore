﻿using eLearning.Common.Utils;
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

    public partial class AddSystemStock : System.Web.UI.Page
    {
        Logger logger = Logger.getInstance();
        string MODULE_NAME = "AddStock";
        DAStock stock = new DAStock();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                popddlStockType();
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
            try
            {
                Page.Validate("Save");
                if (Page.IsValid)
                {
                    DataTable data = getSchemaData();
                    stock.AddStock(data);
                    Response.Redirect(Request.Url.AbsoluteUri);
                }
            }
            catch (Exception ex)
            {
                logger.Error(MODULE_NAME, "btnAdd_Click", ex);
            }
        }
        public DataTable getSchemaData()
        {
            try
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("NAME", typeof(string));
                dt.Columns.Add("STOCK_TYPE", typeof(string));
                dt.Columns.Add("PURCHASE_PRICE", typeof(string));
                dt.Columns.Add("SELL_PRICE_RETAIL", typeof(string));
                dt.Columns.Add("SELL_PRICE_WHOLE_SALE", typeof(string));
                DataRow dr = dt.NewRow();
                dr["NAME"] = txtStockName.Text.Trim();
                dr["STOCK_TYPE"] = ddlType.SelectedItem.Value.ToString();
                dr["PURCHASE_PRICE"] = txtPurchase.Text.Trim();
                dr["SELL_PRICE_RETAIL"] = txtSell.Text.Trim();
                dr["SELL_PRICE_WHOLE_SALE"] = txtSaleWhole.Text.Trim();
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