using System;
using System.Collections.Generic;

namespace Assets.Code.Infrastructure
{
    public class GameStateMachine
    {
        private readonly Dictionary<Type, IGameState> _states;
        private IGameState _activeState;

        public GameStateMachine(SceneLoader sceneLoader)
        {
            _states = new Dictionary<Type, IGameState>
            {
                [typeof(GameBootstrapState)] = new GameBootstrapState(this, sceneLoader),
                /*[typeof(LoadLevelState)] = new LoadLevelState(),*/
            };
        }

        public void Enter<TState>() where TState : IGameState
        {
            _activeState?.Exit();
            IGameState state = _states[typeof(TState)];
            _activeState = state;
            state.Enter();
        }
    }
}

