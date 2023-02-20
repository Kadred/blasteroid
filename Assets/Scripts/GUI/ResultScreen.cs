using TMPro;
using UnityEngine;
using UnityEngine.UI;


namespace GUI
{
    public class ResultScreen : GUIScreen
    {
        #region Fields

        [SerializeField] private Button closeButton;
        [SerializeField] private TextMeshProUGUI battlTimeText;

        #endregion


        #region Methods

        public override void Show()
        {
            base.Show();

            closeButton.onClick.AddListener(CloseButton_OnClick);
            battlTimeText.text = $"Your score: {guiManager.GameManager.StatisticService.Score}";
        }


        public override void Hide()
        {
            closeButton.onClick.RemoveListener(CloseButton_OnClick);

            base.Hide();
        }

        #endregion


        #region Event handlers

        private void CloseButton_OnClick()
        {
            guiManager.GameManager.StartGame();
            Hide();
        }

        #endregion
    }
}