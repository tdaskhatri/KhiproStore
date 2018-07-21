using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace eLearning.DAL.MakerChecker
{
    public class Request
    {
        public DataSet DataSet { get; set; }
        public List<DataTable> MasterTables { get; set; }
        public List<DataTable> DefaultTables { get; set; }
        public List<DataTable> RelationalTables { get; set; }

        public Request(DataSet dataset)
        {
            this.DataSet = dataset;
            this.MasterTables = new List<DataTable>();
            this.DefaultTables = new List<DataTable>();
            this.RelationalTables = new List<DataTable>();

            int i = 2;
            foreach (DataRow row in dataset.Tables[1].Rows)
            {
                string tableName = row["TableName"].ToString();
                string tableType = row["TableType"].ToString();

                DataTable table = dataset.Tables[i++];
                table.TableName = tableName;

                if (tableType.ToUpper() == "MASTER")
                    this.MasterTables.Add(table);
                else if (tableType.ToUpper() == "DEFAULT")
                    this.DefaultTables.Add(table);
                else if (tableType.ToUpper() == "RELATIONAL")
                    this.RelationalTables.Add(table);
            }

        }
    }

    public class RequestManager : BaseManager
    {
        private TokenProvider TokenProvider { get; set; }

        private static DataTable SCHEMA_SYS_REQUESTS { get; set; }
        private static DataTable SCHEMA_SYS_REQUEST_TABLES { get; set; }

        static RequestManager()
        {
            RequestManager.SCHEMA_SYS_REQUESTS = new DataTable("SYS_REQUESTS");
            RequestManager.SCHEMA_SYS_REQUESTS.Columns.Add(new DataColumn("Id", typeof(int)));
            RequestManager.SCHEMA_SYS_REQUESTS.Columns.Add(new DataColumn("Status", typeof(int)));
            RequestManager.SCHEMA_SYS_REQUESTS.Columns.Add(new DataColumn("CreatedOn", typeof(DateTime)));
            RequestManager.SCHEMA_SYS_REQUESTS.Columns.Add(new DataColumn("CreatedBy", typeof(int)));
            RequestManager.SCHEMA_SYS_REQUESTS.Columns.Add(new DataColumn("ReviewedOn", typeof(DateTime)));
            RequestManager.SCHEMA_SYS_REQUESTS.Columns.Add(new DataColumn("ReviewedBy", typeof(int)));

            RequestManager.SCHEMA_SYS_REQUEST_TABLES = new DataTable("SYS_REQUEST_TABLES");
            RequestManager.SCHEMA_SYS_REQUEST_TABLES.Columns.Add(new DataColumn("Id", typeof(int)));
            RequestManager.SCHEMA_SYS_REQUEST_TABLES.Columns.Add(new DataColumn("RequestId", typeof(int)));
            RequestManager.SCHEMA_SYS_REQUEST_TABLES.Columns.Add(new DataColumn("TableName", typeof(String)));
            RequestManager.SCHEMA_SYS_REQUEST_TABLES.Columns.Add(new DataColumn("TableType", typeof(String)));
        }

        public RequestManager(Database database, TokenProvider tokenProvider) : base(database)
        {
            this.Database = database;
            this.TokenProvider = tokenProvider;
        }

        public Script GetNewRequestScript(int userId, DataSet dataset)
        {
            DataTable requestTable = SCHEMA_SYS_REQUESTS.Clone();
            DataTable requestTableMap = SCHEMA_SYS_REQUEST_TABLES.Clone();
            List<SqlCommand> allCommands = new List<SqlCommand>();
            Script script = new Script();

            Int32 requestId = this.TokenProvider.GetNext(requestTable.TableName);

            script.Comment("NEW REQUEST ID");
            script += "DECLARE @requestId int = " + requestId + ";";

            DataRow row = requestTable.NewRow();
            row["Id"] = requestId;
            row["Status"] = 0;
            row["CreatedOn"] = DateTime.Now;
            row["CreatedBy"] = userId;
            row["ReviewedOn"] = DBNull.Value;
            row["ReviewedBy"] = DBNull.Value;
            requestTable.Rows.Add(row);

            script.Comment("INSERTING MASTER REQUEST");
            script += Shared.GetInsertQuery(row);

            foreach (DataTable table in dataset.Tables)
            {
                var tableMapRow = requestTableMap.NewRow();
                tableMapRow["Id"] = TokenProvider.GetNext(requestTableMap.TableName);
                tableMapRow["RequestId"] = requestId;
                tableMapRow["TableName"] = table.TableName;

                if (table.GetCategory() == TableCategory.Master || table.GetType() == typeof(MasterTable))
                {
                    tableMapRow["TableType"] = "MASTER";
                }
                else if (table.GetCategory() == TableCategory.Default || table.GetType() == typeof(DefaultTable))
                {
                    tableMapRow["TableType"] = "DEFAULT";
                }
                else if (table.GetCategory() == TableCategory.Relational || table.GetType() == typeof(RelationalTable))
                {
                    tableMapRow["TableType"] = "RELATIONAL";
                }

                requestTableMap.Rows.Add(tableMapRow);

                script.Comment("INSERTING REQUEST TABLES MAPPING");
                script += Shared.GetInsertQuery(tableMapRow);
            }

            return script;
        }

        public Script GetNewRequestScript(int userId, DataTable table)
        {
            DataTable requestTable = SCHEMA_SYS_REQUESTS.Clone();
            DataTable requestTableMap = SCHEMA_SYS_REQUEST_TABLES.Clone();
            List<SqlCommand> allCommands = new List<SqlCommand>();
            Script script = new Script();

            Int32 requestId = this.TokenProvider.GetNext(requestTable.TableName);

            script.Comment("NEW REQUEST ID");
            script += "DECLARE @requestId int = " + requestId + ";";

            DataRow row = requestTable.NewRow();
            row["Id"] = requestId;
            row["Status"] = 0;
            row["CreatedOn"] = DateTime.Now;
            row["CreatedBy"] = userId;
            row["ReviewedOn"] = DBNull.Value;
            row["ReviewedBy"] = DBNull.Value;
            requestTable.Rows.Add(row);

            script.Comment("INSERTING MASTER REQUEST");
            script += Shared.GetInsertQuery(row);

            var tableMapRow = requestTableMap.NewRow();
            tableMapRow["Id"] = TokenProvider.GetNext(requestTableMap.TableName);
            tableMapRow["RequestId"] = requestId;
            tableMapRow["TableName"] = table.TableName;

            if (table.GetCategory() == TableCategory.Master || table.GetType() == typeof(MasterTable))
            {
                tableMapRow["TableType"] = "MASTER";
            }
            else if (table.GetCategory() == TableCategory.Default || table.GetType() == typeof(DefaultTable))
            {
                tableMapRow["TableType"] = "DEFAULT";
            }
            else if (table.GetCategory() == TableCategory.Relational || table.GetType() == typeof(RelationalTable))
            {
                tableMapRow["TableType"] = "RELATIONAL";
            }

            requestTableMap.Rows.Add(tableMapRow);

            script.Comment("INSERTING REQUEST TABLES MAPPING");
            script += Shared.GetInsertQuery(tableMapRow);

            return script;
        }

        public Request LoadRequest(int requestId)
        {
            string sql = @"
                DECLARE @RequestId int = " + requestId + @";
                SELECT * FROM SYS_REQUESTS WHERE Id = @RequestId;
                SELECT * FROM SYS_REQUEST_TABLES WHERE RequestId = @RequestId ORDER BY Id;

                DECLARE @Query varchar(MAX);
                SELECT  @Query = COALESCE(@Query + '; ', '') + 'SELECT TOP 0 * FROM ' + TableName  
		                FROM SYS_REQUEST_TABLES WHERE RequestId = @RequestId ORDER BY Id;

                EXECUTE(@Query);
                ";

            DataSet dataset = this.Database.ExecuteDataSet(CommandType.Text, sql);
            Request request = new Request(dataset);

            return request;
        }

        public void ClearRequest(int requestId)
        {
            string query1 = @"delete from {0} WHERE Id=@Id";
            string query2 = @"delete from {0} WHERE RequestId=@RequestId";

            SqlCommand command1 = new SqlCommand(String.Format(query1, SCHEMA_SYS_REQUESTS.TableName));
            SqlCommand command2 = new SqlCommand(String.Format(query2, SCHEMA_SYS_REQUEST_TABLES.TableName));

            command1.Parameters.AddWithValue("@Id", requestId);
            command2.Parameters.AddWithValue("@RequestId", requestId);

            this.ExecuteCommand(command1);
            this.ExecuteCommand(command2);
        }

        private void ExecuteCommands(List<SqlCommand> commands)
        {
            foreach (var command in commands)
            {
                this.Database.ExecuteNonQuery(command);
            }
        }

        private void ExecuteCommand(SqlCommand command)
        {
            this.Database.ExecuteNonQuery(command);
        }
    }
}
