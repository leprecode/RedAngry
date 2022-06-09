using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Code.PlayerLogic
{
    public class PlayerCanvasFollower : MonoBehaviour
    {
        private Transform _player;
        private Camera _camera;
        [SerializeField] private Vector3 _offsetY = new Vector3(0,0,0);

        private void Start()
        {
            _player = FindObjectOfType<Player>().gameObject.transform;
            _camera = Camera.main;
        }

        private void LateUpdate()
        {
            transform.position = _player.position + _offsetY;
            transform.LookAt(transform.position + _camera.transform.forward);
        }
    }
}