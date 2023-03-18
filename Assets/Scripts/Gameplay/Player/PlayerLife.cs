using System;
using UnityEngine;

namespace Gameplay.Player
{
    public class PlayerLife : PlayerComponent
    {
        public event Action HitObstacle;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.layer != LayerMask.NameToLayer("Obstacle"))
                return;
            
            HitObstacle?.Invoke();
        }
    }
}