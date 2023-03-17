using System;
using UnityEngine;
using UnityEngine.Audio;

namespace Settings
{
    [RequireComponent(typeof(SettingsConfig))]
    public class SoundSettingsApplier : MonoBehaviour
    {
        [SerializeField] private AudioMixer _mixer;
        [SerializeField] private AnimationCurve _valueDBelCurve;
        
        private void Awake()
        {
            SettingsConfig config = GetComponent<SettingsConfig>();
            config.Updated += ApplyConfig;
        }

        private void ApplyConfig(SettingsConfig config)
        {
            _mixer.SetFloat("sfxVolume", SettingValueToDBelVolume(config.GetSettingValue("sfxVolume")));
            _mixer.SetFloat("musicVolume", SettingValueToDBelVolume(config.GetSettingValue("musicVolume")));
        }
        
        private float SettingValueToDBelVolume(int value) => _valueDBelCurve.Evaluate(value);
    }
}