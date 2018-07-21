using System;
using System.Collections.Generic;
using System.Text;
using eLearning.Common.Utils;
using System.Reflection;
using System.Collections;
using System.Data.Common;
using System.Data;

namespace eLearning.DAL.DataAccess
{
    public class Entities
    {
        public static DataTable GetFilesToDeleteDataTable()
        {
            DataTable dt = new DataTable(Enumaration.Keys.FilesToDelete);
            dt.Columns.Add(Enumaration.Keys.FilesToDelete);
            return dt;

        }

        // Added by AVANZA\jawwad.ahmed on 02/11/2017 11:33:03
        public static class Training_Request
        {
            public const string TABLE_NAME = "TRAINING_REQUEST";
            public const string ID = "ID";
            public const string TRAINING_CONTRACT_NO = "TRAINING_CONTRACT_NO";
            public const string LANGUAGE_ID = "LANGUAGE_ID";
            public const string TRAINING_FOR = "TRAINING_FOR";
            public const string CENTER_ID = "CENTER_ID";
            public const string COMPANY_ID = "COMPANY_ID";
            public const string BRANCH_ID = "BRANCH_ID";
            public const string TRAINING_SITE = "TRAINING_SITE";
            public const string REMARKS = "REMARKS";
            public const string ADDRESS = "ADDRESS";
            public const string AUDIANCE = "AUDIANCE";
            public const string IS_ACTIVE = "IS_ACTIVE";
            public const string IS_PREDEFINED = "IS_PREDEFINED";
            public const string PREDEFINED_TRAINING_ID = "PREDEFINED_TRAINING_ID";
            public const string CREATED_ON = "CREATED_ON";
            public const string CREATED_BY = "CREATED_BY";
            public const string UPDATED_ON = "UPDATED_ON";
            public const string UPDATED_BY = "UPDATED_BY";
            public const string STATUS_ID = "STATUS_ID";

            public const string AUDIANCE_NEW_DRIVER = "AUDIANCE_NEW_DRIVER";
            public const string AUDIANCE_NEW_SUPERVISOR = "AUDIANCE_NEW_SUPERVISOR";
            public const string AUDIANCE_REFRESHER_DRIVER = "AUDIANCE_REFRESHER_DRIVER";
            public const string AUDIANCE_REFRESHER_SUPERVISOR = "AUDIANCE_REFRESHER_SUPERVISOR";
            public const string AUDIANCE_GENERAL = "AUDIANCE_GENERAL";


        }


        // Added by VIJAY\Administrator on 02/11/2017 09:47:37
        public static class Training_Request_Courses
        {
            public const string TABLE_NAME = "TRAINING_REQUEST_COURSES";
            public const string ID = "ID";
            public const string TRAINING_REQUEST_ID = "TRAINING_REQUEST_ID";
            public const string COURSE_ID = "COURSE_ID";
            public const string COURSE_ORDER = "COURSE_ORDER";
            public const string COURSE_NAME = "COURSE_NAME";
            public const string COURSE_FEE = "COURSE_FEE";
            public const string COURSE_CODE = "COURSE_CODE";
            public const string CHAPTER_ID = "CHAPTER_ID";
            public const string CHAPTER_NAME = "CHAPTER_NAME";
            public const string ELIGIBILITY_CRITERIA = "ELIGIBILITY_CRITERIA";
            public const string PRACTICAL_DURATION = "PRACTICAL_DURATION";
            public const string THEORY_DURATION = "THEORY_DURATION";

        }

        // Added by VIJAY\Administrator on 02/11/2017 09:52:57

        public static class Training_Request_Trainees
        {
            public const string TABLE_NAME = "Training_Request_Trainees";
            public const string ID = "ID";
            public const string TRAINING_REQUEST_ID = "TRAINING_REQUEST_ID";
            public const string EMIRATE_ID_NUMBER = "EMIRATE_ID_NUMBER";
            public const string EMIRATE_ID_EXPIRY = "EMIRATE_ID_EXPIRY";
            public const string FIRST_NAME = "FIRST_NAME";
            public const string LAST_NAME = "LAST_NAME";
            public const string DOB = "DOB";
            public const string NATIONALITY = "NATIONALITY";
            public const string NATIONALITY_CODE = "NATIONALITY_CODE";
        }

        // Added by VIJAY\Administrator on 02/11/2017 10:00:08
        public static class Training_Request_Installments
        {
            public const string TABLE_NAME = "Training_Request_Installments";
            public const string ID = "ID";
            public const string TRAINING_REQUEST_ID = "TRAINING_REQUEST_ID";
            public const string DUE_DATE = "DUE_DATE";
            public const string DUE_AMOUNT = "DUE_AMOUNT";
            public const string STATUS = "STATUS";
            public const string DESCRIPTION = "DESCRIPTION";
            //Added by Fahim Nasir 15/01/2018 11:16:10
            public const string REFERENCE_FILE_NAME = "REFERENCE_FILE_NAME";
            //Added by Fahim Nasir 22/02/2018 15:05:01
            public const string VAT_TAX_AMOUNT = "VAT_TAX_AMOUNT";
            public const string VAT_TAX_RATE = "VAT_TAX_RATE";
            //=======================================
        }






        //New Columns are added by M.Tariq on 03 Jan 2017
        public static class Users
        {
            public const string TABLE_NAME = "USERS";
            public const string IS_NEW = "IS_NEW";
            public const string USER_ID = "USER_ID";
            public const string FULL_NAME_EN = "FULL_NAME_EN";
            public const string FULL_NAME_AR = "FULL_NAME_AR";
            public const string EMAIL = "EMAIL";
            public const string USER_IMAGE = "USER_IMAGE";

            public const string IS_SYSTEM = "IS_SYSTEM";
            public const string PASSWORD = "PASSWORD";
            public const string IS_ACTIVE = "IS_ACTIVE";
            public const string CREATED_BY = "CREATED_BY";
            public const string UPDATED_BY = "UPDATED_BY";
            public const string CREATED_BY_EN = "CREATED_BY_EN";
            public const string CREATED_BY_AR = "CREATED_BY_AR";
            public const string CREATED_ON = "CREATED_ON";
            public const string UPDATED_ON = "UPDATED_ON";
            public const string DEPARTMENT = "DEPARTMENT";
            public const string REFERENCE_TYPE_ID = "REFERENCE_TYPE_ID";

            public const string FIRST_NAME_EN = "FIRST_NAME_EN";
            public const string LAST_NAME_EN = "LAST_NAME_EN";
            public const string FIRST_NAME_AR = "FIRST_NAME_AR";
            public const string LAST_NAME_AR = "LAST_NAME_AR";
            public const string CENTER_ID = "CENTER_ID";
            public const string AUTHENTICATION_PROVIDER = "AUTHENTICATION_PROVIDER";
            public const string BRANCH_ID = "BRANCH_ID";
            public const string MOBILE = "MOBILE";
            public const string LANGUAGE_ID = "LANGUAGE_ID";
            public const string USER_UNIQUE_ID = "ID";
            public const string IS_ONLINE = "IS_ONLINE";
            public const string EMIRATES = "EMIRATES";

            // AVANZA\muhammad.awais - 25/08/2017 14:48:18
            public const string LOGIN_LANGUAGE = "LOGIN_LANGUAGE";

            //Added by Fahim Nasir 02/10/2017 15:03:43
            public const string USER_TYPE_ID = "USER_TYPE_ID";

            //Added by Fahim Nasir 24/11/2017 10:55:10
            public const string EMIRATES_ID_NUMBER = "EMIRATES_ID_NUMBER";

            //Vijay Kumar adding training_request_id
            public const string TRAINING_REQUEST_ID = "TRAINING_REQUEST_ID";
            // Added by AVANZA\vijay.kumar on 30/01/2018 18:11:48
            public const string FINANCIAL_NO = "FINANCIAL_NO";

            public static DataTable GetDataTable()
            {
                DataTable dt = new DataTable(TABLE_NAME);
                dt.Columns.Add(USER_ID, typeof(String));
                dt.Columns.Add(DEPARTMENT, typeof(int));
                dt.Columns.Add(IS_NEW, typeof(String));
                dt.Columns.Add(FULL_NAME_EN, typeof(String));
                dt.Columns.Add(FULL_NAME_AR, typeof(String));
                dt.Columns.Add(EMAIL, typeof(String));
                DataColumn isSystem = new DataColumn();
                isSystem.DefaultValue = "0";
                isSystem.ColumnName = IS_SYSTEM;
                isSystem.AllowDBNull = true;
                dt.Columns.Add(isSystem);
                dt.Columns.Add(PASSWORD, typeof(String));
                dt.Columns.Add(IS_ACTIVE, typeof(String));
                dt.Columns.Add(CREATED_BY, typeof(String));
                dt.Columns.Add(CREATED_BY_EN, typeof(String));
                dt.Columns.Add(CREATED_BY_AR, typeof(String));
                dt.Columns.Add(CREATED_ON, typeof(DateTime));
                dt.Columns.Add(USER_IMAGE, typeof(string));
                dt.Columns.Add(UPDATED_BY, typeof(String));
                dt.Columns.Add(UPDATED_ON, typeof(DateTime));
                //New Columns are added by M.Tariq on 03 Jan 2017 as per FS

                dt.Columns.Add(FIRST_NAME_EN, typeof(String));
                dt.Columns.Add(LAST_NAME_EN, typeof(String));
                dt.Columns.Add(FIRST_NAME_AR, typeof(String));
                dt.Columns.Add(LAST_NAME_AR, typeof(String));
                dt.Columns.Add(CENTER_ID, typeof(int));
                dt.Columns.Add(AUTHENTICATION_PROVIDER, typeof(String));
                dt.Columns.Add(BRANCH_ID, typeof(int));
                dt.Columns.Add(MOBILE, typeof(String));
                dt.Columns.Add(LANGUAGE_ID, typeof(int));
                dt.Columns.Add(USER_UNIQUE_ID, typeof(int));
                dt.Columns.Add(EMIRATES, typeof(string));
                // AVANZA\muhammad.awais - 25/08/2017 14:47:58
                dt.Columns.Add(LOGIN_LANGUAGE, typeof(string));
                // AVANZA\Vijay.Kumar - 27/10/2017 
                dt.Columns.Add(REFERENCE_TYPE_ID, typeof(int));
                // Added by AVANZA\vijay.kumar on 30/01/2018 18:13:12
                dt.Columns.Add(FINANCIAL_NO, typeof(int));
                return dt;
            }

        }

        //Added by Fahim Nasir 02/11/2017 15:29:10
        public static class Exams
        {
            public const string TABLE_NAME = "EXAMS";
            public const string ID = "ID";
            public const string NAME_EN = "NAME_EN";
            public const string NAME_AR = "NAME_AR";
            public const string DESCRIPTION = "DESCRIPTION";
            public const string IS_ETTC = "IS_ETTC";
            public const string IS_RTA_EXAM = "IS_RTA_EXAM";
            public const string IS_ACTIVE = "IS_ACTIVE";
            public const string IS_ETDI_EXAM = "IS_ETDI_EXAM";
            public const string CREATED_ON = "CREATED_ON";
            public const string CREATED_BY = "CREATED_BY";
            public const string UPDATED_ON = "UPDATED_ON";
            public const string UPDATED_BY = "UPDATED_BY";
        }
        //===========================================

        public static class ServiceRates
        {
            public const string TABLE_NAME = "SERVICE_RATES";
            public const string ID = "ID";
            public const string NAME_EN = "NAME_EN";
            public const string NAME_AR = "NAME_AR";
            public const string MAIN_SERVICE_ID = "MAIN_SERVICE_ID";
            public const string RATE_CARD_CATEGORY_ID = "RATE_CARD_CATEGORY_ID";
            public const string SERVICE_SHIFT_ID = "SERVICE_SHIFT_ID";
            public const string SUB_SERVICE_ID = "SUB_SERVICE_ID";
            public const string BEGIN_DATE = "BEGIN_DATE";
            public const string END_DATE = "END_DATE";
            public const string CREATED_ON = "CREATED_ON";
            public const string CREATED_BY = "CREATED_BY";
            public const string UPDATED_ON = "UPDATED_ON";
            public const string UPDATED_BY = "UPDATED_BY";

            // Added by Muhammad Uzair on 16/02/2018 17:55:19 
            public const string VAT_PERCENTAGE = "VAT_PERCENTAGE";
            // Added by Muhammad Uzair on 21/02/2018 11:15:59 
            public const string RTA_VAT_PERCENTAGE = "RTA_VAT_PERCENTAGE";
        }

        public static class ServiceRatesClasses
        {
            public const string TABLE_NAME = "SERVICE_RATE_CLASSES";
            public const string ID = "ID";
            public const string SERVICE_RATE_ID = "SERVICE_RATE_ID";
            public const string PREV_LICENSE_EXP = "PREV_LICENSE_EXP";
            public const string FIRST_THEORY_CLASSES = "FIRST_THEORY_CLASSES";
            public const string FIRST_PRACTICAL_CLASSES = "FIRST_PRACTICAL_CLASSES";
            public const string NEXT_THEORY_CLASSES = "NEXT_THEORY_CLASSES";
            public const string NEXT_PRACTICAL_CLASSES = "NEXT_PRACTICAL_CLASSES";
            //Added by Fahim Nasir on 20-9-2017
            public const string NEXT_PRACTICAL_CLASSES_ASSESSMENT_FAIL = "NEXT_PRACTICAL_CLASSES_INTERNAL_ASSESSMENT_FAILURE";
            public const string NEXT_PRACTICAL_CLASSES_ROAD_TEST_FAIL = "NEXT_PRACTICAL_CLASSES_ROAD_TEST_FAILURE";
            //====================================
            public const string CREATED_ON = "CREATED_ON";
            public const string CREATED_BY = "CREATED_BY";
            public const string UPDATED_ON = "UPDATED_ON";
            public const string UPDATED_BY = "UPDATED_BY";

        }
        public static class ServiceRatePayments
        {
            public const string TABLE_NAME = "SERVICE_RATE_PAYMENTS";
            public const string ID = "ID";
            public const string SERVICE_RATE_ID = "SERVICE_RATE_ID";
            public const string PAYMENT_CATEGORY_ID = "PAYMENT_CATEGORY_ID";
            public const string AMOUNT = "AMOUNT";
            public const string RTA_AMOUNT = "RTA_AMOUNT";
            public const string DHA_AMOUNT = "DHA_AMOUNT";
            public const string E_DIRHAM_AMOUNT = "E_DIRHAM_AMOUNT";
            public const string CREATED_ON = "CREATED_ON";
            public const string CREATED_BY = "CREATED_BY";
            public const string UPDATED_ON = "UPDATED_ON";
            public const string UPDATED_BY = "UPDATED_BY";
            // Added by Muhammad Uzair on 16/02/2018 16:33:02 
            public const string ETDI_WITH_VAT = "ETDI_WITH_VAT";
            // Added by Muhammad Uzair on 21/02/2018 11:12:12 
            public const string RTA_WITH_VAT = "RTA_WITH_VAT";
        }
        public static class PaymentCategories
        {
            public const string TABLE_NAME = "PAYMENT_CATEGORIES";
            public const string NAME_EN = "NAME_EN";
            public const string NAME_AR = "NAME_AR";
            public const String ID = "ID";

        }
        public static class Instructor
        {
            public const string TABLE_NAME = "INSTRUCTOR";

            public const string ID = "ID";

            public const string EMPLOYEE_ID = "EMPLOYEE_ID";
            public const string EMIRATES_ID_EXPIRY_DATE = "EMIRATES_ID_EXPIRY_DATE";
            public const string COUNTRY_ID = "COUNTRY_ID";
            public const string NATIONALITY = "NATIONALITY";
            public const string DOB = "DOB";
            public const string GENDER = "GENDER";
            public const string UNIFIED_NO = "UNIFIED_NO";
            public const string CENTER_ID = "CENTER_ID";
            public const string CENTER = "CENTER";
            public const string EMAIL = "EMAIL";
            public const string BRANCH_ID = "BRANCH_ID";
            public const string BRANCH = "BRANCH";
            public const string IS_INSTRUCTOR = "IS_INSTRUCTOR";
            public const string PHONE = "PHONE";

            public const string PASSPORT_NUMBER = "PASSPORT_NUMBER";
            public const string ISSUE_DATE = "ISSUE_DATE";
            public const string PASSPORT_EXPIRY_DATE = "PASSPORT_EXPIRY_DATE";
            public const string TRACKING_NUMBER = "TRACKING_NUMBER";
            public const string BOOKLET_NUMBER = "BOOKLET_NUMBER";

            public const string UID_NO = "UID_NO";
            public const string VISA_FILE_NO = "VISA_FILE_NO";
            public const string VISA_ISSUE_DATE = "VISA_ISSUE_DATE";
            public const string VISA_EXPIRY_DATE = "VISA_EXPIRY_DATE";

            public const string PLACE_OF_ISSUE_EN = "PLACE_OF_ISSUE_EN";
            public const string PLACE_OF_ISSUE_AR = "PLACE_OF_ISSUE_AR";
            public const string ACCOMPANIED_BY_EN = "ACCOMPANIED_BY_EN";
            public const string ACCOMPANIED_BY_AR = "ACCOMPANIED_BY_AR";
            public const string VISA_NAME_EN = "VISA_NAME_EN";
            public const string VISA_NAME_AR = "VISA_NAME_AR";
            public const string PROFESSION_EN = "PROFESSION_EN";
            public const string PROFESSION_AR = "PROFESSION_AR";
            public const string SPONSER_EN = "SPONSER_EN";
            public const string SPONSER_AR = "SPONSER_AR";

            public const string FIRST_NAME_EN = "FIRST_NAME_EN";
            public const string FIRST_NAME_AR = "FIRST_NAME_AR";
            public const string LAST_NAME_EN = "LAST_NAME_EN";
            public const string LAST_NAME_AR = "LAST_NAME_AR";
            public const string FATHER_NAME_EN = "FATHER_NAME_EN";
            public const string FATHER_NAME_AR = "FATHER_NAME_AR";
            public const string ADDRESS_EN = "ADDRESS_EN";
            public const string ADDRESS_AR = "ADDRESS_AR";

            public const string PERMIT_NO = "PERMIT_NO";
            public const string EMIRATES_ID_NUMBER = "EMIRATES_ID_NUMBER";
            public const string FAX = "FAX";
            public const string PO_BOX = "PO_BOX";
            public const string EMIRATE_ID = "EMIRATE_ID";
            public const string MOBILE = "MOBILE";
            public const string LANGUAGE_ID = "LANGUAGE_ID";
            public const string LANGUAGE = "LANGUAGE";
            public const string CREATED_BY = "CREATED_BY";
            public const string CREATED_ON = "CREATED_ON";
            public const string INSTRUCTOR_CONTRACT_TYPE_ID = "INSTRUCTOR_CONTRACT_TYPE_ID";
            public const string EMPLOYEE_TYPE_ID = "EMPLOYEE_TYPE_ID";
            public const string VEHICLE_TYPE_ID = "VEHICLE_TYPE_ID";

            public const string SERVICE_TYPE_ID = "SERVICE_TYPE_ID";
            public const string SERVICE_SHIFT_ID = "SERVICE_SHIFT_ID";
            public const string IMPORTED = "IMPORTED";
            public const string UPDATED_BY = "UPDATED_BY";
            public const string UPDATED_ON = "UPDATED_ON";

            public const string IMAGE = "IMAGE";
            public const string PASSPORT_COUNTRY_ID = "PASSPORT_COUNTRY_ID";
            public const string VISA_EMIRATES_ID = "VISA_EMIRATES_ID";

            //Added by Hassaan 13/06/2017
            public const string IS_LECTURER = "IS_LECTURER";

            //remove later
            public const string CONTRACT_TYPE_ID = "CONTRACT_TYPE_ID";

            // AVANZA\muhammad.awais - 23/08/2017 22:46:43
            public const string INSTRUCTOR_PERMIT_ISSUE_DATE = "INSTRUCTOR_PERMIT_ISSUE_DATE";
            public const string INSTRUCTOR_PERMIT_EXPIRY_DATE = "INSTRUCTOR_PERMIT_EXPIRY_DATE";
            public const string LECTURER_PERMIT_ISSUE_DATE = "LECTURER_PERMIT_ISSUE_DATE";
            public const string LECTURER_PERMIT_EXPIRY_DATE = "LECTURER_PERMIT_EXPIRY_DATE";
            public const string LECTURER_PERMIT_NO = "LECTURER_PERMIT_NO";


            public static DataTable GetDataTable()
            {
                DataTable dt = new DataTable(TABLE_NAME);

                dt.Columns.Add(ID, typeof(int));

                dt.Columns.Add(EMPLOYEE_ID, typeof(string));
                dt.Columns.Add(PERMIT_NO, typeof(string));
                dt.Columns.Add(EMIRATES_ID_NUMBER, typeof(string));
                dt.Columns.Add(EMIRATES_ID_EXPIRY_DATE, typeof(DateTime));

                dt.Columns.Add(FIRST_NAME_EN, typeof(string));
                dt.Columns.Add(FIRST_NAME_AR, typeof(string));
                dt.Columns.Add(LAST_NAME_EN, typeof(string));
                dt.Columns.Add(LAST_NAME_AR, typeof(string));
                dt.Columns.Add(FATHER_NAME_EN, typeof(string));
                dt.Columns.Add(FATHER_NAME_AR, typeof(string));
                dt.Columns.Add(ADDRESS_EN, typeof(string));
                dt.Columns.Add(ADDRESS_AR, typeof(string));
                dt.Columns.Add(EMIRATE_ID, typeof(int));
                dt.Columns.Add(INSTRUCTOR_CONTRACT_TYPE_ID, typeof(int));

                dt.Columns.Add(VEHICLE_TYPE_ID, typeof(int));
                dt.Columns.Add(EMPLOYEE_TYPE_ID, typeof(int));
                dt.Columns.Add(DOB, typeof(DateTime));
                dt.Columns.Add(UNIFIED_NO, typeof(string));
                dt.Columns.Add(GENDER, typeof(string));
                dt.Columns.Add(EMAIL, typeof(string));
                dt.Columns.Add(CENTER_ID, typeof(int));
                dt.Columns.Add(CENTER, typeof(string));
                dt.Columns.Add(BRANCH_ID, typeof(int));
                dt.Columns.Add(BRANCH, typeof(string));
                dt.Columns.Add(IS_INSTRUCTOR, typeof(bool));
                dt.Columns.Add(MOBILE, typeof(string));
                dt.Columns.Add(LANGUAGE_ID, typeof(int));
                dt.Columns.Add(LANGUAGE, typeof(string));
                dt.Columns.Add(PHONE, typeof(string));
                dt.Columns.Add(PO_BOX, typeof(string));
                dt.Columns.Add(FAX, typeof(string));
                //passport
                dt.Columns.Add(COUNTRY_ID, typeof(int));
                dt.Columns.Add(PASSPORT_NUMBER, typeof(string));
                dt.Columns.Add(ISSUE_DATE, typeof(DateTime));
                dt.Columns.Add(PASSPORT_EXPIRY_DATE, typeof(DateTime));
                dt.Columns.Add(BOOKLET_NUMBER, typeof(string));
                dt.Columns.Add(TRACKING_NUMBER, typeof(string));
                //visa
                dt.Columns.Add(UID_NO, typeof(string));
                dt.Columns.Add(VISA_FILE_NO, typeof(string));
                dt.Columns.Add(VISA_ISSUE_DATE, typeof(DateTime));
                dt.Columns.Add(VISA_EXPIRY_DATE, typeof(DateTime));
                dt.Columns.Add(PLACE_OF_ISSUE_EN, typeof(string));
                dt.Columns.Add(PLACE_OF_ISSUE_AR, typeof(string));
                dt.Columns.Add(ACCOMPANIED_BY_EN, typeof(string));
                dt.Columns.Add(ACCOMPANIED_BY_AR, typeof(string));
                dt.Columns.Add(VISA_NAME_EN, typeof(string));
                dt.Columns.Add(VISA_NAME_AR, typeof(string));
                dt.Columns.Add(PROFESSION_EN, typeof(string));
                dt.Columns.Add(PROFESSION_AR, typeof(string));
                dt.Columns.Add(SPONSER_EN, typeof(string));
                dt.Columns.Add(SPONSER_AR, typeof(string));

                dt.Columns.Add(SERVICE_TYPE_ID, typeof(int));
                dt.Columns.Add(SERVICE_SHIFT_ID, typeof(int));
                dt.Columns.Add(IMPORTED, typeof(int));


                dt.Columns.Add(CREATED_ON, typeof(DateTime));
                dt.Columns.Add(CREATED_BY, typeof(string));
                dt.Columns.Add(UPDATED_ON, typeof(DateTime));
                dt.Columns.Add(UPDATED_BY, typeof(string));

                //Changed by Hassaan as asked by Tariq Khan - save image as base64string in Database
                //dt.Columns.Add(IMAGE, typeof(byte[]));
                dt.Columns.Add(IMAGE, typeof(string));

                dt.Columns.Add(PASSPORT_COUNTRY_ID, typeof(int));
                dt.Columns.Add(VISA_EMIRATES_ID, typeof(int));
                //remove later
                dt.Columns.Add(CONTRACT_TYPE_ID, typeof(int));

                dt.Columns.Add(IS_LECTURER, typeof(bool));

                // AVANZA\muhammad.awais - 23/08/2017 22:44:53
                dt.Columns.Add(INSTRUCTOR_PERMIT_ISSUE_DATE, typeof(DateTime));
                dt.Columns.Add(INSTRUCTOR_PERMIT_EXPIRY_DATE, typeof(DateTime));
                dt.Columns.Add(LECTURER_PERMIT_EXPIRY_DATE, typeof(DateTime));
                dt.Columns.Add(LECTURER_PERMIT_ISSUE_DATE, typeof(DateTime));
                dt.Columns.Add(LECTURER_PERMIT_NO, typeof(string));

                return dt;
            }
        }
        public static class Instructor_Language
        {
            public const string TABLE_NAME = "INSTRUCTOR_LANGUAGE";

