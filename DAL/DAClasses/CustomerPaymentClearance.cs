using eLearning.Common.Utils;
using eLearning.DAL.DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace eLearning.DAL.DAClasses
{
    public class CustomerPaymentClearance
    {
        private DACustomerPaymentClearance DA = new DACustomerPaymentClearance();
        Logger logger;
        private const string MODULE_NAME = "CustomerPaymentClearance";

        public int GetNextId()
        {
            return this.DA.GetNextToken();
        }
        public DataTable GetSchema()
        {
            return this.DA.SchemaManager.GetTableAsDefault("CUSTOMER_PAYMENT_CLEARANCE");
        }
        public void Add(DataRow row)
        {
            this.DA.Insert(row);
        }
        public DataSet GetCustomerPaymentClearance(DataTable dtCriteria)
        {
            try
            {
                return DA.GetCustomerPaymentClearance(dtCriteria);
            }
            catch (Exception ex)
            {
                logger.Error(MODULE_NAME, "GetCustomerAttendance", ex);
                throw ex;
            }
        }
        public bool IsTFNExists(string tfn) 
        {
            try
            {
                return DA.IsTFNExists(tfn);
            }
            catch (Exception ex)
            {
                logger.Error(MODULE_NAME, "IsTFNExists", ex);
                throw ex;
            }
        }
    }
}
