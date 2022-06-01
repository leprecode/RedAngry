using UnityEngine;

namespace Assets.Code.Infrastructure
{
    public class InMainMenuState : IGameState
    {
        private readonly GameStateMachine _gameStateMachine;
        private readonly SceneLoader _sceneLoader;

        public InMainMenuState(GameStateMachine gameStateMachine, SceneLoader sceneLoader)
        {
            this._gameStateMachine = gameStateMachine;
            this._sceneLoader = sceneLoader;
        }

        public void Enter()
        {
            Debug.Log("InMainMenuState");
        }

        public void Exit()
        {
        }
    }

}


