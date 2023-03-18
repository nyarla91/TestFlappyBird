using Extentions;
using TMPro;
using UnityEngine;
using Zenject;

namespace Gameplay.Enviroment
{
    public class PipeSection : Transformable
    {
        [SerializeField] private Difficulty _difficulty;
        [Space]
        [SerializeField] private Transform _topPipe;
        [SerializeField] private Transform _bottomPipe;
        
        private void Start()
        {
            float spacing = _difficulty.CurrentLevel.PipesSpacing;
            Vector3 offset = Vector3.up * spacing / 2;
            _topPipe.localPosition += offset;
            _bottomPipe.localPosition -= offset;
        }
    }
}