using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using eLearning.Common.Utils;
using eLearning.DAL.DataAccess;
using System.Data;

namespace Store
{
    public partial class AddCustomer : System.Web.UI.Page
    {
        Logger logger = Logger.getInstance();
        string MODULE_NAME = "AddCustomer";
        DAStock stock = new DAStock();
        int iIDCounter=0;
        string sFiledValue;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

            }

        }

        public DataTable getSchemaData()
        {
            try
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("ID", typeof(string));
                dt.Columns.Add("NAME", typeof(string));
                dt.Columns.Add("PHONE", typeof(string));
                dt.Columns.Add("CNIC", typeof(string));
                dt.Columns.Add("ADDRESS", typeof(string));
                dt.Columns.Add("AMOUNT_DUE", typeof(string));

                DataRow dr = dt.NewRow();
                iIDCounter = stock.getCustomerID();

                sFiledValue = iIDCounter.ToString();
                
               



                dr["ID"] = sFiledValue;
                dr["NAME"] = customerName.Text.Trim();
                dr["PHONE"] = phoneNumber.Text.Trim();
                dr["CNIC"] = cnic.Text.Trim();
                dr["ADDRESS"] = address.Text.Trim();
                dr["AMOUNT_DUE"] = 0;
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
                    stock.addCustomer(data);
                   // Response.Write("<script>alert('Customer Added ')</script>");
                    Response.Redirect(Request.Url.AbsoluteUri);
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "Alert", "Data has been saved", true);
                    }
            }
            catch (Exception ex)
            {
                logger.Error(MODULE_NAME, "btnAdd_Click", ex);
            }
        }

    }


}