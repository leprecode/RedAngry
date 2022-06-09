using Assets.Code.Enemies;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Code.Level
{
    [CreateAssetMenu(fileName = "Wave", menuName = "ScriptableObjects/WaveDataScriptableObject", order = 2)]

    public class Wave : ScriptableObject
    {
        [SerializeField] private List<GameObject> _prefabsOfTypesEnemyWave = new List<GameObject>();
        [SerializeField] private List<int> _countForeachTypeOfEnemyWave = new List<int>();

        public List<GameObject> GetWaveEnemiesTypes() => _prefabsOfTypesEnemyWave;

        public List<int> GetWaveEnemiesCount() => _countForeachTypeOfEnemyWave;

    }
}