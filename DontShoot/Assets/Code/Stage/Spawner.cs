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


    public void Initialize(List<Wave> waves)
    {
        GetWaves(waves);

        GetSpawnPoints();
    }

    private void GetSpawnPoints()
    {
        GameObject parentOfSpawnPoints = GameObject.FindGameObjectWithTag(_tagToSearch);

        for (int i = 0; i < parentOfSpawnPoints.transform.childCount; i++)
        {
            _pointsToSpawn.Add(parentOfSpawnPoints.transform.GetChild(i));
        }
    }

    private void GetWaves(List<Wave> waves)
    {
        switch (waves.Count)
        {
            case 1:
                _prefabsOfTypesEnemyWave1 = new List<GameObject>();
                _countForeachTypeOfEnemyWave1 = new List<int>();

                this._prefabsOfTypesEnemyWave1 = waves[0].GetWaveEnemiesTypes();
                this._countForeachTypeOfEnemyWave1 = waves[0].GetWaveEnemiesCount();
                break;

            case 2:
                _prefabsOfTypesEnemyWave2 = new List<GameObject>();
                _countForeachTypeOfEnemyWave2 = new List<int>();

                this._prefabsOfTypesEnemyWave2 = waves[1].GetWaveEnemiesTypes();
                this._countForeachTypeOfEnemyWave2 = waves[1].GetWaveEnemiesCount();
                break;

            case 3:
                _prefabsOfTypesEnemyWave3 = new List<GameObject>();
                _countForeachTypeOfEnemyWave3 = new List<int>();

                this._prefabsOfTypesEnemyWave3 = waves[2].GetWaveEnemiesTypes();
                this._countForeachTypeOfEnemyWave3 = waves[2].GetWaveEnemiesCount();
                break;

            default:
                Debug.LogError("Waves count was unexpected");
                break;
        }
    }
}
