using System;
using Utils.Updater;
using Models.Projectile;


namespace Models.Weapons
{
    public abstract class BaseWeapon : IUpdatable
    {
        #region Fields

        public event Action<BaseProjectileModel> OnShot;

        protected readonly Positionable bindingPoint;

        #endregion


        #region Properties

        public virtual bool CanShoot { get; }

        #endregion


        #region Methods

        public BaseWeapon(Positionable bindingPoint)
        {
            this.bindingPoint = bindingPoint;
        }


        protected void Shoot()
        {
            if (!CanShoot)
            {
                return;
            }

            BaseProjectileModel projectile = GetProjectile();
            OnShot?.Invoke(projectile);
        }


        public abstract void CustomUpdate(float deltaTime);


        public abstract void Shoot(bool isShooting);


        protected abstract BaseProjectileModel GetProjectile();

        #endregion
    }
}