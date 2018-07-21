using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
namespace eLearning.Common.Utils
{
    public static class DALConstants
    {
        static DALConstants()
        {
        }
        /* amjad
        public static class Culture
        {
            public static string ARABIC = "ar-AE";
            public static string ENGLISH = "en-GB";
        }
        public static string CurrentCulture
        {
            get
            {
                if (System.Threading.Thread.CurrentThread.CurrentCulture.Name == Culture.ENGLISH)
                    return Culture.ENGLISH;
                else if (System.Threading.Thread.CurrentThread.CurrentCulture.Name == Culture.ARABIC)
                    return Culture.ARABIC;
                else
                    return "";
            }
        }
        */
        public static class PageTheme
        {
            public static string EnglishTheme = "CBD_PDMS_EN";
            public static string ArabicTheme = "CBD_PDMS_AR";
        }

      

        public static class TableNames
        {

        }


        public static class Departments
        {
            public static string DEPARTMENT_ID = "DEPARTMENT_ID";
            public static string DEPARTMENT_NAME_EN = "DEPARTMENT_NAME_EN";
            public static string DEPARTMENT_NAME_AR = "DEPARTMENT_NAME_AR";
        }
        public static class DESIGNATION
        {
            public static string DESIGNATION_ID = "DESIGNATION_ID";
            public static string DESIGNATION_NAME_EN = "DESIGNATION_NAME_EN";
            public static string DESIGNATION_NAME_AR = "DESIGNATION_NAME_AR";
            public static string DEPARTMENT_ID = "DEPARTMENT_ID";

        }
        public static class Users
        {
            public static string USERID = "USERID";
            public static string FIRSTNAME_EN = "FIRSTNAME_EN";
            public static string FIRSTNAME_AR = "FIRSTNAME_AR";
            public static string USERNAME = "USERNAME";
            public static string LASTNAME_EN = "LASTNAME_EN";
            public static string LASTNAME_AR = "LASTNAME_AR";
            public static string EMAIL = "EMAIL";
            public static string CELLNO = "CELLNO";
            public static string DEPARTMENT_ID = "DEPARTMENT_ID";
            public static string DESIGNATION_ID = "DESIGNATION_ID";
            public static string ACTIVE = "ACTIVE";
            public static string PASSWORD = "PASSWORD";
            public static string DeveloperId = "Developer_Id";
            public static string IS_FIRST_LOGIN = "IS_FIRST_LOGIN";
            public static string IS_PASSWORD_CHANGED = "IS_PASSWORD_CHANGED";
            public static string IS_ANSWERS_PROVIDED = "IS_ANSWERS_PROVIDED";
        }
        public static class GROUPS
        {
            public static string GROUPID = "GROUPID";
            public static string GROUPNAME_EN = "GROUPNAME_EN";
            public static string GROUPNAME_AR = "GROUPNAME_AR";
            public static string GROUP_DESCRIPTION_EN = "GROUP_DESCRIPTION_EN";
            public static string GROUP_DESCRIPTION_AR = "GROUP_DESCRIPTION_AR";
        }

        public static class MODULE
        {
            public static string MODULE_ID = "MODULE_ID";
            public static string MODULE_NAME_EN = "MODULE_NAME_EN";
            public static string MODULE_NAME_AR = "MODULE_NAME_AR";

        }
        public static class PERMISSIONS
        {
            public static string PERMISSION_ID = "PERMISSION_ID";
            public static string PERMISSION_NAME_EN = "PERMISSION_NAME_EN";
            public static string PERMISSION_NAME_AR = "PERMISSION_NAME_AR";
            public static string MODULE_ID = "MODULE_ID";

        }
        public static class ReportsEnum
        {
            public static string FUNDS_INDIVISUAL_PROPERTY = "FundIndivisualProperty";
            public static string PROJECT_FUND_SUMMARY = "ProjectFundSummary";
            public static string PROJECT_FUND_DETAILS = "ProjectFundDetails";
            public static string PROJECT_HIERARCHY = "ProjectHierarchy";
            public static string Trust_Ledger_Report = "TrustLedgerReport";
            public static string Monthly_Statistic_Report = "MonthlyStatisticReport";
            public static string Monthly_Stats_Report = "MonthlyStatsReport";
            public static string Retention_Withdrawal_Report = "RetentionWithdrawalReport";
            public static string APGAndPBG_Report = "APGAndPBGReport";
            public static string MonthlyReport = "MonthlyReport";
            public static string AuditTrailReport = "AuditTrailReport";

        }

        public enum GRIDSIZE
        {
            SMALL = 0,
            MEDIUM = 1,
            LARGE = 2
        }


        public const string IntermTableSuffix = "_INTRM";
        public const string CheckerPermissionId = "999";



        public const string TagFormat = "<%{0}%>";
        public static class CustomTags
        {
            public const string Token = "<%TOKEN%>";
        }

        public static class AccountTypes
        {
            public const string Retention = "RETENTION";
            public const string Escrow = "ESCROW";
            public const string Infrastructure = "INFRASTRUCTURE";
            public const string Disbursement = "DISBURSEMENT";
            public const string FixedDeposit = "FIXEDDEPOSIT";
        }

        public static class DebitCredit
        {
            public const string Debit = "DR";
            public const string Credit = "CR";

        }
        public static class AdapterChannels
        {
            public const string SMTP_CHANNEL1 = "SMTP_CHANNEL1";
            public const string FAX_CHANNEL1 = "FAX_CHANNEL1";
            public const string SMS_CHANNEL1 = "SMS_CHANNEL1";
        }

        //Added by Fahim Nasir 08/11/2017 15:54:09
        public static class OfferType
        {
            public const string SPECIAL = "SPECIAL";
            public const string CORPORATE = "CORPORATE";
        }

    }
}
