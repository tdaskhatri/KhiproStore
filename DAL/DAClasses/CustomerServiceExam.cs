using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using eLearning.Common;
using System.Reflection;
using System.Collections;
using eLearning.DAL.DataAccess;
using eLearning.Common.Utils;
using System.Data.Common;

namespace eLearning.DAL.DAClasses
{
    public class CustomerServiceExam
    {
        private DACustomerServiceExam DA = new DACustomerServiceExam();
        //DAUser objDAUser = null;

        public DataSet FetchLicences()
        {
            return this.DA.FetchLicences();
        }
        public DataSet Search(Dictionary<Enumaration.SearchCustomerServiceExamCriteria, Object> criteria)
        {
              return this.DA.Search(criteria);
        }
        
        //public DataSet GetServiceRateById(string id)
        //{
        //    DataSet dsReturn = this.DA.GetServiceRateById(id);
        //    return dsReturn;
        //}
        
        //public DataSet GetUsersDataSet()
        //{
        //    DataSet dsReturn = new DataSet();
        //    dsReturn.Tables.Add(Entities.Users.GetDataTable());
        //    dsReturn.Tables.Add(Entities.Roles.GetDataTable());

        //    return dsReturn;

        //}
        //public bool IsDateRangeAvailable(DateTime beginDate, DateTime endDate, string subServiceId, int id)
        //{
        //    return this.DA.IsDatesAvailable(beginDate, endDate, subServiceId, id);
        //}
        //public bool IsNameAvailable(string templateName, int id)
        //{
        //    return this.DA.IsNameAvailable(templateName, id);
        //}
        //public bool IsNameArAvailable(string templateName, int id)
        //{
        //    return this.DA.IsNameArAvailable(templateName, id);
        //}
        //public int GetNextId()
        //{
        //    return this.DA.GetNextToken();
        //}
    }
}