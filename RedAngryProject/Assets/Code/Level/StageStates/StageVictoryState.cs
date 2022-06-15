using Assets.Code.Level.StageStates;
using UnityEngine;

namespace Assets.Code.Level
{
    public class StageVictoryState : IStageState
    {
        public void Enter()
        {
            Debug.Log("Victory State");
        }

        public void Exit()
        {
            throw new System.NotImplementedException();
        }

        public void Update()
        {
            throw new System.NotImplementedException();
        }
    }
}