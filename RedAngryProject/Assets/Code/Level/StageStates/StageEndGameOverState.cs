using Assets.Code.Level.StageStates;
using UnityEngine;

namespace Assets.Code.Level.StageStates
{
    public class StageEndGameOverState : IStageState
    {
        public void Enter()
        {
        }

        public void Exit()
        {
        }

        public void Update()
        {
            Debug.Log("StageEndGameOverState");

        }
    }
}