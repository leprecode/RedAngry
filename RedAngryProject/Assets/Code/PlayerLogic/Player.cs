using Assets.Code.Data;
using Assets.Code.Enemies;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Code.PlayerLogic
{
    public class Player : MonoBehaviour, IDamagable, ISaveProgress
    {
        [SerializeField] private float _health;

        public void ApplyDamage(float damage)
        {
            _health -= damage;

            CheckHealth();
        }

        public void CheckHealth()
        {
            if (_health <= 0)
                Die();
        }

        public void Die()
        {
            Destroy(gameObject);
        }

        public void LoadProgress(PlayerProgress progress)
        {
            if (SceneManager.GetActiveScene().name == progress.worldData.PositionOnLevel.Level)
            {
                var savedPosition = progress.worldData.PositionOnLevel.Position;

                if (savedPosition != null)
                    Warp(savedPosition);
            }
        }

        private void Warp(Vector3Data to)
        {
            var CharacterController = GetComponent<CharacterController>();
            CharacterController.enabled = false;
            transform.position = to.AsUnityVector();
            CharacterController.enabled = true;
        }

        public void UpdateProgress(PlayerProgress progress)
        {
            progress.worldData.PositionOnLevel =
                new PositionOnLevel(CurrentLevel(), transform.position.AsVector3Data());
        }

        private static string CurrentLevel() => SceneManager.GetActiveScene().name;
    }
} 