using Assets.Code.Infrastructure.Services;

namespace Assets.Code.Level.Factories
{
    public interface IStageFactory
    {
        void Create();
        void Initialize();
    }
}