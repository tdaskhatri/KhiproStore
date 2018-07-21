using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text;
//using System.Messaging; -- Tariq
using eLearning.Common.Utils;
using eLearning.DAL.DataAccess;
using System.Data.Common;

namespace eLearning.DAL.DAClasses
{

    [Serializable]
    public class Notification
    {
        DANotification daNotification;
        Logger logger;
        private const string MODULE_NAME = "Notification";
        public Notification()
        {
            daNotification = new DANotification();
            logger = Logger.getInstance();
        }
        #region Member Variables
        // protected StringMap<String> protocolFields;

        protected string content;
        private String createdOn;
        private String createdBy;
        private String updatedOn;
        private String updatedBy;
        private String document_list;
        protected ArrayList documentList;
        //time priority in seconds.
        private long waitTime;
        //private MessagePriority priority= MessagePriority.Normal; --Tariq
        private Int32 priority = (int)Common.Utils.Enumaration.NotificationPriority.High;
        private String body;
        private String adapterchannelId;
        private String locale;
        private int retrycount;
        private String statustext = string.Empty;

        private String protocolfields;
        private String recipientbcclist;
        private String Recipientcclist;
        private String recipientToList;
        private DateTime senttime;
        private String nsFrom;
        private Enumaration.NotificationState state;
        private String notificationid;
        private String subject;
        private long timeout;
        private bool is_html = false;
        private String ref1;
        private String ref3;
        private String ref2;
        private String nsfromadd;



        public bool IS_HTML
        {
            get { return is_html; }
            set { is_html = value; }
        }


        public String REF1
        {
            get { return ref1; }
            set { ref1 = value; }
        }


        public String REF2
        {
            get { return ref2; }
            set { ref2 = value; }
        }

        public String REF3
        {
            get { return ref3; }
            set { ref3 = value; }
        }

        #endregion
        #region Getters and Setters
        public Int32 Priority
        {
            get { return this.priority; }
            set { this.priority = value; }
        }
        public String NsFromAdd
        {
            get { return nsfromadd; }
            set { nsfromadd = value; }
        }
        public String Body
        {
            get { return this.body; }
            set { this.body = value; }
        }
        public String Locale
        {
            get { return this.locale; }
            set { this.locale = value; }
        }
        public int RetryCount
        {
            get { return this.retrycount; }
            set { this.retrycount = value; }
        }
        public String StatusText
        {
            get { return this.statustext; }
            set { this.statustext = value; }
        }
        public String Subject
        {
            get { return this.subject; }
            set { this.subject = value; }
        }
        public long TimeOut
        {
            get { return this.timeout; }
            set { this.timeout = value; }
        }
        public String DocumentList
        {
            get { return document_list; }
            set { document_list = value; }
        }
        public String AdapterChannelId
        {
            get { return adapterchannelId.ToUpper(); }
            set { adapterchannelId = value; }
        }
        public string Content
        {
            get { return content; }
            set { content = value; }
        }
        public String CreatedOn
        {
            get { return createdOn; }
            set { createdOn = value; }
        }
        public String CreatedBy
        {
            get { return createdBy; }
            set { createdBy = value; }
        }
        public String UpdatedOn
        {
            get { return updatedOn; }
            set { updatedOn = value; }
        }
        public String UpdatedBy
        {
            get { return updatedBy; }
            set { updatedBy = value; }
        }
        public String NotificationId
        {
            get { return this.notificationid; }
            set { this.notificationid = value; }
        }
        public Enumaration.NotificationState State
        {
            get { return this.state; }
            set { this.state = value; }
        }
        public String NsFrom
        {
            get { return this.nsFrom; }
            set { this.nsFrom = value; }
        }
        public DateTime SentTime
        {
            get { return this.senttime; }
            set { this.senttime = value; }
        }
        public String RecipientTo
        {
            get { return this.recipientToList; }
            set { recipientToList = value; }
        }
        public String RecipientCC
        {
            get { return this.Recipientcclist; }
            set { Recipientcclist = value; }
        }
        public String RecipientBCC
        {
            get { return this.recipientbcclist; }
            set { recipientbcclist = value; }
        }
        public String ProtocolFields
        {
            get { return ""; }
            set { protocolfields = value; }
        }

        #endregion
        #region Member Function

        public ArrayList GetDocumentList()
        {
            documentList = new ArrayList();
            String[] strArray = null;
            char[] delimiters = { ',', ';', '|' };
            if (!String.IsNullOrEmpty(this.document_list))
                strArray = this.document_list.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
            else
                return null;
            foreach (String s in strArray)
                documentList.Add(s);
            return documentList;
        }
        private String getRecipientList(ArrayList recipientList)
        {

            String retStr = "";
            if (recipientList != null && recipientList.Count > 0)
            {
                for (int i = 0; i < recipientList.Count; i++)
                    retStr += recipientList[i].ToString() + ",";
            }
            else return "";
            return retStr.Substring(0, retStr.Length - 1);
        }

        /// <summary>
        /// Set RetryCount and TimeOut values for this notification from NS_ADAPTER_CHANNEL using ADAPTER_CHANNEL_ID.
        /// </summary>

