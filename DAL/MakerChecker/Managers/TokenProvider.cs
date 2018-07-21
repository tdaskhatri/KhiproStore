using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace eLearning.DAL.MakerChecker
{
    public class TokenProvider
    {
        private const string get_query = @"IF NOT EXISTS(SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[{0}]') AND type = 'SO')
                            BEGIN
	                            CREATE SEQUENCE {0} AS INT
	                            START WITH 1
	                            INCREMENT BY 1
                            END
                            SELECT NEXT VALUE FOR {0};";

        private Database DbContext { get; set; }

        public TokenProvider(Database dbContext)
        {
            this.DbContext = dbContext;
        }

        public int GetNext(string tableName)
        {
            return this.GetNextSeries(tableName, 1)[0];
        }

        public int[] GetNextSeries(string tableName, int count)
        {
            String sequenceName = tableName.Replace(' ', '_');

            int[] ids = new int[count];

            for (int x = 0; x < count; x++)
                ids[x] = this.getNext(sequenceName);
            return ids;
        }

        private int getNext(string sequenceName)
        {
            string sql = String.Format(get_query, "SEQ_" + sequenceName);

            var command = new SqlCommand(sql);
            command.CommandText = sql;
            command.CommandType = System.Data.CommandType.Text;

            object value = this.DbContext.ExecuteScalar(command);

            return Convert.ToInt32(value);
        }
    }
}
