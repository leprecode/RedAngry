using System.Collections.Generic;
using UnityEngine;

namespace Assets.Code.Level
{
    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/StageDataScriptableObject", order = 1)]
    public class StageData : ScriptableObject
    {
        [SerializeField] private List<Wave> _waves = new List<Wave>();
        [SerializeField] private GameObject _stageMapPrefab;

        public List<Wave> GetAllWaves() => _waves;
        public GameObject StageMapPrefab => _stageMapPrefab;
        public Wave GetWave(int numberOfWave)
        {
            if (numberOfWave < _waves.Count)
                return _waves[numberOfWave];
            else
                return null;
        }
    }
}