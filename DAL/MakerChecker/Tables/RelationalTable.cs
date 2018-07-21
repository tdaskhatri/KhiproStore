using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace eLearning.DAL.MakerChecker
{
    [Serializable]
    public class RelationalTable : DataTable
    {
        public RelationalTable() { }
        public RelationalTable(string tableName) : base(tableName) { }
    }
}
