using Assets.Code.Level.AssetManagement;
using UnityEngine;

namespace Assets.Code.Level.Factories
{
    public class StagePlayerFactory : IStageFactory
    {
        private const string tagPlayerSpawnPoint = "PlayerSpawnPoint";
        private Transform _spawnPoint;
        private readonly IAsset _assets;

        public StagePlayerFactory(IAsset assets)
        {
            this._assets = assets;
        }
        public void Initialize()
        {
            _spawnPoint = GameObject.FindGameObjectWithTag(tagPlayerSpawnPoint).transform;
        }

        public void Create()
        {
            Debug.Log("StagePlayerFactory");

            CameraCreate();
            PlayerCreate(_spawnPoint.position);
            PlayerWeaponCreate(_spawnPoint.position);
            PlayerCanvasCreate();
        }


        private void PlayerCreate(Vector3 at)
        {
            _assets.Instantiate(AssetsPath.PlayerPath, at);
        }        
        private void CameraCreate()
        {
            _assets.Instantiate(AssetsPath.MainCameraPath);
        }
        private void MainCanvasCreate()
        {
            _assets.Instantiate(AssetsPath.MainCanvasPath);
        }
        private void PlayerCanvasCreate()
        {
            _assets.Instantiate(AssetsPath.PlayerCanvasPath);
        }
        private void PlayerWeaponCreate(Vector3 at)
        {
            _assets.Instantiate(AssetsPath.PlayerCanvasPath, at);
        }
    }
}