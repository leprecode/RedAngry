using Assets.Code.Data;
using Assets.Code.Infrastructure.Services.Progress;
using Assets.Code.Infrastructure.Services.SaveLoad;
using System;

namespace Assets.Code.Infrastructure.GameStates
{
    public class LoadPlayerGameProgressState  : IGameState
    {
        private const string MainMenuScene = "MainMenu";
        private readonly GameStateMachine _gameStateMachine;
        private readonly IPersistentProgressService _progressService;
        private readonly ISaveLoadService _saveLoadService;

        public LoadPlayerGameProgressState(GameStateMachine gameStateMachine, IPersistentProgressService persistentProgressService, ISaveLoadService saveLoadService)
        {
            this._gameStateMachine = gameStateMachine;
            this._progressService = persistentProgressService;
            this._saveLoadService = saveLoadService;
        }

        public void Enter()
        {
            LoadProgressOrInitialNewProgress();
            _gameStateMachine.Enter<LoadSceneState, string>(MainMenuScene);
        }

        private void LoadProgressOrInitialNewProgress()
        {
            _progressService.Progress = _saveLoadService.LoadProgress() ?? NewProgress();
        }

        //TODO: откуда взять инишиал уровень для каждого стейджа
        private PlayerProgress NewProgress() =>
            new PlayerProgress(/*"TestScene"*/);

        public void Exit()
        {
        }
    }
}

