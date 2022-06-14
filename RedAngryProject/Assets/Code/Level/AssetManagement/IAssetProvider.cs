using Assets.Code.Infrastructure.Services;
using UnityEngine;

namespace Assets.Code.Level.AssetManagement
{
    public interface IAsset : IService
    {
        GameObject Instantiate(string path);
        GameObject Instantiate(string path, Vector3 at);
    }
}

