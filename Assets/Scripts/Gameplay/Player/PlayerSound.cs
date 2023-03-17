using UnityEngine;
using Random = UnityEngine.Random;

namespace Gameplay.Player
{
    public class PlayerSound : PlayerComponent
    {
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] [Range(0, 1)] private float _pitchAmplitude;
        [Space]
        [SerializeField] private AudioClip _jumpSound;
        [SerializeField] private AudioClip _hitSound;
        [SerializeField] private AudioClip _scoreSound;

        private void Awake()
        {
            Movement.Jumped += () => PlaySound(_jumpSound);
            Life.HitObstacle += () => PlaySound(_hitSound);
            Score.PointsIncreased += () => PlaySound(_scoreSound);
        }

        private void PlaySound(AudioClip clip)
        {
            _audioSource.pitch = Random.Range(1 - _pitchAmplitude, 1 + _pitchAmplitude);
            _audioSource.PlayOneShot(clip);
        }
    }
}