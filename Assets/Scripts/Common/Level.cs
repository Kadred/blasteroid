using Models;
using UnityEngine;


namespace Common
{
    public class Level
    {
        #region Fields

        private LevelGenerator levelGenerator;
        private Rect respawnRect;

        #endregion


        #region Properties

        public ISpaceshipInfo Spaceship => levelGenerator.Spaceship;

        #endregion


        #region Methods

        public Level(LevelSetting setting, IGameManager gameManager)
        {
            Vector2 pointLeftTop = Camera.main.ViewportToWorldPoint(Vector3.zero);
            Vector2 pointRightBottom = Camera.main.ViewportToWorldPoint(Vector3.one);
            respawnRect = new Rect(
                pointLeftTop.x,
                pointLeftTop.y,
                Mathf.Abs(pointLeftTop.x) + Mathf.Abs(pointRightBottom.x),
                Mathf.Abs(pointLeftTop.y) + Mathf.Abs(pointRightBottom.y));

            levelGenerator = new LevelGenerator(setting, respawnRect, gameManager);
        }


        public void Initialize()
        {
            levelGenerator.GenerateLevel();
        }


        public void Deinitialize()
        {
            levelGenerator.ClearLevel();
        }

        #endregion
    }
}