using System;
using Settings;
using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class Difficulty : MonoBehaviour
    {
        [SerializeField] private DifficultyLevel[] _levels;

        public DifficultyLevel CurrentLevel { get; private set; }

        [Inject]
        private void Construct(SettingsConfig config)
        {
            CurrentLevel = _levels[config.GetSettingValue("difficulty")];
        }
    }

    [Serializable]
    public class DifficultyLevel
    {
        [SerializeField] private float _pipesSpeedScale = 1;
        [SerializeField] private float _pipesSpacing;

        public float PipesSpeedScale => _pipesSpeedScale;
        public float PipesSpacing => _pipesSpacing;
    }
}