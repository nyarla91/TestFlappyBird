using UnityEngine;

namespace Gameplay
{
    public class PlayerLife : MonoBehaviour
    {
        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.layer == LayerMask.NameToLayer("Obstacle"))
            {
                Lose();
            }
        }

        private void Lose()
        {
            print("Lost");
        }
    }
}