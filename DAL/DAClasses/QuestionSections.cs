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
    public class QuestionSections
    {
        DAQuestionSections oDAQs = new DAQuestionSections();
        
        public DataSet Search(Dictionary<Enumaration.SearchSectionKeys, Object> searchCriteria)
        {
            return oDAQs.Search(searchCriteria); 
        }
        public DataSet GetQuestionSectionById(string id)
        {
            DACultureResources ODaCr = new DACultureResources();
            DataSet dsReturn = oDAQs.GetSectionById(id);
            dsReturn.Tables[0].TableName = Entities.QuestionSections.TABLE_NAME;
            dsReturn.Tables.Add ( ODaCr.GetCultureResourceById(dsReturn.Tables[0].Rows[0][Entities.QuestionSections.SECTION_NAME].ToString() ) 
                                );


            return dsReturn;
        }
        public void PersistQuestionSections(DataSet ds)
        {

            DAQuestionSections daQS = new DAQuestionSections();
            DACultureResources daCR = new DACultureResources();
            using (DbTransaction transaction = daQS.CreateTransaction())
            {
                try
                {
                    DataTable dtCR = ds.Tables[Entities.CultureResources.TABLE_NAME];
                    DataTable dtQS = ds.Tables[Entities.QuestionSections.TABLE_NAME];
                    
                    daCR.PersistCultureResource(dtCR, transaction);
                    dtQS.Rows[0][Entities.QuestionSections.SECTION_NAME] = (Int64)dtCR.Rows[0][Entities.CultureResources.ID];
                    daQS.PersistQuestionSections(dtQS,  transaction);
                    daQS.CommitTransaction(transaction);
                }
                catch (Exception e)
                {
                    daQS.RollbackTransaction(transaction);
                    throw e;
                }
            }

        }
        public static DataSet GetQuestionSectionsDataSet()
        {
            DataSet ds = new DataSet();
            ds.Tables.Add(Entities.QuestionSections.GetDataTable());
            ds.Tables.Add(Entities.CultureResources.GetDataTable());
            

            return ds;
        }
        

    }
}
