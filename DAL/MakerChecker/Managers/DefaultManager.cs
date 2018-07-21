using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace eLearning.DAL.MakerChecker
{
    public class DefaultManager : BaseManager
    {
        public DefaultManager(Database database) : base(database)
        {
        }

        public Script GetProcessingScript(DataSet dataset)
        {
            Script masterQueries = new Script("PROCESSING MASTER TABLES");
            Script defaultQueries = new Script("PROCESSING CHILD TABLES");
            Script relationalQueries = new Script("PROCESSING RELATIONAL TABLES");

            foreach (DataTable table in dataset.Tables)
            {
                if (table.GetType() == typeof(MasterTable))
                {
                    masterQueries += this.GetProcessingScript(table);
                }
                else if (table.GetType() == typeof(DefaultTable))
                {
                    defaultQueries += this.GetProcessingScript(table);
                }
                else if (table.GetType() == typeof(RelationalTable))
                {
                    relationalQueries += this.GetProcessingScript(table);
                }
            }

            return masterQueries + defaultQueries + relationalQueries;
        }

        public Script GetProcessingScript(DataTable table)
        {
            Script inserts = new Script(table.TableName + " INSERTS");
            Script updates = new Script(table.TableName + " UPDATES");
            Script deletes = new Script(table.TableName + " DELETES");

            foreach (DataRow row in table.Rows)
            {
                if (row.RowState == DataRowState.Added)
                {
                    inserts += Shared.GetInsertQuery(row);
                }
                else if (row.RowState == DataRowState.Modified)
                {
                    updates += Shared.GetUpdateQuery(row);
                }
                else if (row.RowState == DataRowState.Deleted)
                {
                    deletes += Shared.GetDeleteQuery(row);
                }
            }

            return inserts + updates + deletes;
        }

    }
}
