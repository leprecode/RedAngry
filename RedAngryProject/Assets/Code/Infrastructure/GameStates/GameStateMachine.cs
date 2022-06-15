using Assets.Code.Infrastructure.Services;
using Assets.Code.Infrastructure.Services.Progress;
using Assets.Code.Infrastructure.Services.SaveLoad;
using System;
using System.Collections.Generic;

namespace Assets.Code.Infrastructure.GameStates
{
    public class GameStateMachine
    {
        private readonly Dictionary<Type, IExitableGameState> _states;
        private IExitableGameState _activeState;

        public GameStateMachine(SceneLoader sceneLoader, AllServices services)
        {
            _states = new Dictionary<Type, IExitableGameState>
            {
                [typeof(GameBootstrapState)] = new GameBootstrapState(this, sceneLoader, services),
                [typeof(LoadSceneState)] = new LoadSceneState(this, sceneLoader),
                [typeof(InGameState)] = new InGameState(this, sceneLoader),
                [typeof(LoadPlayerGameProgressState)] = new LoadPlayerGameProgressState(this,services.Single<IPersistentProgressService>(), services.Single<ISaveLoadService>()),
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

        public TState GetState<TState>() where TState : class, IExitableGameState =>
        _states[typeof(TState)] as TState;

    }
}

