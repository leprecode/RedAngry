using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private float _damage;

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Enemy"))
        {
            if (other.transform.TryGetComponent<IDamagable>(out IDamagable damagable))
            {
                damagable.ApplyDamage(_damage);
            }

        }
    }
}
