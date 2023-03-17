using Extentions;
using UnityEngine;

namespace Gameplay
{
    public class PipeSection : Transformable
    {
        [SerializeField] private Transform _spawnPoint;
        [SerializeField] private Collider2D _yPositionRange;
        [Space]
        [Tooltip("Units per second (positive)")] [SerializeField] private float _moveSpeed;

        private void FixedUpdate()
        {
            if (Pause.Instance.IsPaused)
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

        private void OnValidate()
        {
            _moveSpeed = Mathf.Max(_moveSpeed, 0);
        }
    }
}