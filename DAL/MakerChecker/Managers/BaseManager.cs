using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace eLearning.DAL.MakerChecker
{
    public class BaseManager
    {
        protected Database Database { get; set; }

        public BaseManager(Database database)
        {
            this.Database = database;
        }
    }
}
