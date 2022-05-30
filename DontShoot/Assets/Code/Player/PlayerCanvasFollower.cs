using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Code.Player
{
    public class PlayerCanvasFollower : MonoBehaviour
    {
        private Transform _player;

        private void Awake()
        {
            _player = FindObjectOfType<Player>().gameObject.transform;
        }

        private void LateUpdate()
        {
            transform.position = _player.position;
        }
    }
}