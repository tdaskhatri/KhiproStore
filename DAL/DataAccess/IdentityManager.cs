using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using eLearning.Common;
using System.Reflection;
using System.Collections;
using System.Data.Common;
namespace eLearning.DAL.DataAccess
{
    public class IdentityManager:DABase
    {
        public IdentityManager()
        {

        }
        public IdentityManager(Microsoft.Practices.EnterpriseLibrary.Data.Database DB)
           : base(DB)
        {

        }
        const string QRY_GET_TOKEN = "Select TABLE_NAME, NEXT_ID From ENTITY_TOKEN Where Upper (TABLE_NAME) = '{0}'";
        const string QRY_INS_TOKEN = "Insert Into ENTITY_TOKEN (TABLE_NAME, NEXT_ID) Values ('{0}', {1})";
        const string QRY_UPD_TOKEN = "Update ENTITY_TOKEN Set NEXT_ID = NEXT_ID + {1} Where TABLE_NAME = '{0}'";

        public Int64 GetNextId(string entityName)
        {
            return GetNextId(entityName, 1);
        }
        public Int64 GetNextId(string entityName, int nextIdsCount)
        {
            string query;
            Int64 nextId = -1;
            int result;
            DbTransaction tran = this.CreateTransaction();
            try
            {
                query = string.Format(QRY_UPD_TOKEN, entityName.ToUpper(), nextIdsCount);
                result = base.ExecuteNonQuery(query, tran);
                if (result > 0)
                {
                    DataSet tokenDS = base.ExecuteDataSet(string.Format(QRY_GET_TOKEN, entityName.ToUpper()), tran);
                    if (tokenDS.Tables[0].Rows.Count > 0)
                    {
                        nextId = Convert.ToInt64(tokenDS.Tables[0].Rows[0]["Next_Id"]);
                        nextId = nextId - nextIdsCount; // no need for +1 in this expression, cuz its assuption that this table has next Id not current Id
                    }
                }
                else
                {
                    query = string.Format(QRY_INS_TOKEN, entityName.ToUpper(), ++nextIdsCount);
                    result = base.ExecuteNonQuery(query, tran);
                    nextId = 1;
                }
                base.CommitTransaction(tran);
            }
            catch (Exception ex)
            {
                base.RollbackTransaction(tran);
                throw ex;
            }

            return nextId;
        }

    }
}
