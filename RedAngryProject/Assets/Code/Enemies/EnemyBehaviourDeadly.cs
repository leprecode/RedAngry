using UnityEngine;

namespace Assets.Code.Enemies
{
    public class EnemyBehaviourDeadly : IEnemyBehaviour
    {
        private GameObject _thisGameObject;
        private GameObject _body;
        private GameObject _destroyedBody;
        private ParticleSystem _onDestroyVFX;
        private float _timeToDestroy => _onDestroyVFX.main.duration;

        public EnemyBehaviourDeadly(GameObject thisGameObject, GameObject body, GameObject destroyedBody, ParticleSystem onDestroyVFX)
        {
            _thisGameObject = thisGameObject;
            _destroyedBody = destroyedBody;
            _onDestroyVFX = onDestroyVFX;
            _body = body;
        }

        public void Die()
        {
            Object.Destroy(_body);
            GameObject destroyed = Object.Instantiate(_destroyedBody, _thisGameObject.transform.position, _thisGameObject.transform.rotation);
            Object.Destroy(_thisGameObject, _timeToDestroy);
        }

        public void Enter()
        {
/*            _thisGameObject.GetComponent<Enemy>().stageGameplayState.EnemyDestroyed();*/
            Die();
        }

        public void Exit()
        {
            Debug.Log("ExitEnemyBehaviourDeadly");
        }

        public void Update()
        {
            Debug.Log("UpdateEnemyBehaviourDeadly");
        }
    }
}