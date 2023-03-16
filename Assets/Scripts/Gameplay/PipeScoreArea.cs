using System;
using UnityEngine;

namespace Gameplay
{
    public class PipeScoreArea : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.TryGetComponent(out PlayerScore score))
            {
                score.AddOnePoint();
            }
        }
    }
}