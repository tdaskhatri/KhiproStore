using eLearning.DAL.DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace eLearning.DAL.DAClasses
{
    public class Languages
    {
        private DALanguages DA = new DALanguages();
        public DataSet FetchLanguages()
        {
          return this.DA.SearchLanguages();          
        }

        //Added by Fahim Nasir on 4-June-2017
        public DataSet FetchLoginLanguages()
        {
            try
            {
                return this.DA.FetchLoginLanguages();
            }
            catch (Exception ex)
            {
                throw ex;
            }          
        }
        //=====================================
        public DataSet FetchActiveLanguages()
        {
            return this.DA.SearchActiveLanguages();
        }

        public bool IsNameUniqueNameEn(string name, int id)
        {
            return this.DA.IsUniqueNameEn(name, id);
        }
        public bool IsNameUniqueNameAr(string name, int id)
        {
            return this.DA.IsUniqueNameAr(name, id);
        }
        public bool IsCodeUnique(string name, int id)
        {
            return this.DA.IsCodeUnique(name, id);
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
