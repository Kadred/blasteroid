using Physics;
using UnityEngine;

namespace Portals
{
    public class PortalController : MonoBehaviour
    {
        #region Fields

        [SerializeField] private PortalsSetting settings;
        [SerializeField] private Portal[] portals;

        #endregion


        #region Methods

        public void Initialize(Rect respawnRect, IPhysicService physicService)
        {
            foreach (Portal portal in portals)
            {
                portal.Initialize(settings, respawnRect, physicService);
            }
        }


        public void Deinitialize()
        {
            foreach (Portal portal in portals)
            {
                portal.Deinitialize();
            }
        }

        #endregion
    }
}