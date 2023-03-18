using System;
using Extentions;
using UnityEngine;
using Zenject;

namespace Gameplay.Enviroment
{
    public class MovingEnviromentElement : Transformable
    {
        [SerializeField] private Enviroment _enviroment;
        [SerializeField] private bool _randomizeY = true;
        
        [Inject] private Pause Pause { get; set; }
        
        public event Action Respawned;

        private void FixedUpdate()
        {
            if (Pause.IsPaused)
                return;
            Transform.position += Vector3.left * _enviroment.Speed;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.layer == LayerMask.NameToLayer("ScreenBound"))
            {
                _enviroment.RespawnElement(Transform, _randomizeY);
                Respawned?.Invoke();
            }
        }
    }
}