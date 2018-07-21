using eLearning.Common.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using eLearning.DAL.DataAccess;

namespace DAL.Workflow.States
{
    // AVANZA\jawwad.ahmed - 24/07/2017 18:53:22
    public class PracticalSchedulePendingState : BaseState
    {
        public PracticalSchedulePendingState(WorkflowManager manager)
            : base(manager, WorkflowStates.PracticalSchedulePending)
        {

        }

        public override BaseState GotoNextState()
        {
            //Added by Fahim Nasir on 26-9-2017
            DAWorkflowCallLog daWCL = new DAWorkflowCallLog();
            daWCL.CURRENT_STATE = "PracticalSchedulePendingState";
            daWCL.ContractId = this.DataAccess.ContractId;

            try
            {
                var hasSomeScheduledClasses = this.DataAccess.HasSomeScheduledClasses();
                daWCL.PROCESS += "hasSomeScheduledClasses: " + hasSomeScheduledClasses + ", ";

                if (hasSomeScheduledClasses == true)
                {
                    daWCL.RETURNED_STATE = "PracticalScheduledState";
                    daWCL.Log();
                    return new PracticalScheduledState(this.Manager);
                }
                else
                {
                    daWCL.RETURNED_STATE = daWCL.CURRENT_STATE;
                    daWCL.PROCESS += "NO CLASSES ARE SCHEDULED";
                    daWCL.Log();
                    LogMessages("NO CLASSES ARE SCHEDULED");
                    return this;
                }
            }
            catch (Exception ex)
            {
                daWCL.RETURNED_STATE = daWCL.CURRENT_STATE;
                daWCL.PROCESS = ex.Message;
                daWCL.Log();
                Logger.getInstance().Error("WorkflowManager", "PracticalSchedulePendingState::GotoNextState()", ex);
                LogMessages("ERROR: " + ex.Message);
                return this;
            }
        }
    }
}