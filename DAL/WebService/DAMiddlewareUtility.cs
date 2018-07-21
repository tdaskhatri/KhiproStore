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
    public class DAMiddlewareUtility
    {
        private Database Database { get; set; }
        private SqlConnection Connection { get; set; }
        private SqlTransaction Transaction { get; set; }

        public SchemaManager SchemaManager { get; set; }

        private string MODULE_NAME = "DAMiddlewareUtility";

        private const String QRY_GET_MARKED_DATA = @"
            UPDATE [{0}] SET _STATUS = 'PROCESSING' WHERE
            _STATUS = 'NEW' {1};

            SELECT * FROM [{0}]
            WHERE _STATUS = 'PROCESSING' {1};
        ";

        private const String QRY_MARK_STATUS_BY_ID = @"
            UPDATE [{0}] SET _STATUS = '{2}' WHERE
            _STATUS = 'PROCESSING' AND ID = '{1}';
        ";

        private const String QRY_MARK_CHILDREN_STATUS_BY_ID = @"
            UPDATE [{0}] SET _STATUS = '{2}' WHERE
            _STATUS = 'PROCESSING' AND _PARENT_ID = '{1}';
        ";

        //Commented by Fahim Nasir on 19-7-2017
        //     private const String QRY_GET_RELATED_VALUES = @"
        //         declare @customerid int;
        //         declare @examid int;
        //         declare @emirateid int;
        //         declare @centerid int;
        //         declare @subserviceid int;
        //         declare @contractid int;
        //         declare @actcenterid int;

        //         select @customerid = id from customer where TRACKING_FILE_NUMBER = '{0}';
        //         select @examid = id from exam where name_en = '{1}';
        //         select @centerid = id from BRANCHES where code = '{2}';
        //select @actcenterid = CENTER_ID from BRANCHES where code = '12345';
        //         select @emirateid = emirate_id from CENTERS where Id = @actcenterid;
        //         select @subserviceid = id from sub_service where NAME_EN = '{3}'
        //         select @contractid = id from CUSTOMER_SERVICE_CONTRACT where customer_id=@customerid and sub_service_id=@subserviceid;

        //         select 
        //         @customerid as customerid, 
        //         @examid as examid, 
        //         @centerid as centerid, 
        //         @emirateid as emirateid, 
        //         @subserviceid as subserviceid, 
        //         @contractid as contractid;
        //     ";

            //Added by Fahim Nasir on 21-8-2017
        private const String QRY_GET_RELATED_VALUES_FOR_TEST_RESULT = @"
            declare @customerid int;
            declare @examid int;
            declare @emirateid int;
            declare @centerid int;
            declare @subserviceid int;
            declare @contractid int;
            declare @branchId int;
            declare @vehicleType varchar(100);

            select @customerid = id from customer where TRACKING_FILE_NUMBER = '{0}';

            select @contractid = id from CUSTOMER_SERVICE_CONTRACT 
            WHERE customer_id = @customerid AND LICENSE_STATUS_ID = {3};

            select @subserviceid = SUB_SERVICE_ID FROM CUSTOMER_SERVICE_CONTRACT
            WHERE ID = @contractid;

            select @vehicleType = RTA_VEHICLE_TYPE_EN FROM ET_RTA_SUB_SERVICE_MAPPING 
            WHERE SUB_SERVICE_ID = @subserviceid;
                       
            select @examid = EXAM_ID from EXAMS_SERVICE_MAPPING ESM 
            WHERE ESM.RTA_EXAM_CODE = '{1}' and ESM.VEHICLE_TYPE = @vehicleType;

            select @centerid = id from CENTERS where INTG_MAPPING_CODE = '{2}';
            select @emirateid = emirate_id from CENTERS where Id = @centerid;
            select @branchId = id from BRANCHES where CENTER_ID = @centerid;

            select 
            @customerid as customerid, 
            @examid as examid, 
            @centerid as centerid, 
            @emirateid as emirateid, 
            @subserviceid as subserviceid, 
            @contractid as contractid, 
            @branchId as branchId;
        ";
        //Modify by Fahim Nasir on 21-8-2017.
        //Added by Fahim Nasir on 19-7-2017
        private const String QRY_GET_RELATED_VALUES = @"
            declare @customerid int;
            declare @examid int;
            declare @emirateid int;
            declare @centerid int;
            declare @subserviceid int;
            declare @contractid int;
            declare @branchId int;

            select @customerid = id from customer where TRACKING_FILE_NUMBER = '{0}';
            select @examid = EXAM_ID from EXAMS_SERVICE_MAPPING ESM WHERE ESM.EXAM_TYPE = '{1}' AND 
            ESM.VEHICLE_TYPE = '{3}';
            select @centerid = id from CENTERS where INTG_MAPPING_CODE = '{2}';
            select @emirateid = emirate_id from CENTERS where Id = @centerid;
            select @branchId = id from BRANCHES where CENTER_ID = @centerid;
            select @subserviceid = SUB_SERVICE_ID from ET_RTA_SUB_SERVICE_MAPPING where RTA_VEHICLE_TYPE_EN = '{3}';
            select @contractid = id from CUSTOMER_SERVICE_CONTRACT where customer_id= @customerid and sub_service_id= @subserviceid;

            select 
            @customerid as customerid, 
            @examid as examid, 
            @centerid as centerid, 
            @emirateid as emirateid, 
            @subserviceid as subserviceid, 
            @contractid as contractid, 
            @branchId as branchId;
        ";

        private const String QRY_CANCEL_EXAM = @"UPDATE CUSTOMER_SERVICE_EXAM SET CANCELLED = 1
            WHERE CANCELLED = 0 AND CUSTOMER_ID={0} AND EXAM_ID={1} AND SUB_SERVICE_ID={2}; ";

        //Modified by Fahim Nasir 27/09/2017 14:42:49 - Updated on.
        private const String QRY_UPDATE_EXAM_RESULT = @"UPDATE CUSTOMER_SERVICE_EXAM 
                            SET EXAM_RESULT = '{3}', RESULT_DATE = GETDATE(), UPDATED_ON = GETDATE()
                            WHERE CUSTOMER_ID = {0} AND EXAM_ID= {1} AND SUB_SERVICE_ID= {2};";

        private const String QRY_FIND_CSUTOMER = @"SELECT * FROM CUSTOMER WHERE TRACKING_FILE_NUMBER = '{0}' OR EMIRATES_ID_NUMBER = '{1}';";
        private const String QRY_GET_RELATED_DATA_FOR_CUSTOMER = @"
            SELECT
            (SELECT ID FROM EMIRATES WHERE LOWER(INTG_MAPPING_CODE) = '{0}') AS emirateId,
            (SELECT ID FROM COUNTRY WHERE INTG_MAPPING_CODE = '{1}') AS countryId,
            (SELECT DESCRIPTION_EN FROM OCCUPATION WHERE CODE = '{2}') AS occupationNameEn,
            (SELECT DESCRIPTION_AR FROM OCCUPATION WHERE CODE = '{2}') AS occupationNameAr;";

        private const String QRY_FIND_CSUTOMER_LICENSE = @"SELECT * FROM CUSTOMER_PREVIOUS_LICENSE WHERE CUSTOMER_ID={0} AND LICENSE_NO = '{1}';";

        private const String QRY_GET_RELATED_DATA_FOR_LICENSE = @"SELECT DISTINCT SS.ID AS subServiceId FROM SUB_SERVICE SS
            INNER JOIN ET_RTA_SUB_SERVICE_MAPPING ERSS on SS.ID = ERSS.SUB_SERVICE_ID 
            AND LOWER(ERSS.RTA_VEHICLE_TYPE_EN) = LOWER('{0}')";

        //Updated by Fahim Nasir Mapping column added.
        private const String QRY_FIND_CSUTOMER_SERVICE_CONTRACT = @"
            SELECT * FROM CUSTOMER_SERVICE_CONTRACT CSC
            INNER JOIN SUB_SERVICE SS ON CSC.SUB_SERVICE_ID = SS.ID 
            INNER JOIN ET_RTA_SUB_SERVICE_MAPPING ERSS on SS.ID = ERSS.SUB_SERVICE_ID 
            AND LOWER(ERSS.RTA_VEHICLE_TYPE_EN) = LOWER('{0}')
            --CSC.REGISTRATION_DATE = CONVERT(DATE, '{1}', 112) AND
            WHERE CSC.CUSTOMER_ID = {1}; 
            -- yyyyMMdd";

        //Updated by Fahim Nasir to get value from new created mapping table.
        private const String QRY_GET_MAIN_AND_SUB_SERVICE_ID = @"
            SELECT ERSS.SUB_SERVICE_ID AS ID, SS.MAIN_SERVICE_ID FROM 
            ET_RTA_SUB_SERVICE_MAPPING ERSS INNER JOIN SUB_SERVICE SS
            ON ERSS.SUB_SERVICE_ID = SS.ID
            WHERE ERSS.RTA_VEHICLE_TYPE_EN = '{0}';";

        //Added by Fahim Nasir on 20-7-2017
        private const String QRY_UPDATE_CSC_STATUS = @"UPDATE CUSTOMER_SERVICE_CONTRACT 
                                                       SET SERVICE_WORKFLOW_STATUS_ID = {0} WHERE ID = {1};";

        // AVANZA\muhammad.awais - 28/08/2017 16:50:42
        private const string QRY_GET_CLASSES_DETAILS = @" SELECT [NIGHT] AS NIGHT_CLASSES, [HIGHWAY] AS HIGHWAY_CLASSES, [STANDARD] AS ADDITIONAL_CLASSES FROM VEHICLE_CLASSES_CATEGORIZATION WHERE SUB_SERVICE_ID = {0} AND GENDER = UPPER('{1}');";


        //Added by Fahim Nasir 02/11/2017 10:14:41
        private const string QRY_CHECK_IF_COMPANY_EMPLOYEE = @"SELECT C.ID, CE.EMIRATES_ID FROM COMPANY C
                                                        INNER JOIN COMPANY_EMPLOYEE CE
                                                        ON C.ID = CE.COMPANY_ID
                                                        WHERE CE.EMIRATES_ID = '{0}'";
        public DAMiddlewareUtility()
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

        // AVANZA\muhammad.awais - 28/08/2017 16:47:43
        public DataTable GetClassesDetails(int subServiceId, string gender)
        {
            string query = string.Format(QRY_GET_CLASSES_DETAILS, subServiceId, gender);
            return this.Database.ExecuteDataSet(this.Transaction, CommandType.Text, query).Tables[0];
        }

        public DataTable GetMarkedData(string tableName, string criteria)
        {
            String query = String.Format(QRY_GET_MARKED_DATA, tableName, criteria);
            SqlCommand command = new SqlCommand(query, this.Connection);
            DataTable table = new DataTable(tableName);

            SqlDataReader reader = command.ExecuteReader();
            table.Load(reader);

            return table;
        }

        public void MarkSuccess(string tableName, string id)
        {
            String query = String.Format(QRY_MARK_STATUS_BY_ID, tableName, id, "SUCCEED");
            SqlCommand command = new SqlCommand(query, this.Connection);
            command.Transaction = this.Transaction;
            command.ExecuteNonQuery();
        }

        public void MarkFailed(string tableName, string id)
        {
            String query = String.Format(QRY_MARK_STATUS_BY_ID, tableName, id, "FAILED");
            SqlCommand command = new SqlCommand(query, this.Connection);
            command.ExecuteNonQuery();
        }

        public void MarkChildrenSuccess(string tableName, string id)
        {
            String query = String.Format(QRY_MARK_CHILDREN_STATUS_BY_ID, tableName, id, "SUCCEED");
            SqlCommand command = new SqlCommand(query, this.Connection);
            command.Transaction = this.Transaction;
            command.ExecuteNonQuery();
        }

        public void MarkChildrenFailed(string tableName, string id)
        {
            String query = String.Format(QRY_MARK_CHILDREN_STATUS_BY_ID, tableName, id, "FAILED");
            SqlCommand command = new SqlCommand(query, this.Connection);
            command.ExecuteNonQuery();
        }

        #region Exam Booking Details
        public DataTable GetCustomerServiceExamTable()
        {
            return this.SchemaManager.GetTableAsDefault(Entities.CUSTOMER_SERVICE_EXAM.TABLE_NAME);
        }
        public DataTable GetCustomerTableForStatusUpdateOnly()
        {
            try
            {
                DefaultTable table = new DefaultTable(Entities.CUSTOMER.TABLE_NAME);
                table.Columns.Add(Entities.CUSTOMER.ID, typeof(int));
                table.Columns.Add(Entities.CUSTOMER.STATUS_ID, typeof(int));
                return table;
            }
            catch (Exception ex)
            {
                Logger.getInstance().Error(MODULE_NAME, "GetCustomerTableForStatusUpdateOnly", ex);
                throw ex;
            }
        }
        public void InsertCustomerServiceExam(DataTable table)
        {
            try
            {
                String query = Shared.GetInsertQuery(table.Rows[0]);
                this.Database.ExecuteNonQuery(this.Transaction, CommandType.Text, query);
            }
            catch (Exception ex)
            {
                Logger.getInstance().Error(MODULE_NAME, "InsertCustomerServiceExam", ex);
                throw ex;
            }
        }
        public void UpdateCustomerStatusOnly(DataTable table)
        {
            try
            {
                String query = Shared.GetUpdateQuery(table.Rows[0]);
                this.Database.ExecuteNonQuery(this.Transaction, CommandType.Text, query);
            }
            catch (Exception ex)
            {
                Logger.getInstance().Error(MODULE_NAME, "UpdateCustomerStatusOnly", ex);
                throw ex;
            }
        }

        public bool UpdateCustomerServiceContractStatus(Enumaration.ServiceWorkFlowStatus? status, string CSCId)
        {
            try
            {
                string query = String.Format(QRY_UPDATE_CSC_STATUS, (int)status, CSCId);
                SqlCommand command = new SqlCommand(query, this.Connection);
                command.Transaction = this.Transaction;
                return (command.ExecuteNonQuery() > 0);
            }
            catch (Exception ex)
            {
                Logger.getInstance().Error(MODULE_NAME, "UpdateCustomerServiceContractStatus", ex);
                throw ex;
            }        
        }
        public DataTable GetRelatedDataForTestResult(string fileNumber, string examName, string branchCode)
        {
            String query = String.Format(QRY_GET_RELATED_VALUES_FOR_TEST_RESULT, 
                fileNumber, examName, branchCode, (int)Enumaration.LicenseStatus.New);
            DataSet dataSet = this.Database.ExecuteDataSet(this.Transaction, CommandType.Text, query);
            DataTable table = dataSet.Tables[0];
            return table;
        }

        //Added by Fahim Nasir on 20-9-2017
        public int GetExamScheduleInfo(string query)
        {
            return Convert.ToInt32(this.Database.ExecuteDataSet(this.Transaction, CommandType.Text, query).Tables[0].Rows[0]["RESULT"].ToString());
        }
        public DataTable GetRelatedData(string fileNumber, string examName, string branchCode, string serviceName)
        {
            String query = String.Format(QRY_GET_RELATED_VALUES, fileNumber, examName, branchCode, 
                serviceName);
            DataSet dataSet = this.Database.ExecuteDataSet(this.Transaction, CommandType.Text, query);
            DataTable table = dataSet.Tables[0];
            return table;
        }
        public void CancelExam(string customerId, string examId, string subServiceId)
        {
            String query = String.Format(QRY_CANCEL_EXAM, customerId, examId, subServiceId);
            SqlCommand command = new SqlCommand(query, this.Connection);
            command.Transaction = this.Transaction;
            command.ExecuteNonQuery();
        }
        #endregion

        #region Exam Results Update
        public void UpateResult(string customerId, string examId, string subServiceId, string examResult)
        {
            String query = string.Empty;
            try
            {
                query = String.Format(QRY_UPDATE_EXAM_RESULT,
                customerId, examId, subServiceId, examResult);
                SqlCommand command = new SqlCommand(query, this.Connection);
                command.Transaction = this.Transaction;
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Logger.getInstance().Debug("DAMiddlewareUtility", "UpdateResult", "QUERY : " + query);
                Logger.getInstance().Error("DAMiddlewareUtility", "UpdateResult", ex);                              
                throw ex;
            }
        }

        #endregion

        #region Customer & Service Contracts
        public DataTable GetRelatedDataForCustomerUpdate(string nationalityCode, string cityNameEn, string occupationCode)
        {
            try
            {
                String query = String.Format(QRY_GET_RELATED_DATA_FOR_CUSTOMER,
                                            cityNameEn, nationalityCode, 
                                            occupationCode);
                DataSet dataSet = this.Database.ExecuteDataSet(CommandType.Text, query);
                DataTable table = dataSet.Tables[0];
                return table;
            }
            catch (Exception ex)
            {
                Logger.getInstance().Debug("DAMiddlewareUtility", "GetRelatedDaaForCustomerUpdate", ex.Message);
                throw ex;
            }
        }
        public DataTable GetRelatedDataForLicenseUpdate(string subServiceNameEn)
        {
            String query = String.Format(QRY_GET_RELATED_DATA_FOR_LICENSE, subServiceNameEn.ToLower());
            DataSet dataSet = this.Database.ExecuteDataSet(CommandType.Text, query);
            DataTable table = dataSet.Tables[0];
            return table;
        }
        public DataTable GetCustomer(string trafficFileNumber, string customerEmirateIdNumber)
        {
            String query = String.Format(QRY_FIND_CSUTOMER, trafficFileNumber, customerEmirateIdNumber);
            DataSet dataSet = this.Database.ExecuteDataSet(CommandType.Text, query);
            DataTable table = dataSet.Tables[0];

            if (table.Rows.Count > 1)
                throw new Exception("Multiple Records found in ETAS database against (TRAFFIC FILE and EMAIRATE ID of 1 Record) received from RTA.");

            table.TableName = "CUSTOMER";

            return table;
        }
        public DataTable GetNewCustomerTable()
        {
            return this.SchemaManager.GetTableAsMaster("CUSTOMER");
        }
        public int AddCustomer(DataTable dtCustomer)
        {
            string query = Shared.GetInsertQuery(dtCustomer.Rows[0]);
            query += " SELECT SCOPE_IDENTITY() AS customerId;";
            object customerId = this.Database.ExecuteScalar(this.Transaction, CommandType.Text, query);
            return Convert.ToInt32(customerId);
        }
        public void UpdateCustomer(DataTable dtCustomer)
        {
            string query = Shared.GetUpdateQuery(dtCustomer.Rows[0]);
            this.Database.ExecuteNonQuery(this.Transaction, CommandType.Text, query);
        }
        public DataTable GetCustomerPreviousLicense(string customerId, string licenseNo)
        {
            String query = String.Format(QRY_FIND_CSUTOMER_LICENSE, customerId, licenseNo);
            DataSet dataSet = this.Database.ExecuteDataSet(CommandType.Text, query);
            DataTable table = dataSet.Tables[0];

            table.TableName = "CUSTOMER_PREVIOUS_LICENSE";

            return table;
        }
        public DataTable GetNewPreviousLicenseTable()
        {
            return this.SchemaManager.GetTableAsMaster("CUSTOMER_PREVIOUS_LICENSE");
        }
        public int AddCustomerPreviousLicense(DataTable dtExistingLicense)
        {
            string query = Shared.GetInsertQuery(dtExistingLicense.Rows[0]);
            query += " SELECT SCOPE_IDENTITY() AS licenseId;";
            object licenseId = this.Database.ExecuteScalar(this.Transaction, CommandType.Text, query);
            return Convert.ToInt32(licenseId);
        }
        public void UpdateCustomerPreviousLicense(DataTable dtExistingLicense)
        {
            string query = Shared.GetUpdateQuery(dtExistingLicense.Rows[0]);
            this.Database.ExecuteNonQuery(this.Transaction, CommandType.Text, query);
        }
        public DataTable GetServiceContract(string customerId, string subServiceName, DateTime registrationDate)
        {
            String query = String.Format(QRY_FIND_CSUTOMER_SERVICE_CONTRACT,
                //registrationDate.ToString("yyyyMMdd"),
                subServiceName, customerId);
            DataSet dataSet = this.Database.ExecuteDataSet(CommandType.Text, query);
            DataTable table = dataSet.Tables[0];

            table.TableName = "CUSTOMER_SERVICE_CONTRACT";

            return table;
        }
        public DataTable GetSubServiceIdByDescription(string subServiceName)
        {
            String query = String.Format(QRY_GET_MAIN_AND_SUB_SERVICE_ID, subServiceName);
            DataSet dataSet = this.Database.ExecuteDataSet(CommandType.Text, query);
            DataTable table = dataSet.Tables[0];
            return table;
        }
        public DataTable GetNewServiceContractTable()
        {
            return this.SchemaManager.GetTableAsMaster("CUSTOMER_SERVICE_CONTRACT");
        }

        //Added by Fahim Nasir 02/11/2017 11:14:25
        public DataTable GetCorporateClientInfo(string EmirateIdNumber)
        {
            string query = string.Format(QRY_CHECK_IF_COMPANY_EMPLOYEE, EmirateIdNumber);
            DataSet dataSet = this.Database.ExecuteDataSet(CommandType.Text, query);
            DataTable table = dataSet.Tables[0];
            return table;
        }
        //========================================

        public int AddServiceContract(DataTable dtContract)
        {
            string query = Shared.GetInsertQuery(dtContract.Rows[0]);
            query += " SELECT SCOPE_IDENTITY() AS contractId;";
            object contractId = this.Database.ExecuteScalar(this.Transaction, CommandType.Text, query);
            return Convert.ToInt32(contractId);
        }
        #endregion

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

