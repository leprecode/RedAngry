using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyedEnemy : MonoBehaviour
{
    [SerializeField] ParticleSystem _onDestroyVFX;
    private const float _timeToDestroyOffset = 2.0f;
    private float _timeToDestroy => _onDestroyVFX.main.duration + _timeToDestroyOffset;


    private void Start()
    {
        _onDestroyVFX.Play();
        Destroy(this.gameObject,_timeToDestroy);
    }
}
