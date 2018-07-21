using eLearning.Common.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using eLearning.DAL.DataAccess;

namespace DAL.Workflow.States
{
    // AVANZA\jawwad.ahmed - 24/07/2017 18:52:39
    public class NewCustomerState : BaseState
    {
        public NewCustomerState(WorkflowManager manager)
            : base(manager, WorkflowStates.NewCustomer)
        {

        }

        
        public override BaseState GotoNextState()
        {
            //Added by Fahim Nasir on 26-9-2017
            DAWorkflowCallLog daWCL = new DAWorkflowCallLog();
            daWCL.CURRENT_STATE = "NewCustomerState";
            daWCL.ContractId = this.DataAccess.ContractId;
            try
            {
                var isCustomerApproved = this.DataAccess.IsCustomerApproved();
                
                //var hasSomeScheduledLectures = this.DataAccess.HasSomeScheduledLectures();  
                var IsPaymentA_Cleared = this.DataAccess.IsPaymentA_Cleared();
                var IsCurrentStagePaymentCleared = this.DataAccess.IsCurrentStagePaymentCleared();
                //if (isCustomerApproved && !hasSomeScheduledLectures && IsPaymentA_Cleared)

                daWCL.PROCESS += "isCustomerApproved : " + isCustomerApproved + ", ";
                daWCL.PROCESS += "IsPaymentA_Cleared : " + IsPaymentA_Cleared + ", ";
                daWCL.PROCESS += "IsCurrentStagePaymentCleared : " + IsCurrentStagePaymentCleared + ", ";
                if (isCustomerApproved && IsPaymentA_Cleared && IsCurrentStagePaymentCleared)
                {
                    daWCL.RETURNED_STATE = "LecturesSchedulePendingState";
                    daWCL.Log();
                    return new LecturesSchedulePendingState(this.Manager);
                }
                else
                {
                    daWCL.RETURNED_STATE = "NewCustomerState";
                    daWCL.PROCESS += "CUSTOMER IS NOT APPROVED OR PAYMENT A NOT CLEARED OR CURRENT STAGE PAYMENTS NOT CLEARED";
                    daWCL.Log();
                    LogMessages("CUSTOMER IS NOT APPROVED OR PAYMENT A NOT CLEARED OR CURRENT STAGE PAYMENTS NOT CLEARED");
                    return this;
                }
            }
            catch (Exception ex)
            {
                daWCL.RETURNED_STATE = daWCL.CURRENT_STATE;
                daWCL.PROCESS = ex.Message;
                daWCL.Log();
                Logger.getInstance().Error("WorkflowManager", "NewCustomerState::GotoNextState()", ex);
                LogMessages("ERROR: " + ex.Message);
                return this;
            }
        }
    }
}