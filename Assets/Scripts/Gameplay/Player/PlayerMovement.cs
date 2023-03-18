using System;
using Extentions;
using Gameplay.UI;
using UnityEngine;
using Zenject;

namespace Gameplay.Player
{
    public class PlayerMovement : PlayerComponent
    {
        [Tooltip("Acceleration of fall speed per second (positive)")] [SerializeField] private float _gravity;
        [SerializeField] private float _jumpForce;

        public float VerticalSpeed { get; private set; }
        
        [Inject] private Pause Pause { get; set; }
        
        public event Action Jumped;

        [Inject]
        private void Construct(ScreenInput input)
        {
            input.JumpPressed += Jump;
        }

        private void Jump()
        {
            if (Pause.IsPaused)
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
            if (Pause.IsPaused)
                return;
            
            Transform.position += Vector3.up * VerticalSpeed;
        }

        private void Fall()
        {
            if (Pause.IsPaused)
                return;
            
            VerticalSpeed -= _gravity * Time.fixedDeltaTime;
        }

        private void OnValidate()
        {
            _gravity = Mathf.Max(_gravity, 0);
        }
    }
}