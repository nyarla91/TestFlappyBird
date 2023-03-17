using System;
using Extentions;
using UnityEngine;

namespace Gameplay.Player
{
    public class PlayerMovement : PlayerComponent
    {
        [Tooltip("Acceleration of fall speed per second (positive)")] [SerializeField] private float _gravity;
        [SerializeField] private float _jumpForce;

        private float VerticalSpeed { get; set; }

        public event Action Jumped; 
        
        public void Jump()
        {
            if (Pause.Instance.IsPaused)
                return;
            
            VerticalSpeed = _jumpForce;
            Jumped?.Invoke();
        }

        private void FixedUpdate()
        {
            Fall();
            Move();
        }

        private void Move()
        {
            if (Pause.Instance.IsPaused)
                return;
            
            Transform.position += Vector3.up * VerticalSpeed;
        }

        private void Fall()
        {
            if (Pause.Instance.IsPaused)
                return;
            
            VerticalSpeed -= _gravity * Time.fixedDeltaTime;
        }

        private void OnValidate()
        {
            _gravity = Mathf.Max(_gravity, 0);
        }
    }
}