using eLearning.Common.Utils;
using eLearning.DAL.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DAL.Workflow.States
{
    // AVANZA\jawwad.ahmed - 24/07/2017 18:54:02
    public class LicenseIssuancePendingState : BaseState
    {
        public LicenseIssuancePendingState(WorkflowManager manager)
            : base(manager, WorkflowStates.LicenseIssuancePending)
        {

        }

        public override BaseState GotoNextState()
        {
            //Added by Fahim Nasir on 26-9-2017
            DAWorkflowCallLog daWCL = new DAWorkflowCallLog();
            daWCL.CURRENT_STATE = "LicenseIssuancePendingState";
            daWCL.ContractId = this.DataAccess.ContractId;

            try
            {
                var isLicenseIssued =  this.DataAccess.IsLiceneseIssued();
                var IsPaymentG_Cleared = this.DataAccess.IsPaymentG_Cleared();

                daWCL.PROCESS += "isLicenseIssued: " + isLicenseIssued + ", ";
                daWCL.PROCESS += "IsPaymentG_Cleared: " + IsPaymentG_Cleared + ", ";

                // Commented by MUHAMMADUZAIR\avanza on 19/09/2017 10:22:57
                // No need to check license issued or not only payment need to be checked
                //if (isLicenseIssued == true)
                if (IsPaymentG_Cleared == true)
                {
                    this.DataAccess.IssueLicense();
                    daWCL.RETURNED_STATE = "LicenseIssuedState";
                    daWCL.Log();
                    return new LicenseIssuedState(this.Manager);
                }
                else
                {
                    daWCL.RETURNED_STATE = daWCL.CURRENT_STATE;
                    daWCL.PROCESS += "RELEVANT PAYMENT IS NOT CLEARED";
                    daWCL.Log();
                    LogMessages("RELEVANT PAYMENT IS NOT CLEARED");
                    return this;
                }
            }
            catch (Exception ex)
            {
                daWCL.CURRENT_STATE = "LicenseIssuancePendingState";
                daWCL.RETURNED_STATE = daWCL.CURRENT_STATE;
                daWCL.PROCESS = ex.Message;
                daWCL.Log();
                Logger.getInstance().Error("WorkflowManager", "LicenseIssuancePendingState::GotoNextState()", ex);
                LogMessages("ERROR: " + ex.Message);
                return this;
            }
        }
    }
}