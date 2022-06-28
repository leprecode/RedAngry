using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Assets.Code.Level
{
    public class WaveSpawner
    {
        private float _timeToSpawn = 1.0f;
        private float _timer = 0f;

        private readonly List<GameObject> _wave1;
        private readonly List<GameObject> _wave2;
        private readonly List<GameObject> _wave3;

        public WaveSpawner(List<Dictionary<GameObject,int>> listOfCreatedEnemyWaves)
        {
            _wave1 = new List<GameObject>();
            _wave2 = new List<GameObject>();
            _wave3 = new List<GameObject>();


            switch (listOfCreatedEnemyWaves.Count)
            {
                case 1:
                    _wave1 = WaveDictionaryToList(listOfCreatedEnemyWaves[0]);
                    break;
                case 2:
                    _wave1 = WaveDictionaryToList(listOfCreatedEnemyWaves[0]);
                    _wave1 = WaveDictionaryToList(listOfCreatedEnemyWaves[1]);
                    break;
                case 3:
                    _wave1 = WaveDictionaryToList(listOfCreatedEnemyWaves[0]);
                    _wave1 = WaveDictionaryToList(listOfCreatedEnemyWaves[1]);
                    _wave1 = WaveDictionaryToList(listOfCreatedEnemyWaves[2]);
                    break;

                default:
                Debug.LogError("listOfCreatedEnemyWaves is empty");
                    break;
            }
        }

        public void EnableFirstWave()
        {
            Debug.Log("SpawnFirstWave");
            EnableWave(_wave1);
        }

        public void EnableSecondWave()
        {
            EnableWave(_wave2);
        }

        public void EnableThirdWave()
        {
            EnableWave(_wave3);
        }

        private void EnableWave(List<GameObject> wave)
        {
            //repair
            int RandomEnemy = Random.Range(0, wave.Count);

            _timer += Time.deltaTime;

            if (_timer >= _timeToSpawn)
            {
                Debug.Log(_timer);
                wave[RandomEnemy].SetActive(true);
                wave.RemoveAt(RandomEnemy);
                _timer = 0;
            }
        }

        private List<GameObject> WaveDictionaryToList(Dictionary<GameObject, int> wave)
        {
            List<GameObject> newList = new List<GameObject>();

            foreach (GameObject enemyType in wave.Keys)
            {
                for (int enemyCount = 0; enemyCount < wave[enemyType]; enemyCount++)
                {
                    newList.Add(enemyType);
                }
            }

            return newList;
        }
    }



}