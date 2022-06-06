namespace Assets.Code.Infrastructure
{
    public class LoadSceneState : IPayloadedGameState<string>
    {
        private const string nameOfMainMenuScene = "MainMenu";
        private readonly GameStateMachine _gameStateMachine;
        private readonly SceneLoader _sceneLoader;

        public LoadSceneState(GameStateMachine gameStateMachine, SceneLoader sceneLoader)
        {
            this._gameStateMachine = gameStateMachine;
            this._sceneLoader = sceneLoader;
        }

        public void Enter(string sceneName)
        {
            CheckAndEnterNewState(sceneName);
        }

        private void CheckAndEnterNewState(string sceneName)
        {
            switch (sceneName)
            {
                case nameOfMainMenuScene:
                    _sceneLoader.Load(sceneName, InitialInMainMenuState);
                    EnterInMainMenuState();
                    break;

                default:
                    _sceneLoader.Load(sceneName);
                    EnterInGameState();
                    break;
            }
        }

        private void InitialInMainMenuState()
        {
            _gameStateMachine.GetState<InMainMenuState>().mainMenuUI.Initial();
        }

        private void EnterInMainMenuState()
        {
            _gameStateMachine.Enter<InMainMenuState>();
        }       
        private void EnterInGameState()
        {
            _gameStateMachine.Enter<InGameState>();
        }

        public void Exit()
        {
        }
    }
} 