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

        public GameObject StageMapPrefab => _stageMapPrefab;
        public GameObject HeroPrefab => _heroPrefab;
        public GameObject HeroCanvasPrefab => _heroCanvasPrefab;
        public GameObject HeroWeaponPrefab => _heroWeaponPrefab;
        public GameObject MainCanvasPrefab => _mainCanvasPrefab;
        public GameObject MainCameraPrefab => _mainCameraPrefab;

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