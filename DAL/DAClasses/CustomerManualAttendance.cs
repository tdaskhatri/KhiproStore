using eLearning.Common.Utils;
using eLearning.DAL.DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace eLearning.DAL.DAClasses
{
    public class CustomerManualAttendance
    {
        private DACustomerManualAttendance DA = new DACustomerManualAttendance();
        Logger logger;
        private const string MODULE_NAME = "CustomerManualAttendance";

        public int GetNextId()
        {
            return this.DA.GetNextToken();
        }
        public DataTable GetSchema()
        {
            return this.DA.SchemaManager.GetTableAsDefault("CUSTOMER_MANUAL_ATTENDANCE");
        }
        public void Add(DataRow row)
        {
            this.DA.Insert(row);
        }
        public DataSet GetCustomerAttendance(DataTable dtCriteria)
        {
            try
            {
                return DA.GetCustomerAttendance(dtCriteria);
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
