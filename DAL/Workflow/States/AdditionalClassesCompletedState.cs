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

    class AdditionalClassesCompletedState : BaseState
    {
        public AdditionalClassesCompletedState(WorkflowManager manager)
            : base(manager, WorkflowStates.AdditionalClassesCompleted)
        {

        }

        public override BaseState GotoNextState()
        {
            //Added by Fahim Nasir on 26-9-2017
            DAWorkflowCallLog daWCL = new DAWorkflowCallLog();
            daWCL.CURRENT_STATE = "AdditionalClassesCompletedState";
            daWCL.ContractId = this.DataAccess.ContractId;
            try
            {               
                var hasRTAScheduledRoadTest = this.DataAccess.HasRTAScheduledRoadTest();
                var HasETDIScheduledInternalAssessmentTest = this.DataAccess.HasETDIScheduledInternalAssessmentTest();
                int HasPassesdETDIAssessment = this.DataAccess.HasPassedInternalAssessmentTest();
                var isPaymentE_Cleared = this.DataAccess.IsPaymentE_Cleared();
                var isPaymentF_Cleared = this.DataAccess.IsPaymentF_Cleared();

                daWCL.PROCESS += "hasRTAScheduledRoadTest: " + hasRTAScheduledRoadTest + ", ";
                daWCL.PROCESS += "HasETDIScheduledInternalAssessmentTest: " + HasETDIScheduledInternalAssessmentTest + ", ";
                daWCL.PROCESS += "isPaymentE_Cleared: " + isPaymentE_Cleared + ", ";
                daWCL.PROCESS += "isPaymentF_Cleared: " + isPaymentF_Cleared + ", ";

                // Commented by AVANZA\muhammad.uzair on 29/09/2017 10:45:38
                //if (HasETDIScheduledInternalAssessmentTest == true && isPaymentE_Cleared == true)
                if (HasPassesdETDIAssessment == 0) // 0 means fail
                {
                    if (isPaymentE_Cleared == true)
                    {
                        daWCL.RETURNED_STATE = "InternalAssessmentState";
                        daWCL.Log();
                        return new InternalAssessmentState(this.Manager);
                    }
                    else
                    {
                        daWCL.PROCESS += "Internal Assessment Payment Is Not Cleared";
                        daWCL.RETURNED_STATE = "AdditionalCompletedState";
                        daWCL.Log();
                        return this;
                    }
                }
                else if (hasRTAScheduledRoadTest == true && isPaymentF_Cleared == true)
                {
                    daWCL.RETURNED_STATE = "RoadTestScheduledState";
                    daWCL.Log();
                    return new RoadTestScheduledState(this.Manager);
                }
                else
                {
                    daWCL.RETURNED_STATE = daWCL.CURRENT_STATE;
                    daWCL.PROCESS += "INTERNAL ASSESSMENT / ROAD TEST IS NOT SCHEDULED OR RELATIVE PAYMENTS ARE NOT CLEARED.";
                    daWCL.Log();
                    LogMessages("INTERNAL ASSESSMENT / ROAD TEST IS NOT SCHEDULED OR RELATIVE PAYMENTS ARE NOT CLEARED.");
                    return this;
                }
            }
            catch (Exception ex)
            {
                daWCL.PROCESS = ex.Message;
                daWCL.RETURNED_STATE = daWCL.CURRENT_STATE;
                daWCL.Log();
                Logger.getInstance().Error("WorkflowManager", "AdditionalClassesCompletedState::GotoNextState()", ex);
                LogMessages("ERROR: " + ex.Message);
                return this;
            }
        }


    }


}
