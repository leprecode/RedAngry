﻿using Assets.Code.Data;

namespace Assets.Code.Infrastructure.Services.Progress
{
    public interface IPersistentProgressService : IService
    {
        PlayerProgress Progress { get; set; }
    }
}