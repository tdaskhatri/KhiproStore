using System;
using System.Text;
using System.Threading;
using System.Globalization;
using eLearning.Common.Config;
using System.Collections;
using eLearning.Common.Utils;
using System.Data;
using System.Reflection;
using System.Resources;
using System.Configuration;
using System.IO;
using System.Security.AccessControl;

namespace eLearning.Common.Utils
{

    /// <summary>
    /// 
    /// </summary>

    public class DateUtil
    {


        static string DB_DEFAULT_LONG_DATE_FORMAT = "yyyy-MM-dd HH:mm:ss";
        static string DB_DEFAULT_SHORT_DATE_FORMAT = "yyyy-MM-dd";
        static string DISPLAY_DEFAULT_LONG_DATE_FORMAT = "dd/MM/yyyy HH:mm:ss";
        static string DISPLAY_DEFAULT_SHORT_DATE_FORMAT = "dd/MM/yyyy";
        static string DISPLAY_DEFAULT_SHORT_DATE_FORMAT_EXT = "dd/MM/yyyy";
        public DateUtil()
        {
        }

        public static string DbDefaultLongDateFormat { get { return DB_DEFAULT_LONG_DATE_FORMAT; } }
        public static string DbDefaultShortDateFormat { get { return DB_DEFAULT_SHORT_DATE_FORMAT; } }
        public static string DisplayDefaultLongDateFormat { get { return DISPLAY_DEFAULT_LONG_DATE_FORMAT; } }
        public static string DisplayDefaultShortDateFormat { get { return DISPLAY_DEFAULT_LONG_DATE_FORMAT; } }


        public static string ConvertDateToDisplayDefaultLongString(DateTime date)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            return date.ToString(DISPLAY_DEFAULT_LONG_DATE_FORMAT);
        }

        public static string ConvertDateToDisplayDefaultShortString(DateTime date)
        {

            if (!date.ToShortDateString().Equals("1/1/0001") && !date.ToShortDateString().Equals("01/01/0001"))
                return date.ToString(DISPLAY_DEFAULT_SHORT_DATE_FORMAT);//
            else
                return "";
        }

        // Added by MUHAMMADUZAIR\avanza on 21/09/2017 14:14:56
        //Convert string to date format dd/MM/yyyy
        public static DateTime ConvertStringToDateTime(string datetime)
        {
            return DateTime.ParseExact(datetime, Constants.DATE_FORMAT, CultureInfo.InvariantCulture);
        }
        


        /// <summary>
        /// 
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static DateTime ConvertStringToDate(string date)
        {
            //Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            //date +=" 00:00:00";
            ////return DateTime.Parse(date);

            //DateTime currentDate = DateTime.Parse(date);
            //Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            //return currentDate;

            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            //date +=" 00:00:00";
            return DateTime.Parse(date);
        }

        public static int GetDateDifference(DateTime a_StartDate, DateTime a_EndDate)
        {
            int i_DaysCount = 0;

            int m_YearsDiff = a_StartDate.Year - a_EndDate.Year;
            i_DaysCount = (a_EndDate.DayOfYear + (m_YearsDiff * 365)) - a_StartDate.DayOfYear;


            return i_DaysCount;
        }


        public static TimeSpan GetDateDifferenceInTimeSpan(DateTime a_StartDate, DateTime a_EndDate)
        {

            TimeSpan timeSpan = a_StartDate.Subtract(a_EndDate);

            return timeSpan;
        }

        public static string ConvertDateTimeForSQL(string date)
        {
            return " Convert(datetime,'" + date + "' , 113) ";
        }
        public static string ConvertDateTimeForSQL(DateTime date)
        {
            return " Convert(datetime,'" + date.ToString("dd MMM yyyy HH:mm:ss:fff") + "' , 113) ";
        }
        public static string ConvertDateTimeForSQL(DateTime date, bool max)
        {
            if (max)
            {
                date = new DateTime(date.Year, date.Month, date.Day, 23, 59, 59, 997);
            }
            else
            {
                date = new DateTime(date.Year, date.Month, date.Day, 0, 0, 0, 0);
            }
            return ConvertDateTimeForSQL(date);
        }

        /// <summary>
        /// This method will return Datetime object 
        /// </summary>
        /// <param name="a_DateTime"></param>
        /// <returns></returns>
        // Commented by MUHAMMADUZAIR\avanza on 21/09/2017 14:22:56
        //public static DateTime ConvertStringToDateTime(string a_DateTime)
        //{
        //    Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
        //    //Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");			
        //    return DateTime.Parse(a_DateTime);

