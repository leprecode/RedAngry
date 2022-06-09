using UnityEngine;

namespace Assets.Code.Level.Factories
{
    public class StageMapFactory : IStageFactory
    {
        private GameObject _stageMapPrefab;

        public void Create()
        {
            Debug.Log("StageMapFactory");

            Object.Instantiate(_stageMapPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        }

        public void Initialize()
        {
            _stageMapPrefab = Stage.instance.GetStageData.StageMapPrefab;
        }
    }
}