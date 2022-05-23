using UnityEngine;

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
        Destroy(this.gameObject);
    }
}
