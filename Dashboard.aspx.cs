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
    public partial class Dashboard : System.Web.UI.Page
    {
        Logger logger = Logger.getInstance();
        string MODULE_NAME = "DashBoard";
        DAStock stock = new DAStock();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //popddlStockType();
                GetTotalProducts();
                GetOutOfStockProducts();

            }
            // totalStock.Text = "10";

        }
        private void GetTotalProducts()
        {
            try
            {
                int count = stock.GetTotalProductsCount();
                string totalproducts;
                totalproducts = count.ToString();
                totalStock.Text = totalproducts;
            }
            catch (Exception ex)
            {
                logger.Error(MODULE_NAME, "GetTotalProducts", ex);
            }

        }
        private void GetOutOfStockProducts()
        {
            try
            {
                int count = stock.GetOutOfStockProductsCount();
                string totalOutStockproducts;
                totalOutStockproducts = count.ToString();
                totalStock1.Text = totalOutStockproducts;
            }
            catch (Exception ex)
            {
                logger.Error(MODULE_NAME, "GetTotalProducts", ex);
            }

        }
    }
}