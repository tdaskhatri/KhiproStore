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
    public class TrainingTemplate
    {
        public void Save(DataSet ds)
        {
            DACultureResources oDACr = new DACultureResources();
            DataRow drTrainingTemplate= null;
            using (System.Data.Common.DbTransaction transaction = oDACr.CreateTransaction())
            {
                try
                {
                    drTrainingTemplate = ds.Tables[Entities.TrainingTemplate.TABLE_NAME].Rows[0];
                    DATrainingTemplate oDATrainingTemplate = new DATrainingTemplate();
                    DATrainingTempFinesOnAbsent oDAFines = new DATrainingTempFinesOnAbsent();
                    DATrainingTemplatePlan oDAPlan= new DATrainingTemplatePlan();


                    //Saving culture resources for TrainingTemplate desc:Start

                    DataTable dtTrainingTemplateDescCr = ds.Tables[Enumaration.ManageTrainingTemplateKeys.DT_TrainingTemplateDescriptionCultureRes];
                    
                    oDACr.PersistCultureResource(dtTrainingTemplateDescCr, transaction);
                    drTrainingTemplate[Entities.TrainingTemplate.DESCRIPTION] = (Int64)dtTrainingTemplateDescCr.Rows[0][Entities.CultureResources.ID];

                    //Saving culture resources for TrainingTemplate desc:Finish

                    //Saving culture resources for TrainingTemplate name:Start

                    DataTable dtTrainingTemplateNameCr = ds.Tables[Enumaration.ManageTrainingTemplateKeys.DT_TrainingTemplateNameCultureRes];

                    oDACr.PersistCultureResource(dtTrainingTemplateNameCr, transaction);
                    drTrainingTemplate[Entities.TrainingTemplate.TRAINING_NAME] = (Int64)dtTrainingTemplateNameCr.Rows[0][Entities.CultureResources.ID];

                    //Saving culture resources for TrainingTemplate name:Finish


                    //Saving TrainingTemplate Start

                    oDATrainingTemplate.SaveTrainingTemplate(transaction, drTrainingTemplate);
                    string TrainingTemplateId = drTrainingTemplate[Entities.TrainingTemplate.TRAINING_TEMP_ID].ToString();
                    //Saving TrainingTemplate Finish
                    
                    //Saving TrainingTemplate Fine Start

                     DataTable dtTrainingTemplateMaterial = ds.Tables[Entities.TrainingTempFinesOnAbsent.TABLE_NAME];
                     oDAFines.DeleteTrainingTempFinesOnAbsentForTrainingTempId(transaction, TrainingTemplateId);
                     foreach (DataRow row in dtTrainingTemplateMaterial.Rows)
                     {
                         row[Entities.TrainingTempFinesOnAbsent.TEMP_FINES_ABSENT_ID] = DBNull.Value;
                         row[Entities.TrainingTempFinesOnAbsent.TRAINING_TEMP_ID] = int.Parse(TrainingTemplateId);
                         oDAFines.SaveFinesOnAbsent(transaction, row);
                     }

                     //Saving TrainingTemplate Fine Finish

                     //Saving TrainingTemplate Plan Start

                     DataTable dtPlan= ds.Tables[Entities.TrainingTemplatePlan.TABLE_NAME];
                     oDAPlan.DeleteTrainingTemplatePlanForTrainingTempId(transaction, TrainingTemplateId);
                     foreach (DataRow row in dtPlan.Rows)
                     {
                         row[Entities.TrainingTemplatePlan.TEMPLATE_PLAN_ID] = DBNull.Value;
                         row[Entities.TrainingTemplatePlan.TRAINING_TEMP_ID] = int.Parse(TrainingTemplateId);
                         oDAPlan.SavePlan(transaction, row);
                     }

                     //Saving TrainingTemplate Plan  Finish

                    oDACr.CommitTransaction(transaction);
                    
                }

                catch (Exception ex)
                {
                    
                    
                    oDACr.RollbackTransaction(transaction);
                    throw ex;
                }
            }
            if (drTrainingTemplate != null)
            {
                PersistTrainingXML(drTrainingTemplate);
            }
        }

        private void PersistTrainingXML(DataRow drTraining)
        {
            DATrainingTemplate oDA = new DATrainingTemplate();

            string xmlId = "-1";
            if (drTraining[Entities.TrainingTemplate.XML_ID] != DBNull.Value)
            {
                xmlId = drTraining[Entities.TrainingTemplate.XML_ID].ToString();
            }
            Entities.SP_USP_PersistTrainingCultureXML sp = new Entities.SP_USP_PersistTrainingCultureXML(drTraining[Entities.TrainingTemplate.TRAINING_TEMP_ID].ToString(),
                                                                                                         xmlId
                                                                                                         );
            DataSet dsXML = oDA.ExecuteStoredProcedure(Entities.SP_USP_PersistTrainingCultureXML.SP_NAME, sp.ParamsList);
            if (xmlId.Equals("-1"))
            {
                drTraining[Entities.TrainingTemplate.XML_ID] = Convert.ToInt64(dsXML.Tables[0].Rows[0][Entities.CultureXML.XML_ID].ToString());
                

            }

           
        }
        public DataSet Search(Dictionary<Enumaration.SearchTrainingTemplateCriteria, Object> criteria, int pageToRetrieve, String orderBy)
        {
            DataSet ds = new DataSet();
            DATrainingTemplate oDa = new DATrainingTemplate();
            ds = oDa.Search(criteria, pageToRetrieve, orderBy, Enumaration.RecordsPerPage);

            return ds;
        }
        public static DataSet GetDataSetForTrainingTemplate()
        {
            DataSet ds = new DataSet();

            DataTable dtTrainingTemplate = Entities.TrainingTemplate.GetDataTable();
            dtTrainingTemplate.Rows.Add(dtTrainingTemplate.NewRow());
            ds.Tables.Add(dtTrainingTemplate);
            
            DataTable dtTrainingTemplateDescCultureRes = Entities.CultureResources.GetDataTable();
            dtTrainingTemplateDescCultureRes.TableName = Enumaration.ManageTrainingTemplateKeys.DT_TrainingTemplateDescriptionCultureRes;
            dtTrainingTemplateDescCultureRes.Rows.Add(dtTrainingTemplateDescCultureRes.NewRow());
            ds.Tables.Add(dtTrainingTemplateDescCultureRes);

            DataTable dtTrainingTemplateNameCultureRes = Entities.CultureResources.GetDataTable();
            dtTrainingTemplateNameCultureRes.TableName = Enumaration.ManageTrainingTemplateKeys.DT_TrainingTemplateNameCultureRes;
            dtTrainingTemplateNameCultureRes.Rows.Add(dtTrainingTemplateNameCultureRes.NewRow());
            ds.Tables.Add(dtTrainingTemplateNameCultureRes);

            DataTable dtTrainingTemplateFines = Entities.TrainingTempFinesOnAbsent.GetDataTable();
            ds.Tables.Add(dtTrainingTemplateFines);

            DataTable dtTrainingTemplatePlan = Entities.TrainingTemplatePlan.GetDataTable();
            ds.Tables.Add(dtTrainingTemplatePlan);

            return ds;
        }
        public DataSet GetTrainingTemplateById(string TrainingTemplateId)
        {
            DATrainingTemplate oDATrainingTemplate = new DATrainingTemplate();
            DataSet ds = oDATrainingTemplate.GetTrainingTemplateById(TrainingTemplateId);
            ds.Tables[0].TableName = Entities.TrainingTemplate.TABLE_NAME;
            ds.Tables[1].TableName = Enumaration.ManageTrainingTemplateKeys.DT_TrainingTemplateDescriptionCultureRes;
            ds.Tables[2].TableName = Enumaration.ManageTrainingTemplateKeys.DT_TrainingTemplateNameCultureRes;
            ds.Tables[3].TableName = Entities.TrainingTempFinesOnAbsent.TABLE_NAME;
            ds.Tables[4].TableName = Entities.TrainingTemplatePlan.TABLE_NAME;
            ds.Tables[5].TableName = Entities.CultureXML.TABLE_NAME;
            return ds;
        }

        public DataTable GetPreReqTrainingTemplates(String trainingTemplateId)
        {
            DATrainingTemplate oDATrainingTemplate = new DATrainingTemplate();
            return oDATrainingTemplate.GetPreReqTrainingTemplates(trainingTemplateId);
        }
        public DataTable GetAllTrainingPlanActivities()
        {
            DATrainingTemplate oDATrainingTemplate = new DATrainingTemplate();
            return oDATrainingTemplate.GetAllTrainingPlanActivities();
        }
        public DataTable GetDefaultTraining()
        {
            DATrainingTemplate oDATrainingTemplate = new DATrainingTemplate();
            return oDATrainingTemplate.GetDefaultTraining();
        }
        
    }
    
}
