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
    public partial class SearchCustomer : System.Web.UI.Page
    {
        Logger logger = Logger.getInstance();
        string MODULE_NAME = "SearchCustomer";
        DAStock stock = new DAStock();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //popddlStockType();
                popddlCutomers();

            }

        }





        private void popddlCutomers()
        {
            try
            {
                DataTable dt = stock.GetCustomers();
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



                stock.UpdateCustomerAmountDue(amountPay.Text.Trim(),ddlStock.SelectedValue.ToString());
            }
        }

        

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string AmountDue;

            Decimal pprice = stock.GetCustomerAountDue(Convert.ToInt32(ddlStock.SelectedValue.ToString()));
            AmountDue = pprice.ToString();
            amountDue.Text = AmountDue;
        
          
        }
    }
}