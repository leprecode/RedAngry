using Assets.Code.Level.Factories;
using Assets.Code.Level.StageStates;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Code.Level
{
    public class StageGameplayState : IStageState
    {
        private readonly StageStateMachine _stageStateMachine;
        
        private EnemyWatcher _enemyWatcher;
        private PlayerWatcher _playerWatcher;

        public StageGameplayState(StageStateMachine stageStateMachine)
        {
            this._stageStateMachine = stageStateMachine;
        }

        public void Enter()
        {
            Debug.Log("EnterGameplayState");

            InitialWatchers();
        }

        private GameObject GetPlayer()
        {
            var factory = (StagePlayerFactory)_stageStateMachine.GetStageBootstrapState().GetFactory<StagePlayerFactory>();
            var player = factory.player;
            return player;
        }

        public void Exit()
        {
        }

        public void Update()
        {
            Debug.Log("StageGameplayState");
        }

        private List<GameObject> GetAllEnemies()
        {
            var allEnemies = new List<GameObject>();
            var enemyFactory = (StageEnemyFactory)_stageStateMachine.GetStageBootstrapState().GetFactory<StageEnemyFactory>();
            
            allEnemies = enemyFactory.AllEnemies;
            return allEnemies;
        }

        private void InitialWatchers()
        {
            _enemyWatcher = new EnemyWatcher(GetAllEnemies());
            _playerWatcher = new PlayerWatcher(GetPlayer());
        }
    }
}

public interface IWatcher
{
    void Watch();
}

public class EnemyWatcher : IWatcher
{
    private readonly List<GameObject> _allEnemies;

    public EnemyWatcher(List<GameObject> allEnemies)
    {
        this._allEnemies = allEnemies;
    }

    public void Watch()
    {
    }
}

public class PlayerWatcher : IWatcher
{
    private readonly GameObject _player;

    public PlayerWatcher(GameObject player)
    {
        this._player = player;
    }

    public void Watch()
    {
    }
}