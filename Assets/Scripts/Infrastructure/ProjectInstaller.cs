using SceneManagement;
using Settings;
using UnityEngine;
using Zenject;

namespace Infrastructure
{
    public class ProjectInstaller : MonoInstaller
    {
        [SerializeField] private GameObject _settingsPrefab;
        [SerializeField] private GameObject _sceneLoaderPrefab;
        
        public override void InstallBindings()
        {
            BindFromPrefab<SettingsConfig>(_settingsPrefab);
            BindFromPrefab<SceneLoader>(_sceneLoaderPrefab);
        }

        private void BindFromPrefab<T>(GameObject prefab) where T : Component
        {
            GameObject instance = Container.InstantiatePrefab(prefab);
            Container.Bind<T>().FromInstance(instance.GetComponent<T>()).AsSingle();
        }
    }
}