using eLearning.Common.Utils;
using eLearning.DAL.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DAL.Workflow.States
{
    // AVANZA\jawwad.ahmed - 24/07/2017 18:53:35
    public class PracticalCompletedState : BaseState
    {
        public PracticalCompletedState(WorkflowManager manager)
            : base(manager, WorkflowStates.PracticalCompleted)
        {

        }

        public override BaseState GotoNextState()
        {
            //Added by Fahim Nasir on 26-9-2017
            DAWorkflowCallLog daWCL = new DAWorkflowCallLog();
            daWCL.CURRENT_STATE = "PracticalCompletedState";
            daWCL.ContractId = this.DataAccess.ContractId;

            try
            {
                var hasRTAScheduledParkingTest = this.DataAccess.HasRTAScheduledParkingTest();
                var hasRTAParkingTestResult = this.DataAccess.HasRTAParkingTestResult();
                var IsPaymentD_Cleared = this.DataAccess.IsPaymentD_Cleared();

                daWCL.PROCESS += "hasRTAScheduledParkingTest: " + hasRTAScheduledParkingTest + ", ";
                daWCL.PROCESS += "hasRTAParkingTestResult: " + hasRTAParkingTestResult + ", ";
                daWCL.PROCESS += "IsPaymentD_Cleared: " + IsPaymentD_Cleared + ", ";

                if (hasRTAParkingTestResult == true && IsPaymentD_Cleared == true)
                {
                    var hasPassedRTAParkingTest = this.DataAccess.HasPassedRTAParkingTest();
                    var hasETDIScheduledInternalAssessmentTest = this.DataAccess.HasETDIScheduledInternalAssessmentTest();

                    daWCL.PROCESS += "hasPassedRTAParkingTest: " + hasPassedRTAParkingTest + ", ";
                    daWCL.PROCESS += "hasETDIScheduledInternalAssessmentTest: " + hasETDIScheduledInternalAssessmentTest + ", ";
                  
                    var isAbsentInParkingTest = this.DataAccess.IsAbsentInParkingTest(); 

                    //AVANZA\muhammad.uzair 8/9/17
                    if (hasPassedRTAParkingTest == false)
                    {
                        // Added by AVANZA\muhammad.uzair on 28/09/2017 10:30:08
                        //updating the is_updated bit of exam
                        this.DataAccess.UpdateResultBitForCustomerExam((int)Enumaration.ExamIdMap.ParkingTest);

                        // Added by MUHAMMADUZAIR\Administrator as Onsite Support on 03/12/2017 18:09:53 
                        this.DataAccess.GeneratePaymentForParkingTestFailure();
                        // Generate Payment only in case of Failure. May be this condition change in future. 

                        // Added by Muhammad Uzair on 02/02/2018 16:54:53 
                        // This case might be handy in future for handling system when no classes are defined in case of parking test failure
                        //if (this.DataAccess.IsAdditionalClassesDefinedForParkingTestFailure())
                        //{
                            if (!isAbsentInParkingTest)
                            {
                                // Commented by MUHAMMADUZAIR\Administrator as Onsite Support on 03/12/2017 18:09:47
                                //this.DataAccess.GeneratePaymentForParkingTestFailure();
                                daWCL.RETURNED_STATE = "PracticalScheduledState";
                                daWCL.Log();
                                return new PracticalScheduledState(this.Manager);
                            }
                            else
                            {
                                daWCL.RETURNED_STATE = daWCL.CURRENT_STATE;
                                daWCL.PROCESS += "Customer is Absent in Parking Test.";
                                daWCL.Log();
                                LogMessages("Customer is Absent in Parking Test.");
                                return this;
                            }
                        //}
                        //else
                        //{
                        //    daWCL.RETURNED_STATE = daWCL.CURRENT_STATE;
                        //    daWCL.PROCESS += "No additional classes defined in system for road test failure";
                        //    daWCL.Log();
                        //    LogMessages("No additional classes defined in system for road test failure");
                        //    return this;
                        //}
                        
                    }

                    if (hasPassedRTAParkingTest == true && hasETDIScheduledInternalAssessmentTest == true)
                    {
                        daWCL.RETURNED_STATE = "InternalAssessmentState";
                        daWCL.Log();
                        return new InternalAssessmentState(this.Manager);
                    }
                    else
                    {
                        if(hasRTAScheduledParkingTest == true)
                        {
                            daWCL.RETURNED_STATE = "ParkingTestScheduledState";
                            daWCL.Log();
                            return new ParkingTestScheduledState(this.Manager);
                        }
                        else
                        {
                            daWCL.RETURNED_STATE = daWCL.CURRENT_STATE;
                            daWCL.PROCESS += "CUSTOMER HAS NO RTA SCHEDULED PARKING TEST";
                            daWCL.Log();
                            LogMessages("CUSTOMER HAS NO RTA SCHEDULED PARKING TEST");
                            return this;
                        }
                    }
                }
                else
                {
                    if (hasRTAScheduledParkingTest == true && IsPaymentD_Cleared == true)
                    {
                        daWCL.RETURNED_STATE = "ParkingTestScheduledState";
                        daWCL.Log();
                        return new ParkingTestScheduledState(this.Manager);
                    }
                    else
                    {
                        daWCL.RETURNED_STATE = daWCL.CURRENT_STATE;
                        daWCL.PROCESS += "CUSTOMER HAS NO RTA SCHEDULED PARKING TEST OR PAYMENT D NOT CLEARED";
                        daWCL.Log();
                        LogMessages("CUSTOMER HAS NO RTA SCHEDULED PARKING TEST OR PAYMENT D NOT CLEARED");
                        return this;
                    }
                }
            }
            catch (Exception ex)
            {
                daWCL.RETURNED_STATE = daWCL.CURRENT_STATE;
                daWCL.PROCESS = ex.Message;
                daWCL.Log();
                Logger.getInstance().Error("WorkflowManager", "PracticalCompletedState::GotoNextState()", ex);
                LogMessages("ERROR: " + ex.Message);
                return this;
            }
        }
    }
}