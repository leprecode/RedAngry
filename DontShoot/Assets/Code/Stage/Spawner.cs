using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner
{
    private const string _tagToSearch = "SpawnPoints";

    private List<Transform> _pointsToSpawn;

    [SerializeField] private List<GameObject> _prefabsOfTypesEnemyWave1;
    [SerializeField] private List<int> _countForeachTypeOfEnemyWave1;

    [SerializeField] private List<GameObject> _prefabsOfTypesEnemyWave2;
    [SerializeField] private List<int> _countForeachTypeOfEnemyWave2;

    [SerializeField] private List<GameObject> _prefabsOfTypesEnemyWave3;
    [SerializeField] private List<int> _countForeachTypeOfEnemyWave3;


    public void Initialize()
    {
         _prefabsOfTypesEnemyWave1 = new List<GameObject>();
       _countForeachTypeOfEnemyWave1 = new List<int>();

        _prefabsOfTypesEnemyWave2 = new List<GameObject>();
        _countForeachTypeOfEnemyWave2 = new List<int>();

        _prefabsOfTypesEnemyWave3 = new List<GameObject>();
        _countForeachTypeOfEnemyWave3 = new List<int>();

        for (int i = 0; i < ; i++)
        {

        }


        GameObject parentOfSpawnPoints = GameObject.FindGameObjectWithTag(_tagToSearch);

        for (int i = 0; i < parentOfSpawnPoints.transform.childCount; i++)
        {
            _pointsToSpawn.Add(parentOfSpawnPoints.transform.GetChild(i));
        }
    }



}
