using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using eLearning.Common.Utils;
using System.Data.Common;
using System.Data.SqlClient;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Resources;
using System.Reflection;
using System.Text;


namespace eLearning.DAL.DataAccess
{
    public class DABase
    {
        private DbTransaction Transaction { get; set; }
        static Database db = DatabaseFactory.CreateDatabase();
        DbConnection conn;
        private Logger logger = Logger.getInstance();
        private static readonly string MODULE_NAME = "DABase";
        protected string dbDateFunction = "GETDATE()";
      //  public SchemaManager SchemaManager { get; set; }
      //  public DefaultManager DefaultManager { get; set; }
     //   public TokenProvider TokenProvider { get; set; }
        public DABase()
        {
         //   this.DefaultManager = new DefaultManager(DABase.db);
         //   this.TokenProvider = new TokenProvider(DABase.db);
         //   this.SchemaManager = new SchemaManager(DABase.db);
            //
            // TODO: Add constructor logic here
            //
            //if(db == null)
            //    db = DatabaseFactory.CreateDatabase();


        }
        public DABase(Database dbname)
        {
            db = dbname;
        }
        protected Database DB
        {
            get { return db; }
        }

        //===========================================================================
        /// <summary>
        /// Take the SQL as input and execute it on database. 
        /// Normally use to persist data in DB.
        /// </summary>
        /// <param name="queryString">DML SQL statements e.g Insert / Update / Delete </param>
        /// <returns></returns>
        protected int ExecuteNonQuery(string queryString)
        {
            try
            {
                logger.Debug(MODULE_NAME, "ExecuteNonQuery", "QUERY|" + queryString);
                return db.ExecuteNonQuery(db.GetSqlStringCommand(queryString));
            }
            catch (Exception exception)
            {
                logger.Error(MODULE_NAME, "ExecuteNonQuery", queryString, exception);
                throw exception;
            }
        }
        protected int ExecuteNonQuery(DbCommand cmd)
        {
            try
            {
                logger.Debug(MODULE_NAME, "ExecuteNonQuery", "QUERY|" + cmd.CommandText);
                return db.ExecuteNonQuery(cmd);
            }
            catch (Exception exception)
            {
                logger.Error(MODULE_NAME, "ExecuteNonQuery", cmd.CommandText, exception);
                throw exception;
            }
        }
        protected int ExecuteNonQuery(DbCommand cmd, DbTransaction transaction)
        {
            try
            {
                logger.Debug(MODULE_NAME, "ExecuteNonQuery", "QUERY|" + cmd.CommandText);
                return db.ExecuteNonQuery(cmd, transaction);
            }
            catch (Exception exception)
            {
                logger.Error(MODULE_NAME, "ExecuteNonQuery", cmd.CommandText, exception);
                throw exception;
            }
        }
        protected int ExecuteNonQuery(string queryString, DbTransaction transaction)
        {
            try
            {
                logger.Debug(MODULE_NAME, "ExecuteNonQuery", "QUERY|" + queryString);
                return db.ExecuteNonQuery(db.GetSqlStringCommand(queryString), transaction);
            }
            catch (Exception exception)
            {
                logger.Error(MODULE_NAME, "ExecuteNonQuery", queryString, exception);
                throw exception;
            }
        }

        protected object ExecuteScalar(string queryString)
        {
            try
            {
                logger.Debug(MODULE_NAME, "ExecuteScalar", "QUERY|" + queryString);
                return db.ExecuteScalar(db.GetSqlStringCommand(queryString));
            }
            catch (Exception exception)
            {
                logger.Error(MODULE_NAME, "ExecuteScalar", queryString, exception);
                throw exception;
            }
        }

        protected object ExecuteScalar(string queryString, DbTransaction transaction)
        {
            try
            {
                logger.Debug(MODULE_NAME, "ExecuteScalar", "QUERY|" + queryString);
                return db.ExecuteScalar(db.GetSqlStringCommand(queryString), transaction);
            }
            catch (Exception exception)
            {
                logger.Error(MODULE_NAME, "ExecuteScalar", queryString, exception);
                throw exception;
            }
        }