            public const string ID = "ID";

            public const string INSTRUCTOR_ID = "INSTRUCTOR_ID";
            public const string LANGUAGE_ID = "LANGUAGE_ID";
            public const string CREATED_BY = "CREATED_BY";
            public const string CREATED_ON = "CREATED_ON";
            public const string UPDATED_BY = "UPDATED_BY";
            public const string UPDATED_ON = "UPDATED_ON";

            public static DataTable GetDataTable()
            {
                DataTable dt = new DataTable(TABLE_NAME);

                dt.Columns.Add(ID, typeof(int));

                dt.Columns.Add(INSTRUCTOR_ID, typeof(int));
                dt.Columns.Add(LANGUAGE_ID, typeof(int));

                dt.Columns.Add(CREATED_ON, typeof(DateTime));
                dt.Columns.Add(CREATED_BY, typeof(string));
                dt.Columns.Add(UPDATED_ON, typeof(DateTime));
                dt.Columns.Add(UPDATED_BY, typeof(string));

                return dt;
            }
        }
        public static class Instructor_Services
        {
            public const string TABLE_NAME = "INSTRUCTOR_SERVICES";

            public const string ID = "ID";

            public const string INSTRUCTOR_ID = "INSTRUCTOR_ID";
            public const string SUB_SERVICE_ID = "SUB_SERVICE_ID";
            public const string CREATED_BY = "CREATED_BY";
            public const string CREATED_ON = "CREATED_ON";
            public const string UPDATED_BY = "UPDATED_BY";
            public const string UPDATED_ON = "UPDATED_ON";

            public static DataTable GetDataTable()
            {
                DataTable dt = new DataTable(TABLE_NAME);

                dt.Columns.Add(ID, typeof(int));

                dt.Columns.Add(INSTRUCTOR_ID, typeof(int));
                dt.Columns.Add(SUB_SERVICE_ID, typeof(int));

                dt.Columns.Add(CREATED_ON, typeof(DateTime));
                dt.Columns.Add(CREATED_BY, typeof(string));
                dt.Columns.Add(UPDATED_ON, typeof(DateTime));
                dt.Columns.Add(UPDATED_BY, typeof(string));

                return dt;
            }
        }
        public static class Instructor_Service_Type
        {
            public const string TABLE_NAME = "INSTRUCTOR_SERVICE_TYPE";

            public const string ID = "ID";

            public const string INSTRUCTOR_ID = "INSTRUCTOR_ID";
            public const string SERVICE_RATE_CARD_CATEGORY_ID = "SERVICE_RATE_CARD_CATEGORY_ID";
            public const string CREATED_BY = "CREATED_BY";
            public const string CREATED_ON = "CREATED_ON";
            public const string UPDATED_BY = "UPDATED_BY";
            public const string UPDATED_ON = "UPDATED_ON";

            public static DataTable GetDataTable()
            {
                DataTable dt = new DataTable(TABLE_NAME);

                dt.Columns.Add(ID, typeof(int));

                dt.Columns.Add(INSTRUCTOR_ID, typeof(int));
                dt.Columns.Add(SERVICE_RATE_CARD_CATEGORY_ID, typeof(int));

                dt.Columns.Add(CREATED_ON, typeof(DateTime));
                dt.Columns.Add(CREATED_BY, typeof(string));
                dt.Columns.Add(UPDATED_ON, typeof(DateTime));
                dt.Columns.Add(UPDATED_BY, typeof(string));

                return dt;
            }
        }
        public static class Instructor_Availibility
        {
            public const string TABLE_NAME = "INSTRUCTOR_AVAILIBILITY";

            public const string ID = "ID";
            public const string INSTRUCTOR_ID = "INSTRUCTOR_ID";
            public const string WEEKDAY_ID = "WEEKDAY_ID";
            public const string IS_AVAILABLE = "IS_AVAILABLE";
            public const string CREATED_BY = "CREATED_BY";
            public const string CREATED_ON = "CREATED_ON";
            public const string UPDATED_BY = "UPDATED_BY";
            public const string UPDATED_ON = "UPDATED_ON";

            public static DataTable GetDataTable()
            {
                DataTable dt = new DataTable(TABLE_NAME);

                dt.Columns.Add(ID, typeof(int));
                dt.Columns.Add(INSTRUCTOR_ID, typeof(int));
                dt.Columns.Add(WEEKDAY_ID, typeof(int));
                dt.Columns.Add(IS_AVAILABLE, typeof(bool));

                dt.Columns.Add(CREATED_ON, typeof(DateTime));
                dt.Columns.Add(CREATED_BY, typeof(string));
                dt.Columns.Add(UPDATED_ON, typeof(DateTime));
                dt.Columns.Add(UPDATED_BY, typeof(string));

                return dt;
            }
        }
        public class SP_USP_SearchInstructor
        {
            public const string SP_NAME = "usp_SearchInstructors";
            public const string ERROR_MESSAGE = "ERROR_MESSAGE";
            public SP_USP_SearchInstructor(string orderBy, int pageToRetrieve, int recordsPerPage, string whereClause)
            {

                this.orderBy.ParamValue = orderBy;
                list.Add(this.orderBy);

                this.recordsPerPage.ParamValue = recordsPerPage.ToString();
                list.Add(this.recordsPerPage);

                this.pageToRetrieve.ParamValue = pageToRetrieve.ToString();
                list.Add(this.pageToRetrieve);


                this.whereClause.ParamValue = whereClause.ToString();
                list.Add(this.whereClause);

            }
            //private List<StoredProcedureParams> list = new List<StoredProcedureParams>();
            //public List<StoredProcedureParams> ParamsList { get { return this.list; } }
            //public StoredProcedureParams orderBy = new StoredProcedureParams("@ORDER_BY", DbType.String);
            //public StoredProcedureParams recordsPerPage = new StoredProcedureParams("@RECPERPAGE", DbType.Int16);
            //public StoredProcedureParams pageToRetrieve = new StoredProcedureParams("@CURRENTPAGE", DbType.Int16);
            //public StoredProcedureParams whereClause = new StoredProcedureParams("@WHERECLAUSE", DbType.String);

        }
        public static class UserRoles
        {
            public const string TABLE_NAME = "USER_ROLES";
            public const string USER_ROLES_ID = "USER_ROLES_ID";
            public const string ROLE_ID = "ROLE_ID";
            public const string USER_ID = "USER_ID";

        }
        public static class Roles
        {
            public const string TABLE_NAME = "ROLES";
            public const string ROLE_ID = "ROLE_ID";
            public const string NAME_EN = "NAME_EN";
            public const string NAME_AR = "NAME_AR";
            public const string DESCRIPTION = "DESCRIPTION";
            public const string CREATED_BY = "CREATED_BY";
            public const string CREATED_ON = "CREATED_ON";
            public const string UPDATED_BY = "UPDATED_BY";
            public const string UPDATED_ON = "UPDATED_ON";

            public static DataTable GetDataTable()
            {
                DataTable dt = new DataTable(TABLE_NAME);
                dt.Columns.Add(ROLE_ID, typeof(Int64));
                dt.Columns.Add(NAME_EN, typeof(String));
                dt.Columns.Add(NAME_AR, typeof(String));
                dt.Columns.Add(DESCRIPTION, typeof(String));
                dt.Columns.Add(CREATED_BY, typeof(String));
                dt.Columns.Add(CREATED_ON, typeof(DateTime));
                dt.Columns.Add(UPDATED_BY, typeof(String));
                dt.Columns.Add(UPDATED_ON, typeof(DateTime));
                return dt;
            }

        }
        public static class RolePermissions
        {
            public const string TABLE_NAME = "ROLE_PERMISSIONS";
            public const string ROLE_PERM_ID = "ROLE_PERM_ID";
            public const string PERMISSION_ID = "PERMISSION_ID";
            public const string CREATED_ON = "CREATED_ON";
            public const string CREATED_BY = "CREATED_BY";
            public const string ROLE_ID = "ROLE_ID";

        }
        public static class Permissions
        {
            public const string TABLE_NAME = "PERMISSIONS";
            public const string PERMISSION_ID = "PERMISSION_ID";

            public const string PERM_NAME_EN = "PERM_NAME_EN";
            public const string PERM_NAME_AR = "PERM_NAME_AR";
            public const string DESCRIPTION = "DESCRIPTION";
            public const string APP_ID = "APP_ID";
            public const string PARENT_PERMISSION_ID = "PARENT_PERMISSION_ID";
            public const string URL = "URL";
            public const string MENU_SEQ = "MENU_SEQ";
            public const string SUB_MENU_SEQ = "SUB_MENU_SEQ";

            public const string IS_PRESENT = "IS_PRESENT";
            public const string IS_ACTIVE = "IS_ACTIVE";
            public const string ICON_NAME = "IconName";

            public static DataTable GetDataTable()
            {
                DataTable dt = new DataTable(TABLE_NAME);

                dt.Columns.Add(PERMISSION_ID, typeof(String));
                dt.Columns.Add(PERM_NAME_EN, typeof(String));
                dt.Columns.Add(PERM_NAME_AR, typeof(String));
                dt.Columns.Add(DESCRIPTION, typeof(String));
                dt.Columns.Add(APP_ID, typeof(String));
                dt.Columns.Add(PARENT_PERMISSION_ID, typeof(String));
                dt.Columns.Add(URL, typeof(String));
                dt.Columns.Add(MENU_SEQ, typeof(DateTime));
                dt.Columns.Add(SUB_MENU_SEQ, typeof(DateTime));

                dt.Columns.Add(IS_PRESENT, typeof(String));
                dt.Columns.Add(IS_ACTIVE, typeof(bool));
                return dt;
            }

        }
        public static class CultureResources
        {
            public const string TABLE_NAME = "CULTURE_RESOURCES";
            public const string ID = "RES_ID";
            //User for multilingual file upload to differentiate b/w different types of files
            public const string TYPE = "TYPE";
            public const string TEMP_ID = "TEMP_ID";
            public const string RES_EN = "RES_EN";
            public const string RES_AR = "RES_AR";
            public const string RES_UR = "RES_UR";
            public const string EN_X_PART = "EN_X_PART";
            public const string AR_X_PART = "AR_X_PART";
            public const string UR_X_PART = "UR_X_PART";
            public const string EN_Y_PART = "EN_Y_PART";
            public const string AR_Y_PART = "AR_Y_PART";
            public const string UR_Y_PART = "UR_Y_PART";
            public const string IS_NEW = "IS_NEW";
            public const string IS_ADDING = "IS_ADDING";
            public const string IS_DELETED = "IS_DELETED";
            public const string IS_EDITING = "IS_EDITING";

            public static DataTable GetDataTable()
            {
                DataTable dt = new DataTable(TABLE_NAME);
                dt.Columns.Add(ID, typeof(Int64));
                dt.Columns.Add(TYPE, typeof(String));
                dt.Columns.Add(TEMP_ID, typeof(String));
                dt.Columns.Add(RES_EN, typeof(String));
                dt.Columns.Add(RES_AR, typeof(String));
                dt.Columns.Add(RES_UR, typeof(String));
                dt.Columns.Add(EN_X_PART, typeof(int));
                dt.Columns.Add(EN_Y_PART, typeof(int));
                dt.Columns.Add(AR_X_PART, typeof(int));
                dt.Columns.Add(AR_Y_PART, typeof(int));
                dt.Columns.Add(UR_X_PART, typeof(int));
                dt.Columns.Add(UR_Y_PART, typeof(int));
                DataColumn isNewCol = new DataColumn();
                isNewCol.DefaultValue = "1";
                isNewCol.ColumnName = IS_NEW;
                isNewCol.AllowDBNull = true;
                dt.Columns.Add(isNewCol);

                DataColumn isDelCol = new DataColumn();
                isDelCol.DefaultValue = "0";
                isDelCol.ColumnName = IS_DELETED;
                isDelCol.AllowDBNull = true;
                dt.Columns.Add(isDelCol);

                DataColumn isAddingCol = new DataColumn();
                isAddingCol.DefaultValue = "0";
                isAddingCol.ColumnName = IS_ADDING;
                dt.Columns.Add(isAddingCol);

                DataColumn isEditCol = new DataColumn();
                isEditCol.DefaultValue = "0";
                isEditCol.ColumnName = IS_EDITING;
                dt.Columns.Add(isEditCol);

                return dt;
            }
        }
        public static class TestTemplate
        {
            public const string TABLE_NAME = "TEST_TEMPLATE";
            public const string ID = "ID";
            public const string GENERAL_INSTRUCTIONS = "GENERAL_INSTRUCTIONS";
            public const string EXAM_INFO = "EXAM_INFO";
            public const string EXAM_INFO_PLACE_HOLDER = "EXAM_INFO_PLACE_HOLDER";
            public const string CREATED_BY = "CREATED_BY";
            public const string CREATED_ON = "CREATED_ON";
            public const string IS_ACTIVE = "IS_ACTIVE";
            public const string APPROVED_BY = "APPROVED_BY";
            public const string APPROVED_ON = "APPROVED_ON";
            public const string NO_OF_QUESTIONS = "NO_OF_QUESTIONS";
            public const string PASSING_SCORE = "PASSING_SCORE";
            public const string IS_PERCENTAGE = "IS_PERCENTAGE";
            public const string DURATION = "DURATION";
            public const string PASSING_CHANGE_REASON = "PASSING_CHANGE_REASON";
            public const string CULTURE_NAME = "CULTURE_NAME";
            public const char DEFAULT_IS_ACTIVE = '1';
            public const char DEFAULT_IS_PERCENTAGE = '1';
            public const string NAME_EN = "NAME_EN";
            public const string NAME_AR = "NAME_AR";

            public static DataTable GetDataTable()
            {
                DataTable dt = new DataTable(TABLE_NAME);
                dt.Columns.Add(GENERAL_INSTRUCTIONS, typeof(string));
                dt.Columns.Add(EXAM_INFO, typeof(string));
                dt.Columns.Add(CREATED_BY, typeof(string));
                dt.Columns.Add(CREATED_ON, typeof(DateTime));
                dt.Columns.Add(DURATION, typeof(Int32));
                dt.Columns.Add(ID, typeof(Int64));
                dt.Columns.Add(IS_PERCENTAGE, typeof(char));
                dt.Columns.Add(NO_OF_QUESTIONS, typeof(int));
                dt.Columns.Add(PASSING_CHANGE_REASON, typeof(string));
                dt.Columns.Add(PASSING_SCORE, typeof(double));
                dt.Columns.Add(IS_ACTIVE, typeof(char));
                dt.Columns.Add(APPROVED_BY, typeof(String));
                dt.Columns.Add(APPROVED_ON, typeof(DateTime));
                dt.Columns.Add(CULTURE_NAME, typeof(int));
                dt.Columns.Add(NAME_EN, typeof(string));
                dt.Columns.Add(NAME_AR, typeof(string));
                dt.Columns.Add(EXAM_INFO_PLACE_HOLDER, typeof(string));

                return dt;
            }
            public static DataTable GetDataTableValueFromString(string concatenatedValues)
            {
                string[] values = concatenatedValues.Split('|');
                DataTable dt = GetDataTable();
                DataRow dr = dt.NewRow();
                dr[ID] = Convert.ToInt64(values[0]);
                dr[NAME_EN] = values[1];
                dr[NAME_AR] = values[2];
                dr[PASSING_SCORE] = Convert.ToDouble(values[3]);
                dr[NO_OF_QUESTIONS] = values[4];
                dt.Rows.Add(dr);
                return dt;
            }

        }
        public static class TestTemplateSectionWiseQuestions
        {
            public const string TABLE_NAME = "TT_SECTION_WISE_QUESTIONS";
            public const string ID = "ID";
            public const string TEST_ID = "TEST_ID";
            public const string SECTION_ID = "SECTION_ID";
            public const string QUESTIONS_NUM = "QUESTIONS_NUM";


            public static DataTable GetDataTable()
            {
                DataTable dt = new DataTable(TABLE_NAME);
                dt.Columns.Add(ID, typeof(Int64));
                dt.Columns.Add(QUESTIONS_NUM, typeof(int));
                dt.Columns.Add(SECTION_ID, typeof(Int64));
                dt.Columns.Add(TEST_ID, typeof(Int64));

                return dt;
            }

        }
        public static class QuestionSections
        {
            public const string TABLE_NAME = "QUESTION_SECTIONS";
            public const string ID = "ID";
            public const string DESCRIPTION = "DESCRIPTION";
            public const string CREATED_BY = "CREATED_BY";
            public const string CREATED_BY_EN = "CREATED_EN";
            public const string CREATED_BY_AR = "CREATED_AR";
            public const string CREATED_ON = "CREATED_ON";
            public const string SECTION_NAME = "SECTION_NAME";
            public const string SECTION_NAME_EN = "SECTION_NAME_EN";
            public const string SECTION_NAME_AR = "SECTION_NAME_AR";
            public const string SECTION_NAME_UR = "SECTION_NAME_UR";
            public const string TOTAL_ATTACHED_QUESTIONS = "TOTAL_ATTACHED_QUESTIONS";

            public static DataTable GetDataTable()
            {
                DataTable dt = new DataTable(TABLE_NAME);
                dt.Columns.Add(ID, typeof(Int64));
                dt.Columns.Add(DESCRIPTION, typeof(string));
                dt.Columns.Add(CREATED_BY, typeof(string));
                dt.Columns.Add(CREATED_BY_EN, typeof(string));
                dt.Columns.Add(CREATED_BY_AR, typeof(string));

                dt.Columns.Add(SECTION_NAME_EN, typeof(string));
                dt.Columns.Add(SECTION_NAME_AR, typeof(string));
                dt.Columns.Add(SECTION_NAME_UR, typeof(string));
                dt.Columns.Add(SECTION_NAME, typeof(Int64));
                dt.Columns.Add(TOTAL_ATTACHED_QUESTIONS, typeof(Int64));

                return dt;
            }
        }
        public static class VSearchExamTemplate
        {
            public const string VIEW_NAME = "VSEARCH_EXAM_TEMPLATES";
            public const string TEST_TEMP_ID = "TEST_TEMP_ID";
            public const string RES_EN = "RES_EN";
            public const string RES_AR = "RES_AR";
            public const string RES_UR = "RES_UR";
            public const string FULL_NAME_EN = "FULL_NAME_EN";
            public const string FULL_NAME_AR = "FULL_NAME_AR";
            public const string PASSING_SCORE = "PASSING_SCORE";
            public const string NO_OF_QUESTIONS = "NO_OF_QUESTIONS";
            public const string IS_ACTIVE = "IS_ACTIVE";
            public const string CREATED_ON = "CREATED_ON";
            public const string PASSING_CHANGE_REASON = "PASSING_CHANGE_REASON";
            public const string APPROVED_BY = "APPROVED_BY";
            public const string CREATED_BY = "CREATED_BY";
            public const string APPROVED_ON = "APPROVED_ON";
            public const string COLUMNS_CONCATE = "COLUMNS_CONCATE";
        }
        public static class Test
        {
            public const string TABLE_NAME = "TEST";
            public const string ID = "TEST_ID";
            public const string TEST_NUM = "TEST_NUM";
            public const string CREATED_BY = "CREATED_BY";
            public const string CREATED_ON = "CREATED_ON";
            public const string STATUS = "STATUS";
            public const string APPROVED_BY = "APPROVED_BY";
            public const string APPROVED_ON = "APPROVED_ON";
            public const string START_DATE = "START_DATE";
            public const string END_DATE = "END_DATE";
            public const string TEST_TEMP_ID = "TEST_TEMP_ID";
            public const string DURATION = "DURATION";
            public const string CONDUCTED_BY = "CONDUCTED_BY";
            public const string EXCEL_FILE_LOC = "EXCEL_FILE_LOC";
            public const string DRIVER_TYPE = "DRIVER_TYPE";
            public const string TRAINER = "TRAINER";
            public const string ROOM_ID = "ROOM_ID";
            public const string GRACE_PERIOD = "GRACE_PERIOD";
            //Used for sending xml of the excel file to storedProcedure SP_USP_ScheduleExams no column of this 
            //name exist in db
            public const string EXCEL_FILE_DATA = "EXCEL_FILE_DATA";



