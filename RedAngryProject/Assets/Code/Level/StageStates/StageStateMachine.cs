using Assets.Code.Level.StageStates;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Code.Level
{
    public class StageStateMachine : MonoBehaviour
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
            Debug.Log("StatesInitialized");

            _states = new Dictionary<Type, IStageState>();

            _states[typeof(StageBootstrapState)] = new StageBootstrapState(this);
            _states[typeof(StageGameplayState)] = new StageGameplayState(this);
            _states[typeof(StageGameOverState)] = new StageGameOverState(this);
            _states[typeof(StageVictoryState)] = new StageVictoryState(this);
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
            var state = GetState<StageEndGameOverState>();
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