      static  protected DataSet ExecuteDataSet(string queryString)
        {
            try
            {
               // logger.Debug(MODULE_NAME, "ExecuteDataSet", "QUERY|" + queryString);
                return db.ExecuteDataSet(db.GetSqlStringCommand(queryString));
            }
            catch (Exception exception)
            {
               // logger.Error(MODULE_NAME, "ExecuteDataSet", queryString, exception);
                throw exception;
            }
        }
        protected DataSet ExecuteDataSet(string queryString, DbTransaction transaction)
        {
            try
            {
                logger.Debug(MODULE_NAME, "ExecuteDataSet", "QUERY|" + queryString);
                return db.ExecuteDataSet(db.GetSqlStringCommand(queryString), transaction);
            }
            catch (Exception exception)
            {
                logger.Error(MODULE_NAME, "ExecuteDataSet", queryString, exception);
                throw exception;
            }
        }
        protected void ExecuteBulkCopy(DataTable dt, string tableName)
        {
            try
            {
                using (DbConnection connection = db.CreateConnection())
                {
                    connection.Open();
                    using (SqlBulkCopy copy = new SqlBulkCopy((SqlConnection)connection))
                    {
                        copy.DestinationTableName = tableName;
                        //Define column mappings
                        foreach (DataColumn col in dt.Columns)
                        {
                            copy.ColumnMappings.Add(col.ColumnName, col.ColumnName);
                        }
                        copy.WriteToServer(dt);
                    }
                }
            }
            catch (Exception exception)
            {
                logger.Error(MODULE_NAME, "ExecuteBulkCopy", exception);
                throw exception;
            }
        }

        //public DataSet ExecuteStoredProcedure(string procedureName, List<StoredProcedureParams> parametersList)
        //{
        //    DbCommand cmd = db.GetStoredProcCommand(procedureName);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    foreach (var item in parametersList)
        //    {
        //        if (item.ParamType == DbType.Object)
        //        {
        //            SqlParameter sqlParam = new SqlParameter(item.ParamName, item.ParamObject);
        //            sqlParam.SqlDbType = SqlDbType.Structured;
        //            sqlParam.TypeName = item.TypeName;
        //            cmd.Parameters.Add(sqlParam);
        //            //db.AddInParameter(cmd, item.ParamName, (DbType)item.ParamType, item.ParamObject);
        //        }
        //        else
        //        {
        //            if (item.ParamType.Equals(DbType.DateTime) && (item.ParamValue == null || item.ParamValue.Length <= 0))
        //            {
        //                item.ParamValue = DBNull.Value.ToString();
        //            }
        //            db.AddInParameter(cmd, item.ParamName, (DbType)item.ParamType, item.ParamValue);
        //        }
        //    }

        //    DataSet ds = db.ExecuteDataSet(cmd);
        //    if (ds != null && ds.Tables != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        //    {

        //        if (ds.Tables[0].Columns.Contains("ERROR_MESSAGE"))
        //        {
        //            throw new Exception("Error Occured While executing the stored procedure at break point:" + ds.Tables[0].Rows[0]["ERROR_MESSAGE"].ToString());
        //        }
        //    }
        //    return ds;
        //}

        public DbTransaction CreateTransaction()
        {
            conn = db.CreateConnection();
            conn.Open();
            return conn.BeginTransaction();
        }
        public void CommitTransaction(DbTransaction transaction)
        {
            transaction.Commit();
            conn.Close();
        }
        public void RollbackTransaction(DbTransaction transaction)
        {
            transaction.Rollback();
            conn.Close();
        }

        /// <summary>
        /// This method uses SearhOptions class to apply pagination and sorting 
        /// on existing queries, following points to be considered before using
        /// this methods.
        /// 
        /// 1. Query should not have (TOP n *)
        /// 2. Query should not have ORDER BY clause
        /// 3. Query may or may not have WHERE clause
        /// 4. In SearchOptions default SortExpression is required
        /// 
        /// </summary>
        /// <param name="sql">Existing query, please see the description for details.</param>
        /// <param name="options">Search options to apply on query.</param>
        /// <returns></returns>
        

        #region General Functions 
        public static string RectifyValues(string stringWithSingleQuote)
        {
            stringWithSingleQuote = stringWithSingleQuote.Trim();
            StringBuilder buffer = new StringBuilder(stringWithSingleQuote);
            buffer = buffer.Replace("\'", "\''");
            //buffer = buffer.Replace(">","&gt;");
            //buffer = buffer.Replace("<","&lt;");
            //buffer = buffer.Replace("\"","&quote;");

            return buffer.ToString();
        }
        #endregion 

        #region GetFieldValue
        
       
        /// <summary>
        /// Use this method if you have a nullable string column
        /// </summary>
        /// <param name="dr"></param>
        /// <param name="fieldName"></param>
        /// <param name="encloseQuotation"></param>
        /// <returns></returns>
        
        
        
        
        
        #endregion
    }
}