            public static DataTable GetDataTable()
            {
                DataTable dt = new DataTable(TABLE_NAME);
                dt.Columns.Add(ID, typeof(Int64));
                dt.Columns.Add(CREATED_BY, typeof(string));
                dt.Columns.Add(CREATED_ON, typeof(DateTime));
                dt.Columns.Add(DURATION, typeof(Int16));
                dt.Columns.Add(STATUS, typeof(Int16));
                dt.Columns.Add(APPROVED_BY, typeof(String));
                dt.Columns.Add(APPROVED_ON, typeof(DateTime));
                dt.Columns.Add(START_DATE, typeof(DateTime));
                dt.Columns.Add(END_DATE, typeof(DateTime));
                dt.Columns.Add(TEST_TEMP_ID, typeof(Int64));
                dt.Columns.Add(ROOM_ID, typeof(Int32));
                dt.Columns.Add(CONDUCTED_BY, typeof(string));
                dt.Columns.Add(EXCEL_FILE_LOC, typeof(string));
                dt.Columns.Add(DRIVER_TYPE, typeof(Int16));
                dt.Columns.Add(TRAINER, typeof(string));
                dt.Columns.Add(GRACE_PERIOD, typeof(Int16));
                dt.Columns.Add(EXCEL_FILE_DATA, typeof(String));
                return dt;
            }
        }

        public static class Persons
        {
            public const string TABLE_NAME = "PERSONS";
            public const string PERSON_ID = "PERSON_ID";
            public const string PASSPORT_NUM = "PASSPORT_NUM";
            public const string LICENSE_NUM = "LICENSE_NUM";
            public const string CELL_NUM = "CELL_NUM";
            public const string PRIMARY_LANDLINE_NUM = "PRIMARY_LANDLINE_NUM";
            public const string SEC_LANDLINE_NUM = "SEC_LANDLINE_NUM";
            public const string CREATED_BY = "CREATED_BY";
            public const string CREATED_ON = "CREATED_ON";
            public const string NATIONALITY = "NATIONALITY";
            public const string FILE_NUM = "FILE_NUM";
            public const string DRIVER_ID_NUM = "DRIVER_ID_NUM";
            public const string NAME = "NAME";
            public const string FRANCHISE = "FRANCHISE";
            public const string IMAGE_LOC = "IMAGE_LOC";
            public const string FQN_IMAGE_LOC = "FQN_IMAGE_LOC";
            public const string JOIN_YEAR = "JOIN_YEAR";
            public const string DATE_OF_BIRTH = "DATE_OF_BIRTH";
            public const string TAXI_PERMIT_DATE = "TAXI_PERMIT_DATE";
            public const string TAXI_PERMIT_EXPIRY_DATE = "TAXI_PERMIT_EXPIRY_DATE";

            public static DataTable GetDataTable()
            {
                DataTable dt = new DataTable(TABLE_NAME);
                dt.Columns.Add(PERSON_ID, typeof(Int64));
                dt.Columns.Add(JOIN_YEAR, typeof(int));
                dt.Columns.Add(TAXI_PERMIT_DATE, typeof(DateTime));
                dt.Columns.Add(TAXI_PERMIT_EXPIRY_DATE, typeof(DateTime));
                dt.Columns.Add(NAME, typeof(string));
                dt.Columns.Add(FRANCHISE, typeof(string));
                dt.Columns.Add(PASSPORT_NUM, typeof(string));
                dt.Columns.Add(LICENSE_NUM, typeof(string));
                dt.Columns.Add(CELL_NUM, typeof(string));
                dt.Columns.Add(PRIMARY_LANDLINE_NUM, typeof(string));
                dt.Columns.Add(SEC_LANDLINE_NUM, typeof(string));
                dt.Columns.Add(CREATED_BY, typeof(string));
                dt.Columns.Add(CREATED_ON, typeof(DateTime));
                dt.Columns.Add(NATIONALITY, typeof(string));
                dt.Columns.Add(DATE_OF_BIRTH, typeof(DateTime));
                dt.Columns.Add(FILE_NUM, typeof(string));
                dt.Columns.Add(DRIVER_ID_NUM, typeof(string));
                dt.Columns.Add(IMAGE_LOC, typeof(string));
                dt.Columns.Add(FQN_IMAGE_LOC, typeof(string));
                return dt;
            }
        }
        public static class TestTakers
        {
            public const string TABLE_NAME = "TEST_TAKERS";
            public const string ID = "ID";
            public const string PERSON_ID = "PERSON_ID";
            public const string TEST_ID = "TEST_ID";
            public const string QUESTIONS_ATTEMPTED = "QUESTIONS_ATTEMPTED";
            public const string CORRECT_ANS = "CORRECT_ANS";
            public const string STARTED_ON = "STARTED_ON";
            public const string COMPLETED_ON = "COMPLETED_ON";
            public const string STATUS = "STATUS";
            public const string TEST_XML = "TEST_XML";

        }
        public class SP_USP_ValidateScheduleExams
        {

            public const string SP_NAME = "usp_ValidateScheduleExams";
            public const string ERROR_MESSAGE = "ERROR_MESSAGE";
            public SP_USP_ValidateScheduleExams(string startDate, string endDate, string testId, string duration, string roomId, string trainer, string excelData)
            {

                this.startDate.ParamValue = startDate;
                list.Add(this.startDate);
                this.endDate.ParamValue = endDate;
                list.Add(this.endDate);
                this.testId.ParamValue = testId;
                list.Add(this.testId);
                this.duration.ParamValue = duration;
                list.Add(this.duration);
                this.roomId.ParamValue = roomId;
                list.Add(this.roomId);
                this.trainer.ParamValue = trainer;
                list.Add(this.trainer);
                this.excelData.ParamValue = excelData;
                list.Add(this.excelData);
            }
            private List<StoredProcedureParams> list = new List<StoredProcedureParams>();
            public List<StoredProcedureParams> ParamsList { get { return this.list; } }


            public StoredProcedureParams startDate = new StoredProcedureParams("@START_DATE", DbType.DateTime);
            public StoredProcedureParams endDate = new StoredProcedureParams("@END_DATE", DbType.DateTime);
            public StoredProcedureParams testId = new StoredProcedureParams("@TEST_ID", DbType.Int64);
            public StoredProcedureParams duration = new StoredProcedureParams("@DURATION", DbType.Int16);
            public StoredProcedureParams roomId = new StoredProcedureParams("@TRAININGROOM", DbType.Int32);
            public StoredProcedureParams trainer = new StoredProcedureParams("@TRAINER", DbType.String);
            public StoredProcedureParams excelData = new StoredProcedureParams("@excelData", DbType.String);


        }
        public class SP_USP_ScheduleExams
        {

            public const string SP_NAME = "usp_ScheduleExams";
            public SP_USP_ScheduleExams(string sessionId, string tesetNum, string createdBy, Int16 status, DateTime startDate, DateTime endDate, Int64 testTempId,
                                        Int16 duration, string conductedBy, Int16 driverType, string trainer, Int16 gracePeriod, string excelData, Int32 roomId)
            {

                //this.conductedBy.ParamValue = conductedBy;
                //list.Add(this.conductedBy);
                this.createdBy.ParamValue = createdBy;
                list.Add(this.createdBy);
                this.driverType.ParamValue = driverType.ToString();
                list.Add(this.driverType);
                this.duration.ParamValue = duration.ToString();
                list.Add(this.duration);
                this.roomId.ParamValue = roomId.ToString();
                list.Add(this.roomId);
                this.excelData.ParamValue = excelData.ToString();
                list.Add(this.excelData);
                this.gracePeriod.ParamValue = gracePeriod.ToString();
                list.Add(this.gracePeriod);
                this.startDate.ParamValue = startDate.ToString("dd/MM/yyyy HH:mm:ss");
                list.Add(this.startDate);
                this.status.ParamValue = status.ToString();
                list.Add(this.status);
                this.testTempId.ParamValue = testTempId.ToString();
                list.Add(this.testTempId);
                this.trainer.ParamValue = trainer;
                list.Add(this.trainer);


            }
            public SP_USP_ScheduleExams(DataTable dtScheduleExam)
            {
                DataRow row = dtScheduleExam.Rows[0];
                //this.conductedBy.ParamValue = row[Test.CONDUCTED_BY].ToString();
                //list.Add(this.conductedBy);
                this.createdBy.ParamValue = row[Test.CREATED_BY].ToString();
                list.Add(this.createdBy);
                this.driverType.ParamValue = row[Test.DRIVER_TYPE].ToString();
                list.Add(this.driverType);
                this.duration.ParamValue = row[Test.DURATION].ToString();
                list.Add(this.duration);
                this.roomId.ParamValue = row[Test.ROOM_ID].ToString();
                list.Add(this.roomId);
                this.excelData.ParamValue = row[Test.EXCEL_FILE_DATA].ToString();
                list.Add(this.excelData);
                this.gracePeriod.ParamValue = row[Test.GRACE_PERIOD].ToString();
                list.Add(this.gracePeriod);
                this.startDate.ParamValue = row[Test.START_DATE].ToString();
                list.Add(this.startDate);
                this.status.ParamValue = row[Test.STATUS].ToString();
                list.Add(this.status);
                this.testTempId.ParamValue = row[Test.TEST_TEMP_ID].ToString();
                list.Add(this.testTempId);
                this.trainer.ParamValue = row[Test.TRAINER].ToString();
                list.Add(this.trainer);


            }
            private List<StoredProcedureParams> list = new List<StoredProcedureParams>();

            public List<StoredProcedureParams> ParamsList { get { return this.list; } }
            public StoredProcedureParams createdBy = new StoredProcedureParams("@CREATED_BY", DbType.String);
            public StoredProcedureParams status = new StoredProcedureParams("@STATUS", DbType.Int16);
            public StoredProcedureParams startDate = new StoredProcedureParams("@START_DATE", DbType.DateTime);
            public StoredProcedureParams roomId = new StoredProcedureParams("@TRAININGROOM", DbType.Int32);
            public StoredProcedureParams testTempId = new StoredProcedureParams("@TEST_TEMP_ID", DbType.Int64);
            public StoredProcedureParams duration = new StoredProcedureParams("@DURATION", DbType.Int16);
            //public StoredProcedureParams conductedBy = new StoredProcedureParams("@CONDUCTED_BY", DbType.String);
            public StoredProcedureParams driverType = new StoredProcedureParams("@DRIVER_TYPE", DbType.Int16);
            public StoredProcedureParams trainer = new StoredProcedureParams("@TRAINER", DbType.String);
            public StoredProcedureParams gracePeriod = new StoredProcedureParams("@GRACE_PERIOD", DbType.Int16);
            public StoredProcedureParams excelData = new StoredProcedureParams("@excelData ", DbType.Xml);

        }


        public static class VSearchTest
        {
            public const string VIEW_NAME = "VSEARCH_TEST";
            public const string TEST_ID = "TEST_ID";
            public const string TEST_NUM = "TEST_NUM";
            public const string CREATED_BY_EN = "CREATED_BY_EN";
            public const string CREATED_BY_AR = "CREATED_BY_AR";
            public const string TRAINER_EN = "TRAINER_EN";
            public const string TRAINER_AR = "TRAINER_AR";
            public const string TRAINER = "TRAINER";
            public const string DURATION = "DURATION";
            public const string START_DATE = "START_DATE";
            public const string CREATED_ON = "CREATED_ON";
            public const string GRACE_PERIOD = "GRACE_PERIOD";
            public const string END_DATE = "END_DATE";
            public const string CREATED_BY = "CREATED_BY";
            public const string STATUS = "STATUS";
            public const string STATUS_EN = "STATUS_EN";
            public const string STATUS_AR = "STATUS_AR";
            public const string TEST_TEMP_NAME_EN = "TEST_TEMP_NAME_EN";
            public const string TEST_TEMP_NAME_AR = "TEST_TEMP_NAME_AR";
            public const string TEST_TEMP_NAME_UR = "TEST_TEMP_NAME_UR";
            public const string PASSING_SCORE = "PASSING_SCORE";
            public const string NO_OF_QUESTIONS = "NO_OF_QUESTIONS";
            public const string DRIVER_TYPE = "DRIVER_TYPE";

        }

        public static class VSearchScheduledTestsByPersonId
        {
            public const string VIEW_NAME = "VSEARCH_SCHEDULED_TESTS_BY_PERSON_ID";
            public const string TTSTATUS = "TTSTATUS";
            public const string IS_TEST_ALLOWED = "IS_TEST_ALLOWED";
            public const string TEST_XML_FILE_NAME = "TEST_XML_FILE_NAME";

        }
        public static class QuestionsPool
        {
            public const string TABLE_NAME = "QUESTIONS_POOL";
            public const string ID = "QUESTION_ID";
            public const string TEMP_ID = "TEMP_ID";
            public const string XML_EN = "XML_EN";
            public const string IS_ACTIVE = "IS_ACTIVE";
            public const string MARKS = "MARKS";
            public const string CREATED_ON = "CREATED_ON";
            public const string APPROVED_ON = "APPROVED_ON";
            public const string IMAGE_LOC = "IMAGE_LOC";
            public const string AUDIO_LOC = "AUDIO_LOC";
            public const string CAPTION = "CAPTION";
            public const string CREATED_BY = "CREATED_BY";
            public const string CREATED_BY_EN = "CREATED_BY_EN";
            public const string CREATED_BY_AR = "CREATED_BY_AR";
            public const string APPROVED_BY = "APPROVED_BY";
            public const string APPROVED_BY_EN = "APPROVED_BY_EN";
            public const string APPROVED_BY_AR = "APPROVED_BY_AR";
            public const string SECTION_ID = "SECTION_ID";
            public const string QUESTION_TEXT = "QUESTION_TEXT";
            public const string CATEGORY_ONE = "CATEGORY_ONE";
            public const string CATEGORY_TWO = "CATEGORY_TWO";
            public const string TYPE_ID = "TYPE_ID";
            public const string Is_Vertical = "Is_Vertical";
            public const string QUESTION_NUM = "QUESTION_NUM";
            public const string STATUS = "STATUS";
            public const string STATUS_EN = "STATUS_EN";
            public const string STATUS_AR = "STATUS_AR";
            public const string FQN_IMAGE_LOC = "FQN_IMAGE_LOC";
            public const string FQN_AUDIO_LOC = "FQN_AUDIO_LOC";
            //Added by Fahim Nasir 23/10/2017 13:39:56
            public const string LANGUAGE_ID = "LANGUAGE_ID";
            public const string IS_MOCK = "IS_MOCK";
            public const string VEHICLE_TYPE_ID = "VEHICLE_TYPE_ID";
            public const string COURSE_ID = "COURSE_ID";
            public const string QUESTION_FOR = "QUESTION_FOR";
            //------------------------------------------
            public static DataTable GetDataTable()
            {
                DataTable dt = new DataTable(TABLE_NAME);
                dt.Columns.Add(ID, typeof(Int64));
                dt.Columns.Add(XML_EN, typeof(String));
                dt.Columns.Add(TEMP_ID, typeof(String));
                dt.Columns.Add(IS_ACTIVE, typeof(char));
                dt.Columns.Add(MARKS, typeof(Int16));
                dt.Columns.Add(CREATED_ON, typeof(DateTime));
                dt.Columns.Add(APPROVED_ON, typeof(DateTime));
                dt.Columns.Add(IMAGE_LOC, typeof(String));
                dt.Columns.Add(FQN_IMAGE_LOC, typeof(String));
                dt.Columns.Add(FQN_AUDIO_LOC, typeof(String));
                dt.Columns.Add(AUDIO_LOC, typeof(String));
                dt.Columns.Add(CREATED_BY, typeof(string));
                dt.Columns.Add(CREATED_BY_AR, typeof(string));
                dt.Columns.Add(CREATED_BY_EN, typeof(string));
                dt.Columns.Add(APPROVED_BY, typeof(string));
                dt.Columns.Add(APPROVED_BY_EN, typeof(string));
                dt.Columns.Add(APPROVED_BY_AR, typeof(string));
                dt.Columns.Add(SECTION_ID, typeof(Int64));
                dt.Columns.Add(QUESTION_TEXT, typeof(String));
                dt.Columns.Add(TYPE_ID, typeof(Int16));
                dt.Columns.Add(Is_Vertical, typeof(char));
                dt.Columns.Add(QUESTION_NUM, typeof(String));
                dt.Columns.Add(STATUS, typeof(Int16));
                dt.Columns.Add(STATUS_EN, typeof(String));
                dt.Columns.Add(STATUS_AR, typeof(String));
                dt.Columns.Add(CAPTION, typeof(String));
                dt.Columns.Add(CATEGORY_ONE, typeof(Int64));
                dt.Columns.Add(CATEGORY_TWO, typeof(Int64));
                //Added by Fahim Nasir 23/10/2017 13:42:11
                dt.Columns.Add(LANGUAGE_ID, typeof(Int64));
                dt.Columns.Add(IS_MOCK, typeof(Int32));
                dt.Columns.Add(VEHICLE_TYPE_ID, typeof(Int64));
                dt.Columns.Add(COURSE_ID, typeof(Int64));
                dt.Columns.Add(QUESTION_FOR, typeof(Int64));
                //========================================
                return dt;
            }
        }
        public static class AnswersPool
        {
            public const string TABLE_NAME = "ANSWERS_POOL";
            public const string IS_NEW = "IS_NEW";
            public const string IS_DELETED = "IS_DELETED";
            public const string IS_EDITING = "IS_EDITING";
            public const string IS_CHANGED = "IS_CHANGED";
            public const string ID = "ID";
            public const string IS_CORRECT = "IS_CORRECT";
            public const string IMAGE_LOC = "IMAGE_LOC";
            public const string MATCH_IMAGE_LOC = "MATCH_IMAGE_LOC";
            public const string CREATED_BY = "CREATED_BY";
            public const string CREATED_ON = "CREATED_ON";
            public const string QUESTION_ID = "QUESTION_ID";
            public const string ANSWER_TEXT = "ANSWER_TEXT";
            public const string ANSWER_EN = "ANSWER_EN";
            public const string ANSWER_AR = "ANSWER_AR";
            public const string POS_X = "POS_X";
            public const string POS_Y = "POS_Y";
            public const string CATEGORY_ID = "CATEGORY_ID";
            public const string TEMP_ID_FOR_IMAGE = "TEMP_ID_FOR_IMAGE";
            public const string IMAGE_LOC_QUESTION = "IMAGE_LOC_QUESTION";
            public const string FQN_IMAGE_LOC = "FQN_IMAGE_LOC";
            public const string FQN_MATCH_IMAGE_LOC = "FQN_MATCH_IMAGE_LOC";
            public static DataTable GetDataTable()
            {
                DataTable dt = new DataTable(TABLE_NAME);
                dt.Columns.Add(IS_NEW, typeof(String));
                DataColumn isChanged = new DataColumn();
                isChanged.DefaultValue = "0";
                isChanged.ColumnName = IS_CHANGED;
                isChanged.AllowDBNull = true;
                dt.Columns.Add(isChanged);
                dt.Columns.Add(IS_DELETED, typeof(String));
                dt.Columns.Add(IS_EDITING, typeof(String));
                dt.Columns.Add(ID, typeof(Int64));
                dt.Columns.Add(IS_CORRECT, typeof(String));
                dt.Columns.Add(IMAGE_LOC, typeof(String));
                dt.Columns.Add(MATCH_IMAGE_LOC, typeof(String));
                dt.Columns.Add(CREATED_BY, typeof(String));
                dt.Columns.Add(CREATED_ON, typeof(DateTime));
                dt.Columns.Add(QUESTION_ID, typeof(Int64));
                dt.Columns.Add(ANSWER_TEXT, typeof(Int64));
                dt.Columns.Add(ANSWER_EN, typeof(String));
                dt.Columns.Add(ANSWER_AR, typeof(String));
                dt.Columns.Add(POS_X, typeof(String));
                dt.Columns.Add(POS_Y, typeof(String));
                dt.Columns.Add(CATEGORY_ID, typeof(Int64));
                dt.Columns.Add(TEMP_ID_FOR_IMAGE, typeof(String));
                dt.Columns.Add(IMAGE_LOC_QUESTION, typeof(String));
                dt.Columns.Add(FQN_IMAGE_LOC, typeof(String));
                dt.Columns.Add(FQN_MATCH_IMAGE_LOC, typeof(String));


                return dt;
            }


        }
        public static class QuestionCategory
        {
            public const string TABLE_NAME = "QUESTION_CATEGORY";
            public const string CATEGORY_ID = "CATEGORY_ID";
            public const string QUESTION_ID = "QUESTION_ID";
            public const string CATEGORY_NAME = "CATEGORY_NAME";

            public static DataTable GetDataTable()
            {
                DataTable dt = new DataTable(TABLE_NAME);
                dt.Columns.Add(CATEGORY_ID, typeof(Int64));
                dt.Columns.Add(QUESTION_ID, typeof(Int64));
                dt.Columns.Add(CATEGORY_NAME, typeof(String));

                return dt;
            }


        }
        public static class VSearchAnswersByTestTakerId
        {
            public const string VIEW_NAME = "VSEARCH_ANSWERS_BY_TEST_TAKER_ID";
            public const string TEST_TAKER_PK = "TEST_TAKER_PK";
            public const string TEST_TAKER_ID = "TEST_TAKER_ID";
            public const string IMAGE_MATCH_FORMAT = "IMAGE_MATCH_FORMAT";
            public const string CATEGORY_BASED_FORMAT = "CATEGORY_BASED_FORMAT";
        }
        public class SP_USP_CompileExamResult
        {

            public const string SP_NAME = "usp_CompileExamResult";
            public const string ERROR_MESSAGE = "ERROR_MESSAGE";
            public SP_USP_CompileExamResult(string testTakerId)
            {

                this.testTakerId.ParamValue = testTakerId;
                list.Add(this.testTakerId);
            }
            private List<StoredProcedureParams> list = new List<StoredProcedureParams>();
            public List<StoredProcedureParams> ParamsList { get { return this.list; } }
            public StoredProcedureParams testTakerId = new StoredProcedureParams("@TestTakerId", DbType.Int64);


        }


        public static class SystemConfiguration
        {
            public const string TABLE_NAME = "SYSTEM_CONFIGURATION";
            public const string SYS_KEY = "SYS_KEY";
            public const string VALUE = "VALUE";

        }

        public class SP_USP_SearchQuestions
        {
            public const string SP_NAME = "usp_SearchQuestions";
            public const string ERROR_MESSAGE = "ERROR_MESSAGE";
            public SP_USP_SearchQuestions(string orderBy, int pageToRetrieve, int recordsPerPage, string whereClause)
            {

                this.orderBy.ParamValue = orderBy;
                list.Add(this.orderBy);

                this.recordsPerPage.ParamValue = recordsPerPage.ToString();
                list.Add(this.recordsPerPage);

                this.pageToRetrieve.ParamValue = pageToRetrieve.ToString();
                list.Add(this.pageToRetrieve);


                this.whereClause.ParamValue = whereClause.ToString();
                list.Add(this.whereClause);

            }
            private List<StoredProcedureParams> list = new List<StoredProcedureParams>();
            public List<StoredProcedureParams> ParamsList { get { return this.list; } }
            public StoredProcedureParams orderBy = new StoredProcedureParams("@ORDER_BY", DbType.String);
            public StoredProcedureParams recordsPerPage = new StoredProcedureParams("@RECPERPAGE", DbType.Int16);
            public StoredProcedureParams pageToRetrieve = new StoredProcedureParams("@CURRENTPAGE", DbType.Int16);
            public StoredProcedureParams whereClause = new StoredProcedureParams("@WHERECLAUSE", DbType.String);


