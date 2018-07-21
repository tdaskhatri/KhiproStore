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
using System.DirectoryServices.AccountManagement;


namespace eLearning.DAL.DAClasses
{
    public class Security
    {
        DASecurity objSecurity = null;
        DAAuditTrail objAuditTrail = null;

        #region Login

        public static DataSet GetAllPermissionsByUserIdAppId(String userId, Enumaration.Application applicationId)
        {

            DASecurity objSecurity = new DASecurity();
            return objSecurity.GetAllPermissionsByUserIdAppId(userId, (int)applicationId);
        }

        public static DataSet GetAllPermittedURLByUserTypeId(int userTypeId)
        {

            DASecurity objSecurity = new DASecurity();
            return objSecurity.GetAllPermittedURLByUserTypeId(userTypeId);
        }

        #endregion

        #region USERS

        public DataSet GetUserById(string userId)
        {
            objSecurity = new DASecurity();
            DataSet ds = objSecurity.GetUserById(userId);
            return ds;
        }
        public DataSet GetPortalUserById(string userId)
        {
            objSecurity = new DASecurity();
            DataSet ds = objSecurity.GetPortalUserById(userId);
            return ds;
        }

        #region Code by Fahim Nasir on 5-1-2017
        public Enumaration.LoginStatus AuthenticateForSingleSignOn(ref DataSet dsUser, string Username, string DomainName)
        {
            dsUser = GetUserById(Username);
            if (dsUser != null && dsUser.Tables[0].Rows.Count > 0 && UserExistsInActiveDirectory(Username, DomainName))
            {
                return Enumaration.LoginStatus.Success;
            }
            else
            {
                return Enumaration.LoginStatus.ErrorsWhileSingleSignOn;
            }
        }
        private bool UserExistsInActiveDirectory(string username, string domainName)
        {
            PrincipalContext pContext = new PrincipalContext(ContextType.Domain, domainName);
            var result = UserPrincipal.FindByIdentity(pContext, IdentityType.SamAccountName, username);
            if (result == null) //Means Login Id not exist in Active Directory.
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public Enumaration.LoginStatus Authenticate(ref DataSet dsUser, string User, string txtPwd, string domainName)
        {
            dsUser = GetUserById(User);
            if (dsUser == null || dsUser.Tables[0].Rows.Count <= 0)
            {
                return Enumaration.LoginStatus.InvalidLoginId;
            }
            else if (dsUser.Tables[0].Rows[0]["IS_ACTIVE"].ToString().Equals("0"))
            {
                return Enumaration.LoginStatus.Inactive;
            }

            //If is system user then authenticate from db else authenticate from LDAP.
            if (dsUser.Tables[0].Rows[0][Entities.Users.AUTHENTICATION_PROVIDER] != DBNull.Value &&
                 dsUser.Tables[0].Rows[0][Entities.Users.AUTHENTICATION_PROVIDER].ToString().Trim().Equals("SYS")
                )
            {
                if (Util.verifyMd5Hash(txtPwd, dsUser.Tables[0].Rows[0][Entities.Users.PASSWORD].ToString()))
                {

                    return Enumaration.LoginStatus.Success;
                }
                else
                {
                    return Enumaration.LoginStatus.IncorrectPassword;
                }
            }
            else if (dsUser.Tables[0].Rows[0][Entities.Users.AUTHENTICATION_PROVIDER] != DBNull.Value &&
                    dsUser.Tables[0].Rows[0][Entities.Users.AUTHENTICATION_PROVIDER].ToString().Trim().Equals("AD"))
            {
                ActiveDirectoryHelper ADHelper = new ActiveDirectoryHelper();
                Boolean authenticated = ADHelper.Authenticate(User, txtPwd, domainName);
                if (authenticated)
                {
                    return Enumaration.LoginStatus.Success;
                }
                else
                {
                    return Enumaration.LoginStatus.LDAPNotConnecting;
                }
            }
            else
            {
                throw new Exception("Not a valid Authentication Provider found");
            }
        }
        public Enumaration.LoginStatus PortalAuthenticate(ref DataSet dsUser, string User, string txtPwd, string domainName)
        {
            dsUser = GetPortalUserById(User);
            if (dsUser == null || dsUser.Tables[0].Rows.Count <= 0)
            {
                return Enumaration.LoginStatus.InvalidLoginId;
            }
            else if (dsUser.Tables[0].Rows[0]["IS_ACTIVE"].ToString().Equals("0"))
            {
                return Enumaration.LoginStatus.Inactive;
            }

        
            if (Util.verifyMd5Hash(txtPwd.ToString(), dsUser.Tables[0].Rows[0][Entities.Users.PASSWORD].ToString()))
            {

                return Enumaration.LoginStatus.Success;
            }
            else
            {
                return Enumaration.LoginStatus.IncorrectPassword;
            }
        }
        #endregion

        public Enumaration.LoginStatus Authenticate(ref DataSet dsUser, string User, string txtPwd)
        {
            dsUser = GetUserById(User);

            if (dsUser == null || dsUser.Tables[0].Rows.Count <= 0)
            {
                return Enumaration.LoginStatus.InvalidLoginId;
            }
            //If is system user then authenticate from db else authenticate from LDAP.
            if (dsUser.Tables[0].Rows[0][Entities.Users.IS_SYSTEM] != DBNull.Value &&
                 dsUser.Tables[0].Rows[0][Entities.Users.IS_SYSTEM].ToString().Equals("1")
                )
            {
                if (Util.verifyMd5Hash(txtPwd, dsUser.Tables[0].Rows[0][Entities.Users.PASSWORD].ToString()))
                {

                    return Enumaration.LoginStatus.Success;
                }
                else
                {
                    return Enumaration.LoginStatus.IncorrectPassword;
                }

            }
            else
            {
                return AuthenticateFromLDAP();
            }

        }


        private Enumaration.LoginStatus AuthenticateFromLDAP()
        {
            return Enumaration.LoginStatus.LDAPNotConnecting;
        }
        #endregion

        #region AUDIT_TRAIL

        public DataSet GetAllEventTypes()
        {
            objAuditTrail = new DAAuditTrail();
            return objAuditTrail.GetAllEventTypes();
        }

        public void AddAppAccessHistory(DataSet CriteriaValues)
        {
            objAuditTrail = new DAAuditTrail();
            objAuditTrail.AddAppAccessHistory(CriteriaValues);
        }

        #endregion

    }
}
