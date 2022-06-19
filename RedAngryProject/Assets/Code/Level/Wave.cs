using Assets.Code.Enemies;
using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Code.Level
{
    [CreateAssetMenu(fileName = "Wave", menuName = "ScriptableObjects/WaveDataScriptableObject", order = 2)]

    public class Wave : SerializedScriptableObject
    {
        [SerializeField] private Dictionary<GameObject, int> _enemies = new Dictionary<GameObject, int>();

        public Dictionary<GameObject, int> Enemies => _enemies;
    }
}