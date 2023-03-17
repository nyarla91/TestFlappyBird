using System;
using UnityEngine;

namespace Gameplay.Player
{
    public class PlayerScore : PlayerComponent
    {
        private int _points;

        public event Action<int> PointsChanged;
        public event Action PointsIncreased;
        
        public void AddOnePoint()
        {
            PointsChanged?.Invoke(++_points);
            PointsIncreased?.Invoke();
        }
    }
}