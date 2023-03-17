using System;
using UnityEngine;
using Zenject;

namespace Settings
{
    public abstract class SettingMenuElement : MonoBehaviour
    {
        [SerializeField] private string _setting;
        
        [Inject] private SettingsConfig Config { get; set; }

        public void ApplyValue(float value) => ApplyValue(Mathf.RoundToInt(value));
        
        public void ApplyValue(int value)
        {
            Config.SetSettingValue(_setting, value);
        }

        protected abstract void SetStartingValue(int value);

        protected virtual void Start()
        {
            SetStartingValue(Config.GetSettingValue(_setting));
        }
    }
}