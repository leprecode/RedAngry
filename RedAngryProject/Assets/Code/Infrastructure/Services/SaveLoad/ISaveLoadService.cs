using Assets.Code.Data;

namespace Assets.Code.Infrastructure.Services.SaveLoad
{
    public interface ISaveLoadService : IService
    {
        PlayerProgress LoadProgress();
        void SaveProgress();
    }
}

