using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/StageDataScriptableObject", order = 1)]
public class StageData : ScriptableObject
{
    [SerializeField] private int _pauseBetweenWaves;
    [SerializeField] private List<Wave> _waves = new List<Wave>();


    public int GetWavePause()
    {
        return _pauseBetweenWaves;
    }
}
