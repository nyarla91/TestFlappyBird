using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Extentions;
using UnityEngine;

namespace Settings
{
    public class SettingsConfig : MonoBehaviour
    {
        [SerializeField] private string _saveFileName;
        [SerializeField] private SerializedDictionary<string, int> _settings;

        private string SaveFilePath => PlayerData.Path + $"{_saveFileName}.json";

        public event Action<SettingsConfig> Updated;

        public int GetSettingValue(string setting)
        {
            ValidateSetting(setting);
            return _settings.Dictionary[setting];
        }
        
        public void SetSettingValue(string setting, int value)
        {
            ValidateSetting(setting);
            SerializedKeyValuePair<string,int> pairToEdit = _settings.Pairs.Find(pair => pair.Key.Equals(setting));
            pairToEdit.Value = value;
            Updated?.Invoke(this);
            Save();
        }

        private void Save()
        {
            string json = JsonUtility.ToJson(_settings);
            File.WriteAllText(SaveFilePath, json);
        }

        private void ValidateSetting(string setting)
        {
            if (!_settings.Dictionary.ContainsKey(setting))
                throw new ArgumentOutOfRangeException($"Setting {setting} does not exist");
        }

        private void TryLoadConfig()
        {
            if ( ! File.Exists(SaveFilePath))
                return;
            
            string json = File.ReadAllText(SaveFilePath);
            SerializedDictionary<string, int> config = JsonUtility.FromJson<SerializedDictionary<string, int>>(json);
            _settings = config;
        }

        private void Awake()
        {
            TryLoadConfig();
        }
    }

    [Serializable]
    public class SettingElement
    {
        [SerializeField] private string _name;
        [SerializeField] private int _value;
            
        public string Name => _name;
        public int Value => _value;

        public SettingElement(string name, int value)
        {
            _name = name;
            _value = value;
        }
    }
}