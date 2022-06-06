using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Code.Weapon
{
    public class WeaponMover : MonoBehaviour
    {
        [SerializeField] private Transform _target;


        private void LateUpdate()
        {
            transform.position = _target.position;
        }
    }
}