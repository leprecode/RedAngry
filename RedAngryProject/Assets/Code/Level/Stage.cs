using System.Collections.Generic;
using UnityEngine;

namespace Assets.Code.Level
{
    public class Stage : MonoBehaviour
    {
        //Убрать монобех

        [SerializeField] private StageData stageData;

        private StageStateMachine stateMachine;
        public static Stage instance { get; private set; }
        public StageData GetStageData => stageData;
        public StageStateMachine GetStateMachine => stateMachine;


        private void Awake()
        {
            Debug.Log("StageIsAwaked");

            MakeStaticInstacne();

            stateMachine = gameObject.AddComponent<StageStateMachine>();

            stateMachine.Initialize();
        }

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