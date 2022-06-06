using Assets.Code.Enemies;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Archer : MonoBehaviour, IDamagable
{
    [SerializeField] private GameObject _arrow;

    private Transform _player;
    private float _fireRate = 1f;



    public void ApplyDamage(float damage)
    {
        throw new System.NotImplementedException();
    }

    public void CheckHealth()
    {
        throw new System.NotImplementedException();
    }
}
