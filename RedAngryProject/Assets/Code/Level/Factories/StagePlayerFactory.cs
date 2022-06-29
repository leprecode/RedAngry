using UnityEngine;

namespace Assets.Code.Level.Factories
{
    public class StagePlayerFactory : IStageFactory
    {
        private const string tagPlayerSpawnPoint = "PlayerSpawnPoint";
        private readonly StageData _stageData;
        private Transform _spawnPoint;
        public GameObject player { get; private set; }

        public StagePlayerFactory(StageData stageData, Transform spawnPoint)
        {
            this._stageData = stageData;
            _spawnPoint = spawnPoint;

            CameraCreate();
            PlayerCreate(_spawnPoint.position);
            PlayerWeaponCreate(_spawnPoint.position);
            PlayerCanvasCreate();
        }

        private void PlayerCanvasCreate()
        {
            Object.Instantiate(_stageData.MainCanvasPrefab);
        }

        private void PlayerWeaponCreate(Vector3 position)
        {
            Object.Instantiate(_stageData.PlayerWeaponPrefab, position, Quaternion.identity);

        }

        private void PlayerCreate(Vector3 position)
        {
            Object.Instantiate(_stageData.PlayerPrefab, position, Quaternion.identity);
        }

        private void CameraCreate()
        {
            Object.Instantiate(_stageData.CameraPrefab);
        }
    }
}