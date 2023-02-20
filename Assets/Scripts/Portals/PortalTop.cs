using Physics;
using UnityEngine;


namespace Portals
{
    public class PortalTop : Portal
    {
        #region Methods

        protected override void SetPortalPositions(Rect respawnRect)
        {
            Vector3 position = new Vector3(0, respawnRect.y + respawnRect.height, 0);
            MoveTo(position);

            TransferOffset = respawnRect.y;
            CollisionRect = new Rect(position.x - respawnRect.width / 2, position.y,
                respawnRect.width, PortalWidth);
        }


        public override void OnCollision(IPhysicObject physicObject)
        {
            Vector3 position = physicObject.Position;
            physicObject.MoveTo(new Vector3(position.x, TransferOffset + physicObject.CollisionRect.height,
                position.z));
        }

        #endregion
    }
}