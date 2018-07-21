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
    public class Roles
    {
        DARoles objDARoles = null;



        public DataSet Search(Dictionary<Enumaration.SearchRolesCriteria, Object> criteria, bool fromProduction)
        {
            objDARoles = new DARoles();
            if (fromProduction)
                return objDARoles.Search(criteria);
            else
                return objDARoles.SearchInterim(criteria);
        }

        public DataSet GetRolesById(string roleId)
        {
            DataSet dsReturn = new DataSet();
            objDARoles = new DARoles();

            DataTable dtRole = objDARoles.GetRoleById(roleId);
            dsReturn.Tables.Add(dtRole);

            DAPermissions objDAPermissions = new DAPermissions();
            DataTable dtPermissions = objDAPermissions.GetPermissionsByRoleId(roleId);
            dsReturn.Tables.Add(dtPermissions);

            return dsReturn;
        }
        public DataSet GetRolesInterimById(string roleId)
        {
            DataSet dsReturn = new DataSet();
            objDARoles = new DARoles();

            DataTable dtRole = objDARoles.GetInterimRoleById(roleId);
            dsReturn.Tables.Add(dtRole);

            DAPermissions objDAPermissions = new DAPermissions();
            DataTable dtPermissions = objDAPermissions.GetInterimPermissionsByRoleId(roleId);
            dsReturn.Tables.Add(dtPermissions);

            return dsReturn;
        }

        public void PersistRoles(DataSet ds, string selectedPermissions)
        {
            objDARoles = new DARoles();

            using (DbTransaction transaction = objDARoles.CreateTransaction())
            {
                try
                {
                    DataTable dtUser = ds.Tables[Entities.Roles.TABLE_NAME];
                    objDARoles.PersistRole(dtUser.Rows[0], transaction);

                    DARolePermissions oDARolePermissions = new DARolePermissions();
                    oDARolePermissions.PersistRolesPermissions(selectedPermissions,
                                                                dtUser.Rows[0][Entities.Roles.ROLE_ID].ToString(),
                                                                dtUser.Rows[0][Entities.Roles.UPDATED_BY].ToString(),
                                                                transaction);


                    objDARoles.CommitTransaction(transaction);
                }
                catch (Exception e)
                {
                    objDARoles.RollbackTransaction(transaction);
                    throw e;
                }
            }
        }

        public DataSet GetRoleDataSet()
        {
            DataSet dsReturn = new DataSet();
            dsReturn.Tables.Add(Entities.Roles.GetDataTable());
            dsReturn.Tables.Add(Entities.Permissions.GetDataTable());


            return dsReturn;

        }

    }
}
