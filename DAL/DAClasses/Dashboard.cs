using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using eLearning.DAL.DataAccess;
using eLearning.Common.Utils;
using System.Data;

namespace eLearning.DAL.DAClasses
{
    public class Dashboard
    {

        DADashboardGraphs graphs = new DADashboardGraphs();
        private const string MODULE_NAME = "Dashboard.cs";
        Logger logger = Logger.getInstance();

        // Added by AVANZA\jawwad.ahmed on 09/02/2018 17:05:22
        public DataTable GetRegistrationsData(int months)
        {
            try
            {
                return graphs.GetRegistrationsData(months);
            }
            catch (Exception ex)
            {
                logger.Error(MODULE_NAME, "GetRegistrationsData", ex);
                throw ex;
            }
        }

        // Added by AVANZA\jawwad.ahmed on 09/02/2018 16:12:58
        public DataTable GetSmileyData(int months)
        {
            try
            {
                return graphs.GetSmileyData(months);
            }
            catch (Exception ex)
            {
                logger.Error(MODULE_NAME, "GetSmileyData", ex);
                throw ex;
            }
        }

        // Added by AVANZA\jawwad.ahmed on 09/02/2018 16:39:37
        public DataTable GetPaymentsData(int months)
        {
            try
            {
                return graphs.GetPaymentsData(months);
            }
            catch (Exception ex)
            {
                logger.Error(MODULE_NAME, "GetPaymentsData", ex);
                throw ex;
            }
        }

        // Added by AVANZA\jawwad.ahmed on 09/02/2018 16:39:20
        public DataTable GetExamData(int months)
        {
            try
            {
                return graphs.GetExamData(months);
            }
            catch (Exception ex)
            {
                logger.Error(MODULE_NAME, "GetExamData", ex);
                throw ex;
            }
        }

    }
}