            public static string QUESTION_NUM = "QUESTION_NUM";
            public static string QUESTION_ID = "QUESTION_ID";
            public static string RES_EN = "RES_EN";
            public static string RES_AR = "RES_AR";
            public static string CREATED_ON = "CREATED_ON";
            public static string CREATED_BY = "CREATED_BY";
            public static string APPROVED_ON = "APPROVED_ON";
            public static string APPROVED_BY = "APPROVED_BY";
            public static string SECTION_ID = "SECTION_ID";
            public static string TYPE_ID = "TYPE_ID";
            public static string SECTION_NAME_AR = "SECTION_NAME_AR";
            public static string SECTION_NAME_EN = "SECTION_NAME_EN";
            public static string CREATED_BY_EN = "CREATED_BY_EN";
            public static string CREATED_BY_AR = "CREATED_BY_AR";
            public static string APPROVED_BY_EN = "APPROVED_BY_EN";
            public static string APPROVED_BY_AR = "APPROVED_BY_AR";
            public static string ANSWER_TYPE_AR = "ANSWER_TYPE_AR";
            public static string ANSWER_TYPE_EN = "ANSWER_TYPE_EN";
            public static string STATUS_AR = "STATUS_AR";
            public static string STATUS_EN = "STATUS_EN";
            public static string QUESTION_STATUS_ID = "QUESTION_STATUS_ID";
            public static string ANSWER_TYPE_ID = "ANSWER_TYPE_ID";
            public static string COLUMNS_CONCATE = "COLUMNS_CONCATE";

            public static DataTable GetGridFieldsDataTable()
            {

                DataTable dt = new DataTable(Entities.QuestionsPool.TABLE_NAME);
                dt.Columns.Add(QUESTION_NUM);
                dt.Columns.Add(QUESTION_ID);
                dt.Columns.Add(RES_EN);
                dt.Columns.Add(RES_AR);
                dt.Columns.Add(CREATED_BY);
                dt.Columns.Add(CREATED_BY_AR);
                dt.Columns.Add(CREATED_BY_EN);
                dt.Columns.Add(CREATED_ON);
                dt.Columns.Add(APPROVED_BY);
                dt.Columns.Add(APPROVED_BY_AR);
                dt.Columns.Add(APPROVED_BY_EN);
                dt.Columns.Add(APPROVED_ON);
                dt.Columns.Add(SECTION_ID);
                dt.Columns.Add(SECTION_NAME_AR);
                dt.Columns.Add(SECTION_NAME_EN);
                dt.Columns.Add(ANSWER_TYPE_ID);
                dt.Columns.Add(ANSWER_TYPE_AR);
                dt.Columns.Add(ANSWER_TYPE_EN);
                dt.Columns.Add(QUESTION_STATUS_ID);
                dt.Columns.Add(STATUS_EN);
                dt.Columns.Add(STATUS_AR);
                dt.Columns.Add(COLUMNS_CONCATE);
                return dt;
            }



        }
        public static class QuestionsStatus
        {
            public const string TABLE_NAME = "QUESTIONS_STATUS";
            public const string QUESTION_STATUS_ID = "QUESTION_STATUS_ID";
            public const string DESC_EN = "DESC_EN";
            public const string DESC_AR = "DESC_AR";


        }
        public static class AnswerType
        {
            public const string TABLE_NAME = "ANSWER_TYPES";
            public const string ID = "ID";
            public const string TYPE_EN = "TYPE_EN";
            public const string TYPE_AR = "TYPE_AR";
            public const string TYPE_UR = "TYPE_UR";
            public const string IS_SYSTEM = "IS_SYSTEM";
            public const string IS_ACTIVE = "IS_ACTIVE";





        }
        public class SP_USP_GetQuestionsById
        {

            public const string SP_NAME = "usp_GetQuestionsById";
            public const string ERROR_MESSAGE = "ERROR_MESSAGE";
            public SP_USP_GetQuestionsById(string questionId)
            {

                this.questionId.ParamValue = questionId;
                list.Add(this.questionId);


            }
            private List<StoredProcedureParams> list = new List<StoredProcedureParams>();
            public List<StoredProcedureParams> ParamsList { get { return this.list; } }
            public StoredProcedureParams questionId = new StoredProcedureParams("@QUESTION_ID", DbType.Int64);


        }

        public class SP_USP_GenerateSystemNumber
        {

            public const string SP_NAME = "usp_GenerateSystemNumber";
            public const string ERROR_MESSAGE = "ERROR_MESSAGE";
            public SP_USP_GenerateSystemNumber(string argument)
            {
                this.argument.ParamValue = argument;
                list.Add(this.argument);

            }
            private List<StoredProcedureParams> list = new List<StoredProcedureParams>();
            public List<StoredProcedureParams> ParamsList { get { return this.list; } }
            public StoredProcedureParams argument = new StoredProcedureParams("@Argument", DbType.String);


        }
        public class SP_USP_SearchPersons
        {

            public const string SP_NAME = "usp_SearchPersons";
            public const string ERROR_MESSAGE = "ERROR_MESSAGE";
            public SP_USP_SearchPersons(string orderBy, int pageToRetrieve, int recordsPerPage, string whereClause)
            {

                this.orderBy.ParamValue = orderBy;
                list.Add(this.orderBy);

                this.recordsPerPage.ParamValue = recordsPerPage.ToString();
                list.Add(this.recordsPerPage);

                this.pageToRetrieve.ParamValue = pageToRetrieve.ToString();
                list.Add(this.pageToRetrieve);


                this.whereClause.ParamValue = whereClause.ToString();
                list.Add(this.whereClause);

            }
            private List<StoredProcedureParams> list = new List<StoredProcedureParams>();
            public List<StoredProcedureParams> ParamsList { get { return this.list; } }
            public StoredProcedureParams orderBy = new StoredProcedureParams("@ORDER_BY", DbType.String);
            public StoredProcedureParams recordsPerPage = new StoredProcedureParams("@RECPERPAGE", DbType.Int16);
            public StoredProcedureParams pageToRetrieve = new StoredProcedureParams("@CURRENTPAGE", DbType.Int16);
            public StoredProcedureParams whereClause = new StoredProcedureParams("@WHERECLAUSE", DbType.String);
        }

        public static class TrainingSlide
        {
            public const string TABLE_NAME = "TRAINING_SLIDE";
            public const string IS_NEW = "IS_NEW";
            public const string TEMP_ID = "TEMP_ID";
            public const string SLIDE_ID = "SLIDE_ID";
            public const string SLIDE_NUM = "SLIDE_NUM";
            public const string SLIDE_TYPE = "SLIDE_TYPE";
            public const string SLIDE_STATUS = "SLIDE_STATUS";
            public const string CREATED_BY = "CREATED_BY";
            public const string CREATED_ON = "CREATED_ON";
            public const string PUBLISHED_BY = "PUBLISHED_BY";
            public const string PUBLISHED_ON = "PUBLISHED_ON";
            public const string SLIDE_NAME = "SLIDE_NAME";
            public const string AUDIO_ID = "AUDIO_ID";
            public const string IMAGE_ID = "IMAGE_ID";
            public const string DESCRIPTION = "DESCRIPTION";
            public const string SURVEY_TEXT = "SURVEY_TEXT";
            public const string ANIMATION_ID = "ANIMATION_ID";
            public const string STATUS_EN = "STATUS_EN";
            public const string STATUS_AR = "STATUS_AR";
            public const string CREATED_BY_EN = "CREATED_BY_EN";
            public const string CREATED_BY_AR = "CREATED_BY_AR";
            public const string XML_ID = "XML_ID";
            public const string USE_DEFAULT_MAP = "USE_DEFAULT_MAP";
            public const string TOTAL_X_PARTS = "TOTAL_X_PARTS";
            public const string TOTAL_Y_PARTS = "TOTAL_Y_PARTS";
            public const string MASK_X = "MASK_X";
            public const string MASK_Y = "MASK_Y";
            public const string MASK_WIDTH = "MASK_WIDTH";
            public const string MASK_HEIGHT = "MASK_HEIGHT";

            public static DataTable GetDataTable()
            {
                DataTable dt = new DataTable(TABLE_NAME);
                dt.Columns.Add(SLIDE_ID, typeof(Int64));
                dt.Columns.Add(SLIDE_NUM, typeof(String));
                dt.Columns.Add(SLIDE_TYPE, typeof(int));
                dt.Columns.Add(SLIDE_STATUS, typeof(int));
                dt.Columns.Add(STATUS_EN, typeof(String));
                dt.Columns.Add(STATUS_AR, typeof(String));
                dt.Columns.Add(MASK_X, typeof(int));
                dt.Columns.Add(MASK_Y, typeof(int));
                dt.Columns.Add(MASK_WIDTH, typeof(int));
                dt.Columns.Add(MASK_HEIGHT, typeof(int));
                dt.Columns.Add(CREATED_BY, typeof(String));
                dt.Columns.Add(CREATED_BY_EN, typeof(String));
                dt.Columns.Add(CREATED_BY_AR, typeof(String));
                dt.Columns.Add(CREATED_ON, typeof(DateTime));
                dt.Columns.Add(PUBLISHED_BY, typeof(String));
                dt.Columns.Add(PUBLISHED_ON, typeof(DateTime));
                dt.Columns.Add(SLIDE_NAME, typeof(int));
                dt.Columns.Add(DESCRIPTION, typeof(int));
                dt.Columns.Add(AUDIO_ID, typeof(int));
                dt.Columns.Add(IMAGE_ID, typeof(int));
                dt.Columns.Add(SURVEY_TEXT, typeof(int));
                dt.Columns.Add(ANIMATION_ID, typeof(int));
                dt.Columns.Add(TEMP_ID, typeof(String));
                dt.Columns.Add(XML_ID, typeof(Int64));
                dt.Columns.Add(USE_DEFAULT_MAP, typeof(string));
                dt.Columns.Add(TOTAL_X_PARTS, typeof(int));
                dt.Columns.Add(TOTAL_Y_PARTS, typeof(int));
                DataColumn isNewCol = new DataColumn();
                isNewCol.DefaultValue = "1";
                isNewCol.ColumnName = IS_NEW;
                isNewCol.AllowDBNull = true;
                return dt;
            }


        }

        public static class SlideDetails
        {
            public const string TABLE_NAME = "SLIDE_DETAILS";
            public const string SLIDE_DETAILS_ID = "SLIDE_DETAILS_ID";
            public const string SLIDE_ID = "SLIDE_ID";
            public const string CATEGORY_ID = "CATEGORY_ID";
            public const string SURVEY_CHOICE_ID = "SURVEY_CHOICE_ID";
            public const string AUDIO_ID = "AUDIO_ID";
            public const string SURVEY_QUESTION = "SURVEY_QUESTION";

            public static DataTable GetDataTable()
            {
                DataTable dt = new DataTable(TABLE_NAME);
                dt.Columns.Add(SLIDE_ID, typeof(int));
                dt.Columns.Add(SLIDE_DETAILS_ID, typeof(int));
                dt.Columns.Add(CATEGORY_ID, typeof(int));
                dt.Columns.Add(SURVEY_CHOICE_ID, typeof(int));
                dt.Columns.Add(AUDIO_ID, typeof(int));
                dt.Columns.Add(SURVEY_QUESTION, typeof(int));

                return dt;
            }


        }

        public static class SlideType
        {
            public const string TABLE_NAME = "SLIDE_TYPE";
            public const string SLIDE_TYPE_ID = "SLIDE_TYPE_ID";
            public const string SLIDE_TYPE_EN = "SLIDE_TYPE_EN";
            public const string SLIDE_TYPE_AR = "SLIDE_TYPE_AR";

        }
        public static class SlideStatus
        {
            public const string TABLE_NAME = "SLIDE_STATUS";
            public const string SLIDE_STATUS_ID = "SLIDE_STATUS_ID";
            public const string SLIDE_STATUS_EN = "SLIDE_STATUS_EN";
            public const string SLIDE_STATUS_AR = "SLIDE_STATUS_AR";

        }

        public class SP_USP_GetSlidesById
        {

            public const string SP_NAME = "usp_GetTrainingSlidesById";
            public const string ERROR_MESSAGE = "ERROR_MESSAGE";
            public SP_USP_GetSlidesById(string slideId)
            {

                this.slideId.ParamValue = slideId;
                list.Add(this.slideId);


            }
            private List<StoredProcedureParams> list = new List<StoredProcedureParams>();
            public List<StoredProcedureParams> ParamsList { get { return this.list; } }
            public StoredProcedureParams slideId = new StoredProcedureParams("@SLIDE_ID", DbType.Int64);


        }
        public class SP_USP_SearchTrainingSlides
        {

            public const string SP_NAME = "usp_SearchTrainingSlides";
            public const string ERROR_MESSAGE = "ERROR_MESSAGE";
            public SP_USP_SearchTrainingSlides(string orderBy, int pageToRetrieve, int recordsPerPage, string whereClause)
            {

                this.orderBy.ParamValue = orderBy;
                list.Add(this.orderBy);

                this.recordsPerPage.ParamValue = recordsPerPage.ToString();
                list.Add(this.recordsPerPage);

                this.pageToRetrieve.ParamValue = pageToRetrieve.ToString();
                list.Add(this.pageToRetrieve);


                this.whereClause.ParamValue = whereClause.ToString();
                list.Add(this.whereClause);

            }
            private List<StoredProcedureParams> list = new List<StoredProcedureParams>();
            public List<StoredProcedureParams> ParamsList { get { return this.list; } }
            public StoredProcedureParams orderBy = new StoredProcedureParams("@ORDER_BY", DbType.String);
            public StoredProcedureParams recordsPerPage = new StoredProcedureParams("@RECPERPAGE", DbType.Int16);
            public StoredProcedureParams pageToRetrieve = new StoredProcedureParams("@CURRENTPAGE", DbType.Int16);
            public StoredProcedureParams whereClause = new StoredProcedureParams("@WHERECLAUSE", DbType.String);



        }
        public static class RequestType
        {
            public const string TABLE_NAME = "REQUEST_TYPE";
            public const string TYPE_ID = "TYPE_ID";
            public const string TYPE_EN = "TYPE_EN";
            public const string TYPE_AR = "TYPE_AR";

        }
        public static class RequestStatus
        {
            public const string TABLE_NAME = "REQUEST_STATUS";
            public const string STATUS_ID = "STATUS_ID";
            public const string STATUS_EN = "STATUS_EN";
            public const string STATUS_AR = "STATUS_AR";

        }
        public static class RequestDetailStatus
        {
            public const string TABLE_NAME = "REQUEST_DETAIL_STATUS";
            public const string STATUS_ID = "STATUS_ID";
            public const string STATUS_EN = "STATUS_EN";
            public const string STATUS_AR = "STATUS_AR";

        }
        public static class Franchises
        {
            public const string TABLE_NAME = "FRANCHISES";
            public const string FRANCHISE_ID = "FRANCHISE_ID";
            public const string NAME = "NAME";
            public const string NAME_EN = "NAME_EN";
            public const string NAME_AR = "NAME_AR";
            public const string IS_DELETED = "IS_DELETED";

        }

        public static class Request
        {
            public const string TABLE_NAME = "REQUEST";
            public const string REQUEST_ID = "REQUEST_ID";
            public const string REQ_STATUS = "REQ_STATUS";
            public const string EXCEL_FILE_DATA = "EXCEL_FILE_DATA";
            public const string STATUS_EN = "STATUS_EN";
            public const string STATUS_AR = "STATUS_AR";
            public const string CREATED_BY = "CREATED_BY";
            public const string CREATED_BY_EN = "CREATED_BY_EN";
            public const string CREATED_BY_AR = "CREATED_BY_AR";
            public const string CREATED_ON = "CREATED_ON";
            public const string REQ_TYPE = "REQ_TYPE";
            public const string TYPE_AR = "TYPE_AR";
            public const string TYPE_EN = "TYPE_EN";
            public const string FRANCHISE = "FRANCHISE";
            public const string FRANCHISE_EN = "FRANCHISE_EN";
            public const string FRANCHISE_AR = "FRANCHISE_AR";
            public const string REQ_NUM = "REQ_NUM";
            public const string DEPTT_NAME_EN = "DEPTT_NAME_EN";
            public const string DEPTT_NAME_AR = "DEPTT_NAME_AR";

            public static DataTable GetDataTable()
            {
                DataTable dt = new DataTable(TABLE_NAME);
                dt.Columns.Add(REQUEST_ID, typeof(Int64));
                dt.Columns.Add(REQ_STATUS, typeof(Int16));
                dt.Columns.Add(REQ_NUM, typeof(String));
                dt.Columns.Add(STATUS_EN, typeof(String));
                dt.Columns.Add(STATUS_AR, typeof(String));
                dt.Columns.Add(CREATED_BY, typeof(String));
                dt.Columns.Add(CREATED_BY_EN, typeof(String));
                dt.Columns.Add(CREATED_BY_AR, typeof(String));
                dt.Columns.Add(CREATED_ON, typeof(DateTime));
                dt.Columns.Add(REQ_TYPE, typeof(Int16));
                dt.Columns.Add(TYPE_EN, typeof(String));
                dt.Columns.Add(TYPE_AR, typeof(String));
                dt.Columns.Add(FRANCHISE, typeof(Int16));
                dt.Columns.Add(DEPTT_NAME_EN, typeof(Int16));
                dt.Columns.Add(DEPTT_NAME_AR, typeof(Int16));
                dt.Columns.Add(FRANCHISE_EN, typeof(String));
                dt.Columns.Add(FRANCHISE_AR, typeof(String));
                dt.Columns.Add(EXCEL_FILE_DATA, typeof(String));

                return dt;
            }

        }
        public static class TrainingRequestDetails
        {
            public const string TABLE_NAME = "TRAINING_REQUEST_DETAILS";
            public const string REQUEST_DETAIL_ID = "REQUEST_DETAIL_ID";
            public const string REQUEST_ID = "REQUEST_ID";
            public const string WORK_ORDER_NUM = "WORK_ORDER_NUM";
            public const string REQ_DETAIL_STATUS = "REQ_DETAIL_STATUS";
            public const string STATUS_EN = "STATUS_EN";
            public const string STATUS_AR = "STATUS_AR";
            public const string REQ_DETAIL_TYPE = "REQ_DETAIL_TYPE";
            public const string TYPE_AR = "TYPE_AR";
            public const string TYPE_EN = "TYPE_EN";
            public const string LOCATION = "LOCATION";
            public const string REASON = "REASON";
            public const string PERSON_ID = "PERSON_ID";
            public const string CAR_NUM = "CAR_NUM";
            public const string COMPLAINT_SOURCE = "COMPLAINT_SOURCE";
            public const string COMPLAINT_NO = "COMPLAINT_NO";
            public const string IS_GUILTY = "IS_GUILTY";
            public const string RECOMMENDED_TRAINING_DAYS = "RECOMMENDED_TRAINING_DAYS";
            public const string INVESTIGATION_RECOMMENDATION = "INVESTIGATION_RECOMMENDATION";
            public const string ACCIDENT_DATE = "ACCIDENT_DATE";
            public const string REPORTED_DATE = "REPORTED_DATE";

            public static DataTable GetDataTable()
            {
                DataTable dt = new DataTable(TABLE_NAME);
                dt.Columns.Add(REQUEST_DETAIL_ID, typeof(Int64));
                dt.Columns.Add(REQUEST_ID, typeof(Int64));
                dt.Columns.Add(WORK_ORDER_NUM, typeof(String));
                dt.Columns.Add(REQ_DETAIL_STATUS, typeof(Int16));
                dt.Columns.Add(STATUS_EN, typeof(String));
                dt.Columns.Add(STATUS_AR, typeof(String));
                dt.Columns.Add(LOCATION, typeof(String));
                dt.Columns.Add(REASON, typeof(String));
                dt.Columns.Add(PERSON_ID, typeof(Int64));
                dt.Columns.Add(CAR_NUM, typeof(String));
                dt.Columns.Add(COMPLAINT_SOURCE, typeof(String));
                dt.Columns.Add(COMPLAINT_NO, typeof(String));
                dt.Columns.Add(IS_GUILTY, typeof(String));
                dt.Columns.Add(RECOMMENDED_TRAINING_DAYS, typeof(String));
                dt.Columns.Add(INVESTIGATION_RECOMMENDATION, typeof(String));
                dt.Columns.Add(ACCIDENT_DATE, typeof(String));
                dt.Columns.Add(REPORTED_DATE, typeof(String));

                return dt;
            }
        }

        public class SP_USP_AddNewDriverTrainingRequest
        {

            public const string SP_NAME = "usp_AddNewDriversTrainingRequest";

            public SP_USP_AddNewDriverTrainingRequest(DataRow row)
            {


                this.createdBy.ParamValue = row[Request.CREATED_BY].ToString();
                list.Add(this.createdBy);


                this.requestNumber.ParamValue = row[Request.REQ_NUM].ToString();
                list.Add(this.requestNumber);

                this.franchise.ParamValue = row[Request.FRANCHISE].ToString();
                list.Add(this.franchise);

                this.excelData.ParamValue = row[Request.EXCEL_FILE_DATA].ToString();
                list.Add(this.excelData);

            }
            private List<StoredProcedureParams> list = new List<StoredProcedureParams>();

            public List<StoredProcedureParams> ParamsList { get { return this.list; } }
            public StoredProcedureParams createdBy = new StoredProcedureParams("@CREATED_BY", DbType.String);

            public StoredProcedureParams requestNumber = new StoredProcedureParams("@REQ_NUM", DbType.String);
            public StoredProcedureParams franchise = new StoredProcedureParams("@FRANCHISE", DbType.Int16);
            public StoredProcedureParams excelData = new StoredProcedureParams("@excelData ", DbType.Xml);

        }

        public class SP_USP_GetNewDriverTrainingRequestById
        {

            public const string SP_NAME = "usp_GetNewDriverTrainingRequestById";
            public const string ERROR_MESSAGE = "ERROR_MESSAGE";
            public SP_USP_GetNewDriverTrainingRequestById(string id)
            {
                this.Id.ParamValue = id;
                list.Add(this.Id);
            }
            private List<StoredProcedureParams> list = new List<StoredProcedureParams>();
            public List<StoredProcedureParams> ParamsList { get { return this.list; } }
            public StoredProcedureParams Id = new StoredProcedureParams("@REQUEST_ID", DbType.Int64);


        }

        public class SP_USP_AddAccidentTrainingRequest
        {

            public const string SP_NAME = "usp_AddAccidentTrainingRequest";

            public SP_USP_AddAccidentTrainingRequest(DataRow row)
            {


                this.createdBy.ParamValue = row[Request.CREATED_BY].ToString();
                list.Add(this.createdBy);


                this.requestNumber.ParamValue = row[Request.REQ_NUM].ToString();
                list.Add(this.requestNumber);

                this.franchise.ParamValue = row[Request.FRANCHISE].ToString();
                list.Add(this.franchise);

                this.excelData.ParamValue = row[Request.EXCEL_FILE_DATA].ToString();
                list.Add(this.excelData);

            }
            private List<StoredProcedureParams> list = new List<StoredProcedureParams>();

            public List<StoredProcedureParams> ParamsList { get { return this.list; } }
            public StoredProcedureParams createdBy = new StoredProcedureParams("@CREATED_BY", DbType.String);

            public StoredProcedureParams requestNumber = new StoredProcedureParams("@REQ_NUM", DbType.String);
            public StoredProcedureParams franchise = new StoredProcedureParams("@FRANCHISE", DbType.Int16);
            public StoredProcedureParams excelData = new StoredProcedureParams("@excelData ", DbType.Xml);

        }
        public class SP_USP_GetAccidentTrainingRequestById
        {

