using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Code.Level
{
    public class Spawner : MonoBehaviour
    {
        private const string _tagToSearch = "SpawnPoints";
        private Vector3 _spawnOffsetY = new Vector3(0f, 0.5f, 0f);
        private List<Transform> _pointsToSpawn;
        private int _currentSpawnPoint = 0;

        public void Initialize(List<Wave> waves)
        {
            GetSpawnPoints();
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

        public void Spawn(int timeBetweenSpawn,
            List<GameObject> prefabsOfEnemies, List<int> countOfEnemies)
        {
            StartCoroutine(SpawnCoroutine(timeBetweenSpawn, prefabsOfEnemies, countOfEnemies));
        }

        private IEnumerator SpawnCoroutine(int timeBetweenSpawn,
            List<GameObject> prefabsOfEnemies, List<int> countOfEnemies)
        {
            Debug.Log("SpawnFunc");

            for (int i = 0; i < prefabsOfEnemies.Count; i++)
            {
                for (int j = 0; j < countOfEnemies[i]; j++)
                {
                    GameObject newEnemy = Instantiate(prefabsOfEnemies[i], _pointsToSpawn[NextSpawnPoint()].position += _spawnOffsetY, Quaternion.identity);
                    Debug.Log("SpawnNew");
                    yield return new WaitForSeconds(timeBetweenSpawn);
                }
            }

            Debug.Log("EndWave");
        }
    }
}