using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using eLearning.DAL.DataAccess;
using eLearning.Common.Utils;
using System.Web;

namespace eLearning.DAL.DAClasses
{
    public class Audit
    {
        public void AddAppAccessHistory(string eventDesc, System.Web.SessionState.HttpSessionState objSession)
        {
            string MODULE_NAME = "Logger";
            string METHOD_NAME = "Add Application Audit History";

            try
            {

                DataSet dsUserInfo = (DataSet)objSession["UserInfo"];
                DataTable dtUserInfo = dsUserInfo.Tables[0];

                if (dtUserInfo.Rows[0]["USERID"] != null)
                {
                    string userId = dtUserInfo.Rows[0]["USERID"].ToString();

                    DataSet ds = new DataSet();
                    DataTable dt = new DataTable("APP_ACCESS_HISTORY");

                    dt.Columns.Add("SESSION_ID");
                    dt.Columns.Add("DATETIME", typeof(DateTime));
                    dt.Columns.Add("DESCRIPTION");
                    dt.Columns.Add("USER_ID");

                    DataRow dr = dt.Rows.Add(new object[] { objSession.SessionID, DateTime.Now, eventDesc, userId });

                    ds.Tables.Add(dt);

                    Security objSecurity = new Security();
                    objSecurity.AddAppAccessHistory(ds);
                }
            }
            catch (Exception exp)
            {
                Logger.getInstance().Error(MODULE_NAME, METHOD_NAME, "Exception [ " + exp.ToString() + " ] Message [ " + exp.Message + " ]");
            }
        }


    }
}
