using Extentions;
using UnityEngine;

namespace Gameplay.Player
{
    public class PlayerComponent : Transformable
    {
        private PlayerScore _score;
        private PlayerMovement _movement;
        private PlayerLife _life;

        protected PlayerScore Score => _score ??= GetComponent<PlayerScore>();
        protected PlayerMovement Movement => _movement ??= GetComponent<PlayerMovement>();
        protected PlayerLife Life => _life ??= GetComponent<PlayerLife>();
    }
}