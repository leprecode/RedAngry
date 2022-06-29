using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Code.Level
{
    public class EnemyWatcher : IWatcher
    {
        public delegate void AllEnemiesDestroyed();
        public event AllEnemiesDestroyed AllEnemyWereDestroyed;

        public static EnemyWatcher instance { get; private set; }
        private static List<GameObject> _allEnemies;

        public EnemyWatcher(List<GameObject> allEnemies)
        {
            _allEnemies = allEnemies;
            MakeStaticInstacne();
        }

        public void Watch()
        {
        }

        public static void EnemyDestroyed(GameObject enemy)
        {
            _allEnemies.Remove(enemy);

            CheckEnemyCount();
        }

        private static void CheckEnemyCount()
        {
            if (_allEnemies.Count == 0)
            {
                EnemyWatcher.instance.AllEnemyWereDestroyed?.Invoke();
            }
        }

        private void MakeStaticInstacne()
        {
            if (instance == null)
            {
                instance = this;
            }
        }
    }
}