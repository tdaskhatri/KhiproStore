using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using eLearning.DAL;

namespace eLearning.DAL.MakerChecker
{
    public class InterimManager : BaseManager
    {
        public InterimManager(Database database) : base(database)
        {
        }

        public Script GetProcessingScript(DataSet dataset)
        {
            Script masterQueries = new Script("PROCESSING MASTER TABLES");
            Script defaultQueries = new Script("PROCESSING CHILD TABLES");
            Script relationalQueries = new Script("PROCESSING RELATIONAL TABLES");

            foreach (DataTable table in dataset.Tables)
            {
                this.RemoveInterimColumns(table);

                if (table.GetCategory() == TableCategory.Master || table.GetType() == typeof(MasterTable))
                {
                    masterQueries += this.GetProcessingScript(table);
                }
                else if (table.GetCategory() == TableCategory.Default || table.GetType() == typeof(DefaultTable))
                {
                    defaultQueries += this.GetProcessingScript(table);
                }
                else if (table.GetCategory() == TableCategory.Relational ||  table.GetType() == typeof(RelationalTable))
                {
                    relationalQueries += this.GetProcessingScript(table);
                }
            }

            return masterQueries + defaultQueries + relationalQueries;
        }

        public Script GetProcessingScript(DataTable table)
        {
            this.RemoveInterimColumns(table);

            Script inserts = new Script(table.TableName + " INSERTS");
            Script updates = new Script(table.TableName + " UPDATES");
            Script deletes = new Script(table.TableName + " DELETES");

            foreach (DataRow row in table.Rows)
            {
                if (row.RowState == DataRowState.Added)
                {
                    inserts += Shared.GetInsertQueryForInterim(row);
                }
                else if (row.RowState == DataRowState.Modified)
                {
                    updates += Shared.GetUpdateQueryForInterim(row, OnApproveAction.Update);
                }
                else if (row.RowState == DataRowState.Deleted)
                {
                    deletes += Shared.GetUpdateQueryForInterim(row, OnApproveAction.Delete);
                }
            }

            return inserts + updates + deletes;
        }

        public Script GetApprovalScript(DataTable table, int requestId)
        {
            Script script = new Script();
            script += Shared.GetInsertApproval(table, requestId);
            script += Shared.GetUpdateApproval(table, requestId);
            script += Shared.GetDeleteApproval(table, requestId);
            return script;
        }

        public Script GetRejectionScript(DataTable table, int requestId)
        {
            Script script = new Script();
            script += Shared.GetRejection(table, requestId);
            return script;
        }

        public void GenerateInterimTable(string tableName)
        {
            string template = @"SELECT *, convert(int, '1') AS [Sys_Status], convert(int, '0') AS [Sys_OnApprove], convert(int, '0') AS [Sys_RequestId] into {0}_INTERIM FROM {0} WHERE 1 = 1;";
            string query = String.Format(template, tableName);

            this.Database.ExecuteNonQuery(CommandType.Text, query);
        }

        public void RemoveInterimColumns(DataTable table)
        {
            if (table.Columns.Contains("Sys_Status"))
                table.Columns.Remove("Sys_Status");
            if (table.Columns.Contains("Sys_OnApprove"))
                table.Columns.Remove("Sys_OnApprove");
            if (table.Columns.Contains("Sys_RequestId"))
                table.Columns.Remove("Sys_RequestId");
        }

    }
}
