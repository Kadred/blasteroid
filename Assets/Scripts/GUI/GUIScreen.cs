using System;
using UnityEngine;


namespace GUI
{
    public class GUIScreen : MonoBehaviour, IGUIScreen
    {
        #region Fields

        public event Action onShown;
        public event Action onHidden;

        protected GUIManager guiManager;

        #endregion


        #region Properties

        public bool IsShow => gameObject.activeSelf;

        #endregion


        #region Methods

        public virtual void Initialize(GUIManager manager)
        {
            guiManager = manager;
            gameObject.SetActive(false);
        }


        public virtual void Show()
        {
            gameObject.SetActive(true);
            onShown?.Invoke();
        }


        public virtual void Hide()
        {
            gameObject.SetActive(false);
            onHidden?.Invoke();
        }

        #endregion
    }
}