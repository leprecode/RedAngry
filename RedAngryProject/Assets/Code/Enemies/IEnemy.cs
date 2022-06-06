using Assets.Code.Enemies;
using UnityEngine;

public abstract class IEnemy
{
    public float health { get; set; }
    public float movementSpeed { get; set; }
    public float rotationSpeed { get; set; }
    public Transform player { get; set; }
    public EnemyStateMachine brain { get; set; }
    public GameObject body { get; set; }
    public GameObject destroyedBody { get; set; }
    public ParticleSystem onDestroyVFX { get; set; }
}

public abstract class IMeleeEnemy : IEnemy
{
    public float Damage { get; set; }
}

public abstract class IDistantEnemy : IEnemy
{
    public float Damage { get; set; }
}