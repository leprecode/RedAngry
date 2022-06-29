using Assets.Code.Data;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Code.PlayerLogic
{
    public class Player : MonoBehaviour, ISaveProgress
    {
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