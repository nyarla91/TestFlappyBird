using Gameplay.Player;
using UnityEngine;

namespace Gameplay.Enviroment
{
    [RequireComponent(typeof(MovingEnviromentElement))]
    public class Gem : MonoBehaviour
    {
        [SerializeField] private GameObject _view;

        private void Awake()
        {
            GetComponent<MovingEnviromentElement>().Respawned += Show;
        }

        private void Show() => _view.SetActive(true);
        
        private void Hide() => _view.SetActive(false);

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out PlayerScore score))
            {
                score.AddOnePoint();
                Hide();
            }
        }
    }
}