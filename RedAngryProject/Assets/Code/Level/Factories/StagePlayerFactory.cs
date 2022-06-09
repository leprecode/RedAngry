using UnityEngine;

namespace Assets.Code.Level.Factories
{
    public class StagePlayerFactory : IStageFactory
    {
        private const string tagPlayerSpawnPoint = "PlayerSpawnPoint";

        private readonly GameObject _player;
        private readonly GameObject _weapon;
        private readonly GameObject _playerCanvas;
        private readonly GameObject _mainCamera;

        private Transform _spawnPoint;

        public StagePlayerFactory(GameObject player, GameObject weapon, GameObject playerCanvas, GameObject mainCamera)
        {
            this._player = player;
            this._weapon = weapon;
            this._playerCanvas = playerCanvas;
            this._mainCamera = mainCamera;
        }
        public void Initialize()
        {
        }

        public void Create()
        {
            Debug.Log("StagePlayerFactory");

            _spawnPoint = GameObject.FindGameObjectWithTag(tagPlayerSpawnPoint).transform;


            GameObject player = Object.Instantiate(_player, _spawnPoint.position,Quaternion.identity);
            Object.Instantiate(_weapon, player.transform.position,Quaternion.identity);
            Object.Instantiate(_mainCamera, player.transform.position,Quaternion.identity);
            Object.Instantiate(_playerCanvas, player.transform.position,Quaternion.identity);
        }
    }
}