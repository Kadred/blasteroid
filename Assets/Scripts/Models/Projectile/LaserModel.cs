using Physics;
using UnityEngine;


namespace Models.Projectile
{
    public class LaserModel : BaseProjectileModel
    {
        #region Fields

        private readonly Vector2 direction;
        private readonly float speed;

        #endregion


        #region Methods

        public LaserModel(Vector2 position, float rotation, Vector2 direction, float speed, ColliderData colliderData,
            IPhysicService physicService) : base(position, rotation, 0.0f, colliderData, physicService)
        {
            this.direction = direction;
            this.speed = speed;
        }


        public override void OnCollision(IPhysicObject physicObject)
        {
            if (physicObject.ColliderData.tag == PhysicTags.Portal)
            {
                Destroy();
            }
        }


        public override void CustomUpdate(float deltaTime)
        {
            Vector2 nextPosition = Position + direction * (speed * deltaTime);
            MoveTo(nextPosition);

            base.CustomUpdate(deltaTime);
        }

        #endregion
    }
}