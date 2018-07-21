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
    public class ServiceRates
    {

        private DAServiceRates DA = new DAServiceRates();
        DAUser objDAUser = null;

        public DataSet Search(Dictionary<Enumaration.SearchServiceRatesCriteria, Object> criteria, SearchOptions options, bool fromProduction)
        {
            if (fromProduction)
                return this.DA.Search(criteria, options);
            else
                return this.DA.SearchInterim(criteria, options);
        }

        public int SearchCount(Dictionary<Enumaration.SearchServiceRatesCriteria, Object> criteria, SearchOptions options, bool fromProduction)
        {
            if (fromProduction)
                return this.DA.SearchCount(criteria, options);
            else
                return this.DA.SearchCountInterim(criteria, options);
        }

        public DataSet GetServiceRateById(string id, bool isCopy)
        {
            DataSet dsReturn = this.DA.GetServiceRateById(id, isCopy);
            return dsReturn;
        }

        public DataSet GetServiceRateInterimById(string id)
        {
            DataSet dsReturn = this.DA.GetServiceRateInterimById(id);
            return dsReturn;
        }

        public DataSet GetUsersDataSet()
        {
            DataSet dsReturn = new DataSet();
            dsReturn.Tables.Add(Entities.Users.GetDataTable());
            dsReturn.Tables.Add(Entities.Roles.GetDataTable());

            return dsReturn;

        }
        // Commented and Modified Below by MUHAMMADUZAIR\Administrator as Onsite Support on 27/11/2017 10:49:35
        //public bool IsDateRangeAvailable(DateTime beginDate, DateTime endDate, string subServiceId, int id)
        //{
        //    return this.DA.IsDatesAvailable(beginDate, endDate, subServiceId, id);
        //}
        public bool IsDateRangeAvailable(DateTime beginDate, DateTime endDate, string subServiceId, int id, int registrationCat)
        {
            return this.DA.IsDatesAvailable(beginDate, endDate, subServiceId, id, registrationCat);
        }

        // Commented and Modified Below by MUHAMMADUZAIR\Administrator as Onsite Support on 27/11/2017 10:40:14
        //public bool IsNameAvailable(string templateName, int id)
        //{
        //    return this.DA.IsNameAvailable(templateName, id);
        //}
        public bool IsNameAvailable(string templateName, int id, int registrationCat)
        {
            return this.DA.IsNameAvailable(templateName, id, registrationCat);
        }

        // Commented and Modified Below by MUHAMMADUZAIR\Administrator as Onsite Support on 27/11/2017 10:44:21
        //public bool IsNameArAvailable(string templateName, int id)
        //{
        //    return this.DA.IsNameArAvailable(templateName, id);
        //}
        public bool IsNameArAvailable(string templateName, int id, int registrationCat)
        {
            return this.DA.IsNameArAvailable(templateName, id, registrationCat);
        }
        public int GetNextId()
        {
            return this.DA.GetNextToken();
        }

        // Added by MUHAMMADUZAIR\Administrator as Onsite Support on 26/11/2017 14:25:20 
        public DataTable GetServiceRegistrationCategories()
        {
            return DA.GetRegistrationCategories();
        }
    }
}
