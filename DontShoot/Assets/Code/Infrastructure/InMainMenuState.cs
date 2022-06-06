using Assets.Code.MainMenu;
using UnityEngine;

namespace Assets.Code.Infrastructure
{
    public class InMainMenuState : IGameState
    {
        private readonly GameStateMachine _gameStateMachine;
        private readonly SceneLoader _sceneLoader;
        public MainMenuUI mainMenuUI { get; private set; }

        public InMainMenuState(GameStateMachine gameStateMachine, SceneLoader sceneLoader)
        {
            this._gameStateMachine = gameStateMachine;
            this._sceneLoader = sceneLoader;
        }

        public void Enter()
        {
            Debug.Log("InMainMenuState");
            mainMenuUI = new MainMenuUI(_gameStateMachine);
        }

        public void Exit()
        {
        }
    }

}


