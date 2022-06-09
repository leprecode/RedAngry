using UnityEngine;

namespace Assets.Code.Level.Factories
{
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