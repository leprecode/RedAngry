using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private float _damage;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Enemy"))
        {
            if (collision.transform.TryGetComponent<IDamagable>(out IDamagable damagable))
            {
                damagable.ApplyDamage(_damage);
            }

        }
    }
}
