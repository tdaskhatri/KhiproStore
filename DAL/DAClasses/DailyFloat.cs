using eLearning.DAL.DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace eLearning.DAL.DAClasses
{
    public class DailyFloat
    {
        private DADailyFloat DataAccess = new DADailyFloat();

        public DataTable SearchDailyFloatTransactions(string where)
        {
            return this.DataAccess.SearchDailyFloatTransactions(where);
        }

        public DataTable GetPendingTransactions(string financialNo)
        {
            return this.DataAccess.GetPendingTransactions(financialNo);
        }

        public bool HasPendingTransactions(string financialNo)
        {
            return this.DataAccess.HasPendingTransactions(financialNo);
        }
        public void IssueDailyFloat(string financialNo, decimal amount, string remarks)
        {
            this.DataAccess.IssueDailyFloat(financialNo, amount, remarks);
        }

        public void ReceiveDailyFloat(string financialNo, decimal amount, byte[] uploadedImage, string remarks)
        {
            this.DataAccess.ReceiveDailyFloat(financialNo, amount, uploadedImage, remarks);
        }

        public void ApproveDailyFloatTransaction(string id)
        {
            this.DataAccess.ApproveDailyFloatTransaction(id);
        }

        public void RejectDailyFloatTransaction(string id)
        {
            this.DataAccess.RejectDailyFloatTransaction(id);
        }

        // Added by Muhammad Uzair on 06/02/2018 17:30:07 
        public DataTable GetFloatFinancialTransactions(string financialNo)
        {
            return this.DataAccess.GetFloatFinancialTransactions(financialNo);
        }
    }
}
