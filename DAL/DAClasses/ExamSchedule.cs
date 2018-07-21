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
    public class ExamSchedule
    {
        DATest objDATest = new DATest();
        

        public DataSet Search(Dictionary<Enumaration.SearchExamScheduleCriteria, Object> criteria,int pageToRetrieve, String orderBy)
        {

            return objDATest.Search(criteria, pageToRetrieve, orderBy, Enumaration.RecordsPerPage);
        }



        public DataSet GetExamSchedulesById(Int64 id)
        {

            DataSet ds = objDATest.GetExamSchedulesById(id);
            ds.Tables[0].TableName = Entities.Test.TABLE_NAME;
            
            DAExamTemplate oDAET = new DAExamTemplate();
            DataSet dsET =  oDAET.GetExamTemplatesById(ds.Tables[0].Rows[0][Entities.Test.TEST_TEMP_ID].ToString() );
            dsET.Tables[0].TableName = Entities.TestTemplate.TABLE_NAME;
            ds.Tables.Add(  dsET.Tables[Entities.TestTemplate.TABLE_NAME].Copy() );

            DATestTakers oDATT       = new DATestTakers();
            DataSet dstt             = oDATT.GetTestTakersByTestId( ds.Tables[0].Rows[0][Entities.Test.ID].ToString() );
            dstt.Tables[0].TableName = Entities.TestTakers.TABLE_NAME;
            ds.Tables.Add(dstt.Tables[Entities.TestTakers.TABLE_NAME].Copy());
            
            return ds;
        }

        public DataSet GetExamSchedulesById(string id)
        {

            return GetExamSchedulesById(Convert.ToInt64(id));
        }


        public DataTable PersistTest(  DataSet ds )
        {

            return objDATest.PersistTest(ds.Tables[Entities.Test.TABLE_NAME]);
        
        }
        public static DataSet GetExamScheduleDataSet()
        {
            DataSet ds = new DataSet();
            ds.Tables.Add(Entities.Test.GetDataTable());
            //ds.Tables.Add(Entities.CultureResources.GetDataTable());
            //ds.Tables.Add(Entities.TestTemplateSectionWiseQuestions.GetDataTable() );

            return ds;
        }
        public static DataSet GetTestTakersQuestionByPersonIdTestId(string personId, string testId)
        {
            DATestTakers objDATestTakers = new DATestTakers();
            return objDATestTakers.GetTestTakersQuestionByPersonIdTestId(personId, testId);
        }
        public void UpdateTestTakerStatusAsPresent(string testTakerId, DbTransaction trans)
        {
            DATestTakers objDATestTakers = new DATestTakers();
            Dictionary<Enumaration.UpdateTestTakerOptionalKeys ,Object> criteria = new Dictionary<Enumaration.UpdateTestTakerOptionalKeys,object>();
            criteria.Add(Enumaration.UpdateTestTakerOptionalKeys.Status, Enumaration.TestTakerStatus.Present);
            criteria.Add(Enumaration.UpdateTestTakerOptionalKeys.StartedOn, DateTime.Now);
            objDATestTakers.UpdateTestTaker(testTakerId,criteria,trans);
        }
        
        // amjad
        public DataSet GetCustomerExamDetails(string customerId, string customerServContrId)
        {
                DAExamTemplate daExTm = new DAExamTemplate();
                return daExTm.GetCustomerExamDetails(customerId, customerServContrId);
        }

        // jawwad.ahmed
        public DataSet CancelCustomerExam(string customerServiceExamId, string userId)
        {
            DAExamTemplate daExTm = new DAExamTemplate();
            return daExTm.CancelCustomerExam(customerServiceExamId, userId);
        }

        // Added by avanza\MUHAMMADUZAIR on 06/09/2017 17:48:48
        public void UpdateExamStatus(string customerServiceExamId, string result)
        {
            DAExamTemplate daExTm = new DAExamTemplate();
            daExTm.UpdateExamStatus(customerServiceExamId, result);
        }

        // Added by MUHAMMADUZAIR\avanza on 20/09/2017 17:50:02
        public string GetExamNameFromCustomerExamId(string customerServiceExamId)
        {
            DAExamTemplate daExTm = new DAExamTemplate();
            return daExTm.GetExamNameFromCustomerExamId(customerServiceExamId);
        }

        // amjad
        public DataSet GetCustomerExamBookingDetails(string CSEID)
        {
            DAExamTemplate daExTm = new DAExamTemplate();
            return daExTm.GetCustomerExamBookingDetails(CSEID);
        }

    }
}
