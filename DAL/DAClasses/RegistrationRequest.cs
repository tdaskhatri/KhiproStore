using eLearning.DAL.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace eLearning.DAL.DAClasses
{
    public class RegistrationRequest
    {
        // AVANZA\muhammad.awais - 22/08/2017 10:37:12
        private DARegistrationRequest DA = new DARegistrationRequest();
        public void InsertRegistrationRequest(string Name, string MobileNumber, string Email, string Comments, string ChannelId)
        {
            this.DA.InsertRegistrationRequest(Name, MobileNumber, Email, Comments, ChannelId);
        }
    }
}
