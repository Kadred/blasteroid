using Utils.Updater;
using Physics;
using UnityEngine;

namespace Models.Projectile
{
    public class BaseProjectileModel : Positionable, IUpdatable
    {
        #region Fields

        private readonly float maxLifetime;
        private float lifeTime;

        #endregion


        #region Methods

        protected BaseProjectileModel(Vector2 position, float rotation, float lifetime, ColliderData colliderData,
            IPhysicService physicService) : base(position, rotation, colliderData, physicService)
        {
            maxLifetime = lifetime;
        }


        public override void OnCollision(IPhysicObject physicObject)
        {
            Destroy();
        }


        public virtual void CustomUpdate(float deltaTime)
        {
            if (!(maxLifetime > 0))
            {
                return;
            }

            lifeTime += deltaTime;
            if (lifeTime >= maxLifetime)
            {
                Destroy();
            }
        }

        #endregion
    }
}