using eLearning.Common.Utils;
using eLearning.DAL.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DAL.Workflow.States
{
    // AVANZA\jawwad.ahmed - 04/08/2017 16:15:25
    public class PracticalScheduledBState : BaseState
    {
        public PracticalScheduledBState(WorkflowManager manager)
            : base(manager, WorkflowStates.PracticalScheduledB)
        {

        }

        public override BaseState GotoNextState()
        {
            //Added by Fahim Nasir on 26-9-2017
            DAWorkflowCallLog daWCL = new DAWorkflowCallLog();
            daWCL.CURRENT_STATE = "PracticalScheduledBState";
            daWCL.ContractId = this.DataAccess.ContractId;

            try
            {
                var hasAllClassesScheduled = this.DataAccess.HasAllClassesScheduled();
                var hasAttendedAllClasses = this.DataAccess.HasAttendedAllClasses();
                var IsPaymentE_Cleared = this.DataAccess.IsPaymentE_Cleared();

                daWCL.PROCESS += "hasAllClassesScheduled: " + hasAllClassesScheduled + ", ";
                daWCL.PROCESS += "hasAttendedAllClasses: " + hasAttendedAllClasses + ", ";
                daWCL.PROCESS += "IsPaymentE_Cleared: " + IsPaymentE_Cleared + ", ";

                if (hasAllClassesScheduled == true && hasAttendedAllClasses == true && IsPaymentE_Cleared == true)
                {
                    daWCL.RETURNED_STATE = "InternalAssessmentState";
                    daWCL.Log();
                    return new InternalAssessmentState(this.Manager);
                }
                else
                {
                    daWCL.RETURNED_STATE = daWCL.CURRENT_STATE;
                    daWCL.PROCESS += "ALL CLASSES ARE NOT SCHEDULED OR CUSTOMER HAS NOT ATTENDED ALL CLASSES OR PAYMENT E NOT CLEARED";
                    daWCL.Log();
                    LogMessages("ALL CLASSES ARE NOT SCHEDULED OR CUSTOMER HAS NOT ATTENDED ALL CLASSES OR PAYMENT E NOT CLEARED");
                    return this;
                }

            }
            catch (Exception ex)
            {
                daWCL.RETURNED_STATE = daWCL.CURRENT_STATE;
                daWCL.PROCESS = ex.Message;
                daWCL.Log();
                Logger.getInstance().Error("WorkflowManager", "PracticalScheduledBState::GotoNextState()", ex);
                LogMessages("ERROR: " + ex.Message);
                return this;
            }
        }
    }
}