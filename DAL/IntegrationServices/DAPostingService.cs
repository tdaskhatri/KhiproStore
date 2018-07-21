using eLearning.Common.Utils;
using eLearning.DAL.DataAccess;
using eLearning.DAL.MakerChecker;
using eLearning.DAL.WebService.Components;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace eLearning.DAL.WebService
{
    public class DAPostingService
    {
        private string MODULE_NAME = "DAPostingService";
        private Database Database { get; set; }
        private SqlConnection Connection { get; set; }
        private SqlTransaction Transaction { get; set; }

        public SchemaManager SchemaManager { get; set; }

        //Added by Fahim Nasir on 25-8-2017
        private const string QRY_GET_ASSESSMENT_RESULTS = @"SELECT CA.ID, CA.TRAFFIC_FILE_NO, 
                            CONVERT(varchar(10), CA.CREATED_ON, 103) AS START_DATE, 
                            CASE CA.RESULT WHEN 'Pass' then 2 
                            when 'Fail' then 1
                            when 'Absent' then 3
                            end AS EXAM_RESULT, 
                            I.PERMIT_NO, '' AS PERMIT_TYPE, 
                            '' AS PERMIT_CATEGORY, 
                            (SELECT INTG_MAPPING_CODE FROM CENTERS WHERE ID = I.CENTER_ID)
                            AS CENTER_ID
                            FROM CUSTOMER_ASSESSMENT CA
                            INNER JOIN INSTRUCTOR I ON I.ID = CA.INSTRUCTOR_ID
                            AND CA._Status IS NULL";

        //Added by Fahim Nasir on 25-8-2017
        private const string QRY_GET_CUST_CONTRACT_ATTENDANCE = @"SELECT DISTINCT TRAFFIC_FILE_NUMBER, 
                            CUSTOMER_SERVICE_CONTRACT_ID FROM CUSTOMER_ATTENDANCE
                            WHERE _Status is null AND TRAINING_TYPE_CODE = 1;";

        //Modified by Fahim Nasir 30/01/2018 12:40:48 = null changed to IS NULL
        private const string QRY_GET_LECTURE_INFO_DATA = @"SELECT CA.ID, CA.TRAFFIC_FILE_NUMBER, 
                            (SELECT INTG_MAPPING_CODE FROM CENTERS WHERE ID = CA.CENTER_ID) AS CENTER_ID,
                            CONVERT(varchar(10), ATTENDANCE_DATE, 103) AS START_DATE, 
                            CONVERT(varchar(10), ATTENDANCE_DATE, 103) AS END_DATE,
                            1 AS TOTAL_LESSON,
                            CA.CUSTOMER_SERVICE_CONTRACT_ID, 
                            I.LECTURER_PERMIT_NO AS LECTURER_PERMIT_NO
                            FROM CUSTOMER_ATTENDANCE CA INNER JOIN INSTRUCTOR I ON 
                            CA.INSTRUCTOR_ID = I.ID 
                            WHERE _Status IS NULL AND CA.TRAINING_TYPE_CODE = 1
                            AND CA.ATTENDANCE = 'P'";


        //Not in use now.. Sending lecture attendance 1 by 1.
        //Added by Fahim Nasir on 25-8-2017
        private const string QRY_GET_LECTURE_INFO_DATA_OLD = @"SELECT
                                (SELECT COUNT(COURSE_ID) FROM CUSTOMER_ATTENDANCE
                                WHERE ATTENDANCE = 'P' AND CUSTOMER_SERVICE_CONTRACT_ID = {0}
                                AND COURSE_ID > 0) AS TOTAL_PRESENT, 
                                (SELECT COUNT(ID) FROM COURSE WHERE IS_BREAK = 0) AS TOTAL_LECTURES, 
                                (SELECT INTG_MAPPING_CODE FROM CENTERS WHERE ID = 
                                (SELECT TOP 1 CENTER_ID FROM CUSTOMER_ATTENDANCE WHERE 
	                                CUSTOMER_SERVICE_CONTRACT_ID = {0} AND ATTENDANCE = 'P')
                                ) AS CENTER_ID,
                                (SELECT CONVERT(varchar(10), MIN(ATTENDANCE_DATE), 103) 
                                FROM CUSTOMER_ATTENDANCE WHERE 
                                CUSTOMER_SERVICE_CONTRACT_ID = {0} AND ATTENDANCE = 'P'
                                ) AS START_DATE, 
                                (SELECT CONVERT(varchar(10), MAX(ATTENDANCE_DATE), 103) 
                                FROM CUSTOMER_ATTENDANCE WHERE 
                                CUSTOMER_SERVICE_CONTRACT_ID = {0} AND ATTENDANCE = 'P'
                                ) AS END_DATE, 
                                (SELECT LECTURER_PERMIT_NO FROM INSTRUCTOR 
                                WHERE ID = (SELECT TOP 1 INSTRUCTOR_ID FROM CUSTOMER_ATTENDANCE
                                WHERE CUSTOMER_SERVICE_CONTRACT_ID = {0} AND ATTENDANCE = 'P')
                                ) AS LECTURER_PERMIT_NO,
                                '' AS PERMIT_TYPE, 
                                '' AS PERMIT_CATEGORY;";
        //====================================

        private const String QRY_GET_MARKED_ATTENDANCE_DATA = @"
            UPDATE [CUSTOMER_MANUAL_ATTENDANCE]
            SET _STATUS = 1 
            WHERE ID IN (SELECT TOP {0} ID FROM [CUSTOMER_MANUAL_ATTENDANCE] WHERE _STATUS IN (0, 1) ORDER BY _STATUS DESC);

            SELECT * FROM [CUSTOMER_MANUAL_ATTENDANCE]
            WHERE _STATUS = 1;
        ";

        private const string QRY_MARK_NIGHT_HIGHWAY_CLASS_BY_ID = @"UPDATE [CUSTOMER_SCHEDULE_CLASSES]
            SET _STATUS = 2, _ResponseCode='{1}', _ResponseDescription='{2}', 
            _ViolationsEn=N'{3}', _ViolationsAr=N'{4}'  
            WHERE ID = {0}";

        private const string QRY_MARK_ASSESSMENT_STATUS_BY_ID = @"UPDATE [CUSTOMER_ASSESSMENT]
            SET _STATUS = 2, _ResponseCode='{1}', _ResponseDescription='{2}', 
            _ViolationsEn=N'{3}', _ViolationsAr=N'{4}'  
            WHERE ID = {0}";

        private const String QRY_PRACTICAL_ATTENDANCE_STATUS_BY_ID = @"
            UPDATE [CUSTOMER_ATTENDANCE]
            SET _STATUS = 2, _ResponseCode='{1}', _ResponseDescription='{2}', 
            _ViolationsEn=N'{3}', _ViolationsAr=N'{4}'  
            WHERE ID = {0};
        ";

        private const String QRY_MARK_ATTENDANCE_STATUS_BY_ID = @"
            UPDATE [CUSTOMER_ATTENDANCE]
            SET _STATUS = 2, _ResponseCode='{1}', _ResponseDescription='{2}', 
            _ViolationsEn=N'{3}', _ViolationsAr=N'{4}'  
            WHERE ID = {0} AND TRAINING_TYPE_CODE = 1
            AND ATTENDANCE = 'P';
        ";


        private const String QRY_MARK_NIGHT_HIGHWAY_CLASS_EXCEPTION_BY_ID = @"
            UPDATE [CUSTOMER_SCHEDULE_CLASSES]
            SET _STATUS = -1, _Exception='{1}'
            WHERE ID = {0};
        ";

        private const String QRY_MARK_ASSESSMENT_EXCEPTION_BY_ID = @"
            UPDATE [CUSTOMER_ASSESSMENT]
            SET _STATUS = -1, _Exception='{1}'
            WHERE ID = {0};
        ";

        private const String QRY_PRACTICAL_ATTENDANCE_EXCEPTION_BY_ID = @"
            UPDATE [CUSTOMER_ATTENDANCE]
            SET _STATUS = -1, _Exception='{1}'
            WHERE ID = {0};
        ";

        private const String QRY_MARK_ATTENDANCE_EXCEPTION_BY_ID = @"
            UPDATE [CUSTOMER_ATTENDANCE]
            SET _STATUS = -1, _Exception='{1}'
            WHERE ID = {0} AND TRAINING_TYPE_CODE = 1
            AND ATTENDANCE = 'P';
        ";

        //Added by Fahim Nasir on 25-8-2017
        private const String QRY_GET_MARKED_PAYMENT_DATA = @"UPDATE [CUSTOMER_PAYMENT_DETAILS]
            SET _STATUS = 1 
            WHERE ID IN (SELECT TOP {0} ID FROM [CUSTOMER_PAYMENT_DETAILS] WHERE _STATUS is null ORDER BY _STATUS DESC);

            SELECT CPD.ID, (SELECT INTG_MAPPING_CODE FROM CENTERS WHERE ID = CP.CENTER_ID) AS CENTER_ID, 
			C.TRACKING_FILE_NUMBER, CPD.ALLOWED_SERVICE_CODE, CPD.EXAM_CODE AS CLEARANCE_EXAM_CODE, 
			CONVERT(VARCHAR(10), CP.TRAN_DATE, 103) + ' '  + convert(VARCHAR(8), GETDATE(), 14) AS PAYMENT_DATE
			FROM [CUSTOMER_PAYMENT_DETAILS] CPD INNER JOIN 
			[CUSTOMER_PAYMENTS] CP on CP.ID = CPD.PAYMENT_ID
			INNER JOIN CUSTOMER C on C.ID = CP.CUSTOMER_ID
			INNER JOIN CUSTOMER_SERVICE_CONTRACT CSC 
			on CP.CUSTOMER_ID = CSC.CUSTOMER_ID 
            WHERE GETDATE() BETWEEN CSC.REGISTRATION_DATE AND CSC.EXPIRY_DATE
			AND CSC.LICENSE_STATUS_ID = 1 AND CPD.ALLOWED_SERVICE_CODE is not null AND
			CPD._STATUS = 1;
        ";
        //=========================================

        //Commented by Fahim Nasir - changed to new transaction tables.
        //private const String QRY_GET_MARKED_PAYMENT_DATA = @"
        //    UPDATE [CUSTOMER_PAYMENT_CLEARANCE]
        //    SET _STATUS = 1 
        //    WHERE ID IN (SELECT TOP {0} ID FROM [CUSTOMER_PAYMENT_CLEARANCE] WHERE _STATUS IN (0, 1) ORDER BY _STATUS DESC);

        //    SELECT * FROM [CUSTOMER_PAYMENT_CLEARANCE]
        //    WHERE _STATUS = 1;
        //";

        //Table modified by Fahim Nasir
        private const String QRY_MARK_PAYMENT_STATUS_BY_ID = @"
            UPDATE [CUSTOMER_PAYMENT_DETAILS]
            SET _STATUS = 2, _PaymentClearanceId='{1}', 
            _PaymentClearanceIdSpecified='{2}', 
            _ResponseCode='{3}', _ErrorCode='{4}', 
            _DescriptionEn=N'{5}', 
            _DescriptionAr=N'{6}'
            WHERE ID = {0};
        ";

        //Table modified by Fahim Nasir
        private const String QRY_MARK_PAYMENT_EXCEPTION_BY_ID = @"
            UPDATE [CUSTOMER_PAYMENT_DETAILS]
            SET _STATUS = -1, _Exception='{1}'
            WHERE ID = {0};
        ";

        private const String QRY_GET_TRAINING_INFO_PARAMS = @"
            SELECT TOP {0} * FROM GET_TRAINING_INFO_PARAMS;
        ";

        private const String QRY_INSERT_TRAINING_INFO_RESPONSE = @"
            INSERT INTO [GET_TRAINING_INFO_RESPONSES]
                       ([REQUEST_TIME]
                       ,[RESPONSE_XML])
                 VALUES
                       (GETDATE()
                       ,N'{0}')
        ";


        private const String QRY_GET_GENERAL_INQUIRY_PARAMS = @"
            SELECT TOP {0} * FROM [GET_GENERAL_INQUIRY_PARAMS];
        ";

        private const String QRY_INSERT_GENERAL_INQUIRY_RESPONSE = @"
            INSERT INTO [GET_GENERAL_INQUIRY_RESPONSES]
                       ([REQUEST_TIME]
                       ,[RESPONSE_XML])
                 VALUES
                       (GETDATE()
                       ,N'{0}')
        ";

        //Added by Fahim Nasir on 27-8-2017
        private const string QRY_GET_CUST_PRACTICAL_ATTENDANCE = @"SELECT CA.ID, CA.TRAFFIC_FILE_NUMBER, 
                    I.PERMIT_NO, '' AS PERMIT_TYPE, 
                    '' AS PERMIT_CATEGORY, 
                    (SELECT INTG_MAPPING_CODE FROM CENTERS WHERE ID = CA.CENTER_ID) AS CENTER_ID,
                    CA.TRAINING_TYPE_CODE, 
                    CONVERT(varchar(10), MIN(CA.ATTENDANCE_DATE), 103) AS START_DATE, 
                    CONVERT(varchar(10), MAX(CA.ATTENDANCE_DATE), 103) AS END_DATE, CA.TRANSACTION_TYPE, 
                    COUNT(CA.ID) AS TOTAL_LESSON_NO 
                    FROM CUSTOMER_ATTENDANCE CA
                    INNER JOIN INSTRUCTOR I on I.ID = CA.INSTRUCTOR_ID
					INNER JOIN CUSTOMER_SCHEDULE_CLASSES CSSC ON CA.CUSTOMER_SCHEDULE_CLASS_ID
					= CSSC.ID AND CSSC.TYPE_ID = 1
                    AND I.IS_INSTRUCTOR = 1
                    WHERE CA.TRAINING_TYPE_CODE = 6 AND ATTENDANCE = 'P'
                    AND CA._Status is null
                    GROUP BY CA.ID, CA.TRAFFIC_FILE_NUMBER, I.PERMIT_NO, CA.TRAINING_TYPE_CODE,
                    CA.TRANSACTION_TYPE, CA.CENTER_ID;
        ";

        private const string QRY_GET_NIGHT_HIGHWAY_CLASSES = @"SELECT CSC.ID, C.TRACKING_FILE_NUMBER AS TRAFFIC_FILE_NO,
                            (SELECT INTG_MAPPING_CODE FROM CENTERS CEN WHERE BRANCH_ID = CS.BRANCH_ID) AS CENTER_ID,
                            CONVERT(varchar(10), CSC.DATE, 103) AS START_DATE,
                            CONVERT(varchar(10), CSC.DATE, 103) AS END_DATE, 
							(SELECT PERMIT_NO FROM INSTRUCTOR WHERE ID = CS.INSTRUCTOR_ID) AS PERMIT_NO
                            FROM CUSTOMER_SCHEDULE CS
                            INNER JOIN CUSTOMER C on C.ID = CS.CUSTOMER_ID
                            INNER JOIN CUSTOMER_SCHEDULE_CLASSES CSC
                            ON CS.ID = CSC.CUSTOMER_SCHEDULE_ID
                            AND CSC.TYPE_ID = {0} AND CSC.STATUS_ID = 2
                            AND CSC._Status = NULL";

        public DAPostingService()
        {
            try
            {
                this.Database = DatabaseFactory.CreateDatabase();
                this.Connection = (SqlConnection)this.Database.CreateConnection();
                this.SchemaManager = new SchemaManager(this.Database);
                this.Connection.Open();
            }
            catch (Exception ex)
            {
                Logger.getInstance().Error("Middleware Utility", "DAMiddlewareUtility()", ex);
                throw ex;
            }
        }


        public DataTable GetNightHighwayClasses(int Identifier)
        {
            try
            {
                String query = String.Format(QRY_GET_NIGHT_HIGHWAY_CLASSES, Identifier);
                SqlCommand command = new SqlCommand(query, this.Connection);
                DataTable table = new DataTable("NIGHT_CLASS_INFO");

                SqlDataReader reader = command.ExecuteReader();
                table.Load(reader);

                return table;
            }
            catch (Exception ex)
            {
                Logger.getInstance().Error(MODULE_NAME, "GetNightClasses", ex);
                throw ex;
            }
        }

        //Added by Fahim Nasir on 27-8-2017
        public DataTable GetCustomerPracticalAttendance()
        {
            try
            {
                String query = String.Format(QRY_GET_CUST_PRACTICAL_ATTENDANCE);
                SqlCommand command = new SqlCommand(query, this.Connection);
                DataTable table = new DataTable("PRACTICAL_INFO");

                SqlDataReader reader = command.ExecuteReader();
                table.Load(reader);

                return table;
            }
            catch (Exception ex)
            {
                Logger.getInstance().Error(MODULE_NAME, "GetCustomerPracticalAttendance", ex);
                throw ex;
            }
        }
        public DataTable GetCustomerContractAttendance()
        {
            try
            {
                String query = String.Format(QRY_GET_CUST_CONTRACT_ATTENDANCE);
                SqlCommand command = new SqlCommand(query, this.Connection);
                DataTable table = new DataTable("LECTURE_INFO");

                SqlDataReader reader = command.ExecuteReader();
                table.Load(reader);

                return table;
            }
            catch (Exception ex)
            {
                Logger.getInstance().Error(MODULE_NAME, "GetCustomerContractAttendance", ex);
                throw ex;
            }
        }
        public DataTable GetAssessmentResults()
        {
            try
            {
                string query = QRY_GET_ASSESSMENT_RESULTS;
                SqlCommand command = new SqlCommand(query, this.Connection);
                DataTable table = new DataTable("ASSESSMENT_RESULTS");

                SqlDataReader reader = command.ExecuteReader();
                table.Load(reader);

                return table;
            }
            catch (Exception ex)
            {
                Logger.getInstance().Error(MODULE_NAME, "GetAssessmentResults", ex);
                throw ex;
            }
        }
        public DataTable GetLectureInfoForPosting()
        {
            try
            {
                String query = String.Format(QRY_GET_LECTURE_INFO_DATA);
                SqlCommand command = new SqlCommand(query, this.Connection);
                DataTable table = new DataTable("LECTURE_INFO");

                SqlDataReader reader = command.ExecuteReader();
                table.Load(reader);

                return table;
            }
            catch (Exception ex)
            {
                Logger.getInstance().Error(MODULE_NAME, "GetLectureInfoForPosting", ex);
                throw ex;
            }
        }
        public DataTable GetAttendanceForPosting(int maxRecordsCount = 100)
        {
            try
            {
                String query = String.Format(QRY_GET_MARKED_ATTENDANCE_DATA, maxRecordsCount);
                SqlCommand command = new SqlCommand(query, this.Connection);
                DataTable table = new DataTable("CUSTOMER_MANUAL_ATTENDANCE");

                SqlDataReader reader = command.ExecuteReader();
                table.Load(reader);

                return table;
            }
            catch (Exception ex)
            {
                Logger.getInstance().Error(MODULE_NAME, "GetAttendanceForPosting", ex);
                throw ex;
            }
        }
        public void MarkNightHighwayClassRecord(int Id,
            string responseCode, string responseDescription, string violationsEn, string violationsAr)
        {
            try
            {
                String query = String.Format(QRY_MARK_NIGHT_HIGHWAY_CLASS_BY_ID, Id,
                    responseCode, responseDescription, violationsEn, violationsAr);
                SqlCommand command = new SqlCommand(query, this.Connection);
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Logger.getInstance().Error(MODULE_NAME, "MarkNightHighwayClassRecord", ex);
                throw ex;
            }
        }
        public void MarkPostedAssesmentRecord(int CSCid,
        string responseCode, string responseDescription, string violationsEn, string violationsAr)
        {
            try
            {
                String query = String.Format(QRY_MARK_ASSESSMENT_STATUS_BY_ID, CSCid,
                    responseCode, responseDescription, violationsEn, violationsAr);
                SqlCommand command = new SqlCommand(query, this.Connection);
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Logger.getInstance().Error(MODULE_NAME, "MarkPostedAssesmentRecord", ex);
                throw ex;
            }
        }
        public void MarkPracticalAttendanceRecord(int CSCid,
        string responseCode, string responseDescription, string violationsEn, string violationsAr)
        {
            try
            {
                String query = String.Format(QRY_PRACTICAL_ATTENDANCE_STATUS_BY_ID, CSCid,
                    responseCode, responseDescription, violationsEn, violationsAr);
                SqlCommand command = new SqlCommand(query, this.Connection);
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Logger.getInstance().Error(MODULE_NAME, "MarkPracticalAttendanceRecord", ex);
                throw ex;
            }
        }
        public void MarkPostedAttendanceRecord(int ID, 
            string responseCode, string responseDescription, string violationsEn, string violationsAr)
        {
            try
            {
                String query = String.Format(QRY_MARK_ATTENDANCE_STATUS_BY_ID, ID, 
                    responseCode, responseDescription, violationsEn, violationsAr);
                SqlCommand command = new SqlCommand(query, this.Connection);
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Logger.getInstance().Error(MODULE_NAME, "MarkPostedAttendanceRecord", ex);
                throw ex;
            }
        }
        public void MarkPracticalAttendanceException(int id, string message)
        {
            try
            {
                String query = String.Format(QRY_PRACTICAL_ATTENDANCE_EXCEPTION_BY_ID, id, message.Replace("'", "''"));
                SqlCommand command = new SqlCommand(query, this.Connection);
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Logger.getInstance().Error(MODULE_NAME, "MarkPracticalAttendanceException", ex);
                throw ex;
            }
        }
        public void MarkNightHighwayClassException(int id, string message)
        {
            try
            {
                String query = String.Format(QRY_MARK_NIGHT_HIGHWAY_CLASS_EXCEPTION_BY_ID, id, message.Replace("'", "''"));
                SqlCommand command = new SqlCommand(query, this.Connection);
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Logger.getInstance().Error(MODULE_NAME, "MarkNightHighwayClassException", ex);
                throw ex;
            }
        }
        public void MarkAssessmentException(int id, string message)
        {
            try
            {
                String query = String.Format(QRY_MARK_ASSESSMENT_EXCEPTION_BY_ID, id, message.Replace("'", "''"));
                SqlCommand command = new SqlCommand(query, this.Connection);
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Logger.getInstance().Error(MODULE_NAME, "MarkAssessmentException", ex);
                throw ex;
            }
        }
        public void MarkPostedAttendanceException(int id, string message)
        {
            try
            {
                String query = String.Format(QRY_MARK_ATTENDANCE_EXCEPTION_BY_ID, id, message.Replace("'", "''"));
                SqlCommand command = new SqlCommand(query, this.Connection);
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Logger.getInstance().Error(MODULE_NAME, "MarkPostedAttendanceException", ex);
                throw ex;
            }
        }
        public DataTable GetPaymentDetailsForPosting(int maxRecordsCount)
        {
            try
            {
                String query = String.Format(QRY_GET_MARKED_PAYMENT_DATA, maxRecordsCount);
                SqlCommand command = new SqlCommand(query, this.Connection);
                DataTable table = new DataTable("CUSTOMER_MANUAL_ATTENDANCE");

                SqlDataReader reader = command.ExecuteReader();
                table.Load(reader);

                return table;
            }
            catch (Exception ex)
            {
                Logger.getInstance().Error("DAPostingService", "GetPaymentDetailsForPosting", ex);
                throw ex;
            }
        }
        public void MarkPaymentDetailsRecord(int id, string paymentClearanceId, string paymentClearanceIdSpecified, string responseCode, string errorCode, string descriptionEn, string descriptionAr)
        {
            try
            {
                String query = String.Format(QRY_MARK_PAYMENT_STATUS_BY_ID, id, paymentClearanceId, paymentClearanceIdSpecified, responseCode, errorCode, descriptionEn, descriptionAr);
                SqlCommand command = new SqlCommand(query, this.Connection);
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Logger.getInstance().Error(MODULE_NAME, "MarkPaymentDetailsRecord", ex);
                throw ex;
            }
        }
        public void MarkPaymentDetailsException(int id, string message)
        {
            try
            {
                String query = String.Format(QRY_MARK_PAYMENT_EXCEPTION_BY_ID, id, message.Replace("'", "''"));
                SqlCommand command = new SqlCommand(query, this.Connection);
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Logger.getInstance().Error(MODULE_NAME, "MarkPaymentDetailsException", ex);
                throw ex;
            }
        }
        public DataTable GeneralInquiryParamsForPosting(int maxRecordsCount)
        {
            try
            {
                String query = String.Format(QRY_GET_GENERAL_INQUIRY_PARAMS, maxRecordsCount);
                SqlCommand command = new SqlCommand(query, this.Connection);
                DataTable table = new DataTable("GET_GENERAL_INQUIRY_PARAMS");

                SqlDataReader reader = command.ExecuteReader();
                table.Load(reader);

                return table;
            }
            catch (Exception ex)
            {
                Logger.getInstance().Error(MODULE_NAME, "GeneralInquiryParamsForPosting", ex);
                throw ex;
            }
        }
        public void InsertGeneralInquiryResponse(string xml)
        {
            try
            {
                String query = String.Format(QRY_INSERT_GENERAL_INQUIRY_RESPONSE, xml.Replace("'", "''"));
                SqlCommand command = new SqlCommand(query, this.Connection);
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Logger.getInstance().Error(MODULE_NAME, "InsertGeneralInquiryResponse", ex);
                throw ex;
            }
        }
        public DataTable GetTrainingInfoParamsForPosting(int maxRecordsCount)
        {
            try
            {
                String query = String.Format(QRY_GET_TRAINING_INFO_PARAMS, maxRecordsCount);
                SqlCommand command = new SqlCommand(query, this.Connection);
                DataTable table = new DataTable("GET_TRAINING_INFO_PARAMS");

                SqlDataReader reader = command.ExecuteReader();
                table.Load(reader);

                return table;
            }
            catch (Exception ex)
            {
                Logger.getInstance().Error(MODULE_NAME, "GetTrainingInfoParamsForPosting", ex);
                throw ex;
            }
        }
        public void InsertTrainingInfoResponse(string xml)
        {
            try
            {
                String query = String.Format(QRY_INSERT_TRAINING_INFO_RESPONSE, xml.Replace("'", "''"));
                SqlCommand command = new SqlCommand(query, this.Connection);
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Logger.getInstance().Error(MODULE_NAME, "InsertTrainingInfoResponse", ex);
                throw ex;
            }
        }

        #region Transaction Control

        public void BeginTransaction()
        {
            this.Transaction = this.Connection.BeginTransaction();
        }

        public void CommitTransaction()
        {
            this.Transaction.Commit();
        }

        public void RollbackTransaction()
        {
            this.Transaction.Rollback();
        }

        #endregion
    }
}