        public void Set()
        {
            DataSet _dsChannelInfo = getChannelInfo();
            this.retrycount = Convert.ToInt32(_dsChannelInfo.Tables[0].Rows[0]["RETRY_COUNT"]);
            this.timeout = Convert.ToInt64(_dsChannelInfo.Tables[0].Rows[0]["TIME_OUT"]);
        }
        public long GetRetryInterval()
        {
            DataSet _dsChannelInfo = getChannelInfo();
            return Convert.ToInt64(_dsChannelInfo.Tables[0].Rows[0]["RETRY_INTERVAL"]);

        }
        private DataSet getChannelInfo()
        {
            // Get * Info From NS_ADAPTER_CHANNEL  for ADAPTER_CHANNEL_ID 
            DANotification oDANotification = new DANotification();
            return oDANotification.getChannelInfo(this.AdapterChannelId);

        }
        private ArrayList prepareRecipientList(String strRecipientList)
        {
            String[] strArray = null;
            ArrayList recipientList = new ArrayList();
            char[] delimiters = { ',' };
            if (strRecipientList != null && !String.IsNullOrEmpty(strRecipientList))
                strArray = strRecipientList.Split(delimiters);
            else
                return recipientList;
            RecipientInfo recipientInfo = new RecipientInfo();
            foreach (String s in strArray)
            {
                recipientInfo.Address = s;
                recipientList.Add(recipientInfo);
            }
            return recipientList;
        }


        /* public void setRecipientToList(String recipientToList) 
         {
             this.recipientToList = this.prepareRecipientList(recipientToList);
         }

         public void setRecipientCcList(String recipientCcList) 
         {
             this.Recipientcclist = this.prepareRecipientList(recipientCcList);
         }

         public void setRecipientBccList(String recipientBccList) 
         {
             this.recipientbcclist = this.prepareRecipientList(recipientBccList);
         }

         public String GetRecipientToList() 
         {
             return this.getRecipientList(recipientToList);
         }

         public String GetRecipientCcList() {
             return this.getRecipientList(Recipientcclist);
         }

         public String GetRecipientBccList() {
             return this.getRecipientList(recipientbcclist);
         }
         */
        public long GetWaitTime()
        {
            return waitTime;
        }

        public string SelectMaxNotificationId()
        {
            DANotification oDANotification = new DANotification();
            return oDANotification.GetMaxNotificationId();
        }
        /* -- Tariq
        public void SetNotificationId()
        {
            DANotification oDANotification=new DANotification();
            this.NotificationId = oDANotification.GetNotificationId(this.statustext);

        }
         * */

       //Added by Fahim Nasir 08/11/2017 11:54:04
       //Transaction Support
        public void InsertNotification(Notification notification, DbTransaction dbTran )
        {
            DANotification oDANotification = new DANotification();
            this.NotificationId = Convert.ToString(oDANotification.InsertNotification(notification, dbTran));

        }
        public void InsertNotification(Notification notification)
        {
            DANotification oDANotification = new DANotification();
            this.NotificationId = Convert.ToString(oDANotification.InsertNotification(notification));

        }
        public void Update(Notification notification)
        {
            DANotification _daNotification = new DANotification();
            _daNotification.Update(notification);

        }
        public void SetWaitTime(long waitTime)
        {
            this.waitTime = waitTime;
        }


        #endregion
        #region Functions

        public string GetMessageBodyFromMessageKey(string key)
        {
            return this.daNotification.GetMessageBodyFromMessageKey(key);
        }

        public string GetMessageSubjectFromMessageKey(string key)
        {
            return this.daNotification.GetMessageSubjectFromMessageKey(key);
        }

        public void InsertPinCodeNotification(string channel, string email, string company, string body, string senderEmail)
        {
            try
            {
                this.daNotification.InsertPinCodeNotification(channel, email, company, body, senderEmail);
            }
            catch (Exception ex)
            {
                logger.Error(MODULE_NAME, "InsertPinCodeNotification", ex);
                throw ex;
            }
        }

        public void UpdatePinCodeInUsers(string pinCode, DateTime pinExpiry, string userId)
        {
            try
            {
                this.daNotification.UpdatePinCodeInUsers(pinCode, pinExpiry, userId);
            }
            catch (Exception ex)
            {
                logger.Error(MODULE_NAME, "UpdatePinCodeInUsers", ex);
                throw ex;
            }
        }

        public int PinExpiryTimeDifference(DateTime currentTime, string userId, string pinCode)
        {
            try
            {
                return this.daNotification.PinExpiryTimeDifference(currentTime, userId, pinCode);
            }
            catch (Exception ex)
            {
                logger.Error(MODULE_NAME, "PinExpiryTimeDifference", ex);
                throw ex;
            }
        }

        public void UpdateUserPassword(string password, string userId)
        {
            try
            {
                this.daNotification.UpdateUserPassword(password, userId);
            }
            catch (Exception ex)
            {
                logger.Error(MODULE_NAME, "UpdateUserPassword", ex);
                throw ex;
            }
        }
        #endregion
    }
}
