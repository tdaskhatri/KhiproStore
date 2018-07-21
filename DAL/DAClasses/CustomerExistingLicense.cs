using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace eLearning.DAL.DAClasses
{
    [Serializable]
    public class CustomerExistingLicense //This object represents CUSTOMER_PREVIOUS_LICENSE table in database
    {
        public string RecordUniqueId { get; set; }
        public int Id { get; set; }
        public string LicenseNo { get; set; }
        public int CountryId { get; set; }
        public int SubServiceId { get; set; }
        public string CountryName { get; set; }
        public string SubServiceName { get; set; }
        public string NoOfExprience { get; set; }
        public string NoOfExprienceName { get; set; }
        public string IssueDate { get; set; }
        public string ExpiryDate { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsNew { get; set; }

        public CustomerExistingLicense()
        {
            this.RecordUniqueId = Guid.NewGuid().ToString();
        }
    }
}
