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
        [SerializeField] private float _enviromentSpeed = 1;
        [SerializeField] private float _pipesSpacing;

        public float EnviromentSpeed => _enviromentSpeed;
        public float PipesSpacing => _pipesSpacing;
    }
}