using eLearning.DAL.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;

namespace eLearning.DAL.DAClasses
{

    // CREATED BY MUHAMMAD.AWAIS 7/3/2017
    public class PaymentPlan
    {
        private DAPaymentPlan DA = new DAPaymentPlan();

        public void CreatePaymentPlan(int contractId, string userId, int paymentCatagoryId, DbTransaction dbTran)
        {
            this.DA.CreatePaymentPlan(contractId, userId, paymentCatagoryId, dbTran);
        }

        //Added by Fahim Nasir 22/01/2018 12:05:28
        public void UpdatePPForExemptedCustomer(int contractId, DbTransaction dbTran)
        {
            this.DA.UpdatePPForExemptedCustomer(contractId, dbTran);
        }
    }
}
