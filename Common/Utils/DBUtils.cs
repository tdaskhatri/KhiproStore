using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Globalization;
using System.IO;
using System.Threading;

namespace eLearning.Common.Utils
{
    public class DBUtils
    {
        public static object GetIntValueFromDBLayer(int pFromDB)
        {
            if (pFromDB == int.MinValue)
                return DBNull.Value;

            return pFromDB;
        }

        public static object GetValueForDBLayer(object pFromDB)
        {
            if (pFromDB == null)
                return DBNull.Value;

            return pFromDB;
        }
        
        public static object GetDateValueFromDBLayer(DateTime pDateDB)
        {
            if (pDateDB == DateTime.MinValue)
                return DBNull.Value;

            return pDateDB;
        }
        public static object GetValue(object obj)
        {
            if(obj==DBNull.Value)
                return null;
            else 
                return obj;
        }
        public static object GetIntFromDB(object obj)
        {
            if (obj == DBNull.Value)
                return null;
            else
                return Convert.ToInt32(obj);
        }
        public static int GetNonNullIntFromDB(object obj)
        {
            if (obj == DBNull.Value)
                return -1;
            // Added by Fahim Nasir on 10/02/2017 12:35:45
            else if (obj.ToString().Equals(""))
                return -1;
            //============================================
            else
                return Convert.ToInt32(obj);
        }
        public static Decimal GetNonNullAmountFromDB(object obj)
        {
            if (obj == DBNull.Value)
                return 0;
            else
                return Convert.ToDecimal(obj);
        }

        // Added by Fahim Nasir on 18/01/2017 16:17:31
        public static string GetNonNullStringFromDB(object obj)
        {
            if (obj == DBNull.Value)
            {
                return string.Empty;
            }
            else
            {
                return Convert.ToString(obj);
            }
        }
        //=============================================
        public static object GetStringFromDB(object obj)
        {
            if (obj == DBNull.Value)
                return null;
            else
                return Convert.ToString(obj);
        }
        public static object GetStringValueForDBLayer(string pStr)
        {
            if (pStr == null || pStr == "")
                return DBNull.Value;

            return pStr;
        }

        /// <summary>
        /// This method will rectify the string and add one more ' whereever it
        /// finds single ' .
        /// </summary>
        /// <param name="stringWithSingleQuote"></param>
        /// <returns></returns>
        public static string RectifyValues(string stringWithSingleQuote)
        {
            stringWithSingleQuote = stringWithSingleQuote.Trim();
            StringBuilder buffer = new StringBuilder(stringWithSingleQuote);
            buffer = buffer.Replace("\'", "\''");
            //buffer = buffer.Replace(">","&gt;");
            //buffer = buffer.Replace("<","&lt;");
            //buffer = buffer.Replace("\"","&quote;");

            return buffer.ToString();
        }


      
        public static string getCSVFromDataTable(DataTable pDt,string pCoulmnName)
        {
            if (pDt == null)
                return null;
            string list = "";
            foreach (DataRow o in pDt.Rows)
            {
                list += o[pCoulmnName].ToString() + ",";
            }
            return list.TrimEnd(',');
        }

        public static string getCSVFromDataTableForClildRow(DataTable pDt, string pMasterCoulmnName,
                                                            string pMasterCoulmnValue, string pChildColumnName)
        {
            if (pDt == null)
                return null;
            string list = "";
            string filter = "";
            string[] MasterColumns = pMasterCoulmnName.Split(',');
            string[] MasterValues = pMasterCoulmnValue.Split(',');
            if (!(MasterColumns.Length == 0))
            {
                for (int i = 0; i < MasterColumns.Length; i++)
                {
                    filter += ((filter != "") ? " AND " : "") + MasterColumns[i] + " = " + MasterValues[i] + "";
                }
                filter = filter.TrimEnd(',');
            }
            else
            {
                filter = pMasterCoulmnName + "=" + pMasterCoulmnValue;
            }
            DataRow[] Rows = pDt.Select(filter);
            foreach (DataRow o in Rows)
            {
                list += o[pChildColumnName].ToString() + ",";
            }
            return list.TrimEnd(',');
        }

        public static object GetDecimalValueFromDBLayer(decimal pFromDB)
        {
            if (pFromDB == decimal.MinValue)
                return DBNull.Value;

            return pFromDB;
        }

        public static Hashtable GetSchemaTable(DataTable pDT)
        {
            Hashtable ht = new Hashtable();

            //Loop through the reader and add an entry to the hashtable for each column.

            for (int i = 0; i < pDT.Columns.Count; i++)
            {
                ht.Add(pDT.Columns[i].ColumnName, i);
            }

            return ht;
        }

