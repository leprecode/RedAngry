using System.Collections.Generic;
using UnityEngine;

namespace Assets.Code.Level.Factories
{
    public class StageEnemyFactory : IStageFactory
    {
        private readonly List<Transform> _pointsToSpawn;
        private readonly List<Wave> _waves;
        private int _currentSpawnPoint = 0;
        public List<GameObject> allEnemies { get; private set; }

        public List<Dictionary<GameObject, int>> _listOfCreatedEnemyInWaves { get; private set; }
        public Dictionary<GameObject, int> wave1 { get; private set; }
        public Dictionary<GameObject, int> wave2 { get; private set; }
        public Dictionary<GameObject, int> wave3 { get; private set; }


        public StageEnemyFactory(List<Transform> pointsToSpawn, List<Wave> waves)
        {
            _pointsToSpawn = pointsToSpawn;
            _waves = waves;

            _listOfCreatedEnemyInWaves = new List<Dictionary<GameObject, int>>();

            CreateEnemies();

        }

        private void CreateEnemies()
        {

            Dictionary<GameObject, int> enemies = new Dictionary<GameObject, int>();
            
            allEnemies = new List<GameObject>();

            for (int wave = 0; wave < _waves.Count; wave++)
            {
                InstantiateEmptyObjectForWave(wave);
                enemies = _waves[wave].Enemies;
                _listOfCreatedEnemyInWaves.Add(new Dictionary<GameObject,int>());

                foreach (var enemyKey in enemies.Keys)
                {
                    for (int enemyCount = 0; enemyCount < enemies[enemyKey]; enemyCount++)
                    {
                        GameObject newEnemy = GameObject.Instantiate(enemyKey,
                                        _pointsToSpawn[NextSpawnPoint()].GetChild(wave));
                        
                        allEnemies.Add(newEnemy);
                        _listOfCreatedEnemyInWaves[wave].Add(newEnemy,+1);
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