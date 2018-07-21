using eLearning.DAL.DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using eLearning.Common.Utils;
using eLearning.DAL.MakerChecker;

namespace eLearning.DAL.DAClasses
{
    [Serializable]
    public struct Discount
    {
        public string Id { get; set; }
        public bool IsAvailable { get; set; }
        public Enumaration.DiscountType Type { get; set; }
        public Decimal Value { get; set; }

        public decimal GetDiscountRate(decimal total)
        {
            if (!IsAvailable) return 0;

            if (this.Type == Enumaration.DiscountType.Percentage)
            {
                return (this.Value / 100);
            }
            else
            {
                var percentage = (this.Value / total);
                return percentage;
            }
        }

        public decimal GetApplicableDiscount(decimal total, decimal payable)
        {
            if (!IsAvailable) return 0;

            if (this.Type == Enumaration.DiscountType.Percentage)
            {
                var discounted = (payable * (this.Value / 100));
                return discounted;
            }
            else
            {
                var percentage = (this.Value / total);
                var discounted = (payable * percentage);
                return discounted;
            }
        }

        public string GetDescription(decimal total)
        {
            if (this.Type == Enumaration.DiscountType.Percentage)
            {
                return "Discount available " + this.Value.ToString("0.##") + "% on each mandatory payment.";
            }
            else
            {
                var percentage = (this.Value / total);
                return "Discount available for amount " + this.Value + " AED (i.e. " + percentage.ToString("0.##") + "% on each mandatory payment).";
            }
        }
    }

    public class CustomerPayments
    {
        private DACustomerPayments DACustomerPayments = new DACustomerPayments();
        Logger logger;
        private const string MODULE_NAME = "CustomerPayments";

        public DataSet GetCustomerInformation(bool isEnglishLocale, string trafficFileNumber)
        {
            return this.DACustomerPayments.GetCustomerInformation(!isEnglishLocale, trafficFileNumber);
        }

        //AVANZA\muhammad.uzair 8/4/2017
        public DataSet GetPaymentCategories()
        {
            return this.DACustomerPayments.GetPaymentCategories();
        }
        // Added by avanza\MUHAMMADUZAIR on 29/08/2017 19:12:54
        public DataSet GetPaymentByCategoryId(string subServiceId, string paymentCategoryId, string contractId, string rateCardCategoryId)
        {
            return this.DACustomerPayments.GetPaymentByCategoryId(subServiceId, paymentCategoryId, contractId, rateCardCategoryId);
        }

        public DataSet GetPaymentCategoriesAmount(string contractId)
        {
            return this.DACustomerPayments.GetPaymentCategoriesAmount(contractId);
        }

        public DataTable GetPracticalAmount(int contractId)
        {
            return this.DACustomerPayments.GetPracticalAmount(contractId);
        }

        public Discount GetCompanyDiscount(string companyId, string subServiceId, string stageId)
        {
            Discount discount = new Discount() { IsAvailable = false };

            var dtDiscount = this.DACustomerPayments.GetCompanyDiscount(companyId, subServiceId, stageId);

            if (dtDiscount.Rows.Count > 0)
            {
                discount.Id = Convert.ToString(dtDiscount.Rows[0]["ID"]);
                discount.IsAvailable = true;
                discount.Type = (Enumaration.DiscountType)Convert.ToInt32(dtDiscount.Rows[0]["TYPE"]);
                discount.Value = Convert.ToDecimal(dtDiscount.Rows[0]["AMOUNT"]);
            }

            return discount;
        }

        public Discount GetIndividualDiscount(string contractId, string subServiceId, string stageId)
        {
            Discount discount = new Discount() { IsAvailable = false };

            var dtDiscount = this.DACustomerPayments.GetIndividualDiscount(contractId, subServiceId, stageId);

            if (dtDiscount.Rows.Count > 0)
            {
                discount.Id = Convert.ToString(dtDiscount.Rows[0]["ID"]);
                discount.IsAvailable = true;
                discount.Type = (Enumaration.DiscountType)Convert.ToInt32(dtDiscount.Rows[0]["TYPE"]);
                discount.Value = Convert.ToDecimal(dtDiscount.Rows[0]["AMOUNT"]);
            }

            return discount;
        }

