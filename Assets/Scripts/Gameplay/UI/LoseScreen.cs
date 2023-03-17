using Gameplay.Player;
using SceneManagement;
using UI;
using UnityEngine;
using Zenject;

namespace Gameplay.UI
{
    public class LoseScreen : Menu
    {
        [Inject] private Pause Pause { get; set; }
        [Inject] private SceneLoader SceneLoader { get; set; }
        
        [Inject]
        private void Construct(PlayerLife playerLife)
        {
            playerLife.HitObstacle += Open;
        }

        public void Restart() => SceneLoader.LoadGameplay();
        public void Exit() => SceneLoader.LoadMainMenu();

        public override void Open()
        {
            base.Open();
            Pause.PauseFromSource(this);
        }
    }
}