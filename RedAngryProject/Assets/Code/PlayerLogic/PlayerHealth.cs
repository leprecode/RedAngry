using Assets.Code.Enemies;
using UnityEngine;

namespace Assets.Code.PlayerLogic
{
    public class PlayerHealth : MonoBehaviour, IDamagable, IHealable
    {
        public delegate void OnHealthChanged(float previousHealth, float currentHealth);
        public delegate void OnDie();

        public event OnHealthChanged OnDamage;
        public event OnHealthChanged OnHeal;
        public event OnDie OnPlayerDie;

        //onDie event ??

        [SerializeField] private float _currentHealth;
        [SerializeField] private readonly float _maxHealth;

        private void Start()
        {
            _currentHealth = _maxHealth;
        }


        public void ApplyDamage(float damage)
        {
            if (damage > 0)
            {
                _currentHealth -= damage;

                OnDamage?.Invoke(_currentHealth, _currentHealth - damage);
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

            OnHeal?.Invoke(_currentHealth, previousHealth);
        }

        private void Die()
        {
            OnPlayerDie?.Invoke();
            //Destroy(gameObject);
        }
    }
} 