            public const string SP_NAME = "usp_GetAccidentTrainingRequestById";
            public const string ERROR_MESSAGE = "ERROR_MESSAGE";
            public SP_USP_GetAccidentTrainingRequestById(string id)
            {
                this.Id.ParamValue = id;
                list.Add(this.Id);
            }
            private List<StoredProcedureParams> list = new List<StoredProcedureParams>();
            public List<StoredProcedureParams> ParamsList { get { return this.list; } }
            public StoredProcedureParams Id = new StoredProcedureParams("@REQUEST_ID", DbType.Int64);


        }

        public class SP_USP_AddRefresherTrainingRequest
        {

            public const string SP_NAME = "usp_AddRefresherTrainingRequest";

            public SP_USP_AddRefresherTrainingRequest(DataRow row)
            {


                this.createdBy.ParamValue = row[Request.CREATED_BY].ToString();
                list.Add(this.createdBy);


                this.requestNumber.ParamValue = row[Request.REQ_NUM].ToString();
                list.Add(this.requestNumber);

                this.franchise.ParamValue = row[Request.FRANCHISE].ToString();
                list.Add(this.franchise);

                this.excelData.ParamValue = row[Request.EXCEL_FILE_DATA].ToString();
                list.Add(this.excelData);

            }
            private List<StoredProcedureParams> list = new List<StoredProcedureParams>();

            public List<StoredProcedureParams> ParamsList { get { return this.list; } }
            public StoredProcedureParams createdBy = new StoredProcedureParams("@CREATED_BY", DbType.String);

            public StoredProcedureParams requestNumber = new StoredProcedureParams("@REQ_NUM", DbType.String);
            public StoredProcedureParams franchise = new StoredProcedureParams("@FRANCHISE", DbType.Int16);
            public StoredProcedureParams excelData = new StoredProcedureParams("@excelData ", DbType.Xml);

        }
        public class SP_USP_GetRefresherTrainingRequestById
        {

            public const string SP_NAME = "usp_GetRefresherTrainingRequestById";
            public const string ERROR_MESSAGE = "ERROR_MESSAGE";
            public SP_USP_GetRefresherTrainingRequestById(string id)
            {
                this.Id.ParamValue = id;
                list.Add(this.Id);
            }
            private List<StoredProcedureParams> list = new List<StoredProcedureParams>();
            public List<StoredProcedureParams> ParamsList { get { return this.list; } }
            public StoredProcedureParams Id = new StoredProcedureParams("@REQUEST_ID", DbType.Int64);


        }

        public class SP_USP_SearchTests
        {

            public const string SP_NAME = "usp_SearchTests";
            public const string ERROR_MESSAGE = "ERROR_MESSAGE";
            public SP_USP_SearchTests(string orderBy, int pageToRetrieve, int recordsPerPage, string whereClause)
            {

                this.orderBy.ParamValue = orderBy;
                list.Add(this.orderBy);

                this.recordsPerPage.ParamValue = recordsPerPage.ToString();
                list.Add(this.recordsPerPage);

                this.pageToRetrieve.ParamValue = pageToRetrieve.ToString();
                list.Add(this.pageToRetrieve);


                this.whereClause.ParamValue = whereClause.ToString();
                list.Add(this.whereClause);

            }
            private List<StoredProcedureParams> list = new List<StoredProcedureParams>();
            public List<StoredProcedureParams> ParamsList { get { return this.list; } }
            public StoredProcedureParams orderBy = new StoredProcedureParams("@ORDER_BY", DbType.String);
            public StoredProcedureParams recordsPerPage = new StoredProcedureParams("@RECPERPAGE", DbType.Int16);
            public StoredProcedureParams pageToRetrieve = new StoredProcedureParams("@CURRENTPAGE", DbType.Int16);
            public StoredProcedureParams whereClause = new StoredProcedureParams("@WHERECLAUSE", DbType.String);

        }

        public static class Course
        {
            public const string TABLE_NAME = "COURSE";
            public const string IS_NEW = "IS_NEW";
            public const string TEMP_ID = "TEMP_ID";
            public const string COURSE_ID = "COURSE_ID";
            public const string COURSE_NUM = "COURSE_NUM";
            public const string DESCRIPTION = "DESCRIPTION";
            public const string STATUS = "STATUS";
            public const string CREATED_BY = "CREATED_BY";
            public const string CREATED_ON = "CREATED_ON";
            public const string COURSE_NAME = "COURSE_NAME";
            public const string ICON = "ICON";
            public const string XML_ID = "XML_ID";
            public const string STATUS_EN = "STATUS_EN";
            public const string STATUS_AR = "STATUS_AR";
            public const string CREATED_BY_EN = "CREATED_BY_EN";
            public const string CREATED_BY_AR = "CREATED_BY_AR";

            public const string CourseName = "CourseName";
            public const string CourseCode = "CourseCode";
            public const string CourseFee = "CourseFee";
            public const string ChapterId = "ChapterId";
            public const string ChapterName = "ChapterName";
            public const string PracticalDuration = "PracticalDuration";
            public const string TheoryDuration = "TheoryDuration";
            public const string ELIGIBILITY_CRITERIA = "ELIGIBILITY_CRITERIA";



            public static DataTable GetDataTable()
            {
                DataTable dt = new DataTable(TABLE_NAME);
                dt.Columns.Add(COURSE_ID, typeof(int));
                dt.Columns.Add(COURSE_NAME, typeof(String));
                dt.Columns.Add(COURSE_NUM, typeof(String));
                dt.Columns.Add(DESCRIPTION, typeof(int));
                dt.Columns.Add(STATUS, typeof(int));
                dt.Columns.Add(XML_ID, typeof(int));
                dt.Columns.Add(STATUS_EN, typeof(String));
                dt.Columns.Add(STATUS_AR, typeof(String));
                dt.Columns.Add(CREATED_BY, typeof(String));
                dt.Columns.Add(CREATED_BY_EN, typeof(String));
                dt.Columns.Add(CREATED_BY_AR, typeof(String));
                dt.Columns.Add(CREATED_ON, typeof(DateTime));
                dt.Columns.Add(ICON, typeof(int));
                dt.Columns.Add(TEMP_ID, typeof(String));
                DataColumn isNewCol = new DataColumn();
                isNewCol.DefaultValue = "1";
                isNewCol.ColumnName = IS_NEW;
                isNewCol.AllowDBNull = true;
                return dt;
            }
        }

        public static class CourseStatus
        {
            public const string TABLE_NAME = "COURSE_STATUS";
            public const string COURSE_STATUS_ID = "COURSE_STATUS_ID";
            public const string STATUS_EN = "STATUS_EN";
            public const string STATUS_AR = "STATUS_AR";

        }

        public static class CourseMaterial
        {
            public const string TABLE_NAME = "COURSE_MATERIAL";
            public const string IS_NEW = "IS_NEW";
            public const string TEMP_ID = "TEMP_ID";
            public const string COURSE_MATERIAL_ID = "COURSE_MATERIAL_ID";
            public const string SEQUENCE = "SEQUENCE";
            public const string QUESTION_ID = "QUESTION_ID";
            public const string SLIDE_ID = "SLIDE_ID";
            public const string NAME = "NAME";
            public const string TYPE = "TYPE";
            public const string COURSE_ID = "COURSE_ID";

            public static DataTable GetDataTable()
            {
                DataTable dt = new DataTable(TABLE_NAME);
                dt.Columns.Add(COURSE_MATERIAL_ID, typeof(Int64));
                dt.Columns.Add(COURSE_ID, typeof(Int64));
                dt.Columns.Add(SEQUENCE, typeof(String));
                dt.Columns.Add(QUESTION_ID, typeof(int));
                dt.Columns.Add(SLIDE_ID, typeof(String));
                dt.Columns.Add(NAME, typeof(String));
                dt.Columns.Add(TYPE, typeof(String));
                dt.Columns.Add(TEMP_ID, typeof(String));
                DataColumn isNewCol = new DataColumn();
                isNewCol.DefaultValue = "1";
                isNewCol.ColumnName = IS_NEW;
                isNewCol.AllowDBNull = true;
                return dt;
            }
        }

        public class SP_USP_GetCoursesById
        {

            public const string SP_NAME = "usp_GetCourseById";
            public const string ERROR_MESSAGE = "ERROR_MESSAGE";
            public SP_USP_GetCoursesById(string id)
            {
                this.Id.ParamValue = id;
                list.Add(this.Id);
            }
            private List<StoredProcedureParams> list = new List<StoredProcedureParams>();
            public List<StoredProcedureParams> ParamsList { get { return this.list; } }
            public StoredProcedureParams Id = new StoredProcedureParams("@COURSE_ID", DbType.Int64);


        }
        public class SP_USP_SearchCourses
        {
            public const string SP_NAME = "usp_SearchCourses";
            public const string ERROR_MESSAGE = "ERROR_MESSAGE";
            public SP_USP_SearchCourses(string orderBy, int pageToRetrieve, int recordsPerPage, string whereClause)
            {

                this.orderBy.ParamValue = orderBy;
                list.Add(this.orderBy);

                this.recordsPerPage.ParamValue = recordsPerPage.ToString();
                list.Add(this.recordsPerPage);

                this.pageToRetrieve.ParamValue = pageToRetrieve.ToString();
                list.Add(this.pageToRetrieve);


                this.whereClause.ParamValue = whereClause.ToString();
                list.Add(this.whereClause);

            }
            private List<StoredProcedureParams> list = new List<StoredProcedureParams>();
            public List<StoredProcedureParams> ParamsList { get { return this.list; } }
            public StoredProcedureParams orderBy = new StoredProcedureParams("@ORDER_BY", DbType.String);
            public StoredProcedureParams recordsPerPage = new StoredProcedureParams("@RECPERPAGE", DbType.Int16);
            public StoredProcedureParams pageToRetrieve = new StoredProcedureParams("@CURRENTPAGE", DbType.Int16);
            public StoredProcedureParams whereClause = new StoredProcedureParams("@WHERECLAUSE", DbType.String);

        }


        public static class TrainingTemplate
        {
            public const string TABLE_NAME = "TRAINING_TEMPLATE";
            public const string IS_NEW = "IS_NEW";
            public const string TRAINING_TEMP_ID = "TRAINING_TEMP_ID";
            public const string TRAINING_GROUP = "TRAINING_GROUP";
            public const string DESCRIPTION = "DESCRIPTION";
            public const string TRAINING_NAME = "TRAINING_NAME";
            public const string NAME_EN = "NAME_EN";
            public const string NAME_AR = "NAME_AR";
            public const string TRAINING_SUBGROUP = "TRAINING_SUBGROUP";
            public const string CREATED_ON = "CREATED_ON";
            public const string DURATION = "DURATION";
            public const string XML_ID = "XML_ID";
            public const string FEES_DTC = "FEES_DTC";
            public const string FEES_NON_DTC = "FEES_NON_DTC";
            public const string CREATED_BY = "CREATED_BY";
            public const string CREATED_BY_EN = "CREATED_BY_EN";
            public const string CREATED_BY_AR = "CREATED_BY_AR";
            public const string PREREQ_TRAINING_ID = "PREREQ_TRAINING_ID";
            public const string IS_DEFAULT = "IS_DEFAULT";
            public static DataTable GetDataTable()
            {
                DataTable dt = new DataTable(TABLE_NAME);
                dt.Columns.Add(TRAINING_TEMP_ID, typeof(int));
                dt.Columns.Add(PREREQ_TRAINING_ID, typeof(int));
                dt.Columns.Add(TRAINING_GROUP, typeof(int));
                dt.Columns.Add(TRAINING_SUBGROUP, typeof(int));
                dt.Columns.Add(DESCRIPTION, typeof(int));
                dt.Columns.Add(TRAINING_NAME, typeof(int));
                dt.Columns.Add(NAME_EN, typeof(int));
                dt.Columns.Add(NAME_AR, typeof(int));
                dt.Columns.Add(XML_ID, typeof(int));
                dt.Columns.Add(DURATION, typeof(int));
                dt.Columns.Add(FEES_DTC, typeof(String));
                dt.Columns.Add(FEES_NON_DTC, typeof(String));
                dt.Columns.Add(CREATED_BY, typeof(String));
                dt.Columns.Add(CREATED_BY_EN, typeof(String));
                dt.Columns.Add(CREATED_BY_AR, typeof(String));
                dt.Columns.Add(CREATED_ON, typeof(DateTime));
                dt.Columns.Add(IS_DEFAULT, typeof(String));
                DataColumn isNewCol = new DataColumn();
                isNewCol.DefaultValue = "1";
                isNewCol.ColumnName = IS_NEW;
                isNewCol.AllowDBNull = true;
                return dt;
            }
        }



        public class SP_USP_GetTrainingTemplateById
        {

            public const string SP_NAME = "usp_GetTrainingTemplateById";
            public const string ERROR_MESSAGE = "ERROR_MESSAGE";
            public SP_USP_GetTrainingTemplateById(string id)
            {
                this.Id.ParamValue = id;
                list.Add(this.Id);
            }
            private List<StoredProcedureParams> list = new List<StoredProcedureParams>();
            public List<StoredProcedureParams> ParamsList { get { return this.list; } }
            public StoredProcedureParams Id = new StoredProcedureParams("@TRAINING_TEMP_ID", DbType.Int64);


        }
        public class SP_USP_SearchTrainingTemplates
        {
            public const string SP_NAME = "usp_SearchTrainingTemplates";
            public const string ERROR_MESSAGE = "ERROR_MESSAGE";
            public SP_USP_SearchTrainingTemplates(string orderBy, int pageToRetrieve, int recordsPerPage, string whereClause)
            {

                this.orderBy.ParamValue = orderBy;
                list.Add(this.orderBy);

                this.recordsPerPage.ParamValue = recordsPerPage.ToString();
                list.Add(this.recordsPerPage);

                this.pageToRetrieve.ParamValue = pageToRetrieve.ToString();
                list.Add(this.pageToRetrieve);


                this.whereClause.ParamValue = whereClause.ToString();
                list.Add(this.whereClause);

            }
            private List<StoredProcedureParams> list = new List<StoredProcedureParams>();
            public List<StoredProcedureParams> ParamsList { get { return this.list; } }
            public StoredProcedureParams orderBy = new StoredProcedureParams("@ORDER_BY", DbType.String);
            public StoredProcedureParams recordsPerPage = new StoredProcedureParams("@RECPERPAGE", DbType.Int16);
            public StoredProcedureParams pageToRetrieve = new StoredProcedureParams("@CURRENTPAGE", DbType.Int16);
            public StoredProcedureParams whereClause = new StoredProcedureParams("@WHERECLAUSE", DbType.String);

        }
        public static class TrainingGroup
        {
            public const string TABLE_NAME = "TRAINING_GROUPS";
            public const string IS_SYSTEM = "IS_SYSTEM";
            public const string GROUP_ID = "GROUP_ID";
            public const string CREATED_ON = "CREATED_ON";
            public const string CREATED_BY = "CREATED_BY";
            public const string CREATED_BY_EN = "CREATED_BY_EN";
            public const string CREATED_BY_AR = "CREATED_BY_AR";
            public const string GROUP_NAME_EN = "GROUP_NAME_EN";
            public const string GROUP_NAME_AR = "GROUP_NAME_AR";
            public static DataTable GetDataTable()
            {
                DataTable dt = new DataTable(TABLE_NAME);
                dt.Columns.Add(GROUP_NAME_EN, typeof(String));
                dt.Columns.Add(GROUP_NAME_AR, typeof(String));
                dt.Columns.Add(GROUP_ID, typeof(int));
                dt.Columns.Add(CREATED_BY, typeof(String));
                dt.Columns.Add(CREATED_BY_EN, typeof(String));
                dt.Columns.Add(CREATED_BY_AR, typeof(String));
                dt.Columns.Add(CREATED_ON, typeof(DateTime));
                DataColumn isSysCol = new DataColumn();
                isSysCol.DefaultValue = "0";
                isSysCol.ColumnName = IS_SYSTEM;
                isSysCol.AllowDBNull = true;
                return dt;
            }
        }

        public static class TrainingSubGroup
        {
            public const string TABLE_NAME = "TRAINING_SUB_GROUPS";
            public const string IS_SYSTEM = "IS_SYSTEM";
            public const string SUB_GROUP_ID = "SUB_GROUP_ID";
            public const string CREATED_ON = "CREATED_ON";
            public const string CREATED_BY = "CREATED_BY";
            public const string CREATED_BY_EN = "CREATED_BY_EN";
            public const string CREATED_BY_AR = "CREATED_BY_AR";
            public const string SUB_GROUP_EN = "SUB_GROUP_EN";
            public const string SUB_GROUP_AR = "SUB_GROUP_AR";
            public static DataTable GetDataTable()
            {
                DataTable dt = new DataTable(TABLE_NAME);
                dt.Columns.Add(SUB_GROUP_EN, typeof(String));
                dt.Columns.Add(SUB_GROUP_AR, typeof(String));
                dt.Columns.Add(SUB_GROUP_ID, typeof(int));
                dt.Columns.Add(CREATED_BY, typeof(String));
                dt.Columns.Add(CREATED_BY_EN, typeof(String));
                dt.Columns.Add(CREATED_BY_AR, typeof(String));
                dt.Columns.Add(CREATED_ON, typeof(DateTime));
                DataColumn isSysCol = new DataColumn();
                isSysCol.DefaultValue = "0";
                isSysCol.ColumnName = IS_SYSTEM;
                isSysCol.AllowDBNull = true;
                return dt;
            }
        }
        public static class TrainingTempFinesOnAbsent
        {
            public const string TABLE_NAME = "TRAINING_TEMP_FINES_ON_ABSENT";
            public const string TEMP_FINES_ABSENT_ID = "TEMP_FINES_ABSENT_ID";
            public const string COUNT = "COUNT";
            public const string FINE = "FINE";
            public const string TRAINING_TEMP_ID = "TRAINING_TEMP_ID";
            public static DataTable GetDataTable()
            {
                DataTable dt = new DataTable(TABLE_NAME);
                dt.Columns.Add(TEMP_FINES_ABSENT_ID, typeof(int));
                dt.Columns.Add(FINE, typeof(int));
                dt.Columns.Add(COUNT, typeof(int));
                dt.Columns.Add(TRAINING_TEMP_ID, typeof(int));
                return dt;
            }
        }

        public static class TrainingPlanActivity
        {
            public const string TABLE_NAME = "TRAINING_PLAN_ACTIVITY_TYPE";
            public const string TYPE_ID = "TYPE_ID";
            public const string TYPE_EN = "TYPE_EN";
            public const string TYPE_AR = "TYPE_AR";


        }
        public static class TrainingTemplatePlan
        {
            public const string TABLE_NAME = "TRAINING_TEMPLATE_PLAN";
            public const string TEMPLATE_PLAN_ID = "TEMPLATE_PLAN_ID";
            public const string DAY = "DAY";
            public const string ACTIVITY_TYPE = "ACTIVITY_TYPE";
            public const string ACTIVITY_TYPE_EN = "ACTIVITY_TYPE_EN";
            public const string ACTIVITY_TYPE_AR = "ACTIVITY_TYPE_AR";
            public const string COURSE_ID = "COURSE_ID";
            public const string NAME_EN = "NAME_EN";
            public const string NAME_AR = "NAME_AR";
            public const string EXAM_TEMPLATE_ID = "EXAM_TEMPLATE_ID";

            public const string TRAINING_TEMP_ID = "TRAINING_TEMP_ID";

