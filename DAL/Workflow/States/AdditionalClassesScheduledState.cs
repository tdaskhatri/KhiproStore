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
    class AdditionalClassesScheduledState : BaseState
    {
        // added by MUHAMMAD.AWAIS 8/8/2017

        public AdditionalClassesScheduledState(WorkflowManager manager)
            : base(manager, WorkflowStates.AdditionalClassesScheduled)
        {

        }

        public override BaseState GotoNextState()
        {
            //Added by Fahim Nasir on 26-9-2017
            DAWorkflowCallLog daWCL = new DAWorkflowCallLog();
            daWCL.CURRENT_STATE = "AdditionalClassesScheduledState";
            daWCL.ContractId = this.DataAccess.ContractId;
            try
            {
                var hasAllClassesScheduled = this.DataAccess.HasAllClassesScheduled();
                var hasAttendedAllClasses = this.DataAccess.HasAttendedAllClasses();
                var hasRTAScheduledRoadTest = this.DataAccess.HasRTAScheduledRoadTest();
                var HasETDIScheduledInternalAssessmentTest = this.DataAccess.HasETDIScheduledInternalAssessmentTest();
                int HasPassesdETDIAssessment = this.DataAccess.HasPassedInternalAssessmentTest();
                var isPaymentE_Cleared = this.DataAccess.IsPaymentE_Cleared();
                var isPaymentF_Cleared = this.DataAccess.IsPaymentF_Cleared();
                var IsCurrentStagePaymentCleared = this.DataAccess.IsCurrentStagePaymentCleared();

                daWCL.PROCESS += "hasAllClassesScheduled: " + hasAllClassesScheduled + ", ";
                daWCL.PROCESS += "hasAttendedAllClasses: " + hasAttendedAllClasses + ", ";
                daWCL.PROCESS += "hasRTAScheduledRoadTest: " + hasRTAScheduledRoadTest + ", ";
                daWCL.PROCESS += "HasETDIScheduledInternalAssessmentTest: " + HasETDIScheduledInternalAssessmentTest + ",";
                daWCL.PROCESS += "isPaymentE_Cleared: " + isPaymentE_Cleared + ", ";
                daWCL.PROCESS += "isPaymentF_Cleared: " + isPaymentF_Cleared + ", ";
                daWCL.PROCESS += "IsCurrentStagePaymentCleared: " + IsCurrentStagePaymentCleared + ", ";

                if (hasAllClassesScheduled == true && hasAttendedAllClasses == true)
                {
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
                            daWCL.RETURNED_STATE = "AdditionalClassesScheduled";
                            daWCL.Log();
                            return this;
                        }                           
                    }
                    else if (hasRTAScheduledRoadTest == true && isPaymentF_Cleared == true && IsCurrentStagePaymentCleared == true)
                    {
                        daWCL.RETURNED_STATE = "RoadTestScheduledState";
                        daWCL.Log();
                        return new RoadTestScheduledState(this.Manager);
                    }
                    else
                    {
                        daWCL.RETURNED_STATE = "AdditionalClassesCompletedState";
                        daWCL.Log();
                        return new AdditionalClassesCompletedState(this.Manager);
                    }


                }
                else
                {
                    daWCL.RETURNED_STATE = daWCL.CURRENT_STATE;
                    daWCL.PROCESS += "ALL CLASSES ARE NOT SCHEDULED OR CUSTOMER HAS NOT ATTENDED ALL CLASSES";
                    daWCL.Log();
                    LogMessages("ALL CLASSES ARE NOT SCHEDULED OR CUSTOMER HAS NOT ATTENDED ALL CLASSES");
                    return this;
                }
            }
            catch (Exception ex)
            {
                daWCL.CURRENT_STATE = "AdditionalClassesScheduledState";
                daWCL.RETURNED_STATE = daWCL.CURRENT_STATE;
                daWCL.PROCESS = ex.Message;
                daWCL.Log();
                Logger.getInstance().Error("WorkflowManager", "AdditionalClassesScheduledState::GotoNextState()", ex);
                LogMessages("ERROR: " + ex.Message);
                return this;
            }
        }


    }
}
