using System;
using UnityEngine;

namespace Gameplay.Player
{
    public class PlayerAnimation : PlayerComponent
    {
        [SerializeField] private Transform _sprite;
        [Space]
        [SerializeField] private float _tiltForce;

        private void Update()
        {
            _sprite.localRotation = Quaternion.Euler(0, 0, Movement.VerticalSpeed * _tiltForce);
        }
    }
}