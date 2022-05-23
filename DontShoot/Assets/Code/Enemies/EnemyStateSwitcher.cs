using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateSwitcher : MonoBehaviour, IDamagable
{
    [SerializeField] private float _health;
    [SerializeField] private float _damage;

    [SerializeField] private float _movementSpeed = 10;
    [SerializeField] private float _rotationSpeed = 10;

    [SerializeField] private GameObject _body;
    [SerializeField] private GameObject _destroyedBody;
    [SerializeField] private ParticleSystem _onDestroyVFX;

    private Dictionary<Type, IEnemyBehaviour> _behaviours;
    private IEnemyBehaviour _currentBehaviour;
        
    private void Start()
    {
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

        _behaviours[typeof(EnemyBehaviourAggresive)] = new EnemyBehaviourAggresive(transform,_rotationSpeed,_movementSpeed);
        _behaviours[typeof(EnemyBehaviourDeadly)] = new EnemyBehaviourDeadly(gameObject, _body, _destroyedBody, _onDestroyVFX);
    }

    private void SetBehaviour(IEnemyBehaviour newBehaviour)
    {
        if (_currentBehaviour != null)
            _currentBehaviour.Exit();

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
        _health -= damage;

        CheckHealth();
    }

    public void CheckHealth()
    {
        if (_health <= 0)
        {
            SetBehaviour(GetBehaviour<EnemyBehaviourDeadly>());
        }
    }



    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<IDamagable>().ApplyDamage(_damage);
        }
    }

    public void Die()
    {
    }
}
