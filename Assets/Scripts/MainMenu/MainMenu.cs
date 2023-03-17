using SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace MainMenu
{
    public class MainMenu : MonoBehaviour
    {
        [Inject] private SceneLoader SceneLoader { get; set; }
        
        public void Play() => SceneLoader.LoadGameplay();
    }
}