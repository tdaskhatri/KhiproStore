using eLearning.DAL.DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace eLearning.DAL.DAClasses
{
    public class Centers
    {
        private DACenters DA = new DACenters();
        public DataSet FetchCenters()
        {
            return this.DA.SearchCenters();
        }
        public DataSet FetchActiveCenters()
        {
            return this.DA.SearchActiveCenters();
        }
        public DataSet FetchCentersExclusive(string emirateId = null, bool? isActive = null, string exclusiveId = null)
        {
            return this.DA.SearchCenters(emirateId, isActive, exclusiveId);
        }

        public int fetchUserId(string id)
        {
            return DA.fetchUserId(id);
        }
        public bool IsNameUniqueNameEn(string name, int id)
        {
            return this.DA.IsUniqueNameEn(name, id);
        }
        public bool IsNameUniqueNameAr(string name, int id)
        {
            return this.DA.IsUniqueNameAr(name, id);
        }
        public DataSet GetById(int id)
        {
            return this.DA.Get(id);
        }
        public void Delete(DataRow row)
        {
            this.DA.Delete(row);
        }
        public void Save(DataRow row)
        {
            this.DA.Update(row);
        }

        public void Add(DataRow row)
        {
            this.DA.Insert(row);
        }

        public int GetNextId()
        {
            return this.DA.GetNextToken();
        }

        public DataTable GetSchema()
        {
            return this.DA.SchemaManager.GetTableAsDefault("CENTERS");
        }
    }
}
