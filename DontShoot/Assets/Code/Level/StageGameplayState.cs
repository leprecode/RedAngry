using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Code.Level
{
    public class StageGameplayState : IStageState
    {
        private int _currentEnemiesCountInWave;
        private const int _timeBetweenSpawn = 1;
        private Spawner _spawner;
        private int _timeBetweenWaves;
        private int _wavesCount;
        private int _numberWaveToSpawn;

        public void Enter()
        {
            Debug.Log("EnterGameplayState");

            Initialize();

            SpawnWave(_numberWaveToSpawn);
        }

        private bool CheckWaveCount()
        {
            if (_numberWaveToSpawn++ < _wavesCount)
            {
                _numberWaveToSpawn += 1;
                return true;
            }

            return false;
        }

        private void SpawnWave(int currentWave)
        {
                _spawner.Spawn(_timeBetweenSpawn,
                Stage.instance.GetStageData.GetWave(_numberWaveToSpawn).GetWaveEnemiesTypes(),
                Stage.instance.GetStageData.GetWave(_numberWaveToSpawn).GetWaveEnemiesCount());

            Debug.Log("StartSpawnNewWave");

            GetAllEnemiesCount(currentWave);

        }

        private void GetAllEnemiesCount(int _numberWaveToSpawn)
        {
            List<int> enemies = Stage.instance.GetStageData.GetWave(_numberWaveToSpawn).GetWaveEnemiesCount();

            for (int i = 0; i < enemies.Count; i++)
            {
                _currentEnemiesCountInWave += enemies[i];
            }

            Debug.Log(_currentEnemiesCountInWave + "All enemies");
        }

        public void EnemyDestroyed()
        {
            _currentEnemiesCountInWave--;

            CheckCurrentEnemyCount();
        }

        private void CheckCurrentEnemyCount()
        {
            if (_currentEnemiesCountInWave == 0)
            {
                CheckVictory();
            }
        }

        public void CheckVictory()
        {
            if (CheckWaveCount())
                SpawnWave(_numberWaveToSpawn);
            else
                Stage.instance.GetStateMachine.SetVictoryState();

        }

        private void Initialize()
        {
            _spawner = Stage.instance.Spawner;
            _timeBetweenWaves = Stage.instance.GetStageData.GetWavePause();
            _wavesCount = Stage.instance.GetStageData.GetAllWaves().Count;
        }

        public void Exit()
        {
        }

        public void Update()
        {
            Debug.Log("StageGameplayState");
        }


    }
}