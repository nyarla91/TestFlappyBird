﻿using System;
using Extentions;
using UnityEngine;
using Zenject;

namespace Gameplay.Enviroment
{
    public class Enviroment : MonoBehaviour
    {
        [SerializeField] private Difficulty _difficulty;
        [SerializeField] private Transform _spawnPoint;
        [SerializeField] private Collider2D _yPositionRange;

        public float Speed => _difficulty.CurrentLevel.EnviromentSpeed;

        
        public void RespawnElement(Transform element)
        {
            Vector3 newPosition = new Vector3
            {
                x = _spawnPoint.position.x,
                y = _yPositionRange.bounds.RandomPoint().y
            };
            element.position = newPosition;
        }
    }
}