using Assets.Code.Enemies;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Code.Weapon
{
    public class Weapon : MonoBehaviour
    {
        [SerializeField] private float _damage;

        private void OnTriggerEnter(Collider other)
        {
            if (other.transform.CompareTag("Enemy"))
            {
                if (other.transform.TryGetComponent(out IDamagable damagable))
                {
                    damagable.ApplyDamage(_damage);
                }

            }
        }
    }
}