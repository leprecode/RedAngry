using Assets.Code.Level.StageStates;
using UnityEngine;

namespace Assets.Code.Level.StageStates
{
    public class StageGameOverState : IStageState
    {
        private readonly StageStateMachine _stageStateMachine;

        public StageGameOverState(StageStateMachine stageStateMachine)
        {
            this._stageStateMachine = stageStateMachine;
        }

        public void Enter()
        {
        }

        public void Exit()
        {
        }

        public void Update()
        {
            Debug.Log("StageGameOverState");

        }
    }
}