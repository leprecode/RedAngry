using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Code.Level
{
    public class StageEntryPoint : MonoBehaviour
    {
        [SerializeField] private StageData stageData;
        private StageStateMachine _stateMachine;
        public static StageEntryPoint instance { get; private set; }
        public StageData StageData => stageData;
        public StageStateMachine GetStateMachine => _stateMachine;
        public List<GameObject> allEnemies { get; private set; }


        private void Awake()
        {
            MakeStaticInstacne();

            allEnemies = new List<GameObject>();
            _stateMachine = new StageStateMachine();
            _stateMachine.Initialize();
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

        private void Update()
        {
            _stateMachine.Update();
        }
    }
}