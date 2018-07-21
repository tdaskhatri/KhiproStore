using eLearning.Common.Utils;
using eLearning.DAL.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DAL.Workflow.States
{
    // AVANZA\jawwad.ahmed - 24/07/2017 18:54:08
    public class LicenseIssuedState : BaseState
    {
        public LicenseIssuedState(WorkflowManager manager)
            : base(manager, WorkflowStates.LicenseIssued)
        {

        }

        public override BaseState GotoNextState()
        {
            //Added by Fahim Nasir on 26-9-2017
            DAWorkflowCallLog daWCL = new DAWorkflowCallLog();
            daWCL.CURRENT_STATE = "LicenseIssuedState";
            daWCL.ContractId = this.DataAccess.ContractId;

            try
            {
                daWCL.RETURNED_STATE = daWCL.CURRENT_STATE;
                daWCL.PROCESS += "LICENSE IS ALREADY ISSUED";
                daWCL.Log();
                LogMessages("LICENSE IS ALREADY ISSUED");
                return this;
            }
            catch (Exception ex)
            {
                daWCL.RETURNED_STATE = daWCL.CURRENT_STATE;
                daWCL.PROCESS = ex.Message;
                daWCL.Log();
                Logger.getInstance().Error("WorkflowManager", "LicenseIssuedState::GotoNextState()", ex);
                LogMessages("ERROR: " + ex.Message);
                return this;
            }
        }
    }
}