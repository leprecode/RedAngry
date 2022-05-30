using UnityEngine;

namespace Assets.Code.Level
{
    public class StageBootstrapState : IStageState
    {
        public Spawner _spawner { get; private set; }

        public void Enter()
        {
            Debug.Log("EnterStageBootstrapState");

            Stage.instance.Spawner.Initialize(Stage.instance.GetStageData.GetAllWaves());

            Stage.instance.GetStateMachine.SetGameplayState();
        }

        public void Exit()
        {
        }

        public void Update()
        {
            Debug.Log("BootstrapState");
        }
    }
}