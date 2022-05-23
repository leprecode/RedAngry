using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private CharacterController _characterController;
    [SerializeField] private float _movementSpeed;
    private Camera _camera;
    Vector3 movementVector;

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
        Vector3 lastMovementVector;
        movementVector = Vector3.zero;

        movementVector.x = SimpleInput.GetAxis("Horizontal");
        movementVector.z = SimpleInput.GetAxis("Vertical");

        if (movementVector.x != 0 && movementVector.z != 0)
            lastMovementVector = new Vector3(movementVector.x, 0, movementVector.z);
        else
            lastMovementVector = new Vector3(0, 0, 0);
        

        transform.forward = lastMovementVector;

        movementVector.y += Physics.gravity.y;

        
    }

    private void FixedUpdate()
    {
        _characterController.Move(_movementSpeed * movementVector * Time.fixedDeltaTime);
    }

    private void CameraFollow() =>
    _camera.GetComponent<CameraFollow>().Follow(this.gameObject);
}

