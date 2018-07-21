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
    public class DrivingAssessmentTest
    {
        DADrivingAssessmentTest oDADrivingAssessmentTest = new DADrivingAssessmentTest();

        public DataSet GetDrivingAssessmentTestForDriver(string refNum)
        {
            DACultureResources oDA = new DACultureResources();
            Entities.SP_USP_GetDrivingAssessmentTestForDriver usp = new Entities.SP_USP_GetDrivingAssessmentTestForDriver(refNum);
            DataSet ds = oDA.ExecuteStoredProcedure(Entities.SP_USP_GetDrivingAssessmentTestForDriver.SP_NAME, usp.ParamsList);
            if (ds != null)
            {
                if (!ds.Tables[0].Columns.Contains(Entities.SP_USP_GetDrivingAssessmentTestForDriver.MUTILPLE_PERSON) &&
                    !ds.Tables[0].Columns.Contains(Entities.SP_USP_GetDrivingAssessmentTestForDriver.NO_PERSON)
                   )
                {
                    ds.Tables[0].TableName = Entities.Persons.TABLE_NAME;
                    ds.Tables[1].TableName = Entities.DrivingAssessmentTest.TABLE_NAME;
                    ds.Tables[2].TableName = Entities.DrivingAssessmentDetails.TABLE_NAME;
                    ds.Tables[3].TableName = Entities.DrivingAssessmentImages.TABLE_NAME;
                }
            }
            return ds;
        }

        public DataSet PersistDrivingTest( DataSet ds )
        {
            oDADrivingAssessmentTest.PersistDrivingAssessmentTest(ds);
            return ds;
        }

        public static void GetDataTable(DataSet ds)
        {
            DataTable dt =  Entities.DrivingAssessmentTest.GetDataTable();
            dt.Rows.Add(dt.NewRow());
            ds.Tables.Add(dt);
            
        }
    }
    
}
