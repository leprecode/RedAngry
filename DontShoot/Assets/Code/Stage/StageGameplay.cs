using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageGameplay
{
    private Spawner _spawner;
    private int _timeBetweenSpawn;


    public void Initialize(Spawner spawner, int timeBetweenSpawn)
    {
        this._spawner = spawner;
        _timeBetweenSpawn = timeBetweenSpawn;
    }


    //STAAAATE MAAACHINE!!!!!!!!!!!!!!!!!!!!!


}
