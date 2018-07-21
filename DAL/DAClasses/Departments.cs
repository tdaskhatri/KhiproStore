using eLearning.DAL.DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace eLearning.DAL.DAClasses
{
    public class Departments
    {
        private DADepartments DA = new DADepartments();
        public DataSet FetchDepartments()
        {
            return this.DA.SearchDepartments();
        }
        public DataSet FetchActiveDepartments()
        {
            return this.DA.SearchActiveDepartments();
        }
        public bool IsNameUniqueNameEn(string name, int id)
        {
            return this.DA.IsUniqueNameEn(name, id);
        }
        public bool IsNameUniqueNameAr(string name, int id)
        {
            return this.DA.IsUniqueNameAr(name, id);
        }
        public bool IsShortCodeUnique(string code, int id)
        {
            return this.DA.IsUniqueShortCode(code, id);
        }
        public bool IsCodeUnique(string code, int id)
        {
            return this.DA.IsUniqueCode(code, id);
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
    }
}