            public static DataTable GetDataTable()
            {
                DataTable dt = new DataTable(TABLE_NAME);
                dt.Columns.Add(TEMPLATE_PLAN_ID, typeof(Int64));
                dt.Columns.Add(TRAINING_TEMP_ID, typeof(Int64));
                dt.Columns.Add(DAY, typeof(int));
                dt.Columns.Add(ACTIVITY_TYPE, typeof(int));
                dt.Columns.Add(ACTIVITY_TYPE_EN, typeof(String));
                dt.Columns.Add(ACTIVITY_TYPE_AR, typeof(String));
                dt.Columns.Add(COURSE_ID, typeof(int));
                dt.Columns.Add(NAME_EN, typeof(String));
                dt.Columns.Add(NAME_AR, typeof(String));
                dt.Columns.Add(EXAM_TEMPLATE_ID, typeof(Int64));

                return dt;
            }
        }
        public static class SlideSurveyCategory
        {
            public const string TABLE_NAME = "SLIDE_SURVEY_CATEGORY";
            public const string CATEGORY_ID = "CATEGORY_ID";
            public const string IS_NEW = "IS_NEW";
            public const string IS_EDITING = "IS_EDITING";
            public const string IS_CHANGED = "IS_CHANGED";
            public const string IS_DELETED = "IS_DELETED";
            public const string IS_ADDING = "IS_ADDING";
            public const string CATEGORY_TEXT = "CATEGORY_TEXT";
            public const string SLIDE_ID = "SLIDE_ID";
            public static DataTable GetDataTable()
            {
                DataTable dt = new DataTable(TABLE_NAME);
                dt.Columns.Add(CATEGORY_ID, typeof(int));
                dt.Columns.Add(CATEGORY_TEXT, typeof(int));
                dt.Columns.Add(SLIDE_ID, typeof(int));
                DataColumn isNewCol = new DataColumn();
                isNewCol.DefaultValue = "1";
                isNewCol.ColumnName = IS_NEW;
                dt.Columns.Add(isNewCol);
                DataColumn isEditCol = new DataColumn();
                isEditCol.DefaultValue = "0";
                isEditCol.ColumnName = IS_EDITING;
                dt.Columns.Add(isEditCol);
                DataColumn isChangedCol = new DataColumn();
                isChangedCol.DefaultValue = "0";
                isChangedCol.ColumnName = IS_CHANGED;
                dt.Columns.Add(isChangedCol);
                DataColumn isDelCol = new DataColumn();
                isDelCol.DefaultValue = "0";
                isDelCol.ColumnName = IS_DELETED;
                dt.Columns.Add(isDelCol);
                DataColumn isAddingCol = new DataColumn();
                isAddingCol.DefaultValue = "0";
                isAddingCol.ColumnName = IS_ADDING;
                dt.Columns.Add(isAddingCol);
                AddCulutureResLangColumnsToDataTable(dt);
                return dt;
            }


        }
        private static void AddCulutureResLangColumnsToDataTable(DataTable dt)
        {
            foreach (DataColumn col in CultureResources.GetDataTable().Columns)
            {

                if (!col.ColumnName.Equals("RES_ID") && col.ColumnName.IndexOf("RES_") == 0)
                {
                    DataColumn column = new DataColumn();
                    column.DefaultValue = col.DefaultValue;
                    column.ColumnName = col.ColumnName;
                    column.MaxLength = col.MaxLength;
                    column.DataType = col.DataType;

                    dt.Columns.Add(column);
                }
            }
        }
        public static class SlideSurveyChoices
        {
            public const string TABLE_NAME = "SLIDE_SURVEY_CHOICES";
            public const string CHOICE_ID = "CHOICE_ID";
            public const string CHOICE_TEXT = "CHOICE_TEXT";
            public const string SLIDE_ID = "SLIDE_ID";
            public const string SCORE = "SCORE";
            public const string IS_NEW = "IS_NEW";
            public const string IS_EDITING = "IS_EDITING";
            public const string IS_DELETED = "IS_DELETED";
            public const string IS_ADDING = "IS_ADDING";
            public const string IS_CHANGED = "IS_CHANGED";
            public static DataTable GetDataTable()
            {
                DataTable dt = new DataTable(TABLE_NAME);
                dt.Columns.Add(CHOICE_ID, typeof(int));
                dt.Columns.Add(CHOICE_TEXT, typeof(int));
                dt.Columns.Add(SLIDE_ID, typeof(int));
                dt.Columns.Add(SCORE, typeof(int));
                DataColumn isNewCol = new DataColumn();
                isNewCol.DefaultValue = "1";
                isNewCol.ColumnName = IS_NEW;
                dt.Columns.Add(isNewCol);
                DataColumn isEditCol = new DataColumn();
                isEditCol.DefaultValue = "0";
                isEditCol.ColumnName = IS_EDITING;
                dt.Columns.Add(isEditCol);
                DataColumn isDelCol = new DataColumn();
                isDelCol.DefaultValue = "0";
                isDelCol.ColumnName = IS_DELETED;
                dt.Columns.Add(isDelCol);
                DataColumn isAddingCol = new DataColumn();
                isAddingCol.DefaultValue = "0";
                isAddingCol.ColumnName = IS_ADDING;
                dt.Columns.Add(isAddingCol);
                AddCulutureResLangColumnsToDataTable(dt);
                DataColumn isChangedCol = new DataColumn();
                isChangedCol.DefaultValue = "0";
                isChangedCol.ColumnName = IS_CHANGED;
                dt.Columns.Add(isChangedCol);
                return dt;
            }
        }
        public static class SlideSurveyQuestions
        {
            public const string TABLE_NAME = "SLIDE_SURVEY_QUESTIONS";
            public const string SURVEY_QUESTION_ID = "SURVEY_QUESTION_ID";
            public const string CATEGORY_ID = "CATEGORY_ID";
            public const string CATEGORY_RES_EN = "CATEGORY_RES_EN";
            public const string CATEGORY_RES_AR = "CATEGORY_RES_AR";
            public const string AUDIO = "AUDIO";
            public const string SURVEY_QUESTION_TEXT = "SURVEY_QUESTION_TEXT";
            public const string SLIDE_ID = "SLIDE_ID";
            public const string IS_NEW = "IS_NEW";
            public const string IS_EDITING = "IS_EDITING";
            public const string IS_CHANGED = "IS_CHANGED";
            public const string IS_DELETED = "IS_DELETED";
            public const string IS_ADDING = "IS_ADDING";
            public static DataTable GetDataTable()
            {
                DataTable dt = new DataTable(TABLE_NAME);
                dt.Columns.Add(SURVEY_QUESTION_ID, typeof(int));
                dt.Columns.Add(CATEGORY_ID, typeof(int));
                dt.Columns.Add(CATEGORY_RES_EN, typeof(string));
                dt.Columns.Add(CATEGORY_RES_AR, typeof(string));
                dt.Columns.Add(AUDIO, typeof(int));
                dt.Columns.Add(SURVEY_QUESTION_TEXT, typeof(int));
                dt.Columns.Add(SLIDE_ID, typeof(int));
                DataColumn isNewCol = new DataColumn();
                isNewCol.DefaultValue = "1";
                isNewCol.ColumnName = IS_NEW;
                dt.Columns.Add(isNewCol);
                DataColumn isEditCol = new DataColumn();
                isEditCol.DefaultValue = "0";
                isEditCol.ColumnName = IS_EDITING;
                dt.Columns.Add(isEditCol);

                DataColumn isChangedCol = new DataColumn();
                isChangedCol.DefaultValue = "0";
                isChangedCol.ColumnName = IS_CHANGED;
                dt.Columns.Add(isChangedCol);

                DataColumn isDelCol = new DataColumn();
                isDelCol.DefaultValue = "0";
                isDelCol.ColumnName = IS_DELETED;
                dt.Columns.Add(isDelCol);
                DataColumn isAddingCol = new DataColumn();
                isAddingCol.DefaultValue = "0";
                isAddingCol.ColumnName = IS_ADDING;
                dt.Columns.Add(isAddingCol);
                AddCulutureResLangColumnsToDataTable(dt);
                return dt;
            }
        }
        public static class RoomType
        {
            public const string TABLE_NAME = "ROOM_TYPE";
            public const string TYPE_EN = "TYPE_EN";
            public const string TYPE_AR = "TYPE_AR";
            public const string ROOM_TYPE_ID = "ROOM_TYPE_ID";
        }
        public static class RoomStatus
        {
            public const string TABLE_NAME = "ROOM_STATUS";
            public const string STATUS_EN = "STATUS_EN";
            public const string STATUS_AR = "STATUS_AR";
            public const string ROOM_STATUS_ID = "ROOM_STATUS_ID";
        }
        public static class TrainingRooms
        {
            public const string TABLE_NAME = "TRAINING_ROOMS";
            public const string ROOM_ID = "ROOM_ID";
            public const string ROOM_NAME = "ROOM_NAME";

            public const string CAPACITY = "CAPACITY";
            public const string ROOM_TYPE = "ROOM_TYPE";
            public const string ROOM_STATUS = "ROOM_STATUS";

            public const string CREATED_BY = "CREATED_BY";
            public const string CREATED_BY_EN = "CREATED_BY_EN";
            public const string CREATED_BY_AR = "CREATED_BY_AR";
            public const string CREATED_ON = "CREATED_ON";

            public static DataTable GetDataTable()
            {
                DataTable dt = new DataTable(TABLE_NAME);
                dt.Columns.Add(ROOM_NAME, typeof(string));
                dt.Columns.Add(ROOM_ID, typeof(int));
                dt.Columns.Add(CREATED_BY, typeof(String));
                dt.Columns.Add(CREATED_BY_EN, typeof(String));
                dt.Columns.Add(CREATED_BY_AR, typeof(String));
                dt.Columns.Add(CREATED_ON, typeof(DateTime));

                dt.Columns.Add(CAPACITY, typeof(int));
                dt.Columns.Add(ROOM_TYPE, typeof(int));
                dt.Columns.Add(ROOM_STATUS, typeof(int));
                return dt;

            }
        }

        public static class Days
        {
            public const string TABLE_NAME = "DAYS";
            public const string DAY_ID = "DAY_ID";
            public const string DAY_EN = "DAY_EN";
            public const string DAY_AR = "DAY_AR";
        }

        public static class HolidayType
        {
            public const string TABLE_NAME = "HOLIDAY_TYPE";
            public const string HOLIDAY_TYPE_ID = "HOLIDAY_TYPE_ID";
            public const string TYPE_EN = "TYPE_EN";
            public const string TYPE_AR = "TYPE_AR";
        }

        public static class HolidayCalendar
        {
            public const string TABLE_NAME = "DTC_HOLIDAY_CALENDAR";

            public const string CALENDAR_ID = "CALENDAR_ID";
            public const string REASON = "REASON";
            public const string CREATED_ON = "CREATED_ON";

            public const string DATE = "DATE";

            public const string DAY = "DAY";
            public const string DAY_EN = "DAY_EN";
            public const string DAY_AR = "DAY_AR";

            public const string TYPE = "TYPE";
            public const string TYPE_EN = "TYPE_EN";
            public const string TYPE_AR = "TYPE_AR";

            public const string CREATED_BY = "CREATED_BY";
            public const string CREATED_BY_EN = "CREATED_BY_EN";
            public const string CREATED_BY_AR = "CREATED_BY_AR";

            public static DataTable GetDataTable()
            {
                DataTable dt = new DataTable(TABLE_NAME);

                dt.Columns.Add(CALENDAR_ID, typeof(int));
                dt.Columns.Add(REASON, typeof(string));
                dt.Columns.Add(DATE, typeof(DateTime));

                dt.Columns.Add(TYPE, typeof(int));
                dt.Columns.Add(TYPE_EN, typeof(string));
                dt.Columns.Add(TYPE_AR, typeof(string));

                dt.Columns.Add(CREATED_BY, typeof(String));
                dt.Columns.Add(CREATED_BY_EN, typeof(String));
                dt.Columns.Add(CREATED_BY_AR, typeof(String));

                dt.Columns.Add(CREATED_ON, typeof(DateTime));


                dt.Columns.Add(DAY, typeof(int));
                dt.Columns.Add(DAY_EN, typeof(string));
                dt.Columns.Add(DAY_AR, typeof(string));


                return dt;

            }
        }

        public static class SlideNavigation
        {
            public const string TABLE_NAME = "SLIDE_NAVIGATION";
            public const string NAVIGATION_CHOICE_ID = "NAVIGATION_CHOICE_ID";
            public const string PLACE_HOLDER_TYPE = "PLACE_HOLDER_TYPE";
            public const string PLACE_HOLDER_NAME_EN = "PLACE_HOLDER_NAME_EN";
            public const string PLACE_HOLDER_NAME_AR = "PLACE_HOLDER_NAME_AR";
            public const string POS_X = "POS_X";
            public const string POS_Y = "POS_Y";
            public const string IS_FIRST_LOC = "IS_FIRST_LOC";
            public const string VIDEO = "VIDEO";
            public const string TITLE = "TITLE";
            public const string TITLE_EN = "TITLE_EN";
            public const string TITLE_AR = "TITLE_AR";
            public const string AUDIO = "AUDIO";
            public const string IMAGE = "IMAGE";
            public const string DEFAULT_TAB = "DEFAULT_TAB";
            public const string DEFAULT_TAB_EN = "DEFAULT_TAB_EN";
            public const string DEFAULT_TAB_AR = "DEFAULT_TAB_AR";
            public const string PIN_IMAGE = "PIN_IMAGE";
            public const string DESCRIPTION = "DESCRIPTION";
            public const string SHOW_TOOL_TIP = "SHOW_TOOL_TIP";
            public const string SLIDE_ID = "SLIDE_ID";
            public const string IS_CHANGED = "IS_CHANGED";
            public const string IS_NEW = "IS_NEW";
            public const string IS_EDITING = "IS_EDITING";
            public const string IS_DELETED = "IS_DELETED";
            public const string IS_ADDING = "IS_ADDING";

            public static DataTable GetDataTable()
            {
                DataTable dt = new DataTable(TABLE_NAME);
                dt.Columns.Add(NAVIGATION_CHOICE_ID, typeof(Int64));
                dt.Columns.Add(PLACE_HOLDER_TYPE, typeof(int));
                dt.Columns.Add(DEFAULT_TAB, typeof(int));
                dt.Columns.Add(DEFAULT_TAB_EN, typeof(string));
                dt.Columns.Add(DEFAULT_TAB_AR, typeof(string));
                dt.Columns.Add(PLACE_HOLDER_NAME_EN, typeof(string));
                dt.Columns.Add(PLACE_HOLDER_NAME_AR, typeof(string));
                dt.Columns.Add(POS_X, typeof(int));
                dt.Columns.Add(POS_Y, typeof(int));
                dt.Columns.Add(IS_FIRST_LOC, typeof(String));
                dt.Columns.Add(TITLE, typeof(int));
                dt.Columns.Add(TITLE_EN, typeof(String));
                dt.Columns.Add(TITLE_AR, typeof(String));
                dt.Columns.Add(VIDEO, typeof(int));
                dt.Columns.Add(AUDIO, typeof(int));
                dt.Columns.Add(IMAGE, typeof(int));
                dt.Columns.Add(PIN_IMAGE, typeof(String));
                dt.Columns.Add(DESCRIPTION, typeof(int));
                dt.Columns.Add(SHOW_TOOL_TIP, typeof(string));
                dt.Columns.Add(SLIDE_ID, typeof(Int64));

                DataColumn isNewCol = new DataColumn();
                isNewCol.DefaultValue = "1";
                isNewCol.ColumnName = IS_NEW;
                dt.Columns.Add(isNewCol);

                DataColumn isEditCol = new DataColumn();
                isEditCol.DefaultValue = "0";
                isEditCol.ColumnName = IS_EDITING;
                dt.Columns.Add(isEditCol);
                DataColumn isChangedCol = new DataColumn();
                isChangedCol.DefaultValue = "0";
                isChangedCol.ColumnName = IS_CHANGED;
                dt.Columns.Add(isChangedCol);

                DataColumn isDelCol = new DataColumn();
                isDelCol.DefaultValue = "0";
                isDelCol.ColumnName = IS_DELETED;
                dt.Columns.Add(isDelCol);

                DataColumn isAddingCol = new DataColumn();
                isAddingCol.DefaultValue = "0";
                isAddingCol.ColumnName = IS_ADDING;
                dt.Columns.Add(isAddingCol);
                return dt;
            }
        }

        public static class PlaceHolderType
        {
            public const string TABLE_NAME = "PLACE_HOLDER_TYPE";
            public const string PLACE_HOLDER_TYPE_ID = "PLACE_HOLDER_TYPE_ID";
            public const string TYPE_EN = "TYPE_EN";
            public const string TYPE_AR = "TYPE_AR";
        }

        public static class SlideNavigationLinks
        {
            public const string TABLE_NAME = "SLIDE_NAV_LINKS";
            public const string NAVIGATION_CHOICE_ID = "NAVIGATION_CHOICE_ID";
            public const string SLIDE_NAV_LINK_ID = "SLIDE_NAV_LINK_ID";
            public const string TYPE = "TYPE";
            public const string FILE_LINK = "FILE_LINK";
            public const string FILE_NAME_EN = "FILE_NAME_EN";
            public const string FILE_NAME_AR = "FILE_NAME_AR";
            public const string DESCRIPTION = "DESCRIPTION";
            public const string IS_NEW = "IS_NEW";
            public const string IS_EDITING = "IS_EDITING";
            public const string IS_DELETED = "IS_DELETED";
            public const string IS_ADDING = "IS_ADDING";
            public const string IS_CHANGED = "IS_CHANGED";

            public static DataTable GetDataTable()
            {
                DataTable dt = new DataTable(TABLE_NAME);
                dt.Columns.Add(SLIDE_NAV_LINK_ID, typeof(Int64));
                dt.Columns.Add(NAVIGATION_CHOICE_ID, typeof(Int64));
                dt.Columns.Add(DESCRIPTION, typeof(int));
                dt.Columns.Add(FILE_LINK, typeof(int));
                dt.Columns.Add(FILE_NAME_EN, typeof(string));
                dt.Columns.Add(FILE_NAME_AR, typeof(string));
                dt.Columns.Add(TYPE, typeof(int));
                dt.Columns.Add(CultureResources.RES_EN, typeof(string));
                dt.Columns.Add(CultureResources.RES_AR, typeof(string));
                DataColumn isNewCol = new DataColumn();
                isNewCol.DefaultValue = "1";
                isNewCol.ColumnName = IS_NEW;
                dt.Columns.Add(isNewCol);

                DataColumn isChangedCol = new DataColumn();
                isChangedCol.DefaultValue = "1";
                isChangedCol.ColumnName = IS_CHANGED;
                dt.Columns.Add(isChangedCol);

                DataColumn isEditCol = new DataColumn();
                isEditCol.DefaultValue = "0";
                isEditCol.ColumnName = IS_EDITING;
                dt.Columns.Add(isEditCol);

                DataColumn isDelCol = new DataColumn();
                isDelCol.DefaultValue = "0";
                isDelCol.ColumnName = IS_DELETED;
                dt.Columns.Add(isDelCol);

                DataColumn isAddingCol = new DataColumn();
                isAddingCol.DefaultValue = "0";
                isAddingCol.ColumnName = IS_ADDING;
                dt.Columns.Add(isAddingCol);

                return dt;
            }
        }
        public static class CultureXML
        {
            public const string TABLE_NAME = "CULTURE_XML";
            public const string XML_ID = "XML_ID";
            public const string XML_EN = "XML_EN";
            public const string XML_AR = "XML_AR";
            public const string XML_UR = "XML_UR";

            public static DataTable GetDataTable()
            {
                DataTable dt = new DataTable(TABLE_NAME);
                dt.Columns.Add(XML_ID, typeof(Int64));
                dt.Columns.Add(XML_EN, typeof(String));
                dt.Columns.Add(XML_AR, typeof(String));
                dt.Columns.Add(XML_UR, typeof(String));

                return dt;
            }
        }
        public class SP_USP_SlideCultureXML
        {
            public const string SP_NAME = "usp_SlideCultureXML";
            public const string ERROR_MESSAGE = "ERROR_MESSAGE";
            public SP_USP_SlideCultureXML(string refId, string xmlId, string slideTypeId)
            {

                this.xmlId.ParamValue = xmlId;
                list.Add(this.xmlId);

                this.refId.ParamValue = refId;
                list.Add(this.refId);

                this.slideTypeId.ParamValue = slideTypeId;
                list.Add(this.slideTypeId);
            }
            private List<StoredProcedureParams> list = new List<StoredProcedureParams>();
            public List<StoredProcedureParams> ParamsList { get { return this.list; } }
            public StoredProcedureParams refId = new StoredProcedureParams("@REF_ID", DbType.String);
            public StoredProcedureParams xmlId = new StoredProcedureParams("@XML_ID", DbType.String);
            public StoredProcedureParams slideTypeId = new StoredProcedureParams("@TYPE_ID", DbType.String);


        }

        public static class Department
        {
            public const string TABLE_NAME = "DTC_DEPARTMENTS";
            public const string DEPTT_ID = "DEPTT_ID";
            public const string DEPTT_NAME_EN = "DEPTT_NAME_EN";
            public const string DEPTT_NAME_AR = "DEPTT_NAME_AR";
            public const string IS_DELETED = "IS_DELETED";

        }

        public static class VehicleTypes
        {
            public const string TABLE_NAME = "SUB_SERVICE";
            public const string ID = "ID";
            public const string NAME_EN = "NAME_EN";
            public const string NAME_AR = "NAME_AR";

        }

        public class SP_USP_PersistSurveyResponse
        {
            public const string SP_NAME = "usp_PersistSurveyResponse";
            public const string ERROR_MESSAGE = "ERROR_MESSAGE";
            public SP_USP_PersistSurveyResponse(string personId, string responseSelectClause, string slideId)
            {

                this.responseSelectClause.ParamValue = responseSelectClause;
                list.Add(this.responseSelectClause);

                this.personId.ParamValue = personId;
                list.Add(this.personId);

                this.slideId.ParamValue = slideId;
                list.Add(this.slideId);
            }
            private List<StoredProcedureParams> list = new List<StoredProcedureParams>();
            public List<StoredProcedureParams> ParamsList { get { return this.list; } }
            public StoredProcedureParams personId = new StoredProcedureParams("@PERSON_ID", DbType.String);
            public StoredProcedureParams responseSelectClause = new StoredProcedureParams("@RESPONSE_SELECT_CLAUSE", DbType.String);
            public StoredProcedureParams slideId = new StoredProcedureParams("@SLIDE_ID", DbType.String);


        }

        public static class MysteryShopperHeader
        {
            public const string TABLE_NAME = "MYSTERY_SHOPPER_HEADER";
            public const string MYSTERY_SHOP_ID = "MYSTERY_SHOP_ID";
            public const string CREATED_ON = "CREATED_ON";
            public const string CREATED_BY = "CREATED_BY";
            public const string PHASE = "PHASE";
            public const string YEAR = "YEAR";
            public static DataTable GetDataTable()
            {
                DataTable dt = new DataTable(TABLE_NAME);
                dt.Columns.Add(MYSTERY_SHOP_ID, typeof(Int64));
                dt.Columns.Add(CREATED_BY, typeof(string));
                dt.Columns.Add(CREATED_ON, typeof(DateTime));
                dt.Columns.Add(PHASE, typeof(int));
                dt.Columns.Add(YEAR, typeof(string));
                return dt;
            }
        }

        public static class MysteryShopperData
        {
            public const string TABLE_NAME = "MYSTERY_SHOPPER_DATA";
            public const string MYSTERY_SHOP_ID = "MYSTERY_SHOP_ID";
            public const string JOB_ID = "JOB_ID";
            public const string PERSON_ID = "PERSON_ID";
            public const string DRIVER_ID = "DRIVER_ID";
            public const string VISIT_DATE = "VISIT_DATE";
            public const string VISIT_TIME = "VISIT_TIME";
            public const string POINTS_OBTAINED = "POINTS_OBTAINED";
            public const string TOTAL_POINTS = "TOTAL_POINTS";
            public const string RESULT_PERCENT = "RESULT_PERCENT";

            public const string PHASE = "PHASE";
            public const string YEAR = "YEAR";
            public const string VEHICLE_NUM = "VEHICLE_NUM";

            public static DataTable GetDataTable()
            {
                DataTable dt = new DataTable(TABLE_NAME);
                dt.Columns.Add(JOB_ID, typeof(string));
                dt.Columns.Add(PERSON_ID, typeof(Int64));
                dt.Columns.Add(DRIVER_ID, typeof(int));
                dt.Columns.Add(VISIT_DATE, typeof(DateTime));
                dt.Columns.Add(VISIT_TIME, typeof(string));
                dt.Columns.Add(POINTS_OBTAINED, typeof(int));
                dt.Columns.Add(TOTAL_POINTS, typeof(int));
                dt.Columns.Add(RESULT_PERCENT, typeof(Double));
                dt.Columns.Add(MYSTERY_SHOP_ID, typeof(Int64));
                dt.Columns.Add(PHASE, typeof(int));
                dt.Columns.Add(YEAR, typeof(string));
                dt.Columns.Add(VEHICLE_NUM, typeof(string));
                return dt;
            }
        }

        public class SP_USP_ImportMysteryShopper
        {

            public const string SP_NAME = "usp_ImportMysteryShopper";
            public SP_USP_ImportMysteryShopper(string createdBy, string phase, string year, string excelData)
            {
                this.createdBy.ParamValue = createdBy;
                list.Add(this.createdBy);
                this.phase.ParamValue = phase;
                list.Add(this.phase);
                this.year.ParamValue = year;
                list.Add(this.year);
                this.excelData.ParamValue = excelData.ToString();
                list.Add(this.excelData);
            }

            private List<StoredProcedureParams> list = new List<StoredProcedureParams>();
            public List<StoredProcedureParams> ParamsList { get { return this.list; } }
            public StoredProcedureParams createdBy = new StoredProcedureParams("@CREATED_BY", DbType.String);
            public StoredProcedureParams phase = new StoredProcedureParams("@PHASE", DbType.String);
            public StoredProcedureParams year = new StoredProcedureParams("@YEAR", DbType.String);
            public StoredProcedureParams excelData = new StoredProcedureParams("@excelData ", DbType.Xml);

        }
        public class SP_USP_GetMysteryShopperById
        {

            public const string SP_NAME = "usp_GetMysteryShopperById";
            public const string ERROR_MESSAGE = "ERROR_MESSAGE";
            public SP_USP_GetMysteryShopperById(string id)
            {
                this.Id.ParamValue = id;
                list.Add(this.Id);
            }
            private List<StoredProcedureParams> list = new List<StoredProcedureParams>();
            public List<StoredProcedureParams> ParamsList { get { return this.list; } }
            public StoredProcedureParams Id = new StoredProcedureParams("@MYSTERY_SHOP_ID", DbType.Int64);


        }

        public class SP_USP_GetMysteryShopperReport
        {

            public const string SP_NAME = "usp_MysteryShopperReport";
            public const string ERROR_MESSAGE = "ERROR_MESSAGE";
            public SP_USP_GetMysteryShopperReport(string year)
            {
                this.year.ParamValue = year;
                list.Add(this.year);

            }
            private List<StoredProcedureParams> list = new List<StoredProcedureParams>();
            public List<StoredProcedureParams> ParamsList { get { return this.list; } }
            public StoredProcedureParams year = new StoredProcedureParams("@YEAR", DbType.String);



        }

