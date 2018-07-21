using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace eLearning.Common.Utils
{
    class Notification
    {
        string MODULE_NAME = "Notification";
        protected Logger logger = Logger.getInstance();
        private Int64 messageId;
        private string userName;
        private string password;
        private string mode;
        private string messageTemplate;
        private ContactInfo contactInfo;
        private string Param1;
        private string Param3;
        private string Param2;
        private string Param4;
        private string Param5;
        private string Param6;
        private string Param7;
        private string Param8;
        
        public Notification( string userName, string password, string mode, string messageTemplate, ContactInfo contact,
                             string Param1, string Param2,string Param3, string Param4, string Param5, string Param6, 
                             string Param7, string Param8
                           )
        {

          this.messageId = messageId;
          this.userName = userName;
          this.password = password;
          this.mode = mode;

          this.messageTemplate = messageTemplate;
          
            this.contactInfo = contact;
          
          this.Param1 = Param1;
          this.Param2 = Param2;
          this.Param3 = Param3;
          this.Param4 = Param4;
          this.Param5 = Param5;
          this.Param6 = Param6;
          this.Param7 = Param7;
          this.Param8 = Param8;
        }
      
        public void sendSMS()
        {
            string response = string.Empty;
            try
            {
                
                SMSService.sms_elearningSoapClient client = new SMSService.sms_elearningSoapClient();
                //Emp ID {1}. Dear {2}, You are invited to attend {3} on {4}. File number {5}. Mobile {0}. Dubai Taxi 04-2080735
                //Current
                //Dear {2},  Your test for {3}  is scheduled on {4} at {5} in training room {6} at DTQI. For further information, please call {7}. DTC-DTQI
                response = client.send_elearning_sms( messageTemplate,
                                                      contactInfo.MobileNo,
                                                      contactInfo.Id,
                                                      contactInfo.Name,
                                                      Param1,
                                                      Param2,
                                                      Param3,
                                                      Param4,
                                                      Param5,
                                                      Param6,
                                                      userName,
                                                      password,
                                                      mode
                                                    );
                logger.Debug(MODULE_NAME, "sendSMS", "Response From dtc webservice::"+response);
            }
            catch (Exception e)
            {
                logger.Error(MODULE_NAME, "sendSMS", "Error Occured::", e);

            }
            //return response;
        }


        public void UpdateMessageStatus(Int64 msgId, int status)
        { 
        
        
        }
    }
}
