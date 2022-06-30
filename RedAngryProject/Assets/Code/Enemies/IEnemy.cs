using Assets.Code.Enemies;
using UnityEngine;

public interface IEnemy
{
/*    public float health { get; set; }
    public float movementSpeed { get; set; }
    public float rotationSpeed { get; set; }
    public Transform player { get; set; }
    public EnemyStateMachine brain { get; set; }
    public GameObject body { get; set; }
    public GameObject destroyedBody { get; set; }
    public ParticleSystem onDestroyVFX { get; set; }*/
}

public interface  IMeleeEnemy : IEnemy
{

}

public interface  IDistantEnemy : IEnemy
{
    public float Damage { get; set; }
}