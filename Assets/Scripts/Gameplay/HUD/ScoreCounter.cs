using System;
using TMPro;
using UnityEngine;

namespace Gameplay.HUD
{
    public class ScoreCounter : MonoBehaviour
    {
        [SerializeField] private TMP_Text _counter;
        [SerializeField] private PlayerScore _player;
        
        
        private void Awake()
        {
            _player.PointsChanged += UpdateCounter;
            UpdateCounter(0);
        }

        private void UpdateCounter(int score)
        {
            _counter.text = $"{score}";
        }
    }
}