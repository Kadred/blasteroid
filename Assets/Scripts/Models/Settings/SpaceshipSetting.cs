using Physics;
using UnityEngine;

namespace Models
{
    [CreateAssetMenu]
    public class SpaceshipSetting : ScriptableObject
    {
        #region Fields

        [SerializeField] private ShipMoverData moverData;
        [SerializeField] private ShipShootingData shootingData;
        [SerializeField] private ColliderData colliderData;

        #endregion


        #region Properties

        public ShipMoverData MoverData => moverData;

        public ShipShootingData ShootingData => shootingData;

        public ColliderData ShipColliderData => colliderData;

        #endregion
    }
}