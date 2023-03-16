using System;
using Extentions;
using UnityEngine;

namespace Gameplay
{
    public class PlayerMovement : Transformable
    {
        [Tooltip("Acceleration of fall speed per second (positive)")] [SerializeField] private float _gravity;
        [SerializeField] private float _jumpForce;

        private float VerticalSpeed { get; set; }
        
        public void Jump()
        {
            VerticalSpeed = _jumpForce;
        }

        private void FixedUpdate()
        {
            Fall();
            Move();
        }

        private void Move()
        {
            Transform.position += Vector3.up * VerticalSpeed;
        }

        private void Fall()
        {
            VerticalSpeed -= _gravity * Time.fixedDeltaTime;
        }

        private void OnValidate()
        {
            _gravity = Mathf.Max(_gravity, 0);
        }
    }
}