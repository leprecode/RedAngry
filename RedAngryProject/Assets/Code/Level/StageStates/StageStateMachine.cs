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

            GameObject player = GetPlayer();

            var listOfCreatedEnemyWaves = GetCreatedEnemies();


            List<GameObject> allEnemies = new List<GameObject>();
            GetAllEnemies(out allEnemies);


            _states[typeof(StageGameplayState)] = new StageGameplayState(this, new WaveSpawner(listOfCreatedEnemyWaves), new EnemyWatcher(allEnemies), new PlayerWatcher(player));
            _states[typeof(StageGameOverState)] = new StageGameOverState(this);
            _states[typeof(StageVictoryState)] = new StageVictoryState(this);
        }

        private void GetAllEnemies(out List<GameObject> allEnemies)
        {
            var enemyFactory = (StageEnemyFactory)GetStageBootstrapState().GetFactory<StageEnemyFactory>();
            allEnemies = enemyFactory.allEnemies;
        }

        private List<Dictionary<GameObject,int>> GetCreatedEnemies()
        {
            var enemyFactory = (StageEnemyFactory)GetStageBootstrapState().GetFactory<StageEnemyFactory>();

            return enemyFactory._listOfCreatedEnemyInWaves;
        }

        private GameObject GetPlayer()
        {
            var playerFactory = (StagePlayerFactory)GetStageBootstrapState().GetFactory<StagePlayerFactory>();
            var player = playerFactory.player;
            return player;
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