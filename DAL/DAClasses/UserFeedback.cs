using eLearning.DAL.DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace eLearning.DAL.DAClasses
{
    public class UserFeedback
    {
        public void AddUserFeedback(string uname, string uemail, string umobile, string uphone, string ufeedback)
        {
            DAUserFeedback oUF = new DAUserFeedback();
            oUF.AddUserFeedback(uname, uemail, umobile, uphone, ufeedback);
        }
    }
}
