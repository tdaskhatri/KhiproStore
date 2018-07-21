using eLearning.DAL.DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace eLearning.DAL.DAClasses
{
    public class VehicleTypes
    {
        private DAVehicleTypes DA = new DAVehicleTypes();
        public DataSet FetchVehicleTypes()
        {
            return this.DA.SearchVehicleTypes();
        }

        public DataSet FetchActiveVehicleTypes()
        {
            return this.DA.SearchActiveVehicleTypes();
        }
        public bool IsNameUniqueNameEn(string name, int id)
        {
            return this.DA.IsUniqueNameEn(name, id);
        }
        public bool IsNameUniqueNameAr(string name, int id)
        {
            return this.DA.IsUniqueNameAr(name, id);
        }
        public bool IsUniqueShortCode(string code, int id)
        {
            return this.DA.IsUniqueShortCode(code, id);
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
        public int Add2(DataRow row)
        {
            return this.DA.Insert2(row);
        }

        public int GetNextId()
        {
            return this.DA.GetNextToken();
        }
    }
}
