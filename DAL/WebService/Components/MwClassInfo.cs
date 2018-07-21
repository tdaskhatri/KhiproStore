using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace eLearning.DAL.WebService.Components
{
    public class MwClassInfo
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string FullName { get; set; }
        public string TableName { get; set; }

        public MwPropertyInfoDictionary Properties { get; set; }

        public MwClassInfo()
        {
            this.Properties = new MwPropertyInfoDictionary();
        }

        public static MwClassInfo FromDataRow(DataRow row)
        {
            var obj = new MwClassInfo();

            obj.Id = Convert.ToString(row["ID"]);
            obj.Name = Convert.ToString(row["NAME"]);
            obj.FullName = Convert.ToString(row["FULL_NAME"]);
            obj.TableName = Convert.ToString(row["TABLE_NAME"]);

            return obj;

        }
    }
}
