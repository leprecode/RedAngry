namespace Assets.Code.Infrastructure.GameStates
{
    public interface IGameState : IExitableGameState
    {
        void Enter();
    }

    public interface IExitableGameState
    {
        void Exit();
    }
    
    public interface IPayloadedGameState<TPayload> : IExitableGameState
    {
        void Enter(TPayload payload);
    }
}

 