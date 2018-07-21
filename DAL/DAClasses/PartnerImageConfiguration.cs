using eLearning.DAL.DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace eLearning.DAL.DAClasses
{
    public class PartnerImageConfiguration
    {

        public DataSet GetAllImages()
        {
            DataSet ds = new DataSet();
            DAPartnerImageConfiguration oDa = new DAPartnerImageConfiguration();
            ds = oDa.GeAllImages().DataSet;

            return ds;
        }

    }
}
