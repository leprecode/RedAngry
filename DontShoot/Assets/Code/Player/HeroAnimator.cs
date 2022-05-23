using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HeroAnimator : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private CharacterController _characterController;

    private const string _movingState = "Running";

    private void Update()
    {
        _animator.SetFloat(_movingState, _characterController.velocity.magnitude, 0.1f, Time.deltaTime);
        Debug.Log(_characterController.velocity.magnitude);
    }
}

