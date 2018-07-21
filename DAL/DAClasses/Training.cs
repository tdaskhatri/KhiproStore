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
    public class Training
    {
        DATraining oDATraining = new DATraining();
        public void Save(DataSet ds ,string modifiedBy,string trainerId)
        {
            DataRow training= ds.Tables[Entities.TrainingInstance.TABLE_NAME].Rows[0];
            oDATraining.ModifyTraining(training[Entities.TrainingInstance.TRAINING_ID].ToString(),
                                       "-1",
                                       training[Entities.TrainingInstance.START_DATE].ToString(),
                                       trainerId,
                                       modifiedBy,
                                       "-1"
                                       );
        }


        public DataSet Search(Dictionary<Enumaration.SearchTrainingCriteria, Object> criteria, int pageToRetrieve, String orderBy)
        {
            DataSet ds = new DataSet();

            ds = oDATraining.Search(criteria, pageToRetrieve, orderBy, Enumaration.RecordsPerPage);

            return ds;
        }

        public DataSet GetTrainingById(string trainingId)
        {
            DataSet ds = oDATraining.GetTrainingById(trainingId);
            return ds;
          
        }

        public DataSet ModifyTraining(string trainingId, string trainingSchId, string scheduledDate, string trainerId, string modifiedBy, string cascadeSchedule)
        {
            ModifyTrainingSchedule(trainingId, trainingSchId, scheduledDate, trainerId, modifiedBy, cascadeSchedule);
             return GetTrainingById(trainingId);
        }

        public void ModifyTrainingSchedule(string trainingId, string trainingSchId, string scheduledDate, string trainerId, string modifiedBy, string cascadeSchedule)
        {
            
            oDATraining.ModifyTraining(trainingId,
                                       trainingSchId,
                                       scheduledDate,
                                       trainerId,
                                       modifiedBy,
                                       cascadeSchedule
                                       );
        }
      
    }
    
}
