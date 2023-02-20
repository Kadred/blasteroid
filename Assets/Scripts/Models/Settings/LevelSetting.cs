using UnityEngine;

namespace Models
{
    [CreateAssetMenu]
    public class LevelSetting : ScriptableObject
    {
        #region Fields

        [SerializeField] private int minRespawnAsteroids;
        [SerializeField] private int maxRespawnAsteroids;
        [SerializeField] private int minRespawnFragments;
        [SerializeField] private int maxRespawnFragments;
        [SerializeField] private int countKillForRespawnUfo;

        [SerializeField] private SpaceshipSetting spaceshipSetting;
        [SerializeField] private EnemySetting asteroidSetting;
        [SerializeField] private EnemySetting fragmentSetting;
        [SerializeField] private EnemySetting ufoSetting;

        #endregion


        #region Properties

        public int MinRespawnAsteroids => minRespawnAsteroids;
        public int MaxRespawnAsteroids => maxRespawnAsteroids;
        public int MinRespawnFragments => minRespawnFragments;
        public int MaxRespawnFragments => maxRespawnFragments;
        public int CountKillForRespawnUfo => countKillForRespawnUfo;

        public SpaceshipSetting SpaceshipSetting => spaceshipSetting;
        public EnemySetting AsteroidSetting => asteroidSetting;
        public EnemySetting FragmentSetting => fragmentSetting;
        public EnemySetting UfoSetting => ufoSetting;

        #endregion
    }
}