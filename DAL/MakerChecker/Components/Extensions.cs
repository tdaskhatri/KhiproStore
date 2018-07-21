using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace eLearning.DAL
{
    public enum TableCategory
    {
        None = 0,
        Master = 1,
        Default = 2,
        Relational = 3
    }

    public static class Extensions
    {
        public static void SetIgnored(this DataColumn column, bool value)
        {
            column.ExtendedProperties["IGNORE_IN_SCRIPTS"] = value.ToString();
        }
        public static bool GetIgnored(this DataColumn column)
        {
            if (column.ExtendedProperties.ContainsKey("IGNORE_IN_SCRIPTS"))
                return Convert.ToBoolean(column.ExtendedProperties["IGNORE_IN_SCRIPTS"]);
            else
                return false;
        }

        public static void SetCategory(this DataTable table, TableCategory category)
        {
            table.ExtendedProperties["TABLE_CATEGORY"] = category.ToString();
        }
        public static TableCategory GetCategory(this DataTable table)
        {
            if (table.ExtendedProperties.ContainsKey("TABLE_CATEGORY"))
                return (TableCategory)Enum.Parse(typeof(TableCategory), Convert.ToString(table.ExtendedProperties["TABLE_CATEGORY"]));
            else
                return TableCategory.None;
        }

    }
}
