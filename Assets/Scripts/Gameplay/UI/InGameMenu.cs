using UI;
using UnityEngine;

namespace Gameplay.UI
{
    public class InGameMenu : Menu
    {
        public override void Open()
        {
            base.Open();
            Pause.Instance.PauseFromSource(this);
        }

        public override void Close()
        {
            base.Close();
            Pause.Instance.UnpauseFromSource(this);
        }
    }
}