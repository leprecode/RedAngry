using System;
using UnityEngine;

namespace Assets.Code.Infrastructure
{
    public class GameBootstrapState : IGameState
    {
        private const string LoadingSceneName = "Loading";
        private readonly GameStateMachine _gameStateMachine;
        private readonly SceneLoader _sceneLoader;

        public GameBootstrapState(GameStateMachine gameStateMachine, SceneLoader sceneLoader)
        {
            _gameStateMachine = gameStateMachine;
            _sceneLoader = sceneLoader; 
        }

        public void Enter()
        {
            Debug.Log("Bootsrap enter!");
            _sceneLoader.Load(LoadingSceneName,EnterLoadLevel);
        }

        private void EnterLoadLevel() => 
            _gameStateMachine.Enter<LoadSceneState, string>("MainMenu");

        public void Exit()
        {
        }
    }
}

 