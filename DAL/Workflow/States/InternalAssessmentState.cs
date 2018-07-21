using eLearning.Common.Utils;
using eLearning.DAL.DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace DAL.Workflow.States
{
    // AVANZA\jawwad.ahmed - 24/07/2017 18:53:48
    public class InternalAssessmentState : BaseState
    {
        public InternalAssessmentState(WorkflowManager manager)
            : base(manager, WorkflowStates.InternalAssessment)
        {

        }
        
        public override BaseState GotoNextState()
        {
            //Added by Fahim Nasir on 26-9-2017
            DAWorkflowCallLog daWCL = new DAWorkflowCallLog();
            daWCL.CURRENT_STATE = "InternalAssessmentState";
            daWCL.ContractId = this.DataAccess.ContractId;

            try
            {
                DASystemConfiguration sysConfig = new DASystemConfiguration();
                var hasInternalAssessmentTestResult = this.DataAccess.HasInternalAssessmentTestResult();
                var IsPaymentF_Cleared = this.DataAccess.IsPaymentF_Cleared();

                daWCL.PROCESS += "hasInternalAssessmentTestResult: " + hasInternalAssessmentTestResult + ", ";
                daWCL.PROCESS += "IsPaymentF_Cleared: " + IsPaymentF_Cleared + ", ";

                // Commented by AVANZA\muhammad.uzair on 25/09/2017 14:46:26
                //Payment F not needed to be checked here
                //if (hasInternalAssessmentTestResult == true && IsPaymentF_Cleared == true)
                if (hasInternalAssessmentTestResult == true)
                {
                    
                    var hasPassedInternalAssessmentTest = this.DataAccess.HasPassedInternalAssessmentTest();
                    daWCL.PROCESS += "hasPassedInternalAssessmentTest: " + hasPassedInternalAssessmentTest + ", ";

                    if (hasPassedInternalAssessmentTest == 1) // 1 means pass
                    {
                        var hasRTAScheduledRoadTest = this.DataAccess.HasRTAScheduledRoadTest();
                        var IsCurrentStagePaymentCleared = this.DataAccess.IsCurrentStagePaymentCleared();

                        daWCL.PROCESS += "hasRTAScheduledRoadTest: " + hasRTAScheduledRoadTest + ", ";
                        daWCL.PROCESS += "IsCurrentStagePaymentCleared: " + IsCurrentStagePaymentCleared + ", ";

                        // Added by MUHAMMADUZAIR\avanza on 22/09/2017 11:06:42
                        // Modified by AVANZA\muhammad.uzair on 25/09/2017 15:26:25
                        //Added check for payment 
                        DataTable ds = sysConfig.GetSystemConfigurationByKey("IS_MANDATORY_ADDITIONAL_CLASSES_BEFORE_ROAD_TEST");

                        string isMandatoryAdditionalClasses = string.Empty;
                        if(ds != null && ds.Rows.Count > 0 && ds.Columns.Contains("VALUE"))
                        {
                            isMandatoryAdditionalClasses = ds.Rows[0]["VALUE"].ToString();
                        }
                        else
                        {
                            daWCL.PROCESS += "SYSTEM CONFIGURATION TABLE HAS NO VALUE FOR IS_MANDATORY_ADDITIONAL_CLASSES_BEFORE_ROAD_TEST";
                        }

                        daWCL.PROCESS += "isMandatoryAdditionalClasses: " + isMandatoryAdditionalClasses + ", ";

                        if (IsPaymentF_Cleared == true)
                        {
                            if (hasRTAScheduledRoadTest == true && IsCurrentStagePaymentCleared == true)
                            {
                                if (isMandatoryAdditionalClasses != "true")
                                {
                                    //if highway or night or additional classes count =0 means all classes are scheduled
                                    // in case we might be required to check attendance of these classes in future as well
                                    daWCL.RETURNED_STATE = "RoadTestScheduledState";
                                    daWCL.Log();
                                    return new RoadTestScheduledState(this.Manager);
                                }
                                else
                                {
                                    var hasTakenAllOtherClasses = this.DataAccess.HasTakenAllOtherClasses();
                                    daWCL.PROCESS += "hasTakenAllOtherClasses: " + hasTakenAllOtherClasses + ", ";

                                    if (hasTakenAllOtherClasses == true)
                                    {
                                        daWCL.RETURNED_STATE = "RoadTestScheduledState";
                                        daWCL.Log();
                                        return new RoadTestScheduledState(this.Manager);
                                    }
                                    else
                                    {
                                        daWCL.RETURNED_STATE = daWCL.CURRENT_STATE;
                                        daWCL.PROCESS += "ALL OTHER CLASSES ARE NOT SCHEDULED";
                                        daWCL.Log();
                                        LogMessages("ALL OTHER CLASSES ARE NOT SCHEDULED");
                                        return this;
                                    }
                                }
                            }
                            else
                            {
                                daWCL.RETURNED_STATE = daWCL.CURRENT_STATE;
                                daWCL.PROCESS += "RTA SCHEDULED ROAD TEST WAS NOT PASSED OR CURRENT STAGE PAYMENT NOT CLEARED";
                                daWCL.Log();
                                LogMessages("RTA SCHEDULED ROAD TEST WAS NOT PASSED OR CURRENT STAGE PAYMENT NOT CLEARED");
                                return this;
                            }
                        }
                        else
                        {
                            daWCL.RETURNED_STATE = daWCL.CURRENT_STATE;
                            daWCL.PROCESS += "FINAL ROAD TEST PAYMENT NOT CLEARED";
                            daWCL.Log();
                            LogMessages("FINAL ROAD TEST PAYMENT NOT CLEARED");
                            return this;
                        }
                    }
                    else if(hasPassedInternalAssessmentTest == 0) // 0 means fail
                    {
                        //AVANZA\muhammad.uzair 8/9/17
                        this.DataAccess.GeneratePaymentForInternalAssessmentTestFailure();
                        daWCL.RETURNED_STATE = "AdditionalClassesPendingState";
                        daWCL.Log();

                        // Added by AVANZA\muhammad.uzair on 28/09/2017 10:32:51
                        //updating the is_updated bit of exam
                        this.DataAccess.UpdateResultBitForCustomerExam((int)Enumaration.ExamIdMap.InternalAssessment);


                        // added by MUHAMMAD.AWAIS 8/8/2017
                        return new AdditionalClassesPendingState(this.Manager);
                    }
                    else // for absent and other cases value would be 2
                    {
                        // Added by MUHAMMADUZAIR\Administrator as Onsite Support on 03/12/2017 18:07:29 
                        this.DataAccess.GeneratePaymentForInternalAssessmentTestFailure();

                        daWCL.RETURNED_STATE = "PracticalScheduledBState";
                        daWCL.PROCESS += "CUSTOMER IS ABSENT IN INTERNAL ASSESSMENT";
                        daWCL.Log();
                        LogMessages("CUSTOMER IS ABSENT IN INTERNAL ASSESSMENT");
                        // internal test if absent then should be scheduled form here

                        // Added by AVANZA\muhammad.uzair on 28/09/2017 10:32:51
                        //updating the is_updated bit of exam
                        this.DataAccess.UpdateResultBitForCustomerExam((int)Enumaration.ExamIdMap.InternalAssessment);

                        return this;
                    }
                }
                else
                {
                    daWCL.RETURNED_STATE = daWCL.CURRENT_STATE;
                    daWCL.PROCESS += "INTERNAL ASSESSMENT TEST RESULT DOES NOT EXIST OR PAYMENT F NOT CLEARED";
                    daWCL.Log();
                    LogMessages("INTERNAL ASSESSMENT TEST RESULT DOES NOT EXIST OR PAYMENT F NOT CLEARED");
                    return this;
                }
            }
            catch (Exception ex)
            {
                daWCL.RETURNED_STATE = daWCL.CURRENT_STATE;
                daWCL.PROCESS = ex.Message;
                daWCL.Log();
                Logger.getInstance().Error("WorkflowManager", "InternalAssessmentState::GotoNextState()", ex);
                LogMessages("ERROR: " + ex.Message);
                return this;
            }
        }
    }
}