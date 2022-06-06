using System.Collections.Generic;
using UnityEngine;

namespace Assets.Code.Level
{
    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/StageDataScriptableObject", order = 1)]
    public class StageData : ScriptableObject
    {
        [SerializeField] private int _pauseBetweenWaves;
        [SerializeField] private List<Wave> _waves = new List<Wave>();

        public List<Wave> GetAllWaves() => _waves;

        public Wave GetWave(int numberOfWave)
        {
            if (numberOfWave < _waves.Count)
                return _waves[numberOfWave];
            else
                return null;
        }

        public int GetWavePause() => _pauseBetweenWaves;
    }
}