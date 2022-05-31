using UnityEngine;

namespace Assets.Code.Infrastructure
{
    public interface IGameState
    {
        void Enter();
        void Exit();
    }

    public class GameBootstrapState : IGameState
    {
        public void Enter()
        {
            Debug.Log("Bootsrap enter!");
        }

        public void Exit()
        {
        }
    }
}

 