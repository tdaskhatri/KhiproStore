using eLearning.DAL.DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace eLearning.DAL.DAClasses
{
    public class UserRegistration
    {
        public void AddUserRegistration(string userId, string emiratesId, string name, string email, string cell, string country, string password, string address)
        {
            DAUserRegistration oDa = new DAUserRegistration();
            oDa.AddUserRegistration(userId, emiratesId, name, email, cell, country, password, address);
        }
    }
}