        public decimal GetPracticalId()
        {
            return this.DACustomerPayments.GetPracticalId();
        }

        // Added by Muhammad Uzair on 13/02/2018 14:28:59 
        public int GetChangeCourseAdjusmentId()
        {
            return this.DACustomerPayments.GetChangeCourseAdjusmentId();
        }

        // Added by Muhammad Uzair on 13/03/2018 18:20:24 as ONSITE_DEV
        public int GetAdditionalAmountCategory()
        {
            return this.DACustomerPayments.GetAdditionalAmountCategory();
        }

        // Added by Muhammad Uzair on 01/03/2018 17:13:47 
        public decimal GetCourseChangeAdjustmentTax(string contractId, string categoryId)
        {
            return this.DACustomerPayments.GetCourseChangeAdjustmentTax(contractId, categoryId);
        }

        public DataTable GetPaymentsMasterTable()
        {
            return this.DACustomerPayments.GetPaymentsMasterTable();
        }
        public DataTable GetPaymentDetailsTable()
        {
            return this.DACustomerPayments.GetPaymentDetailsTable();
        }

        public string GetNextReceiptNo()
        {
            return this.DACustomerPayments.GetPaymentReceiptNumber().PadLeft(6, '0');
        }

        public int InsertPayments(DataTable master, DataTable details, Dictionary<string, string> categories, int contractId, string paymentCategoryId, string chkOther, Discount discount, string LanguageId, DataTable lumpSum, bool isPersonalDisocunt)
        {
            var transaction = this.DACustomerPayments.CreateTransaction();

            try
            {
                var paymentId = this.DACustomerPayments.InsertMasterPayment(master, transaction);
                this.DACustomerPayments.InsertDetailPayment(details,master, transaction, paymentId, contractId, LanguageId);

               
                if (chkOther == "0")
                {
                    this.DACustomerPayments.UpdateReceivables(contractId, categories, transaction);
                }
                else
                {
                    string amount = details.Rows[0]["AMOUNT"].ToString();
                    // Modified by Muhammad Uzair on 14/03/2018 22:51:09 as ONSITE_DEV
                    string etdiVat = details.Rows[0]["TAX_AMOUNT"].ToString();
                    this.DACustomerPayments.InsertAdditionalPaymentCategory(contractId.ToString(), paymentCategoryId, amount, transaction, etdiVat);
                }

                if (isPersonalDisocunt && discount.IsAvailable)
                    this.DACustomerPayments.ConsumeDiscountRequest(discount.Id, paymentId.ToString(), transaction);

                // Added by Muhammad Uzair on 30/01/2018 16:19:45 
                // Added for inserting a lump sum installment
                if (Convert.ToInt32(lumpSum.Rows[0]["IS_LUMP_SUM"]) == 1 && Convert.ToInt32(lumpSum.Rows[0]["IS_SELF_PAID"]) == 0)
                    this.DACustomerPayments.InsertInstallmentForLumpSum(transaction, lumpSum);

                this.DACustomerPayments.CommitTransaction(transaction);

                return paymentId;
            }
            catch (Exception ex)
            {
                this.DACustomerPayments.RollbackTransaction(transaction);
                throw ex;
            }
        }
        public DataSet GetCustomerPayments(DataTable dtCriteria)
        {
            try
            {
                return DACustomerPayments.GetCustomerPayments(dtCriteria);
            }
            catch (Exception ex)
            {
                logger.Error(MODULE_NAME, "GetCustomerPayments", ex);
                throw ex;
            }
        }

        public DataSet GetSearchComboData()
        {
            try
            {
                return DACustomerPayments.GetSearchComboData();
            }
            catch (Exception ex)
            {
                logger.Error(MODULE_NAME, "GetComboData", ex);
                throw ex;
            }
        }

