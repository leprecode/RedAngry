using Assets.Code.PlayerLogic;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Code.Weapon
{
    public class WeaponMover : MonoBehaviour
    {
        private Transform _target;

        private void Start()
        {
            _target = GameObject.FindGameObjectWithTag("Player").transform;
        }

        private void LateUpdate()
        {
            transform.position = _target.position;
        }
    }
}