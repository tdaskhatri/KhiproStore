using eLearning.DAL.DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace eLearning.DAL.DAClasses
{
    public class Branches
    {
        private DABranches DA = new DABranches();
        public DataSet FetchBranches()
        {
            return this.DA.SearchBranches();
        }
        public DataSet FetchActiveBranches()
        {
            return this.DA.SearchActiveBranches();
        }
        public DataSet FetchBranchesByCenter(string centerId, bool isActive, string exclusiveId)
        {
            return this.DA.SearchBranches(centerId, isActive, exclusiveId);
        }
        public DataSet FetchBranchesByCenter(string centerId)
        {
            return this.DA.SearchBranchesByCenter(centerId);
        }
        public void GetCenterIdAndEmirateIdFromBranchId(string branchId, ref string centerId, ref string emirateId)
        {
            this.DA.GetCenterIdAndEmirateIdFromBranchId(branchId, ref centerId, ref emirateId);
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
            return this.DA.SchemaManager.GetTableAsDefault("BRANCHES");
        }
    }
}
