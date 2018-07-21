using eLearning.Common.Config;
using eLearning.Common.Utils;
using eLearning.DAL.DataAccess;
using Escrow.Common.Utils;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;

namespace eLearning.DAL.DAClasses
{
    public class Holidays
    {
        private DAHolidays DA = new DAHolidays();
        public DataSet FetchHolidays()
        {
            return this.DA.SearchHolidays();
        }
        
        public DataSet GetById(int id)
        {
            return this.DA.Get(id);
        }

        public void Delete(DataRow row)
        {
            this.DA.Delete(row);
        }

        // Added by AVANZA\muhammad.uzair on 03/10/2017 13:50:36
        public void CancelHoliday(string date)
        {
            this.DA.CancelHoliday(date);
        }

        // Added by AVANZA\muhammad.uzair on 03/10/2017 15:18:44
        public bool CheckHolidayExist(string date)
        {
            var result = this.DA.CheckHolidayExist(date);
            if (result > 0)
                return false;
            return true;
        }

        public void Save(DataRow row)
        {
            this.DA.Update(row);
        }

        public void Add(DataRow row)
        {
            this.DA.Insert(row);
        }

        // Added by AVANZA\muhammad.uzair on 03/10/2017 12:56:20
        public void UpdateClassesAndLectures(DateTime date)
        {
            this.DA.UpdateClassesAndLectures(date);
        }

        public int GetNextId()
        {
            return this.DA.GetNextToken();
        }

        //AVANZA\muhammad.uzair 8/4/2017
        public DataSet ImpactReport(DateTime date)
        {
            return this.DA.ImpactReport(date);
        }

        // Added by AVANZA\muhammad.uzair on 25/09/2017 11:27:10
        public void SendHolidayNotification(string date)
        {
            string MODULE_NAME = "Holiday";
            string MethodName = "SendHolidayNotification";
            DataTable ds = this.DA.CheckClassesOnDate(date);
            DASystemConfiguration sysConfig = new DASystemConfiguration();
            foreach (DataRow row in ds.Rows)
            {
                Notification notification = new Notification();
                DataTable dt;
                try
                {
                    notification.AdapterChannelId = DALConstants.AdapterChannels.SMS_CHANNEL1;
                    notification.RetryCount = Constants.RETRY_COUNT;
                    dt = sysConfig.GetSystemConfigurationByKey("COMPANY_NAME");
                    notification.NsFrom = dt.Rows[0][Entities.SystemConfiguration.VALUE].ToString();
                    dt = sysConfig.GetSystemConfigurationByKey("COMPANY_EMAIL");
                    notification.NsFromAdd = dt.Rows[0][Entities.SystemConfiguration.VALUE].ToString();
                    notification.IS_HTML = false;
                    notification.Priority = (int)Enumaration.NotificationPriority.High;
                    notification.RecipientTo = row["MOBILE"].ToString();
                    StringBuilder sb = new StringBuilder(notification.GetMessageBodyFromMessageKey("HolidayCancellationNotification"));
                    string message = sb.Replace("#{Customer.FirstName}", row["NAME_EN"].ToString()).Replace("#{Customer.Date}", date).ToString();
                    notification.Body = message;
                    notification.Subject = notification.GetMessageSubjectFromMessageKey("HolidayCancellationNotification");
                    notification.CreatedBy = ConfigurationManager.AppSettings["CREATED_BY"];
                    notification.InsertNotification(notification);
                    Logger.getInstance().Debug(MODULE_NAME, MethodName, "Holiday Notification Sent Successfully");
                }
                catch (Exception ex)
                {
                    Logger.getInstance().Error(MODULE_NAME, MethodName, ex);
                }
            }

        }

        public static void SendLectureAttendanceToRTA()
        {
            string MODULE_NAME = "MarkHolidays";
            string MethodName = "SendLectureAttendanceToRTA";
            Notification notification = new Notification();
            DASystemConfiguration sysConfig = new DASystemConfiguration();
            DataTable dt;
            try
            {
                notification.AdapterChannelId = DALConstants.AdapterChannels.SMTP_CHANNEL1;
                notification.RetryCount = Constants.RETRY_COUNT;
                dt = sysConfig.GetSystemConfigurationByKey("COMPANY_NAME");
                notification.NsFrom = dt.Rows[0][Entities.SystemConfiguration.VALUE].ToString();
                dt = sysConfig.GetSystemConfigurationByKey("COMPANY_EMAIL");
                notification.NsFromAdd = dt.Rows[0][Entities.SystemConfiguration.VALUE].ToString();
                notification.IS_HTML = false;
                notification.Priority = (int)Enumaration.NotificationPriority.High;
                dt = sysConfig.GetSystemConfigurationByKey("NOTIFICATION_EMAIL_RECIPIENTS_TO");
                notification.RecipientTo = dt.Rows[0][Entities.SystemConfiguration.VALUE].ToString();
                dt = sysConfig.GetSystemConfigurationByKey("NOTIFICATION_EMAIL_RECIPIENTS_CC");
                notification.RecipientCC = dt.Rows[0][Entities.SystemConfiguration.VALUE].ToString();
                dt = sysConfig.GetSystemConfigurationByKey("LECTURE_ATTENDANCE_RPT_UPLOAD_PATH");
                notification.DocumentList = dt.Rows[0][Entities.SystemConfiguration.VALUE].ToString() + "Attendance-" + DateTime.Now.ToString("dd-MM-yyyy") + "\\";
                notification.Body = notification.GetMessageBodyFromMessageKey("LectureAttendanceNotification");
                notification.Subject = notification.GetMessageSubjectFromMessageKey("LectureAttendanceNotification");
                notification.CreatedBy = ConfigurationManager.AppSettings["CREATED_BY"];
                notification.InsertNotification(notification);
                Logger.getInstance().Debug(MODULE_NAME, MethodName, "Lectures Sent Successfully");
                Console.WriteLine("Lectures Sent Successfully");
                //Wait for 3 seconds
                Thread.Sleep(3000);
            }
            catch (Exception ex)
            {
                Logger.getInstance().Error(MODULE_NAME, MethodName, ex);
                Console.WriteLine("Lecture Notification Failed");
                // Wait For 5 seconds
                Thread.Sleep(5000);
            }
        }

    }
}
