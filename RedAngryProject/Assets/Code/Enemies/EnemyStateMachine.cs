using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Code.Enemies
{
    public class EnemyStateMachine : MonoBehaviour, IDamagable
    {
        private Enemy _enemy;
        private Dictionary<Type, IEnemyBehaviour> _behaviours;
        private IEnemyBehaviour _currentBehaviour;

        private void Start()
        {
            _enemy = GetComponent<Enemy>();

            InitializeBehaviours();
            SetBehaviourByDefault();
        }

        private void Update()
        {
            _currentBehaviour.Update();
        }

        private void InitializeBehaviours()
        {
            _behaviours = new Dictionary<Type, IEnemyBehaviour>();

            _behaviours[typeof(EnemyBehaviourAggresive)] = new EnemyBehaviourAggresive(transform, _enemy._rotationSpeed, _enemy._movementSpeed);
            _behaviours[typeof(EnemyBehaviourDeadly)] = new EnemyBehaviourDeadly(gameObject, _enemy._body, _enemy._destroyedBody, _enemy._onDestroyVFX);
        }

        private void SetBehaviour(IEnemyBehaviour newBehaviour)
        {
            _currentBehaviour?.Exit();

            _currentBehaviour = newBehaviour;
            _currentBehaviour.Enter();
        }

        private IEnemyBehaviour GetBehaviour<T>() where T : IEnemyBehaviour
        {
            var type = typeof(T);
            return _behaviours[type];
        }

        private void SetBehaviourByDefault()
        {
            var behaviourByDefault = GetBehaviour<EnemyBehaviourAggresive>();
            SetBehaviour(behaviourByDefault);
        }

        public void ApplyDamage(float damage)
        {
            _enemy._health -= damage;

            CheckHealth();
        }

        public void CheckHealth()
        {
            if (_enemy._health <= 0)
            {
                SetBehaviour(GetBehaviour<EnemyBehaviourDeadly>());
            }
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                Debug.Log("Player Damaged " + _enemy._damage);
                collision.gameObject.GetComponent<IDamagable>().ApplyDamage(_enemy._damage);
            }
        }
    }
}