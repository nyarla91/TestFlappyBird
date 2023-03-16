using System;
using UnityEngine;

namespace Gameplay
{
    public class PlayerScore : MonoBehaviour
    {
        [SerializeField] private int _points;

        public event Action<int> PointsChanged;
        
        public void AddOnePoint() => PointsChanged?.Invoke(++_points);
    }
}