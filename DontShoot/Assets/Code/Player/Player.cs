using Assets.Code.Enemies;
using UnityEngine;

namespace Assets.Code.Player
{
    public class Player : MonoBehaviour, IDamagable
    {
        [SerializeField] private float _health;

        public void ApplyDamage(float damage)
        {
            _health -= damage;

            CheckHealth();
        }

        public void CheckHealth()
        {
            if (_health <= 0)
                Die();
        }

        public void Die()
        {
            Destroy(gameObject);
        }
    }
}