using eLearning.DAL.DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace eLearning.DAL.DAClasses
{
    public class Emirates
    {
        private DAEmirates DA = new DAEmirates();
        public DataSet FetchEmirates()
        {
            return this.DA.SearchEmirates();
        }

        public DataSet FetchEmirates(bool? isActive = null, string exclusiveId = null)
        {
            return this.DA.SearchEmirates();
        }

    }
}
