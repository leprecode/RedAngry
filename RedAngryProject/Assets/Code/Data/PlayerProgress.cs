using System;

namespace Assets.Code.Data
{
    [Serializable]
    public class PlayerProgress
    {
        public StageProgress worldData { get; private set; }
        public GameProgress gameProgress { get; private set; }

        public PlayerProgress()
        {
            
        }
    }
} 