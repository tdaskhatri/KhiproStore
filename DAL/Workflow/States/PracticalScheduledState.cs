using eLearning.Common.Utils;
using eLearning.DAL.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DAL.Workflow.States
{
    // AVANZA\jawwad.ahmed - 24/07/2017 18:53:28
    public class PracticalScheduledState : BaseState
    {
        public PracticalScheduledState(WorkflowManager manager)
            : base(manager, WorkflowStates.PracticalScheduled)
        {

        }

        public override BaseState GotoNextState()
        {
            //Added by Fahim Nasir on 26-9-2017
            DAWorkflowCallLog daWCL = new DAWorkflowCallLog();
            daWCL.CURRENT_STATE = "PracticalScheduledState";
            daWCL.ContractId = this.DataAccess.ContractId;

            try
            {
                var hasAllClassesScheduled = this.DataAccess.HasAllClassesScheduled();
                var hasAttendedAllClasses = this.DataAccess.HasAttendedAllClasses();
                var hasRTAParkingTestResult = this.DataAccess.HasRTAParkingTestResult();

                daWCL.PROCESS += "hasAllClassesScheduled: " + hasAllClassesScheduled + ", ";
                daWCL.PROCESS += "hasAttendedAllClasses: " + hasAttendedAllClasses + ", ";
                daWCL.PROCESS += "hasRTAParkingTestResult: " + hasRTAParkingTestResult + ", ";

                if (hasRTAParkingTestResult == true)
                {
                    var hasPassedRTAParkingTest = this.DataAccess.HasPassedRTAParkingTest();
                    var IsCurrentStagePaymentCleared = this.DataAccess.IsCurrentStagePaymentCleared();
                    var IsAbsentInParkingTest = this.DataAccess.IsAbsentInParkingTest(); 
                    daWCL.PROCESS += "hasPassedRTAParkingTest: " + hasPassedRTAParkingTest + ", ";
                    daWCL.PROCESS += "IsCurrentStagePaymentCleared: " + IsCurrentStagePaymentCleared + ", ";

                    //AVANZA\muhammad.uzair 8/9/17
                    if (hasPassedRTAParkingTest == false)
                    {

                        // Added by AVANZA\muhammad.uzair on 28/09/2017 10:30:08
                        //updating the is_updated bit of exam
                        this.DataAccess.UpdateResultBitForCustomerExam((int)Enumaration.ExamIdMap.ParkingTest);
                        // Added by MUHAMMADUZAIR\Administrator as Onsite Support on 03/12/2017 18:09:10 
                        this.DataAccess.GeneratePaymentForParkingTestFailure();


                        // Added by Muhammad Uzair on 02/02/2018 16:58:13 
                        // This case can be added in future to check whether classes are defined in case of parking test failure
                        //if (this.DataAccess.IsAdditionalClassesDefinedForParkingTestFailure())
                        //{
                            if (!IsAbsentInParkingTest)
                            {
                                // Commented by MUHAMMADUZAIR\Administrator as Onsite Support on 03/12/2017 18:09:05
                                //this.DataAccess.GeneratePaymentForParkingTestFailure();
                                daWCL.RETURNED_STATE = daWCL.CURRENT_STATE;
                                daWCL.Log();
                                return this;
                            }
                            else
                            {
                                daWCL.RETURNED_STATE = daWCL.CURRENT_STATE;
                                daWCL.PROCESS += "Customer is Absent in Parking Test.";
                                daWCL.Log();
                                LogMessages("Customer is Absent in Parking Test.");
                                return this;
                            }
                       // }
                       // else
                       // {
                        //    daWCL.RETURNED_STATE = daWCL.CURRENT_STATE;
                        //    daWCL.PROCESS += "No additional classes defined in system for parking test failure";
                        //    daWCL.Log();
                        //    LogMessages("No additional classes defined in system for parking test failure");
                        //    return this;
                        //}
                    }

                    //if (hasPassedRTAParkingTest == true && hasAllClassesScheduled == false && IsCurrentStagePaymentCleared == true)
                    else if(hasPassedRTAParkingTest == true && hasAttendedAllClasses == false && IsCurrentStagePaymentCleared == true)
                    {
                        daWCL.RETURNED_STATE = "PracticalScheduledBState";
                        daWCL.Log();
                        return new PracticalScheduledBState(this.Manager);
                    }
                }

                if (hasAllClassesScheduled == true && hasAttendedAllClasses == true)
                {
                    // Added by AVANZA\muhammad.uzair on 29/09/2017 12:07:23
                    var hasRTAParkingTestScheduled = this.DataAccess.HasRTAScheduledParkingTest();
                    daWCL.PROCESS += "hasRTAParkingTestScheduled: " + hasRTAParkingTestScheduled + ", ";

                    if (hasRTAParkingTestScheduled == true)
                    {
                        daWCL.RETURNED_STATE = "ParkingTestScheduled";
                        daWCL.Log();
                        return new ParkingTestScheduledState(this.Manager);
                    }
                    else
                    {
                        daWCL.RETURNED_STATE = "PracticalCompletedState";
                        daWCL.Log();
                        return new PracticalCompletedState(this.Manager);
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
                daWCL.RETURNED_STATE = daWCL.CURRENT_STATE;
                daWCL.PROCESS = ex.Message;
                daWCL.Log();
                Logger.getInstance().Error("WorkflowManager", "PracticalScheduledState::GotoNextState()", ex);
                LogMessages("ERROR: " + ex.Message);
                return this;
            }
        }
    }
}