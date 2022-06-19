using Assets.Code.Infrastructure.Services;
using UnityEngine;

namespace Assets.Code.Level.Factories
{
    public class StageMapFactory : IStageFactory, IService
    {
        private readonly GameObject _stageMapPrefab;

        public StageMapFactory(GameObject stageMapPrefab)
        {
            _stageMapPrefab = stageMapPrefab;

            CreateMap();
        }

        private void CreateMap()
        {
            Object.Instantiate(_stageMapPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        }

        public void Create()
        {
            Debug.Log("StageMapFactory");
        }
    }
}