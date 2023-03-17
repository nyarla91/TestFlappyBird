using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Settings
{
    [RequireComponent(typeof(TMP_Dropdown))]
    public class DropdownSettingMenuElement : SettingMenuElement
    {
        private TMP_Dropdown _dropdown;
        
        protected override void SetStartingValue(int value) => _dropdown.value = value;

        private void Awake()
        {
            _dropdown = GetComponent<TMP_Dropdown>();
        }
    }
}