        public class SP_USP_PersistTrainingCultureXML
        {
            public const string SP_NAME = "usp_PersistTrainingCultureXML";
            public const string ERROR_MESSAGE = "ERROR_MESSAGE";
            public SP_USP_PersistTrainingCultureXML(string refId, string xmlId)
            {

                this.xmlId.ParamValue = xmlId;
                list.Add(this.xmlId);

                this.refId.ParamValue = refId;
                list.Add(this.refId);

            }
            private List<StoredProcedureParams> list = new List<StoredProcedureParams>();
            public List<StoredProcedureParams> ParamsList { get { return this.list; } }
            public StoredProcedureParams refId = new StoredProcedureParams("@REF_ID", DbType.String);
            public StoredProcedureParams xmlId = new StoredProcedureParams("@XML_ID", DbType.String);



        }

        public static class DrivingAssessmentCriteria
        {
            public const string TABLE_NAME = "DRIVING_ASSESSMENT_CRITERIA";
            public const string CRITERIA_ID = "CRITERIA_ID";
            public const string CRITERIA_EN = "CRITERIA_EN";
            public const string CRITERIA_AR = "CRITERIA_AR";
            public const string SEQUENCE = "SEQUENCE";

        }

        public static class DrivingAssessmentTest
        {
            public const string TABLE_NAME = "DRIVING_ASSESSMENT_TEST";
            public const string DRIVING_TEST_ID = "DRIVING_TEST_ID";
            public const string CREATED_ON = "CREATED_ON";
            public const string COMMENTS = "COMMENTS";
            public const string EXAMINER_ID = "EXAMINER_ID";
            public const string EXAMINER_NAME_EN = "EXAMINER_NAME_EN";
            public const string EXAMINER_NAME_AR = "EXAMINER_NAME_AR";
            public const string DRIVER_ID = "DRIVER_ID";
            public const string RESULT = "RESULT";

            public static DataTable GetDataTable()
            {
                DataTable dt = new DataTable(TABLE_NAME);
                dt.Columns.Add(DRIVING_TEST_ID, typeof(Int64));
                dt.Columns.Add(CREATED_ON, typeof(DateTime));
                dt.Columns.Add(COMMENTS, typeof(String));
                dt.Columns.Add(EXAMINER_NAME_EN, typeof(String));
                dt.Columns.Add(EXAMINER_NAME_AR, typeof(String));
                dt.Columns.Add(EXAMINER_ID, typeof(String));
                dt.Columns.Add(DRIVER_ID, typeof(Int64));
                dt.Columns.Add(RESULT, typeof(int));

                return dt;
            }
        }

        public static class DrivingAssessmentImages
        {
            public const string TABLE_NAME = "DRIVING_ASSESSMENT_IMAGES";
            public const string TEST_IMAGE_ID = "TEST_IMAGE_ID";
            public const string IMAGE = "IMAGE";
            public const string IMAGE_NAME = "IMAGE_NAME";
            public const string CREATED_ON = "CREATED_ON";
            public const string CREATED_BY = "CREATED_BY";
            public const string CREATED_BY_EN = "CREATED_BY_EN";
            public const string CREATED_BY_AR = "CREATED_BY_AR";
            public const string DRIVING_TEST_ID = "DRIVING_TEST_ID";

            public static DataTable GetDataTable()
            {
                DataTable dt = new DataTable(TABLE_NAME);

                dt.Columns.Add(TEST_IMAGE_ID, typeof(Int64));
                dt.Columns.Add(IMAGE_NAME, typeof(String));
                dt.Columns.Add(IMAGE, typeof(Byte));
                dt.Columns.Add(CREATED_ON, typeof(DateTime));
                dt.Columns.Add(CREATED_BY, typeof(String));
                dt.Columns.Add(CREATED_BY_EN, typeof(String));
                dt.Columns.Add(CREATED_BY_AR, typeof(String));
                dt.Columns.Add(DRIVING_TEST_ID, typeof(Int64));
                return dt;
            }


        }
        public static class DrivingAssessmentDetails
        {
            public const string TABLE_NAME = "DRIVING_ASSESSMENT_TEST_DETAILS";
            public const string TEST_DETAIL_ID = "TEST_DETAIL_ID";

            public const string DRIVING_TEST_ID = "DRIVING_TEST_ID";
            public const string ASSESSMENT_CRITERIA_ID = "ASSESSMENT_CRITERIA_ID";
            public const string DAY_1 = "DAY_1";
            public const string DAY_2 = "DAY_2";
            public const string DAY_3 = "DAY_3";
            public const string DAY_4 = "DAY_4";
            public const string DAY_5 = "DAY_5";
            public const string DAY_6 = "DAY_6";
            public const string DAY_7 = "DAY_7";
            public const string DAY_8 = "DAY_8";
            public const string DAY_9 = "DAY_9";
            public const string DAY_10 = "DAY_10";
            public const string SUMMARY = "SUMMARY";
            public const string RESULT_COL = "RESULT_COL";
            public const string ROAD_TEST_1 = "ROAD_TEST_1";
            public const string ROAD_TEST_2 = "ROAD_TEST_2";
            public const string ROAD_TEST_3 = "ROAD_TEST_3";

            public static DataTable GetDataTable()
            {
                DataTable dt = new DataTable(TABLE_NAME);

                dt.Columns.Add(TEST_DETAIL_ID, typeof(Int64));
                dt.Columns.Add(DRIVING_TEST_ID, typeof(Int64));
                dt.Columns.Add(ASSESSMENT_CRITERIA_ID, typeof(Int64));
                dt.Columns.Add(DAY_1, typeof(String));
                dt.Columns.Add(DAY_2, typeof(String));
                dt.Columns.Add(DAY_3, typeof(String));
                dt.Columns.Add(DAY_4, typeof(String));
                dt.Columns.Add(DAY_5, typeof(String));
                dt.Columns.Add(DAY_6, typeof(String));
                dt.Columns.Add(DAY_7, typeof(String));
                dt.Columns.Add(DAY_8, typeof(String));
                dt.Columns.Add(DAY_9, typeof(String));
                dt.Columns.Add(DAY_10, typeof(String));
                dt.Columns.Add(SUMMARY, typeof(String));
                dt.Columns.Add(RESULT_COL, typeof(String));
                dt.Columns.Add(ROAD_TEST_1, typeof(String));
                dt.Columns.Add(ROAD_TEST_2, typeof(String));
                dt.Columns.Add(ROAD_TEST_3, typeof(String));
                return dt;
            }
        }

        public class SP_USP_GetDrivingAssessmentTestForDriver
        {
            public const string SP_NAME = "usp_GetDrivingAssessmentTestForDriver";
            public const string MUTILPLE_PERSON = "MUTILPLE_PERSON";
            public const string NO_PERSON = "NO_PERSON";
            public const string ERROR_MESSAGE = "ERROR_MESSAGE";
            public SP_USP_GetDrivingAssessmentTestForDriver(string refId)
            {


                this.refId.ParamValue = refId;
                list.Add(this.refId);

            }
            private List<StoredProcedureParams> list = new List<StoredProcedureParams>();
            public List<StoredProcedureParams> ParamsList { get { return this.list; } }
            public StoredProcedureParams refId = new StoredProcedureParams("@REF_NO", DbType.String);

        }

        public class SP_USP_PersistDrivingAssesmentTest
        {
            public const string SP_NAME = "usp_PersistDrivingAssesmentTest";
            public const string MULTIPLE_PERSONS = "MULTIPLE_PERSONS";
            public const string NO_PERSON = "NO_PERSON";
            public const string ERROR_MESSAGE = "ERROR_MESSAGE";
            public SP_USP_PersistDrivingAssesmentTest(string driverId, string testId, string user, string comments, string result,
                                                       string drivingTestDetails, string drivingTestImages
                                                     )
            {

                this.driverId.ParamValue = driverId;
                list.Add(this.driverId);

                this.testId.ParamValue = string.IsNullOrEmpty(testId) ? "-1" : testId;
                list.Add(this.testId);

                this.user.ParamValue = user;
                list.Add(this.user);

                this.comments.ParamValue = comments;
                list.Add(this.comments);

                this.result.ParamValue = result;
                list.Add(this.result);

                this.drivingTestDetails.ParamValue = drivingTestDetails;
                list.Add(this.drivingTestDetails);

                this.drivingTestImages.ParamValue = drivingTestImages;
                list.Add(this.drivingTestImages);

            }
            private List<StoredProcedureParams> list = new List<StoredProcedureParams>();
            public List<StoredProcedureParams> ParamsList { get { return this.list; } }

            public StoredProcedureParams driverId = new StoredProcedureParams("@DRIVER_ID", DbType.String);
            public StoredProcedureParams testId = new StoredProcedureParams("@DRIVING_ASSESSMENT_TEST_ID", DbType.Int64);
            public StoredProcedureParams user = new StoredProcedureParams("@USER", DbType.String);
            public StoredProcedureParams comments = new StoredProcedureParams("@COMMENTS", DbType.String);
            public StoredProcedureParams result = new StoredProcedureParams("@RESULT", DbType.String);
            public StoredProcedureParams drivingTestDetails = new StoredProcedureParams("@drivingTestDetails", DbType.String);
            public StoredProcedureParams drivingTestImages = new StoredProcedureParams("@drivingTestImages", DbType.String);

        }


        public class SP_USP_TestAnalysis
        {

            public const string SP_NAME = "usp_TestAnalysis";
            public const string ERROR_MESSAGE = "ERROR_MESSAGE";

            public SP_USP_TestAnalysis(string whereClause)
            {
                this.whereClause.ParamValue = whereClause;
                list.Add(this.whereClause);

            }
            private List<StoredProcedureParams> list = new List<StoredProcedureParams>();
            public List<StoredProcedureParams> ParamsList { get { return this.list; } }
            public StoredProcedureParams whereClause = new StoredProcedureParams("@WHERECLAUSE", DbType.String);



        }
        public class SP_USP_CourseCultureXML
        {
            public const string SP_NAME = "usp_CourseCultureXML";
            public const string ERROR_MESSAGE = "ERROR_MESSAGE";
            public SP_USP_CourseCultureXML(string refId, string xmlId)
            {

                this.xmlId.ParamValue = xmlId;
                list.Add(this.xmlId);

                this.refId.ParamValue = refId;
                list.Add(this.refId);


            }
            private List<StoredProcedureParams> list = new List<StoredProcedureParams>();
            public List<StoredProcedureParams> ParamsList { get { return this.list; } }
            public StoredProcedureParams refId = new StoredProcedureParams("@REF_ID", DbType.String);
            public StoredProcedureParams xmlId = new StoredProcedureParams("@XML_ID", DbType.String);



        }

        public static class DefaultTabType
        {
            public const string TABLE_NAME = "DEFAULT_TAB_TYPE";
            public const string DEFAULT_TAB_TYPE_ID = "DEFAULT_TAB_TYPE_ID";
            public const string TYPE_EN = "TYPE_EN";
            public const string TYPE_AR = "TYPE_AR";
        }

        public class SP_USP_SearchTrainingRequests
        {
            public const string SP_NAME = "usp_SearchTrainingRequests";
            public const string ERROR_MESSAGE = "ERROR_MESSAGE";
            public SP_USP_SearchTrainingRequests(string orderBy, int pageToRetrieve, int recordsPerPage, string whereClause)
            {

                this.orderBy.ParamValue = orderBy;
                list.Add(this.orderBy);

                this.recordsPerPage.ParamValue = recordsPerPage.ToString();
                list.Add(this.recordsPerPage);

                this.pageToRetrieve.ParamValue = pageToRetrieve.ToString();
                list.Add(this.pageToRetrieve);


                this.whereClause.ParamValue = whereClause.ToString();
                list.Add(this.whereClause);

            }
            private List<StoredProcedureParams> list = new List<StoredProcedureParams>();
            public List<StoredProcedureParams> ParamsList { get { return this.list; } }
            public StoredProcedureParams orderBy = new StoredProcedureParams("@ORDER_BY", DbType.String);
            public StoredProcedureParams recordsPerPage = new StoredProcedureParams("@RECPERPAGE", DbType.Int16);
            public StoredProcedureParams pageToRetrieve = new StoredProcedureParams("@CURRENTPAGE", DbType.Int16);
            public StoredProcedureParams whereClause = new StoredProcedureParams("@WHERECLAUSE", DbType.String);

        }

        public class SP_USP_GetTestWiseQuestionAllocation
        {

            public const string SP_NAME = "eLearninghelper_DetailedExamOutcome";
            public const string ERROR_MESSAGE = "ERROR_MESSAGE";
            public SP_USP_GetTestWiseQuestionAllocation(string testNum)
            {
                this.testNum.ParamValue = testNum;
                list.Add(this.testNum);

            }
            private List<StoredProcedureParams> list = new List<StoredProcedureParams>();
            public List<StoredProcedureParams> ParamsList { get { return this.list; } }
            public StoredProcedureParams testNum = new StoredProcedureParams("@TestNum", DbType.String);



        }

        public class SP_USP_GetTrainerActivityReport
        {

            public const string SP_NAME = "usp_TrainerActivityReport";
            public const string ERROR_MESSAGE = "ERROR_MESSAGE";
            public SP_USP_GetTrainerActivityReport(string trainer, string startedFrom, string startedTo)
            {
                this.trainer.ParamValue = trainer;
                list.Add(this.trainer);
                this.startedFrom.ParamValue = startedFrom;
                list.Add(this.startedFrom);
                this.startedTo.ParamValue = startedTo;
                list.Add(this.startedTo);
            }
            private List<StoredProcedureParams> list = new List<StoredProcedureParams>();
            public List<StoredProcedureParams> ParamsList { get { return this.list; } }
            public StoredProcedureParams trainer = new StoredProcedureParams("@TRAINER_ID", DbType.String);
            public StoredProcedureParams startedFrom = new StoredProcedureParams("@FROM", DbType.String);
            public StoredProcedureParams startedTo = new StoredProcedureParams("@TO", DbType.String);

        }

        public static class TrainerActivityLog
        {
            public const string TABLE_NAME = "TRAINER_ACTIVITY_LOG";
            public const string TRAINER_ACTIVITY_LOG_ID = "TRAINER_ACTIVITY_LOG_ID";
            public const string TRAINER_ID = "TRAINER_ID";
            public const string STARTED_ON = "STARTED_ON";
            public const string COURSE_ID = "COURSE_ID";
            public const string SLIDE_ID = "SLIDE_ID";
            public const string TRAINING_ID = "TRAINING_ID";
            public const string FINISHED_ON = "FINISHED_ON";


            public static DataTable GetDataTable()
            {
                DataTable dt = new DataTable(TABLE_NAME);

                dt.Columns.Add(TRAINER_ACTIVITY_LOG_ID, typeof(Int64));
                dt.Columns.Add(TRAINER_ID, typeof(String));
                dt.Columns.Add(STARTED_ON, typeof(DateTime));
                dt.Columns.Add(COURSE_ID, typeof(Int64));
                dt.Columns.Add(SLIDE_ID, typeof(Int64));
                dt.Columns.Add(TRAINING_ID, typeof(Int64));
                dt.Columns.Add(FINISHED_ON, typeof(DateTime));

                return dt;
            }


        }

        public class SP_USP_AddTrainerActivityLog
        {

            public const string SP_NAME = "usp_AddTrainerActivityLog";
            public const string ERROR_MESSAGE = "ERROR_MESSAGE";
            public SP_USP_AddTrainerActivityLog(string eventDesc, string trainerId, string trainingId, string courseId, string slideId, string trainingScheduleId)
            {
                this.eventDesc.ParamValue = eventDesc;
                list.Add(this.eventDesc);
                this.trainerId.ParamValue = trainerId;
                list.Add(this.trainerId);
                this.trainingId.ParamValue = trainingId;
                list.Add(this.trainingId);
                this.courseId.ParamValue = courseId;
                list.Add(this.courseId);
                this.slideId.ParamValue = slideId;
                list.Add(this.slideId);
                this.trainingScheduleId.ParamValue = trainingScheduleId;
                list.Add(this.trainingScheduleId);
            }
            private List<StoredProcedureParams> list = new List<StoredProcedureParams>();
            public List<StoredProcedureParams> ParamsList { get { return this.list; } }
            public StoredProcedureParams eventDesc = new StoredProcedureParams("@EVENT", DbType.String);
            public StoredProcedureParams trainerId = new StoredProcedureParams("@TRAINER_ID", DbType.String);
            public StoredProcedureParams trainingId = new StoredProcedureParams("@TRAINING_ID", DbType.String);
            public StoredProcedureParams courseId = new StoredProcedureParams("@COURSE_ID", DbType.String);
            public StoredProcedureParams slideId = new StoredProcedureParams("@SLIDE_ID", DbType.String);
            public StoredProcedureParams trainingScheduleId = new StoredProcedureParams("@SCHEDULE_ID", DbType.String);

        }

        public class SP_USP_GetDashboardReport
        {

            public const string SP_NAME = "usp_DashBoard";
            public const string ERROR_MESSAGE = "ERROR_MESSAGE";
            public SP_USP_GetDashboardReport()
            {

            }
            private List<StoredProcedureParams> list = new List<StoredProcedureParams>();
            public List<StoredProcedureParams> ParamsList { get { return this.list; } }

        }

        public static class TrainingSchedule
        {
            public const string TABLE_NAME = "TRAINING_SCHEDULE";
            public const string SCHEDULE_ID = "SCHEDULE_ID";
            public const string TRAINING_ID = "TRAINING_ID";
            public const string DATE = "DATE";
            public const string ROOM_ID = "ROOM_ID";
            public const string TRAINER_ID = "TRAINER_ID";
            public const string SCHEDULE_STATUS = "SCHEDULE_STATUS";
            public const string DAY = "DAY";
            public const string FORMATTED_DATE = "FORMATTED_DATE";
            public const string FORMATTED_COMPLETED_ON = "FORMATTED_COMPLETED_ON";
            public const string COMPLETED_ON = "COMPLETED_ON";
            public const string SHOW_MODIFY_ICON = "SHOW_MODIFY_ICON";

            public static DataTable GetDataTable()
            {
                DataTable dt = new DataTable(TABLE_NAME);

                dt.Columns.Add(SCHEDULE_ID, typeof(Int64));
                dt.Columns.Add(TRAINING_ID, typeof(Int64));
                dt.Columns.Add(DATE, typeof(DateTime));
                dt.Columns.Add(ROOM_ID, typeof(Int64));
                dt.Columns.Add(DAY, typeof(int));
                dt.Columns.Add(TRAINER_ID, typeof(String));
                dt.Columns.Add(SCHEDULE_STATUS, typeof(int));
                dt.Columns.Add(FORMATTED_DATE, typeof(int));
                dt.Columns.Add(FORMATTED_COMPLETED_ON, typeof(int));
                dt.Columns.Add(COMPLETED_ON, typeof(DateTime));
                dt.Columns.Add(SHOW_MODIFY_ICON, typeof(String));


                return dt;
            }


        }

        public static class TrainingInstance
        {
            public const string TABLE_NAME = "TRAINING_INSTANCE";
            public const string TRAINING_ID = "TRAINING_ID";
            public const string CREATED_ON = "CREATED_ON";
            public const string START_DATE = "START_DATE";
            public const string TRAINING_TEMP_ID = "TRAINING_TEMP_ID";
            public const string NAME_EN = "NAME_EN";
            public const string NAME_AR = "NAME_AR";
            public const string DURATION = "DURATION";
            public const string TRAINING_NUM = "TRAINING_NUM";
            public const string COMPLETED_ON = "COMPLETED_ON";
            public const string TOTAL_PARTICIPANTS = "TOTAL_PARTICIPANTS";
            public const string STATUS = "STATUS";
            public const string STATUS_EN = "STATUS_EN";
            public const string STATUS_AR = "STATUS_AR";
            public const string FORMATTED_START_DATE = "FORMATTED_START_DATE";
            public const string FORMATTED_COMPLETED_ON = "FORMATTED_COMPLETED_ON";
            public const string FORMATTED_CREATED_ON = "FORMATTED_CREATED_ON";

            public static DataTable GetDataTable()
            {
                DataTable dt = new DataTable(TABLE_NAME);

                dt.Columns.Add(TRAINING_ID, typeof(Int64));
                dt.Columns.Add(START_DATE, typeof(DateTime));
                dt.Columns.Add(FORMATTED_START_DATE, typeof(string));
                dt.Columns.Add(CREATED_ON, typeof(DateTime));
                dt.Columns.Add(FORMATTED_CREATED_ON, typeof(string));
                dt.Columns.Add(DURATION, typeof(int));
                dt.Columns.Add(TRAINING_TEMP_ID, typeof(Int64));
                dt.Columns.Add(NAME_EN, typeof(string));
                dt.Columns.Add(NAME_AR, typeof(string));
                dt.Columns.Add(TRAINING_NUM, typeof(String));
                dt.Columns.Add(COMPLETED_ON, typeof(DateTime));
                dt.Columns.Add(FORMATTED_COMPLETED_ON, typeof(string));
                dt.Columns.Add(TOTAL_PARTICIPANTS, typeof(int));
                dt.Columns.Add(STATUS, typeof(int));
                dt.Columns.Add(STATUS_EN, typeof(string));
                dt.Columns.Add(STATUS_AR, typeof(string));
                return dt;
            }


        }

        public class SP_USP_SearchTrainingInstances
        {
            public const string SP_NAME = "usp_SearchTrainingInstances";
            public const string ERROR_MESSAGE = "ERROR_MESSAGE";
            public SP_USP_SearchTrainingInstances(string orderBy, int pageToRetrieve, int recordsPerPage, string whereClause)
            {

                this.orderBy.ParamValue = orderBy;
                list.Add(this.orderBy);

                this.recordsPerPage.ParamValue = recordsPerPage.ToString();
                list.Add(this.recordsPerPage);

                this.pageToRetrieve.ParamValue = pageToRetrieve.ToString();
                list.Add(this.pageToRetrieve);


                this.whereClause.ParamValue = whereClause.ToString();
                list.Add(this.whereClause);

            }
            private List<StoredProcedureParams> list = new List<StoredProcedureParams>();
            public List<StoredProcedureParams> ParamsList { get { return this.list; } }
            public StoredProcedureParams orderBy = new StoredProcedureParams("@ORDER_BY", DbType.String);
            public StoredProcedureParams recordsPerPage = new StoredProcedureParams("@RECPERPAGE", DbType.Int16);
            public StoredProcedureParams pageToRetrieve = new StoredProcedureParams("@CURRENTPAGE", DbType.Int16);
            public StoredProcedureParams whereClause = new StoredProcedureParams("@WHERECLAUSE", DbType.String);

        }

        public static class TrainingStatus
        {
            public const string TABLE_NAME = "TRAINING_STATUS";
            public const string STATUS_ID = "STATUS_ID";
            public const string STATUS_EN = "STATUS_EN";
            public const string STATUS_AR = "STATUS_AR";

        }

        public class SP_USP_GetTrainingsById
        {

            public const string SP_NAME = "usp_GetTrainingsById";
            public const string ERROR_MESSAGE = "ERROR_MESSAGE";
            public SP_USP_GetTrainingsById(string id)
            {
                this.Id.ParamValue = id;
                list.Add(this.Id);
            }
            private List<StoredProcedureParams> list = new List<StoredProcedureParams>();
            public List<StoredProcedureParams> ParamsList { get { return this.list; } }
            public StoredProcedureParams Id = new StoredProcedureParams("@TRAINING_ID", DbType.Int64);

        }
        public class SP_USP_GetTraineeAttendanceReport
        {

