using Assets.Code.Level.AssetManagement;
using Assets.Code.Level.Factories;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Code.Level.StageStates
{
    public class StageBootstrapState : IStageState
    {
        private List<IStageFactory> _factories;

        public void Enter()
        {
            Debug.Log("EnterStageBootstrapState");

            CreateAllFactories();
            InitializeAllFactories();
            StartAllFactories();

            Stage.instance.GetStateMachine.SetGameplayState();
        }

        public void Exit()
        {
        }

        public void Update()
        {
            Debug.Log("BootstrapState");
        }

        private void CreateAllFactories()
        {
            _factories = new List<IStageFactory>();

            _factories.Add(new StageMapFactory());

            //remove
            _factories.Add(new StagePlayerFactory(new AssetProvider()));

            _factories.Add(new StageEnemyFactory());
        }

        private void StartAllFactories()
        {
            for (int i = 0; i < _factories.Count; i++)
            {
                _factories[i].Create();
            }
        }

        private void InitializeAllFactories()
        {
            for (int i = 0; i < _factories.Count; i++)
            {
                _factories[i].Initialize();
            }
        }
    }
}