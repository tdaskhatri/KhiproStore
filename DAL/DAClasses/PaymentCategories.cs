using eLearning.DAL.DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace eLearning.DAL.DAClasses
{
    public class PaymentCategories
    {
        private DAPaymentCategories DA = new DAPaymentCategories();
        public DataSet FetchWorkflowStages(bool arabicLocale)
        {
            return this.DA.SearchAllWorkflowStages(arabicLocale);
        }
        public DataSet FetchAllPaymentCategories(bool isArabic = false)
        {
            return this.DA.SearchAllPaymentCategories(isArabic);
        }
        public DataSet FetchPaymentCategories()
        {
            return this.DA.SearchPaymentCategories();
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
