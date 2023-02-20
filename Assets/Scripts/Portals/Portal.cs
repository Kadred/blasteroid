using Utils;
using Physics;
using UnityEngine;


namespace Portals
{
    public abstract class Portal : MonoBehaviour, IPhysicObject
    {
        #region Fields

        private IPhysicService physicService;
        private PortalsSetting portalsSetting;

        #endregion


        #region Properties

        public ColliderData ColliderData => portalsSetting.ColliderData;

        public virtual Vector2 Position => transform.position;

        public Rect CollisionRect { get; protected set; }

        protected float PortalWidth => portalsSetting.PortalWidth;

        protected float TransferOffset { get; set; }

        #endregion


        #region Methods

        public void Initialize(PortalsSetting portalsSetting, Rect respawnRect, IPhysicService physicService)
        {
            this.portalsSetting = portalsSetting;
            this.physicService = physicService;

            SetPortalPositions(respawnRect);
            this.physicService.Register(this);
        }


        public void Deinitialize()
        {
            physicService.Unregister(this);
        }


        protected abstract void SetPortalPositions(Rect respawnRect);


        public abstract void OnCollision(IPhysicObject physicObject);


        public void MoveTo(Vector2 position)
        {
            transform.position = position;
        }


        private void OnDrawGizmos()
        {
            EditorUtils.DrawRectGizmos(CollisionRect, Color.red);
        }

        #endregion
    }
}