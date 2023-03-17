using UI;
using UnityEngine;
using Zenject;

namespace Gameplay.UI
{
    public class InGameMenu : Menu
    {
        [Inject] private Pause Pause { get; set; }
        
        public override void Open()
        {
            base.Open();
            Pause.PauseFromSource(this);
        }

        public override void Close()
        {
            base.Close();
            Pause.UnpauseFromSource(this);
        }
    }
}