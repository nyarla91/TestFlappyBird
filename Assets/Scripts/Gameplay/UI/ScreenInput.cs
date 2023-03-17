using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Gameplay.UI
{
    public class ScreenInput : MonoBehaviour
    {
        public event Action JumpPressed;

        public void PressJump(BaseEventData _) => JumpPressed?.Invoke();
    }
}