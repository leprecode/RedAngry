using Assets.Code.Level;
using UnityEditor;
using UnityEngine;

namespace Assets.Code.Enemies
{
    public class Enemy : MonoBehaviour, IEnemy
    {
        //все данные и основное поведение(для всех енеми) из стейт машины вынести сюда
        //remove
        [SerializeField] public  float _damage;
        [SerializeField] public  float _movementSpeed = 10;
        [SerializeField] public  float _rotationSpeed = 10;
        [SerializeField] public  GameObject _body;
        [SerializeField] public  GameObject _destroyedBody;
        [SerializeField] public  ParticleSystem _onDestroyVFX;
        [SerializeField] public float _health;

        private EnemyStateMachine _stateMachine;
        public StageGameplayState stageGameplayState { get; private set; }
        public float health { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public float movementSpeed { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public float rotationSpeed { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public Transform player { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public EnemyStateMachine brain { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public GameObject body { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public GameObject destroyedBody { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public ParticleSystem onDestroyVFX { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

        private void Start()
        {
            _stateMachine = gameObject.AddComponent<EnemyStateMachine>();
        }
    }
}