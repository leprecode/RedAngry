using Assets.Code.Infrastructure.Services;
using UnityEngine;

namespace Assets.Code.Level.Factories
{
    public class StageMapFactory : IStageFactory, IService
    {
        private GameObject _stageMapPrefab;

        public void Create()
        {
            Debug.Log("StageMapFactory");

            Object.Instantiate(_stageMapPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        }

        public void Initialize()
        {
            _stageMapPrefab = Stage.instance.StageData.StageMapPrefab;
        }
    }
}