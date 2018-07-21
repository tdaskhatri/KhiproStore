using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

// Added by Fahim Nasir on 11/01/2017 15:08:59
namespace eLearning.Common
{
    public static class Validations
    {
        public static bool ValidateNumber(string inputStr)
        {
            string regexNum = @"^[0-9]*$";
            Regex objRegex = new Regex(regexNum);
            Match objMatch = objRegex.Match(inputStr);
            return objMatch.Success;
        }

        
        public static bool ValidateString(string inputStr)
        {
            string regexNum = "([A-Z]|[a-z])*$";

            Regex objRegex = new Regex(regexNum);
            Match objMatch = objRegex.Match(inputStr);
            return objMatch.Success;
        }

        public static bool ValidateNumericString(string inputStr)
        {
            string regexNum = "^([A-Z]|[a-z]|[0-9])*$";

            Regex objRegex = new Regex(regexNum);
            Match objMatch = objRegex.Match(inputStr);
            return objMatch.Success;
        }

        public static bool ValidateNumericStringWithSpaces(string inputStr)
        {
            string regexNum = "^([A-Z ]|[a-z ]|[0-9 ])*$";

            Regex objRegex = new Regex(regexNum);
            Match objMatch = objRegex.Match(inputStr);
            return objMatch.Success;
        }

        // Added by Fahim Nasir on 11/01/2017 15:55:58
        public static bool ValidateNumberWithHyphenOnly(string inputStr)
        {
            string regexNum = @"^[0-9-]*$";
            Regex objRefex = new Regex(regexNum);
            Match objMach = objRefex.Match(inputStr);
            return objMach.Success;
        }
        //===============================================
        public static bool ValidateNumericStringWithOthers(string inputStr)
        {
            string regexNum = "^([A-Z ]|[a-z ]|[0-9 ]|-|,|.)*$";

            Regex objRegex = new Regex(regexNum);
            Match objMatch = objRegex.Match(inputStr);
            return objMatch.Success;
        }

        
        public static bool ValidateNumericStringWithSpacesWithComma(string inputStr)
        {
            string regexNum = "^([A-Z ]|[a-z ]|[0-9 ]|,)*$";

            Regex objRegex = new Regex(regexNum);
            Match objMatch = objRegex.Match(inputStr);
            return objMatch.Success;
        }

        public static bool ValidateNumericStringWithSpacesWithHyphen(string inputStr)
        {
            string regexNum = "^([A-Z ]|[a-z ]|[0-9 ]|-)*$";

            Regex objRegex = new Regex(regexNum);
            Match objMatch = objRegex.Match(inputStr);
            return objMatch.Success;
        }
        public static bool ValidateDecimal(string inputStr)
        {
            string regexNum = "^[0-9]*.?[0-9]*$";

            Regex objRegex = new Regex(regexNum);
            Match objMatch = objRegex.Match(inputStr);
            return objMatch.Success;
        }

        public static bool ValidateTelePhoneNum(string inputStr)
        {
            string regexNum = @"^[0-9\s\(\)\+\-]+$";             
            Regex objRegex = new Regex(regexNum);
            Match objMatch = objRegex.Match(inputStr);
            return objMatch.Success;
        }

        public static bool ValidateTimeFormat(string inputStr)
        {
            string regexNum = "([0-2][0-9]:[0-5][0-9])$";
            Regex objRegex = new Regex(regexNum);
            Match objMatch = objRegex.Match(inputStr);
            return objMatch.Success;
        }

        public static bool ValidateEmail(string inputEmail)
        {           
           string strRegex = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                 @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" + 
                 @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
           Regex objRegex = new Regex(strRegex);
           Match objMatch = objRegex.Match(inputEmail);
           return objMatch.Success;
        }

        public static bool ValidatePercentage(string inputPercentage)
        {
           string strRegex = @"^[0-9]{0,2}(\.[0-9]{1,2})?$|^(100)(\.[0]{1,2})?$";
           Regex objRegex = new Regex(strRegex);
           Match objMatch = objRegex.Match(inputPercentage);
           return objMatch.Success;
        }

        


 
        

    }
}
