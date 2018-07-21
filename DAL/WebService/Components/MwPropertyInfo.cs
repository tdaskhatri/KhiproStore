using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace eLearning.DAL.WebService.Components
{
    public class MwPropertyInfo
    {
        public string PropertyName { get; set; }
        public string ColumnName { get; set; }
        public bool IsMandatory { get; set; }
        public bool IsAlphabetic { get; set; }
        public bool IsNumeric { get; set; }
        public bool IsAlphanumeric { get; set; }
        public int? MinLength { get; set; }
        public int? MaxLength { get; set; }
        public string FormatRegex { get; set; }
        public string ValidFormatPattern { get; set; }

        public static MwPropertyInfo FromDataRow(DataRow row)
        {
            var obj = new MwPropertyInfo();

            obj.PropertyName = Convert.ToString(row["PROPERTY_NAME"]);
            obj.ColumnName = Convert.ToString(row["COLUMN_NAME"]);
            obj.IsMandatory = row["IS_MANDATORY"] == DBNull.Value ? false : Convert.ToBoolean(row["IS_MANDATORY"]);
            obj.IsAlphabetic = row["IS_ALPHABATIC"] == DBNull.Value ? false : Convert.ToBoolean(row["IS_ALPHABATIC"]);
            obj.IsAlphanumeric = row["IS_ALPHANUMERIC"] == DBNull.Value ? false : Convert.ToBoolean(row["IS_ALPHANUMERIC"]);
            obj.IsNumeric = row["IS_NUMERIC"] == DBNull.Value ? false : Convert.ToBoolean(row["IS_NUMERIC"]);
            obj.MinLength = row["MIN_LENGTH"] == DBNull.Value ? null : (Nullable<int>)Convert.ToInt32(row["MIN_LENGTH"]);
            obj.MaxLength = row["MAX_LENGTH"] == DBNull.Value ? null : (Nullable<int>)Convert.ToInt32(row["MAX_LENGTH"]);
            obj.FormatRegex = row["FORMAT_REGEX"] == DBNull.Value ? null : Convert.ToString(row["FORMAT_REGEX"]);
            obj.ValidFormatPattern = row["VALID_FORMAT_PATTERN"] == DBNull.Value ? null : Convert.ToString(row["VALID_FORMAT_PATTERN"]);

            return obj;

        }
    }
}
