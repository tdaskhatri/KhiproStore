using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace eLearning.DAL.MakerChecker
{
    [Serializable]
    public class MasterTable : DataTable
    {
        public MasterTable() { }
        public MasterTable(string tableName) : base(tableName) { }
    }
}
