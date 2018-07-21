using eLearning.DAL.DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace eLearning.DAL.DAClasses
{
    public class ActivityLogger
    {
        private DABranches DA = new DABranches();

        public void Log(string userId, string module, string description)
        {
            this.Log(userId, module, description, "unknown");
        }

        public void Log(string userId, string module, string description, string ip)
        {
            DataTable table = this.GetSchema();
            table.Columns.Remove("ID");

            DataRow row = table.NewRow();
            row["MODULE_NAME"] = module;
            row["DESCRIPTION"] = description;
            row["CLASS"] = this.GetCallerModule();
            row["METHOD"] = this.GetCallerName();
            row["IP"] = ip;
            row["CREATED_ON"] = DateTime.Now;
            row["CREATED_BY"] = Convert.ToInt32(userId);
            this.DA.Insert(row);
        }

        private string GetCallerName()
        {
            StackTrace stackTrace = new StackTrace();
            return stackTrace.GetFrame(3).GetMethod().Name;
        }

        private string GetCallerModule()
        {
            StackTrace stackTrace = new StackTrace();
            return stackTrace.GetFrame(3).GetMethod().DeclaringType.FullName;
        }

        public int GetNextId()
        {
            return this.DA.GetNextToken();
        }

        public DataTable GetSchema()
        {
            return this.DA.SchemaManager.GetTableAsDefault("ACTIVITY_LOG");
        }
    }
}
