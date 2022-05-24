using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private CharacterController _characterController;
    [SerializeField] private float _movementSpeed;
    private Camera _camera;
    Vector3 movementVector;
    Vector3 lastMovementVector;

    private void Awake()
    {
        _camera = Camera.main;
    }

    private void Start()
    {
        CameraFollow();
    }

    private void Update()
    {
        movementVector = Vector3.zero;

        movementVector.x = SimpleInput.GetAxis("Horizontal");
        movementVector.z = SimpleInput.GetAxis("Vertical");

        if (movementVector.x != 0 && movementVector.z != 0)
        {
            lastMovementVector = new Vector3(movementVector.x, 0, movementVector.z);
            transform.forward = movementVector;
        }
        else
        {
            transform.forward = lastMovementVector;
        }

        movementVector.y += Physics.gravity.y;


    }

    private void FixedUpdate()
    {
        _characterController.Move(_movementSpeed * movementVector * Time.fixedDeltaTime);
    }

    private void CameraFollow() =>
    _camera.GetComponent<CameraFollow>().Follow(this.gameObject);
}

