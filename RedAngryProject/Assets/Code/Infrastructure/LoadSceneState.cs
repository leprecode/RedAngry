using UnityEngine;

namespace Assets.Code.Infrastructure
{
    public class LoadSceneState : IPayloadedGameState<string>
    {
        private const string nameOfMainMenuScene = "MainMenu";
        private const string nameOfLoadingScene = "Loading";
        private readonly GameStateMachine _gameStateMachine;
        private readonly SceneLoader _sceneLoader;
        private readonly GameFactory _gameFactory;

        public LoadSceneState(GameStateMachine gameStateMachine, SceneLoader sceneLoader)
        {
            this._gameStateMachine = gameStateMachine;
            this._sceneLoader = sceneLoader;
        }

        public void Enter(string sceneName)
        {
            CheckAndEnterNewState(sceneName);
        }

        private void CheckAndEnterNewState(string sceneName)
        {
            switch (sceneName)
            {
                case nameOfMainMenuScene:
                    _sceneLoader.Load(sceneName, EnterInMainMenuState);
                    break;

                default:
                    _sceneLoader.Load(sceneName);
                    EnterInGameState();
                    break;
            }
        }

        private void EnterInMainMenuState()
        {
            _gameStateMachine.Enter<InMainMenuState>();
            InitialInMainMenuState();
        }
        private void InitialInMainMenuState()
        {
            _gameStateMachine.GetState<InMainMenuState>().mainMenuUI.Initial();
        }
        private void EnterInGameState()
        {
            _gameStateMachine.Enter<InGameState>();
        }

        public void Exit()
        {
        }


    }
} 