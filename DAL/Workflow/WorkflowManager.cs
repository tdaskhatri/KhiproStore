using DAL.Workflow;
using DAL.Workflow.States;
using eLearning.DAL.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DAL.Workflow
{
    // AVANZA\jawwad.ahmed - 25/08/2017 12:16:27
    public enum WorkflowIdentityType
    {
        TrafficFileNumber = 0,
        ServiceContractId = 1,
        CustomerId = 2
    }

    // AVANZA\jawwad.ahmed - 24/07/2017 19:08:47
    public enum WorkflowStates
    {
        None = 0,
        NewCustomer = 1,
        LecturesSchedulePending = 2,
        LecturesScheduled = 3,
        LecturesCompleted = 4,
        KnowledgeTestScheduled = 5,
        PracticalSchedulePending = 6,
        PracticalScheduled = 7,
        PracticalScheduledB = 8,
        PracticalCompleted = 9,
        ParkingTestScheduled = 10,
        InternalAssessment = 11,
        RoadTestScheduled = 12,
        LicenseIssuancePending = 13,
        LicenseIssued = 14,
        AdditionalClassesPending = 15,
        AdditionalClassesScheduled = 16,
        AdditionalClassesCompleted = 17
    }

    // AVANZA\jawwad.ahmed - 24/07/2017 19:08:50
    public class WorkflowManager
    {
        public DAWorkflow DataAccess { get; set; }
        public BaseState CurrentState { get; set; }
        public int ContractId { get; }

        // Modified by AVANZA\muhammad.uzair on 01/11/2017 16:05:22
        public WorkflowManager(int contractId)
        {
            this.ContractId = contractId;
            this.DataAccess = new DAWorkflow(this.ContractId);

            // Set based on contract state in DB.
            WorkflowStates state = (WorkflowStates)this.DataAccess.GetCurrentState();

            this.CurrentState = BaseState.GetInstanceOf(state, this);
        }

        public WorkflowManager(string identity, WorkflowIdentityType identityType)
        {
            this.DataAccess = new DAWorkflow(identity, identityType);

            // Set based on contract state in DB.
            WorkflowStates state = (WorkflowStates)this.DataAccess.GetCurrentState();

            this.CurrentState = BaseState.GetInstanceOf(state, this);
        }


        public BaseState GetCurrentState()
        {
            return this.CurrentState;
        }

        public bool MoveToNextState()
        {
            var newState = this.CurrentState.GotoNextState();
            if (newState != this.CurrentState)
            {
                this.CurrentState = newState;
                this.DataAccess.UpdateWorkflowStatus(newState.InternalState);
                return true;
            }
            else
            {
                // State was not changed!
                return false;
            }
        }

        // Added by AVANZA\jawwad.ahmed on 29/11/2017 12:46:48
        public int GetCurrentStageId()
        {
            return this.DataAccess.GetStageFromState(this.CurrentState.InternalState);
        }
    }
}