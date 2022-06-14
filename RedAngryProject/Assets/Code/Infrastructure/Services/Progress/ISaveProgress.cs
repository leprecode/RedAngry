using Assets.Code.Data;

namespace Assets.Code.PlayerLogic
{
    public interface ISaveProgressReader
    {
        void LoadProgress(PlayerProgress playerProgress);
    }

    public interface ISaveProgress : ISaveProgressReader
    {
        void UpdateProgress(PlayerProgress playerProgress);

    }
}