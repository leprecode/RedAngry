using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Code.Level.Factories
{
    public class StageEnemyFactory : IStageFactory
    {
        private const string _tagToSearch = "SpawnPoints";
        private int _currentSpawnPoint = 0;

        private List<Transform> _pointsToSpawn;
        private List<GameObject> _allEnemies = new List<GameObject>();
        private List<Wave> _waves;

        public StageEnemyFactory()
        {
        }

        public void Initialize()
        {
            GetWaves();
        }

        public void Create()
        {
            Debug.Log("StageEnemyFactory");

            GetSpawnPoints();
            CreateEnemies();
        }

        private void CreateEnemies()
        {
            for (int wave = 0; wave < _waves.Count; wave++)
            {
                InstantiateEmptyObjectForWave(wave);

                for (int enemyType = 0; enemyType < _waves[wave].GetWaveEnemiesTypes().Count; enemyType++)
                {
                    for (int countEnemyOfType = 0; countEnemyOfType < _waves[wave].GetWaveEnemiesCount()[enemyType]; countEnemyOfType++)
                    {
                        GameObject newEnemy = GameObject.Instantiate(_waves[wave].GetWaveEnemiesTypes()[enemyType],
                             _pointsToSpawn[NextSpawnPoint()].GetChild(wave));

                        _allEnemies.Add(newEnemy);
                        DisableEnemy(newEnemy);
                    }
                }
            }

            SendAllEnemiesToStage();
        }

        private void DisableEnemy(GameObject newEnemy)
        {
            newEnemy.SetActive(false);
        }

        private void SendAllEnemiesToStage()
        {
            Stage.instance.SetAllEnemies(_allEnemies);
        }

        private void InstantiateEmptyObjectForWave(int numberOfWave)
        {
            GameObject newEmptyObject = new GameObject();
            newEmptyObject.name = "Wave" + numberOfWave;

            for (int i = 0; i < _pointsToSpawn.Count; i++)
            {
                GameObject.Instantiate(newEmptyObject, _pointsToSpawn[i]);
            }
        }

        private void GetWaves()
        {
            _waves = new List<Wave>();

            int countOfWaves = Stage.instance.StageData.GetAllWaves().Count;

            for (int i = 0; i < countOfWaves; i++)
            {
                _waves.Add(Stage.instance.StageData.GetWave(i));
            }
        }

        private void GetSpawnPoints()
        {
            _pointsToSpawn = new List<Transform>();

            GameObject parentOfSpawnPoints = GameObject.FindGameObjectWithTag(_tagToSearch);

            for (int i = 0; i < parentOfSpawnPoints.transform.childCount; i++)
            {
                _pointsToSpawn.Add(parentOfSpawnPoints.transform.GetChild(i));
            }
        }

        private int NextSpawnPoint()
        {
            if (_currentSpawnPoint + 1 < _pointsToSpawn.Count)
            {
                _currentSpawnPoint++;
            }
            else
            {
                _currentSpawnPoint = 0;
            }

            return _currentSpawnPoint;
        }
    }
}