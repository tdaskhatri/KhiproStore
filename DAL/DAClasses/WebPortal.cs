using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using eLearning.DAL.DataAccess;
using eLearning.DAL.DAClasses;
using System.Data;
using eLearning.Common.Utils;

namespace eLearning.DAL.DAClasses
{
    public class WebPortal
    {
        private const string MODULE_NAME = "WebPortal";
        Logger logger;
        DAInstructor instructor = new DAInstructor();
        DACustomer customer = new DACustomer();
        DACompany company = new DACompany();

        // Added by VIJAY\Administrator on 25/10/2017 17:32:0/ Added by VIJAY\Administrator on 25/10/2017 17:32:05
        public DataTable PracticalSchedule(string studentid,string fromDate,string endDate)
        {
            DataTable dt;
            dt = customer.GetPracticalSchedule(studentid, fromDate, endDate);
            return dt;
        }

        // Added by VIJAY\Administrator on 25/10/2017 17:32:1
        public DataTable ViewPayment(string userid)
        {
            DataTable dt;
            dt = customer.GetPaymentHistory(userid);
            return dt;
        }

        // Added by VIJAY\Administrator on 25/10/2017 17:33:1/ 
        public DataTable ViewExamResult(string userid)
        {
            DataTable dt;
            dt = customer.GetExamsForService(userid);
            return dt;
        }

        public DataTable ViewProfile(string userid)
        {
            DataTable dt;
            DAUser DA = new DAUser();
            dt = DA.GetUserTypeById(userid);
            if(dt.Rows.Count>0)
            if (Convert.ToInt32(dt.Rows[0]["USER_TYPE_ID"]) == (int)Enumaration.UserType.Student)
            {
                DACustomer DAC = new DACustomer();
                DataTable customer = DAC.GetCustomer(dt.Rows[0]["ID"].ToString(), dt.Rows[0]["REFERENCE_TYPE_ID"].ToString());
                dt = customer;
            }
            return dt;
        }

        public DataTable ViewLecture(string studentid,string fromDate,string endDate)
        {
            DataTable dt;
            dt = customer.GetTheoryClassSchedule(studentid, fromDate, endDate);
            return dt;
        }


        
        #region Instructors
        
        // Added by AVANZA\muhammad.uzair on 25/10/2017 14:27:20
        // Used to get Instructor profile information
        public DataTable GetInstructorProfile(string userId, string instructorId)
        {
            return instructor.GetInstructor(userId, instructorId);
        }
        
        // Added by AVANZA\muhammad.uzair on 25/10/2017 13:57:33
        // Used to get instructor practical class or assessment schedule based on practical type
        public DataTable GetInstructorPracticalSchedule(string userId, string fromDate, string endDate, string practicalType)
        {
            return instructor.GetSchedule(userId, fromDate, endDate, practicalType);
        }

        public DataTable GetInstructorPracticalScheduleExt(string userId, string fromDate, string endDate, string practicalType)
        {
            return instructor.GetScheduleExt(userId, fromDate, endDate, practicalType);
        }

        // Added by AVANZA\muhammad.uzair on 25/10/2017 14:07:05
        // Used to get instructor theory schedule
        public DataTable GetInstructorTheorySchedule(string userId, string fromDate, string toDate)
        {
            return instructor.GetInstructorTheorySchedule(userId, fromDate, toDate);
        }

        // Added by AVANZA\muhammad.uzair on 25/10/2017 14:13:17
        // Used to mark customer attendance
        public bool MarkCustomerAttendance(DataTable dtCustomerAttendance)
        {
            return new DACustomerManualAttendance().InsertCustomerAttendance(dtCustomerAttendance);
        }

        // Added by AVANZA\muhammad.uzair on 25/10/2017 14:15:43
        //Used to mark customer assessment
        public bool MarkCustomerAssessment(DataTable dt, System.Byte[] fileBytes)
        {
            return new DACustomerAssessment().InsertAssessment(dt, fileBytes);
        }
        public DataTable GetCompanyTraining(int companyId)
        {
            return company.GetCompanyTraining(companyId);
        }
        public DataTable GetCompanyTrainingSchedule(int trainingId, int CompanyId)
        {
            return company.GetCompanyTrainingSchedule(trainingId, CompanyId);
        }
        public DataTable GetCompanyTrainingEmployees(int trainingID)
        {
            return company.GetCompanyTrainingEmployees(trainingID);
        }
        
        // Added by BSD-004\Administrator as Onsite Support on 02/01/2018 15:47:17 
        public bool CheckFeedBackExists(int trainingId, int companyId)
        {
            return company.CheckFeedBackExists(trainingId, companyId);
        }

        #endregion
    }
}
