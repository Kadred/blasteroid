using Models.Projectile;

namespace Models.Weapons
{
    public class BulletWeapon : BaseWeapon
    {
        #region Fields

        private BulletWeaponData setting;
        private float timeRechargeCounter;

        #endregion


        #region Properties

        public bool IsShooting { get; private set; }

        public override bool CanShoot => true;

        #endregion


        #region Methods

        public BulletWeapon(BulletWeaponData bulletWeaponData, Positionable bindingPoint) : base(bindingPoint)
        {
            setting = bulletWeaponData;
        }


        public override void Shoot(bool isShooting) => IsShooting = isShooting;


        public override void CustomUpdate(float deltaTime)
        {
            if (!IsShooting)
            {
                return;
            }

            if (timeRechargeCounter > setting.rechargeTime)
            {
                Shoot();
                timeRechargeCounter = 0.0f;
            }
            else
            {
                timeRechargeCounter += deltaTime;
            }
        }

        protected override BaseProjectileModel GetProjectile() =>
            new BulletModel(bindingPoint.Position, bindingPoint.Rotation, bindingPoint.Forward, setting.speed,
                setting.colliderData,
                bindingPoint.PhysicService);

        #endregion
    }
}