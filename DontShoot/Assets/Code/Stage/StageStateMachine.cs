using System;
using System.Collections.Generic;
using UnityEngine;

public class StageStateMachine : MonoBehaviour
{
    private Dictionary<Type, IStageState> _states;
    private IStageState _currentState;

    private void Start()
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

        _states[typeof(StageBootstrapState)] = new StageBootstrapState();
        _states[typeof(StageGameplayState)] = new StageGameplayState();
        _states[typeof(StageEndGameOverState)] = new StageEndGameOverState();
        _states[typeof(StageEndGameVictoryState)] = new StageEndGameVictoryState();
    }

    private void SetState(IStageState newState)
    {
        if (_currentState != null)
            _currentState.Exit();

        _currentState = newState;
        _currentState.Enter();
    }

    public IStageState GetState<T>() where T : IStageState
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
        var state = this.GetState<StageGameplayState>();
        this.SetState(state);
    }
    public void SetGameOverState()
    {
        var state = this.GetState<StageEndGameOverState>();
        this.SetState(state);
    }
    public void SetVictoryState()
    {
        var state = this.GetState<StageEndGameVictoryState>();
        this.SetState(state);
    }
}
