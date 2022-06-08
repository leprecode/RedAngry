using System.Collections.Generic;
using UnityEngine;

namespace Assets.Code.Level
{
    public class StageBootstrapState : IStageState
    {
        private List<IStageFactory> _factories;

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

        private void InitialAllFactories()
        {
            _factories = new List<IStageFactory>();

            _factories.Add(new StageMapFactory());
            _factories.Add(new StagePlayerFactory());
            _factories.Add(new StageEnemyFactory());
        }
    }
}