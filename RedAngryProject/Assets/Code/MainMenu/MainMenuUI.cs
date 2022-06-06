using Assets.Code.Infrastructure;

using UnityEngine;
using UnityEngine.UI;

namespace Assets.Code.MainMenu
{
    public class MainMenuUI
    {
        private const string NameOfPlayButton = "PlayButton";
        
        private const string PathToBackgroundCanvas = "Prefabs/MainMenu/UI/CanvasBackground";
        private const string PathToFooterCanvas = "Prefabs/MainMenu/UI/CanvasForFooter";
        private const string PathToForHeaderCanvas = "Prefabs/MainMenu/UI/CanvasForHeader";
        private const string PathToPlayer = "Prefabs/MainMenu/Objects/Boximon Fiery";


        private readonly GameStateMachine _gameStateMachine;
        private Button _playButton;

        public MainMenuUI(GameStateMachine gameStateMachine)
        {
            this._gameStateMachine = gameStateMachine;
        }

        public void Initial()
        {
            Debug.Log("Initial");

            InstantiatePrefab(PathToBackgroundCanvas);
            InstantiatePrefab(PathToFooterCanvas);
            InstantiatePrefab(PathToForHeaderCanvas);
            InstantiatePrefab(PathToPlayer);

            FindAllButtons();
            AddListenersToButtons();
        }

        private GameObject InstantiatePrefab(string path)
        {
            Debug.Log($"Instantiate {path}");

            var prefab = Resources.Load<GameObject>(path);
            return Object.Instantiate(prefab) as GameObject;
        }

        private void FindAllButtons()
        {
            _playButton = GameObject.Find(NameOfPlayButton).GetComponent<Button>();
        }

        private void AddListenersToButtons()
        {
            _playButton.onClick.AddListener(StartGame);
        }


        //FIX testScene!
        private void StartGame()
        {
            _gameStateMachine.Enter<LoadSceneState,string>("TestScene");
        }
    }
}