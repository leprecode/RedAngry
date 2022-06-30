using Sirenix.OdinInspector;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Code.Level
{
    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/StageDataScriptableObject", order = 1)]
    public class StageData : SerializedScriptableObject
    {
        [SerializeField] private List<Wave> _waves = new List<Wave>();
        [SerializeField] private readonly GameObject _stageMapPrefab;
        [SerializeField] private readonly GameObject _playerPrefab;
        [SerializeField] private readonly GameObject _mainCanvasPrefab;
        [SerializeField] private readonly GameObject _healthCanvasPrefab;
        [SerializeField] private readonly GameObject _playerWeaponPrefab;
        [SerializeField] private readonly GameObject _cameraPrefab;
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