        public static string GetCultureColumnName(string columnName)
        {
            CultureInfo ci = Thread.CurrentThread.CurrentCulture;
            string RESULT = "";
            switch (ci.Name)
            {
                case "ar-AE": RESULT = columnName + "_AR"; break;
                case "en-US": RESULT = columnName + "_EN"; break;
                default: RESULT = columnName + "_EN";break;
            }
            return RESULT;
        }

        public static string GetCultureColumnName(string columnName , CultureInfo ci)
        {
            switch (ci.Name)
            {
                case "ar-AE": return columnName + "_AR";
                case "en-US": return columnName + "_EN";
                default: return columnName + "_EN";
            }
        }


        public static string ConvertDateToStringForDBUpdate(Object obj)
        {
            if (obj != null && obj != DBNull.Value && obj.ToString() != "")
            {
                DateTime date = Convert.ToDateTime(obj);
                Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
                if (!date.ToShortDateString().Equals("1/1/1900") && !date.ToShortDateString().Equals("01/01/1900"))
                    return "to_date('" + date.ToString("yyyy-MM-dd HH:mm:ss") + "','YYYY-MM-DD HH24:MI:SS')";

                else
                    return "null";
            }
            else return "null";
        }

        public static string ConvertToShortDate(Object obj)
        {
            if (obj != null && obj != DBNull.Value && obj.ToString() != "")
            {
                DateTime date = Convert.ToDateTime(obj);
                Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
                if (!date.ToShortDateString().Equals("1/1/1900") && !date.ToShortDateString().Equals("01/01/1900"))
                    return "to_date('" + date.ToString("yyyy-MM-dd") + "','YYYY-MM-DD')";

                else
                    return "null";
            }
            else return "null";
        }

        public static string ConvertStringToStringForDBUpdate(Object obj)
        {
            if (obj != null && obj != DBNull.Value)
                return "'" + (string)obj + "'";

            else
                return "null";
        }

        public static string ConvertIntToStringForDBUpdate(Object obj)
        {
            if (obj == null)
                return "null";
            if (obj == DBNull.Value)
                return "null";
            if (obj.ToString() == "")
                return "null";
            else if (Convert.ToInt32(obj) == -1)
                return "null";
            else
                return obj.ToString();

        }
        public static  byte[] StringToByteArray(string str)
        {
            System.Text.ASCIIEncoding encoding = new System.Text.ASCIIEncoding();
            return encoding.GetBytes(str);
        }

        public static string ConvertCurrencyToNumber(string currency)
        {
            return RemoveComma(currency);
        }

        public static string RemoveComma(string strVal)
        {
            strVal=strVal.Trim();
            if (strVal== "")
                return "0";
            else
            return strVal.Replace(",", "").Trim();
        }

        public static string LoadFile(string sFileName)
        {
            FileStream oFS = null;
            try
            {
                oFS = File.OpenRead(sFileName);

                if (oFS != null)
                {
                    byte[] bData = new byte[oFS.Length];

                    int iRead = oFS.Read(bData, 0, bData.Length);

                    if (iRead != bData.Length)
                        throw new Exception("Number of bytes read is less than expected number of bytes in a file!");
                    else
                    {
                        string fleContent = Encoding.Default.GetString(bData);
                        return fleContent;
                    }
                }
            }
            catch (Exception error) {
                Logger.getInstance().Error("DBUtils", "SaveFile", "Error while reading the file " + sFileName + " Details[+" + error.ToString() + "]");
            }
            finally
            {
                oFS.Close();
            }
            return null;
        }

        public static bool SaveFile(string sFileName, string contents)
        {

            FileStream oFS = null;
            try
            {
                oFS = File.Create(sFileName);
                if (oFS != null)
                {
                    byte[] bData = Encoding.Default.GetBytes(contents);
                    oFS.Write(bData, 0, bData.Length);
                }
            }
            catch (Exception error) {

                Logger.getInstance().Error("DBUtils", "SaveFile", "Error while creating the file " + sFileName + " Details[+" + error.ToString() + "]");
                return false;
            }
            finally
            {
                oFS.Close();
            }
            return true;
        }


        public static string RemoveDashesfromString(string strVal)
        {
            strVal = strVal.Trim();
            if (strVal == "")
                return strVal;
            else
                return strVal.Replace("-", "").Trim();
        }

        public static string RemoveSingleQuotefromString(string strVal)
        {
            strVal = strVal.Trim();
            if (strVal == "")
                return strVal;
            else
                return strVal.Replace("'", "").Trim();
        }



    }
}
