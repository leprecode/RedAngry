using UnityEngine;

namespace Assets.Code.MainMenu
{
    public class CanvasBackground : MonoBehaviour
    {
        private void Start()
        {
            Canvas canvas = GetComponent<Canvas>();
            canvas.renderMode = RenderMode.ScreenSpaceCamera;
            canvas.worldCamera = Camera.main;
        }
    }
}