namespace Assets.Code.Level
{
    public interface IStageState
    {
        void Enter();
        void Exit();
        void Update();
    }
}