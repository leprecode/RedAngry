using Assets.Code.Infrastructure.Services;
using Assets.Code.Level.Identificators;
using UnityEngine;

namespace Assets.Code.Level.Factories
{
    public class StageMapFactory : IStageFactory, IService
    {
        private readonly GameObject _stageMapPrefab;
        public PlayerSpawnPoint spawnPointForPlayer { get; private set; }

        public StageMapFactory(GameObject stageMapPrefab)
        {
            _stageMapPrefab = stageMapPrefab;

            CreateMap();
        }

        private void CreateMap()
        {
            Object.Instantiate(_stageMapPrefab, new Vector3(0, 0, 0), Quaternion.identity);

            spawnPointForPlayer = GameObject.FindObjectOfType<PlayerSpawnPoint>();

            Debug.Log("MapCreated");

            if (spawnPointForPlayer != null)
            {
                Debug.Log("MapCreatedWithNoNull");

            }
        }
    }
}