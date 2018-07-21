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
    public class ExamTemplates
    {
        DAExamTemplate objExamTemplate = new DAExamTemplate();
        public DataSet Search(Dictionary<Enumaration.SearchExamTemplateCriteria, Object> criteria)
        {
            return objExamTemplate.Search(criteria);
        }

        public DataSet GetExamTemplateById(String id)
        {

            DataSet dsET = objExamTemplate.GetExamTemplatesById(id);


            DataSet dsReturn = GetExamTemplateDataSet(); ;

            DataTable dtCR = new DataTable();
            dtCR = dsReturn.Tables[Entities.CultureResources.TABLE_NAME];
            DataTable dtET = new DataTable();
            dtET = dsReturn.Tables[Entities.TestTemplate.TABLE_NAME];
            //DataTable dtSWQ = Entities.TestTemplateSectionWiseQuestions.GetDataTable();
            DataRow element = dsET.Tables[0].Rows[0];
            DataRow rowET = dtET.NewRow();
            rowET[Entities.TestTemplate.ID] = element[Entities.TestTemplate.ID];
            rowET[Entities.TestTemplate.DURATION] = element[Entities.TestTemplate.DURATION];
            rowET[Entities.TestTemplate.APPROVED_BY] = element[Entities.TestTemplate.APPROVED_BY];
            rowET[Entities.TestTemplate.APPROVED_ON] = element[Entities.TestTemplate.APPROVED_ON];
            rowET[Entities.TestTemplate.CREATED_BY] = element[Entities.TestTemplate.CREATED_BY];
            rowET[Entities.TestTemplate.CREATED_ON] = element[Entities.TestTemplate.CREATED_ON];
            rowET[Entities.TestTemplate.CULTURE_NAME] = element[Entities.TestTemplate.CULTURE_NAME];
            rowET[Entities.TestTemplate.IS_ACTIVE] = element[Entities.TestTemplate.IS_ACTIVE];
            rowET[Entities.TestTemplate.IS_PERCENTAGE] = element[Entities.TestTemplate.IS_PERCENTAGE];
            rowET[Entities.TestTemplate.NO_OF_QUESTIONS] = element[Entities.TestTemplate.NO_OF_QUESTIONS];
            rowET[Entities.TestTemplate.PASSING_CHANGE_REASON] = element[Entities.TestTemplate.PASSING_CHANGE_REASON];
            rowET[Entities.TestTemplate.PASSING_SCORE] = element[Entities.TestTemplate.PASSING_SCORE];
            rowET[Entities.TestTemplate.GENERAL_INSTRUCTIONS] = element[Entities.TestTemplate.GENERAL_INSTRUCTIONS];
            rowET[Entities.TestTemplate.EXAM_INFO] = element[Entities.TestTemplate.EXAM_INFO];
            rowET[Entities.TestTemplate.EXAM_INFO_PLACE_HOLDER] = element[Entities.TestTemplate.EXAM_INFO_PLACE_HOLDER];
            dtET.Rows.Add(rowET);
            DataRow rowCR = dtCR.NewRow();
            rowCR[Entities.CultureResources.ID] = element[Entities.TestTemplate.CULTURE_NAME];
            rowCR[Entities.CultureResources.RES_EN] = element[Entities.CultureResources.RES_EN];
            rowCR[Entities.CultureResources.RES_AR] = element[Entities.CultureResources.RES_AR];
            rowCR[Entities.CultureResources.RES_UR] = element[Entities.CultureResources.RES_UR];
            dtCR.Rows.Add(rowCR);

            DataSet dsSWQ = objExamTemplate.GetSectionWiseQuestionByExamTemplatesById(id);
            dsReturn.Tables.Add(dsSWQ.Tables[0].Copy());

            return dsReturn;
        }
        public void PersistExamTemplate(DataSet ds)
        {

            DAExamTemplate daET = new DAExamTemplate();
            DACultureResources daCR = new DACultureResources();
            using (DbTransaction transaction = daET.CreateTransaction())
            {
                try
                {
                    DataTable dtCR = ds.Tables[Entities.CultureResources.TABLE_NAME];
                    DataTable dtET = ds.Tables[Entities.TestTemplate.TABLE_NAME];
                    DataTable dtSWQ = ds.Tables[Entities.TestTemplateSectionWiseQuestions.TABLE_NAME];
                    daCR.PersistCultureResource(dtCR, transaction);
                    dtET.Rows[0][Entities.TestTemplate.CULTURE_NAME] = (Int64)dtCR.Rows[0][Entities.CultureResources.ID];
                    daET.PersistExamTemplates(dtET, dtSWQ, transaction);
                    daET.CommitTransaction(transaction);
                }
                catch (Exception e)
                {
                    daET.RollbackTransaction(transaction);
                    throw e;
                }
            }

        }

        public static DataSet GetExamTemplateDataSet()
        {
            DataSet ds = new DataSet();
            ds.Tables.Add(Entities.TestTemplate.GetDataTable());
            ds.Tables.Add(Entities.CultureResources.GetDataTable());
            //ds.Tables.Add(Entities.TestTemplateSectionWiseQuestions.GetDataTable() );

            return ds;
        }

        // AVANZA\jawwad.ahmed - 03/02/2017 09:38:05
        public void ScheduleCustomerExam(DataRow row1, DataRow row2, CustomerTrackingHistory history)
        {
            this.objExamTemplate.ScheduleCustomerExam(row1, row2, history);
        }

        // AVANZA\jawwad.ahmed - 03/02/2017 09:38:03
        public void RescheduleCustomerExam(DataRow row1, DataRow row2, DataRow row3, CustomerTrackingHistory history)
        {
            this.objExamTemplate.ReScheduleCustomerExam(row1, row2, row3, history);
        }

        // AVANZA\jawwad.ahmed - 03/02/2017 09:37:57
        public DataTable GetExamCodes(string subServiceId)
        {
            return this.objExamTemplate.GetExamCodes(subServiceId);
        }

        // AVANZA\jawwad.ahmed - 03/02/2017 09:37:52
        public bool IsExamScheduled(string customerId, string examCode,string CSCId)
        {
            return this.objExamTemplate.IsExamScheduled(customerId, examCode,CSCId);
        }

        // AVANZA\jawwad.ahmed - 03/02/2017 09:37:48
        public DataTable GetExamCodeAndId(string customerServiceExamId)
        {
            return this.objExamTemplate.GetExamCodeAndId(customerServiceExamId);
        }

        // AVANZA\jawwad.ahmed - 03/02/2017 09:37:46
        public DataTable GetCustomerIdAndServiceContractId(string trackingFileNo, string contractNo)
        {
            return this.objExamTemplate.GetCustomerIdAndServiceContractId(trackingFileNo,  contractNo);
        }

        // Added by MUHAMMADUZAIR\avanza on 21/09/2017 10:26:45
        public DataTable GetCustomerIdAndServiceContractId(string trackingFileNo)
        {
            return this.objExamTemplate.GetCustomerIdAndServiceContractId(trackingFileNo);
        }

        // Added by avanza\MUHAMMADUZAIR on 06/09/2017 12:24:37
        public DataTable GetRTAExamNames()
        {
            return this.objExamTemplate.GetRTAExamNames();
        }
        // Added by avanza\MUHAMMADUZAIR on 06/09/2017 12:24:39
        public DataTable GetETDIExamNames()
        {
            return this.objExamTemplate.GetETDIExamNames();
        }
        // Added by MUHAMMADUZAIR\avanza on 11/09/2017 14:49:54
        public int IsRTAExam(string examId)
        {
            return this.objExamTemplate.IsRTAExam(examId);
        }

        // Added by AVANZA\muhammad.uzair on 19/10/2017 17:40:44
        public DataTable GetActiveExamsByType(string isETTC, string isETDI)
        {
            return objExamTemplate.GetActiveExamsByType(isETTC, isETDI);
        }

        // Added by AVANZA\muhammad.uzair on 19/10/2017 18:22:34
        public DataTable GetActiveVehicles()
        {
            return objExamTemplate.GetActiveVehicles();
        }

        // Added by AVANZA\muhammad.uzair on 19/10/2017 19:22:30
        public DataTable GetCourseCodesAndIds()
        {
            return objExamTemplate.GetCourseCodeAndIds();
        }

        // Added by AVANZA\muhammad.uzair on 20/10/2017 10:51:45
        public void SaveExamTemplate(DataRow examTemplate, DataTable sectionTemplates)
        {
            objExamTemplate.SaveExamTemplate(examTemplate, sectionTemplates);
        }

        // Added by AVANZA\muhammad.uzair on 20/10/2017 11:02:54
        public DataTable GetSections()
        {
            return objExamTemplate.GetSections();
        }

        // Added by AVANZA\muhammad.uzair on 20/10/2017 12:25:03
        public void UpdateExamTemplate(string templateId, DataRow examTemplate, DataTable sectionTemplates)
        {
            objExamTemplate.UpdateExamTemplate(templateId, examTemplate, sectionTemplates);
        }

        // Added by AVANZA\muhammad.uzair on 20/10/2017 14:32:10
        public DataSet GetTemplateData(string templateId)
        {
            return objExamTemplate.GetTemplateData(templateId);
        }

        // Added by AVANZA\muhammad.uzair on 20/10/2017 16:55:24
        public DataTable GetSearchTemplateData(string whereClause)
        {
            return objExamTemplate.GetSearchTemplateData(whereClause);
        }

        // Added by AVANZA\muhammad.uzair on 13/11/2017 18:44:20
        public bool isExamPassed(string customerId, string examCode, string CSCId)
        {
            return this.objExamTemplate.isExamPassed(customerId, examCode, CSCId);
        }

        // Added by Muhammad Uzair on 26/01/2018 10:45:24 
        public int NumberOfQuestionsInSectionCourse(string sectionId, string courseId)
        {
            return this.objExamTemplate.NumberOfQuestionsInSectionCourse(sectionId, courseId);
        }
    }
}
