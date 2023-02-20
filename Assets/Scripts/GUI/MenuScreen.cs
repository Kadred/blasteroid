using UnityEngine;
using UnityEngine.UI;


namespace GUI
{
    public class MenuScreen : GUIScreen
    {
        #region Fields

        [SerializeField] private Button startButton;

        #endregion


        #region Methods
        
        public override void Show()
        {
            base.Show();

            startButton.onClick.AddListener(StartButton_OnClick);
        }


        public override void Hide()
        {
            startButton.onClick.RemoveListener(StartButton_OnClick);

            base.Hide();
        }

        #endregion


        #region Event handlers
        
        private void StartButton_OnClick()
        {
            guiManager.GameManager.StartGame();
            Hide();
        }

        #endregion
    }
}