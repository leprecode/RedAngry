using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Code.Level.Factories
{
    public class StageEnemyFactory : IStageFactory
    {
        private const string _tagToSearch = "SpawnPoints";

        private readonly List<Transform> _pointsToSpawn;
        private readonly List<Wave> _waves;

        private List<GameObject> _allEnemies;
        private int _currentSpawnPoint = 0;

        public List<GameObject> AllEnemies { get => _allEnemies; }

        public StageEnemyFactory(List<Transform> pointsToSpawn, List<Wave> waves)
        {
            _pointsToSpawn = pointsToSpawn;
            _waves = waves;

        }

        public void Create()
        {
            Debug.Log("StageEnemyFactory");
            CreateEnemies();
        }

        private void CreateEnemies()
        {
            _allEnemies = new List<GameObject>();
            Dictionary<GameObject, int> enemies = new Dictionary<GameObject, int>();

            for (int wave = 0; wave < _waves.Count; wave++)
            {
                InstantiateEmptyObjectForWave(wave);
                enemies = _waves[wave].Enemies;

                foreach (var enemyKey in enemies.Keys)
                {
                    for (int enemyCount = 0; enemyCount < enemies[enemyKey]; enemyCount++)
                    {
                        GameObject newEnemy = GameObject.Instantiate(enemyKey,
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