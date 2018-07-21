using eLearning.Common.Utils;
using eLearning.DAL.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace eLearning.DAL.DAClasses
{
    public class CustomerTrackingHistory
    {
        #region DataMembers
        Logger logger = Logger.getInstance();
        private const string MODULE_NAME = "CustomerTrackingHistory.cs";
        public int CustomerId { get; set; }
        public int ActionPerformedBy {get;set;}
        public string ActionPerformedFrom { get; set; }
        public int ChannelId { get; set; }
        public int StatusId { get; set; }
        public readonly DateTime ActionDate;

        // Added by AVANZA\vijay.kumar on 24/01/2018 17:17:16
        public int CUSTOMER_SERVICE_CONTRACT_ID { get; set; }
        public int ACTIVITY_TYPE { get; set; }
        public string ACTIVITY_DESCRIPTION { get; set; }
        public int ACTIVITY_BY { get; set; }
        public string ACTIVITY_ON { get; set; }
        
        #endregion

        #region BusinessFunction
        public void LogCustomerTrackingHistory(CustomerTrackingHistory cth)
        {
            try
            {
                DACustomerTrackingHistory daCTH = new DACustomerTrackingHistory();
                daCTH.LogCustomerTrackingHistory(cth);
            }
            catch (Exception ex)
            {
                logger.Error(MODULE_NAME, "LogCustomerTrackingHistory", ex);
                throw ex;
            }
        }
        #endregion
    }
}
