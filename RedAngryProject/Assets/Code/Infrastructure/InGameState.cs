using UnityEngine;

namespace Assets.Code.Infrastructure
{
    public class InGameState : IGameState
    {
        private readonly GameStateMachine _gameStateMachine;
        private readonly SceneLoader _sceneLoader;

        public InGameState(GameStateMachine gameStateMachine, SceneLoader sceneLoader)
        {
            this._gameStateMachine = gameStateMachine;
            this._sceneLoader = sceneLoader;
        }

        public void Enter()
        {
            Debug.Log("InGameState");
        }

        public void Exit()
        {
        }
    }

}


