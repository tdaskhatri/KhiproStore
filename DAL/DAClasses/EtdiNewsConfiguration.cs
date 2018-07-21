using eLearning.DAL.DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace eLearning.DAL.DAClasses
{
    public class EtdiNewsConfiguration
    {

        public void InsertNews(string title, string summary, string details, bool isActive)
        {
            DAEtdiNewsConfiguration oDa = new DAEtdiNewsConfiguration();
            oDa.InsertNews(title, summary, details, isActive);
        }

        public void UpdateNews(string id, string title, string summary, string details, bool isActive)
        {
            DAEtdiNewsConfiguration oDa = new DAEtdiNewsConfiguration();
            oDa.UpdateNews(id, title, summary, details, isActive);
        }

        public DataSet GeAllNews()
        {
            DataSet ds = new DataSet();
            DAEtdiNewsConfiguration oDa = new DAEtdiNewsConfiguration();
            ds = oDa.GeAllNews().DataSet;

            return ds;
        }
      public DataSet GetAllNewsExt()
        {
            DataSet ds = new DataSet();
            DAEtdiNewsConfiguration oDa = new DAEtdiNewsConfiguration();
            ds = oDa.GetAllNewsExt().DataSet;

            return ds;
        }


        public DataSet GeNewsById(int id)
        {
            DataSet ds = new DataSet();
            DAEtdiNewsConfiguration oDa = new DAEtdiNewsConfiguration();
            ds = oDa.GeNewsById(id).DataSet;

            return ds;
        }

        public DataSet GetStatistics()
        {
            DAEtdiNewsConfiguration oDa = new DAEtdiNewsConfiguration();
            var ds = oDa.GetStatistics();

            return ds;
        }
    }
}
