using System;
using System.Diagnostics;
using System.Configuration;

namespace eLearning.Common.Config
{
	/// <summary>
	/// Summary description for Config.
	/// </summary>
	public class Constants
	{
		public Constants(){}
		
		//Tracer Constants
		public static TraceSwitch TRACELEVEL = new TraceSwitch("AppTraceLevel","Application Trace Level Switch");
		public static string LOGFILENAME = SystemParameters.GetParameter("LOGFILENAME");
		public static string LOGPATH = SystemParameters.GetParameter("LOGFILEPATH");
		public static string TRACEEVENTSOURCE = SystemParameters.GetParameter("TRACEEVENTSOURCE");
        public static string APPLOGFILENAME = ConfigurationSettings.AppSettings["APPLOGFILENAME"];
        public static string APPLOGPATH = ConfigurationSettings.AppSettings["APPLOGFILEPATH"];
        public static bool ALLOWEVENTLOG = true;
        public const string CRLF = "\r\n";
        public static string APPLICATIONPATH = ".";
        public static string DEBUG_LEVEL = "Debug";
        public const string DATE_FORMAT = "dd/MM/yyyy";

        public static string SOURCEFTP = "FTP";
        public static string SOURCEFILE = "FILE";
        public static string YES = "Y";
        public static string NO = "N";
        public static string TYPE_INT = "int";
        public static string TYPE_DECIMAL = "decimal";
        public static string TYPE_DATE = "date";
        public static string TYPE_TEXT = "text";
        public static string PLUS = "+";
        public static string MINUS = "-";

        public static string CELL_SPACING = "3";
        public static string CELL_PADDING = "0";

        public static string FORGET_PASSWORD_KEY = "EmailForgetPassword";
        public static string COMPANY_NAME = "Emirates Transport Driving Institute ";
        public static int RETRY_COUNT = 3;
        public static string TRAINING_REQUEST_TO = "TrainingRequestTo";

        // Added by AVANZA\vijay.kumar on 02/02/2018 15:02:38
        public static string WEB_STUDENT_USER_SIGN_UP = "WebPortalUserCreationDetail";
        public static string WEB_COMPANY_USER_SIGN_UP = "WebSComapnyUserSignUpDetail";
        public static string NEW_GENERAL_REQUEST = "NEW_GENERAL_REQUEST";
        public static string GENERAL_REQUEST_COMPLETED = "GENERAL_REQUEST_COMPLTED";
    }
}
