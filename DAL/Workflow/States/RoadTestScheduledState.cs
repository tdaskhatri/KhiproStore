using eLearning.Common.Utils;
using eLearning.DAL.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DAL.Workflow.States
{
    // AVANZA\jawwad.ahmed - 24/07/2017 18:53:55
    public class RoadTestScheduledState : BaseState
    {
        public RoadTestScheduledState(WorkflowManager manager)
            : base(manager, WorkflowStates.RoadTestScheduled)
        {

        }

        public override BaseState GotoNextState()
        {
            //Added by Fahim Nasir on 26-9-2017
            DAWorkflowCallLog daWCL = new DAWorkflowCallLog();
            daWCL.CURRENT_STATE = "RoadTestScheduledState";
            daWCL.ContractId = this.DataAccess.ContractId;

            try
            {
                var hasRTARoadTestResult = this.DataAccess.HasRTARoadTestResult();
                var IsPaymentG_Cleared = this.DataAccess.IsPaymentG_Cleared();

                daWCL.PROCESS += "hasRTARoadTestResult: " + hasRTARoadTestResult + ", ";
                daWCL.PROCESS += "IsPaymentG_Cleared: " + IsPaymentG_Cleared + ", ";

                // Modified by AVANZA\muhammad.uzair on 25/09/2017 18:12:08
                // Commented by AVANZA\muhammad.uzair on 25/09/2017 18:12:24
                //Payment g not needed to be checked here
                //if (hasRTARoadTestResult == true && IsPaymentG_Cleared == true)
                if(hasRTARoadTestResult == true)
                {
                    // Added by AVANZA\muhammad.uzair on 28/09/2017 10:32:51
                    //updating the is_updated bit of exam
                    this.DataAccess.UpdateResultBitForCustomerExam((int)Enumaration.ExamIdMap.RoadTest);

                    var hasPassedRTARoadTest = this.DataAccess.HasPassedRTARoadTest();
                    daWCL.PROCESS += "hasPassedRTARoadTest: " + hasPassedRTARoadTest + ", ";

                    var isAbsentInRTARoadTest = this.DataAccess.IsAbsentInRoadTest();
                    daWCL.PROCESS += "isAbsentInRTARoadTest: " + isAbsentInRTARoadTest + ", ";

                    if (hasPassedRTARoadTest == true)
                    {
                        // Added by MUHAMMADUZAIR\avanza on 19/09/2017 10:07:00
                        if (IsPaymentG_Cleared == true)
                        {
                            this.DataAccess.IssueLicense();
                            daWCL.RETURNED_STATE = "LicenseIssuedState";
                            daWCL.Log();
                            return new LicenseIssuedState(this.Manager);
                        }
                        else
                        {
                            daWCL.RETURNED_STATE = "LicenseIssuancePendingState";
                            daWCL.Log();
                            return new LicenseIssuancePendingState(this.Manager);
                        }
                    }
                    else
                    {
                        // Added by MUHAMMADUZAIR\Administrator as Onsite Support on 03/12/2017 18:07:00 
                        this.DataAccess.GeneratePaymentForRoadTestTestFailure();

                        // Added by Muhammad Uzair on 02/02/2018 16:43:17 
                        // Added check for additional classes defined if not defined then remain at this state
                        // THis case might be handy in future
                        //if (this.DataAccess.IsAdditionalClassesDefinedForRoadTestFailure())
                        //{
                            //AVANZA\muhammad.uzair 8/9/17
                            if (!isAbsentInRTARoadTest)
                            {
                                // Commented by MUHAMMADUZAIR\Administrator as Onsite Support on 03/12/2017 18:06:47
                                //this.DataAccess.GeneratePaymentForRoadTestTestFailure();
                                daWCL.RETURNED_STATE = "AdditionalClassesPendingState";
                                daWCL.Log();
                                return new AdditionalClassesPendingState(this.Manager);
                            }
                            else
                            {
                                daWCL.RETURNED_STATE = "InternalAssessmentState";
                                daWCL.PROCESS += "Customer is Absent in Road Test. Need to Reschedule it again.";
                                daWCL.Log();
                                LogMessages("Customer is Absent in Road Test. Need to Reschedule it again.");
                                return new InternalAssessmentState(this.Manager);
                            }
                        //}
                        //else
                        //{
                        //    daWCL.RETURNED_STATE = "RoadTestScheduledState";
                        //    daWCL.PROCESS += "No additional classes defined for the road test failure. Schedule the road test again.";
                        //    daWCL.Log();
                        //    LogMessages("No additional classes defined for the road test failure. Schedule the road test again.");
                        //    return this;
                        //}
                        
                    }
                }
                else
                {
                    daWCL.RETURNED_STATE = daWCL.CURRENT_STATE;
                    daWCL.PROCESS += "RTA ROAD TEST RESULT DOES NOT EXIST OR PAYMENT G IS NOT CLEARED";
                    daWCL.Log();
                    LogMessages("RTA ROAD TEST RESULT DOES NOT EXIST OR PAYMENT G IS NOT CLEARED");
                    return this;
                }
            }
            catch (Exception ex)
            {
                daWCL.RETURNED_STATE = daWCL.CURRENT_STATE;
                daWCL.PROCESS = ex.Message;
                daWCL.Log();
                Logger.getInstance().Error("WorkflowManager", "RoadTestScheduledState::GotoNextState()", ex);
                LogMessages("ERROR: " + ex.Message);
                return this;
            }
        }
    }
}