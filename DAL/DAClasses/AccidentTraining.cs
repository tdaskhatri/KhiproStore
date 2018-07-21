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
    public class AccidentTraining
    {
        DAAccidentRequest oDa = new DAAccidentRequest();
        
        public void Save(DataSet ds)
        {
            using ( DbTransaction transaction = oDa.CreateTransaction())
            {
                try
                {
                    oDa.Save(null, ds.Tables[Entities.Request.TABLE_NAME].Rows[0]);
                }
                catch (Exception e)
                {
                    oDa.RollbackTransaction(transaction);
                    throw e;
                }
            }
            
        }
        public static DataSet GetPageDataSet()
        {
            DataSet ds = new DataSet();
            ds.Tables.Add(Entities.Request.GetDataTable());
            ds.Tables[Entities.Request.TABLE_NAME].Rows.Add(ds.Tables[Entities.Request.TABLE_NAME].NewRow());
           
            return ds;
        }
        public DataSet GetRequestById(string id)
        {
            DataSet ds = new DataSet();
            ds=oDa.GetRequestById(id);
            
            return ds;
        }

        
    }
}
