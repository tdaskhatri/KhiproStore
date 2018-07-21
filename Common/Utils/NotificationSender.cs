using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
namespace eLearning.Common.Utils
{
    public class NotificationSender
    {
        
        private static volatile NotificationSender instance = null;

        private string userName;
        private string password;
        private string mode;

        
        private NotificationSender() { }
        public static NotificationSender GetInstance()
        { 
          if(  instance == null )
          {
                  instance = new NotificationSender();
              
          }
          return instance;
        }
        public static void Initialize(string userName, string password, string mode)
        {
          GetInstance();
          instance.userName = userName;
          instance.password = password;
          instance.mode  = mode;
        }
        public void sendNotification(string messageTemplate ,List<ContactInfo> list,string testName,string testDate,string testTime,string room)
        {

            foreach (ContactInfo contact in list)
            {
                if (!String.IsNullOrEmpty(contact.MobileNo))
                {
                    Notification notification = new Notification(userName, password, mode, messageTemplate, contact,
                                                                 testName, testDate, testTime, room, "04-2080735", "", "", ""
                                                                );
                    ThreadPool.QueueUserWorkItem(delegate{notification.sendSMS();});
                   
                }
              
            }
          
        
        
        }
       
    }
}
