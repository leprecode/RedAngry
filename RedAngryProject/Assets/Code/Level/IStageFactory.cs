using UnityEngine;

namespace Assets.Code.Level
{
    public interface IStageFactory
    {
        void Create();
        void Initialize();
    }
    public class StageMapFactory : IStageFactory
    {
        public void Create()
        {
            Debug.Log("StageMapFactory");
        }

        public void Initialize()
        {
        }
    }

    public class StagePlayerFactory : IStageFactory
    {
        public void Create()
        {
            Debug.Log("StagePlayerFactory");
        }

        public void Initialize()
        {
        }
    }
}