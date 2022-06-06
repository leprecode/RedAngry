using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Assets.Code.Infrastructure
{
    public class SceneLoader
    {
        private const string loadingSceneName = "Loading";
        private readonly ICoroutineRunner _coroutineRunner;

        public SceneLoader(ICoroutineRunner coroutineRunner) =>
        _coroutineRunner = coroutineRunner;

        public void Load(string sceneName, Action onLoaded = null) =>
        _coroutineRunner.StartCoroutine(LoadScene(sceneName, onLoaded));

        private IEnumerator LoadScene(string nextScene, Action onLoaded = null)
        {

            if (SceneManager.GetActiveScene().name == nextScene)
            {
                onLoaded?.Invoke();
                yield break;
            }

            AsyncOperation waitNextScene = SceneManager.LoadSceneAsync(nextScene);

            while (!waitNextScene.isDone)
            {
/*                FillLoadingProgressBar(waitNextScene);*/

                yield return null;
            }

            onLoaded?.Invoke();
        }

/*        private void FillLoadingProgressBar(AsyncOperation waitNextScene)
        {
            Slider slider = GameObject.FindObjectOfType<Slider>();

            if (slider != null)
            {
                float loadProgress = Mathf.Clamp01(waitNextScene.progress / 0.9f);
                slider.value = loadProgress;
                Debug.Log("load progress" + loadProgress);
            }
        }*/
    }
}