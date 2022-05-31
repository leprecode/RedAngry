using System.Collections;
using UnityEditor;
using UnityEngine;

namespace Assets.Code.Infrastructure
{
    public class GameBootstraper : MonoBehaviour, ICoroutineRunner
    {
        private Game _game;

        public Coroutine StartCoroutine(IEnumerator coroutine)
        {
            throw new System.NotImplementedException();
        }

        private void Awake()
        {
            _game = new Game(this);
            _game.StateMachine.Enter<GameBootstrapState>();

            DontDestroyOnLoad(this);
        }
    }
}