using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace eLearning.DAL.DAClasses
{
    [Serializable]
    public class CustomerAppliedLicense //This object represents CUSTOMER_SERVICE_CONTRACT table in database
    {
        public int CustomerServiceContractId { get; set; }
        public int StatusId { get; set; }
        public string StatusName { get; set; }
        public int SubServiceId { get; set; }
        public string SubServiceName { get; set; }
        public int MainServiceId { get; set; }
        public string RegistrationDate { get; set; }
        public int CenterId { get; set; }
        public int BranchId { get; set; }
        public int ServiceRateCardCategoryId { get; set; }
        public string ServiceRateCardCategoryName { get; set; }
        public int ServiceShiftId { get; set; }
        public string ExpiryDate { get; set; }
        public string ContractNo { get; set; }
        public int EmirateId { get; set; }
        public int LanguageId { get; set; }
        public bool IsDeleted { get; set; }
        public string RecordUniqueId { get; set; }
        public int? SubmittedBy { get; set; }


        //Modified by Fahim Nasir 06/12/2017 17:50:37
        // Added by AVANZA\muhammad.uzair as Onsite Support on 21/11/2017 14:29:23 
        public string AttendanceCardNumber { get; set; }

        // Added by MUHAMMADUZAIR\Administrator as Onsite Support on 29/11/2017 11:24:53 
        public int ServiceRegistrationType { get; set; }
        public int LicenseStatusId { get; set; }
        // Added by AVANZA\vijay.kumar on 12/01/2018 14:23:15
        public string Company { get; set; }

        // Added by Muhammad Uzair on 26/01/2018 15:23:43 
        public string CompanyContractNo { get; set; }

        // Added by Muhammad Uzair on 01/02/2018 10:41:40 
        public int KnowledgeTestAttempts { get; set; }
        public int ParkingTestAttempts { get; set; }
        public int AssessmentAttempts { get; set; }
        public int RoadTestAttempts { get; set; }
        public int ClassesAttempt { get; set; }

        // Added by Muhammad Uzair on 08/03/2018 10:32:03 
        public string PaymentPlanGenerated { get; set; }

    }
}
