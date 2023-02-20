using Physics;
using UnityEngine;


namespace Portals
{
    public class PortalLeft : Portal
    {
        #region Methods

        protected override void SetPortalPositions(Rect respawnRect)
        {
            Vector3 position = new Vector3(respawnRect.x, 0, 0);
            MoveTo(position);

            TransferOffset = respawnRect.x + respawnRect.width;

            CollisionRect = new Rect(position.x - PortalWidth, position.y - respawnRect.height / 2,
                PortalWidth, respawnRect.height);
        }


        public override void OnCollision(IPhysicObject physicObject)
        {
            Vector3 position = physicObject.Position;
            physicObject.MoveTo(new Vector3(TransferOffset - physicObject.CollisionRect.width,
                position.y, position.z));
        }

        #endregion
    }
}