using System.Collections.Generic;
using UnityEngine;

namespace Assets.Code.Level
{
    public class Stage : MonoBehaviour
    {
        //Убрать монобех и инициализировать со стейт машиной всей игры
        [SerializeField] private StageData stageData;

        private StageStateMachine stateMachine;
        public static Stage instance { get; private set; }
        public StageData GetStageData => stageData;
        public StageStateMachine GetStateMachine => stateMachine;

        public List<GameObject> allEnemies { get; private set; }

        private void Awake()
        {
            Debug.Log("StageIsAwaked");

            allEnemies = new List<GameObject>();

            MakeStaticInstacne();

            stateMachine = gameObject.AddComponent<StageStateMachine>();

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
}