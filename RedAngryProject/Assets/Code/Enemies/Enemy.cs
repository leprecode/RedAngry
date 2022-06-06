using Assets.Code.Level;
using UnityEditor;
using UnityEngine;

namespace Assets.Code.Enemies
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] public  float _damage;
        [SerializeField] public  float _movementSpeed = 10;
        [SerializeField] public  float _rotationSpeed = 10;
        [SerializeField] public  GameObject _body;
        [SerializeField] public  GameObject _destroyedBody;
        [SerializeField] public  ParticleSystem _onDestroyVFX;
        [SerializeField] public float _health;

        private EnemyStateMachine _stateMachine;
        public StageGameplayState stageGameplayState { get; private set; }

        private void Start()
        {
            _stateMachine = gameObject.AddComponent<EnemyStateMachine>();
            stageGameplayState = (StageGameplayState)FindObjectOfType<Stage>().GetStateMachine.GetState<StageGameplayState>();
        }
    }
}