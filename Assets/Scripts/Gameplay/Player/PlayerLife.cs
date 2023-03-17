using System;
using UnityEngine;

namespace Gameplay.Player
{
    public class PlayerLife : PlayerComponent
    {
        public event Action HitObstacle;
        
        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.layer != LayerMask.NameToLayer("Obstacle"))
                return;
            
            HitObstacle?.Invoke();
        }
    }
}