using System;
using System.Collections.Generic;

namespace Assets.Code.Infrastructure
{
    public class GameStateMachine
    {
        private readonly Dictionary<Type, IExitableGameState> _states;
        private IExitableGameState _activeState;

        public GameStateMachine(SceneLoader sceneLoader)
        {
            _states = new Dictionary<Type, IExitableGameState>
            {
                [typeof(GameBootstrapState)] = new GameBootstrapState(this, sceneLoader),
                [typeof(LoadSceneState)] = new LoadSceneState(this, sceneLoader),
                [typeof(InGameState)] = new InGameState(this, sceneLoader),
                [typeof(InMainMenuState)] = new InMainMenuState(this, sceneLoader),
            };
        }

        public void Enter<TState>() where TState : class, IGameState
        {
            IGameState state = ChangeState<TState>();
            state.Enter();
        }

        public void Enter<TState, TPayload>(TPayload payload) where TState : class, IPayloadedGameState<TPayload>
        {
            TState state = ChangeState<TState>();
            state.Enter(payload);
        }
        private TState ChangeState<TState>() where TState : class, IExitableGameState
        {
            _activeState?.Exit();

            TState state = GetState<TState>();
            _activeState = state;

            return state;
        }

        private TState GetState<TState>() where TState : class, IExitableGameState =>
        _states[typeof(TState)] as TState;

    }

}

