using UnityEngine;

public class Stage : MonoBehaviour
{
    [SerializeField] private StageData stageData;

    private StageStateMachine stateMachine;
    public static Stage instance { get; private set; }

    public Spawner spawner;

    public StageData GetStageData => stageData;
    public StageStateMachine GetStateMachine => stateMachine;


    private void Awake()
    {
        Debug.Log("StageIsAwaked");

        MakeStaticInstacne();

        spawner = new Spawner();

        stateMachine = this.gameObject.AddComponent<StageStateMachine>();
    }

    private void MakeStaticInstacne()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}
