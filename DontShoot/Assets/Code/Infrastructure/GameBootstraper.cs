using UnityEditor;
using UnityEngine;

namespace Assets.Code.Infrastructure
{
    public class GameBootstraper : MonoBehaviour
    {
        private Game _game;

        private void Awake()
        {
            _game = new Game();
            _game.StateMachine.Enter<GameBootstrapState>();

            DontDestroyOnLoad(this);
        }
    }
}