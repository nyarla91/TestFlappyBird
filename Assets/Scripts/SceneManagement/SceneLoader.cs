using UnityEngine;
using UnityEngine.AddressableAssets;

namespace SceneManagement
{
    public class SceneLoader : MonoBehaviour
    {
        [SerializeField] private AssetReference _mainMenuScene;
        [SerializeField] private AssetReference _gameplayScene;

        private bool _loadingScene;

        public void LoadMainMenu() => LoadScene(_mainMenuScene);
        public void LoadGameplay() => LoadScene(_gameplayScene);

        private async void LoadScene(AssetReference scene)
        {
            if (_loadingScene)
                return;
            _loadingScene = true;

            await scene.LoadSceneAsync().Task;
            scene.ReleaseAsset();

            _loadingScene = false;
        }
    }
}