        //}

        public static DateTime ConvertInternalStringToDate(string date)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            return DateTime.Parse(date);

        }

        public static DateTime ConvertDate(DateTime date)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");

            return ConvertInternalStringToDate(ConvertDateToDisplayDefaultShortString(date));



        }

        public static DateTime ConvertTime(DateTime a_DateTime)
        {
            //Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            return ConvertInternalStringToDate(ConvertDateToDisplayDefaultShortString(a_DateTime));
        }



        /// <summary>
        /// This method will rectify the string found in DB as &#39 into single quote add one more ' whereever it
        /// finds single' .
        /// </summary>
        /// <param name="stringWithSingleQuote"></param>
        /// <returns></returns>
        public static string RectifyUniCodeFromDB(string stringWithSingleQuoteInDB)
        {
            StringBuilder buffer = new StringBuilder(stringWithSingleQuoteInDB);
            buffer = buffer.Replace("&#39", "'");
            buffer = buffer.Replace("&gt;", ">");
            buffer = buffer.Replace("&lt;", "<");
            buffer = buffer.Replace("&quote;", "\"");

            return buffer.ToString();
        }


        public static string ReplaceEnter(string stringWithEnter)
        {

            StringBuilder buffer = new StringBuilder(stringWithEnter);
            string ResultString = "";

            for (int i = 0; i < buffer.Length; i++)
            {

                if (buffer[i] == '\n')
                {
                    ResultString += "<br>";
                }
                else
                {
                    ResultString += buffer[i];
                }
            }
            return ResultString;
        }

        public static DateTime getWeekBeginDate(DateTime a_DateTime)
        {
            DateTime WeekBeginDate = a_DateTime;
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");

            int dayOfWeek = getDayOfWeek(a_DateTime.DayOfWeek);


            switch (dayOfWeek)
            {
                case 0: return WeekBeginDate.Subtract(TimeSpan.FromDays(0.0));
                case 1: return WeekBeginDate.Subtract(TimeSpan.FromDays(1.0));
                case 2: return WeekBeginDate.Subtract(TimeSpan.FromDays(2.0));
                case 3: return WeekBeginDate.Subtract(TimeSpan.FromDays(3.0));
                case 4: return WeekBeginDate.Subtract(TimeSpan.FromDays(4.0));
                case 5: return WeekBeginDate.Subtract(TimeSpan.FromDays(5.0));
                case 6: return WeekBeginDate.Subtract(TimeSpan.FromDays(6.0));
            }

            return a_DateTime;
        }

        public static int getDayOfWeek(DayOfWeek a_DayOfWeek)
        {
            switch (a_DayOfWeek)
            {
                case DayOfWeek.Monday: return 0;
                case DayOfWeek.Tuesday: return 1;
                case DayOfWeek.Wednesday: return 2;
                case DayOfWeek.Thursday: return 3;
                case DayOfWeek.Friday: return 4;
                case DayOfWeek.Saturday: return 5;
                case DayOfWeek.Sunday: return 6;

            }

            return 0;
        }

        private static string[] m_MonthsArray = new string[]{"January",
                                                            "February",
                                                            "March",
                                                            "April",
                                                            "May",
                                                            "June",
                                                            "July",
                                                            "August",
                                                            "September",
                                                            "October",
                                                            "November",
                                                            "December"
                                                            };

        public static string getMonthTitle(int a_MonthId)
        {
            if ((a_MonthId > 0) && (a_MonthId <= 12))
            {
                return m_MonthsArray[a_MonthId - 1];
            }
            return "";
        }
        public static DateTime GetDateFromTextBox(string txtDate)
        {

            DateTime ODT = DateTime.ParseExact(txtDate, "dd/MM/yyyy", null);
            txtDate = ODT.ToString("MM/dd/yyyy");
            ODT = DateTime.ParseExact(txtDate, "MM/dd/yyyy", null);
            return ODT;
        }

        public static DateTime GetDateFromTextBoxExt(string txtDate)
        {
            return DateTime.ParseExact(txtDate, DISPLAY_DEFAULT_SHORT_DATE_FORMAT_EXT, null);
        }

        public static string GetStringForTextBoxExt(object date)
        {
            if (date != null || date != DBNull.Value)
            {
                return Convert.ToDateTime(date).ToString(DISPLAY_DEFAULT_SHORT_DATE_FORMAT_EXT);
            }
            else
                return string.Empty;
        }
    }
}