            public const string SP_NAME = "usp_TraineeAttendanceReport";
            public const string ERROR_MESSAGE = "ERROR_MESSAGE";
            public SP_USP_GetTraineeAttendanceReport(string traineeName, string trainingName, string startedFrom, string startedTo,
                                                     string completedFrom, string completedTo)
            {
                this.startedFrom.ParamValue = startedFrom;
                list.Add(this.startedFrom);

                this.startedTo.ParamValue = startedTo;
                list.Add(this.startedTo);

                this.traineeName.ParamValue = traineeName;
                list.Add(this.traineeName);

                this.trainingName.ParamValue = trainingName;
                list.Add(this.trainingName);

                this.completedFrom.ParamValue = completedFrom;
                list.Add(this.completedFrom);

                this.completedTo.ParamValue = completedTo;
                list.Add(this.completedTo);

            }
            private List<StoredProcedureParams> list = new List<StoredProcedureParams>();
            public List<StoredProcedureParams> ParamsList { get { return this.list; } }
            public StoredProcedureParams startedTo = new StoredProcedureParams("@STARTED_TO", DbType.String);
            public StoredProcedureParams startedFrom = new StoredProcedureParams("@STARTED_FROM", DbType.String);
            public StoredProcedureParams trainingName = new StoredProcedureParams("@TRAINING_NAME_NUM", DbType.String);
            public StoredProcedureParams traineeName = new StoredProcedureParams("@TRAINEE_NAME_NUM", DbType.String);
            public StoredProcedureParams completedFrom = new StoredProcedureParams("@COMPLETED_FROM", DbType.String);
            public StoredProcedureParams completedTo = new StoredProcedureParams("@COMPLETED_TO", DbType.String);


        }
        public class SP_ModifyTraining
        {

            public const string SP_NAME = "ModifyTraining";
            public const string ERROR_MESSAGE = "ERROR_MESSAGE";
            public SP_ModifyTraining(string trainingId, string trainingSchId, string scheduledDate, string trainerId, string modifiedBy, string cascadeSchedule)
            {
                this.trainingId.ParamValue = trainingId;
                list.Add(this.trainingId);

                this.trainingSchId.ParamValue = trainingSchId;
                list.Add(this.trainingSchId);

                this.scheduledDate.ParamValue = scheduledDate;
                list.Add(this.scheduledDate);

                this.trainerId.ParamValue = trainerId;
                list.Add(this.trainerId);

                this.modifiedBy.ParamValue = modifiedBy;
                list.Add(this.modifiedBy);

                // this.cascadeSchedule.ParamValue = cascadeSchedule;
                //list.Add(this.cascadeSchedule);

            }
            private List<StoredProcedureParams> list = new List<StoredProcedureParams>();
            public List<StoredProcedureParams> ParamsList { get { return this.list; } }
            public StoredProcedureParams trainingId = new StoredProcedureParams("@TRAINING_ID", DbType.String);
            public StoredProcedureParams trainingSchId = new StoredProcedureParams("@TRAINING_SCHEDULE_ID", DbType.String);
            public StoredProcedureParams scheduledDate = new StoredProcedureParams("@SCHEDULED_DATE", DbType.String);
            public StoredProcedureParams trainerId = new StoredProcedureParams("@TRAINERID", DbType.String);
            public StoredProcedureParams modifiedBy = new StoredProcedureParams("@MODIFIEDBY", DbType.String);
            // public StoredProcedureParams cascadeSchedule = new StoredProcedureParams("@CASCADE_SCHEDULE", DbType.String);
        }

        public static class Trainer
        {
            public const string TABLE_NAME = "TRAINER";
            public const string TRAINER_ALIAS = "TRAINER_ALIAS";
            public const string USER_ID = "USER_ID";
            public const string TRAINER_ALIAS_ID = "TRAINER_ALIAS_ID";
            public const string START_TIME = "START_TIME";
            public const string END_TIME = "END_TIME";

            public static DataTable GetDataTable()
            {
                DataTable dt = new DataTable(TABLE_NAME);

                dt.Columns.Add(TRAINER_ALIAS, typeof(String));
                dt.Columns.Add(USER_ID, typeof(String));
                dt.Columns.Add(TRAINER_ALIAS_ID, typeof(String));
                dt.Columns.Add(START_TIME, typeof(String));
                dt.Columns.Add(END_TIME, typeof(String));
                return dt;
            }


        }

        public static class Message
        {
            public const string TABLE_NAME = "MESSAGE";
            public const string MESSAGE_ID = "MESSAGE_ID";
            public const string MESSAGE_TEMP_ID = "MESSAGE_TEMP_ID";
            public const string MOBILE_NO = "MOBILE_NO";
            public const string RECEIPIENT_NAME = "RECEIPIENT_NAME";
            public const string RECEIPIENT_REF_NUM = "RECEIPIENT_REF_NUM";
            public const string PARAM1 = "PARAM1";
            public const string PARAM2 = "PARAM2";
            public const string PARAM3 = "PARAM3";
            public const string PARAM4 = "PARAM4";
            public const string PARAM5 = "PARAM5";
            public const string PARAM6 = "PARAM6";
            public const string PARAM7 = "PARAM7";
            public const string PARAM8 = "PARAM8";
            public const string PARAM9 = "PARAM9";
            public const string PARAM10 = "PARAM10";
            public const string STATUS = "STATUS";

            public static DataTable GetDataTable()
            {
                DataTable dt = new DataTable(TABLE_NAME);
                dt.Columns.Add(MESSAGE_ID, typeof(Int64));
                dt.Columns.Add(MESSAGE_TEMP_ID, typeof(string));
                dt.Columns.Add(MOBILE_NO, typeof(string));
                dt.Columns.Add(RECEIPIENT_NAME, typeof(string));
                dt.Columns.Add(RECEIPIENT_REF_NUM, typeof(string));
                dt.Columns.Add(PARAM1, typeof(string));
                dt.Columns.Add(PARAM2, typeof(string));
                dt.Columns.Add(PARAM3, typeof(string));
                dt.Columns.Add(PARAM4, typeof(string));
                dt.Columns.Add(PARAM5, typeof(string));
                dt.Columns.Add(PARAM6, typeof(string));
                dt.Columns.Add(PARAM7, typeof(string));
                dt.Columns.Add(PARAM8, typeof(string));
                dt.Columns.Add(PARAM9, typeof(string));
                dt.Columns.Add(PARAM10, typeof(string));
                dt.Columns.Add(STATUS, typeof(int));


                return dt;
            }

        }


        public class SP_GetQueuedMessages
        {

            public const string SP_NAME = "GetQueuedMessages";
            public const string ERROR_MESSAGE = "ERROR_MESSAGE";
            public SP_GetQueuedMessages()
            {


            }
            private List<StoredProcedureParams> list = new List<StoredProcedureParams>();
            public List<StoredProcedureParams> ParamsList { get { return this.list; } }

        }

        //Added by M.Tariq on 02 Jan. 2017

        public static class Centers
        {
            public const string TABLE_NAME = "CENTERS";
            public const string CENTER_ID = "ID";
            public const string CENTER_NAME_EN = "NAME_EN";
            public const string CENTER_NAME_AR = "NAME_AR";
            public const string CENTER_ADDRESS_EN = "ADDRESS_EN";
            public const string CENTER_ADDRESS_AR = "ADDRESS_AR";
            public const string CENTER_PHONE = "PHONE";
            public const string CENTER_DESCRIPTION = "DESCRIPTION";

        }

        public static class Branches
        {
            public const string TABLE_NAME = "BRANCHES";
            public const string BRANCH_ID = "ID";
            public const string BRANCH_NAME_EN = "NAME_EN";
            public const string BRANCH_NAME_AR = "NAME_AR";
            public const string BRANCH_ADDRESS_EN = "ADDRESS_EN";
            public const string BRANCH_ADDRESS_AR = "ADDRESS_AR";
            public const string BRANCH_DESCRIPTION = "DESCRIPTION";
            public const string BRANCH_IS_ACTIVE = "IS_ACTIVE";
        }

        public static class Languages
        {
            public const string TABLE_NAME = "LANGUAGES";
            public const string LANGUAGE_ID = "ID";
            public const string LANGUAGE_NAME_EN = "NAME_EN";
            public const string LANGUAGE_NAME_AR = "NAME_AR";
            public const string LANGUAGE_SHORT_CODE = "SHORT_CODE";
            public const string LANGUAGE_IS_ACTIVE = "IS_ACTIVE";
        }

        public static class NewDepartment
        {
            public const string TABLE_NAME = "DEPARTMENTS";
            public const string DEPTT_ID = "ID";
            public const string DEPTT_NAME_EN = "NAME_EN";
            public const string DEPTT_NAME_AR = "NAME_AR";
            public const string SHORT_CODE = "SHORT_CODE";
            public const string IS_ACTIVE = "IS_ACTIVE";

        }
        public static class CUSTOMER_SERVICE_EXAM
        {
            public const string ID = "ID";
            public const string TABLE_NAME = "CUSTOMER_SERVICE_EXAM";
            public const string CUSTOMER_ID = "CUSTOMER_ID";
            public const string EXAM_ID = "EXAM_ID";
            public const string SUB_SERVICE_ID = "SUB_SERVICE_ID";
            public const string EXAM_DATE = "EXAM_DATE";
            //public const string EXAM_TIME = "EXAM_TIME";
            public const string CANCELLED = "CANCELLED";
            public const string EXAM_RESULT = "EXAM_RESULT";
            public const string CREATED_ON = "CREATED_ON";
            public const string CREATED_BY = "CREATED_BY";
            public const string UPDATED_ON = "UPDATED_ON";
            public const string UPDATED_BY = "UPDATED_BY";
            public const string EMIRATE_ID = "EMIRATE_ID";
            public const string BRANCH_ID = "BRANCH_ID";
            public const string RESULT_DATE = "RESULT_DATE";
            public const string CUSTOMER_SERVICE_CONTRACT_ID = "CUSTOMER_SERVICE_CONTRACT_ID";
        }
        public static class CUSTOMER
        {
            public const string TABLE_NAME = "CUSTOMER";
            public const string ID = "ID";
            public const string STATUS_ID = "STATUS_ID";
        }

        //Added by Fahim Nasir 11/10/2017 10:19:55
        public static class Company
        {
            public const string TABLE_NAME = "COMPANY";
            public const string ID = "ID";
            public const string NAME_EN = "NAME_EN";
            public const string NAME_AR = "NAME_AR";
            public const string ADDRESS = "ADDRESS";
            public const string POSTAL_CODE = "POSTAL_CODE";
            public const string LICENSE_NO = "LICENSE_NO";
            public const string EMIRATE_ID = "EMIRATE_ID";
            public const string CONTACT_NO = "CONTACT_NO";
            public const string EMAIL = "EMAIL";
            public const string CONTACT_PERSON_NAME = "CONTACT_PERSON_NAME";
            public const string CONTACT_PERSON_MOBILE = "CONTACT_PERSON_MOBILE";
            public const string REFERENCE_NO = "REFERENCE_NO";
            // Commented by AVANZA\muhammad.uzair on 06/11/2017 11:12:07
            //public const string IS_INTERNAL_COMPANY = "IS_INTERNAL_COMPANY";
            public const string IS_ACTIVE = "IS_ACTIVE";
            public const string REMARKS = "REMARKS";
            public const string CREATED_BY = "CREATED_BY";
            public const string CREATED_ON = "CREATED_ON";
            public const string UPDATED_BY = "UPDATED_BY";
            public const string UPDATED_ON = "UPDATED_ON";

            // Added by AVANZA\vijay.kumar on 20/11/2017 19:39:3/ 
            public const string DEPOTS_ID = "DEPOTS_ID";

            // Added by AVANZA\muhammad.uzair on 06/11/2017 11:11:27
            public const string COMPANY_TYPE_ID = "COMPANY_TYPE_ID";

            // Added by Muhammad Uzair on 25/01/2018 12:44:39 
            public const string BENEFIT_CRITERIA = "BENEFIT_CRITERIA";

            public static DataTable GetDataTable()
            {
                DataTable dt = new DataTable(TABLE_NAME);
                dt.Columns.Add(ID, typeof(int));
                dt.Columns.Add(NAME_EN, typeof(String));
                dt.Columns.Add(NAME_AR, typeof(String));
                dt.Columns.Add(ADDRESS, typeof(String));
                dt.Columns.Add(POSTAL_CODE, typeof(String));
                dt.Columns.Add(EMAIL, typeof(String));
                dt.Columns.Add(LICENSE_NO, typeof(String));
                dt.Columns.Add(EMIRATE_ID, typeof(int));
                dt.Columns.Add(CONTACT_NO, typeof(String));
                dt.Columns.Add(CONTACT_PERSON_NAME, typeof(String));
                dt.Columns.Add(CONTACT_PERSON_MOBILE, typeof(string));
                dt.Columns.Add(REFERENCE_NO, typeof(String));
                // Commented by AVANZA\muhammad.uzair on 06/11/2017 11:12:11
                //dt.Columns.Add(IS_INTERNAL_COMPANY, typeof(int));
                dt.Columns.Add(IS_ACTIVE, typeof(int));
                dt.Columns.Add(REMARKS, typeof(String));
                dt.Columns.Add(CREATED_BY, typeof(int));
                dt.Columns.Add(CREATED_ON, typeof(DateTime));
                dt.Columns.Add(UPDATED_BY, typeof(int));
                dt.Columns.Add(UPDATED_ON, typeof(DateTime));
                dt.Columns.Add(COMPANY_TYPE_ID, typeof(int));
                // Added by AVANZA\vijay.kumar on 20/11/2017 19:52:1/ 
                dt.Columns.Add(DEPOTS_ID, typeof(int));
                // Added by Muhammad Uzair on 25/01/2018 12:45:08 
                dt.Columns.Add(BENEFIT_CRITERIA, typeof(int));
                return dt;
            }
        }

        //Added by Fahim Nasir 12/10/2017 10:15:19
        public static class CompanyDiscount
        {
            public const string TABLE_NAME = "COMPANY_DISCOUNT";
            public const string ID = "ID";
            public const string COMPANY_ID = "COMPANY_ID";
            public const string VEHICLE_TYPE_ID = "VEHICLE_TYPE_ID";
            public const string DISCOUNT = "DISCOUNT";
            public const string DISCOUNT_TYPE = "DISCOUNT_TYPE";
            public const string DISCOUNT_TYPE_NAME = "DISCOUNT_TYPE_NAME";
            public const string PAYMENT_STAGE_NAME = "PAYMENT_STAGE_NAME";
            public const string VEHICLE_TYPE_NAME = "VEHICLE_TYPE_NAME";
            public const string PAYMENT_STAGE_ID = "PAYMENT_STAGE_ID";
            public const string START_DATE = "START_DATE";
            public const string END_DATE = "END_DATE";
            public const string CREATED_ON = "CREATED_ON";
            public const string CREATED_BY = "CREATED_BY";
            public const string UPDATED_BY = "UPDATED_BY";
            public const string UPDATE_ON = "UPDATE_ON";

        }

        //Added by Fahim Nasir 17/01/2018 11:41:30
        public static class CompanyContract
        {
            public const string TABLE_NAME = "COMPANY_CONTRACT";
            public const string ID = "ID";
            public const string COMPANY_ID = "COMPANY_ID";
            public const string VEHICLE_TYPE_ID = "VEHICLE_TYPE_ID";
            public const string VEHICLE_TYPE_NAME = "VEHICLE_TYPE_NAME";
            public const string CONTRACT_NO = "CONTRACT_NO";
            public const string START_DATE = "START_DATE";
            public const string END_DATE = "END_DATE";
            public const string KNT_ATTEMPTS = "KNT_ATTEMPTS";
            public const string RDT_ATTEMPTS = "RDT_ATTEMPTS";
            public const string PRKT_ATTEMPTS = "PRKT_ATTEMPTS";
            public const string ASMT_ATTEMPTS = "ASMT_ATTEMPTS";
            public const string CLASSES_ATTEMPT = "CLASSES_ATTEMPT";
            public const string AMOUNT = "AMOUNT";
            public const string IS_ACTIVE = "IS_ACTIVE";
            public const string STATUS = "STATUS";
            public const string EMPLOYEE_COUNT = "EMPLOYEE_COUNT";
            public const string CREATED_ON = "CREATED_ON";
            public const string CREATED_BY = "CREATED_BY";
            public const string UPDATED_BY = "UPDATED_BY";
            public const string UPDATED_ON = "UPDATED_ON";
            // Added by Muhammad Uzair on 25/01/2018 12:23:42 
            public const string IS_SELF_PAYMENT = "IS_SELF_PAYMENT";
            //Added by Fahim Nasir 20/03/2018 10:53:44
            public const string CONTRACT_NAME = "CONTRACT_NAME";
            public const string IS_LUMPSUM_PACKAGE = "IS_LUMPSUM_PACKAGE";
            //=========================================
        }


        public static DataTable GetCompanyDiscountTable()
        {
            DataTable dt = new DataTable(CompanyDiscount.TABLE_NAME);
            dt.Columns.Add(CompanyDiscount.ID, typeof(int));
            dt.Columns.Add(CompanyDiscount.COMPANY_ID, typeof(int));
            dt.Columns.Add(CompanyDiscount.VEHICLE_TYPE_ID, typeof(int));
            dt.Columns.Add(CompanyDiscount.DISCOUNT, typeof(int));
            dt.Columns.Add(CompanyDiscount.DISCOUNT_TYPE, typeof(int));
            dt.Columns.Add(CompanyDiscount.PAYMENT_STAGE_ID, typeof(int));
            dt.Columns.Add(CompanyDiscount.PAYMENT_STAGE_NAME, typeof(string));
            dt.Columns.Add(CompanyDiscount.VEHICLE_TYPE_NAME, typeof(string));
            dt.Columns.Add(CompanyDiscount.DISCOUNT_TYPE_NAME, typeof(string));
            dt.Columns.Add(CompanyDiscount.START_DATE, typeof(DateTime));
            dt.Columns.Add(CompanyDiscount.END_DATE, typeof(DateTime));
            dt.Columns.Add(CompanyDiscount.CREATED_ON, typeof(DateTime));
            dt.Columns.Add(CompanyDiscount.CREATED_BY, typeof(int));
            dt.Columns.Add(CompanyDiscount.UPDATE_ON, typeof(DateTime));
            dt.Columns.Add(CompanyDiscount.UPDATED_BY, typeof(int));
            return dt;
        }


        public static DataTable GetCompanyContractTable()
        {
            DataTable dt = new DataTable(CompanyContract.TABLE_NAME);
            dt.Columns.Add(CompanyContract.ID, typeof(int));
            dt.Columns.Add(CompanyContract.COMPANY_ID, typeof(int));
            dt.Columns.Add(CompanyContract.VEHICLE_TYPE_ID, typeof(int));
            dt.Columns.Add(CompanyContract.VEHICLE_TYPE_NAME, typeof(String));
            dt.Columns.Add(CompanyContract.KNT_ATTEMPTS, typeof(int));
            dt.Columns.Add(CompanyContract.RDT_ATTEMPTS, typeof(int));
            dt.Columns.Add(CompanyContract.ASMT_ATTEMPTS, typeof(int));
            dt.Columns.Add(CompanyContract.CLASSES_ATTEMPT, typeof(int));
            dt.Columns.Add(CompanyContract.CONTRACT_NO, typeof(string));
            dt.Columns.Add(CompanyContract.PRKT_ATTEMPTS, typeof(int));
            dt.Columns.Add(CompanyContract.START_DATE, typeof(DateTime));
            dt.Columns.Add(CompanyContract.END_DATE, typeof(DateTime));
            dt.Columns.Add(CompanyContract.AMOUNT, typeof(decimal));
            dt.Columns.Add(CompanyContract.EMPLOYEE_COUNT, typeof(int));
            dt.Columns.Add(CompanyContract.IS_ACTIVE, typeof(int));
            dt.Columns.Add(CompanyContract.STATUS, typeof(string));
            dt.Columns.Add(CompanyContract.CREATED_ON, typeof(DateTime));
            dt.Columns.Add(CompanyContract.CREATED_BY, typeof(int));
            dt.Columns.Add(CompanyContract.UPDATED_ON, typeof(DateTime));
            dt.Columns.Add(CompanyContract.UPDATED_BY, typeof(int));
            // Added by Muhammad Uzair on 25/01/2018 12:27:35 
            dt.Columns.Add(CompanyContract.IS_SELF_PAYMENT, typeof(int));

            //Added by Fahim Nasir 20/03/2018 11:00:49
            dt.Columns.Add(CompanyContract.CONTRACT_NAME, typeof(String));
            dt.Columns.Add(CompanyContract.IS_LUMPSUM_PACKAGE, typeof(int));
            //=======================================
            return dt;
        }

        public static class CourseContentPublished
        {
            public const string TABLE_NAME = "COURSE_CONTENT_PUBLISHED";
            public const string CC_PUBLISHED_ID = "CC_PUBLISHED_ID";
            public const string CC_ID = "CC_ID";
            public const string CHAPTER_ID = "CHAPTER_ID";
            public const string COURSE_ID = "COURSE_ID";
            public const string UPLOADED_FILE_NAME = "UPLOADED_FILE_NAME";
            public const string UPLOADED_FILE_PATH = "UPLOADED_FILE_PATH";
            public const string TOTAL_SLIDES = "TOTAL_SLIDES";
            public const string SLIDE_DURATION = "SLIDE_DURATION";
            public const string PUBLISHED_ON = "PUBLISHED_ON";
            public const string PUBLISHED_BY = "PUBLISHED_BY";
            public const string VERSION_NUM = "VERSION_NUM";
        }

        public static class UserTypePermittedUrls
        {
            public const string TABLE_NAME = "UserTypePermittedUrls";
            public const string ID = "ID";
            public const string USER_TYPE_ID = "USER_TYPE_ID";
            public const string PERMITTED_URL = "PERMITTED_URL";

            public static DataTable GetDataTable()
            {
                DataTable dt = new DataTable(TABLE_NAME);
                dt.Columns.Add(ID, typeof(Int32));
                dt.Columns.Add(USER_TYPE_ID, typeof(Int32));
                dt.Columns.Add(PERMITTED_URL, typeof(String));
                return dt;
            }

        }

        // Added by AVANZA\jawwad.ahmed on 09/11/2017 13:39:18

        public static class INDIVIDUAL_DISCOUNT
        {
            public const string TABLE_NAME = "INDIVIDUAL_DISCOUNT";
            public const string ID = "ID";
            public const string SERVICE_CONTRACT_ID = "SERVICE_CONTRACT_ID";
            public const string WORKFLOW_STAGE_ID = "WORKFLOW_STAGE_ID";
            public const string SUB_SERVICE_ID = "SUB_SERVICE_ID";
            public const string AMOUNT = "AMOUNT";
            public const string DISCOUNT_TYPE = "DISCOUNT_TYPE";
            public const string STATUS = "STATUS";
            public const string CREATED_ON = "CREATED_ON";
            public const string CREATED_BY = "CREATED_BY";
            public const string UPDATED_ON = "UPDATED_ON";
            public const string UPDATED_BY = "UPDATED_BY";

        }

    }
}