        // Added by avanza\MUHAMMADUZAIR on 23/08/2017 15:31:17
        public DataSet GetPaymentDetailsById(int paymentId)
        {
            return DACustomerPayments.GetPaymentDetailsById(paymentId);
        }

        // Added by avanza\MUHAMMADUZAIR on 23/08/2017 15:31:14
        public int IsOtherPaymentExist(string contractId, string paymentCategoryId)
        {
            return this.DACustomerPayments.IsOtherPaymentExist(contractId, paymentCategoryId);
        }

        // Added by avanza\MUHAMMADUZAIR on 23/08/2017 15:31:09
        public void UpdateAdditionalPaymentCategory(string contractId, string paymentCategoryId)
        {
            var transaction = this.DACustomerPayments.CreateTransaction();
            try
            {

                //this.DACustomerPayments.UpdateAdditionalPaymentCategory(contractId, paymentCategoryId, transaction);
                this.DACustomerPayments.CommitTransaction(transaction);
            }
            catch (Exception ex)
            {
                this.DACustomerPayments.RollbackTransaction(transaction);
                throw ex;
            }
        }



        // Added by avanza\MUHAMMADUZAIR on 26/08/2017 01:26:46
        public string GetAdditionalPaymentAmount(string contractId, string paymentCategoryId)
        {
            return this.DACustomerPayments.GetAdditionalPaymentAmount(contractId, paymentCategoryId);
        }

        // Added by avanza\MUHAMMADUZAIR on 23/08/2017 15:31:04
        public void DeleteAdditionalPayment(string contractId, string paymentCategoryId)
        {
            var transaction = this.DACustomerPayments.CreateTransaction();
            try
            {
                this.DACustomerPayments.DeleteAdditionalPayment(contractId, paymentCategoryId, transaction);
                this.DACustomerPayments.CommitTransaction(transaction);
            }
            catch (Exception ex)
            {
                this.DACustomerPayments.RollbackTransaction(transaction);
                throw ex;
            }
        }

        // Added by avanza\MUHAMMADUZAIR on 23/08/2017 15:30:41
        public void ExcludeAdditionalPayment(string contractId, string paymentCategoryId)
        {
            var transaction = this.DACustomerPayments.CreateTransaction();
            try
            {
                this.DACustomerPayments.ExcludeAdditionalPayment(contractId, paymentCategoryId, transaction);
                this.DACustomerPayments.CommitTransaction(transaction);
            }
            catch (Exception ex)
            {
                this.DACustomerPayments.RollbackTransaction(transaction);
                throw ex;
            }
        }

        // Added by avanza\MUHAMMADUZAIR on 23/08/2017 15:30:38
        public int CheckIsOptional(string paymentCatId)
        {
            return this.DACustomerPayments.CheckIsOptional(paymentCatId);
        }

        // Added by AVANZA\jawwad.ahmed on 09/11/2017 13:38:08
        public DataTable GetDiscountRequestTable()
        {
            return this.DACustomerPayments.SchemaManager.GetTableAsDefault(Entities.INDIVIDUAL_DISCOUNT.TABLE_NAME);
        }

        // Added by AVANZA\jawwad.ahmed on 09/11/2017 13:48:30
        public void SaveDiscountRequest(DataTable table)
        {
            this.DACustomerPayments.SaveDiscountRequest(table);
        }

        public void ApproveDiscountRequest(string id)
        {
            this.DACustomerPayments.ApproveDiscountRequest(id);
        }

        public void RejectDiscountRequest(string id)
        {
            this.DACustomerPayments.RejectDiscountRequest(id);
        }

        public void UpdateDiscountRequest(string id, string type, string amount)
        {
            this.DACustomerPayments.UpdateDiscountRequest(id, type, amount);
        }

        //public void ConsumeDiscountRequest(string id, string paymentId)
        //{
        //    this.DACustomerPayments.ConsumeDiscountRequest(id, paymentId);
        //}
    }
}
