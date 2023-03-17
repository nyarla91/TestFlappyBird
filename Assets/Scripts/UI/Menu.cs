using UnityEngine;

namespace UI
{
    [RequireComponent(typeof(CanvasGroup))]
    public class Menu : MonoBehaviour
    {
        private CanvasGroup _canvasGroup;

        public virtual void Open()
        {
            _canvasGroup.alpha = 1;
            _canvasGroup.blocksRaycasts = true;
        }

        public virtual void Close()
        {
            _canvasGroup.alpha = 0;
            _canvasGroup.blocksRaycasts = false;
        }

        protected virtual void Awake()
        {
            _canvasGroup = GetComponent<CanvasGroup>();
        }

        protected virtual void Start()
        {
            Close();
        }
    }
}