using UnityEngine;

namespace Assets.Code.Level
{
    public class Stage : MonoBehaviour
    {
        [SerializeField] private StageData stageData;

        private StageStateMachine stateMachine;
        public static Stage instance { get; private set; }
        public Spawner Spawner { get; set; }
        public StageData GetStageData => stageData;
        public StageStateMachine GetStateMachine => stateMachine;


        private void Awake()
        {
            Debug.Log("StageIsAwaked");

            MakeStaticInstacne();

            Spawner = gameObject.AddComponent<Spawner>();

            stateMachine = gameObject.AddComponent<StageStateMachine>();
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