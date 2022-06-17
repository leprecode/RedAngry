using Assets.Code.Level.StageStates;
using UnityEngine;

namespace Assets.Code.Level
{
    public class StageVictoryState : IStageState
    {
        private readonly StageStateMachine _stageStateMachine;

        public StageVictoryState(StageStateMachine stageStateMachine)
        {
            this._stageStateMachine = stageStateMachine;
        }

        public void Enter()
        {
            Debug.Log("Victory State");
        }

        public void Exit()
        {
        }

        public void Update()
        {
        }
    }
}