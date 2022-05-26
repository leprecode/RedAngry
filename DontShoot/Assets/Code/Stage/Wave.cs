using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Wave", menuName = "ScriptableObjects/WaveDataScriptableObject", order = 2)]

public class Wave : ScriptableObject
{
    [SerializeField] private List<GameObject> _prefabsOfTypesEnemyWave = new List<GameObject>();
    [SerializeField] private List<int> _countForeachTypeOfEnemyWave = new List<int>();

    public void GetWave(out List<GameObject> prefabsOfTypesEnemyWave, out List<int> countForeachTypeOfEnemyWave)
    {
        prefabsOfTypesEnemyWave = this._prefabsOfTypesEnemyWave;
        countForeachTypeOfEnemyWave = this._countForeachTypeOfEnemyWave;
    }
}
