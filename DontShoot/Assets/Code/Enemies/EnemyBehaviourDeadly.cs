using UnityEngine;

public class EnemyBehaviourDeadly : IEnemyBehaviour
{
    private GameObject _thisGameObject;
    private GameObject _body;
    private GameObject _destroyedBody;
    private ParticleSystem _onDestroyVFX;
    private float _timeToDestroy => _onDestroyVFX.duration;

    public EnemyBehaviourDeadly(GameObject thisGameObject,GameObject body, GameObject destroyedBody, ParticleSystem onDestroyVFX)
    {
        _thisGameObject = thisGameObject;
        _destroyedBody = destroyedBody;
        _onDestroyVFX = onDestroyVFX;
        _body = body;
    }

    public void Die()
    {
        GameObject.Destroy(_body);
        GameObject destroyed = GameObject.Instantiate(_destroyedBody,_thisGameObject.transform.position, _thisGameObject.transform.rotation);
        GameObject.Destroy(_thisGameObject,_timeToDestroy);
    }

    public void Enter()
    {
        Debug.Log("EnterEnemyBehaviourDeadly");

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
