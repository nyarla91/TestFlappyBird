using System;
using UnityEngine;
using UnityEngine.UI;

namespace Settings
{
    [RequireComponent(typeof(Slider))]
    public sealed class SliderSettingMenuElement : SettingMenuElement
    {
        private Slider _slider;
        
        protected override void SetStartingValue(int value) => _slider.value = value;

        private void Awake()
        {
            _slider = GetComponent<Slider>();
        }
    }
}