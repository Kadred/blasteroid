using Models.Projectile;

namespace Models.Weapons
{
    public class LaserWeapon : BaseWeapon
    {
        #region Fields

        private LaserWeaponData setting;
        private int shotCount;
        private float timeRechargeCounter;

        #endregion


        #region Properties

        public override bool CanShoot => shotCount > 0;

        public int MaxLaserShots => setting.maxShots;

        public int LaserShots => shotCount;

        public float RechargeLaserCooldown => shotCount < setting.maxShots
            ? setting.rechargeTime - timeRechargeCounter
            : 0.0f;

        #endregion


        #region Methods

        public LaserWeapon(LaserWeaponData laserWeaponData, Positionable bindingPoint) : base(bindingPoint)
        {
            setting = laserWeaponData;

            shotCount = setting.maxShots;
            timeRechargeCounter = 0.0f;
        }


        public override void Shoot(bool isShooting)
        {
            if (!CanShoot)
            {
                return;
            }

            Shoot();
            shotCount--;
        }


        public override void CustomUpdate(float deltaTime)
        {
            if (shotCount >= setting.maxShots)
            {
                return;
            }

            if (timeRechargeCounter > setting.rechargeTime)
            {
                shotCount++;
                timeRechargeCounter = 0.0f;
            }
            else
            {
                timeRechargeCounter += deltaTime;
            }
        }


        protected override BaseProjectileModel GetProjectile() =>
            new LaserModel(bindingPoint.Position, bindingPoint.Rotation, bindingPoint.Forward, setting.speed,
                setting.colliderData, bindingPoint.PhysicService);

        #endregion
    }
}