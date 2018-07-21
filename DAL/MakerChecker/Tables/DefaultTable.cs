using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace eLearning.DAL.MakerChecker
{
    [Serializable]
    public class DefaultTable : DataTable
    {
        public DefaultTable() { }
        public DefaultTable(string tableName) : base(tableName) { }
    }
}
