using UnityEngine;

public class StageBootstrapState : IStageState
{
    public Spawner _spawner { get; private set; }

    public void Enter()
    {
        Debug.Log("EnterStageBootstrapState");


        Stage.instance.spawner = new Spawner();
        Stage.instance.spawner.Initialize(Stage.instance.GetStageData.GetWaves());

        Stage.instance.GetStateMachine.SetGameplayState();
    }

    public void Exit()
    {
    }

    public void Update()
    {
        Debug.Log("BootstrapState");
    }
}
