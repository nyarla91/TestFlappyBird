using Gameplay.Player;
using TMPro;
using UnityEngine;
using Zenject;

namespace Gameplay.UI
{
    public class ScoreCounter : MonoBehaviour
    {
        [SerializeField] private TMP_Text _counter;
        
        [Inject]
        private void Construct(PlayerScore playerScore)
        {
            playerScore.PointsChanged += UpdateCounter;
        }
        
        private void Start()
        {
            UpdateCounter(0);
        }

        private void UpdateCounter(int score)
        {
            _counter.text = $"{score}";
        }
    }
}