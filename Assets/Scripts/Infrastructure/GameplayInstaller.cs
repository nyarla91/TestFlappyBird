using Gameplay;
using Gameplay.Player;
using Gameplay.UI;
using UnityEngine;
using Zenject;

namespace Infrastructure
{
    public class GameplayInstaller : MonoInstaller
    {
        [SerializeField] private GameObject _playerPrefab;
        [SerializeField] private Transform _playerOrigin;
        [SerializeField] private Pause _pause;
        [SerializeField] private ScreenInput _screenInput;
        
        public override void InstallBindings()
        {
            Container.Bind<Pause>().FromInstance(_pause).AsSingle();
            Container.Bind<ScreenInput>().FromInstance(_screenInput).AsSingle();
            
            GameObject player = Container.InstantiatePrefab(_playerPrefab, _playerOrigin);
            BindGameObjectComponent<PlayerScore>(player);
            BindGameObjectComponent<PlayerLife>(player);
            BindGameObjectComponent<PlayerMovement>(player);
        }

        private void BindGameObjectComponent<T>(GameObject objectToBind) where T : Component
        {
            Container.Bind<T>().FromInstance(objectToBind.GetComponent<T>());
        }
    }
}