using Assets.Code.Level.Factories;
using Assets.Code.Level.StageStates;
using System;
using System.Collections;
using UnityEngine;

namespace Assets.Code.Level
{
    public class StageGameplayState : IStageState
    {
        private readonly StageStateMachine _stageStateMachine;
        private readonly WaveSpawner _waveSpawner;
        private EnemyWatcher _enemyWatcher;
        private PlayerWatcher _playerWatcher;

        public StageGameplayState(StageStateMachine stageStateMachine, WaveSpawner waveSpawner, 
            EnemyWatcher enemyWatcher, PlayerWatcher playerWatcher)
        {
            this._stageStateMachine = stageStateMachine;
            this._waveSpawner = waveSpawner;
            _enemyWatcher = enemyWatcher;
            _playerWatcher = playerWatcher;
        }

        public void Enter()
        {
            Debug.Log("EnterGameplayState");
        }

        public void Exit()
        {
        }

        public void Update()
        {
            Debug.Log("StageGameplayState");
            _waveSpawner.EnableFirstWave();
        }
    }
}
