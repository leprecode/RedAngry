using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageGameplayState : IStageState
{
    private Spawner _spawner;
    private int _timeBetweenSpawn;


    public void Enter()
    {
        Debug.Log("EnterGameplayState");

    }

    public void Exit()
    {
    }

    public void GetSpawner(Spawner spawner)
    {
        this._spawner = spawner;
    }

    public void Initialize(Spawner spawner, int timeBetweenSpawn)
    {
        this._spawner = spawner;
        _timeBetweenSpawn = timeBetweenSpawn;
    }

    public void Update()
    {
        Debug.Log("StageGameplayState");

    }
}
