using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace eLearning.DAL.MakerChecker
{
    public enum OnApproveAction
    {
        None = 0,
        Add = 1,
        Update = 2,
        Delete = 3,
    }

    public enum InterimStatus
    {
        Pending = 0,
        Approved = 1,
        Rejected = 2
    }

    public class DAMakerChecker
    {
        private Database Database { get; set; }
        public TokenProvider TokenProvider { get; set; }
        private DefaultManager DefaultManager { get; set; }
        private RequestManager RequestManager { get; set; }
        private InterimManager InterimManager { get; set; }
        public SchemaManager SchemaManager { get; set; }

        public DAMakerChecker()
        {
            this.Database = DatabaseFactory.CreateDatabase();
            this.TokenProvider = new TokenProvider(this.Database);
            this.DefaultManager = new DefaultManager(this.Database);
            this.InterimManager = new InterimManager(this.Database);
            this.SchemaManager = new SchemaManager(this.Database);
            this.RequestManager = new RequestManager(this.Database, this.TokenProvider);
        }

        public void GenerateInterimTable(string tableName)
        {
            this.InterimManager.GenerateInterimTable(tableName);
        }

        public void ProcessDataSet(DataSet dataset, bool skipMakerCheckerFlow = false)
        {
            if (!skipMakerCheckerFlow)
            {
                Script script = new Script();
                script += this.RequestManager.GetNewRequestScript(1, dataset);
                script += this.InterimManager.GetProcessingScript(dataset);
                this.Database.ExecuteNonQuery(CommandType.Text, script.ToString(true));
            }
            else
            {
                Script script = new Script();
                script += this.DefaultManager.GetProcessingScript(dataset);
                this.Database.ExecuteNonQuery(CommandType.Text, script.ToString(true));
            }
        }

        public void ProcessDataTable(DataTable table, bool skipMakerCheckerFlow = false)
        {
            if (!skipMakerCheckerFlow)
            {
                Script script = new Script();
                script += this.RequestManager.GetNewRequestScript(1, table);
                script += this.InterimManager.GetProcessingScript(table);
                this.Database.ExecuteNonQuery(CommandType.Text, script.ToString(true));
            }
            else
            {
                Script script = new Script();
                script += this.DefaultManager.GetProcessingScript(table);
                this.Database.ExecuteNonQuery(CommandType.Text, script.ToString(true));
            }
        }

        public void ApproveRequest(int requestId)
        {
            Request request = this.RequestManager.LoadRequest(requestId);

            Script script = new Script();

            script.Comment("APPROVING MASTER TABLES");
            foreach (DataTable table in request.MasterTables)
                script += this.InterimManager.GetApprovalScript(table, requestId);

            script.Comment("APPROVING CHILD/DEFAULT TABLES");
            foreach (DataTable table in request.DefaultTables)
                script += this.InterimManager.GetApprovalScript(table, requestId);

            script.Comment("APPROVING RELATIONAL TABLES");
            foreach (DataTable table in request.RelationalTables)
                script += this.InterimManager.GetApprovalScript(table, requestId);

            this.Database.ExecuteNonQuery(CommandType.Text, script.ToString());

        }

        public void RejectRequest(int requestId)
        {
            Request request = this.RequestManager.LoadRequest(requestId);

            Script script = new Script();

            script.Comment("REJECTING MASTER TABLES");
            foreach (DataTable table in request.MasterTables)
                script += this.InterimManager.GetRejectionScript(table, requestId);

            script.Comment("REJECTING CHILD/DEFAULT TABLES");
            foreach (DataTable table in request.DefaultTables)
                script += this.InterimManager.GetRejectionScript(table, requestId);

            script.Comment("REJECTING RELATIONAL TABLES");
            foreach (DataTable table in request.RelationalTables)
                script += this.InterimManager.GetRejectionScript(table, requestId);

            this.Database.ExecuteNonQuery(CommandType.Text, script.ToString());
        }

    }

}
