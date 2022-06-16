using Assets.Code.Level.AssetManagement;
using Assets.Code.Level.Factories;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Code.Level.StageStates
{
    public class StageBootstrapState : IStageState
    {
        private Dictionary<Type,IStageFactory> _factories;
        private readonly StageStateMachine _stageStateMachine;

        public StageBootstrapState(StageStateMachine stageStateMachine)
        {
            this._stageStateMachine = stageStateMachine;
        }

        public void Enter()
        {
            Debug.Log("EnterStageBootstrapState");

            CreateAllFactories();
            InitializeAllFactories();
            StartAllFactories();

            _stageStateMachine.SetGameplayState();
        }

        public void Exit()
        {
        }

        public void Update()
        {
            Debug.Log("BootstrapState");
        }

        public IStageFactory GetFactory<TFactory>() where TFactory : IStageFactory
        {
            var factory = typeof(TFactory);
            return _factories[factory];
        }

        private void CreateAllFactories()
        {
            _factories = new Dictionary<Type, IStageFactory>();

            _factories[typeof(StageMapFactory)] = new StageMapFactory();
            _factories[typeof(StagePlayerFactory)] = new StagePlayerFactory(new AssetProvider());
            _factories[typeof(StageEnemyFactory)] = new StageEnemyFactory();
        }

        private void StartAllFactories()
        {
            foreach (var factory in _factories)
            {
                factory.Value.Create();
            }
        }

        private void InitializeAllFactories()
        {
            foreach (var factory in _factories)
            {
                factory.Value.Initialize();
            }
        }
    }
}