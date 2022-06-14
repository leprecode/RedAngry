using Assets.Code.Infrastructure.Services;

namespace Assets.Code.Level.Factories
{
    public interface IStageFactory : IService
    {
        void Create();
        void Initialize();
    }
}