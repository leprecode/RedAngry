using UnityEngine;

namespace Assets.Code.Enemies
{
    public class EnemyBehaviourAggresive : IEnemyBehaviour
    {
        private Transform _target;
        private Transform _myTransform;
        private float _rotationSpeed;
        private float _movementSpeed;
        public float _damage;

        public EnemyBehaviourAggresive(Transform transform, float rotationSpeed, float movementSpeed)
        {
            _myTransform = transform;
            _rotationSpeed = rotationSpeed;
            _movementSpeed = movementSpeed;
        }

        public void Enter()
        {
            Debug.Log("EnterEnemyBehaviourAggresive");
            _target = GameObject.FindGameObjectWithTag("Player").transform;
        }

        public void Exit()
        {
            Debug.Log("ExitEnemyBehaviourAggresive");
        }

        public void Update()
        {
            Debug.Log("UpdateEnemyBehaviourAggresive");

            FollowPlayer();
        }

        public void FollowPlayer()
        {
            _myTransform.rotation = Quaternion.Slerp(_myTransform.rotation,
            Quaternion.LookRotation(_target.position - _myTransform.position), _rotationSpeed * Time.fixedDeltaTime);

            _myTransform.position += _myTransform.forward * _movementSpeed * Time.fixedDeltaTime;
        }
    }
}