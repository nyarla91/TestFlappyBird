using SceneManagement;
using UnityEngine;
using Zenject;

namespace Boot
{
    public class StartButton : MonoBehaviour
    {
        [SerializeField] private CanvasGroup _canvasGroup;
        [SerializeField] private ConversionData _conversionData;

        [Inject] private SceneLoader SceneLoader { get; set; }

        public void StartGame()
        {
            SceneLoader.LoadMainMenu();
        }
        
        private void Awake()
        {
            Hide();
            _conversionData.Loaded += Show;
        }

        private void Show() => ToggleVisibility(true);
        private void Hide() => ToggleVisibility(false);
        
        private void ToggleVisibility(bool visible)
        {
            _canvasGroup.alpha = visible ? 1 : 0;
            _canvasGroup.blocksRaycasts = visible;
        }
    }
}