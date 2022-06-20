using Assets.Code.Level.Factories;
using Assets.Code.Level.StageStates;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Code.Level
{
    public class StageStateMachine
    {
        private Dictionary<Type, IStageState> _states;
        private IStageState _currentState;

        public void Initialize()
        {
            Debug.Log("StateMachineIsStarted");
            InitializeStates();
            SetBehaviourByDefault();
        }

        public void Update()
        {
            _currentState.Update();
        }

        private void InitializeStates()
        {
            _states = new Dictionary<Type, IStageState>();
            _states[typeof(StageBootstrapState)] = new StageBootstrapState(this);

            List<GameObject> allEnemies = GetAllEnemies();
            GameObject player = GetPlayer();

            Dictionary<GameObject, int> Wave1, Wave2, Wave3;
            GetAllWaves(out Wave1, out Wave2/*, out Wave3*/);

            _states[typeof(StageGameplayState)] = new StageGameplayState(this, new WaveSpawner(Wave1, Wave2/*,Wave3*/), new EnemyWatcher(allEnemies), new PlayerWatcher(player));
            _states[typeof(StageGameOverState)] = new StageGameOverState(this);
            _states[typeof(StageVictoryState)] = new StageVictoryState(this);
        }

        private void GetAllWaves(out Dictionary<GameObject, int> Wave1, out Dictionary<GameObject, int> Wave2/*,out Dictionary<GameObject, int> Wave3*/)
        {
            Wave1 = StageEntryPoint.instance.StageData.GetWave(0).Enemies;
            Wave2 = StageEntryPoint.instance.StageData.GetWave(1).Enemies;
          //  Wave3 = StageEntryPoint.instance.StageData.GetWave(2).Enemies;
        }

        private GameObject GetPlayer()
        {
            var playerFactory = (StagePlayerFactory)GetStageBootstrapState().GetFactory<StagePlayerFactory>();
            var player = playerFactory.player;
            return player;
        }

        private List<GameObject> GetAllEnemies()
        {
            var enemyFactory = (StageEnemyFactory)GetStageBootstrapState().GetFactory<StageEnemyFactory>();
            var allEnemies = enemyFactory.allEnemies;
            return allEnemies;
        }

        private void SetState(IStageState newState)
        {
            if (_currentState != null)
                _currentState.Exit();

            _currentState = newState;
            _currentState.Enter();
        }

        private IStageState GetState<T>() where T : IStageState
        {
            var type = typeof(T);
            return _states[type];
        }

        private void SetBehaviourByDefault()
        {
            var stateByDefault = GetState<StageBootstrapState>();
            SetState(stateByDefault);
        }

        public void SetGameplayState()
        {
            var state = GetState<StageGameplayState>();
            SetState(state);
        }
        public void SetGameOverState()
        {
            var state = GetState<StageGameOverState>();
            SetState(state);
        }
        public void SetVictoryState()
        {
            var state = GetState<StageVictoryState>();
            SetState(state);
        }

        public StageBootstrapState GetStageBootstrapState()
        {
            var state = GetState<StageBootstrapState>();
            return (StageBootstrapState)state;
        }
    }
}