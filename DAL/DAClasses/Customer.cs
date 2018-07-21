using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using eLearning.DAL.DataAccess;
using eLearning.Common.Utils;
using System.Data.Common;

// Developed by Fahim Nasir on 09/01/2017 12:45:24
namespace eLearning.DAL.DAClasses
{
    [Serializable]
    public class Customer
    {
        DACustomer daCustomer;
        Logger logger;
        private const string MODULE_NAME = "Customer";


        #region Constructor
        public Customer()
        {
            daCustomer = new DACustomer();
            logger = Logger.getInstance();
        }
        #endregion

        #region Data Members

        //Customer Details
        public int CustomerId { get; set; }
        public string TrackingFileNumber { get; set; }
        public string EmirateIDNumber { get; set; }
        public string EmirateIdNumberExpiryDate { get; set; }
        public string PersonNameEn { get; set; }
        public string PersonNameAr { get; set; }
        public string FatherNameEn { get; set; }
        public string FatherNameAr { get; set; }
        public string OccupationEn { get; set; }
        public string OccupationAr { get; set; }
        public string SponsorNameEn { get; set; }
        public string SponsorNameAr { get; set; }
        public int CustomerEmirateId { get; set; }
        public string CityNameAr { get; set; }
        public string AddressEn { get; set; }
        public string AddressAr { get; set; }
        public int Nationality { get; set; }
        public string DateOfBirth { get; set; }
        public char Gender { get; set; }
        public int IsPregnant { get; set; }
        public string UnifiedNo { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string Phone { get; set; }
        public int Language { get; set; }
        public int RTALanguage { get; set; }
        public string TranslationRIP { get; set; }
        public string RIP_LANGUAGE_NAME { get; set; }
        public string TRANSLATION_RIP_SERVICE { get; set; }
        public string POBoxNo { get; set; }
        public string Fax { get; set; }

        // Added by MUHAMMADUZAIR\Administrator as Onsite Support on 01/12/2017 02:43:24 
        public int RTAVoiceLanguage { get; set; }

        //=======================================

        //Applied License Details
        public List<CustomerAppliedLicense> listAppliedLicense { get; set; }
        //=========================

        //Existing License Details
        public string LicenseNo { get; set; }
        public string LicenseIssueDate { get; set; }
        public string LicenseExpiryDate { get; set; }
        public int LicenseCountry { get; set; }
        public int ExistingVehicleType { get; set; }
        public int NoExperienceValue { get; set; }
        public List<CustomerExistingLicense> listExistingLicense { get; set; }
        //============================

        //Passport Details
        public int PassportCountry { get; set; }
        public string PassportNo { get; set; }
        public string PassportIssueDate { get; set; }
        public string PassportExpiryDate { get; set; }
        public string PassportTrackingNo { get; set; }
        public string BookletNo { get; set; }
        //======================================

        //Visa Details
        public string VisaNameEn { get; set; }
        public string VisaNameAr { get; set; }
        public string VisaIssueDate { get; set; }
        public string VisaExpiryDate { get; set; }
        public string ProfessionEn { get; set; }
        public string ProfessionAr { get; set; }
        public string PlaceOfIssueEn { get; set; }
        public string PlaceofIssueAr { get; set; }
        public string AccompaniedByEn { get; set; }
        public string AccompaniedByAr { get; set; }
        public string UIDNo { get; set; }
        public int VisaEmirateId { get; set; }
        public string SponsorEn { get; set; }
        public string SponsorAr { get; set; }
        //=============================

        //Documents
        public DataTable dtDocuments = new DataTable();

        //Image
        public string CustomerImage { get; set; }

        //Others
        public string Remarks { get; set; }
        public int CustomerType { get; set; }
        public string InstructorPreference { get; set; }
        public int EidaInfoUsingCard { get; set; }
        public int ChannelId { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }

        public int Status { get; set; }
        public int? SubmittedBy { get; set; }
        //=======================
        #endregion

        #region Business Logic Methods
        
        // Added by Muhammad Uzair on 19/03/2018 19:51:31 as ONSITE_DEV
        public DataSet GetCustomerDetailsById(string userName, int customerId)
        {
            return daCustomer.GetCustomerDetailsById(userName, customerId);
        }
        //Added by Fahim Nasir on 27-9-2017
        public string GetCustomerIdByTFN(string TrafficFileNo)
        {
            return daCustomer.GetCustomerIdByTFN(TrafficFileNo);
        }
        public bool MarkLicenseCancelled(int CustomerServiceContractId)
        {
            return daCustomer.MarkLicenseCancelled(CustomerServiceContractId);
        }
        public bool SendCustomerForApproval(CustomerTrackingHistory cth, string Remarks)
        {
            return daCustomer.SendCustomrForApproval(cth, Remarks);
        }

        public bool RejectCustomer(CustomerTrackingHistory cth, string Remarks)
        {
            return daCustomer.RejectCustomer(cth, Remarks);
        }

        // MODIFIED BY MUHAMMAD.AWAIS 8/3/2017 9:50AM
        public bool ApproveCustomer(CustomerTrackingHistory cth, string trackingFileNo, string Remarks, PaymentPlan pp, string userId)
        {
            return daCustomer.ApproveCustomer(cth, trackingFileNo, Remarks, pp, userId);
        }

        public DataTable GetNationalitiesAllData()
        {
            return daCustomer.GetNationalitiesAllData();
        }

        public DataTable GetEidaInfoKeyValueData()
        {
            return daCustomer.GetEidaInfoKeyValueData();
        }

        // MODIFIED BY MUHAMMAD.AWAIS 8/3/2017 3:44PM ADDED USERID
        // Modified by AVANZA\muhammad.uzair on 13/11/2017 11:23:29
        public int SaveCustomer(Customer customer, string userId)
        {
            return daCustomer.SaveCustomer(customer, userId);
        }
        public DataTable GetNationalities()
        {
            return daCustomer.GetNationalities();
        }

        public DataTable GetDocumentTypes()
        {
            return daCustomer.GetDocumentTypes();
        }

        public DataTable GetCountries()
        {
            return daCustomer.GetCountries();
        }

        public DataTable GetETDILanguages(int IsActiveBit)
        {
            return daCustomer.GetETDILanguages(IsActiveBit);
        }

        public DataTable GetRTALanguages(int IsActiveBit)
        {
            return daCustomer.GetRTALanguages(IsActiveBit);
        }

        public DataTable GetBranches()
        {
            return daCustomer.GetBranches();
        }

        public DataTable GetContractCategories()
        {
            return daCustomer.GetContractCategories();
        }

        public DataTable GetVehicleTypes(int IsActiveBit)
        {
            return daCustomer.GetVehicleTypes(IsActiveBit);
        }

        public DataTable GetEmirates()
        {
            return daCustomer.GetEmirates();
        }

        public DataTable GetServiceRateCardCategories()
        {
            return daCustomer.GetServiceRateCardCategories();
        }

        public bool IsUniqueEmirateIdNumber(string value, int customerId)
        {
            return daCustomer.IsUniqueEmirateIdNumber(value, customerId);
        }

        // Added by MUHAMMADUZAIR\avanza on 19/09/2017 15:32:07
        public bool IsUniquerTrackingFileNumber(string value, int customerId)
        {
            return daCustomer.IsUniquerTrackingFileNumber(value, customerId);
        }

        public DataTable GetCenters()
        {
            return daCustomer.GetCenters();
        }
        public DataSet GetSearchComboData()
        {
            try
            {
                return daCustomer.GetSearchComboData();
            }
            catch (Exception ex)
            {
                logger.Error(MODULE_NAME, "GetComboData", ex);
                throw ex;
            }
        }
        public DataSet GetCustomers(DataTable dtCriteria)
        {
            try
            {
                return daCustomer.GetCustomers(dtCriteria);
            }
            catch (Exception ex)
            {
                logger.Error(MODULE_NAME, "GetCustomers", ex);
                throw ex;
            }
        }

        public DataSet GetCustomerDataById(int CustomerId)
        {
            try
            {
                return daCustomer.GetCustomerDataById(CustomerId);
            }
            catch (Exception ex)
            {
                logger.Error(MODULE_NAME, "GetCustomerDataById", ex);
                throw ex;
            }
        }

        // Added by avanza\MUHAMMADUZAIR on 21/08/2017 14:39:50
        public DataSet GetUserDataByUserId(string userId)
        {
            DACustomer obj = new DACustomer();
            return obj.GetUserDataByUserId(userId);
        }


        public DataSet GetCustomerDetails(string customerId, string customerServContrId)
        {
            DACustomer obj = new DACustomer();
            return obj.GetCustomerDetails(customerId, customerServContrId);
        }

        public bool CheckIfUniqueRegistrationNo(string RegistrationNo)
        {
            DACustomer obj = new DACustomer();
            return obj.CheckIfUniqueRegistrationNo(RegistrationNo);
        }

        public DataTable GetActiveSubServiceWithThisId(string SubServiceId)
        {
            return new DACustomer().GetActiveSubServiceWithThisId(SubServiceId);
        }

        public bool checkForUnique(string value, string tableName, string dbColumnName, int pageMode)
        {
            return new DACustomer().checkForUnique(value, tableName, dbColumnName, pageMode);
        }

        // AVANZA\jawwad.ahmed - 29/03/2017 11:52:54
        public DataSet GetTrainingContractReportData(string customerId, string customerServiceContractId, string usernameEn, string usernameAr)
        {
            return new DACustomer().GetTrainingContractReportData(customerId, customerServiceContractId, usernameEn, usernameAr);
        }

        // AVANZA\jawwad.ahmed - 29/03/2017 11:52:54
        public DataSet GetLearningFileReportData(string customerId)
        {
            return new DACustomer().GetLearningFileReportData(customerId);
        }

        // AVANZA\jawwad.ahmed - 05/04/2017 11:21:59
        public string GetNextServiceRegistrationNo()
        {
            string regNo = new DACustomer().GetNextServiceRegistrationNo();
            return regNo.PadLeft(8, '0');
        }

        // Hassaan Masood - 24/05/2017 02:37 PM
        public DataTable GetPaymentDetails(int paymentId)
        {
            return daCustomer.GetPaymentDetails(paymentId);
        }

        public DataSet GetPaymentReceiptById(int paymentId, string copyLabel, string copyLabelAr, string NetAmountLabel = "")
        {
            return daCustomer.GetPaymentReceiptById(paymentId, copyLabel, NetAmountLabel, copyLabelAr);
        }

        public DataTable GetPaymentFile(int paymentId)
        {
            return daCustomer.GetPaymentFile(paymentId);
        }

        public DataSet GetLicenseIssueReportData(int CustomerId)
        {
            return daCustomer.GetLicenseIssueReportData(CustomerId);
        }

        // AVANZA\muhammad.uzair - 15/08/2017 11:14:32
        public int GetContractId(string TFN)
        {
            return daCustomer.GetContractId(TFN);
        }

        // AVANZA\muhammad.uzair - 15/08/2017 16:53:43
        public decimal GetPracticalId()
        {
            return daCustomer.GetPracticalId();
        }

        // Modified by Muhammad Uzair on 20/03/2018 19:42:24 as ONSITE_DEV
        //added by fahim nasir on 29-8-2017
        public DataSet GetClassesScheduleData(string CustomerId, string userName, bool pendingOnly)
        {
            return daCustomer.GetClassesScheduleData(CustomerId,userName,pendingOnly);
        }

        // Added by MUHAMMADUZAIR\avanza on 07/09/2017 13:24:38
        public DataSet GetCustomerExamBookingData(string customerServiceExamId)
        {
            return daCustomer.GetCustomerExamBookingData(customerServiceExamId);
        }
        // Added by AVANZA\muhammad.uzair on 11/10/2017 11:21:05
        public int GetCustomerLicenseStatusId(string contractId)
        {
            return daCustomer.GetCustomerLicenseStatusId(contractId);
        }

        // Added by AVANZA\muhammad.uzair on 11/10/2017 11:43:02
        public DataSet GetLicenseTrainingCertificateData(string contractId)
        {
            return daCustomer.GetLicenseTrainingCertificateData(contractId);
        }


        public DataTable GetCustomerService(string customerId)
        {

            DataTable dt = new DataTable();
            dt = this.daCustomer.GetCustomerService(customerId);
            return dt;
        }

        public string GetCustomerImage(string customerId)
        {

            DataTable dt = new DataTable();

            dt = this.daCustomer.GetCustomerImage(customerId);
            if (dt.Rows.Count > 0)
            {
                string name = dt.Rows[0]["IMAGE_STR"].ToString();
                return name;
            }
            else
                return "";

        }

        // Added by MUHAMMADUZAIR\Administrator as Onsite Support on 11/12/2017 11:32:56 
        public void UpdateCustomerContractLicenseStatus(int customerId, int contractId, int statusId)
        {
            daCustomer.UpdateCustomerContractLicenseStatus(customerId, contractId, statusId);
        }

        // Added by MUHAMMADUZAIR\Administrator as Onsite Support on 13/12/2017 13:14:16 
        public int GetContractIdByCustomerId(string customerId)
        {
            return daCustomer.GetContractIdByCustomerId(customerId);
        }

        //Added by Fahim Nasir 09/03/2018 10:59:25
        public DataTable GetCustomerChannels()
        {
            return daCustomer.GetCustomerChannels();
        }

        #endregion
    }
}
