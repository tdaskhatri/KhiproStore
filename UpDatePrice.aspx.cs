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
    public partial class UpdatePrice : System.Web.UI.Page
    {
        Logger logger = Logger.getInstance();
        string MODULE_NAME = "UpdatePrice";
        DAStock stock = new DAStock();

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {

                popddlStock();

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


        public DataTable getSchemaData()
        {
            try
            {
                DataTable dt = new DataTable();

                dt.Columns.Add("PURCHASE_PRICE", typeof(string));
                dt.Columns.Add("SELL_PRICE_RETAIL", typeof(string));
                dt.Columns.Add("STOCK_ID", typeof(string));
                DataRow dr = dt.NewRow();


                dr["PURCHASE_PRICE"] = NewPurchasePrice.Text.Trim();
                dr["SELL_PRICE_RETAIL"] = NewSalePrice.Text.Trim();
                dr["STOCK_ID"] = ddlStock.SelectedValue.ToString();
                dt.Rows.InsertAt(dr, 0);
                return dt;
            }
            catch (Exception ex)
            {
                logger.Error(MODULE_NAME, "getSchemaData", ex);
                throw ex;
            }

        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (Page.IsValid)
                {
                    DataTable data = getSchemaData();
                    stock.UpdatePrice(data);
                    // Response.Write("<script>alert('Customer Added ')</script>");
                    //  Response.Redirect(Request.Url.AbsoluteUri);
                    // ScriptManager.RegisterStartupScript(Page, Page.GetType(), "Alert", "Data has been saved", true);
                }
            }
            catch (Exception ex)
            {
                logger.Error(MODULE_NAME, "btnAdd_Click", ex);
            }
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string oldPurchasePrice, OldsalePrice;

            Decimal pprice = stock.GetPurchasePrice(Convert.ToInt32(ddlStock.SelectedValue.ToString()));
            oldPurchasePrice = pprice.ToString();
            OldPurchasePrice.Text = oldPurchasePrice;
            Decimal sprice = stock.GetSalePrice(Convert.ToInt32(ddlStock.SelectedValue.ToString()));
            OldsalePrice = sprice.ToString();
            OldSalePrice.Text = OldsalePrice;
        }
    }

    }