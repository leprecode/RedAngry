using UnityEngine;

namespace Assets.Code.Level
{
    public class PlayerWatcher : IWatcher
    {
        private readonly GameObject _player;
        public static PlayerWatcher instance { get; private set; }

        public delegate void PlayerWasDestroyed();
        public event PlayerWasDestroyed PlayerDestroyed;

        public PlayerWatcher(GameObject player)
        {
            _player = player;
        }

        public void Watch()
        {
        }

        private void MakeStaticInstacne()
        {
            if (instance == null)
            {
                instance = this;
            }
        }
    }
}