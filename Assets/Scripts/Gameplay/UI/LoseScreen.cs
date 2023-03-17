using Gameplay.Player;
using UI;
using UnityEngine;
using Zenject;

namespace Gameplay.UI
{
    public class LoseScreen : Menu
    {
        [Inject] private Pause Pause { get; set; }
        
        [Inject]
        private void Construct(PlayerLife playerLife)
        {
            playerLife.HitObstacle += Open;
        }

        public override void Open()
        {
            base.Open();
            Pause.PauseFromSource(this);
        }
    }
}