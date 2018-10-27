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
    public partial class AddSupplier : System.Web.UI.Page
    {
        Logger logger = Logger.getInstance();
        string MODULE_NAME = "AddStockTransactions";
        DAStock stock = new DAStock();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                DataTable Supplier = getSchemaData();
                stock.AddSupplierName(Supplier);
            }
        }

        public DataTable getSchemaData()
        {
            try
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("NAME", typeof(string));
                dt.Columns.Add("PHONE", typeof(string));
                DataRow dr = dt.NewRow();
                dr["NAME"] = supplierName.Text.Trim();
                dr["PHONE"] = phoneNumber.Text.Trim();
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