using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace eLearning.DAL.DataAccess
{
   public class DALogin:DABase
    {
        public DataTable getUsers()
        {
            return ExecuteDataSet("SELECT *FROM STOCK").Tables[0];
        }
    }
}
