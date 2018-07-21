using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using eLearning.Common;
using System.Reflection;
using System.Collections;
using eLearning.DAL.DataAccess;
using eLearning.Common.Utils;
using System.Data.Common;

namespace eLearning.DAL.DAClasses
{
    public class User
    {
        DAUser objDAUser = null;
      

        public DataSet Search(Dictionary<Enumaration.SearchUsersCriteria, Object> criteria, bool fromProduction)
        {
            objDAUser = new DAUser();
            if (fromProduction)
                return objDAUser.Search(criteria);
            else
                return objDAUser.SearchInterim(criteria);
        }
        public DataSet GetUsersById(string userId)
        {
            DataSet dsReturn = new DataSet();
            objDAUser = new DAUser();
            DataTable dtUsers = objDAUser.GetUserById(userId);
            dsReturn.Tables.Add(dtUsers);

            DARoles objDARoles = new DARoles();
            DataTable dtRoles = objDARoles.GetRolesByUserId(userId);
            dsReturn.Tables.Add(dtRoles);

            return dsReturn;
        }

        public DataSet GetUsersInterimById(string userId)
        {
            DataSet dsReturn = new DataSet();
            objDAUser = new DAUser();
            DataTable dtUsers = objDAUser.GetUserInterimById(userId);
            dsReturn.Tables.Add(dtUsers);

            DARoles objDARoles = new DARoles();
            DataTable dtRoles = objDARoles.GetRolesInterimByUserId(userId);
            dsReturn.Tables.Add(dtRoles);

            return dsReturn;
        }

        public DataSet GetUsersDataSet()
        {
            DataSet dsReturn = new DataSet();
            dsReturn.Tables.Add(Entities.Users.GetDataTable());
            dsReturn.Tables.Add(Entities.Roles.GetDataTable());
            return dsReturn;
        }

        public void PersistUser(DataSet ds, string selectedGroups)
        {
            objDAUser = new DAUser();

            using (DbTransaction transaction = objDAUser.CreateTransaction())
            {
                try
                {
                    DataTable dtUser = ds.Tables[Entities.Users.TABLE_NAME];
                    objDAUser.PersistUser(dtUser.Rows[0], transaction);

                    DataTable dtRoles = ds.Tables[Entities.Roles.TABLE_NAME];
                    DAUserRoles oDAUserRoles = new DAUserRoles();
                    oDAUserRoles.PersistUserRoles(selectedGroups, dtUser.Rows[0][Entities.Users.USER_ID].ToString(), transaction);


                    objDAUser.CommitTransaction(transaction);
                }
                catch (Exception e)
                {
                    objDAUser.RollbackTransaction(transaction);
                    throw e;
                }
            }
        }

        public void UpdateUserSessionID(string UserID, string SessionID, bool IsOnline)
        {
            objDAUser = new DAUser();

            using (DbTransaction transaction = objDAUser.CreateTransaction())
            {
                try
                {
                    objDAUser.UpdateUserSession(UserID, SessionID, IsOnline == true ? 1 : 0, transaction);
                    objDAUser.CommitTransaction(transaction);
                }
                catch (Exception e)
                {
                    objDAUser.RollbackTransaction(transaction);
                    throw e;
                }
            }
        }
        public void UpdatePortalUserSession(string UserID, string SessionID, bool IsOnline)
        {
            objDAUser = new DAUser();

            using (DbTransaction transaction = objDAUser.CreateTransaction())
            {
                try
                {
                    objDAUser.UpdatePortalUserSession(UserID, SessionID, IsOnline == true ? 1 : 0, transaction);
                    objDAUser.CommitTransaction(transaction);
                }
                catch (Exception e)
                {
                    objDAUser.RollbackTransaction(transaction);
                    throw e;
                }
            }
        }
        
        public bool UserInActive(string id)
        {
            objDAUser = new DAUser();
            return objDAUser.UserInActive(id);
        }
        public bool AlreadyPendingUserID(string id,string currID)
        {
            objDAUser = new DAUser();
            return objDAUser.AlreadyPendingUserID(id,currID);
        }
        public bool AlreadyUserID(string id)
        {
            objDAUser = new DAUser();
            return objDAUser.AlreadyUserID(id);
        }
        
    }
}
