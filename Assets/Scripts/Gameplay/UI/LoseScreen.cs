using Gameplay.Player;
using UI;
using UnityEngine;

namespace Gameplay.UI
{
    public class LoseScreen : Menu
    {
        [SerializeField] private PlayerLife _player;

        protected override void Awake()
        {
            base.Awake();
            _player.HitObstacle += Open;
        }

        public override void Open()
        {
            base.Open();
            Pause.Instance.PauseFromSource(this);
        }
    }
}