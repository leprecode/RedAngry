using Assets.Code.Data;
using UnityEngine;

namespace Assets.Code.Infrastructure.Services.Progress
{
    public class PersistentProgressService : IPersistentProgressService
    {
        public PlayerProgress Progress { get; set; }

    }
}