using eLearning.Common.Utils;
using eLearning.DAL.MakerChecker;
using eLearning.DAL.WebService.Components;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace eLearning.DAL.WebService
{
    public class DAMiddleware
    {
        private Database Database { get; set; }
        public SchemaManager SchemaManager { get; set; }

        public DAMiddleware()
        {
            try
            {
                this.Database = DatabaseFactory.CreateDatabase();
                this.SchemaManager = new SchemaManager(this.Database);
            }
            catch (Exception ex)
            {
                Logger.getInstance().Error("Middleware", "DAMiddleware()", ex);
                throw ex;
            }
        }

        public MwClassInfoDictionary GetClasses()
        {
            MwClassInfoDictionary classes = new MwClassInfoDictionary();

            string sql = @"SELECT * FROM WEB_SERVICE_CLASSES;";

            DataSet dataSet = this.Database.ExecuteDataSet(CommandType.Text, sql);

            foreach (DataRow row in dataSet.Tables[0].Rows)
            {
                var classInfo = MwClassInfo.FromDataRow(row);
                classInfo.Properties = this.GetProperties(classInfo.Id);
                classes.Add(classInfo.FullName, classInfo);
            }

            return classes;
        }

        //Added by Fahim Nasir 
        public DataTable GetWSUserDetails(string username, string password)
        {
            string query = @"SELECT * FROM USERS WHERE USER_ID = '{0}' AND PASSWORD = '{1}' 
                            AND IS_WEB_SERVICE_USER = 1";
            query = string.Format(query, username, password);
            DataSet ds = this.Database.ExecuteDataSet(CommandType.Text, query);
            return ds.Tables[0];
        }
        public MwPropertyInfoDictionary GetProperties(string classId)
        {
            string template = @"SELECT * FROM [dbo].[WEB_SERVICE_PROPERTIES] P WHERE P.CLASS_ID = {0};";

            string sql = string.Format(template, classId);

            DataSet dataSet = this.Database.ExecuteDataSet(CommandType.Text, sql);
            MwPropertyInfoDictionary dictionary = new MwPropertyInfoDictionary();

            foreach (DataRow row in dataSet.Tables[0].Rows)
            {
                var info = MwPropertyInfo.FromDataRow(row);
                dictionary.Add(info.PropertyName, info);
            }

            return dictionary;
        }

        public DataTable GetRequestLogTable()
        {
            return this.SchemaManager.GetTableAsDefault("WEB_SERVICE_CALL_LOGS");
        }

        public void InsertRequestLogTable(DataTable table)
        {
            String query = Shared.GetInsertQuery(table.Rows[0]);
            this.Database.ExecuteNonQuery(CommandType.Text, query);
        }

        public void UpdateRequestLogTable(DataTable table)
        {
            String query = Shared.GetUpdateQuery(table.Rows[0]);
            this.Database.ExecuteNonQuery(CommandType.Text, query);
        }

        public DataTable GetDataLogTable(string tableName)
        {
            return this.SchemaManager.GetTableAsDefault(tableName);
        }

        public void InsertTables(ICollection<DataTable> tables)
        {
            Script script = new Script("DATA INSERTING FOR TABLES");

            foreach (var table in tables)
            {
                script.Comment("SCRIPTS FOR " + table.TableName);

                foreach(DataRow row in table.Rows)
                {
                    String query = Shared.GetInsertQuery(row);
                    script += query;
                }
            }

            this.Database.ExecuteNonQuery(CommandType.Text, script.ToString(true));
        }
    }
}

