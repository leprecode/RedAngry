using System.Collections;
using UnityEditor;
using UnityEngine;

namespace Assets.Code.Infrastructure
{
    public class GameEntryPoint : MonoBehaviour, ICoroutineRunner
    {
        private Game _game;

        private void Awake()
        {
            _game = new Game(this);
            _game.StateMachine.Enter<GameBootstrapState>();

            DontDestroyOnLoad(this);
        }
    }
}