using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace eLearning.DAL.MakerChecker
{
    public class MultipleSchemas : Dictionary<string, DataTable>
    {
    }

    public class SchemaManager : BaseManager
    {
        private static Dictionary<string, MultipleSchemas> SchemaDictionary { get; set; }

        static SchemaManager()
        {
            SchemaManager.SchemaDictionary = new Dictionary<string, MultipleSchemas>();
        }

        public SchemaManager(Database database) : base(database)
        {
        }

        public MasterTable GetTableAsMaster(string tableName)
        {
            tableName = tableName.ToUpper();
            if (!SchemaManager.SchemaDictionary.ContainsKey(tableName))
            {
                MultipleSchemas schemas = this.LoadSchemas(tableName);
                SchemaManager.SchemaDictionary.Add(tableName, schemas);
            }
            return SchemaManager.SchemaDictionary[tableName]["MASTER"].Clone() as MasterTable;
        }

        public DefaultTable GetTableAsDefault(string tableName)
        {
            tableName = tableName.ToUpper();
            if (!SchemaManager.SchemaDictionary.ContainsKey(tableName))
            {
                MultipleSchemas schemas = this.LoadSchemas(tableName);
                SchemaManager.SchemaDictionary.Add(tableName, schemas);
            }
            return SchemaManager.SchemaDictionary[tableName]["DEFAULT"].Clone() as DefaultTable;
        }

        public RelationalTable GetTableAsRelational(string tableName)
        {
            tableName = tableName.ToUpper();
            if (!SchemaManager.SchemaDictionary.ContainsKey(tableName))
            {
                MultipleSchemas schemas = this.LoadSchemas(tableName);
                SchemaManager.SchemaDictionary.Add(tableName, schemas);
            }
            return SchemaManager.SchemaDictionary[tableName]["RELATIONAL"].Clone() as RelationalTable;
        }

        public void CopyCommonColumns(DataRow from, DataRow to)
        {
            foreach (DataColumn column in to.Table.Columns)
            {
                if (from.Table.Columns.Contains(column.ColumnName))
                    to[column.ColumnName] = from[column.ColumnName];
            }
        }

        private MultipleSchemas LoadSchemas(string tableName)
        {
            string queries = "SELECT TOP 0 * FROM [" + tableName + "];\n";
            SqlCommand command = new SqlCommand(queries);
            SqlDataReader reader = (SqlDataReader)this.Database.ExecuteReader(command);
            MasterTable masterTable = new MasterTable(tableName);
            DefaultTable defaultTable = new DefaultTable(tableName);
            RelationalTable relationalTable = new RelationalTable(tableName);

            masterTable.Load(reader);
            defaultTable.Load(masterTable.CreateDataReader());
            relationalTable.Load(masterTable.CreateDataReader());

            MultipleSchemas schemas = new MultipleSchemas();
            schemas.Add("MASTER", masterTable);
            schemas.Add("DEFAULT", defaultTable);
            schemas.Add("RELATIONAL", relationalTable);
            return schemas;
        }
    }
}