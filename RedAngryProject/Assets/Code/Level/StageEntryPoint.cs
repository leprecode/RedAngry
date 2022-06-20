using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Assets.Code.Level
{
    public class StageEntryPoint : MonoBehaviour
    {
        [SerializeField] private StageData stageData;
        public static StageEntryPoint instance { get; private set; }
        public StageData StageData => stageData;
        public StageStateMachine GetStateMachine => stateMachine;
        public List<GameObject> allEnemies { get; private set; }
        private StageStateMachine stateMachine;


        private void Awake()
        {
            MakeStaticInstacne();

            allEnemies = new List<GameObject>();
            stateMachine = new StageStateMachine();
            stateMachine.Initialize();
        }

        public void SetAllEnemies(List<GameObject> enemies) => allEnemies = enemies;

        private void MakeStaticInstacne()
        {
            if (instance == null)
            {
                instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }

    public class WaveSpawner
    {
        private float _timeToSpawn = 1.0f;
        private float _timer = 0f;

        private readonly List<GameObject> _wave1;
        private readonly List<GameObject> _wave2;
        private readonly List<GameObject> _wave3;

        public WaveSpawner(Dictionary<GameObject, int> wave1, Dictionary<GameObject, int> wave2 = null, 
            Dictionary<GameObject, int> wave3 = null)
        {
            _wave1 = new List<GameObject>();
            _wave2 = new List<GameObject>();
            _wave3 = new List<GameObject>();

            if (wave1 != null)
                this._wave1 = WaveDictionaryToList(wave1);

            if (wave2 != null)
                this._wave2 = WaveDictionaryToList(wave2);
            
            if (wave3 != null)
                this._wave3 = WaveDictionaryToList(wave3);
        }

        private void EnableWave(List<GameObject> _wave1)
        {
            int RandomEnemy = Random.Range(0, _wave1.Count);

            _timer += Time.deltaTime;

            if (_timer >= _timeToSpawn)
            {
                _wave1[RandomEnemy].SetActive(true);
                _wave1.RemoveAt(RandomEnemy);
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