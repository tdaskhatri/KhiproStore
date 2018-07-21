using eLearning.Common.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using eLearning.DAL.DataAccess;

namespace DAL.Workflow.States
{
    // AVANZA\jawwad.ahmed - 24/07/2017 18:53:10
    public class LecturesCompletedState : BaseState
    {
        public LecturesCompletedState(WorkflowManager manager)
            : base(manager, WorkflowStates.LecturesCompleted)
        {

        }

        public override BaseState GotoNextState()
        {
            //Added by Fahim Nasir on 26-9-2017
            DAWorkflowCallLog daWCL = new DAWorkflowCallLog();
            daWCL.CURRENT_STATE = "LecturesCompletedState";
            daWCL.ContractId = this.DataAccess.ContractId;

            try
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
                    daWCL.RETURNED_STATE = daWCL.CURRENT_STATE;
                    daWCL.PROCESS += "CUSTOMER HAS NO RTA SCHEDULED KNOWLEDGE TEST OR PAYMENT B NOT CLEARED";
                    daWCL.Log();
                    LogMessages("CUSTOMER HAS NO RTA SCHEDULED KNOWLEDGE TEST OR PAYMENT B NOT CLEARED");
                    return this;
                }
            }
            catch (Exception ex)
            {
                daWCL.CURRENT_STATE = "LecturesCompletedState";
                daWCL.RETURNED_STATE = daWCL.CURRENT_STATE;
                daWCL.PROCESS = ex.Message;
                daWCL.Log();
                Logger.getInstance().Error("WorkflowManager", "LecturesCompletedState::GotoNextState()", ex);
                LogMessages("ERROR: " + ex.Message);
                return this;
            }
        }
    }
}