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
    public class Reports
    {

        DAReports oDAReports = new DAReports();
        public DataSet GetPassFailReport(Dictionary<Enumaration.CriteriaKeysReportPassFail, Object> criteria)
        {

            DataSet ds = oDAReports.GetPassFailReport(criteria);

            return ds;
        }

        // Added by Fahim Nasir on 26/01/2017 14:49:27
        public DataSet GetLearningFileReport(int CustomerServiceContractId)
        {
            DataSet ds = oDAReports.GetLearningFileReport(CustomerServiceContractId);
            return ds;
        }
        public DataSet GetPsychometricReport(Dictionary<Enumaration.CriteriaKeysReportPsychometric, Object> criteria)
        {

            DataSet ds = oDAReports.GetPsychometricReport(criteria);

            return ds;
        }

        public DataSet GetMysteryShopperReport(Dictionary<Enumaration.CriteriaKeysReportMysteryShopper, Object> criteria)
        {

            DataSet ds = new DataSet();
            ds = oDAReports.GetMysteryShopperReport(criteria);
            ds.Tables[0].TableName = "MysteryShopperTabularData";
            ds.Tables[1].TableName = "YearVersusScore";
            ds.Tables[2].TableName = "NationalityVersusScore";
            ds.Tables[3].TableName = "PhaseWiseScore";
            ds.Tables[4].TableName = "Issues";
            
            return ds;
        }
        public DataSet GetTestAnalysisReport(Dictionary<Enumaration.CriteriaKeysReportPassFail, Object> criteria)
        {

            DataSet ds = oDAReports.GetTestAnalysisReport(criteria);

            return ds;
        }
        public DataSet GetTestWiseQuestionAllocation(Dictionary<Enumaration.CriteriaKeysReportPassFail, Object> criteria)
        {

            DataSet ds = oDAReports.GetTestWiseQuestionAllocation(criteria);

            return ds;
        }

        public DataSet GetTrainingActivityReport(Dictionary<Enumaration.CriteriaKeysReportTrainerActivity, Object> criteria)
        {

            DataSet ds = new DataSet();
            ds = oDAReports.GetTrainingActivityReport(criteria);
            ds.Tables[0].TableName = "TrainerActivityLog";
            

            return ds;
        }

        public DataSet GetDashboard(Dictionary<Enumaration.CriteriaKeysReportDashboard, Object> criteria)
        {

            DataSet ds = oDAReports.GetDashboard(criteria);
            ds.Tables[0].TableName = "CustomerPerpectiveMisc";
            ds.Tables[1].TableName = "NoOfDriversPerTrainingType";
            ds.Tables[2].TableName = "DriverSatisfactionSurveyRate";
            
            
            return ds;
        }

        public DataSet GetTraineeAttendanceReport(Dictionary<Enumaration.CriteriaKeysReportTraineeAttendaceReport, Object> criteria)
        {

            DataSet ds = new DataSet();
            ds = oDAReports.GetTraineeAttendanceReport(criteria);
            ds.Tables[0].TableName = "TraineeAttendence";


            return ds;
        }

        
    }
}
