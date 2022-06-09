using System.Collections.Generic;
using UnityEngine;

namespace Assets.Code.Level
{
    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/StageDataScriptableObject", order = 1)]
    public class StageData : ScriptableObject
    {
        [SerializeField] private List<Wave> _waves = new List<Wave>();
        [SerializeField] private GameObject _stageMapPrefab;
        [SerializeField] private GameObject _heroPrefab;
        [SerializeField] private GameObject _heroCanvasPrefab;
        [SerializeField] private GameObject _heroWeaponPrefab;
        [SerializeField] private GameObject _mainCanvasPrefab;
        [SerializeField] private GameObject _mainCameraPrefab;
        
        public GameObject StageMapPrefab { get; private set; }
        public GameObject HeroPrefab { get; private set; }
        public GameObject HeroCanvasPrefab { get; private set; }
        public GameObject HeroWeaponPrefab { get; private set; }
        public GameObject MainCanvasPrefab { get; private set; }
        public GameObject MainCameraPrefab { get; private set; }

        public List<Wave> GetAllWaves() => _waves;

        public Wave GetWave(int numberOfWave)
        {
            if (numberOfWave < _waves.Count)
                return _waves[numberOfWave];
            else
                return null;
        }
    }
}