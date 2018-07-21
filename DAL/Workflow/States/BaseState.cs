using eLearning.DAL.DataAccess;
using DAL.Workflow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DAL.Workflow.States
{
    // AVANZA\jawwad.ahmed - 25/07/2017 16:28:02
    public class BaseState
    {
        public DAWorkflow DataAccess { get; set; }
        public WorkflowManager Manager { get; }
        public WorkflowStates InternalState { get; }

        public BaseState(WorkflowManager manager, WorkflowStates state)
        {
            this.Manager = manager;
            this.DataAccess = manager.DataAccess;
            this.InternalState = state;
        }
        public void LogMessages(string message)
        {
            this.DataAccess.LogMessage("Current State: " + this.InternalState.ToString() + " - " + message);
        }

        public virtual BaseState GotoNextState()
        {
            throw new NotImplementedException();
        }

        public static BaseState GetInstanceOf(WorkflowStates state, WorkflowManager manager)
        {
            switch (state)
            {
                case WorkflowStates.NewCustomer:
                    return new NewCustomerState(manager);
                case WorkflowStates.LecturesSchedulePending:
                    return new LecturesSchedulePendingState(manager);
                case WorkflowStates.LecturesScheduled:
                    return new LecturesScheduledState(manager);
                case WorkflowStates.LecturesCompleted:
                    return new LecturesCompletedState(manager);
                case WorkflowStates.KnowledgeTestScheduled:
                    return new KnowledgeTestScheduledState(manager);
                case WorkflowStates.PracticalSchedulePending:
                    return new PracticalSchedulePendingState(manager);
                case WorkflowStates.PracticalScheduled:
                    return new PracticalScheduledState(manager);
                case WorkflowStates.PracticalScheduledB:
                    return new PracticalScheduledBState(manager);
                case WorkflowStates.PracticalCompleted:
                    return new PracticalCompletedState(manager);
                case WorkflowStates.ParkingTestScheduled:
                    return new ParkingTestScheduledState(manager);
                case WorkflowStates.InternalAssessment:
                    return new InternalAssessmentState(manager);
                case WorkflowStates.RoadTestScheduled:
                    return new RoadTestScheduledState(manager);
                case WorkflowStates.LicenseIssuancePending:
                    return new LicenseIssuancePendingState(manager);
                case WorkflowStates.LicenseIssued:
                    return new LicenseIssuedState(manager);
                case WorkflowStates.AdditionalClassesPending:
                    return new AdditionalClassesPendingState(manager);
                case WorkflowStates.AdditionalClassesScheduled:
                    return new AdditionalClassesScheduledState(manager);
                case WorkflowStates.AdditionalClassesCompleted:
                    return new AdditionalClassesCompletedState(manager);
                default:
                    throw new Exception("Unknown Contract State!");
            }
        }

    }
}