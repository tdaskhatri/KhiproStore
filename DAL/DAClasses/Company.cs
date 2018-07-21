using eLearning.DAL.DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
namespace eLearning.DAL.DAClasses
{
    //Created by Fahim Nasir 09/10/2017 09:19:33
    [Serializable]
    public class cCompany
    {
        private const string MODULE_NAME = "Company";
        public int CompanyId { get; set; }
        public string NameEn { get; set; }
        public string NameAr { get; set; }
        public string LicenseNo { get; set; }
        public string ReferenceNo { get; set; }
        public string ContactNo { get; set; }
        public string Email { get; set; }
        public int EmiratedId { get; set; }
        public string PostalCode { get; set; }
        public string ContactPersonName { get; set; }
        public string ContactPersonMobileNo { get; set; }
        //public int IsInternalCompany { get; set; }
        public int IsActive { get; set; }
        public string CompanyAddress { get; set; }
        public string Remarks { get; set; }
        public int CreatedBy { get; set; }
        public int? UpdatedBy { get; set; }
        public int CompanyTypeId { get; set; }

        //Added by Fahim Nasir 11/10/2017 10:20:05
        public DataSet GetCompanyDataSet()
        {
            DataSet dsReturn = new DataSet();
            dsReturn.Tables.Add(Entities.Company.GetDataTable());
            //Added by Fahim Nasir 12/10/2017 10:22:26
            dsReturn.Tables.Add(Entities.GetCompanyDiscountTable().Copy());
            //==============

            //Added by Fahim Nasir 17/01/2018 11:40:13
            dsReturn.Tables.Add(Entities.GetCompanyContractTable().Copy());
            return dsReturn;
        }
    }
}
