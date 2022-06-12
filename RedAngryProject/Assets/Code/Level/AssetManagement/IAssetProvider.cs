using UnityEngine;

namespace Assets.Code.Level.AssetManagement
{
    public interface IAsset
    {
        GameObject Instantiate(string path);
        GameObject Instantiate(string path, Vector3 at);
    }
}

