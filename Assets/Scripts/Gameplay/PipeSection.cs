using System;
using Extentions;
using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class PipeSection : Transformable
    {
        [SerializeField] private Difficulty _difficulty;
        [SerializeField] private Transform _spawnPoint;
        [SerializeField] private Collider2D _yPositionRange;
        [Space]
        [SerializeField] private Transform _topPipe;
        [SerializeField] private Transform _bottomPipe;
        [Space]
        [Tooltip("Units per second (positive)")] [SerializeField] private float _moveSpeed;
        
        [Inject] private Pause Pause { get; set; }
        
        private void FixedUpdate()
        {
            if (Pause.IsPaused)
                return;
            Transform.position += Vector3.left * _moveSpeed;
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.layer == LayerMask.NameToLayer("ScreenBound"))
            {
                Respawn();
            }
        }

        private void Respawn()
        {
            Vector3 newPosition = new Vector3
            {
                x = _spawnPoint.position.x,
                y = _yPositionRange.bounds.RandomPoint().y
            };
            Transform.position = newPosition;
        }

        private void Start()
        {
            _moveSpeed *= _difficulty.CurrentLevel.PipesSpeedScale;
            
            float spacing = _difficulty.CurrentLevel.PipesSpacing;
            Vector3 offset = Vector3.up * spacing / 2;
            _topPipe.localPosition += offset;
            _bottomPipe.localPosition -= offset;
        }

        private void OnValidate()
        {
            _moveSpeed = Mathf.Max(_moveSpeed, 0);
        }
    }
}