using Settings;
using UnityEngine;
using Zenject;

namespace Infrastructure
{
    public class ProjectInstaller : MonoInstaller
    {
        [SerializeField] private GameObject _settingsPrefab;
        
        public override void InstallBindings()
        {
            GameObject settings = Container.InstantiatePrefab(_settingsPrefab);
            Container.Bind<SettingsConfig>().FromInstance(settings.GetComponent<SettingsConfig>()).AsSingle();
        }
    }
}