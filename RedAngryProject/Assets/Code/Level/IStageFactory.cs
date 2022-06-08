using System.Collections;
using UnityEngine;

namespace Assets.Code.Level
{
    public interface IStageFactory
    {
        void Create();
    }
    public class StageMapFactory : IStageFactory
    {
        public void Create()
        {
        }
    }

    public class StageEnemyFactory : IStageFactory
    {
        public void Create()
        {
        }
    }

    public class StagePlayerFactory : IStageFactory
    {
        public void Create()
        {
        }
    }
}