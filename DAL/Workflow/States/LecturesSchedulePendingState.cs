using eLearning.Common.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using eLearning.DAL.DataAccess;

namespace DAL.Workflow.States
{
    // AVANZA\jawwad.ahmed - 24/07/2017 18:52:54
    public class LecturesSchedulePendingState : BaseState
    {
        public LecturesSchedulePendingState(WorkflowManager manager)
            : base(manager, WorkflowStates.LecturesSchedulePending)
        {

        }

        public override BaseState GotoNextState()
        {
            //Added by Fahim Nasir on 26-9-2017
            DAWorkflowCallLog daWCL = new DAWorkflowCallLog();
            daWCL.CURRENT_STATE = "LecturesSchedulePendingState";
            daWCL.ContractId = this.DataAccess.ContractId;

            try
            {
                var hasSomeScheduledLectures = this.DataAccess.HasSomeScheduledLectures();

                daWCL.PROCESS += "hasSomeScheduledLectures: " + hasSomeScheduledLectures + ", ";

                if (hasSomeScheduledLectures == true)
                {
                    daWCL.RETURNED_STATE = "LecturesScheduledState";
                    daWCL.Log();
                    return new LecturesScheduledState(this.Manager);
                }
                else
                {
                    daWCL.RETURNED_STATE = daWCL.CURRENT_STATE;
                    daWCL.PROCESS += "NO LECTURES SCHEDULED";
                    daWCL.Log();
                    LogMessages("NO LECTURES SCHEDULED");
                    return this;
                }
            }
            catch(Exception ex)
            {
                daWCL.CURRENT_STATE = "LecturesSchedulePendingState";
                daWCL.RETURNED_STATE = daWCL.CURRENT_STATE;
                daWCL.PROCESS = ex.Message;
                daWCL.Log();
                Logger.getInstance().Error("WorkflowManager", "LectureSchedulePendingState::GotoNextState()", ex);
                LogMessages("ERROR: " + ex.Message);
                return this;
            }
        }
    }
}