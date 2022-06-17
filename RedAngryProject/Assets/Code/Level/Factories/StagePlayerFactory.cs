using Assets.Code.Level;
using UnityEngine;

namespace Assets.Code.Level.Factories
{
    public class StagePlayerFactory : IStageFactory
    {
        private const string tagPlayerSpawnPoint = "PlayerSpawnPoint";
        private Transform _spawnPoint;
        public GameObject player { get; private set; }

        public StagePlayerFactory()
        {
        }

        public void Create()
        {
            _spawnPoint = GameObject.FindGameObjectWithTag(tagPlayerSpawnPoint).transform;

            Debug.Log("StagePlayerFactory");

            CameraCreate();
            PlayerCreate(_spawnPoint.position);
            PlayerWeaponCreate(_spawnPoint.position);
            PlayerCanvasCreate();
        }


        private void PlayerCreate(Vector3 at)
        {
            player = _assets.Instantiate(AssetsPath.PlayerPath, at);
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