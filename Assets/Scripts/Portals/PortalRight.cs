using Physics;
using UnityEngine;


namespace Portals
{
    public class PortalRight : Portal
    {
        #region Methods

        protected override void SetPortalPositions(Rect respawnRect)
        {
            Vector3 position = new Vector3(respawnRect.x + respawnRect.width, 0, 0);
            MoveTo(position);

            TransferOffset = respawnRect.x;

            CollisionRect = new Rect(position.x, position.y - respawnRect.height / 2, PortalWidth, respawnRect.height);
        }


        public override void OnCollision(IPhysicObject physicObject)
        {
            Vector3 position = physicObject.Position;
            physicObject.MoveTo(new Vector3(TransferOffset + physicObject.CollisionRect.width,
                position.y, position.z));
        }

        #endregion
    }
}