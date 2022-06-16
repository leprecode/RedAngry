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
        private List<GameObject> _allEnemies;

        public StageGameplayState(StageStateMachine stageStateMachine)
        {
            this._stageStateMachine = stageStateMachine;
        }

        public void Enter()
        {
            Debug.Log("EnterGameplayState");

            GetAllEnemies();
        }

        public void Exit()
        {
        }

        public void Update()
        {
            Debug.Log("StageGameplayState");
        }

        private void GetAllEnemies()
        {
            _allEnemies = new List<GameObject>();
            var enemyFactory = (StageEnemyFactory)_stageStateMachine.GetStageBootstrapState().GetFactory<StageEnemyFactory>();
            _allEnemies = enemyFactory.AllEnemies;
        }
    }
}

public interface IWatcher
{
    void Watch();
}

public class EnemyWatcher : IWatcher
{
    public void Watch()
    {
    }
}

public class PlayerWatcher : IWatcher
{
    public void Watch()
    {
    }
}