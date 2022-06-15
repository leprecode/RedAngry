using Assets.Code.Infrastructure.GameStates;
using Assets.Code.Infrastructure.Services;
using UnityEngine;

namespace Assets.Code.Infrastructure
{
    public class Game
    {
        public GameStateMachine StateMachine;

        public Game(ICoroutineRunner coroutineRunner)
        {
            StateMachine = new GameStateMachine(new SceneLoader(coroutineRunner), AllServices.Container);
        }
    }
}

