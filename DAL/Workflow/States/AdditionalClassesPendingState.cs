using DAL.Workflow;
using DAL.Workflow.States;
using eLearning.Common.Utils;
using eLearning.DAL.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.Workflow.States
{

    // added by MUHAMMAD.AWAIS 8/8/2017

    class AdditionalClassesPendingState : BaseState
    {
        public AdditionalClassesPendingState(WorkflowManager manager)
            : base(manager, WorkflowStates.AdditionalClassesPending)
        {

        }

        public override BaseState GotoNextState()
        {
            //Added by Fahim Nasir on 26-9-2017
            DAWorkflowCallLog daWCL = new DAWorkflowCallLog();
            daWCL.CURRENT_STATE = "AdditionalClassesPendingState";
            daWCL.ContractId = this.DataAccess.ContractId;
            try
            {
                var hasSomeScheduledClasses = this.DataAccess.HasSomeScheduledClasses();
                daWCL.PROCESS += "hasSomeScheduledClasses: " + hasSomeScheduledClasses + ", ";

                if (hasSomeScheduledClasses == true)
                {
                    daWCL.RETURNED_STATE = "AdditionalClassesScheduledState";
                    daWCL.Log();
                    return new AdditionalClassesScheduledState(this.Manager);
                }
                else
                {
                    daWCL.RETURNED_STATE = daWCL.CURRENT_STATE;
                    daWCL.PROCESS += "ADDITIONAL ALLOTED CLASSES ARE NOT SCHEDULED.";
                    daWCL.Log();
                    LogMessages("ADDITIONAL ALLOTED CLASSES ARE NOT SCHEDULED.");
                    return this;
                }
            }
            catch (Exception ex)
            {
                daWCL.CURRENT_STATE = "AdditionalClassesPendingState";
                daWCL.RETURNED_STATE = daWCL.CURRENT_STATE;
                daWCL.PROCESS = ex.Message;
                daWCL.Log();
                Logger.getInstance().Error("WorkflowManager", "AdditionalClassesPendingState::GotoNextState()", ex);
                LogMessages("ERROR: " + ex.Message);
                return this;
            }
        }


    }
}
