using Assets.Code.Data;

namespace Assets.Code.Infrastructure.Services.Progress
{
    public interface IPersistentProgressService : IService
    {
        public PlayerProgress Progress { get; set; }
    }
}