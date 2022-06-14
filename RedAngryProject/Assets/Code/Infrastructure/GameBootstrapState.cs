﻿using Assets.Code.Infrastructure.Services;
using System;
using UnityEngine;

namespace Assets.Code.Infrastructure
{
    public class GameBootstrapState : IGameState
    {
        //Доделать регистрацию сервисов

        private const string LoadingSceneName = "Loading";
        private readonly GameStateMachine _gameStateMachine;
        private readonly SceneLoader _sceneLoader;
        private readonly AllServices _services;

        public GameBootstrapState(GameStateMachine gameStateMachine, SceneLoader sceneLoader, AllServices services)
        {
            _gameStateMachine = gameStateMachine;
            _sceneLoader = sceneLoader;
            _services = services;
        }

        public void Enter()
        {
            Debug.Log("Bootsrap enter!");
            _sceneLoader.Load(LoadingSceneName,EnterLoadLevel);
           RegisterServices();
        }

        private void RegisterServices()
        {
        

        }

        private void EnterLoadLevel() => 
            _gameStateMachine.Enter<LoadSceneState, string>("MainMenu");

        public void Exit()
        {
        }
    }
}

 