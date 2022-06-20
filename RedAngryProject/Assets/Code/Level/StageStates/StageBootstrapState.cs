using Assets.Code.Level.Factories;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Code.Level.StageStates
{
    public class StageBootstrapState : IStageState
    {
        private const string _tagToSearchParentOfSpawnPoints = "SpawnPoints";
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

            CreateMapFactory();
            CreatePlayerFactory();
            CreateEnemyFactory();
        }

        private void CreateEnemyFactory()
        {
            var pointsToSpawn = GetSpawnPoints();
            var waves = GetWaves();

            _factories[typeof(StageEnemyFactory)] = new StageEnemyFactory(pointsToSpawn, waves);
        }

        private List<Transform> GetSpawnPoints()
        {
            var parentOfSpawnPoints = GameObject.FindGameObjectWithTag(_tagToSearchParentOfSpawnPoints);
            List<Transform> _pointsToSpawn = new List<Transform>();

            for (int i = 0; i < parentOfSpawnPoints.transform.childCount; i++)
            {
                _pointsToSpawn.Add(parentOfSpawnPoints.transform.GetChild(i));
            }

            return _pointsToSpawn;
        }

        private void CreatePlayerFactory()
        {
            _factories[typeof(StagePlayerFactory)] = new StagePlayerFactory(StageEntryPoint.instance.StageData);
        }

        private void CreateMapFactory()
        {
            var stagePrefab = StageEntryPoint.instance.StageData.StageMapPrefab;
            _factories[typeof(StageMapFactory)] = new StageMapFactory(stagePrefab);
        }

        private void StartAllFactories()
        {
            foreach (var factory in _factories)
            {
                factory.Value.Create();
            }
        }
        private List<Wave> GetWaves()
        {
            List<Wave> waves = new List<Wave>();

            int countOfWaves = StageEntryPoint.instance.StageData.GetAllWaves().Count;

            for (int i = 0; i < countOfWaves; i++)
            {
                waves.Add(StageEntryPoint.instance.StageData.GetWave(i));
            }

            return waves;
        }
    }
}