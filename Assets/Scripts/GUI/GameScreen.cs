using Utils.Updater;
using Models;
using TMPro;
using UnityEngine;


namespace GUI
{
    public class GameScreen : GUIScreen, IUpdatable
    {
        #region Fields

        [SerializeField] private TextMeshProUGUI scoreText;
        [SerializeField] private TextMeshProUGUI positionXText;
        [SerializeField] private TextMeshProUGUI positionYText;
        [SerializeField] private TextMeshProUGUI rotateText;
        [SerializeField] private TextMeshProUGUI speedText;
        [SerializeField] private TextMeshProUGUI laserChargesText;
        [SerializeField] private TextMeshProUGUI laserCooldownTimeText;

        #endregion


        #region Methods

        public override void Show()
        {
            base.Show();

            scoreText.text = $"SCORE: 0";

            guiManager.GameManager.Updater.Register(this);
        }


        public override void Hide()
        {
            guiManager.GameManager.Updater.Unregister(this);
            base.Hide();
        }


        public void CustomUpdate(float deltaTime)
        {
            if (IsShow)
            {
                scoreText.text = $"SCORE: {guiManager.GameManager.StatisticService.Score}";

                ISpaceshipInfo spaceship = guiManager.GameManager.Level.Spaceship;
                positionXText.text = $"X: {spaceship.Position.x:F}";
                positionYText.text = $"Y: {spaceship.Position.y:F}";
                rotateText.text = $"Angle: {spaceship.Rotation:F}";
                speedText.text = $"Speed: {spaceship.Acceleration:F}";

                laserChargesText.text = $"Laser shots: {spaceship.LaserShots}/{spaceship.MaxLaserShots}";
                laserCooldownTimeText.text = $"Laser cooldown: {spaceship.RechargeLaserCooldown:F}";
            }
        }

        #endregion
    }
}