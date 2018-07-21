using eLearning.Common.Utils;
using eLearning.DAL.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace DAL.Workflow.States
{
    // AVANZA\jawwad.ahmed - 24/07/2017 18:53:17
    public class KnowledgeTestScheduledState : BaseState
    {
        public KnowledgeTestScheduledState(WorkflowManager manager)
            : base(manager, WorkflowStates.KnowledgeTestScheduled)
        {

        }

        public override BaseState GotoNextState()
        {
            //Added by Fahim Nasir on 26-9-2017
            DAWorkflowCallLog daWCL = new DAWorkflowCallLog();
            daWCL.CURRENT_STATE = "KnowledgeTestScheduledState";
            daWCL.ContractId = this.DataAccess.ContractId;

            try
            {
                var hasRTAKnowledgeTestResult = this.DataAccess.HasRTAKnowledgeTestResult();
                var IsPaymentC_Cleared = this.DataAccess.IsPaymentC_Cleared();
                var isAbsentInKnowledgeTest = this.DataAccess.IsAbsentInKnowledgeTest();

                daWCL.PROCESS += "hasRTAKnowledgeTestResult: " + hasRTAKnowledgeTestResult + ", ";
                daWCL.PROCESS += "IsPaymentC_Cleared: " + IsPaymentC_Cleared + ", ";

                if (hasRTAKnowledgeTestResult == true && IsPaymentC_Cleared == true)
                {
                    
                    var hasPassedRTAKnowledgeTest = this.DataAccess.HasPassedRTAKnowledgeTest();
                    var IsCurrentStagePaymentCleared = this.DataAccess.IsCurrentStagePaymentCleared();

                    daWCL.PROCESS += "hasPassedRTAKnowledgeTest: " + hasPassedRTAKnowledgeTest + ", ";
                    daWCL.PROCESS += "IsCurrentStagePaymentCleared: " + IsCurrentStagePaymentCleared + ", ";

                    if (hasPassedRTAKnowledgeTest == true)
                    {
                        if (IsCurrentStagePaymentCleared == true)
                        {
                            //Added by Fahim Nasir 22/01/2018 11:57:51
                            var IsExemptedCustomer = this.DataAccess.IsCustomerExempted();
                            daWCL.PROCESS += "IsExemptedCustomer" + IsExemptedCustomer + ", ";
                            //========================================                         

                            //Modified by Fahim Nasir 22/01/2018 12:00:36
                            if (IsExemptedCustomer)
                            {
                                daWCL.RETURNED_STATE = "RoadTestScheduledState";
                                daWCL.Log();
                                return new RoadTestScheduledState(this.Manager);
                            }
                            else
                            {
                                daWCL.RETURNED_STATE = "PracticalSchedulePendingState";
                                daWCL.Log();
                                return new PracticalSchedulePendingState(this.Manager);
                            }
                            //===============================================
                        }
                        else
                        {
                            daWCL.RETURNED_STATE = daWCL.CURRENT_STATE;
                            daWCL.PROCESS += "KNOWLEDGE TEST STAGE PAYMENT IS NOT CLEARED";
                            daWCL.Log();
                            LogMessages("KNOWLEDGE TEST STAGE PAYMENT IS NOT CLEARED");
                            return this;
                        }
                    }
                    else
                    {
                        // Commented and Modified Below by MUHAMMADUZAIR\Administrator as Onsite Support on 03/12/2017 18:03:47
                        // Payment only generated in case of test failure.
                        //if (!isAbsentInKnowledgeTest)
                        //{
                        //    this.DataAccess.GeneratePaymentForKnowledgeTestFailure();
                        //}           

                        this.DataAccess.GeneratePaymentForKnowledgeTestFailure();
                        daWCL.RETURNED_STATE = "LecturesCompletedState";
                        daWCL.Log();

                        // Added by AVANZA\muhammad.uzair on 28/09/2017 10:32:51
                        //updating the is_updated bit of exam
                        this.DataAccess.UpdateResultBitForCustomerExam((int)Enumaration.ExamIdMap.KnowledgeTest);

                        return new LecturesCompletedState(this.Manager);
                    }
                }
                else
                {
                    daWCL.RETURNED_STATE = daWCL.CURRENT_STATE;
                    daWCL.PROCESS += "RTA KNOWLEDGE TEST RESULT DOES NOT EXIST OR PAYMENT C NOT CLEARED";
                    daWCL.Log();
                    LogMessages("RTA KNOWLEDGE TEST RESULT DOES NOT EXIST OR PAYMENT C NOT CLEARED");
                    return this;
                }
               
            }
            catch (Exception ex)
            {
                daWCL.CURRENT_STATE = "KnowledgeTestScheduled";
                daWCL.RETURNED_STATE = daWCL.CURRENT_STATE;
                daWCL.PROCESS = ex.Message;
                daWCL.Log();
                Logger.getInstance().Error("WorkflowManager", "KnowledgeTestScheduledState::GotoNextState()", ex);
                LogMessages("ERROR: " + ex.Message);
                return this;
            }
        }
    }
}