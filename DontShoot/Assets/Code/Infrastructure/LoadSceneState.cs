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
                    _sceneLoader.Load(sceneName);
                    _gameStateMachine.Enter<InMainMenuState>();
                    break;

                default:
                    _sceneLoader.Load(sceneName);
                    _gameStateMachine.Enter<InGameState>();
                    break;
            }
        }

        public void Exit()
        {
        }
    }
} 