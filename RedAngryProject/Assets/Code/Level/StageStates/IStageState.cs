namespace Assets.Code.Level.StageStates
{
    public interface IStageState
    {
        void Enter();
        void Exit();
        void Update();
    }
}