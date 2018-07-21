using eLearning.Common.Utils;
using eLearning.DAL.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DAL.Workflow.States
{
    // AVANZA\jawwad.ahmed - 24/07/2017 18:53:40
    public class ParkingTestScheduledState : BaseState
    {
        public ParkingTestScheduledState(WorkflowManager manager)
            : base(manager, WorkflowStates.ParkingTestScheduled)
        {

        }

        public override BaseState GotoNextState()
        {
            //Added by Fahim Nasir on 26-9-2017
            DAWorkflowCallLog daWCL = new DAWorkflowCallLog();
            daWCL.CURRENT_STATE = "ParkingTestScheduledState";
            daWCL.ContractId = this.DataAccess.ContractId;

            try
            {
                var hasRTAParkingTestResult = this.DataAccess.HasRTAParkingTestResult();
                var IsPaymentE_Cleared = this.DataAccess.IsPaymentE_Cleared();

                daWCL.PROCESS += "hasRTAParkingTestResult: "+ hasRTAParkingTestResult + ", ";
                daWCL.PROCESS += "IsPaymentE_Cleared: " + IsPaymentE_Cleared + ", ";

                //if (hasRTAParkingTestResult == true && IsPaymentE_Cleared == true)
                if (hasRTAParkingTestResult == true )
                {
                    var hasPassedRTAParkingTest = this.DataAccess.HasPassedRTAParkingTest();
                    var hasETDIScheduledInternalAssessmentTest = this.DataAccess.HasETDIScheduledInternalAssessmentTest();
                    var IsCurrentStagePaymentCleared = this.DataAccess.IsCurrentStagePaymentCleared();
                    
                    var isAbsentinParkingTest = this.DataAccess.IsAbsentInParkingTest();

                    daWCL.PROCESS += "hasPassedRTAParkingTest: " + hasPassedRTAParkingTest + ", ";
                    daWCL.PROCESS += "hasETDIScheduledInternalAssessmentTest: " + hasETDIScheduledInternalAssessmentTest + ", ";
                    daWCL.PROCESS += "IsCurrentStagePaymentCleared: " + IsCurrentStagePaymentCleared + ", ";                   
                    daWCL.PROCESS += "isAbsentinParkingTest: " + isAbsentinParkingTest + ", ";

                    //AVANZA\muhammad.uzair 8/9/17
                    // Modified by AVANZA\muhammad.uzair on 25/09/2017 13:58:44
                    // Copied the else from below
                    if (hasPassedRTAParkingTest == false)
                    {
                        //abseent 
                        // Generate Payment only in case of Failure. May be this condition change in future. 
                        // Commented and Modified Below by MUHAMMADUZAIR\Administrator as Onsite Support on 03/12/2017 18:40:52
                        //if (!isAbsentinParkingTest) this.DataAccess.GeneratePaymentForParkingTestFailure();
                        this.DataAccess.GeneratePaymentForParkingTestFailure();
                        daWCL.PROCESS += "isAbsentinParkingTest: " + isAbsentinParkingTest + ", ";

                        //Modified by Fahim Nasir 27/09/2017 14:01:50 - advised by Uziar
                        var hasAttendedAllClasses = this.DataAccess.HasAttendedAllClasses();
                        daWCL.PROCESS += "hasAttendedAllClasses: " + hasAttendedAllClasses + ", ";

                        // Added by AVANZA\muhammad.uzair on 28/09/2017 10:29:23
                        //Updating the is_updated bit of exam result
                        this.DataAccess.UpdateResultBitForCustomerExam((int)Enumaration.ExamIdMap.ParkingTest);


                        // Added by Muhammad Uzair on 02/02/2018 16:47:20 
                        // Added check for classes not defined for parking test failure
                        // THis case might be handy in future
                        //if (this.DataAccess.IsAdditionalClassesDefinedForParkingTestFailure())
                        //{
                            if (hasAttendedAllClasses == true)
                            {
                                daWCL.RETURNED_STATE = "PracticalCompletedState";
                                daWCL.Log();
                                return new PracticalCompletedState(this.Manager);
                            }
                            else
                            {
                                daWCL.RETURNED_STATE = "PracticalScheduledState";
                                daWCL.Log();
                                return new PracticalScheduledState(this.Manager);
                            }
                        //}
                        //else
                        //{
                        //    // If no classes defined in the system for failure then remain at this state
                        //    daWCL.RETURNED_STATE = "ParkingTestScheduled";
                        //    daWCL.Log();
                        //    return this;
                        //}

                    }

                    if (hasPassedRTAParkingTest == true && hasETDIScheduledInternalAssessmentTest == true && IsCurrentStagePaymentCleared == true)
                    {
                        daWCL.RETURNED_STATE = "InternalAssessmentState";
                        daWCL.Log();
                        return new InternalAssessmentState(this.Manager);
                    }
                    else
                    {
                        //var hasAttendedAllClasses = this.DataAccess.HasAttendedAllClasses();

                        //if (hasAttendedAllClasses == true)
                        //{
                        //    //return new PracticalSchedulePendingState(this.Manager);
                        //    return new PracticalCompletedState(this.Manager);
                        //}
                        //else
                        //{
                        //    // AVANZA\jawwad.ahmed - 27/07/2017 19:34:49
                        //    // This condition will never occur! But it was part of Flow diagram.
                        //    return new PracticalScheduledState(this.Manager);
                        //}
                        return this;
                    }
                }
                else
                {
                    daWCL.RETURNED_STATE = daWCL.CURRENT_STATE;
                    daWCL.PROCESS += "CUSTOMER HAS NO RTA PARKING TEST RESULT OR PAYMENT E NOT CLEARED";
                    daWCL.Log();
                    LogMessages("CUSTOMER HAS NO RTA PARKING TEST RESULT OR PAYMENT E NOT CLEARED");
                    return this;
                }
            }
            catch (Exception ex)
            {
                daWCL.RETURNED_STATE = daWCL.CURRENT_STATE;
                daWCL.PROCESS = ex.Message;
                daWCL.Log();
                Logger.getInstance().Error("WorkflowManager", "ParkingTestScheduledState::GotoNextState()", ex);
                LogMessages("ERROR: " + ex.Message);
                return this;
            }
        }
    }
}