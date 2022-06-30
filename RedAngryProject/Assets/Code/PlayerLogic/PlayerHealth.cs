﻿using Assets.Code.Enemies;
using UnityEngine;

namespace Assets.Code.PlayerLogic
{
    public class PlayerHealth : MonoBehaviour, IDamagable, IHealable
    {
        public delegate void OnHealthChanged(float currentHealth, float takedDamage);
        public delegate void OnDie();

        public event OnHealthChanged OnDamage;
        public event OnHealthChanged OnHeal;
        public event OnDie OnPlayerDie;

        //onDie event ??

        public float _currentHealth { get; private set; }

        public float MaxHealth => _maxHealth;

        [SerializeField] private float _maxHealth;

        private void Awake()
        {
            _currentHealth = _maxHealth;
        }


        public void ApplyDamage(float damage)
        {
            if (damage > 0)
            {
                _currentHealth -= damage;

                OnDamage?.Invoke(_currentHealth, damage);
                CheckHealth();
            }
        }

        public void CheckHealth()
        {
            if (_currentHealth <= 0)
                Die();
        }

        public void Heal(float value)
        {
            var previousHealth = value;

            if (value > 0)
                _currentHealth += value;

            if (_currentHealth > _maxHealth)
                _currentHealth = _maxHealth;

            //repair delegate
            OnHeal?.Invoke(_currentHealth, 0f);
        }

        private void Die()
        {
            OnPlayerDie?.Invoke();
            //Destroy(gameObject);
        }
    }
} 