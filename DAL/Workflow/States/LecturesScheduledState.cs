using eLearning.Common.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using eLearning.DAL.DataAccess;

namespace DAL.Workflow.States
{
    // AVANZA\jawwad.ahmed - 24/07/2017 18:53:03
    public class LecturesScheduledState : BaseState
    {
        public LecturesScheduledState(WorkflowManager manager)
            : base(manager, WorkflowStates.LecturesScheduled)
        {

        }

        public override BaseState GotoNextState()
        {
            //Added by Fahim Nasir on 26-9-2017
            DAWorkflowCallLog daWCL = new DAWorkflowCallLog();
            daWCL.CURRENT_STATE = "LecturesScheduledState";
            daWCL.ContractId = this.DataAccess.ContractId;

            try
            {
                var hasAllLecturesScheduled = this.DataAccess.HasAllLecturesScheduled();
                var hasAttendedAllLectures = this.DataAccess.HasAttendedAllLectures();

                daWCL.PROCESS += "hasAllLecturesScheduled: " + hasAllLecturesScheduled + ", ";
                daWCL.PROCESS += "hasAttendedAllLectures: " + hasAttendedAllLectures + ", ";

                if (hasAllLecturesScheduled == true && hasAttendedAllLectures == true)
                {
                    var hasRTAScheduledKnowledgeTest = this.DataAccess.HasRTAScheduledKnowledgeTest();
                    var IsPaymentB_Cleared = this.DataAccess.IsPaymentB_Cleared();

                    daWCL.PROCESS += "hasRTAScheduledKnowledgeTest: " + hasRTAScheduledKnowledgeTest + ", ";
                    daWCL.PROCESS += "IsPaymentB_Cleared: " + IsPaymentB_Cleared + ", ";

                    if (hasRTAScheduledKnowledgeTest == true && IsPaymentB_Cleared == true)
                    {
                        daWCL.RETURNED_STATE = "KnowledgeTestScheduledState";
                        daWCL.Log();
                        return new KnowledgeTestScheduledState(this.Manager);
                    }
                    else
                    {
                        daWCL.RETURNED_STATE = "LecturesCompletedState";
                        daWCL.Log();
                        return new LecturesCompletedState(this.Manager);
                    }
                }
                else
                {
                    daWCL.RETURNED_STATE = daWCL.CURRENT_STATE;
                    daWCL.PROCESS += "ALL LECTURES ARE NOT SCHEDULED OR HAS NOT ATTENDED ALL LECTURES";
                    daWCL.Log();
                    LogMessages("ALL LECTURES ARE NOT SCHEDULED OR HAS NOT ATTENDED ALL LECTURES");
                    return this;
                }

            }
            catch (Exception ex)
            {
                daWCL.CURRENT_STATE = "LecturesScheduledState";
                daWCL.RETURNED_STATE = daWCL.CURRENT_STATE;
                daWCL.PROCESS = ex.Message;
                daWCL.Log();
                Logger.getInstance().Error("WorkflowManager", "LectureScheduledState::GotoNextState()", ex);
                LogMessages("ERROR: " + ex.Message);
                return this;
            }
        }
    }
}