using System.Collections.Generic;
using UnityEngine;

namespace Assets.Code.Level
{
    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/StageDataScriptableObject", order = 1)]
    public class StageData : ScriptableObject
    {
        [SerializeField] private List<Wave> _waves = new List<Wave>();
        [SerializeField] private GameObject _stageMapPrefab;
        [SerializeField] private GameObject _playerPrefab;
        [SerializeField] private GameObject _mainCanvasPrefab;
        [SerializeField] private GameObject _playerWeaponPrefab;
        [SerializeField] private GameObject _cameraPrefab;

        public List<Wave> GetAllWaves() => _waves;
        public GameObject StageMapPrefab => _stageMapPrefab;

        public GameObject PlayerPrefab => _playerPrefab;

        public GameObject MainCanvasPrefab => _mainCanvasPrefab;

        public GameObject PlayerWeaponPrefab => _playerWeaponPrefab;

        public GameObject CameraPrefab => _cameraPrefab;

        public Wave GetWave(int numberOfWave)
        {
            if (numberOfWave < _waves.Count)
                return _waves[numberOfWave];
            else
                return null;
        }
    }
}