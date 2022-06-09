using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Code.Level
{
    public class StageEnemyFactory : IStageFactory
    {
        private const string _tagToSearch = "SpawnPoints";
        private Vector3 _spawnOffsetY = new Vector3(0f, 0.2f, 0f);
        private List<Transform> _pointsToSpawn;
        private int _currentSpawnPoint = 0;
        
        private List<Wave> _waves;
        


        public void Initialize()
        {
            GetSpawnPoints();

            GetWaves();

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

                        DisableEnemy(newEnemy);
                    }
                }
            }
        }

        private void DisableEnemy(GameObject newEnemy)
        {
            newEnemy.SetActive(false);
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

            int countOfWaves = Stage.instance.GetStageData.GetAllWaves().Count;

            for (int i = 0; i < countOfWaves; i++)
            {
                _waves.Add(Stage.instance.GetStageData.GetWave(i));
            }
        }

        public void Create()
        {
            Debug.Log("StageEnemyFactory");
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